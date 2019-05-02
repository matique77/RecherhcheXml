

''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXDouble
    Inherits CommandeX

#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXDouble avec le nom de l'élément de base. 
    ''' </summary>
    Public Sub New(nomElem As String)
        MyBase.New(nomElem)
    End Sub
#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns></returns>
    Public Overrides Function Rechercher(elem As ElementXml) As List(Of ElementXml)
        Dim listeRetour As List(Of ElementXml) = New List(Of ElementXml)
        Me.RechercherRec(elem, listeRetour)
        Return listeRetour
    End Function

    ''' <summary>
    ''' Effectue une recherche recursive tout en ajoutant les éléments trouvés
    ''' dans une liste passée en paramètre. 
    ''' </summary>
    ''' <param name="elem"></param>
    ''' <param name="listeRetour"></param>
    Private Sub RechercherRec(elem As ElementXml, listeRetour As List(Of ElementXml))

        If elem.Nom = Me.Nom Then
            listeRetour.Add(elem)
        End If

        'Cas simple : 
        If elem.NbElementsEnfants = 0 Then
            'On ne fait rien : 
        Else
            For Each sousElem In elem.ElemEnfants
                RechercherRec(sousElem, listeRetour)
            Next
        End If
    End Sub

#End Region

End Class
