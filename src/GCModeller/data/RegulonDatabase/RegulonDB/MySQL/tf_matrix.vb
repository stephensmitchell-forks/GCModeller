REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:14 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `tf_matrix`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `tf_matrix` (
'''   `tf_matrix_id` char(12) NOT NULL,
'''   `transcription_factor_id` char(12) NOT NULL,
'''   `tf_matrix_name` varchar(255) DEFAULT NULL,
'''   `media` decimal(5,2) NOT NULL,
'''   `standar_desv` decimal(8,3) NOT NULL,
'''   `score_low` decimal(5,2) NOT NULL,
'''   `score_high` decimal(5,2) DEFAULT NULL,
'''   `tf_matrix_note` varchar(2000) DEFAULT NULL,
'''   `tf_matrix_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("tf_matrix", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `tf_matrix` (
  `tf_matrix_id` char(12) NOT NULL,
  `transcription_factor_id` char(12) NOT NULL,
  `tf_matrix_name` varchar(255) DEFAULT NULL,
  `media` decimal(5,2) NOT NULL,
  `standar_desv` decimal(8,3) NOT NULL,
  `score_low` decimal(5,2) NOT NULL,
  `score_high` decimal(5,2) DEFAULT NULL,
  `tf_matrix_note` varchar(2000) DEFAULT NULL,
  `tf_matrix_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class tf_matrix: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_matrix_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="tf_matrix_id")> Public Property tf_matrix_id As String
    <DatabaseField("transcription_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="transcription_factor_id")> Public Property transcription_factor_id As String
    <DatabaseField("tf_matrix_name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="tf_matrix_name")> Public Property tf_matrix_name As String
    <DatabaseField("media"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="media")> Public Property media As Decimal
    <DatabaseField("standar_desv"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="standar_desv")> Public Property standar_desv As Decimal
    <DatabaseField("score_low"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="score_low")> Public Property score_low As Decimal
    <DatabaseField("score_high"), DataType(MySqlDbType.Decimal), Column(Name:="score_high")> Public Property score_high As Decimal
    <DatabaseField("tf_matrix_note"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="tf_matrix_note")> Public Property tf_matrix_note As String
    <DatabaseField("tf_matrix_internal_comment"), DataType(MySqlDbType.Text), Column(Name:="tf_matrix_internal_comment")> Public Property tf_matrix_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="key_id_org")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `tf_matrix` (`tf_matrix_id`, `transcription_factor_id`, `tf_matrix_name`, `media`, `standar_desv`, `score_low`, `score_high`, `tf_matrix_note`, `tf_matrix_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `tf_matrix` (`tf_matrix_id`, `transcription_factor_id`, `tf_matrix_name`, `media`, `standar_desv`, `score_low`, `score_high`, `tf_matrix_note`, `tf_matrix_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `tf_matrix` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `tf_matrix` SET `tf_matrix_id`='{0}', `transcription_factor_id`='{1}', `tf_matrix_name`='{2}', `media`='{3}', `standar_desv`='{4}', `score_low`='{5}', `score_high`='{6}', `tf_matrix_note`='{7}', `tf_matrix_internal_comment`='{8}', `key_id_org`='{9}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `tf_matrix` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `tf_matrix` (`tf_matrix_id`, `transcription_factor_id`, `tf_matrix_name`, `media`, `standar_desv`, `score_low`, `score_high`, `tf_matrix_note`, `tf_matrix_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_matrix_id, transcription_factor_id, tf_matrix_name, media, standar_desv, score_low, score_high, tf_matrix_note, tf_matrix_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_matrix_id}', '{transcription_factor_id}', '{tf_matrix_name}', '{media}', '{standar_desv}', '{score_low}', '{score_high}', '{tf_matrix_note}', '{tf_matrix_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `tf_matrix` (`tf_matrix_id`, `transcription_factor_id`, `tf_matrix_name`, `media`, `standar_desv`, `score_low`, `score_high`, `tf_matrix_note`, `tf_matrix_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_matrix_id, transcription_factor_id, tf_matrix_name, media, standar_desv, score_low, score_high, tf_matrix_note, tf_matrix_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `tf_matrix` SET `tf_matrix_id`='{0}', `transcription_factor_id`='{1}', `tf_matrix_name`='{2}', `media`='{3}', `standar_desv`='{4}', `score_low`='{5}', `score_high`='{6}', `tf_matrix_note`='{7}', `tf_matrix_internal_comment`='{8}', `key_id_org`='{9}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As tf_matrix
                  Return DirectCast(MyClass.MemberwiseClone, tf_matrix)
              End Function
End Class


End Namespace
