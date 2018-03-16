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
''' DROP TABLE IF EXISTS `arraydesign`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraydesign` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `Version` varchar(255) DEFAULT NULL,
'''   `NumberOfFeatures` smallint(6) DEFAULT NULL,
'''   `SurfaceType` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ArrayDesign1` (`DataSetWID`),
'''   KEY `FK_ArrayDesign3` (`SurfaceType`),
'''   CONSTRAINT `FK_ArrayDesign1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayDesign3` FOREIGN KEY (`SurfaceType`) REFERENCES `term` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraydesign", Database:="warehouse", SchemaSQL:="
CREATE TABLE `arraydesign` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Version` varchar(255) DEFAULT NULL,
  `NumberOfFeatures` smallint(6) DEFAULT NULL,
  `SurfaceType` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ArrayDesign1` (`DataSetWID`),
  KEY `FK_ArrayDesign3` (`SurfaceType`),
  CONSTRAINT `FK_ArrayDesign1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayDesign3` FOREIGN KEY (`SurfaceType`) REFERENCES `term` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class arraydesign: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="MAGEClass")> Public Property MAGEClass As String
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Identifier")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("Version"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Version")> Public Property Version As String
    <DatabaseField("NumberOfFeatures"), DataType(MySqlDbType.Int64, "6"), Column(Name:="NumberOfFeatures")> Public Property NumberOfFeatures As Long
    <DatabaseField("SurfaceType"), DataType(MySqlDbType.Int64, "20"), Column(Name:="SurfaceType")> Public Property SurfaceType As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `arraydesign` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `Version`, `NumberOfFeatures`, `SurfaceType`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `arraydesign` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `Version`, `NumberOfFeatures`, `SurfaceType`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `arraydesign` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `arraydesign` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `Version`='{5}', `NumberOfFeatures`='{6}', `SurfaceType`='{7}' WHERE `WID` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `arraydesign` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `arraydesign` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `Version`, `NumberOfFeatures`, `SurfaceType`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, Version, NumberOfFeatures, SurfaceType)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{Version}', '{NumberOfFeatures}', '{SurfaceType}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `arraydesign` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `Version`, `NumberOfFeatures`, `SurfaceType`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, Version, NumberOfFeatures, SurfaceType)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `arraydesign` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `Version`='{5}', `NumberOfFeatures`='{6}', `SurfaceType`='{7}' WHERE `WID` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, Version, NumberOfFeatures, SurfaceType, WID)
    End Function
#End Region
Public Function Clone() As arraydesign
                  Return DirectCast(MyClass.MemberwiseClone, arraydesign)
              End Function
End Class


End Namespace
