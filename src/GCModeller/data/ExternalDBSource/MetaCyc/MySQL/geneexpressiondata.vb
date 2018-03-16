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
''' DROP TABLE IF EXISTS `geneexpressiondata`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `geneexpressiondata` (
'''   `B` smallint(6) NOT NULL,
'''   `D` smallint(6) NOT NULL,
'''   `Q` smallint(6) NOT NULL,
'''   `Value` varchar(100) NOT NULL,
'''   `BioAssayValuesWID` bigint(20) NOT NULL,
'''   KEY `FK_GEDBAV` (`BioAssayValuesWID`),
'''   CONSTRAINT `FK_GEDBAV` FOREIGN KEY (`BioAssayValuesWID`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("geneexpressiondata", Database:="warehouse", SchemaSQL:="
CREATE TABLE `geneexpressiondata` (
  `B` smallint(6) NOT NULL,
  `D` smallint(6) NOT NULL,
  `Q` smallint(6) NOT NULL,
  `Value` varchar(100) NOT NULL,
  `BioAssayValuesWID` bigint(20) NOT NULL,
  KEY `FK_GEDBAV` (`BioAssayValuesWID`),
  CONSTRAINT `FK_GEDBAV` FOREIGN KEY (`BioAssayValuesWID`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class geneexpressiondata: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("B"), NotNull, DataType(MySqlDbType.Int64, "6"), Column(Name:="B")> Public Property B As Long
    <DatabaseField("D"), NotNull, DataType(MySqlDbType.Int64, "6"), Column(Name:="D")> Public Property D As Long
    <DatabaseField("Q"), NotNull, DataType(MySqlDbType.Int64, "6"), Column(Name:="Q")> Public Property Q As Long
    <DatabaseField("Value"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="Value")> Public Property Value As String
    <DatabaseField("BioAssayValuesWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayValuesWID"), XmlAttribute> Public Property BioAssayValuesWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `geneexpressiondata` WHERE `BioAssayValuesWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `geneexpressiondata` SET `B`='{0}', `D`='{1}', `Q`='{2}', `Value`='{3}', `BioAssayValuesWID`='{4}' WHERE `BioAssayValuesWID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `geneexpressiondata` WHERE `BioAssayValuesWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayValuesWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, B, D, Q, Value, BioAssayValuesWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{B}', '{D}', '{Q}', '{Value}', '{BioAssayValuesWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, B, D, Q, Value, BioAssayValuesWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `geneexpressiondata` SET `B`='{0}', `D`='{1}', `Q`='{2}', `Value`='{3}', `BioAssayValuesWID`='{4}' WHERE `BioAssayValuesWID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, B, D, Q, Value, BioAssayValuesWID, BioAssayValuesWID)
    End Function
#End Region
Public Function Clone() As geneexpressiondata
                  Return DirectCast(MyClass.MemberwiseClone, geneexpressiondata)
              End Function
End Class


End Namespace
