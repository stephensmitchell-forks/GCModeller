﻿#Region "Microsoft.VisualBasic::48c9fd0baf8d4aab5e35bf2c81a8b33f, data\ExternalDBSource\ExplorEnz\MySQL\hist.vb"

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

    ' Class hist
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:50 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace ExplorEnz.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `hist`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `hist` (
'''   `ec_num` varchar(12) NOT NULL DEFAULT '',
'''   `action` varchar(11) NOT NULL DEFAULT '',
'''   `note` text,
'''   `history` text,
'''   `class` int(1) DEFAULT NULL,
'''   `subclass` int(1) DEFAULT NULL,
'''   `subsubclass` int(1) DEFAULT NULL,
'''   `serial` int(1) DEFAULT NULL,
'''   `status` char(3) DEFAULT NULL,
'''   `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`ec_num`),
'''   UNIQUE KEY `ec_num` (`ec_num`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hist", Database:="enzymed", SchemaSQL:="
CREATE TABLE `hist` (
  `ec_num` varchar(12) NOT NULL DEFAULT '',
  `action` varchar(11) NOT NULL DEFAULT '',
  `note` text,
  `history` text,
  `class` int(1) DEFAULT NULL,
  `subclass` int(1) DEFAULT NULL,
  `subsubclass` int(1) DEFAULT NULL,
  `serial` int(1) DEFAULT NULL,
  `status` char(3) DEFAULT NULL,
  `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ec_num`),
  UNIQUE KEY `ec_num` (`ec_num`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class hist: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ec_num"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property ec_num As String
    <DatabaseField("action"), NotNull, DataType(MySqlDbType.VarChar, "11")> Public Property action As String
    <DatabaseField("note"), DataType(MySqlDbType.Text)> Public Property note As String
    <DatabaseField("history"), DataType(MySqlDbType.Text)> Public Property history As String
    <DatabaseField("class"), DataType(MySqlDbType.Int64, "1")> Public Property [class] As Long
    <DatabaseField("subclass"), DataType(MySqlDbType.Int64, "1")> Public Property subclass As Long
    <DatabaseField("subsubclass"), DataType(MySqlDbType.Int64, "1")> Public Property subsubclass As Long
    <DatabaseField("serial"), DataType(MySqlDbType.Int64, "1")> Public Property serial As Long
    <DatabaseField("status"), DataType(MySqlDbType.VarChar, "3")> Public Property status As String
    <DatabaseField("last_change"), NotNull, DataType(MySqlDbType.DateTime)> Public Property last_change As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `hist` WHERE `ec_num` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `hist` SET `ec_num`='{0}', `action`='{1}', `note`='{2}', `history`='{3}', `class`='{4}', `subclass`='{5}', `subsubclass`='{6}', `serial`='{7}', `status`='{8}', `last_change`='{9}' WHERE `ec_num` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `hist` WHERE `ec_num` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ec_num)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, DataType.ToMySqlDateTimeString(last_change))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ec_num}', '{action}', '{note}', '{history}', '{[class]}', '{subclass}', '{subsubclass}', '{serial}', '{status}', '{last_change}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, DataType.ToMySqlDateTimeString(last_change))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `hist` SET `ec_num`='{0}', `action`='{1}', `note`='{2}', `history`='{3}', `class`='{4}', `subclass`='{5}', `subsubclass`='{6}', `serial`='{7}', `status`='{8}', `last_change`='{9}' WHERE `ec_num` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, DataType.ToMySqlDateTimeString(last_change), ec_num)
    End Function
#End Region
End Class


End Namespace
