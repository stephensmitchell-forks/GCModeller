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
''' DROP TABLE IF EXISTS `go_biologicalprocess`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `go_biologicalprocess` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `accession` text,
'''   `definition` text,
'''   `referenceDatabase` int(10) unsigned DEFAULT NULL,
'''   `referenceDatabase_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `referenceDatabase` (`referenceDatabase`),
'''   FULLTEXT KEY `accession` (`accession`),
'''   FULLTEXT KEY `definition` (`definition`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("go_biologicalprocess", Database:="gk_current")>
Public Class go_biologicalprocess: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("accession"), DataType(MySqlDbType.Text)> Public Property accession As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text)> Public Property definition As String
    <DatabaseField("referenceDatabase"), DataType(MySqlDbType.Int64, "10")> Public Property referenceDatabase As Long
    <DatabaseField("referenceDatabase_class"), DataType(MySqlDbType.VarChar, "64")> Public Property referenceDatabase_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `go_biologicalprocess` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `go_biologicalprocess` SET `DB_ID`='{0}', `accession`='{1}', `definition`='{2}', `referenceDatabase`='{3}', `referenceDatabase_class`='{4}' WHERE `DB_ID` = '{5}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
