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
''' DROP TABLE IF EXISTS `annotation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `annotation` (
'''   `gid` varchar(25) DEFAULT NULL,
'''   `Gene_Name` varchar(80) DEFAULT NULL,
'''   `fundescrp` varchar(255) DEFAULT NULL
''' ) ENGINE=MyISAM AUTO_INCREMENT=11862 DEFAULT CHARSET=gb2312;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("annotation", Database:="ceg", SchemaSQL:="
CREATE TABLE `annotation` (
  `gid` varchar(25) DEFAULT NULL,
  `Gene_Name` varchar(80) DEFAULT NULL,
  `fundescrp` varchar(255) DEFAULT NULL
) ENGINE=MyISAM AUTO_INCREMENT=11862 DEFAULT CHARSET=gb2312;")>
Public Class annotation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gid"), DataType(MySqlDbType.VarChar, "25"), Column(Name:="gid")> Public Property gid As String
    <DatabaseField("Gene_Name"), DataType(MySqlDbType.VarChar, "80"), Column(Name:="Gene_Name")> Public Property Gene_Name As String
    <DatabaseField("fundescrp"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="fundescrp")> Public Property fundescrp As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `annotation` (`gid`, `Gene_Name`, `fundescrp`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `annotation` (`gid`, `Gene_Name`, `fundescrp`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `annotation` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `annotation` SET `gid`='{0}', `Gene_Name`='{1}', `fundescrp`='{2}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `annotation` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `annotation` (`gid`, `Gene_Name`, `fundescrp`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gid, Gene_Name, fundescrp)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gid}', '{Gene_Name}', '{fundescrp}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `annotation` (`gid`, `Gene_Name`, `fundescrp`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gid, Gene_Name, fundescrp)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `annotation` SET `gid`='{0}', `Gene_Name`='{1}', `fundescrp`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As annotation
                  Return DirectCast(MyClass.MemberwiseClone, annotation)
              End Function
End Class


End Namespace
