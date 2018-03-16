REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:14 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `cond_effect_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `cond_effect_link` (
'''   `cond_effect_link_id` char(12) NOT NULL,
'''   `condition_id` char(12) NOT NULL,
'''   `medium_id` char(12) NOT NULL,
'''   `effect` varchar(250) NOT NULL,
'''   `cond_effect_link_notes` varchar(2000) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("cond_effect_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `cond_effect_link` (
  `cond_effect_link_id` char(12) NOT NULL,
  `condition_id` char(12) NOT NULL,
  `medium_id` char(12) NOT NULL,
  `effect` varchar(250) NOT NULL,
  `cond_effect_link_notes` varchar(2000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class cond_effect_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("cond_effect_link_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="cond_effect_link_id")> Public Property cond_effect_link_id As String
    <DatabaseField("condition_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="condition_id")> Public Property condition_id As String
    <DatabaseField("medium_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="medium_id")> Public Property medium_id As String
    <DatabaseField("effect"), NotNull, DataType(MySqlDbType.VarChar, "250"), Column(Name:="effect")> Public Property effect As String
    <DatabaseField("cond_effect_link_notes"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="cond_effect_link_notes")> Public Property cond_effect_link_notes As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `cond_effect_link` (`cond_effect_link_id`, `condition_id`, `medium_id`, `effect`, `cond_effect_link_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `cond_effect_link` (`cond_effect_link_id`, `condition_id`, `medium_id`, `effect`, `cond_effect_link_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `cond_effect_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `cond_effect_link` SET `cond_effect_link_id`='{0}', `condition_id`='{1}', `medium_id`='{2}', `effect`='{3}', `cond_effect_link_notes`='{4}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `cond_effect_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `cond_effect_link` (`cond_effect_link_id`, `condition_id`, `medium_id`, `effect`, `cond_effect_link_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, cond_effect_link_id, condition_id, medium_id, effect, cond_effect_link_notes)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{cond_effect_link_id}', '{condition_id}', '{medium_id}', '{effect}', '{cond_effect_link_notes}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `cond_effect_link` (`cond_effect_link_id`, `condition_id`, `medium_id`, `effect`, `cond_effect_link_notes`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, cond_effect_link_id, condition_id, medium_id, effect, cond_effect_link_notes)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `cond_effect_link` SET `cond_effect_link_id`='{0}', `condition_id`='{1}', `medium_id`='{2}', `effect`='{3}', `cond_effect_link_notes`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As cond_effect_link
                  Return DirectCast(MyClass.MemberwiseClone, cond_effect_link)
              End Function
End Class


End Namespace
