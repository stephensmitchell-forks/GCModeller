﻿#Region "Microsoft.VisualBasic::1cc999e3f5b3daf83aaa49f4f64c792f, ..\GCModeller\CLI_tools\ProteinInteraction\CLI\CLI.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.DocumentStream
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics
Imports SMRUCC.genomics.Analysis.ProteinTools.Interactions
Imports SMRUCC.genomics.Analysis.ProteinTools.Interactions.BioGRID
Imports SMRUCC.genomics.Analysis.ProteinTools.Interactions.SwissTCS
Imports SMRUCC.genomics.Assembly
Imports SMRUCC.genomics.Assembly.DOOR
Imports SMRUCC.genomics.Assembly.MiST2
Imports SMRUCC.genomics.Data.STRING
Imports SMRUCC.genomics.Data.STRING.SimpleCsv
Imports SMRUCC.genomics.Data.STRING.StringDB.Tsv

<PackageNamespace("Protein.Interactions.Tools", Category:=APICategories.CLI_MAN,
                  Description:="Tools for analysis the protein interaction relationship.",
                  Publisher:="xie.guigang@gcmodeller.org",
                  Url:="http://gcmodeller.org")>
Public Module CLI

    <ExportAPI("--interact.TCS", Usage:="--interact.TCS /door <door.opr> /MiST2 <mist2.xml> /swiss <tcs.csv.DIR> /out <out.DIR>")>
    Public Function TCSParser(args As CommandLine) As Integer
        Dim MiST2 = args("/mist2").LoadXml(Of MiST2)  ' 主要是从这个模块之中获取TCS的基因定义
        Dim DOOR As DOOR = DOOR_API.Load(args("/door"))
        Dim cTkDIR As String = args("/swiss")
        Dim outDIR As String = args.GetValue("/out", App.CurrentDirectory)
        Dim CrossTalks = FileIO.FileSystem.GetFiles(cTkDIR, FileIO.SearchOption.SearchAllSubDirectories, "*.csv") _
            .ToArray(Function(csv) csv.LoadCsv(Of CrossTalks)).Unlist

        For Each rep As Replicon In MiST2.MajorModules

            Dim lstHisk As String() = rep.TwoComponent.get_HisKinase
            Dim lstRR As String() = rep.TwoComponent.GetRR

            For Each HisK As String In lstHisk
                Dim lstChunk As New List(Of CrossTalks)

                For Each RR As String In lstRR

                    Dim p As Double = CrossTalks.CrossTalk(HisK, RR)

                    If DOOR.SameOperon(HisK, RR) Then  ' 同源的？？？
                        If Not p > 0 Then
                            p = 1
                        End If

                        Call lstChunk.Add(New CrossTalks With {.Kinase = HisK, .Regulator = RR, .Probability = p})
                    Else
                        If p > 0 Then
                            Call lstChunk.Add(New CrossTalks With {.Kinase = HisK, .Regulator = RR, .Probability = p})
                        End If
                    End If
                Next

                If Not lstChunk.IsNullOrEmpty Then
                    Call lstChunk.SaveTo(outDIR & $"/{HisK}.csv")
                End If
            Next
        Next

        Return 0
    End Function

    <ExportAPI("/STRING.selects",
               Usage:="/STRING.selects /in <in.DIR/*.Csv> /key <GeneId> /links <links.txt> /maps <maps_id.tsv> [/out <out.DIR/*.Csv>]")>
    <Group(CLIGroupping.STRING_tools)>
    Public Function STRINGSelects(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim links As String = args("/links")
        Dim maps As String = args("/maps")
        Dim key As String = args.GetValue("/key", "GeneId")
        Dim mapsKey As New Dictionary(Of String, String) From {
            {key, NameOf(EntityObject.ID)}
        }
        Dim mapNames As Dictionary(Of String, String) =
            entrez_gene_id_vs_string.BuildMapsFromFile(maps)

        If [in].FileExists Then
            Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".STRING.Csv")
            Dim result As EntityObject() = linksDetail.Selects(
                [in].LoadCsv(Of EntityObject)(maps:=mapsKey),
                linksDetail.LoadFile(links),
                mapNames).ToArray

            Return result.SaveTo(out).CLICode
        Else
            Dim net As linksDetail() = linksDetail.LoadFile(links).ToArray
            Dim EXPORT As String = args.GetValue("/out", [in].TrimDIR & ".STRING_selects/")

            For Each file As String In ls - l - r - wildcards("*.Csv") <= [in]
                Dim result As EntityObject() = file.LoadCsv(Of EntityObject)(maps:=mapsKey)
                Dim out As String = EXPORT & "/" & file.BaseName & ".Csv"

                result = linksDetail.Selects(result, net, mapNames).ToArray
                result.SaveTo(out)
            Next
        End If

        Return 0
    End Function

    <ExportAPI("/STRING.Network",
               Usage:="/STRING.Network /id <uniprot_idMappings.tsv> /links <protein.actions-links.tsv> [/all_links <protein.links.txt> /out <outDIR>]")>
    <Group(CLIGroupping.STRING_tools)>
    Public Function StringNetwork(args As CommandLine) As Integer
        Dim idTsv = args("/id")
        Dim links$ = args("/links")
        Dim alllinks As String = args("/all_links")
        Dim out = args.GetValue("/out", idTsv.TrimSuffix & "-" * links.BaseName & "/")
        Dim maps = Uniprot.Web.SingleMappings(idTsv)
        Dim net As FileStream.Network = If(
            alllinks.FileExists(True),
            maps.MatchNetwork(actions:=links, links:=alllinks),
            maps.MatchNetwork(actions:=links))
        Return net.Save(out).CLICode
    End Function

    <ExportAPI("/BioGRID.selects",
               Usage:="/BioGRID.selects /in <in.DIR/*.Csv> /key <GeneId> /links <BioGRID-links.mitab.txt> [/out <out.DIR/*.Csv>]")>
    Public Function BioGRIDSelects(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim links As String = args("/links")
        Dim key As String = args.GetValue("/key", "GeneId")
        Dim mapsKey As New Dictionary(Of String, String) From {
            {key, NameOf(EntityObject.ID)}
        }

        If [in].FileExists Then
            Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".BioGRID.Csv")
            Dim result As EntityObject() = BioGRID.API.Selects(
                [in].LoadCsv(Of EntityObject)(maps:=mapsKey),
                BioGRID.LoadAllmiTab(links)).ToArray

            Return result.SaveTo(out).CLICode
        Else
            Dim net As ALLmitab() = BioGRID.LoadAllmiTab(links).ToArray
            Dim EXPORT As String = args.GetValue("/out", [in].TrimDIR & ".BioGRID_selects/")

            For Each file As String In ls - l - r - wildcards("*.Csv") <= [in]
                Dim result As EntityObject() = file.LoadCsv(Of EntityObject)(maps:=mapsKey)
                Dim out As String = EXPORT & "/" & file.BaseName & ".Csv"

                result = BioGRID.API.Selects(result, net).ToArray
                result.SaveTo(out)
            Next
        End If

        Return 0
    End Function

    <ExportAPI("/BioGRID.Id.types", Usage:="/BioGRID.Id.types /in <BIOGRID-IDENTIFIERS.tsv> [/out <out.txt>]")>
    Public Function BioGridIdTypes(args As CommandLine) As Integer
        Dim [in] As String = args("/in")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".Types.txt")
        Dim source As IEnumerable(Of IDENTIFIERS) = LoadIdentifiers([in])
        Dim types As String() = source.AllIdentifierTypes
        Return types.SaveTo(out).CLICode
    End Function
End Module
