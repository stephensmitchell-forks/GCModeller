﻿#Region "Microsoft.VisualBasic::494fb0c13650706b31288fd947c4866b, ..\GCModeller\data\Reactome\LocalMySQL\gk_current\entitywithaccessionedsequence.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

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
''' DROP TABLE IF EXISTS `entitywithaccessionedsequence`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entitywithaccessionedsequence` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `endCoordinate` int(10) DEFAULT NULL,
'''   `referenceEntity` int(10) unsigned DEFAULT NULL,
'''   `referenceEntity_class` varchar(64) DEFAULT NULL,
'''   `startCoordinate` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `endCoordinate` (`endCoordinate`),
'''   KEY `referenceEntity` (`referenceEntity`),
'''   KEY `startCoordinate` (`startCoordinate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entitywithaccessionedsequence", Database:="gk_current")>
Public Class entitywithaccessionedsequence: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("endCoordinate"), DataType(MySqlDbType.Int64, "10")> Public Property endCoordinate As Long
    <DatabaseField("referenceEntity"), DataType(MySqlDbType.Int64, "10")> Public Property referenceEntity As Long
    <DatabaseField("referenceEntity_class"), DataType(MySqlDbType.VarChar, "64")> Public Property referenceEntity_class As String
    <DatabaseField("startCoordinate"), DataType(MySqlDbType.Int64, "10")> Public Property startCoordinate As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `entitywithaccessionedsequence` (`DB_ID`, `endCoordinate`, `referenceEntity`, `referenceEntity_class`, `startCoordinate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `entitywithaccessionedsequence` (`DB_ID`, `endCoordinate`, `referenceEntity`, `referenceEntity_class`, `startCoordinate`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `entitywithaccessionedsequence` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `entitywithaccessionedsequence` SET `DB_ID`='{0}', `endCoordinate`='{1}', `referenceEntity`='{2}', `referenceEntity_class`='{3}', `startCoordinate`='{4}' WHERE `DB_ID` = '{5}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, endCoordinate, referenceEntity, referenceEntity_class, startCoordinate)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, endCoordinate, referenceEntity, referenceEntity_class, startCoordinate)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, endCoordinate, referenceEntity, referenceEntity_class, startCoordinate, DB_ID)
    End Function
#End Region
End Class


End Namespace
