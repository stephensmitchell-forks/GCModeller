﻿Imports System.Xml.Serialization
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.MEME
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.TomTOM
Imports LANS.SystemsBiology.SequenceModel
Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic

Namespace Programs

    ''' <summary>
    ''' Quantifying similarity between motifs
    ''' </summary>
    ''' 
    <PackageNamespace("TomTOM",
                      Category:=APICategories.ResearchTools,
                      Description:="Quantifying similarity between motifs")>
    <Cite(Title:="Quantifying similarity between motifs",
      Abstract:="A common question within the context of de novo motif discovery is whether a newly discovered, putative motif resembles any previously discovered motif in an existing database. 
To answer this question, we define a statistical measure of motif-motif similarity, and we describe an algorithm, called Tomtom, for searching a database of motifs with a given query motif. 
Experimental simulations demonstrate the accuracy of Tomtom's E values and its effectiveness in finding similar motifs.",
      AuthorAddress:="Department of Genome Sciences, University of Washington, 1705 NE Pacific Street, Box 355065, Seattle, WA 98195, USA. shobhitg@u.washington.edu",
      Authors:="Gupta, S.
Stamatoyannopoulos, J. A.
Bailey, T. L.
Noble, W. S.", DOI:="10.1186/gb-2007-8-2-r24", ISSN:="1474-760X (Electronic)
1474-7596 (Linking)",
      Issue:="2",
      Journal:="Genome Biol",
      Keywords:="*Algorithms
Amino Acid Motifs/*genetics
Computational Biology/*methods
*Databases, Genetic
*Sequence Homology
*Software",
      Notes:="Gupta, Shobhit
Stamatoyannopoulos, John A
Bailey, Timothy L
Noble, William Stafford
eng
England
2007/02/28 09:00
Genome Biol. 2007;8(2):R24.",
      Pages:="R24",
      URL:="",
      Year:=2007,
      Volume:=8,
      PubMed:=17324271)>
    Public Module TomTOM

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="inDIR">like F:\2015.12.21.RegPrecise\TOM\kgModules\250</param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("Load.Similarity")>
        Public Function LoadsSimilarity(inDIR As String,
                                        Optional simplifyId As Boolean = True,
                                        Optional blocks As Boolean = False) As MotifMatch()

            Dim lstModules As IEnumerable(Of String) =
                FileIO.FileSystem.GetDirectories(inDIR, FileIO.SearchOption.SearchTopLevelOnly)  ' 途径
            Dim getName As Func(Of String, String) = If(blocks, Function(s) inDIR.BaseName, Function(s) s)
            Dim lstFamily = (From modDIR As String
                             In lstModules.AsParallel
                             Let id As String = If(simplifyId,
                                 IO.Path.GetFileNameWithoutExtension(modDIR),
                                 FileIO.FileSystem.GetDirectoryInfo(modDIR).Name)
                             Let familyMatches = FileIO.FileSystem.GetFiles(modDIR, FileIO.SearchOption.SearchAllSubDirectories, "tomtom.xml")
                             Where Not familyMatches.IsNullOrEmpty
                             Select modId = id,
                             Family = familyMatches _
                                .ToDictionary(AddressOf ParentDirName,
                                              Function(path) TOMText.LoadDoc(path.TrimFileExt & ".txt"))).ToArray
            Dim copy As New Serialization.ShadowsCopyOpr(Of TOMText, MotifMatch)
            Dim LQuery As MotifMatch() =
            LinqAPI.Exec(Of MotifMatch) <= From [mod]
                                           In lstFamily
                                           Let matches = __copy(getName([mod].modId), [mod].Family, copy, simplifyId)
                                           Where Not matches.IsNullOrEmpty
                                           Select matches
            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="modId"></param>
        ''' <param name="matches"></param>
        ''' <param name="copy"></param>
        ''' <param name="simplifyId"></param>
        ''' <returns></returns>
        Private Function __copy(modId As String,
                                matches As Dictionary(Of String, TOMText()),
                                copy As Serialization.ShadowsCopyOpr(Of TOMText, MotifMatch),
                                simplifyId As Boolean) As MotifMatch()

            Dim family = From x In matches Where Not x.Value.IsNullOrEmpty Select x
            Dim copies = (From x In family
                          Select FamilyName =
                             If(simplifyId,
                             IO.Path.GetFileNameWithoutExtension(x.Key),
                             x.Key),
                             matchesValue = From query As TOMText
                                            In x.Value
                                            Select copy.ShadowCopy(query)).ToArray
            Dim result As New List(Of MotifMatch)

            For Each x In copies
                For Each query As MotifMatch In x.matchesValue
                    query.Module = modId
                    query.Family = x.FamilyName

                    result += query
                Next
            Next

            Return result
        End Function

        <ExportAPI("Build.Similarity")>
        Public Function BuildSimilarity(TOMTOM As String, MEME_OUT As String, Optional hashTag As String = "") As MotifMatch()
            Dim motifs As Dictionary(Of String, LDM.Motif()) = LoadSource(inDIR:=MEME_OUT)
            Dim Matches As MotifMatch() = LoadsSimilarity(inDIR:=TOMTOM)
            Matches = BuildSimilarity(motifs, Matches)

            If Not String.IsNullOrEmpty(hashTag) Then
                For Each motif As MotifMatch In Matches
                    motif.Module = $"{hashTag}/{motif.Module}"
                Next
            End If

            Return Matches
        End Function

        Sub New()
            Call Settings.Session.Initialize()
        End Sub

        <ExportAPI("Build.Similarity")>
        Public Function BuildSimilarity(motifs As Dictionary(Of String, LDM.Motif()), matches As IEnumerable(Of MotifMatch)) As MotifMatch()
            Dim sites = (From motif
                     In motifs
                         Select From x As LDM.Motif
                            In motif.Value
                                Select id = $"{motif.Key}.{x.Id}",
                                x).MatrixAsIterator _
                                .ToDictionary(Function(x) x.id,
                                              Function(x) x.x)
            Dim LQuery As MotifMatch() =
            LinqAPI.Exec(Of MotifMatch) <= From match As MotifMatch In matches
                                           Let uid As String = $"{match.Module}.{match.Query}"
                                           Where sites.ContainsKey(uid)
                                           Select __copy(sites(uid), match)
            Return LQuery
        End Function

        Private Function __copy(motif As LDM.Motif, match As MotifMatch) As MotifMatch()
            Dim copy As New Serialization.ShadowsCopyOpr(Of MotifMatch)

            match.MEMEEvalue = motif.Evalue
            match.Width = motif.Width

            Dim LQuery As MotifMatch() =
            LinqAPI.Exec(Of MotifMatch) <= From site As LDM.Site
                                           In motif.Sites
                                           Let siteCopy As MotifMatch =
                                               copy.ShadowCopy(match)
                                           Select __copy(site, siteCopy)
            Return LQuery
        End Function

        Private Function __copy(site As LDM.Site, match As MotifMatch) As MotifMatch
            With match
                .LocusId = site.Name
                .MEMEPvalue = site.Pvalue
                .Right = site.Right
                .Site = site.GetSequenceData
                .Start = site.Start
            End With

            Return match
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="inDIR">MEME_OUT</param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("Load.Motifs")>
        Public Function LoadSource(inDIR As String) As Dictionary(Of String, LDM.Motif())
            Dim lstFile As IEnumerable(Of String) = ls - l - r - wildcards("*.txt") <= inDIR
            Dim lstMEME = (From path As String
                       In lstFile.AsParallel
                           Let modId As String = IO.Path.GetFileNameWithoutExtension(path)
                           Let Motifs As LDM.Motif() = Text.Load(path)
                           Where Not Motifs.IsNullOrEmpty
                           Select modId,
                           Motifs) _
                           .ToDictionary(Function(x) x.modId,
                                         Function(x) x.Motifs)
            Return lstMEME
        End Function
    End Module
End Namespace