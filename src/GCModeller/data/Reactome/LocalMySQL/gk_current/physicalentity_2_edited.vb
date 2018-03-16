﻿#Region "Microsoft.VisualBasic::e18efa1415f83d8de346c7ad90bb2936, data\Reactome\LocalMySQL\gk_current\physicalentity_2_edited.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    ' Class physicalentity_2_edited
    ' 
    '     Properties: DB_ID, edited, edited_class, edited_rank
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:21 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `physicalentity_2_edited`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentity_2_edited` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `edited_rank` int(10) unsigned DEFAULT NULL,
'''   `edited` int(10) unsigned DEFAULT NULL,
'''   `edited_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `edited` (`edited`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentity_2_edited", Database:="gk_current", SchemaSQL:="
CREATE TABLE `physicalentity_2_edited` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `edited_rank` int(10) unsigned DEFAULT NULL,
  `edited` int(10) unsigned DEFAULT NULL,
  `edited_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `edited` (`edited`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class physicalentity_2_edited: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("edited_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="edited_rank")> Public Property edited_rank As Long
    <DatabaseField("edited"), DataType(MySqlDbType.Int64, "10"), Column(Name:="edited")> Public Property edited As Long
    <DatabaseField("edited_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="edited_class")> Public Property edited_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `physicalentity_2_edited` (`DB_ID`, `edited_rank`, `edited`, `edited_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `physicalentity_2_edited` (`DB_ID`, `edited_rank`, `edited`, `edited_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `physicalentity_2_edited` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `physicalentity_2_edited` SET `DB_ID`='{0}', `edited_rank`='{1}', `edited`='{2}', `edited_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `physicalentity_2_edited` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity_2_edited` (`DB_ID`, `edited_rank`, `edited`, `edited_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, edited_rank, edited, edited_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{edited_rank}', '{edited}', '{edited_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity_2_edited` (`DB_ID`, `edited_rank`, `edited`, `edited_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, edited_rank, edited, edited_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `physicalentity_2_edited` SET `DB_ID`='{0}', `edited_rank`='{1}', `edited`='{2}', `edited_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, edited_rank, edited, edited_class, DB_ID)
    End Function
#End Region
Public Function Clone() As physicalentity_2_edited
                  Return DirectCast(MyClass.MemberwiseClone, physicalentity_2_edited)
              End Function
End Class


End Namespace

