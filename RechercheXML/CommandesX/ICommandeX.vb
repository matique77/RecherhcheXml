'=================================================================================================
'  Nom du fichier : ICommandeX.vb
'      Interface  : ICommandeX
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 02/05/19
'==================================================================================================
''' <summary>
''' Interface implémentant une commande XPath. 
''' </summary>
Public Interface ICommandeX

#Region "Propriétés"
    ''' <summary>
    ''' Le nom de la commande.
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Nom As String

#End Region

#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir du nom de l'élément passé en paramètre. 
    ''' </summary>
    ''' <param name="nomElem">Le nom de l'élément.</param>
    ''' <returns>Une file d'ElementXml.</returns>
    Function Rechercher(nomElem As ElementXml) As Queue(Of ElementXml)
#End Region

End Interface
