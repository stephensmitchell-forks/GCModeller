REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:21 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `regulation_2_literaturereference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulation_2_literaturereference` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `literatureReference_rank` int(10) unsigned DEFAULT NULL,
'''   `literatureReference` int(10) unsigned DEFAULT NULL,
'''   `literatureReference_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `literatureReference` (`literatureReference`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulation_2_literaturereference", Database:="gk_current", SchemaSQL:="
CREATE TABLE `regulation_2_literaturereference` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `literatureReference_rank` int(10) unsigned DEFAULT NULL,
  `literatureReference` int(10) unsigned DEFAULT NULL,
  `literatureReference_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `literatureReference` (`literatureReference`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class regulation_2_literaturereference: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("literatureReference_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="literatureReference_rank")> Public Property literatureReference_rank As Long
    <DatabaseField("literatureReference"), DataType(MySqlDbType.Int64, "10"), Column(Name:="literatureReference")> Public Property literatureReference As Long
    <DatabaseField("literatureReference_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="literatureReference_class")> Public Property literatureReference_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulation_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulation_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulation_2_literaturereference` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulation_2_literaturereference` SET `DB_ID`='{0}', `literatureReference_rank`='{1}', `literatureReference`='{2}', `literatureReference_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulation_2_literaturereference` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulation_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{literatureReference_rank}', '{literatureReference}', '{literatureReference_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulation_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulation_2_literaturereference` SET `DB_ID`='{0}', `literatureReference_rank`='{1}', `literatureReference`='{2}', `literatureReference_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class, DB_ID)
    End Function
#End Region
Public Function Clone() As regulation_2_literaturereference
                  Return DirectCast(MyClass.MemberwiseClone, regulation_2_literaturereference)
              End Function
End Class


End Namespace
