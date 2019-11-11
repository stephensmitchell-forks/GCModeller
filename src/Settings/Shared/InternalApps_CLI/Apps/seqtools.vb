﻿Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\seqtools.exe

' 
'  // 
'  // SMRUCC genomics GCModeller Programs Profiles Manager
'  // 
'  // VERSION:   3.3277.7251.18537
'  // ASSEMBLY:  Settings, Version=3.3277.7251.18537, Culture=neutral, PublicKeyToken=null
'  // COPYRIGHT: Copyright © SMRUCC genomics. 2014
'  // GUID:      a554d5f5-a2aa-46d6-8bbb-f7df46dbbe27
'  // BUILT:     11/8/2019 10:17:54 AM
'  // 
' 
' 
'  Sequence operation utilities
' 
' 
' SYNOPSIS
' Settings command [/argument argument-value...] [/@set environment-variable=value...]
' 
' All of the command that available in this program has been list below:
' 
'  /Count:                                  
'  /Fasta.Subset.Large:                     
'  /Genotype:                               
'  /Genotype.Statics:                       
'  /logo:                                   * Drawing the sequence logo from the clustal alignment result.
'  /motifs:                                 Populate possible motifs from a give nt fasta sequence dataset.
'  /NeedlemanWunsch.NT:                     
'  /Promoter.Palindrome.Fasta:              
'  /Promoter.Regions.Palindrome:            
'  /Promoter.Regions.Parser.gb:             
'  /Rule.dnaA_gyrB:                         Create a ruler fasta sequence for DNA sequence distance
'                                           computing.
'  /Rule.dnaA_gyrB.Matrix:                  
'  /ruler.dist.calc:                        
'  /Sites2Fasta:                            Converts the simple segment object collection as fasta file.
'  -321:                                    Polypeptide sequence 3 letters to 1 lettes sequence.
'  -complement:                             
'  --Drawing.ClustalW:                      
'  -pattern_search:                         Parsing the sequence segment from the sequence source using
'                                           regular expression.
'  -reverse:                                
'  --translates:                            Translates the ORF gene as protein sequence. If any error
'                                           was output from the console, please using > operator dump
'                                           the output to a log file for the analysis.
' 
' 
' API list that with functional grouping
' 
' 1. DNA_Comparative tools
' 
' 
'    /CAI:                                    
'    /gwANI:                                  Given a multi-FASTA alignment, output the genome wide average
'                                             nucleotide identity (gwANI) for Each sample against all
'                                             other samples. A matrix containing the percentages Is outputted.
'    /Sigma:                                  Create a distance similarity matrix for the input sequence.
' 
' 
' 2. Fasta Sequence Tools
' 
'    Tools command that works around the fasta format data.
' 
' 
'    /Compare.By.Locis:                       
'    /Distinct:                               Distinct fasta sequence by sequence content.
'    /Excel.2Fasta:                           Convert the sequence data in a excel annotation file into
'                                             a fasta sequence file.
'    /Get.Locis:                              
'    /Gff.Sites:                              
'    /Merge:                                  Only search for 1 level folder, dit not search receve.
'    /Merge.Simple:                           This tools just merge the fasta sequence into one larger
'                                             file.
'    /Select.By_Locus:                        Select fasta sequence by local_tag.
'    /Split:                                  
'    /subset:                                 
'    -segment:                                
'    --segments:                              
'    --Trim:                                  
' 
' 
' 3. Nucleotide Sequence Property Calculation tools
' 
' 
'    /Mirrors.Context:                        This function will convert the mirror data to the simple
'                                             segment object data
'    /Mirrors.Context.Batch:                  This function will convert the mirror data to the simple
'                                             segment object data
'    /Mirrors.Group:                          
'    /Mirrors.Group.Batch:                    
'    /SimpleSegment.AutoBuild:                
'    /SimpleSegment.Mirrors:                  
'    /SimpleSegment.Mirrors.Batch:            
' 
' 
' 4. Palindrome batch task tools
' 
' 
'    /check.attrs:                            
'    /Palindrome.BatchTask:                   
'    /Palindrome.Workflow:                    
' 
' 
' 5. Sequence Aligner
' 
' 
'    /align.SmithWaterman:                    
'    /Clustal.Cut:                            
'    /nw:                                     RunNeedlemanWunsch
'    --align:                                 
'    --align.Self:                            
' 
' 
' 6. Sequence Palindrome Features Analysis
' 
'    Tools command that using for finding Palindrome sites.
' 
' 
'    /Mirror.Batch:                           
'    /Mirror.Fuzzy:                           Search mirror loci sites on your sequence.
'    /Mirror.Fuzzy.Batch:                     
'    /Mirror.Vector:                          
'    /Mirrors.Nt.Trim:                        
'    /Palindrome.Screen.MaxMatches:           
'    /Palindrome.Screen.MaxMatches.Batch:     
'    --Hairpinks:                             
'    --Hairpinks.batch.task:                  
'    --ImperfectsPalindrome.batch.Task:       
'    --Mirror.From.Fasta:                     Mirror Palindrome, search from a fasta file.
'    --Mirror.From.NT:                        Mirror Palindrome, and this function is for the debugging
'                                             test
'    --Palindrome.batch.Task:                 
'    --palindrome.From.FASTA:                 
'    --Palindrome.From.NT:                    This function is just for debugger test, /nt parameter is
'                                             the nucleotide sequence data as ATGCCCC
'    --Palindrome.Imperfects:                 Gets all partly matched palindrome sites.
'    --PerfectPalindrome.Filtering:           
'    --ToVector:                              
' 
' 
' 7. Sequence Repeats Loci Search
' 
' 
'    /loci.Density:                           Do statistics of the loci density on a specific sequence.
'    /Screen.sites:                           
'    /Search.Repeats:                         Search for repeats sequence loci sites.
'    /SSR:                                    Search for SSR on a nt sequence.
'    /Write.Seeds:                            
'    Search.Batch:                            Batch search for repeats.
' 
' 
' 8. SNP search tools
' 
' 
'    /SNP:                                    
'    /Time.Mutation:                          The ongoing time mutation of the genome sequence.
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    1. You can using "Settings ??<commandName>" for getting more details command help.
'    2. Using command "Settings /CLI.dev [---echo]" for CLI pipeline development.
'    3. Using command "Settings /i" for enter interactive console mode.

Namespace GCModellerApps


''' <summary>
''' Sequence operation utilities
''' </summary>
'''
Public Class seqtools : Inherits InteropService

    Public Const App$ = "seqtools.exe"

    Sub New(App$)
        MyBase._executableAssembly = App$
    End Sub

     <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromEnvironment(directory As String) As seqtools
          Return New seqtools(App:=directory & "/" & seqtools.App)
     End Function

''' <summary>
''' ```bash
''' /align.SmithWaterman /query &lt;query.fasta&gt; /subject &lt;subject.fasta&gt; [/blosum &lt;matrix.txt&gt; /out &lt;out.xml&gt;]
''' ```
''' </summary>
'''
Public Function Align2(query As String, subject As String, Optional blosum As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/align.SmithWaterman")
    Call CLI.Append(" ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/subject " & """" & subject & """ ")
    If Not blosum.StringEmpty Then
            Call CLI.Append("/blosum " & """" & blosum & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /CAI /ORF &lt;orf_nt.fasta&gt; [/out &lt;out.XML&gt;]
''' ```
''' </summary>
'''
Public Function CAI(ORF As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/CAI")
    Call CLI.Append(" ")
    Call CLI.Append("/ORF " & """" & ORF & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /check.attrs /in &lt;in.fasta&gt; /n &lt;attrs.count&gt; [/all]
''' ```
''' </summary>
'''
Public Function CheckHeaders([in] As String, n As String, Optional all As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/check.attrs")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/n " & """" & n & """ ")
    If all Then
        Call CLI.Append("/all ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Clustal.Cut /in &lt;in.fasta&gt; [/left 0.1 /right 0.1 /out &lt;out.fasta&gt;]
''' ```
''' </summary>
'''
Public Function CutMlAlignment([in] As String, Optional left As String = "", Optional right As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Clustal.Cut")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not left.StringEmpty Then
            Call CLI.Append("/left " & """" & left & """ ")
    End If
    If Not right.StringEmpty Then
            Call CLI.Append("/right " & """" & right & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Compare.By.Locis /file1 &lt;file1.fasta&gt; /file2 &lt;/file2.fasta&gt;
''' ```
''' </summary>
'''
Public Function CompareFile(file1 As String, file2 As String) As Integer
    Dim CLI As New StringBuilder("/Compare.By.Locis")
    Call CLI.Append(" ")
    Call CLI.Append("/file1 " & """" & file1 & """ ")
    Call CLI.Append("/file2 " & """" & file2 & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Count /in &lt;data.fasta&gt;
''' ```
''' </summary>
'''
Public Function Count([in] As String) As Integer
    Dim CLI As New StringBuilder("/Count")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Distinct /in &lt;in.fasta&gt; [/out &lt;out.fasta&gt; /by_Uid &lt;uid_regexp&gt;]
''' ```
''' Distinct fasta sequence by sequence content.
''' </summary>
'''
Public Function Distinct([in] As String, Optional out As String = "", Optional by_uid As String = "") As Integer
    Dim CLI As New StringBuilder("/Distinct")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not by_uid.StringEmpty Then
            Call CLI.Append("/by_uid " & """" & by_uid & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Excel.2Fasta /in &lt;anno.csv&gt; [/out &lt;out.fasta&gt; /attrs &lt;gene;locus_tag;gi;location,...&gt; /seq &lt;Sequence&gt;]
''' ```
''' Convert the sequence data in a excel annotation file into a fasta sequence file.
''' </summary>
'''
Public Function ToFasta([in] As String, Optional out As String = "", Optional attrs As String = "", Optional seq As String = "") As Integer
    Dim CLI As New StringBuilder("/Excel.2Fasta")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not attrs.StringEmpty Then
            Call CLI.Append("/attrs " & """" & attrs & """ ")
    End If
    If Not seq.StringEmpty Then
            Call CLI.Append("/seq " & """" & seq & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Fasta.Subset.Large /in &lt;locus.txt&gt; /db &lt;large_db.fasta&gt; [/keyword.map.multiple /out &lt;out.fasta&gt;]
''' ```
''' </summary>
'''
Public Function SubsetFastaDb([in] As String, db As String, Optional out As String = "", Optional keyword_map_multiple As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Fasta.Subset.Large")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/db " & """" & db & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If keyword_map_multiple Then
        Call CLI.Append("/keyword.map.multiple ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Genotype /in &lt;raw.csv&gt; [/out &lt;out.Csv&gt;]
''' ```
''' </summary>
'''
Public Function Genotype([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Genotype")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Genotype.Statics /in &lt;in.DIR&gt; [/out &lt;EXPORT&gt;]
''' ```
''' </summary>
'''
Public Function GenotypeStatics([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Genotype.Statics")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Get.Locis /in &lt;locis.csv&gt; /nt &lt;genome.nt.fasta&gt; [/out &lt;outDIR&gt;]
''' ```
''' </summary>
'''
Public Function GetSimpleSegments([in] As String, nt As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Get.Locis")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Gff.Sites /fna &lt;genomic.fna&gt; /gff &lt;genome.gff&gt; [/out &lt;out.fasta&gt;]
''' ```
''' </summary>
'''
Public Function GffSites(fna As String, gff As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Gff.Sites")
    Call CLI.Append(" ")
    Call CLI.Append("/fna " & """" & fna & """ ")
    Call CLI.Append("/gff " & """" & gff & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /gwANI /in &lt;in.fasta&gt; [/fast /out &lt;out.Csv&gt;]
''' ```
''' Given a multi-FASTA alignment, output the genome wide average nucleotide identity (gwANI) for Each sample against all other samples. A matrix containing the percentages Is outputted.
''' </summary>
'''
Public Function gwANIEvaluate([in] As String, Optional out As String = "", Optional fast As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/gwANI")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If fast Then
        Call CLI.Append("/fast ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /loci.Density /locis &lt;data.csv&gt; [/left &lt;default=Start&gt; /size &lt;size&gt; /win_size &lt;default=100&gt; /offset &lt;default=1000&gt; /out &lt;result.txt&gt;]
''' ```
''' Do statistics of the loci density on a specific sequence.
''' </summary>
'''
Public Function RepeatsDensity(locis As String, Optional left As String = "Start", Optional size As String = "", Optional win_size As String = "100", Optional offset As String = "1000", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/loci.Density")
    Call CLI.Append(" ")
    Call CLI.Append("/locis " & """" & locis & """ ")
    If Not left.StringEmpty Then
            Call CLI.Append("/left " & """" & left & """ ")
    End If
    If Not size.StringEmpty Then
            Call CLI.Append("/size " & """" & size & """ ")
    End If
    If Not win_size.StringEmpty Then
            Call CLI.Append("/win_size " & """" & win_size & """ ")
    End If
    If Not offset.StringEmpty Then
            Call CLI.Append("/offset " & """" & offset & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /logo /in &lt;clustal.fasta&gt; [/out &lt;out.png&gt; /title &quot;&quot;]
''' ```
''' * Drawing the sequence logo from the clustal alignment result.
''' </summary>
'''
Public Function SequenceLogo([in] As String, Optional out As String = "", Optional title As String = "") As Integer
    Dim CLI As New StringBuilder("/logo")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not title.StringEmpty Then
            Call CLI.Append("/title " & """" & title & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Merge /in &lt;fasta.DIR&gt; [/out &lt;out.fasta&gt; /trim /unique /ext &lt;*.fasta&gt; /brief]
''' ```
''' Only search for 1 level folder, dit not search receve.
''' </summary>
'''
Public Function Merge([in] As String, Optional out As String = "", Optional ext As String = "", Optional trim As Boolean = False, Optional unique As Boolean = False, Optional brief As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Merge")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not ext.StringEmpty Then
            Call CLI.Append("/ext " & """" & ext & """ ")
    End If
    If trim Then
        Call CLI.Append("/trim ")
    End If
    If unique Then
        Call CLI.Append("/unique ")
    End If
    If brief Then
        Call CLI.Append("/brief ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Merge.Simple /in &lt;DIR&gt; [/exts &lt;default:*.fasta,*.fa&gt; /line.break 120 /out &lt;out.fasta&gt;]
''' ```
''' This tools just merge the fasta sequence into one larger file.
''' </summary>
'''
Public Function SimpleMerge([in] As String, Optional exts As String = "", Optional line_break As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Merge.Simple")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not exts.StringEmpty Then
            Call CLI.Append("/exts " & """" & exts & """ ")
    End If
    If Not line_break.StringEmpty Then
            Call CLI.Append("/line.break " & """" & line_break & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirror.Batch /nt &lt;nt.fasta&gt; [/out &lt;out.csv&gt; /mp /min &lt;3&gt; /max &lt;20&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function MirrorBatch(nt As String, Optional out As String = "", Optional min As String = "", Optional max As String = "", Optional num_threads As String = "", Optional mp As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Mirror.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
    If mp Then
        Call CLI.Append("/mp ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirror.Fuzzy /in &lt;in.fasta&gt; [/cut &lt;default=0.6&gt; /max-dist &lt;default=6&gt; /min &lt;default=3&gt; /max &lt;default=20&gt; /out &lt;out.csv&gt;]
''' ```
''' Search mirror loci sites on your sequence.
''' </summary>
'''
Public Function FuzzyMirrors([in] As String, Optional cut As String = "0.6", Optional max_dist As String = "6", Optional min As String = "3", Optional max As String = "20", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Mirror.Fuzzy")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not cut.StringEmpty Then
            Call CLI.Append("/cut " & """" & cut & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirror.Fuzzy.Batch /in &lt;in.fasta/DIR&gt; [/out &lt;out.DIR&gt; /cut 0.6 /max-dist 6 /min 3 /max 20 /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function FuzzyMirrorsBatch([in] As String, Optional out As String = "", Optional cut As String = "", Optional max_dist As String = "", Optional min As String = "", Optional max As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("/Mirror.Fuzzy.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cut.StringEmpty Then
            Call CLI.Append("/cut " & """" & cut & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirror.Vector /in &lt;inDIR&gt; /size &lt;genome.size&gt; [/out out.txt]
''' ```
''' </summary>
'''
Public Function MirrorsVector([in] As String, size As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Mirror.Vector")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/size " & """" & size & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirrors.Context /in &lt;mirrors.csv&gt; /PTT &lt;genome.ptt&gt; [/trans /strand &lt;+/-&gt; /out &lt;out.csv&gt; /stranded /dist &lt;500bp&gt;]
''' ```
''' This function will convert the mirror data to the simple segment object data
''' </summary>
'''
Public Function MirrorContext([in] As String, PTT As String, Optional strand As String = "", Optional out As String = "", Optional dist As String = "", Optional trans As Boolean = False, Optional stranded As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Mirrors.Context")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/PTT " & """" & PTT & """ ")
    If Not strand.StringEmpty Then
            Call CLI.Append("/strand " & """" & strand & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not dist.StringEmpty Then
            Call CLI.Append("/dist " & """" & dist & """ ")
    End If
    If trans Then
        Call CLI.Append("/trans ")
    End If
    If stranded Then
        Call CLI.Append("/stranded ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirrors.Context.Batch /in &lt;mirrors.csv.DIR&gt; /PTT &lt;genome.ptt.DIR&gt; [/trans /strand &lt;+/-&gt; /out &lt;out.csv&gt; /stranded /dist &lt;500bp&gt; /num_threads -1]
''' ```
''' This function will convert the mirror data to the simple segment object data
''' </summary>
'''
Public Function MirrorContextBatch([in] As String, PTT As String, Optional strand As String = "", Optional out As String = "", Optional dist As String = "", Optional num_threads As String = "", Optional trans As Boolean = False, Optional stranded As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Mirrors.Context.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/PTT " & """" & PTT & """ ")
    If Not strand.StringEmpty Then
            Call CLI.Append("/strand " & """" & strand & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not dist.StringEmpty Then
            Call CLI.Append("/dist " & """" & dist & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
    If trans Then
        Call CLI.Append("/trans ")
    End If
    If stranded Then
        Call CLI.Append("/stranded ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirrors.Group /in &lt;mirrors.Csv&gt; [/batch /fuzzy &lt;-1&gt; /out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function MirrorGroups([in] As String, Optional fuzzy As String = "", Optional out As String = "", Optional batch As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Mirrors.Group")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not fuzzy.StringEmpty Then
            Call CLI.Append("/fuzzy " & """" & fuzzy & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If batch Then
        Call CLI.Append("/batch ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirrors.Group.Batch /in &lt;mirrors.DIR&gt; [/fuzzy &lt;-1&gt; /out &lt;out.DIR&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function MirrorGroupsBatch([in] As String, Optional fuzzy As String = "", Optional out As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("/Mirrors.Group.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not fuzzy.StringEmpty Then
            Call CLI.Append("/fuzzy " & """" & fuzzy & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Mirrors.Nt.Trim /in &lt;mirrors.Csv&gt; [/out &lt;out.Csv&gt;]
''' ```
''' </summary>
'''
Public Function TrimNtMirrors([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Mirrors.Nt.Trim")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /motifs /in &lt;data.fasta&gt; [/min.w &lt;default=6&gt; /max.w &lt;default=20&gt; /n.motifs &lt;default=25&gt; /n.occurs &lt;default=6&gt; /out &lt;out.directory&gt;]
''' ```
''' Populate possible motifs from a give nt fasta sequence dataset.
''' </summary>
'''
Public Function FindMotifs([in] As String, Optional min_w As String = "6", Optional max_w As String = "20", Optional n_motifs As String = "25", Optional n_occurs As String = "6", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/motifs")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not min_w.StringEmpty Then
            Call CLI.Append("/min.w " & """" & min_w & """ ")
    End If
    If Not max_w.StringEmpty Then
            Call CLI.Append("/max.w " & """" & max_w & """ ")
    End If
    If Not n_motifs.StringEmpty Then
            Call CLI.Append("/n.motifs " & """" & n_motifs & """ ")
    End If
    If Not n_occurs.StringEmpty Then
            Call CLI.Append("/n.occurs " & """" & n_occurs & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /NeedlemanWunsch.NT /query &lt;nt&gt; /subject &lt;nt&gt;
''' ```
''' </summary>
'''
Public Function NWNT(query As String, subject As String) As Integer
    Dim CLI As New StringBuilder("/NeedlemanWunsch.NT")
    Call CLI.Append(" ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/subject " & """" & subject & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /nw /query &lt;query.fasta&gt; /subject &lt;subject.fasta&gt; [/out &lt;out.txt&gt;]
''' ```
''' RunNeedlemanWunsch
''' </summary>
'''
Public Function NW(query As String, subject As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/nw")
    Call CLI.Append(" ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/subject " & """" & subject & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Palindrome.BatchTask /in &lt;in.DIR&gt; [/num_threads 4 /min 3 /max 20 /min-appears 2 /cutoff &lt;0.6&gt; /Palindrome /max-dist &lt;1000 (bp)&gt; /partitions &lt;-1&gt; /out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function PalindromeBatchTask([in] As String, Optional num_threads As String = "", Optional min As String = "", Optional max As String = "", Optional min_appears As String = "", Optional cutoff As String = "", Optional max_dist As String = "", Optional partitions As String = "", Optional out As String = "", Optional palindrome As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Palindrome.BatchTask")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not min_appears.StringEmpty Then
            Call CLI.Append("/min-appears " & """" & min_appears & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not partitions.StringEmpty Then
            Call CLI.Append("/partitions " & """" & partitions & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If palindrome Then
        Call CLI.Append("/palindrome ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Palindrome.Screen.MaxMatches /in &lt;in.csv&gt; /min &lt;min.max-matches&gt; [/out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function FilteringMatches([in] As String, min As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Palindrome.Screen.MaxMatches")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/min " & """" & min & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Palindrome.Screen.MaxMatches.Batch /in &lt;inDIR&gt; /min &lt;min.max-matches&gt; [/out &lt;out.DIR&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function FilteringMatchesBatch([in] As String, min As String, Optional out As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("/Palindrome.Screen.MaxMatches.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/min " & """" & min & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Palindrome.Workflow /in &lt;in.fasta&gt; [/batch /min-appears 2 /min 3 /max 20 /cutoff &lt;0.6&gt; /max-dist &lt;1000 (bp)&gt; /Palindrome /partitions &lt;-1&gt; /out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function PalindromeWorkflow([in] As String, Optional min_appears As String = "", Optional min As String = "", Optional max As String = "", Optional cutoff As String = "", Optional max_dist As String = "", Optional partitions As String = "", Optional out As String = "", Optional batch As Boolean = False, Optional palindrome As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Palindrome.Workflow")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not min_appears.StringEmpty Then
            Call CLI.Append("/min-appears " & """" & min_appears & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not partitions.StringEmpty Then
            Call CLI.Append("/partitions " & """" & partitions & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If batch Then
        Call CLI.Append("/batch ")
    End If
    If palindrome Then
        Call CLI.Append("/palindrome ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Promoter.Palindrome.Fasta /in &lt;palindrome.csv&gt; [/out &lt;out.fasta&gt;]
''' ```
''' </summary>
'''
Public Function PromoterPalindrome2Fasta([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Promoter.Palindrome.Fasta")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Promoter.Regions.Palindrome /in &lt;genbank.gb&gt; [/min &lt;3&gt; /max &lt;20&gt; /len &lt;100,150,200,250,300,400,500, default:=250&gt; /mirror /out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function PromoterRegionPalindrome([in] As String, Optional min As String = "", Optional max As String = "", Optional len As String = "", Optional out As String = "", Optional mirror As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Promoter.Regions.Palindrome")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not len.StringEmpty Then
            Call CLI.Append("/len " & """" & len & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If mirror Then
        Call CLI.Append("/mirror ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Promoter.Regions.Parser.gb /gb &lt;genbank.gb&gt; [/out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function PromoterRegionParser_gb(gb As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Promoter.Regions.Parser.gb")
    Call CLI.Append(" ")
    Call CLI.Append("/gb " & """" & gb & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Rule.dnaA_gyrB /genome &lt;genbank.gb&gt; [/out &lt;out.fasta&gt;]
''' ```
''' Create a ruler fasta sequence for DNA sequence distance computing.
''' </summary>
'''
Public Function dnaA_gyrB_rule(genome As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Rule.dnaA_gyrB")
    Call CLI.Append(" ")
    Call CLI.Append("/genome " & """" & genome & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Rule.dnaA_gyrB.Matrix /genomes &lt;genomes.gb.DIR&gt; [/out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function RuleMatrix(genomes As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Rule.dnaA_gyrB.Matrix")
    Call CLI.Append(" ")
    Call CLI.Append("/genomes " & """" & genomes & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /ruler.dist.calc /in &lt;ruler.fasta&gt; /genomes &lt;genome.gb.DIR&gt; [/winSize &lt;default=1000&gt; /step &lt;default=500&gt; /out &lt;out.csv.dir&gt;]
''' ```
''' </summary>
'''
Public Function RulerSlideWindowMatrix([in] As String, genomes As String, Optional winsize As String = "1000", Optional [step] As String = "500", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/ruler.dist.calc")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/genomes " & """" & genomes & """ ")
    If Not winsize.StringEmpty Then
            Call CLI.Append("/winsize " & """" & winsize & """ ")
    End If
    If Not [step].StringEmpty Then
            Call CLI.Append("/step " & """" & [step] & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Screen.sites /in &lt;DIR/sites.csv&gt; /range &lt;min_bp&gt;,&lt;max_bp&gt; [/type &lt;type,default:=RepeatsView,alt:RepeatsView,RevRepeatsView,PalindromeLoci,ImperfectPalindrome&gt; /out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function ScreenRepeats([in] As String, range As String, Optional type As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Screen.sites")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/range " & """" & range & """ ")
    If Not type.StringEmpty Then
            Call CLI.Append("/type " & """" & type & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Search.Repeats /in &lt;nt.fasta&gt; [/min &lt;default=3&gt; /max &lt;default=20&gt; /minOccurs &lt;default=3&gt; /reverse /out &lt;result.csv&gt;]
''' ```
''' Search for repeats sequence loci sites.
''' </summary>
'''
Public Function SearchRepeats([in] As String, Optional min As String = "3", Optional max As String = "20", Optional minoccurs As String = "3", Optional out As String = "", Optional reverse As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Search.Repeats")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not minoccurs.StringEmpty Then
            Call CLI.Append("/minoccurs " & """" & minoccurs & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If reverse Then
        Call CLI.Append("/reverse ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Select.By_Locus /in &lt;locus.txt/csv&gt; /fa &lt;fasta/.inDIR&gt; [/field &lt;columnName&gt; /reverse /out &lt;out.fasta&gt;]
''' ```
''' Select fasta sequence by local_tag.
''' </summary>
'''
Public Function SelectByLocus([in] As String, fa As String, Optional field As String = "", Optional out As String = "", Optional reverse As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Select.By_Locus")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/fa " & """" & fa & """ ")
    If Not field.StringEmpty Then
            Call CLI.Append("/field " & """" & field & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If reverse Then
        Call CLI.Append("/reverse ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Sigma /in &lt;in.fasta&gt; [/out &lt;out.Csv&gt; /simple /round &lt;-1&gt;]
''' ```
''' Create a distance similarity matrix for the input sequence.
''' </summary>
'''
Public Function Sigma([in] As String, Optional out As String = "", Optional round As String = "", Optional simple As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Sigma")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not round.StringEmpty Then
            Call CLI.Append("/round " & """" & round & """ ")
    End If
    If simple Then
        Call CLI.Append("/simple ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SimpleSegment.AutoBuild /in &lt;locis.csv&gt; [/out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function ConvertsAuto([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/SimpleSegment.AutoBuild")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SimpleSegment.Mirrors /in &lt;in.csv&gt; [/out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function ConvertMirrors([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/SimpleSegment.Mirrors")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SimpleSegment.Mirrors.Batch /in &lt;in.DIR&gt; [/out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function ConvertMirrorsBatch([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/SimpleSegment.Mirrors.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Sites2Fasta /in &lt;segments.csv&gt; [/assemble /out &lt;out.fasta&gt;]
''' ```
''' Converts the simple segment object collection as fasta file.
''' </summary>
'''
Public Function Sites2Fasta([in] As String, Optional out As String = "", Optional assemble As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Sites2Fasta")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If assemble Then
        Call CLI.Append("/assemble ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SNP /in &lt;nt.fasta&gt; [/ref &lt;int_index/title, default:0&gt; /pure /monomorphic /high &lt;0.65&gt;]
''' ```
''' </summary>
'''
Public Function SNP([in] As String, Optional ref As String = "", Optional high As String = "", Optional pure As Boolean = False, Optional monomorphic As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/SNP")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not ref.StringEmpty Then
            Call CLI.Append("/ref " & """" & ref & """ ")
    End If
    If Not high.StringEmpty Then
            Call CLI.Append("/high " & """" & high & """ ")
    End If
    If pure Then
        Call CLI.Append("/pure ")
    End If
    If monomorphic Then
        Call CLI.Append("/monomorphic ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Split /in &lt;in.fasta&gt; [/n &lt;4096&gt; /out &lt;outDIR&gt;]
''' ```
''' </summary>
'''
Public Function Split([in] As String, Optional n As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Split")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not n.StringEmpty Then
            Call CLI.Append("/n " & """" & n & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SSR /in &lt;nt.fasta&gt; [/range &lt;default=2,6&gt; /parallel /out &lt;out.csv/DIR&gt;]
''' ```
''' Search for SSR on a nt sequence.
''' </summary>
'''
Public Function SSRFinder([in] As String, Optional range As String = "2,6", Optional out As String = "", Optional parallel As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/SSR")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not range.StringEmpty Then
            Call CLI.Append("/range " & """" & range & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If parallel Then
        Call CLI.Append("/parallel ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /subset /lstID &lt;lstID.txt&gt; /fa &lt;source.fasta&gt;
''' ```
''' </summary>
'''
Public Function SubSet(lstID As String, fa As String) As Integer
    Dim CLI As New StringBuilder("/subset")
    Call CLI.Append(" ")
    Call CLI.Append("/lstID " & """" & lstID & """ ")
    Call CLI.Append("/fa " & """" & fa & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Time.Mutation /in &lt;aln.fasta&gt; [/ref &lt;default:first,other:title/index&gt; /cumulative /out &lt;out.csv&gt;]
''' ```
''' The ongoing time mutation of the genome sequence.
''' </summary>
'''
Public Function TimeDiffs([in] As String, Optional ref As String = "", Optional out As String = "", Optional cumulative As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Time.Mutation")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not ref.StringEmpty Then
            Call CLI.Append("/ref " & """" & ref & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If cumulative Then
        Call CLI.Append("/cumulative ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Write.Seeds /out &lt;out.dat&gt; [/prot /max &lt;20&gt;]
''' ```
''' </summary>
'''
Public Function WriteSeeds(out As String, Optional max As String = "", Optional prot As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Write.Seeds")
    Call CLI.Append(" ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If prot Then
        Call CLI.Append("/prot ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' -321 /in &lt;sequence.txt&gt; [/out &lt;out.fasta&gt;]
''' ```
''' Polypeptide sequence 3 letters to 1 lettes sequence.
''' </summary>
'''
Public Function PolypeptideBriefs([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("-321")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --align /query &lt;query.fasta&gt; /subject &lt;subject.fasta&gt; [/out &lt;out.DIR&gt; /cost &lt;0.7&gt;]
''' ```
''' </summary>
'''
Public Function Align(query As String, subject As String, Optional out As String = "", Optional cost As String = "") As Integer
    Dim CLI As New StringBuilder("--align")
    Call CLI.Append(" ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/subject " & """" & subject & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cost.StringEmpty Then
            Call CLI.Append("/cost " & """" & cost & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --align.Self /query &lt;query.fasta&gt; /out &lt;out.DIR&gt; [/cost 0.75]
''' ```
''' </summary>
'''
Public Function AlignSelf(query As String, out As String, Optional cost As String = "") As Integer
    Dim CLI As New StringBuilder("--align.Self")
    Call CLI.Append(" ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not cost.StringEmpty Then
            Call CLI.Append("/cost " & """" & cost & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' -complement -i &lt;input_fasta&gt; [-o &lt;output_fasta&gt;]
''' ```
''' </summary>
'''
Public Function Complement(i As String, Optional o As String = "") As Integer
    Dim CLI As New StringBuilder("-complement")
    Call CLI.Append(" ")
    Call CLI.Append("-i " & """" & i & """ ")
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Drawing.ClustalW /in &lt;align.fasta&gt; [/out &lt;out.png&gt; /dot.Size 10]
''' ```
''' </summary>
'''
Public Function DrawClustalW([in] As String, Optional out As String = "", Optional dot_size As String = "") As Integer
    Dim CLI As New StringBuilder("--Drawing.ClustalW")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not dot_size.StringEmpty Then
            Call CLI.Append("/dot.size " & """" & dot_size & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Hairpinks /in &lt;in.fasta&gt; [/out &lt;out.csv&gt; /min &lt;6&gt; /max &lt;7&gt; /cutoff 3 /max-dist &lt;35 (bp)&gt;]
''' ```
''' </summary>
'''
Public Function Hairpinks([in] As String, Optional out As String = "", Optional min As String = "", Optional max As String = "", Optional cutoff As String = "", Optional max_dist As String = "") As Integer
    Dim CLI As New StringBuilder("--Hairpinks")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Hairpinks.batch.task /in &lt;in.fasta&gt; [/out &lt;outDIR&gt; /min &lt;6&gt; /max &lt;7&gt; /cutoff &lt;0.6&gt; /max-dist &lt;35 (bp)&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function HairpinksBatch([in] As String, Optional out As String = "", Optional min As String = "", Optional max As String = "", Optional cutoff As String = "", Optional max_dist As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("--Hairpinks.batch.task")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --ImperfectsPalindrome.batch.Task /in &lt;in.fasta&gt; /out &lt;outDir&gt; [/min &lt;3&gt; /max &lt;20&gt; /cutoff &lt;0.6&gt; /max-dist &lt;1000 (bp)&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function BatchSearchImperfectsPalindrome([in] As String, out As String, Optional min As String = "", Optional max As String = "", Optional cutoff As String = "", Optional max_dist As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("--ImperfectsPalindrome.batch.Task")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Mirror.From.Fasta /nt &lt;nt-sequence.fasta&gt; [/out &lt;out.csv&gt; /min &lt;3&gt; /max &lt;20&gt;]
''' ```
''' Mirror Palindrome, search from a fasta file.
''' </summary>
'''
Public Function SearchMirrotFasta(nt As String, Optional out As String = "", Optional min As String = "", Optional max As String = "") As Integer
    Dim CLI As New StringBuilder("--Mirror.From.Fasta")
    Call CLI.Append(" ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Mirror.From.NT /nt &lt;nt-sequence&gt; /out &lt;out.csv&gt; [/min &lt;3&gt; /max &lt;20&gt;]
''' ```
''' Mirror Palindrome, and this function is for the debugging test
''' </summary>
'''
Public Function SearchMirrotNT(nt As String, out As String, Optional min As String = "", Optional max As String = "") As Integer
    Dim CLI As New StringBuilder("--Mirror.From.NT")
    Call CLI.Append(" ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Palindrome.batch.Task /in &lt;in.fasta&gt; /out &lt;outDir&gt; [/min &lt;3&gt; /max &lt;20&gt; /num_threads &lt;-1&gt;]
''' ```
''' </summary>
'''
Public Function BatchSearchPalindrome([in] As String, out As String, Optional min As String = "", Optional max As String = "", Optional num_threads As String = "") As Integer
    Dim CLI As New StringBuilder("--Palindrome.batch.Task")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not num_threads.StringEmpty Then
            Call CLI.Append("/num_threads " & """" & num_threads & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --palindrome.From.Fasta /nt &lt;nt-sequence.fasta&gt; [/out &lt;out.csv&gt; /min &lt;default=3&gt; /max &lt;default=20&gt;]
''' ```
''' </summary>
'''
Public Function SearchPalindromeFasta(nt As String, Optional out As String = "", Optional min As String = "3", Optional max As String = "20") As Integer
    Dim CLI As New StringBuilder("--palindrome.From.Fasta")
    Call CLI.Append(" ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Palindrome.From.NT /nt &lt;nt-sequence&gt; /out &lt;out.csv&gt; [/min &lt;3&gt; /max &lt;20&gt;]
''' ```
''' This function is just for debugger test, /nt parameter is the nucleotide sequence data as ATGCCCC
''' </summary>
'''
Public Function SearchPalindromeNT(nt As String, out As String, Optional min As String = "", Optional max As String = "") As Integer
    Dim CLI As New StringBuilder("--Palindrome.From.NT")
    Call CLI.Append(" ")
    Call CLI.Append("/nt " & """" & nt & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Palindrome.Imperfects /in &lt;in.fasta&gt; [/out &lt;out.csv&gt; /min &lt;3&gt; /max &lt;20&gt; /cutoff &lt;0.6&gt; /max-dist &lt;1000 (bp)&gt; /partitions &lt;-1&gt;]
''' ```
''' Gets all partly matched palindrome sites.
''' </summary>
'''
Public Function ImperfectPalindrome([in] As String, Optional out As String = "", Optional min As String = "", Optional max As String = "", Optional cutoff As String = "", Optional max_dist As String = "", Optional partitions As String = "") As Integer
    Dim CLI As New StringBuilder("--Palindrome.Imperfects")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not cutoff.StringEmpty Then
            Call CLI.Append("/cutoff " & """" & cutoff & """ ")
    End If
    If Not max_dist.StringEmpty Then
            Call CLI.Append("/max-dist " & """" & max_dist & """ ")
    End If
    If Not partitions.StringEmpty Then
            Call CLI.Append("/partitions " & """" & partitions & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' -pattern_search -i &lt;file_name&gt; -p &lt;regex_pattern&gt; [-o &lt;output_directory&gt; -f &lt;format:fsa/gbk&gt;]
''' ```
''' Parsing the sequence segment from the sequence source using regular expression.
''' </summary>
'''
Public Function PatternSearchA(i As String, p As String, Optional o As String = "", Optional f As String = "") As Integer
    Dim CLI As New StringBuilder("-pattern_search")
    Call CLI.Append(" ")
    Call CLI.Append("-i " & """" & i & """ ")
    Call CLI.Append("-p " & """" & p & """ ")
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
    If Not f.StringEmpty Then
            Call CLI.Append("-f " & """" & f & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --PerfectPalindrome.Filtering /in &lt;inDIR&gt; [/min &lt;8&gt; /out &lt;outDIR&gt;]
''' ```
''' </summary>
'''
Public Function FilterPerfectPalindrome([in] As String, Optional min As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("--PerfectPalindrome.Filtering")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' -reverse -i &lt;input_fasta&gt; [-o &lt;output_fasta&gt;]
''' ```
''' </summary>
'''
Public Function Reverse(i As String, Optional o As String = "") As Integer
    Dim CLI As New StringBuilder("-reverse")
    Call CLI.Append(" ")
    Call CLI.Append("-i " & """" & i & """ ")
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' Search.Batch /aln &lt;alignment.fasta&gt; [/min 3 /max 20 /min-rep 2 /out &lt;./&gt;]
''' ```
''' Batch search for repeats.
''' </summary>
'''
Public Function BatchSearch(aln As String, Optional min As String = "", Optional max As String = "", Optional min_rep As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("Search.Batch")
    Call CLI.Append(" ")
    Call CLI.Append("/aln " & """" & aln & """ ")
    If Not min.StringEmpty Then
            Call CLI.Append("/min " & """" & min & """ ")
    End If
    If Not max.StringEmpty Then
            Call CLI.Append("/max " & """" & max & """ ")
    End If
    If Not min_rep.StringEmpty Then
            Call CLI.Append("/min-rep " & """" & min_rep & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' -segment /fasta &lt;Fasta_Token&gt; [-loci &lt;loci&gt;] [/left &lt;left&gt; /length &lt;length&gt; /right &lt;right&gt; [/reverse]] [/ptt &lt;ptt&gt; /geneID &lt;gene_id&gt; /dist &lt;distance&gt; /downstream] -o &lt;saved&gt; [-line.break 100]
''' ```
''' </summary>
'''
Public Function GetSegment(fasta As String, Optional loci As String = "", Optional length As String = "", Optional right As String = "", Optional __reverse__ As String = "", Optional geneid As String = "", Optional dist As String = "", Optional o As String = "", Optional __line_break As String = "", Optional downstream_ As Boolean = False) As Integer
    Dim CLI As New StringBuilder("-segment")
    Call CLI.Append(" ")
    Call CLI.Append("/fasta " & """" & fasta & """ ")
    If Not loci.StringEmpty Then
            Call CLI.Append("-loci " & """" & loci & """ ")
    End If
    If Not length.StringEmpty Then
            Call CLI.Append("/length " & """" & length & """ ")
    End If
    If Not right.StringEmpty Then
            Call CLI.Append("/right " & """" & right & """ ")
    End If
    If Not __reverse__.StringEmpty Then
            Call CLI.Append("[/reverse]] " & """" & __reverse__ & """ ")
    End If
    If Not geneid.StringEmpty Then
            Call CLI.Append("/geneid " & """" & geneid & """ ")
    End If
    If Not dist.StringEmpty Then
            Call CLI.Append("/dist " & """" & dist & """ ")
    End If
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
    If Not __line_break.StringEmpty Then
            Call CLI.Append("[-line.break " & """" & __line_break & """ ")
    End If
    If downstream_ Then
        Call CLI.Append("/downstream] ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --segments /regions &lt;regions.csv&gt; /fasta &lt;nt.fasta&gt; [/complement /reversed /brief-dump]
''' ```
''' </summary>
'''
Public Function GetSegments(regions As String, fasta As String, Optional complement As Boolean = False, Optional reversed As Boolean = False, Optional brief_dump As Boolean = False) As Integer
    Dim CLI As New StringBuilder("--segments")
    Call CLI.Append(" ")
    Call CLI.Append("/regions " & """" & regions & """ ")
    Call CLI.Append("/fasta " & """" & fasta & """ ")
    If complement Then
        Call CLI.Append("/complement ")
    End If
    If reversed Then
        Call CLI.Append("/reversed ")
    End If
    If brief_dump Then
        Call CLI.Append("/brief-dump ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --ToVector /in &lt;in.DIR&gt; /min &lt;4&gt; /max &lt;8&gt; /out &lt;out.txt&gt; /size &lt;genome.size&gt;
''' ```
''' </summary>
'''
Public Function ToVector([in] As String, min As String, max As String, out As String, size As String) As Integer
    Dim CLI As New StringBuilder("--ToVector")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/min " & """" & min & """ ")
    Call CLI.Append("/max " & """" & max & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
    Call CLI.Append("/size " & """" & size & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --translates /orf &lt;orf.fasta&gt; [/transl_table 1 /force]
''' ```
''' Translates the ORF gene as protein sequence. If any error was output from the console, please using &gt; operator dump the output to a log file for the analysis.
''' </summary>
'''
Public Function Translates(orf As String, Optional transl_table As String = "", Optional force As Boolean = False) As Integer
    Dim CLI As New StringBuilder("--translates")
    Call CLI.Append(" ")
    Call CLI.Append("/orf " & """" & orf & """ ")
    If Not transl_table.StringEmpty Then
            Call CLI.Append("/transl_table " & """" & transl_table & """ ")
    End If
    If force Then
        Call CLI.Append("/force ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Trim /in &lt;in.fasta&gt; [/case &lt;u/l&gt; /break &lt;-1/int&gt; /out &lt;out.fasta&gt; /brief]
''' ```
''' </summary>
'''
Public Function Trim([in] As String, Optional [case] As String = "", Optional break As String = "", Optional out As String = "", Optional brief As Boolean = False) As Integer
    Dim CLI As New StringBuilder("--Trim")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not [case].StringEmpty Then
            Call CLI.Append("/case " & """" & [case] & """ ")
    End If
    If Not break.StringEmpty Then
            Call CLI.Append("/break " & """" & break & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If brief Then
        Call CLI.Append("/brief ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function
End Class
End Namespace
