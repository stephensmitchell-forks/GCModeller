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
''' DROP TABLE IF EXISTS `clan`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `clan` (
'''   `clan_acc` varchar(7) NOT NULL,
'''   `id` varchar(40) DEFAULT NULL,
'''   `previous_id` tinytext,
'''   `description` varchar(100) DEFAULT NULL,
'''   `author` tinytext,
'''   `comment` longtext,
'''   `created` datetime NOT NULL,
'''   `updated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`clan_acc`),
'''   UNIQUE KEY `clan_acc` (`clan_acc`),
'''   UNIQUE KEY `clan_acc_2` (`clan_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("clan", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `clan` (
  `clan_acc` varchar(7) NOT NULL,
  `id` varchar(40) DEFAULT NULL,
  `previous_id` tinytext,
  `description` varchar(100) DEFAULT NULL,
  `author` tinytext,
  `comment` longtext,
  `created` datetime NOT NULL,
  `updated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`clan_acc`),
  UNIQUE KEY `clan_acc` (`clan_acc`),
  UNIQUE KEY `clan_acc_2` (`clan_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class clan: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("clan_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="clan_acc"), XmlAttribute> Public Property clan_acc As String
    <DatabaseField("id"), DataType(MySqlDbType.VarChar, "40"), Column(Name:="id")> Public Property id As String
    <DatabaseField("previous_id"), DataType(MySqlDbType.Text), Column(Name:="previous_id")> Public Property previous_id As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="description")> Public Property description As String
    <DatabaseField("author"), DataType(MySqlDbType.Text), Column(Name:="author")> Public Property author As String
    <DatabaseField("comment"), DataType(MySqlDbType.Text), Column(Name:="comment")> Public Property comment As String
    <DatabaseField("created"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="created")> Public Property created As Date
    <DatabaseField("updated"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="updated")> Public Property updated As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `clan` (`clan_acc`, `id`, `previous_id`, `description`, `author`, `comment`, `created`, `updated`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `clan` (`clan_acc`, `id`, `previous_id`, `description`, `author`, `comment`, `created`, `updated`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `clan` WHERE `clan_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `clan` SET `clan_acc`='{0}', `id`='{1}', `previous_id`='{2}', `description`='{3}', `author`='{4}', `comment`='{5}', `created`='{6}', `updated`='{7}' WHERE `clan_acc` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `clan` WHERE `clan_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, clan_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `clan` (`clan_acc`, `id`, `previous_id`, `description`, `author`, `comment`, `created`, `updated`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, clan_acc, id, previous_id, description, author, comment, MySqlScript.ToMySqlDateTimeString(created), MySqlScript.ToMySqlDateTimeString(updated))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{clan_acc}', '{id}', '{previous_id}', '{description}', '{author}', '{comment}', '{created}', '{updated}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `clan` (`clan_acc`, `id`, `previous_id`, `description`, `author`, `comment`, `created`, `updated`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, clan_acc, id, previous_id, description, author, comment, MySqlScript.ToMySqlDateTimeString(created), MySqlScript.ToMySqlDateTimeString(updated))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `clan` SET `clan_acc`='{0}', `id`='{1}', `previous_id`='{2}', `description`='{3}', `author`='{4}', `comment`='{5}', `created`='{6}', `updated`='{7}' WHERE `clan_acc` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, clan_acc, id, previous_id, description, author, comment, MySqlScript.ToMySqlDateTimeString(created), MySqlScript.ToMySqlDateTimeString(updated), clan_acc)
    End Function
#End Region
Public Function Clone() As clan
                  Return DirectCast(MyClass.MemberwiseClone, clan)
              End Function
End Class


End Namespace
