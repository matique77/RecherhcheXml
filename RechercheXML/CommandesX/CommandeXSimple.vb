

''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXSimple
    Inherits CommandeX

#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXSimple avec le nom de l'élément à cherher
    ''' </summary>
    Public Sub New(nom As String)
        MyBase.New(nom)
    End Sub

#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns></returns>
    Public Overrides Function Rechercher(elem As ElementXml) As List(Of ElementXml)
        Dim listeRetour As List(Of ElementXml)
        'On parcourt tous les éléments enfants et retourne une liste. 
        For Each sousElem In elem.ElemEnfants
            If (sousElem.Nom = Me.Nom) Then
                listeRetour.Add(sousElem)
            End If
        Next
        Return listeRetour
    End Function

#End Region

End Class
