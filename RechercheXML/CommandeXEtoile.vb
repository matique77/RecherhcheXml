

Imports RechercheXML
''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXEtoile
    Inherits CommandeX

#Region "Propriétés"
    Public Overrides Property Nom As String
        Get
            Return MyBase.Nom
        End Get
        Private Set(value As String)

        End Set
    End Property


#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXSimple avec * comme nom d'élément.
    ''' </summary>
    Public Sub New()
        MyBase.New("*")
    End Sub
#End Region



#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns></returns>
    Public Function Rechercher(elem As ElementXml) As List(Of ElementXml)
        Return elem.ElemEnfants
    End Function

    Public Function Rechercher(nomElem As ElementXml, As Object) As List(Of ElementXml)
        Throw New NotImplementedException()
    End Function

#End Region

End Class
