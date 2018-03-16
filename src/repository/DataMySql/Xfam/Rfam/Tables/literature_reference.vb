REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:13 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `literature_reference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `literature_reference` (
'''   `pmid` int(10) NOT NULL AUTO_INCREMENT,
'''   `title` tinytext,
'''   `author` text,
'''   `journal` tinytext,
'''   PRIMARY KEY (`pmid`)
''' ) ENGINE=InnoDB AUTO_INCREMENT=97362240 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("literature_reference", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `literature_reference` (
  `pmid` int(10) NOT NULL AUTO_INCREMENT,
  `title` tinytext,
  `author` text,
  `journal` tinytext,
  PRIMARY KEY (`pmid`)
) ENGINE=InnoDB AUTO_INCREMENT=97362240 DEFAULT CHARSET=latin1;")>
Public Class literature_reference: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pmid"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="pmid"), XmlAttribute> Public Property pmid As Long
    <DatabaseField("title"), DataType(MySqlDbType.Text), Column(Name:="title")> Public Property title As String
    <DatabaseField("author"), DataType(MySqlDbType.Text), Column(Name:="author")> Public Property author As String
    <DatabaseField("journal"), DataType(MySqlDbType.Text), Column(Name:="journal")> Public Property journal As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `literature_reference` (`title`, `author`, `journal`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `literature_reference` (`title`, `author`, `journal`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `literature_reference` WHERE `pmid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `literature_reference` SET `pmid`='{0}', `title`='{1}', `author`='{2}', `journal`='{3}' WHERE `pmid` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `literature_reference` WHERE `pmid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pmid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `literature_reference` (`title`, `author`, `journal`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, title, author, journal)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{title}', '{author}', '{journal}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `literature_reference` (`title`, `author`, `journal`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, title, author, journal)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `literature_reference` SET `pmid`='{0}', `title`='{1}', `author`='{2}', `journal`='{3}' WHERE `pmid` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pmid, title, author, journal, pmid)
    End Function
#End Region
Public Function Clone() As literature_reference
                  Return DirectCast(MyClass.MemberwiseClone, literature_reference)
              End Function
End Class


End Namespace
