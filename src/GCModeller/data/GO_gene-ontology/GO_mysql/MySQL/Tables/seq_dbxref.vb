REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:59 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `seq_dbxref`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `seq_dbxref` (
'''   `seq_id` int(11) NOT NULL,
'''   `dbxref_id` int(11) NOT NULL,
'''   UNIQUE KEY `seq_id` (`seq_id`,`dbxref_id`),
'''   KEY `seqx0` (`seq_id`),
'''   KEY `seqx1` (`dbxref_id`),
'''   KEY `seqx2` (`seq_id`,`dbxref_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("seq_dbxref", Database:="go", SchemaSQL:="
CREATE TABLE `seq_dbxref` (
  `seq_id` int(11) NOT NULL,
  `dbxref_id` int(11) NOT NULL,
  UNIQUE KEY `seq_id` (`seq_id`,`dbxref_id`),
  KEY `seqx0` (`seq_id`),
  KEY `seqx1` (`dbxref_id`),
  KEY `seqx2` (`seq_id`,`dbxref_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class seq_dbxref: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("seq_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property seq_id As Long
    <DatabaseField("dbxref_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property dbxref_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `seq_dbxref` (`seq_id`, `dbxref_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `seq_dbxref` (`seq_id`, `dbxref_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `seq_dbxref` WHERE `seq_id`='{0}' and `dbxref_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `seq_dbxref` SET `seq_id`='{0}', `dbxref_id`='{1}' WHERE `seq_id`='{2}' and `dbxref_id`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `seq_dbxref` WHERE `seq_id`='{0}' and `dbxref_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, seq_id, dbxref_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `seq_dbxref` (`seq_id`, `dbxref_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, seq_id, dbxref_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{seq_id}', '{dbxref_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `seq_dbxref` (`seq_id`, `dbxref_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, seq_id, dbxref_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `seq_dbxref` SET `seq_id`='{0}', `dbxref_id`='{1}' WHERE `seq_id`='{2}' and `dbxref_id`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, seq_id, dbxref_id, seq_id, dbxref_id)
    End Function
#End Region
End Class


End Namespace
