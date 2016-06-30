REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:15:49 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `polymer_2_repeatedunit`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `polymer_2_repeatedunit` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `repeatedUnit_rank` int(10) unsigned DEFAULT NULL,
'''   `repeatedUnit` int(10) unsigned DEFAULT NULL,
'''   `repeatedUnit_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `repeatedUnit` (`repeatedUnit`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("polymer_2_repeatedunit", Database:="gk_current")>
Public Class polymer_2_repeatedunit: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("repeatedUnit_rank"), DataType(MySqlDbType.Int64, "10")> Public Property repeatedUnit_rank As Long
    <DatabaseField("repeatedUnit"), DataType(MySqlDbType.Int64, "10")> Public Property repeatedUnit As Long
    <DatabaseField("repeatedUnit_class"), DataType(MySqlDbType.VarChar, "64")> Public Property repeatedUnit_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `polymer_2_repeatedunit` (`DB_ID`, `repeatedUnit_rank`, `repeatedUnit`, `repeatedUnit_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `polymer_2_repeatedunit` (`DB_ID`, `repeatedUnit_rank`, `repeatedUnit`, `repeatedUnit_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `polymer_2_repeatedunit` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `polymer_2_repeatedunit` SET `DB_ID`='{0}', `repeatedUnit_rank`='{1}', `repeatedUnit`='{2}', `repeatedUnit_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, repeatedUnit_rank, repeatedUnit, repeatedUnit_class)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, repeatedUnit_rank, repeatedUnit, repeatedUnit_class)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, repeatedUnit_rank, repeatedUnit, repeatedUnit_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
