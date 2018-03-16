REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:19 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dataset`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dataset` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` varchar(255) NOT NULL,
'''   `Version` varchar(50) DEFAULT NULL,
'''   `ReleaseDate` datetime DEFAULT NULL,
'''   `LoadDate` datetime NOT NULL,
'''   `ChangeDate` datetime DEFAULT NULL,
'''   `HomeURL` varchar(255) DEFAULT NULL,
'''   `QueryURL` varchar(255) DEFAULT NULL,
'''   `LoadedBy` varchar(255) DEFAULT NULL,
'''   `Application` varchar(255) DEFAULT NULL,
'''   `ApplicationVersion` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`WID`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dataset", Database:="warehouse", SchemaSQL:="
CREATE TABLE `dataset` (
  `WID` bigint(20) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Version` varchar(50) DEFAULT NULL,
  `ReleaseDate` datetime DEFAULT NULL,
  `LoadDate` datetime NOT NULL,
  `ChangeDate` datetime DEFAULT NULL,
  `HomeURL` varchar(255) DEFAULT NULL,
  `QueryURL` varchar(255) DEFAULT NULL,
  `LoadedBy` varchar(255) DEFAULT NULL,
  `Application` varchar(255) DEFAULT NULL,
  `ApplicationVersion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`WID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class dataset: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("Name"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("Version"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="Version")> Public Property Version As String
    <DatabaseField("ReleaseDate"), DataType(MySqlDbType.DateTime), Column(Name:="ReleaseDate")> Public Property ReleaseDate As Date
    <DatabaseField("LoadDate"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="LoadDate")> Public Property LoadDate As Date
    <DatabaseField("ChangeDate"), DataType(MySqlDbType.DateTime), Column(Name:="ChangeDate")> Public Property ChangeDate As Date
    <DatabaseField("HomeURL"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="HomeURL")> Public Property HomeURL As String
    <DatabaseField("QueryURL"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="QueryURL")> Public Property QueryURL As String
    <DatabaseField("LoadedBy"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="LoadedBy")> Public Property LoadedBy As String
    <DatabaseField("Application"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Application")> Public Property Application As String
    <DatabaseField("ApplicationVersion"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="ApplicationVersion")> Public Property ApplicationVersion As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dataset` (`WID`, `Name`, `Version`, `ReleaseDate`, `LoadDate`, `ChangeDate`, `HomeURL`, `QueryURL`, `LoadedBy`, `Application`, `ApplicationVersion`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dataset` (`WID`, `Name`, `Version`, `ReleaseDate`, `LoadDate`, `ChangeDate`, `HomeURL`, `QueryURL`, `LoadedBy`, `Application`, `ApplicationVersion`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dataset` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dataset` SET `WID`='{0}', `Name`='{1}', `Version`='{2}', `ReleaseDate`='{3}', `LoadDate`='{4}', `ChangeDate`='{5}', `HomeURL`='{6}', `QueryURL`='{7}', `LoadedBy`='{8}', `Application`='{9}', `ApplicationVersion`='{10}' WHERE `WID` = '{11}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dataset` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dataset` (`WID`, `Name`, `Version`, `ReleaseDate`, `LoadDate`, `ChangeDate`, `HomeURL`, `QueryURL`, `LoadedBy`, `Application`, `ApplicationVersion`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, Version, MySqlScript.ToMySqlDateTimeString(ReleaseDate), MySqlScript.ToMySqlDateTimeString(LoadDate), MySqlScript.ToMySqlDateTimeString(ChangeDate), HomeURL, QueryURL, LoadedBy, Application, ApplicationVersion)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{Version}', '{ReleaseDate}', '{LoadDate}', '{ChangeDate}', '{HomeURL}', '{QueryURL}', '{LoadedBy}', '{Application}', '{ApplicationVersion}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dataset` (`WID`, `Name`, `Version`, `ReleaseDate`, `LoadDate`, `ChangeDate`, `HomeURL`, `QueryURL`, `LoadedBy`, `Application`, `ApplicationVersion`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, Version, MySqlScript.ToMySqlDateTimeString(ReleaseDate), MySqlScript.ToMySqlDateTimeString(LoadDate), MySqlScript.ToMySqlDateTimeString(ChangeDate), HomeURL, QueryURL, LoadedBy, Application, ApplicationVersion)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dataset` SET `WID`='{0}', `Name`='{1}', `Version`='{2}', `ReleaseDate`='{3}', `LoadDate`='{4}', `ChangeDate`='{5}', `HomeURL`='{6}', `QueryURL`='{7}', `LoadedBy`='{8}', `Application`='{9}', `ApplicationVersion`='{10}' WHERE `WID` = '{11}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, Version, MySqlScript.ToMySqlDateTimeString(ReleaseDate), MySqlScript.ToMySqlDateTimeString(LoadDate), MySqlScript.ToMySqlDateTimeString(ChangeDate), HomeURL, QueryURL, LoadedBy, Application, ApplicationVersion, WID)
    End Function
#End Region
Public Function Clone() As dataset
                  Return DirectCast(MyClass.MemberwiseClone, dataset)
              End Function
End Class


End Namespace
