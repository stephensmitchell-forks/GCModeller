REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:52 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `text_index_entry`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `text_index_entry` (
'''   `id` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `field` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `text` varchar(100) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("text_index_entry", Database:="interpro", SchemaSQL:="
CREATE TABLE `text_index_entry` (
  `id` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `field` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `text` varchar(100) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class text_index_entry: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), DataType(MySqlDbType.VarChar, "9")> Public Property id As String
    <DatabaseField("field"), DataType(MySqlDbType.VarChar, "20")> Public Property field As String
    <DatabaseField("text"), DataType(MySqlDbType.VarChar, "100")> Public Property text As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `text_index_entry` (`id`, `field`, `text`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `text_index_entry` (`id`, `field`, `text`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `text_index_entry` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `text_index_entry` SET `id`='{0}', `field`='{1}', `text`='{2}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `text_index_entry` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `text_index_entry` (`id`, `field`, `text`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, field, text)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{field}', '{text}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `text_index_entry` (`id`, `field`, `text`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, field, text)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `text_index_entry` SET `id`='{0}', `field`='{1}', `text`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
