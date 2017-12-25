﻿#Region "Microsoft.VisualBasic::4c2240516fe8a82da32ad05e0f25809d, ..\GCModeller\data\ExternalDBSource\MetaCyc\MySQL\dataexternal.vb"

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

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dataexternal`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dataexternal` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `DataFormat` varchar(255) DEFAULT NULL,
'''   `DataFormatInfoURI` varchar(255) DEFAULT NULL,
'''   `FilenameURI` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_DataExternal1` (`DataSetWID`),
'''   CONSTRAINT `FK_DataExternal1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dataexternal", Database:="warehouse", SchemaSQL:="
CREATE TABLE `dataexternal` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `DataFormat` varchar(255) DEFAULT NULL,
  `DataFormatInfoURI` varchar(255) DEFAULT NULL,
  `FilenameURI` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_DataExternal1` (`DataSetWID`),
  CONSTRAINT `FK_DataExternal1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class dataexternal: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
    <DatabaseField("DataFormat"), DataType(MySqlDbType.VarChar, "255")> Public Property DataFormat As String
    <DatabaseField("DataFormatInfoURI"), DataType(MySqlDbType.VarChar, "255")> Public Property DataFormatInfoURI As String
    <DatabaseField("FilenameURI"), DataType(MySqlDbType.VarChar, "255")> Public Property FilenameURI As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dataexternal` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dataexternal` SET `WID`='{0}', `DataSetWID`='{1}', `DataFormat`='{2}', `DataFormatInfoURI`='{3}', `FilenameURI`='{4}' WHERE `WID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dataexternal` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{DataFormat}', '{DataFormatInfoURI}', '{FilenameURI}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dataexternal` SET `WID`='{0}', `DataSetWID`='{1}', `DataFormat`='{2}', `DataFormatInfoURI`='{3}', `FilenameURI`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI, WID)
    End Function
#End Region
End Class


End Namespace
