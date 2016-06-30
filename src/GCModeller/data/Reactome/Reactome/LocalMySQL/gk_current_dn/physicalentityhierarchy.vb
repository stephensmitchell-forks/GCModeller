REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:16:51 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current_dn

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `physicalentityhierarchy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentityhierarchy` (
'''   `physicalEntityId` int(32) NOT NULL DEFAULT '0',
'''   `childPhysicalEntityId` int(32) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`physicalEntityId`,`childPhysicalEntityId`),
'''   CONSTRAINT `PhysicalEntityHierarchy_ibfk_1` FOREIGN KEY (`physicalEntityId`) REFERENCES `physicalentity` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentityhierarchy", Database:="gk_current_dn")>
Public Class physicalentityhierarchy: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("physicalEntityId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property physicalEntityId As Long
    <DatabaseField("childPhysicalEntityId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32")> Public Property childPhysicalEntityId As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `physicalentityhierarchy` WHERE `physicalEntityId`='{0}' and `childPhysicalEntityId`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `physicalentityhierarchy` SET `physicalEntityId`='{0}', `childPhysicalEntityId`='{1}' WHERE `physicalEntityId`='{2}' and `childPhysicalEntityId`='{3}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, physicalEntityId, childPhysicalEntityId)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, physicalEntityId, childPhysicalEntityId)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, physicalEntityId, childPhysicalEntityId)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, physicalEntityId, childPhysicalEntityId, physicalEntityId, childPhysicalEntityId)
    End Function
#End Region
End Class


End Namespace
