REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:16 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `varsplic_supermatch`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `varsplic_supermatch` (
'''   `protein_ac` varchar(12) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `pos_from` int(5) NOT NULL,
'''   `pos_to` int(5) NOT NULL,
'''   PRIMARY KEY (`protein_ac`,`entry_ac`,`pos_from`,`pos_to`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2015-11-20 18:54:43
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("varsplic_supermatch", Database:="interpro", SchemaSQL:="
CREATE TABLE `varsplic_supermatch` (
  `protein_ac` varchar(12) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `pos_from` int(5) NOT NULL,
  `pos_to` int(5) NOT NULL,
  PRIMARY KEY (`protein_ac`,`entry_ac`,`pos_from`,`pos_to`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class varsplic_supermatch: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="protein_ac"), XmlAttribute> Public Property protein_ac As String
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry_ac"), XmlAttribute> Public Property entry_ac As String
    <DatabaseField("pos_from"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "5"), Column(Name:="pos_from"), XmlAttribute> Public Property pos_from As Long
    <DatabaseField("pos_to"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "5"), Column(Name:="pos_to"), XmlAttribute> Public Property pos_to As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `varsplic_supermatch` (`protein_ac`, `entry_ac`, `pos_from`, `pos_to`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `varsplic_supermatch` (`protein_ac`, `entry_ac`, `pos_from`, `pos_to`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `varsplic_supermatch` WHERE `protein_ac`='{0}' and `entry_ac`='{1}' and `pos_from`='{2}' and `pos_to`='{3}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `varsplic_supermatch` SET `protein_ac`='{0}', `entry_ac`='{1}', `pos_from`='{2}', `pos_to`='{3}' WHERE `protein_ac`='{4}' and `entry_ac`='{5}' and `pos_from`='{6}' and `pos_to`='{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `varsplic_supermatch` WHERE `protein_ac`='{0}' and `entry_ac`='{1}' and `pos_from`='{2}' and `pos_to`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, protein_ac, entry_ac, pos_from, pos_to)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `varsplic_supermatch` (`protein_ac`, `entry_ac`, `pos_from`, `pos_to`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, entry_ac, pos_from, pos_to)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{protein_ac}', '{entry_ac}', '{pos_from}', '{pos_to}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `varsplic_supermatch` (`protein_ac`, `entry_ac`, `pos_from`, `pos_to`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, entry_ac, pos_from, pos_to)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `varsplic_supermatch` SET `protein_ac`='{0}', `entry_ac`='{1}', `pos_from`='{2}', `pos_to`='{3}' WHERE `protein_ac`='{4}' and `entry_ac`='{5}' and `pos_from`='{6}' and `pos_to`='{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, protein_ac, entry_ac, pos_from, pos_to, protein_ac, entry_ac, pos_from, pos_to)
    End Function
#End Region
Public Function Clone() As varsplic_supermatch
                  Return DirectCast(MyClass.MemberwiseClone, varsplic_supermatch)
              End Function
End Class


End Namespace
