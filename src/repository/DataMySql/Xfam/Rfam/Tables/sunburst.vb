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
''' DROP TABLE IF EXISTS `sunburst`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `sunburst` (
'''   `rfam_acc` varchar(7) NOT NULL,
'''   `data` longblob NOT NULL,
'''   `type` enum('rfamseq','genome','refseq') NOT NULL,
'''   KEY `fk_table1_family3_idx` (`rfam_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("sunburst", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `sunburst` (
  `rfam_acc` varchar(7) NOT NULL,
  `data` longblob NOT NULL,
  `type` enum('rfamseq','genome','refseq') NOT NULL,
  KEY `fk_table1_family3_idx` (`rfam_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class sunburst: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="rfam_acc"), XmlAttribute> Public Property rfam_acc As String
    <DatabaseField("data"), NotNull, DataType(MySqlDbType.Blob), Column(Name:="data")> Public Property data As Byte()
    <DatabaseField("type"), NotNull, DataType(MySqlDbType.String), Column(Name:="type")> Public Property type As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `sunburst` (`rfam_acc`, `data`, `type`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `sunburst` (`rfam_acc`, `data`, `type`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `sunburst` WHERE `rfam_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `sunburst` SET `rfam_acc`='{0}', `data`='{1}', `type`='{2}' WHERE `rfam_acc` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `sunburst` WHERE `rfam_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `sunburst` (`rfam_acc`, `data`, `type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_acc, data, type)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{rfam_acc}', '{data}', '{type}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `sunburst` (`rfam_acc`, `data`, `type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_acc, data, type)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `sunburst` SET `rfam_acc`='{0}', `data`='{1}', `type`='{2}' WHERE `rfam_acc` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_acc, data, type, rfam_acc)
    End Function
#End Region
Public Function Clone() As sunburst
                  Return DirectCast(MyClass.MemberwiseClone, sunburst)
              End Function
End Class


End Namespace
