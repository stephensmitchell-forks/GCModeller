﻿#Region "Microsoft.VisualBasic::a1e99b2dbc0b967199272466ba0ae1a6, ..\GCModeller\data\RegulonDatabase\RegulonDB\MySQL\gu_reaction_link.vb"

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

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `gu_reaction_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gu_reaction_link` (
'''   `gu_id` char(12) NOT NULL,
'''   `reaction_id` char(12) NOT NULL,
'''   `reaction_number` varchar(50) NOT NULL,
'''   `reaction_order` decimal(10,0) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gu_reaction_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `gu_reaction_link` (
  `gu_id` char(12) NOT NULL,
  `reaction_id` char(12) NOT NULL,
  `reaction_number` varchar(50) NOT NULL,
  `reaction_order` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class gu_reaction_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gu_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property gu_id As String
    <DatabaseField("reaction_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property reaction_id As String
    <DatabaseField("reaction_number"), NotNull, DataType(MySqlDbType.VarChar, "50")> Public Property reaction_number As String
    <DatabaseField("reaction_order"), DataType(MySqlDbType.Decimal)> Public Property reaction_order As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gu_reaction_link` (`gu_id`, `reaction_id`, `reaction_number`, `reaction_order`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gu_reaction_link` (`gu_id`, `reaction_id`, `reaction_number`, `reaction_order`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gu_reaction_link` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gu_reaction_link` SET `gu_id`='{0}', `reaction_id`='{1}', `reaction_number`='{2}', `reaction_order`='{3}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gu_reaction_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gu_reaction_link` (`gu_id`, `reaction_id`, `reaction_number`, `reaction_order`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gu_id, reaction_id, reaction_number, reaction_order)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gu_id}', '{reaction_id}', '{reaction_number}', '{reaction_order}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gu_reaction_link` (`gu_id`, `reaction_id`, `reaction_number`, `reaction_order`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gu_id, reaction_id, reaction_number, reaction_order)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gu_reaction_link` SET `gu_id`='{0}', `reaction_id`='{1}', `reaction_number`='{2}', `reaction_order`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace

