

Imports RechercheXML
''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXEtoile
    Implements ICommandeX

#Region "Constante"
    Private Const regxEtoile As String = "^\/\*$"
#End Region


#Region "Attributs"
    Private ReadOnly _nom As String
#End Region

#Region "Propriétés"
    Public ReadOnly Property Nom As String Implements ICommandeX.Nom
        Get
            Return Me._nom
        End Get
    End Property
#End Region


#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXSimple avec * comme nom d'élément.
    ''' </summary>
    Public Sub New(expression As String)
        StringValide(expression)
        'On vérifie que l'expression soit valider : 
        If (Not RegexMatch(regxEtoile, expression)) Then
            Throw New ArgumentException("L'expression n'est pas conforme.")
        End If

        'On n'a ni nom, ni filtre
        Me._nom = ""
    End Sub
#End Region



#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns></returns>
    Public Function Rechercher(elem As ElementXml) As Queue(Of ElementXml) Implements ICommandeX.Rechercher
        Dim fileRetour As Queue(Of ElementXml) = New Queue(Of ElementXml)
        For Each elem In elem.ElemEnfants
            fileRetour.Enqueue(elem)
        Next
        Return fileRetour
    End Function


#End Region

End Class
