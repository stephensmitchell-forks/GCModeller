﻿#Region "Microsoft.VisualBasic::ceb60e9ec1e3e70b1daa29245ed50a99, data\ExternalDBSource\MetaCyc\MySQL\composseqwidrepocomposmapwid.vb"

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

    ' Class composseqwidrepocomposmapwid
    ' 
    '     Properties: CompositeSequenceWID, ReporterCompositeMapWID
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:19 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `composseqwidrepocomposmapwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `composseqwidrepocomposmapwid` (
'''   `CompositeSequenceWID` bigint(20) NOT NULL,
'''   `ReporterCompositeMapWID` bigint(20) NOT NULL,
'''   KEY `FK_ComposSeqWIDRepoComposMap1` (`CompositeSequenceWID`),
'''   KEY `FK_ComposSeqWIDRepoComposMap2` (`ReporterCompositeMapWID`),
'''   CONSTRAINT `FK_ComposSeqWIDRepoComposMap1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ComposSeqWIDRepoComposMap2` FOREIGN KEY (`ReporterCompositeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("composseqwidrepocomposmapwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `composseqwidrepocomposmapwid` (
  `CompositeSequenceWID` bigint(20) NOT NULL,
  `ReporterCompositeMapWID` bigint(20) NOT NULL,
  KEY `FK_ComposSeqWIDRepoComposMap1` (`CompositeSequenceWID`),
  KEY `FK_ComposSeqWIDRepoComposMap2` (`ReporterCompositeMapWID`),
  CONSTRAINT `FK_ComposSeqWIDRepoComposMap1` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ComposSeqWIDRepoComposMap2` FOREIGN KEY (`ReporterCompositeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class composseqwidrepocomposmapwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("CompositeSequenceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="CompositeSequenceWID"), XmlAttribute> Public Property CompositeSequenceWID As Long
    <DatabaseField("ReporterCompositeMapWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ReporterCompositeMapWID")> Public Property ReporterCompositeMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `composseqwidrepocomposmapwid` WHERE `CompositeSequenceWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `composseqwidrepocomposmapwid` SET `CompositeSequenceWID`='{0}', `ReporterCompositeMapWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `composseqwidrepocomposmapwid` WHERE `CompositeSequenceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, CompositeSequenceWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, CompositeSequenceWID, ReporterCompositeMapWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{CompositeSequenceWID}', '{ReporterCompositeMapWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `composseqwidrepocomposmapwid` (`CompositeSequenceWID`, `ReporterCompositeMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, CompositeSequenceWID, ReporterCompositeMapWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `composseqwidrepocomposmapwid` SET `CompositeSequenceWID`='{0}', `ReporterCompositeMapWID`='{1}' WHERE `CompositeSequenceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, CompositeSequenceWID, ReporterCompositeMapWID, CompositeSequenceWID)
    End Function
#End Region
Public Function Clone() As composseqwidrepocomposmapwid
                  Return DirectCast(MyClass.MemberwiseClone, composseqwidrepocomposmapwid)
              End Function
End Class


End Namespace

