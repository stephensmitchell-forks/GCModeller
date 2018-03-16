REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:18 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace CEG.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `clade`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `clade` (
'''   `oganismid` int(4) NOT NULL,
'''   `phylum` varchar(100) DEFAULT NULL,
'''   `abbr` varchar(100) DEFAULT NULL,
'''   `class` varchar(100) DEFAULT NULL,
'''   `order` varchar(100) NOT NULL,
'''   `family` varchar(100) DEFAULT NULL,
'''   `genus` text NOT NULL,
'''   PRIMARY KEY (`oganismid`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=7687 DEFAULT CHARSET=gb2312;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("clade", Database:="ceg", SchemaSQL:="
CREATE TABLE `clade` (
  `oganismid` int(4) NOT NULL,
  `phylum` varchar(100) DEFAULT NULL,
  `abbr` varchar(100) DEFAULT NULL,
  `class` varchar(100) DEFAULT NULL,
  `order` varchar(100) NOT NULL,
  `family` varchar(100) DEFAULT NULL,
  `genus` text NOT NULL,
  PRIMARY KEY (`oganismid`)
) ENGINE=MyISAM AUTO_INCREMENT=7687 DEFAULT CHARSET=gb2312;")>
Public Class clade: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("oganismid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "4"), Column(Name:="oganismid"), XmlAttribute> Public Property oganismid As Long
    <DatabaseField("phylum"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="phylum")> Public Property phylum As String
    <DatabaseField("abbr"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="abbr")> Public Property abbr As String
    <DatabaseField("class"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="class")> Public Property [class] As String
    <DatabaseField("order"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="order")> Public Property order As String
    <DatabaseField("family"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="family")> Public Property family As String
    <DatabaseField("genus"), NotNull, DataType(MySqlDbType.Text), Column(Name:="genus")> Public Property genus As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `clade` (`oganismid`, `phylum`, `abbr`, `class`, `order`, `family`, `genus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `clade` (`oganismid`, `phylum`, `abbr`, `class`, `order`, `family`, `genus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `clade` WHERE `oganismid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `clade` SET `oganismid`='{0}', `phylum`='{1}', `abbr`='{2}', `class`='{3}', `order`='{4}', `family`='{5}', `genus`='{6}' WHERE `oganismid` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `clade` WHERE `oganismid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, oganismid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `clade` (`oganismid`, `phylum`, `abbr`, `class`, `order`, `family`, `genus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, oganismid, phylum, abbr, [class], order, family, genus)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{oganismid}', '{phylum}', '{abbr}', '{[class]}', '{order}', '{family}', '{genus}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `clade` (`oganismid`, `phylum`, `abbr`, `class`, `order`, `family`, `genus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, oganismid, phylum, abbr, [class], order, family, genus)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `clade` SET `oganismid`='{0}', `phylum`='{1}', `abbr`='{2}', `class`='{3}', `order`='{4}', `family`='{5}', `genus`='{6}' WHERE `oganismid` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, oganismid, phylum, abbr, [class], order, family, genus, oganismid)
    End Function
#End Region
Public Function Clone() As clade
                  Return DirectCast(MyClass.MemberwiseClone, clade)
              End Function
End Class


End Namespace
