﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.MEME.LDM
Imports LANS.SystemsBiology.AnalysisTools.SequenceTools.SequencePatterns
Imports LANS.SystemsBiology.AnalysisTools.SequenceTools.SequencePatterns.SequenceLogo
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.ComponentModel
Imports Microsoft.VisualBasic.Imaging

Public Module SequenceLogoAPI

#Region "Model API"
    Public Function CreateObject(LDM As Analysis.MotifScans.AnnotationModel) As DrawingModel
        Dim residues As Residue() = LDM.PspMatrix.ToArray(AddressOf DrawingModel.NTResidue)
        Dim model As DrawingModel = New DrawingModel With {
                .ModelsId = LDM.ToString,
                .Residues = residues.AddHandle.ToArray
            }
        Return model
    End Function

    Public Function GenerateFromMEMEMotif(Motif As MEME.LDM.Motif) As DrawingModel
        Dim Alphabets As Char() = If(Motif.NtMolType,
                ColorSchema.NucleotideSchema.Keys.ToArray,
                ColorSchema.ProteinSchema.Keys.ToArray)
        Dim En As Double = E(s:=Alphabets.Count, n:=Motif.Sites.Length)
        Dim rsd = (From residue As MotifPM
                       In Motif.PspMatrix
                   Select DrawingModel.NTResidue(residue)).ToArray.AddHandle.ToArray
        Dim Model As DrawingModel = New DrawingModel With {
                .Residues = rsd,
                .En = En,
                .ModelsId = Motif.uid
            }

        Return Model
    End Function
#End Region

    ''' <summary>
    ''' Load the motif data from the meme text format calculation result
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    <ExportAPI("Load.MEME_Text.Motifs", Info:="Load the motif data from the meme text format calculation result")>
    Public Function LoadMotif(Path As String) As Motif()
        Dim data As Motif() = MEME.Text.Load(path:=Path)
        Return data
    End Function

    ''' <summary>
    ''' Create the sequence logo from the meme motif calculation reuslt.
    ''' </summary>
    ''' <param name="Motif"></param>
    ''' <returns></returns>
    <ExportAPI("Model.From.MEME_Motif", Info:="Create the sequence logo from the meme motif calculation reuslt.")>
    Public Function GenerateModel(Motif As Motif) As SequenceLogo.DrawingModel
        Return GenerateFromMEMEMotif(Motif)
    End Function

    <ExportAPI("Invoke.Drawing", Info:="Drawing a sequence logo from a generated sequence motif model.")>
    <Extension>
    Public Function DrawLogo(LDM As Analysis.MotifScans.AnnotationModel,
                         <Parameter("Order.Frequency", "Does the alphabets in a residue position will be ordered its drawing order based on their relative frequency in the residue site?")>
                         Optional FrequencyOrder As Boolean = True,
                         Optional Margin As Integer = 200,
                         Optional reverse As Boolean = False) As Image
        Dim model As DrawingModel = CreateObject(LDM)
        Return SequenceLogo.InvokeDrawing(model, FrequencyOrder, Margin, reverse)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="MEME_Text">file path of the meme.txt inputs</param>
    ''' <param name="outDIR"></param>
    ''' <returns></returns>
    <ExportAPI("Invoke.Drawing.Batch", Info:="Drawing the sequence logo from all of the motifs in a meme.txt output file.")>
    Public Function BatchDrawing(<Parameter("MEME_Text.Path")> MEME_Text As String,
                                 <Parameter("Out.DIR")> Optional outDIR As String = "") As Boolean

        Dim ID As String = IO.Path.GetFileNameWithoutExtension(MEME_Text)
        Dim Motifs As Motif() = DocumentFormat.MEME.Text.Load(MEME_Text)

        If String.IsNullOrEmpty(outDIR) Then
            outDIR = FileIO.FileSystem.GetParentPath(MEME_Text)
        End If

        For Each Motif As Motif In Motifs
            Dim Model As DrawingModel = GenerateFromMEMEMotif(Motif)
            Dim res As Image = DrawingDevice.InvokeDrawing(Model)
            Dim Path As String = $"{outDIR}/{ID}.{Motif.Id}.png"

            res = res.CorpBlank(25)

            Call res.SaveAs(Path, format:=ImageFormats.Png)
            Call $"{Path.ToFileURL} saved....".__DEBUG_ECHO
        Next

        Return True
    End Function

    <ExportAPI("Invoke.Drawing.Batch")>
    Public Function BatchDrawingFromDirectory(inDIR As String) As Boolean
        Dim LQuery = (From File As String
                      In FileIO.FileSystem.GetFiles(inDIR, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
                      Select BatchDrawing(MEME_Text:=File)).ToArray
        Return Not LQuery.IsNullOrEmpty
    End Function
End Module