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
''' DROP TABLE IF EXISTS `referencesequence_2_keyword`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referencesequence_2_keyword` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `keyword_rank` int(10) unsigned DEFAULT NULL,
'''   `keyword` text,
'''   KEY `DB_ID` (`DB_ID`),
'''   FULLTEXT KEY `keyword` (`keyword`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referencesequence_2_keyword", Database:="gk_current", SchemaSQL:="
CREATE TABLE `referencesequence_2_keyword` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `keyword_rank` int(10) unsigned DEFAULT NULL,
  `keyword` text,
  KEY `DB_ID` (`DB_ID`),
  FULLTEXT KEY `keyword` (`keyword`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class referencesequence_2_keyword: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("keyword_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="keyword_rank")> Public Property keyword_rank As Long
    <DatabaseField("keyword"), DataType(MySqlDbType.Text), Column(Name:="keyword")> Public Property keyword As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `referencesequence_2_keyword` (`DB_ID`, `keyword_rank`, `keyword`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `referencesequence_2_keyword` (`DB_ID`, `keyword_rank`, `keyword`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `referencesequence_2_keyword` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `referencesequence_2_keyword` SET `DB_ID`='{0}', `keyword_rank`='{1}', `keyword`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `referencesequence_2_keyword` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `referencesequence_2_keyword` (`DB_ID`, `keyword_rank`, `keyword`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, keyword_rank, keyword)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{keyword_rank}', '{keyword}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `referencesequence_2_keyword` (`DB_ID`, `keyword_rank`, `keyword`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, keyword_rank, keyword)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `referencesequence_2_keyword` SET `DB_ID`='{0}', `keyword_rank`='{1}', `keyword`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, keyword_rank, keyword, DB_ID)
    End Function
#End Region
Public Function Clone() As referencesequence_2_keyword
                  Return DirectCast(MyClass.MemberwiseClone, referencesequence_2_keyword)
              End Function
End Class


End Namespace
