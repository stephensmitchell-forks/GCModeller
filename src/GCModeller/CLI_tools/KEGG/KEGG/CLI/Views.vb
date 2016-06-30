﻿Imports LANS.SystemsBiology.Assembly.KEGG.DBGET.BriteHEntry
Imports LANS.SystemsBiology.ProteinModel
Imports LANS.SystemsBiology.Assembly.KEGG.DBGET.bGetObject.SSDB
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Serialization.JSON
Imports LANS.SystemsBiology.Assembly.KEGG.WebServices
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank

Partial Module CLI

    <ExportAPI("/Views.mod_stat", Usage:="/Views.mod_stat /in <KEGG_Modules/Pathways_DIR> /locus <in.csv> [/locus_map Gene /pathway /out <out.csv>]")>
    Public Function Stats(args As CommandLine.CommandLine) As Integer
        Dim inDIR As String = args("/in")
        Dim locus As String = args("/locus")
        Dim locus_map As String = args.GetValue("/locus_map", "Gene")
        Dim ispathway As String = args.GetBoolean("/pathway")
        Dim out As String = args.GetValue("/out", locus.TrimFileExt & $"-{inDIR.BaseName}.csv")
        Dim modsCls As ModuleClassAPI =
            If(ispathway,
            ModuleClassAPI.FromPathway(inDIR),
            ModuleClassAPI.FromModules(inDIR))
        Dim locusId As String() = EntityObject.LoadDataSet(locus, locus_map).ToArray(Function(x) x.Identifier)
        Dim LQuery = (From x In modsCls.Modules
                      Select x.EntryId,
                          locus_id = (From sid As String
                                      In x.GetPathwayGenes
                                      Where Array.IndexOf(locusId, sid) > -1
                                      Select sid).ToArray).ToList
        Return LQuery > out
    End Function

    <ExportAPI("/Get.prot_motif", Usage:="/Get.prot_motif /query <sp:locus> [/out out.json]")>
    Public Function ProteinMotifs(args As CommandLine.CommandLine) As Integer
        Dim query As String = args - "/query"
        Dim out As String = args.GetValue("/out", App.CurrentDirectory & $"/{query.NormalizePathString}.json")
        Dim prot As Protein = ProtMotifsQuery.Query(query)
        Return prot.GetJson.SaveTo(out).CLICode
    End Function

    <ExportAPI("/Gets.prot_motif",
               Usage:="/Gets.prot_motif /query <query.txt/genome.PTT> [/PTT /sp <kegg-sp> /out <out.json> /update]")>
    Public Function GetsProteinMotifs(args As CommandLine.CommandLine) As Integer
        Dim query As String = args("/query")
        Dim out As String = args.GetValue("/out", query.TrimFileExt & ".prot_motifs.json")
        Dim TEMP As String = out & ".temp/"

        ' If out.FileExists AndAlso Not args.GetBoolean("/update") Then
        ' Return 0
        ' Else
        Call $"Data will save to {out.ToFileURL}".__DEBUG_ECHO
        ' End If

        Dim isPTT As Boolean = args.GetBoolean("/PTT")
        Dim locus As QuerySource

        If isPTT Then
            Dim PTT As PTT = TabularFormat.PTT.Load(query)
            locus = New QuerySource With {
                .genome = PTT.Title,
                .locusId = PTT.GeneIDList.ToArray
            }
        Else
            locus = QuerySource.DocParser(query)
        End If

        Dim sp As String = args.GetValue("/sp", locus.QuerySpCode)
        Dim result As New Dictionary(Of Protein)

        If String.IsNullOrEmpty(sp) Then
            Return -100
        End If

        If out.FileExists Then
            result = New Dictionary(Of Protein)(out.ReadAllText.LoadObject(Of Protein()))
        End If

        For Each locusId As String In locus.locusId
            Dim tmp As String = TEMP & $"/{locusId}.json"

            If result.ContainsKey(locusId) Then
                If Not result(locusId).Domains.IsNullOrEmpty Then
                    Continue For
                Else
                    result -= locusId
                End If
            End If

            Dim prot As Protein

            If tmp.FileExists Then
                prot = tmp.ReadAllText.LoadObject(Of Protein)
                If Not prot.Domains.IsNullOrEmpty Then
                    result += prot
                    Continue For
                End If
            End If

            prot = ProtMotifsQuery.Query(sp, locusId)

            If Not prot Is Nothing Then
                result += prot
                Call prot.GetJson.SaveTo(tmp)
            End If
        Next

        Return result.Values.ToArray.GetJson.SaveTo(out)
    End Function
End Module