

''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXEtoile
    Inherits CommandeX

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
    Public Overrides Function Rechercher(elem As ElementXml) As List(Of ElementXml)
        Return elem.ElemEnfants
    End Function

#End Region

End Class
