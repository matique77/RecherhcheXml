'=================================================================================================
'  Nom du fichier : CommandeXEtoile.vb
'         Classe  : CommandeXEtoile
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 02/05/19
'=================================================================================================
''' <summary>
''' Classe représentant une commande XPath /* et implémentant l'interface
''' ICommandeX. 
''' </summary>
Public Class CommandeXEtoile
    Implements ICommandeX

#Region "Constante"
    ''' <summary>
    ''' Expression régulière validant la forme de la syntaxe /*. 
    ''' </summary>
    Public Const RegxEtoile As String = "^\/\*$"
#End Region


#Region "Attributs"
    ''' <summary>
    ''' Nom de la commande
    ''' </summary>
    Private ReadOnly _nom As String
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
#End Region


#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeXSimple avec * comme nom d'élément.
    ''' </summary>
    ''' <param name="expression">Une expression Xpath débutant par /*.</param>
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
        If (Not RegexMatch(CommandeXEtoile.RegxEtoile, expression)) Then
            Throw New ArgumentException("L'expression n'est pas conforme.")
        End If

        Me._nom = "*"
    End Sub
#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir de l'élément reçu en paramètre et du nom de l'élément.
    ''' </summary>
    ''' <param name="nomElem">L'élément à partir duquel chercher.</param>
    ''' <returns>Une file d'éléments</returns>
    ''' <remarks>Un élément ne peut référer à rien.</remarks>
    Public Function Rechercher(elem As ElementXml) As Queue(Of ElementXml) Implements ICommandeX.Rechercher
        'L'élément ne peut référer à rien. 
        If (elem Is Nothing) Then
            Throw New ArgumentNullException("Un élément ne peut référer à rien.")
        End If

        Dim fileRetour As Queue(Of ElementXml) = New Queue(Of ElementXml)
        For Each elem In elem.ElemEnfants
            fileRetour.Enqueue(elem)
        Next
        Return fileRetour
    End Function


#End Region

End Class
