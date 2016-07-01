﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.KEGG.DBGET
Imports SMRUCC.genomics.ComponentModel.EquaionModel.DefaultTypes
Imports SMRUCC.genomics.Model.SBML.Level2.Elements
Imports SMRUCC.genomics.Model.SBML.Specifics.MetaCyc

Namespace ExportServices

    Public Module KEGG

        <Extension> Public Function GetReactions(model As Level2.XmlFile, Optional nonEnzymes As Boolean = False) As bGetObject.Reaction()
            Dim allCompounds = (From sp As Specie
                                In model.Model.listOfSpecies.AsParallel
                                Let cp As String = New SpeciesPropReader(sp.Notes).KEGG
                                Where Not String.IsNullOrEmpty(cp)
                                Select cp, sp
                                Group By cp Into Group) _
                                        .ToDictionary(Function(x) x.cp,
                                                      Function(x) x.Group.ToArray(Function(xx) xx.sp))
            Dim Meta2KEGG As Dictionary(Of String, String) =
                (From x In allCompounds.AsParallel
                 Select (From xx As Specie In x.Value
                         Select xx,
                             x.Key)).MatrixAsIterator.ToDictionary(Function(x) x.xx.ID,
                                                                   Function(x) x.Key)
            Dim source = (From x As Reaction In model.Model.listOfReactions
                          Where Meta2KEGG.Exists(x)
                          Select x)
            Dim models = (From x As Reaction In source.AsParallel
                          Let created = __getModel(x, Meta2KEGG, nonEnzymes)
                          Where Not created Is Nothing
                          Select created).ToArray
            Return models
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="rxn"></param>
        ''' <param name="allCompounds"></param>
        ''' <param name="filterNonEnzyme">只会生成非酶促反应的数据</param>
        ''' <returns></returns>
        Private Function __getModel(rxn As Reaction, allCompounds As Dictionary(Of String, String), Optional filterNonEnzyme As Boolean = False) As bGetObject.Reaction
            Dim props As New FluxPropReader(rxn.Notes)

            If filterNonEnzyme Then
                If Not StringHelpers.IsNullOrEmpty(props.ECNumber) Then
                    Return Nothing
                End If
            End If

            Dim equation As New Equation(rxn.Reactants, rxn.Products, allCompounds, rxn.reversible)
            Dim def As New Equation(rxn.Reactants, rxn.Products, rxn.reversible)
            Dim model As New bGetObject.Reaction With {
                .Entry = rxn.id,
                .CommonNames = {rxn.name},
                .Comments = rxn.Notes.Text,
                .Equation = equation.ToString,
                .ECNum = props.ECNumber,
                .Definition = def.ToString
            }
            Return model
        End Function

        <Extension> Public Function Exists(allCompunds As Dictionary(Of String, String), rxn As Reaction) As Boolean
            For Each x In rxn.Reactants
                If Not allCompunds.ContainsKey(x.species) Then
                    Return False
                End If
            Next
            For Each x In rxn.Products
                If Not allCompunds.ContainsKey(x.species) Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Module
End Namespace