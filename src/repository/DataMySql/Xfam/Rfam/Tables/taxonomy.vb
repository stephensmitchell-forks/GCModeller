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
''' DROP TABLE IF EXISTS `taxonomy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `taxonomy` (
'''   `ncbi_id` int(10) unsigned NOT NULL DEFAULT '0',
'''   `species` varchar(100) NOT NULL DEFAULT '',
'''   `tax_string` mediumtext,
'''   `tree_display_name` varchar(100) DEFAULT NULL,
'''   `align_display_name` varchar(50) DEFAULT NULL,
'''   PRIMARY KEY (`ncbi_id`),
'''   KEY `species` (`species`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("taxonomy", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `taxonomy` (
  `ncbi_id` int(10) unsigned NOT NULL DEFAULT '0',
  `species` varchar(100) NOT NULL DEFAULT '',
  `tax_string` mediumtext,
  `tree_display_name` varchar(100) DEFAULT NULL,
  `align_display_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ncbi_id`),
  KEY `species` (`species`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class taxonomy: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ncbi_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="ncbi_id"), XmlAttribute> Public Property ncbi_id As Long
    <DatabaseField("species"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="species")> Public Property species As String
    <DatabaseField("tax_string"), DataType(MySqlDbType.Text), Column(Name:="tax_string")> Public Property tax_string As String
    <DatabaseField("tree_display_name"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="tree_display_name")> Public Property tree_display_name As String
    <DatabaseField("align_display_name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="align_display_name")> Public Property align_display_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `taxonomy` (`ncbi_id`, `species`, `tax_string`, `tree_display_name`, `align_display_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `taxonomy` (`ncbi_id`, `species`, `tax_string`, `tree_display_name`, `align_display_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `taxonomy` WHERE `ncbi_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `taxonomy` SET `ncbi_id`='{0}', `species`='{1}', `tax_string`='{2}', `tree_display_name`='{3}', `align_display_name`='{4}' WHERE `ncbi_id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `taxonomy` WHERE `ncbi_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ncbi_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `taxonomy` (`ncbi_id`, `species`, `tax_string`, `tree_display_name`, `align_display_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ncbi_id, species, tax_string, tree_display_name, align_display_name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ncbi_id}', '{species}', '{tax_string}', '{tree_display_name}', '{align_display_name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `taxonomy` (`ncbi_id`, `species`, `tax_string`, `tree_display_name`, `align_display_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ncbi_id, species, tax_string, tree_display_name, align_display_name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `taxonomy` SET `ncbi_id`='{0}', `species`='{1}', `tax_string`='{2}', `tree_display_name`='{3}', `align_display_name`='{4}' WHERE `ncbi_id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ncbi_id, species, tax_string, tree_display_name, align_display_name, ncbi_id)
    End Function
#End Region
Public Function Clone() As taxonomy
                  Return DirectCast(MyClass.MemberwiseClone, taxonomy)
              End Function
End Class


End Namespace
