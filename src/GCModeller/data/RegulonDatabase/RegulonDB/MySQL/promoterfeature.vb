REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:08:18 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `promoterfeature`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `promoterfeature` (
'''   `promoter_feature_id` char(12) DEFAULT NULL,
'''   `promoter_id` char(12) DEFAULT NULL,
'''   `feature` varchar(12) DEFAULT NULL,
'''   `pfeature_posleft` decimal(10,0) DEFAULT NULL,
'''   `pfeature_posright` decimal(10,0) DEFAULT NULL,
'''   `pfeature_sequence` varchar(100) DEFAULT NULL,
'''   `pfeature_relative_posleft` decimal(10,0) DEFAULT NULL,
'''   `pfeature_relative_posright` decimal(10,0) DEFAULT NULL,
'''   `pfeature_score` decimal(4,2) DEFAULT NULL,
'''   `pfeature_box_pair` char(12) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("promoterfeature", Database:="regulondb_7_5")>
Public Class promoterfeature: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("promoter_feature_id"), DataType(MySqlDbType.VarChar, "12")> Public Property promoter_feature_id As String
    <DatabaseField("promoter_id"), DataType(MySqlDbType.VarChar, "12")> Public Property promoter_id As String
    <DatabaseField("feature"), DataType(MySqlDbType.VarChar, "12")> Public Property feature As String
    <DatabaseField("pfeature_posleft"), DataType(MySqlDbType.Decimal)> Public Property pfeature_posleft As Decimal
    <DatabaseField("pfeature_posright"), DataType(MySqlDbType.Decimal)> Public Property pfeature_posright As Decimal
    <DatabaseField("pfeature_sequence"), DataType(MySqlDbType.VarChar, "100")> Public Property pfeature_sequence As String
    <DatabaseField("pfeature_relative_posleft"), DataType(MySqlDbType.Decimal)> Public Property pfeature_relative_posleft As Decimal
    <DatabaseField("pfeature_relative_posright"), DataType(MySqlDbType.Decimal)> Public Property pfeature_relative_posright As Decimal
    <DatabaseField("pfeature_score"), DataType(MySqlDbType.Decimal)> Public Property pfeature_score As Decimal
    <DatabaseField("pfeature_box_pair"), DataType(MySqlDbType.VarChar, "12")> Public Property pfeature_box_pair As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `promoterfeature` (`promoter_feature_id`, `promoter_id`, `feature`, `pfeature_posleft`, `pfeature_posright`, `pfeature_sequence`, `pfeature_relative_posleft`, `pfeature_relative_posright`, `pfeature_score`, `pfeature_box_pair`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `promoterfeature` (`promoter_feature_id`, `promoter_id`, `feature`, `pfeature_posleft`, `pfeature_posright`, `pfeature_sequence`, `pfeature_relative_posleft`, `pfeature_relative_posright`, `pfeature_score`, `pfeature_box_pair`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `promoterfeature` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `promoterfeature` SET `promoter_feature_id`='{0}', `promoter_id`='{1}', `feature`='{2}', `pfeature_posleft`='{3}', `pfeature_posright`='{4}', `pfeature_sequence`='{5}', `pfeature_relative_posleft`='{6}', `pfeature_relative_posright`='{7}', `pfeature_score`='{8}', `pfeature_box_pair`='{9}' WHERE ;</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, promoter_feature_id, promoter_id, feature, pfeature_posleft, pfeature_posright, pfeature_sequence, pfeature_relative_posleft, pfeature_relative_posright, pfeature_score, pfeature_box_pair)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, promoter_feature_id, promoter_id, feature, pfeature_posleft, pfeature_posright, pfeature_sequence, pfeature_relative_posleft, pfeature_relative_posright, pfeature_score, pfeature_box_pair)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
