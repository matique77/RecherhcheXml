Imports System.Text.RegularExpressions
''' <summary>
''' Interface implémentant une commande XPath. 
''' </summary>
Public Interface CommandeX

#Region "Propriétés"
    ReadOnly Property Nom As String

    ReadOnly Property Filtre As String

#End Region

#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir du nom de l'élément passé en paramètre. 
    ''' </summary>
    ''' <param name="nomElem">Le nom de l'élément.</param>
    ''' <returns></returns>
    Function Rechercher(nomElem As ElementXml) As Queue(Of ElementXml)

#End Region

End Interface
