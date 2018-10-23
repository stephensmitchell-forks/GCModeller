﻿#Region "Microsoft.VisualBasic::9baded6e16fe91440e0a2a0c765e71bd, CLI_tools\Map\CLI\CLI.vb"

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

' Module CLI
' 
'     Function: Draw, DrawGenbank, DrawingChrMap, WriteConfigTemplate
' 
' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService.SharedORM
Imports Microsoft.VisualBasic.CommandLine.ManView
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Oracle.Java.IO.Properties
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.RpsBLAST
Imports SMRUCC.genomics.Visualize
Imports SMRUCC.genomics.Visualize.ChromosomeMap
Imports SMRUCC.genomics.Visualize.ChromosomeMap.Configuration
Imports SMRUCC.genomics.Visualize.ChromosomeMap.DrawingModels
Imports SMRUCC.genomics.Visualize.Extensions

<ExceptionHelp(Documentation:="http://docs.gcmodeller.org", Debugging:="https://github.com/SMRUCC/GCModeller/wiki", EMailLink:="xie.guigang@gcmodeller.org")>
<CLI> Public Module CLI

    <ExportAPI("--Draw.ChromosomeMap",
               Info:="Drawing the chromosomes map from the PTT object as the basically genome information source.",
               Usage:="--Draw.ChromosomeMap /ptt <genome.ptt> [/conf <config.inf> /out <dir.export> /COG <cog.csv>]")>
    <Argument("/COG", True, CLITypes.File,
              AcceptTypes:={GetType(MyvaCOG)},
              Description:="The gene object color definition, you can using this parameter to overrides the cog definition in the PTT file.")>
    Public Function DrawingChrMap(args As CommandLine) As Integer
        Dim PTT = args.GetObject(Of PTT)("/ptt", AddressOf TabularFormat.PTT.Load)
        Dim out As String = args.GetValue("/out", App.CurrentDirectory)
        Dim confInf As String = args.GetValue("/conf", out & "/config.inf")
        Dim COG As String = args("/COG")

        Return PTT.Draw(COG, "", confInf, out)
    End Function

    <ExportAPI("/Config.Template", Usage:="/Config.Template [/out <./config.inf>]")>
    Public Function WriteConfigTemplate(args As CommandLine) As Integer
        Dim conf As String = args.GetValue("/out", "./config.inf")

        With GetDefaultConfiguration(conf)
            Return .ToConfigDoc.SaveTo(conf)
        End With
    End Function

    <Extension>
    Private Function Draw(PTT As PTT, COG$, motifs$, conf$, out$) As Integer
        Dim config As Config

        If Not conf.FileExists(True) Then
Create:     config = ChromosomeMap.GetDefaultConfiguration(conf)
        Else
            Try
                config = ChromosomeMap.LoadConfig(conf)
            Catch ex As Exception
                GoTo Create
            End Try
        End If

        Dim model As ChromesomeDrawingModel = ChromosomeMap.FromPTT(PTT, config)
        Dim COGProfiles As MyvaCOG() = Nothing

        If COG.FileExists(True) Then
            COGProfiles = COG.LoadCsv(Of MyvaCOG).ToArray
            model = ChromosomeMap.ApplyCogColorProfile(model, COGProfiles)
        End If

        If motifs.FileExists Then
            Dim data As EntityObject() = motifs.LoadCsv(Of EntityObject)
            Dim familyList$() = data.Keys _
                .Distinct _
                .ToArray
            Dim colors As Dictionary(Of String, Color)

            With New LoopArray(Of Color)(ChartColors)
                colors = familyList _
                    .ToDictionary(Function(name) name,
                                  Function() .Next)
            End With

            model.MotifSites = data _
                .Select(Function(site)
                            Return New MotifSite With {
                                .Color = colors(site.ID),
                                .Left = site!left,
                                .Right = site!right,
                                .Strand = site!strain,
                                .MotifName = site.ID,
                                .SiteName = site.ID,
                                .Comments = site!src
                            }
                        End Function) _
                .ToArray
            model.MotifSiteColors = colors
        End If

        With config

            Dim output As GraphicsData() =
                .CreateDevice _
                .InvokeDrawing(model)

            If Not COGProfiles.IsNullOrEmpty Then
                output(output.Length - 1) = output _
                    .Last _
                    .DrawCatalogProfiling(
                        COGProfiles,
                        .Margin,
                        "2000,1200")
            End If

            Return output.SaveImage(out, .SavedFormat)
        End With
    End Function

    <ExportAPI("--Draw.ChromosomeMap.genbank")>
    <Usage("--Draw.ChromosomeMap.genbank /gb <genome.gbk> [/motifs <motifs.csv> /conf <config.inf> /out <dir.export> /COG <cog.csv>]")>
    <Description("Draw bacterial genome map from genbank annotation dataset.")>
    Public Function DrawGenbank(args As CommandLine) As Integer
        Dim gb As String = args("/gb")
        Dim out As String = args("/out") Or $"{gb.TrimSuffix}.maps/"
        Dim confInf As String = args("/conf") Or $"{out}/config.inf"
        Dim COG As String = args("/COG")
        Dim PTT As PTT = GBFF.File.Load(gb).GbffToPTT(ORF:=True)
        Dim motifs$ = args <= "/motifs"

        Return PTT.Draw(COG, motifs, confInf, out)
    End Function

    <ExportAPI("/draw.map.region")>
    <Usage("/draw.map.region /gb <genome.gbk> [/COG <cog.csv> /draw.shape.stroke /size <default=10240,2048> /default.color <default=brown> /gene.draw.height <default=85> /disable.level.skip /out <map.png>]")>
    Public Function DrawMapRegion(args As CommandLine) As Integer
        Dim in$ = args <= "/gb"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.map.png"
        Dim PTT As PTT = GBFF.File.Load([in]).GbffToPTT(ORF:=True)
        Dim config As Config = Config.DefaultValue

        With config
            .NoneCogColor = args("/default.color")
        End With

        Dim model As ChromesomeDrawingModel = ChromosomeMap.FromPTT(PTT, config)
        Dim disableLevelSkip As Boolean = args("/disable.level.skip")
        Dim geneDrawHeight% = args("/gene.draw.height") Or 85
        Dim drawShapeStroke As Boolean = args("/draw.shape.stroke")

        With args("/cog").DefaultValue
            If .FileExists(True) Then
                model = model.ApplyCogColorProfile(.LoadCsv(Of MyvaCOG), 235)
            End If
        End With

        Return RegionMap.Plot(
            model:=model,
            size:=args("/size") Or "10240,2048",
            padding:=g.DefaultPadding,
            disableLevelSkip:=disableLevelSkip,
            drawShapeStroke:=drawShapeStroke,
            geneShapeHeight:=geneDrawHeight
        ).Save(out) _
         .CLICode
    End Function
End Module
