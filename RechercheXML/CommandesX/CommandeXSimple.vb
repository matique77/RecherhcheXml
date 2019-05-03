Imports System.Text.RegularExpressions


''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public Class CommandeXSimple
    Implements CommandeX

#Region "Constante"
    Private Const regxSimple As String = "^/.[^/]+$"
#End Region

#Region "Attributs"
    Private ReadOnly _nom As String
    Private ReadOnly _filtre As String
#End Region

#Region "Propriétés"
    Public ReadOnly Property Nom As String Implements CommandeX.Nom
        Get
            Return Me._nom
        End Get
    End Property
    Public ReadOnly Property Filtre As String Implements CommandeX.Filtre
        Get
            Return Me._filtre
        End Get
    End Property
#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Permet de créer une CommandeXSimple à partir d'une expression donnée.
    ''' </summary>
    Public Sub New(expression As String)
        StringValide(expression)
        'On vérifie que l'expression soit valider : 
        If (Not RegexMatch(regxSimple, expression)) Then
            Throw New ArgumentException("L'expression n'est pas conforme.")
        End If

        'On récupère le nom : 
        expression = expression.Substring(1)
        If (RegexMatch(ExprXPath.RegxFiltre, expression)) Then
            Dim index As Integer = 0
            Dim nom As String
            While (expression(index) <> "["c)
                nom &= expression(index)
            End While

            'On récupère le filtre : 
            expression = expression.Substring(index + 2)
            expression = expression.Remove(expression.Length - 1)
            Me._filtre = expression
        Else
                Me._nom = expression
                Me._filtre = ""
        End If
    End Sub

#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns></returns>
    Public Function Rechercher(elem As ElementXml) As Queue(Of ElementXml) Implements CommandeX.Rechercher
        Dim fileRetour As Queue(Of ElementXml) = New Queue(Of ElementXml)
        'On parcourt tous les éléments enfants et retourne une liste. 
        For Each sousElem In elem.ElemEnfants
            If (sousElem.Nom = Me.Nom) Then
                fileRetour.Enqueue(sousElem)
            End If
        Next
        Return fileRetour
    End Function

#End Region

End Class
