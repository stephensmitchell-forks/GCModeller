REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:17 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `obj_sub_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `obj_sub_types` (
'''   `parent_obj_type_id` int(11) NOT NULL DEFAULT '0',
'''   `child_obj_type_id` int(11) NOT NULL DEFAULT '0'
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("obj_sub_types", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `obj_sub_types` (
  `parent_obj_type_id` int(11) NOT NULL DEFAULT '0',
  `child_obj_type_id` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class obj_sub_types: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("parent_obj_type_id"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="parent_obj_type_id")> Public Property parent_obj_type_id As Long
    <DatabaseField("child_obj_type_id"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="child_obj_type_id")> Public Property child_obj_type_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `obj_sub_types` (`parent_obj_type_id`, `child_obj_type_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `obj_sub_types` (`parent_obj_type_id`, `child_obj_type_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `obj_sub_types` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `obj_sub_types` SET `parent_obj_type_id`='{0}', `child_obj_type_id`='{1}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `obj_sub_types` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `obj_sub_types` (`parent_obj_type_id`, `child_obj_type_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, parent_obj_type_id, child_obj_type_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{parent_obj_type_id}', '{child_obj_type_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `obj_sub_types` (`parent_obj_type_id`, `child_obj_type_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, parent_obj_type_id, child_obj_type_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `obj_sub_types` SET `parent_obj_type_id`='{0}', `child_obj_type_id`='{1}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As obj_sub_types
                  Return DirectCast(MyClass.MemberwiseClone, obj_sub_types)
              End Function
End Class


End Namespace
