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
''' DROP TABLE IF EXISTS `dead_clan`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dead_clan` (
'''   `clan_acc` varchar(7) NOT NULL DEFAULT '',
'''   `clan_id` varchar(40) NOT NULL COMMENT 'Added. Add author?',
'''   `comment` mediumtext,
'''   `forward_to` varchar(7) DEFAULT NULL,
'''   `user` tinytext NOT NULL,
'''   UNIQUE KEY `rfam_acc` (`clan_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dead_clan", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `dead_clan` (
  `clan_acc` varchar(7) NOT NULL DEFAULT '',
  `clan_id` varchar(40) NOT NULL COMMENT 'Added. Add author?',
  `comment` mediumtext,
  `forward_to` varchar(7) DEFAULT NULL,
  `user` tinytext NOT NULL,
  UNIQUE KEY `rfam_acc` (`clan_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dead_clan: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("clan_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="clan_acc"), XmlAttribute> Public Property clan_acc As String
''' <summary>
''' Added. Add author?
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("clan_id"), NotNull, DataType(MySqlDbType.VarChar, "40"), Column(Name:="clan_id")> Public Property clan_id As String
    <DatabaseField("comment"), DataType(MySqlDbType.Text), Column(Name:="comment")> Public Property comment As String
    <DatabaseField("forward_to"), DataType(MySqlDbType.VarChar, "7"), Column(Name:="forward_to")> Public Property forward_to As String
    <DatabaseField("user"), NotNull, DataType(MySqlDbType.Text), Column(Name:="user")> Public Property user As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dead_clan` (`clan_acc`, `clan_id`, `comment`, `forward_to`, `user`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dead_clan` (`clan_acc`, `clan_id`, `comment`, `forward_to`, `user`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dead_clan` WHERE `clan_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dead_clan` SET `clan_acc`='{0}', `clan_id`='{1}', `comment`='{2}', `forward_to`='{3}', `user`='{4}' WHERE `clan_acc` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dead_clan` WHERE `clan_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, clan_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dead_clan` (`clan_acc`, `clan_id`, `comment`, `forward_to`, `user`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, clan_acc, clan_id, comment, forward_to, user)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{clan_acc}', '{clan_id}', '{comment}', '{forward_to}', '{user}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dead_clan` (`clan_acc`, `clan_id`, `comment`, `forward_to`, `user`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, clan_acc, clan_id, comment, forward_to, user)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dead_clan` SET `clan_acc`='{0}', `clan_id`='{1}', `comment`='{2}', `forward_to`='{3}', `user`='{4}' WHERE `clan_acc` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, clan_acc, clan_id, comment, forward_to, user, clan_acc)
    End Function
#End Region
Public Function Clone() As dead_clan
                  Return DirectCast(MyClass.MemberwiseClone, dead_clan)
              End Function
End Class


End Namespace
