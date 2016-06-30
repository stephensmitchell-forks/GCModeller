REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:07:30 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `h_dict_exp_technique_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `h_dict_exp_technique_types` (
'''   `pkg_name` varchar(100) NOT NULL DEFAULT '',
'''   `db_name` varchar(100) DEFAULT NULL,
'''   PRIMARY KEY (`pkg_name`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("h_dict_exp_technique_types", Database:="dbregulation_update")>
Public Class h_dict_exp_technique_types: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pkg_name"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property pkg_name As String
    <DatabaseField("db_name"), DataType(MySqlDbType.VarChar, "100")> Public Property db_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `h_dict_exp_technique_types` (`pkg_name`, `db_name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `h_dict_exp_technique_types` (`pkg_name`, `db_name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `h_dict_exp_technique_types` WHERE `pkg_name` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `h_dict_exp_technique_types` SET `pkg_name`='{0}', `db_name`='{1}' WHERE `pkg_name` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pkg_name)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pkg_name, db_name)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pkg_name, db_name)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pkg_name, db_name, pkg_name)
    End Function
#End Region
End Class


End Namespace
