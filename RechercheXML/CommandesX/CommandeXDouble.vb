''' <summary>
''' Classe représentant une commande XPath. 
''' </summary>
Public Class CommandeXDouble
    Implements ICommandeX, IFiltreX


#Region "Constante"
    Private Const regxDouble As String = "^//.[^/]+$"
#End Region

#Region "Attributs"
    Private ReadOnly _nom As String
    Private ReadOnly _filtre As String
#End Region

#Region "Propriétés"
    Public ReadOnly Property Nom As String Implements ICommandeX.Nom
        Get
            Return Me._nom
        End Get
    End Property
    Public ReadOnly Property Filtre As String Implements IFiltreX.Filtre
        Get
            Return Me._filtre
        End Get
    End Property

    Public ReadOnly Property EstFiltree As Boolean Implements IFiltreX.EstFiltree
        Get
            Return Me.Filtre <> ""
        End Get
    End Property
#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXDouble avec le nom de l'élément de base. 
    ''' </summary>
    Public Sub New(expression As String)
        StringValide(expression)
        'On vérifie que l'expression soit valider : 
        If (Not RegexMatch(regxDouble, expression)) Then
            Throw New ArgumentException("L'expression n'est pas conforme.")
        End If

        'On récupère le nom : 
        expression = expression.Substring(2)
        If (RegexMatch(ExprXPath.RegxFiltre, expression)) Then
            Dim nom As String = ""
            While (expression(0) <> "["c)
                nom &= expression(0)
            End While
            Me._nom = nom

            'On récupère le filtre : 
            expression = expression.Substring(2)
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
    Public Function Rechercher(elem As ElementXml) As Queue(Of ElementXml) Implements ICommandeX.Rechercher
        Dim fileRetour As Queue(Of ElementXml) = New Queue(Of ElementXml)
        Me.RechercherRec(elem, fileRetour)
        Return fileRetour
    End Function

    ''' <summary>
    ''' Effectue une recherche recursive tout en ajoutant les éléments trouvés
    ''' dans une liste passée en paramètre. 
    ''' </summary>
    ''' <param name="elem"></param>
    ''' <param name="listeRetour"></param>
    Private Sub RechercherRec(elem As ElementXml, fileRetour As Queue(Of ElementXml))
        'Cas simple : 
        If elem.NbElementsEnfants = 0 Then
            'On ne fait rien : 
        Else
            For Each sousElem In elem.ElemEnfants
                If sousElem.Nom = Me.Nom Then
                    If (Me.EstFiltree) Then
                        For Each attr As Attribut In sousElem.Attributs
                            If (String.Format("{0}={1}", attr.Nom, attr.Valeur) = Me.Filtre) Then
                                fileRetour.Enqueue(sousElem)
                            End If
                        Next
                    Else
                        fileRetour.Enqueue(sousElem)
                    End If
                End If
                RechercherRec(sousElem, fileRetour)
            Next
        End If
    End Sub

#End Region

End Class
