'=================================================================================================
'  Nom du fichier : CommandeXSimple.vb
'         Classe  : CommandeXSimple
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 02/05/19
'=================================================================================================

''' <summary>
''' Classe représentant une commande XPath / et implémentant l'interface
''' ICommandeX. 
''' </summary>
Public Class CommandeXSimple
    Implements ICommandeX, IFiltreX

#Region "Constante"
    ''' <summary>
    ''' Expression régulière validant la forme de la syntaxe /. 
    ''' </summary>
    Public Const RegxSimple As String = "^/.[^/]+$"
#End Region

#Region "Attributs"
    ''' <summary>
    ''' Nom de la commande
    ''' </summary>
    Private ReadOnly _nom As String

    ''' <summary>
    ''' Le filtre appliqué à la commande
    ''' </summary>
    Private ReadOnly _filtre As String
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Accède au nom de la commande 
    ''' </summary>
    ''' <returns>Le nom de la commande.</returns>
    Public ReadOnly Property Nom As String Implements ICommandeX.Nom
        Get
            Return Me._nom
        End Get
    End Property

    ''' <summary>
    ''' Accède au filtre de la commande 
    ''' </summary>
    ''' <returns>Le filte de la commande, si elle est filtrée,
    ''' sinon retourne une chaine vide.
    ''' </returns>
    Public ReadOnly Property Filtre As String Implements IFiltreX.Filtre
        Get
            Return Me._filtre
        End Get
    End Property

    ''' <summary>
    ''' Determine si l'élément est filtré. 
    ''' </summary>
    ''' <returns>Vrai si l'élément est filtré, sinon Faux.</returns>
    Public ReadOnly Property EstFiltree As Boolean Implements IFiltreX.EstFiltree
        Get
            Return Me.Filtre <> ""
        End Get
    End Property

#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Permet de créer une CommandeXSimple à partir d'e l'expression.
    ''' </summary>
    ''' <param name="expression">Une expression Xpath débutant par /.</param>
    ''' <remarks>L'expression ne peut être vide ou référer à rien.</remarks>
    Public Sub New(expression As String)
        'On récupère un string Valide. 
        If (expression Is Nothing) Then
            Throw New ArgumentNullException("Une expression de caractère ne référer à rien.")
        End If

        expression = expression.Trim()

        If (expression = "") Then
            Throw New ArgumentException("Une expression ne peut être vide.")
        End If

        'On vérifie que l'expression soit valide : 
        If (Not RegexMatch(CommandeXSimple.RegxSimple, expression)) Then
            Throw New ArgumentException("L'expression n'est pas conforme.")
        End If

        'On récupère le nom : 
        expression = expression.Substring(1)
        If (RegexMatch(ExprXPath.RegxFiltre, expression)) Then
            Dim nom As String = ""
            While (expression(0) <> "["c)
                nom &= expression(0)
                expression = expression.Remove(0, 1)
            End While
            Me._nom = nom

            'On récupère le filtre : 
            expression = expression.Substring(2)
            expression = expression.Remove(expression.Length - 1)
            expression = expression.Replace("'", "")

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
    ''' <param name="elem">L'élément à partir duquel chercher.</param>
    ''' <returns>Une file d'ElementXml. </returns>
    ''' <remarks>Un élément ne peut référer à rien.</remarks>
    Public Function Rechercher(elem As ElementXml) As Queue(Of ElementXml) Implements ICommandeX.Rechercher

        Dim fileRetour As Queue(Of ElementXml) = New Queue(Of ElementXml)
        'On parcourt tous les éléments enfants et retourne une liste. 
        For Each sousElem In elem.ElemEnfants
            If (sousElem.Nom = Me.Nom) Then
                If (Me.EstFiltree) Then
                    For Each attr As Attribut In sousElem.Attributs
                        If (attr.ToString().Replace("""", "") = Me.Filtre) Then
                            fileRetour.Enqueue(sousElem)
                        End If
                    Next
                Else
                    fileRetour.Enqueue(sousElem)
                End If

            End If
        Next
        Return fileRetour
    End Function
#End Region

End Class
