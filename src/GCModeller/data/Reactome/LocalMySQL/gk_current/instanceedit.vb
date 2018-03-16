REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:21 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `instanceedit`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `instanceedit` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `_applyToAllEditedInstances` text,
'''   `dateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   `note` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `dateTime` (`dateTime`),
'''   FULLTEXT KEY `_applyToAllEditedInstances` (`_applyToAllEditedInstances`),
'''   FULLTEXT KEY `note` (`note`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("instanceedit", Database:="gk_current", SchemaSQL:="
CREATE TABLE `instanceedit` (
  `DB_ID` int(10) unsigned NOT NULL,
  `_applyToAllEditedInstances` text,
  `dateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `note` text,
  PRIMARY KEY (`DB_ID`),
  KEY `dateTime` (`dateTime`),
  FULLTEXT KEY `_applyToAllEditedInstances` (`_applyToAllEditedInstances`),
  FULLTEXT KEY `note` (`note`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class instanceedit: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("_applyToAllEditedInstances"), DataType(MySqlDbType.Text), Column(Name:="_applyToAllEditedInstances")> Public Property _applyToAllEditedInstances As String
    <DatabaseField("dateTime"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="dateTime")> Public Property dateTime As Date
    <DatabaseField("note"), DataType(MySqlDbType.Text), Column(Name:="note")> Public Property note As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `instanceedit` (`DB_ID`, `_applyToAllEditedInstances`, `dateTime`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `instanceedit` (`DB_ID`, `_applyToAllEditedInstances`, `dateTime`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `instanceedit` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `instanceedit` SET `DB_ID`='{0}', `_applyToAllEditedInstances`='{1}', `dateTime`='{2}', `note`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `instanceedit` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `instanceedit` (`DB_ID`, `_applyToAllEditedInstances`, `dateTime`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, _applyToAllEditedInstances, MySqlScript.ToMySqlDateTimeString(dateTime), note)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{_applyToAllEditedInstances}', '{dateTime}', '{note}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `instanceedit` (`DB_ID`, `_applyToAllEditedInstances`, `dateTime`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, _applyToAllEditedInstances, MySqlScript.ToMySqlDateTimeString(dateTime), note)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `instanceedit` SET `DB_ID`='{0}', `_applyToAllEditedInstances`='{1}', `dateTime`='{2}', `note`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, _applyToAllEditedInstances, MySqlScript.ToMySqlDateTimeString(dateTime), note, DB_ID)
    End Function
#End Region
Public Function Clone() As instanceedit
                  Return DirectCast(MyClass.MemberwiseClone, instanceedit)
              End Function
End Class


End Namespace
