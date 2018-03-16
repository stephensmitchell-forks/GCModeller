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
''' DROP TABLE IF EXISTS `support`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `support` (
'''   `WID` bigint(20) NOT NULL,
'''   `OtherWID` bigint(20) NOT NULL,
'''   `Type` varchar(100) DEFAULT NULL,
'''   `EvidenceType` varchar(100) DEFAULT NULL,
'''   `Confidence` float DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("support", Database:="warehouse", SchemaSQL:="
CREATE TABLE `support` (
  `WID` bigint(20) NOT NULL,
  `OtherWID` bigint(20) NOT NULL,
  `Type` varchar(100) DEFAULT NULL,
  `EvidenceType` varchar(100) DEFAULT NULL,
  `Confidence` float DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class support: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("OtherWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="OtherWID")> Public Property OtherWID As Long
    <DatabaseField("Type"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="Type")> Public Property Type As String
    <DatabaseField("EvidenceType"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="EvidenceType")> Public Property EvidenceType As String
    <DatabaseField("Confidence"), DataType(MySqlDbType.Double), Column(Name:="Confidence")> Public Property Confidence As Double
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `support` (`WID`, `OtherWID`, `Type`, `EvidenceType`, `Confidence`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `support` (`WID`, `OtherWID`, `Type`, `EvidenceType`, `Confidence`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `support` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `support` SET `WID`='{0}', `OtherWID`='{1}', `Type`='{2}', `EvidenceType`='{3}', `Confidence`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `support` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `support` (`WID`, `OtherWID`, `Type`, `EvidenceType`, `Confidence`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, OtherWID, Type, EvidenceType, Confidence, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{OtherWID}', '{Type}', '{EvidenceType}', '{Confidence}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `support` (`WID`, `OtherWID`, `Type`, `EvidenceType`, `Confidence`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, OtherWID, Type, EvidenceType, Confidence, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `support` SET `WID`='{0}', `OtherWID`='{1}', `Type`='{2}', `EvidenceType`='{3}', `Confidence`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, OtherWID, Type, EvidenceType, Confidence, DataSetWID, WID)
    End Function
#End Region
Public Function Clone() As support
                  Return DirectCast(MyClass.MemberwiseClone, support)
              End Function
End Class


End Namespace
