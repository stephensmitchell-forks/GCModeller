﻿#Region "Microsoft.VisualBasic::867b6dfeb115737b9ea38014f5db373c, RNA-Seq\RNA-seq.Data\SAM\SAM.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    '     Class SAM
    ' 
    '         Properties: AlignmentsReads, Head
    ' 
    '         Function: Assembling, Load, Save, TrimUnmappedReads
    ' 
    '         Sub: Assembling
    '         Delegate Function
    ' 
    '             Function: GetEnumerator, IEnumerable_GetEnumerator
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Terminal.Utility
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel.SAM

Namespace SAM

    ''' <summary>
    ''' The Sequence Alignment/Map (SAM) format is a generic nucleotide alignment format that describes the alignment of query sequences or sequencing reads to a reference sequence or assembly. 
    ''' Importantly:
    '''
    ''' It is flexible enough to store all the alignment information generated by various alignment programs;
    ''' It is simple enough to be easily generated by alignment programs or converted from existing alignment formats;
    ''' It is compact in file size;
    ''' It allows most of the operations on the alignment to work on a stream without loading the whole alignment into memory;
    ''' It allows the file to be indexed by genomic position to efficiently retrieve all reads aligning to a locus.
    '''
    ''' SAM is a tab-delimited text format. SAM is a bit slow to parse; so there is a binary equivalent to SAM, called BAM.
    '''
    ''' SAM allows optional fields to be stored. In SAM, each alignment must contain a fixed number of mandatory fields that describe 
    ''' the key information about the alignment (such as coordinate detailed alignment and sequences) and may contain a variable 
    ''' number of optional fields which are less important or aligner specific.
    ''' 
    ''' SAM is able to store clipped alignments, spliced alignments, multi-part alignments, padded alignments and alignments in colour space. 
    ''' The extended CIGAR string is the key to describing these types of alignments.
    ''' </summary>
    ''' <remarks>
    ''' SAM stands for Sequence Alignment/Map format. It is a TAB-delimited text format consisting of a
    ''' header section, which is optional, and an alignment section. If present, the header must be prior to
    ''' the alignments. Header lines start with `@', while alignment lines do not. Each alignment line has 11
    ''' mandatory fields for essential alignment information such as mapping position, and variable number of 
    ''' optional fields for flexible or aligner specific information.
    ''' 
    ''' SAM格式的文件是一种序列比对文件，使用TAB符号进行分隔，文件的格式为一个可选的标题头部区域，标题头部使用@符号起始而比对区域则不需要
    ''' 每一行序列比对的数据有11个域用于储存比对信息，诸如：mapping的位置之类
    ''' </remarks>
    Public Class SAM : Inherits ITextFile
        Implements IEnumerable(Of AlignmentReads)

#If DEBUG Then
        Public Const CHUNK_SIZE As Integer = 32 * 1024 * 1024
#Else
        Public Const CHUNK_SIZE As Integer = 128 * 1024 * 1024
#End If

        ''' <summary>
        ''' If present, the header must be prior to the alignments. Header lines start With `@', while alignment lines do not.
        ''' (文件的可选头部区域必须要在比对数据区域的前面并且每一行以@符号开始)
        ''' </summary>
        Public Property Head As SAMHeader()

        ''' <summary>
        ''' The object of this value is the details alignment data.
        ''' </summary>
        ''' <returns></returns>
        Public Property AlignmentsReads As AlignmentReads()

#Region "SAM Parser"

        ''' <summary>
        ''' 从一个文本文件之中加载一个SAM格式的文件数据
        ''' </summary>
        ''' <param name="Path"></param>
        ''' <param name="encoding">Default value is utf8 encoding.</param>
        ''' <returns></returns>
        Public Shared Function Load(Path As String, Optional encoding As Encodings = Encodings.UTF8) As SAM
            Dim IO As New SAMStream(Path, encoding)
            Dim readsBuffer As AlignmentReads() = IO.IteratesAllReads.ToArray

            Call $"There are {readsBuffer.Length} alignment reads in the sam mapping file  {Path.ToFileURL}".__DEBUG_ECHO
            Call FlushMemory()

            Return New SAM With {
                .AlignmentsReads = readsBuffer,
                .FilePath = Path,
                .Head = IO.IteratesAllHeaders.ToArray
            }
        End Function
#End Region

        Public Overrides Function Save(Optional FilePath As String = "", Optional Encoding As Encoding = Nothing) As Boolean
            Dim LQuery = (From Reads In Me.AsParallel Select Reads.GenerateDocumentLine).ToArray
            Dim Header As String() = (From Head In Me.Head Select Head.GenerateDocumentLine).ToArray

            FilePath = getPath(FilePath)
            Call FileIO.FileSystem.CreateDirectory(FileIO.FileSystem.GetParentPath(FilePath))
            Encoding = getEncoding(encoding:=Encoding)
            Call IO.File.WriteAllLines(FilePath, Header, encoding:=Encoding)
            For Each TempChunk In LQuery.Split(40960)
                Call FileIO.FileSystem.WriteAllText(FilePath, String.Join(vbCrLf, TempChunk), append:=True, encoding:=Encoding)
            Next

            Return True
        End Function

        ''' <summary>
        ''' 移除没有被mapping到基因组上面的reads
        ''' </summary>
        ''' <returns></returns>
        Public Function TrimUnmappedReads() As SAM
            Dim mapped As AlignmentReads() =
                LinqAPI.Exec(Of AlignmentReads) <=
 _
                    From reads As AlignmentReads
                    In Me.AlignmentsReads.AsParallel
                    Where reads.IsUnmappedReads  ' 这个符号表示没有被Mapping到
                    Select reads

            Return New SAM With {
                .Head = Head,
                .AlignmentsReads = mapped,
                .FilePath = FilePath
            }
        End Function

        ''' <summary>
        ''' 对当前的这个Mapping之中的Reads进行装配
        ''' </summary>
        Public Sub Assembling(ByRef Forwards As Contig()， ByRef Reversed As Contig(), Optional TrimError As Boolean = True)
            Dim AlignmentReads As AlignmentReads() = Me.AlignmentsReads.ToArray

            If TrimError Then
                AlignmentReads = (From ReadMapping In AlignmentReads.AsParallel
                                  Where Not ReadMapping.IsUnmappedReads AndAlso
                                      Not ReadMapping.LowQuality
                                  Select ReadMapping).ToArray  '筛选出前面三个碱基没有包含错误，并且片段长度大于等于18的Reads
            End If

            Dim FwAyHandle = Function() (From Read In AlignmentReads.AsParallel
                                         Where Read.Strand = Strands.Forward
                                         Select Read
                                         Group Read By Read.POS Into Group).ToArray
            Dim FwStart = FwAyHandle.BeginInvoke(Nothing, Nothing)

            Call $"Get reads on the reversed strand....".__DEBUG_ECHO
            Dim ReversedReads = (From Read In AlignmentReads.AsParallel
                                 Where Read.Strand = Strands.Reverse
                                 Select Read
                                 Group Read By Read.POS Into Group).ToArray
            Call $"Get reads on the forwards strand....".__DEBUG_ECHO
            Dim ForwardReads = FwAyHandle.EndInvoke(FwStart)

#If DEBUG Then

            Reversed = Assembling(New Dictionary(Of Integer, List(Of AlignmentReads))((From gr In ReversedReads Select gr Order By gr.POS Descending).ToArray.ToDictionary(
                                                Function(obj) obj.POS,
                                                elementSelector:=Function(obj) obj.Group.AsList)), True)
            Forwards = Assembling(New SortedDictionary(Of Integer, List(Of AlignmentReads))(ForwardReads.ToDictionary(
                                                          Function(obj) obj.POS,
                                                          elementSelector:=Function(obj) obj.Group.AsList)).ToDictionary(Function(obj) obj.Key, elementSelector:=Function(obj) obj.Value), False)

#Else
            Dim AssemblyTask = Function() Assembling(
                New SortedDictionary(Of Integer, List(Of AlignmentReads))(ForwardReads.ToDictionary(
                                                          Function(obj) obj.POS,
                                                          elementSelector:=Function(obj) obj.Group.AsList)).ToDictionary(Function(obj) obj.Key, elementSelector:=Function(obj) obj.Value), False)
            FwStart = AssemblyTask.BeginInvoke(Nothing, Nothing)

            Reversed = Assembling(New Dictionary(Of Integer, List(Of AlignmentReads))((From gr In ReversedReads Select gr Order By gr.POS Descending).ToArray.ToDictionary(
                                                Function(obj) obj.POS,
                                                elementSelector:=Function(obj) obj.Group.AsList)), True)
            Forwards = AssemblyTask.EndInvoke(FwStart)
#End If
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Alignment">请注意先按照方向排序</param>
        ''' <param name="Reversed"></param>
        ''' <returns></returns>
        Private Shared Function Assembling(Alignment As Dictionary(Of Integer, List(Of AlignmentReads)), Reversed As Boolean) As Contig()
            Dim ChunkBuffer As New List(Of Contig)
            Dim p As New EventProc(Alignment.Count)

            Do While Alignment.Count > 0

                Dim CurrentGroup = Alignment.First.Value

                Do While CurrentGroup.Count > 0

                    Dim CurrentReads = CurrentGroup(Scan0)
                    Call CurrentGroup.RemoveAt(Scan0)

                    Dim CurrentReadList As New List(Of AlignmentReads) From {CurrentReads}
                    Dim d As Integer = -1 * Math.Sign(CurrentReads.POS - CurrentReads.PNEXT) 'd等于-1表示反向即POS大于PNEXT

                    Do While True

                        If Not Alignment.ContainsKey(CurrentReads.PNEXT) Then
                            Exit Do
                        End If

                        Dim NextReadGroup = Alignment(CurrentReads.PNEXT)

                        If NextReadGroup.IsNullOrEmpty Then '已经被读取完了
                            Call Alignment.Remove(CurrentReads.PNEXT)
                            Exit Do
                        End If

                        Dim NextReads = (From read In NextReadGroup.AsParallel
                                         Where Math.Sign(read.POS - read.PNEXT) <> d  '请注意，d在初始化的时候乘以-1倍反向了，所以这里为不等于
                                         Select read).FirstOrDefault ' (Scan0)

                        If NextReads Is Nothing Then
                            Exit Do
                        End If

                        Call NextReadGroup.Remove(NextReads)

                        Call CurrentReadList.Add(NextReads)

                        CurrentReads = NextReads
                    Loop

#If DEBUG Then
                    If CurrentReadList.Count > 1 Then
                        Call Console.WriteLine("-")
                    End If
#End If


                Loop '当前的这个Reads装配完了

                Call Alignment.Remove(Alignment.First.Key)
                ' Call Console.Write(".")
                Call p.Tick()
            Loop

            Return ChunkBuffer.ToArray
        End Function

        Private Delegate Function InvokeAssembling(Reads As List(Of AlignmentReads)) As Contig

#Region "Implements IEnumerable(Of AlignmentReads).GetEnumerator"

        Public Iterator Function GetEnumerator() As IEnumerator(Of AlignmentReads) Implements IEnumerable(Of AlignmentReads).GetEnumerator
            For i As Integer = 0 To Me.AlignmentsReads.Count - 1
                Yield AlignmentsReads(i)
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
#End Region

    End Class
End Namespace
