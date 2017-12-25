﻿#Region "Microsoft.VisualBasic::f9b5a0eb70ae88a3cbde5711e4798e9b, ..\repository\DataMySql\Interpro\Tables\cv_entry_type.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

REM  Dump @3/29/2017 10:21:21 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `cv_entry_type`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `cv_entry_type` (
'''   `code` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `abbrev` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `description` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
'''   PRIMARY KEY (`code`),
'''   UNIQUE KEY `uq_entry_type$abbrev` (`abbrev`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("cv_entry_type", Database:="interpro", SchemaSQL:="
CREATE TABLE `cv_entry_type` (
  `code` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `abbrev` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `description` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
  PRIMARY KEY (`code`),
  UNIQUE KEY `uq_entry_type$abbrev` (`abbrev`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class cv_entry_type: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("code"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property code As String
    <DatabaseField("abbrev"), NotNull, DataType(MySqlDbType.VarChar, "20")> Public Property abbrev As String
    <DatabaseField("description"), DataType(MySqlDbType.Text)> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `cv_entry_type` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `cv_entry_type` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `cv_entry_type` WHERE `code` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `cv_entry_type` SET `code`='{0}', `abbrev`='{1}', `description`='{2}' WHERE `code` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `cv_entry_type` WHERE `code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `cv_entry_type` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, code, abbrev, description)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{code}', '{abbrev}', '{description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `cv_entry_type` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, code, abbrev, description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `cv_entry_type` SET `code`='{0}', `abbrev`='{1}', `description`='{2}' WHERE `code` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, code, abbrev, description, code)
    End Function
#End Region
End Class


End Namespace
