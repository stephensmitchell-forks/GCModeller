﻿Imports LANS.SystemsBiology.GCModeller.ModellingEngine.EngineSystem.RuntimeObjects
Imports Microsoft.VisualBasic.Scripting.ShoalShell.Runtime

Namespace EngineSystem.Engine

    Public Class ShellScript : Inherits EngineSystem.ObjectModels.SubSystem.SystemObjectModel
        Implements IDrivenable

        Dim _Internal_EmbeddedScriptEngine As ScriptEngine
        Dim ScriptSourceList As KeyValuePair(Of String, String)()

        Sub New(RuntimeContainer As IContainerSystemRuntimeEnvironment)
            I_RuntimeContainer = RuntimeContainer
            Call EngineSystem.ObjectModels.ExperimentSystem.ShellScriptAPI.set_EngineKernel(obj:=DirectCast(I_RuntimeContainer, EngineSystem.Engine.GCModeller))
            _Internal_EmbeddedScriptEngine = New Microsoft.VisualBasic.Scripting.ShoalShell.Runtime.ScriptEngine()
            For Each assembly As System.Reflection.Module In GetType(ShellScript).Assembly.GetLoadedModules
                Call _Internal_EmbeddedScriptEngine.Interpreter.SPMDevice.Imports(assembly.Assembly.Location)
            Next
            Call _Internal_EmbeddedScriptEngine.Interpreter.SPMDevice.UpdateDb()
        End Sub

        Public Overrides Function Initialize() As Integer
            Dim ScriptMountPoint As String = I_RuntimeContainer.ConfigurationData.ScriptMountPoint

            If String.IsNullOrEmpty(ScriptMountPoint) Then
                Me.ScriptSourceList = New KeyValuePair(Of String, String)() {}
                Call LoggingClient.WriteLine("User not specific a script file mount point.")
                Return 0
            End If

            Call LoggingClient.WriteLine(String.Format("ScriptMountPoint <- ""{0}""", ScriptMountPoint))

            Dim PreWork As String = My.Computer.FileSystem.CurrentDirectory
            My.Computer.FileSystem.CurrentDirectory = I_RuntimeContainer.ConfigurationData.RootDIR
            Call LoggingClient.WriteLine(String.Format("Configuration data root directory is ""{0}""", I_RuntimeContainer.ConfigurationData.RootDIR))

            If Not FileIO.FileSystem.DirectoryExists(ScriptMountPoint) Then
                Call LoggingClient.WriteLine("But the script mount point is not exists on the filesystem....")
                Me.ScriptSourceList = New KeyValuePair(Of String, String)() {}
                Return 0
            End If

            Dim Files As String() = FileIO.FileSystem.GetFiles(ScriptMountPoint, FileIO.SearchOption.SearchTopLevelOnly).ToArray

            For Each Path As String In Files
                Call LoggingClient.WriteLine(String.Format("  *Load shellscript from mount point: ""{0}""", Path))
            Next

            Me.ScriptSourceList = (From FilePath As String In Files Select New KeyValuePair(Of String, String)(FilePath, FileIO.FileSystem.ReadAllText(FilePath))).ToArray
            My.Computer.FileSystem.CurrentDirectory = PreWork

            If Me.ScriptSourceList.IsNullOrEmpty Then
                Me.ScriptSourceList = New KeyValuePair(Of String, String)() {}
            End If

            Call LoggingClient.WriteLine(String.Format("System load {0} script file into engine kernel.", ScriptSourceList.Count))

            Return 0
        End Function

        Public Overrides Sub MemoryDump(Dir As String)

        End Sub

        Public Function Tick(KernelCycle As Integer) As Integer Implements IDrivenable.__innerTicks
            For Each strLine In ScriptSourceList
                Dim f As Boolean = _Internal_EmbeddedScriptEngine.Exec(strLine.Value) = 0
                If Not f Then '出错了
                    Call LoggingClient.WriteLine(String.Format("Error occur while execute the external mount shellscript ""{0}"", try ignore this error!", strLine.Key),
                                                 "ShellScript -> Tick(KernelCycle As Integer)", Type:=Logging.MSG_TYPES.ERR)
                End If
            Next

            Return 0
        End Function

        Public ReadOnly Property EventId As String Implements IDrivenable.EventId
            Get
                Return "ShellScript Driver"
            End Get
        End Property
    End Class
End Namespace