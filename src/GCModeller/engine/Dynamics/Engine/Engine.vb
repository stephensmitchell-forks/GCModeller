﻿#Region "Microsoft.VisualBasic::2d8de1fcb622c6e0ace5d3f0d3f8c3f3, engine\Dynamics\Engine\Engine.vb"

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

'     Class Engine
' 
'         Function: GetMass
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ApplicationServices.Development
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Terminal.ProgressBar
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Core
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model

Namespace Engine

    Public Class Engine : Implements ITaskDriver

        Dim mass As MassTable

        ''' <summary>
        ''' The biological flux simulator engine core module
        ''' </summary>
        Dim core As Vessel
        Dim def As Definition
        Dim model As CellularModule
        Dim iterations As Integer = 5000
        Dim dataStorageDriver As OmicsDataAdapter

#Region "Debug views"

        Public ReadOnly Property viewTranscriptome As Dictionary(Of String, Double)
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return mass _
                    .GetByKey(dataStorageDriver.mass.transcriptome) _
                    .ToDictionary(Function(mass) mass.ID,
                                  Function(mass)
                                      Return mass.Value
                                  End Function)
            End Get
        End Property

        Public ReadOnly Property viewProteome As Dictionary(Of String, Double)
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return mass _
                    .GetByKey(dataStorageDriver.mass.proteome) _
                    .ToDictionary(Function(mass) mass.ID,
                                  Function(mass)
                                      Return mass.Value
                                  End Function)
            End Get
        End Property

        Public ReadOnly Property viewMetabolome As Dictionary(Of String, Double)
            Get
                Return mass _
                    .GetByKey(dataStorageDriver.mass.metabolome) _
                    .ToDictionary(Function(mass) mass.ID,
                                  Function(mass)
                                      Return mass.Value
                                  End Function)
            End Get
        End Property

#End Region

        Sub New(def As Definition, Optional iterations% = 5000)
            Me.def = def
            Me.iterations = iterations
        End Sub

        Public Function AttachBiologicalStorage(driver As OmicsDataAdapter) As Engine
            dataStorageDriver = driver
            Return Me
        End Function

        Public Function LoadModel(virtualCell As CellularModule, deletions As IEnumerable(Of String), Optional timeResolution# = 1000) As Engine
            Dim loader As New Loader(def)
            Dim cell As Core.Vessel = loader _
                .CreateEnvironment(virtualCell) _
                .Initialize(timeResolution)

            core = cell
            mass = loader.massTable
            model = virtualCell

            Call Reset()

            ' 在这里完成初始化后
            ' 再将对应的基因模板的数量设置为0
            ' 达到无法执行转录过程反应的缺失突变的效果
            For Each geneTemplateId As String In deletions
                mass.GetByKey(geneTemplateId).Value = 0
            Next

            Return Me
        End Function

        ''' <summary>
        ''' Reset the reactor engine. (Do reset of the biological mass contents)
        ''' </summary>
        Public Sub Reset()
            For Each mass As Factor In Me.mass
                If def.status.ContainsKey(mass.ID) Then
                    mass.Value = def.status(mass.ID)
                Else
                    mass.Value = 1
                End If
            Next
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetMass(names As IEnumerable(Of String)) As IEnumerable(Of Factor)
            Return mass.GetByKey(names)
        End Function

        Public Function Run() As Integer Implements ITaskDriver.Run
            Call VBDebugger.WaitOutput()
            Call GetType(Engine).Assembly _
                .FromAssembly _
                .DoCall(Sub(assm)
                            CLITools.AppSummary(assm, "Welcome to use SMRUCC/GCModeller virtual cell simulator!", Nothing, App.StdOut)
                        End Sub)
            Call Console.WriteLine()

            Using process As New ProgressBar("Running simulator...")
                Dim progress As New ProgressProvider(iterations)
                Dim flux As Dictionary(Of String, Double)

                For i As Integer = 0 To iterations
                    flux = core _
                        .ContainerIterator() _
                        .ToDictionary _
                        .FlatTable

                    Call dataStorageDriver.FluxSnapshot(i, flux)
                    Call dataStorageDriver.MassSnapshot(i, mass.GetMassValues)
                    Call ($"iteration: {i + 1}; ETA: {progress.ETA(process.ElapsedMilliseconds).FormatTime}") _
                        .DoCall(Sub(msg)
                                    Call process.SetProgress(progress.StepProgress, msg)
                                End Sub)
                Next
            End Using

            Return 0
        End Function
    End Class
End Namespace
