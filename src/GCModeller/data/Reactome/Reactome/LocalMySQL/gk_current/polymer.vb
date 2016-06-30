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
''' DROP TABLE IF EXISTS `polymer`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `polymer` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `maxUnitCount` int(10) DEFAULT NULL,
'''   `minUnitCount` int(10) DEFAULT NULL,
'''   `totalProt` text,
'''   `maxHomologues` text,
'''   `inferredProt` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `maxUnitCount` (`maxUnitCount`),
'''   KEY `minUnitCount` (`minUnitCount`),
'''   FULLTEXT KEY `totalProt` (`totalProt`),
'''   FULLTEXT KEY `maxHomologues` (`maxHomologues`),
'''   FULLTEXT KEY `inferredProt` (`inferredProt`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("polymer", Database:="gk_current")>
Public Class polymer: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("maxUnitCount"), DataType(MySqlDbType.Int64, "10")> Public Property maxUnitCount As Long
    <DatabaseField("minUnitCount"), DataType(MySqlDbType.Int64, "10")> Public Property minUnitCount As Long
    <DatabaseField("totalProt"), DataType(MySqlDbType.Text)> Public Property totalProt As String
    <DatabaseField("maxHomologues"), DataType(MySqlDbType.Text)> Public Property maxHomologues As String
    <DatabaseField("inferredProt"), DataType(MySqlDbType.Text)> Public Property inferredProt As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `polymer` (`DB_ID`, `maxUnitCount`, `minUnitCount`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `polymer` (`DB_ID`, `maxUnitCount`, `minUnitCount`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `polymer` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `polymer` SET `DB_ID`='{0}', `maxUnitCount`='{1}', `minUnitCount`='{2}', `totalProt`='{3}', `maxHomologues`='{4}', `inferredProt`='{5}' WHERE `DB_ID` = '{6}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, maxUnitCount, minUnitCount, totalProt, maxHomologues, inferredProt)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, maxUnitCount, minUnitCount, totalProt, maxHomologues, inferredProt)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, maxUnitCount, minUnitCount, totalProt, maxHomologues, inferredProt, DB_ID)
    End Function
#End Region
End Class


End Namespace
