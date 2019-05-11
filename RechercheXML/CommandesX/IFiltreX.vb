'=================================================================================================
'  Nom du fichier : IFiltreX.vb
'      Interface  : IFiltreX
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 02/05/19
'==================================================================================================

''' <summary>
''' Interface implémentant un filtre d'une commande XPath. 
''' </summary>
Public Interface IFiltreX

    ''' <summary>
    ''' Permet de d’accéder au filtre.
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property Filtre As String

    ''' <summary>
    ''' Determine si l'élément est filtré.
    ''' </summary>
    ''' <returns>Vrai si l'élément est filtré, faux sinon.</returns>
    ReadOnly Property EstFiltree As Boolean
End Interface
