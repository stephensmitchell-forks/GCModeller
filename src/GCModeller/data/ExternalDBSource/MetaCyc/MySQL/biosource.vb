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
''' DROP TABLE IF EXISTS `biosource`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `biosource` (
'''   `WID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) DEFAULT NULL,
'''   `TaxonWID` bigint(20) DEFAULT NULL,
'''   `Name` varchar(200) DEFAULT NULL,
'''   `Strain` varchar(220) DEFAULT NULL,
'''   `Organ` varchar(50) DEFAULT NULL,
'''   `Organelle` varchar(50) DEFAULT NULL,
'''   `Tissue` varchar(100) DEFAULT NULL,
'''   `CellType` varchar(50) DEFAULT NULL,
'''   `CellLine` varchar(50) DEFAULT NULL,
'''   `ATCCId` varchar(50) DEFAULT NULL,
'''   `Diseased` char(1) DEFAULT NULL,
'''   `Disease` varchar(250) DEFAULT NULL,
'''   `DevelopmentStage` varchar(50) DEFAULT NULL,
'''   `Sex` varchar(15) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_BioSource1` (`TaxonWID`),
'''   KEY `FK_BioSource2` (`DataSetWID`),
'''   CONSTRAINT `FK_BioSource1` FOREIGN KEY (`TaxonWID`) REFERENCES `taxon` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioSource2` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("biosource", Database:="warehouse", SchemaSQL:="
CREATE TABLE `biosource` (
  `WID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) DEFAULT NULL,
  `TaxonWID` bigint(20) DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Strain` varchar(220) DEFAULT NULL,
  `Organ` varchar(50) DEFAULT NULL,
  `Organelle` varchar(50) DEFAULT NULL,
  `Tissue` varchar(100) DEFAULT NULL,
  `CellType` varchar(50) DEFAULT NULL,
  `CellLine` varchar(50) DEFAULT NULL,
  `ATCCId` varchar(50) DEFAULT NULL,
  `Diseased` char(1) DEFAULT NULL,
  `Disease` varchar(250) DEFAULT NULL,
  `DevelopmentStage` varchar(50) DEFAULT NULL,
  `Sex` varchar(15) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_BioSource1` (`TaxonWID`),
  KEY `FK_BioSource2` (`DataSetWID`),
  CONSTRAINT `FK_BioSource1` FOREIGN KEY (`TaxonWID`) REFERENCES `taxon` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioSource2` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class biosource: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("MAGEClass"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="MAGEClass")> Public Property MAGEClass As String
    <DatabaseField("TaxonWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="TaxonWID")> Public Property TaxonWID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "200"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("Strain"), DataType(MySqlDbType.VarChar, "220"), Column(Name:="Strain")> Public Property Strain As String
    <DatabaseField("Organ"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="Organ")> Public Property Organ As String
    <DatabaseField("Organelle"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="Organelle")> Public Property Organelle As String
    <DatabaseField("Tissue"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="Tissue")> Public Property Tissue As String
    <DatabaseField("CellType"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="CellType")> Public Property CellType As String
    <DatabaseField("CellLine"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="CellLine")> Public Property CellLine As String
    <DatabaseField("ATCCId"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="ATCCId")> Public Property ATCCId As String
    <DatabaseField("Diseased"), DataType(MySqlDbType.VarChar, "1"), Column(Name:="Diseased")> Public Property Diseased As String
    <DatabaseField("Disease"), DataType(MySqlDbType.VarChar, "250"), Column(Name:="Disease")> Public Property Disease As String
    <DatabaseField("DevelopmentStage"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="DevelopmentStage")> Public Property DevelopmentStage As String
    <DatabaseField("Sex"), DataType(MySqlDbType.VarChar, "15"), Column(Name:="Sex")> Public Property Sex As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `biosource` (`WID`, `MAGEClass`, `TaxonWID`, `Name`, `Strain`, `Organ`, `Organelle`, `Tissue`, `CellType`, `CellLine`, `ATCCId`, `Diseased`, `Disease`, `DevelopmentStage`, `Sex`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `biosource` (`WID`, `MAGEClass`, `TaxonWID`, `Name`, `Strain`, `Organ`, `Organelle`, `Tissue`, `CellType`, `CellLine`, `ATCCId`, `Diseased`, `Disease`, `DevelopmentStage`, `Sex`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `biosource` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `biosource` SET `WID`='{0}', `MAGEClass`='{1}', `TaxonWID`='{2}', `Name`='{3}', `Strain`='{4}', `Organ`='{5}', `Organelle`='{6}', `Tissue`='{7}', `CellType`='{8}', `CellLine`='{9}', `ATCCId`='{10}', `Diseased`='{11}', `Disease`='{12}', `DevelopmentStage`='{13}', `Sex`='{14}', `DataSetWID`='{15}' WHERE `WID` = '{16}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `biosource` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `biosource` (`WID`, `MAGEClass`, `TaxonWID`, `Name`, `Strain`, `Organ`, `Organelle`, `Tissue`, `CellType`, `CellLine`, `ATCCId`, `Diseased`, `Disease`, `DevelopmentStage`, `Sex`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, MAGEClass, TaxonWID, Name, Strain, Organ, Organelle, Tissue, CellType, CellLine, ATCCId, Diseased, Disease, DevelopmentStage, Sex, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{MAGEClass}', '{TaxonWID}', '{Name}', '{Strain}', '{Organ}', '{Organelle}', '{Tissue}', '{CellType}', '{CellLine}', '{ATCCId}', '{Diseased}', '{Disease}', '{DevelopmentStage}', '{Sex}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `biosource` (`WID`, `MAGEClass`, `TaxonWID`, `Name`, `Strain`, `Organ`, `Organelle`, `Tissue`, `CellType`, `CellLine`, `ATCCId`, `Diseased`, `Disease`, `DevelopmentStage`, `Sex`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, MAGEClass, TaxonWID, Name, Strain, Organ, Organelle, Tissue, CellType, CellLine, ATCCId, Diseased, Disease, DevelopmentStage, Sex, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `biosource` SET `WID`='{0}', `MAGEClass`='{1}', `TaxonWID`='{2}', `Name`='{3}', `Strain`='{4}', `Organ`='{5}', `Organelle`='{6}', `Tissue`='{7}', `CellType`='{8}', `CellLine`='{9}', `ATCCId`='{10}', `Diseased`='{11}', `Disease`='{12}', `DevelopmentStage`='{13}', `Sex`='{14}', `DataSetWID`='{15}' WHERE `WID` = '{16}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, MAGEClass, TaxonWID, Name, Strain, Organ, Organelle, Tissue, CellType, CellLine, ATCCId, Diseased, Disease, DevelopmentStage, Sex, DataSetWID, WID)
    End Function
#End Region
Public Function Clone() As biosource
                  Return DirectCast(MyClass.MemberwiseClone, biosource)
              End Function
End Class


End Namespace
