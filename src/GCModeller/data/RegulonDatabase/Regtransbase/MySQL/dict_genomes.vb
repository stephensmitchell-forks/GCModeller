﻿#Region "Microsoft.VisualBasic::c1468888aecccf05029076811ad8db2a, data\RegulonDatabase\Regtransbase\MySQL\dict_genomes.vb"

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

    ' Class dict_genomes
    ' 
    '     Properties: genome_guid, name
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:17 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dict_genomes`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_genomes` (
'''   `genome_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(100) DEFAULT NULL,
'''   PRIMARY KEY (`genome_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_genomes", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_genomes` (
  `genome_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`genome_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dict_genomes: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("genome_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="genome_guid"), XmlAttribute> Public Property genome_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="name")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dict_genomes` (`genome_guid`, `name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dict_genomes` (`genome_guid`, `name`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dict_genomes` WHERE `genome_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dict_genomes` SET `genome_guid`='{0}', `name`='{1}' WHERE `genome_guid` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dict_genomes` WHERE `genome_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, genome_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dict_genomes` (`genome_guid`, `name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, genome_guid, name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{genome_guid}', '{name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_genomes` (`genome_guid`, `name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, genome_guid, name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dict_genomes` SET `genome_guid`='{0}', `name`='{1}' WHERE `genome_guid` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, genome_guid, name, genome_guid)
    End Function
#End Region
Public Function Clone() As dict_genomes
                  Return DirectCast(MyClass.MemberwiseClone, dict_genomes)
              End Function
End Class


End Namespace

