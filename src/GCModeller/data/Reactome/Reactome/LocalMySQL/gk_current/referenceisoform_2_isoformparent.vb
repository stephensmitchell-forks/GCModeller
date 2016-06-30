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
''' DROP TABLE IF EXISTS `referenceisoform_2_isoformparent`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referenceisoform_2_isoformparent` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `isoformParent_rank` int(10) unsigned DEFAULT NULL,
'''   `isoformParent` int(10) unsigned DEFAULT NULL,
'''   `isoformParent_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `isoformParent` (`isoformParent`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referenceisoform_2_isoformparent", Database:="gk_current")>
Public Class referenceisoform_2_isoformparent: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("isoformParent_rank"), DataType(MySqlDbType.Int64, "10")> Public Property isoformParent_rank As Long
    <DatabaseField("isoformParent"), DataType(MySqlDbType.Int64, "10")> Public Property isoformParent As Long
    <DatabaseField("isoformParent_class"), DataType(MySqlDbType.VarChar, "64")> Public Property isoformParent_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `referenceisoform_2_isoformparent` (`DB_ID`, `isoformParent_rank`, `isoformParent`, `isoformParent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `referenceisoform_2_isoformparent` (`DB_ID`, `isoformParent_rank`, `isoformParent`, `isoformParent_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `referenceisoform_2_isoformparent` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `referenceisoform_2_isoformparent` SET `DB_ID`='{0}', `isoformParent_rank`='{1}', `isoformParent`='{2}', `isoformParent_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, isoformParent_rank, isoformParent, isoformParent_class)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, isoformParent_rank, isoformParent, isoformParent_class)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, isoformParent_rank, isoformParent, isoformParent_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
