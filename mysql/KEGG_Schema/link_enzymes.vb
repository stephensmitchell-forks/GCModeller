REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:37


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `link_enzymes`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `link_enzymes` (
'''   `enzyme` int(11) NOT NULL,
'''   `EC` varchar(45) DEFAULT NULL,
'''   `database` varchar(45) DEFAULT NULL,
'''   `ID` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`enzyme`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("link_enzymes", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `link_enzymes` (
  `enzyme` int(11) NOT NULL,
  `EC` varchar(45) DEFAULT NULL,
  `database` varchar(45) DEFAULT NULL,
  `ID` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`enzyme`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class link_enzymes: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("enzyme"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="enzyme"), XmlAttribute> Public Property enzyme As Long
    <DatabaseField("EC"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="EC")> Public Property EC As String
    <DatabaseField("database"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="database")> Public Property database As String
    <DatabaseField("ID"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="ID")> Public Property ID As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `link_enzymes` WHERE `enzyme` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `link_enzymes` SET `enzyme`='{0}', `EC`='{1}', `database`='{2}', `ID`='{3}' WHERE `enzyme` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `link_enzymes` WHERE `enzyme` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, enzyme)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, enzyme, EC, database, ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, enzyme, EC, database, ID)
        Else
        Return String.Format(INSERT_SQL, enzyme, EC, database, ID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{enzyme}', '{EC}', '{database}', '{ID}')"
        Else
            Return $"('{enzyme}', '{EC}', '{database}', '{ID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, enzyme, EC, database, ID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `link_enzymes` (`enzyme`, `EC`, `database`, `ID`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, enzyme, EC, database, ID)
        Else
        Return String.Format(REPLACE_SQL, enzyme, EC, database, ID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `link_enzymes` SET `enzyme`='{0}', `EC`='{1}', `database`='{2}', `ID`='{3}' WHERE `enzyme` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, enzyme, EC, database, ID, enzyme)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As link_enzymes
                         Return DirectCast(MyClass.MemberwiseClone, link_enzymes)
                     End Function
End Class


End Namespace
