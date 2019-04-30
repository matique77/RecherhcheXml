Imports RechercheXML
'=================================================================================================
'  Nom du fichier : ElementXml.vb
'         Classe  : ElementXml
' Nom de l'auteur : Mathieu Morin 
'            Date : 30/04/19
'=================================================================================================


''' <summary>
''' Représente un élément XML avec son nom,
''' ses attributs XML, le texte qu'il contient et ses sous-attributs. 
''' </summary>
Public Class ElementXml

#Region "Attributs"

    ''' <summary>
    ''' Le nom de l'élément XML. 
    ''' </summary>
    Private _nom As String

    ''' <summary>
    ''' Attributs de l'élément XML. 
    ''' </summary>
    Private _attributs As List(Of String)

    ''' <summary>
    ''' Liste des sous-éléments. 
    ''' </summary>
    Private _elemEnfants As List(Of ElementXml)

    ''' <summary>
    ''' Contenu textuel de l'élément XML(s'il en contient). 
    ''' Sinon, initialisé à Nothing. 
    ''' </summary>
    Private _contenuTextuel As String

    ''' <summary>
    ''' Nombre d'éléments enfants, s'il en contient.  
    ''' </summary>
    Private _nbElementsEnfants As Integer

    ''' <summary>
    ''' Permet d'accéder au nom de l'élément. 
    ''' </summary>
    ''' <remarks>Le nom ne doit pas être vide.</remarks>
    ''' <returns>Le nom de l'élément.</returns>
    Public Property Nom As String
        Get
            Return Me._nom
        End Get
        Set(value As String)
            'Le nom ne peut être Nothing ou vide. 
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Le nom de l'élément ne peut référer à rien.")
            End If

            value = value.Trim()

            If value = "" Then
                Throw New ArgumentException("Le nom de l'élément ne peut être vide.")
            End If

            Me._nom = value
        End Set
    End Property

    ''' <summary>
    ''' Permet d'accéder aux attributs. 
    ''' </summary>
    ''' <returns>La liste des attributs.</returns>
    Public Property Attributs As List(Of String)
        Get
            Return Me._attributs
        End Get
        Set(value As List(Of String))

            'La liste ne peut-être à nothing.  
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Une liste d'attributs ne peut référé à rien")
            End If

            Me._attributs = value
        End Set
    End Property

    ''' <summary>
    ''' Permet d'accéder à la liste des éléments enfants de l'élément présent.  
    ''' </summary>
    ''' <returns></returns>
    Public Property ElemEnfants As List(Of ElementXml)
        Get
            Return _elemEnfants
        End Get
        Set(value As List(Of ElementXml))
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Une liste d'enfant ne peut référer à rien.")
            End If
            Me._elemEnfants = value
        End Set
    End Property

    ''' <summary>
    ''' Le contenu textuel contenu dans l'élément XML. 
    ''' </summary>
    ''' <returns></returns>
    Public Property ContenuTextuel As String
        Get
            Return _contenuTextuel
        End Get
        Set(value As String)
            'Le contenu textuel peut être vide
            If (value IsNot Nothing) Then
                value = value.Trim()
            End If

            Me._contenuTextuel = value
        End Set
    End Property

    ''' <summary>
    ''' Permet d'accéder aux nombre d'éléments enfants. 
    ''' </summary>
    ''' <returns>Le nombre d'éléments enfants de l'élémentXml.</returns>
    Public ReadOnly Property NbElementsEnfants As Integer
        Get
            Return Me._elemEnfants.Count
        End Get
    End Property

#End Region

#Region "Constructeur"

    ''' <summary>
    ''' Constructeur de base.
    ''' Crée un élément XML sans enfant et sans contenu textuel. 
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttribut">La liste des attributs.</param>
    Public Sub New(nom As String, listeAttribut As List(Of String))
        Me.Nom = nom
        Me.Attributs = listeAttribut
    End Sub

    ''' <summary>
    ''' Constructeur par permettant de créer un "ElementXml" contenant 
    ''' un contenu textuel. 
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttributs">Liste des attributs.</param>
    ''' <param name="contenuTextuel">Le contenu textuel.</param>
    Public Sub New(nom As String, listeAttributs As List(Of String), contenuTextuel As String)
        Me.New(nom, listeAttributs)
        Me.ContenuTextuel = contenuTextuel
        Me.ElemEnfants = Nothing
    End Sub

    ''' <summary>
    ''' Constructeur permettant de créer un "ElementXml"
    ''' contenant des éléments enfants.
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttributs">Liste des attributs.</param>
    ''' <param name="listeElemEnfants">Liste des éléments enfants.</param>
    Public Sub New(nom As String, listeAttributs As List(Of String), listeElemEnfants As List(Of ElementXml))
        Me.New(nom, listeAttributs)
        Me.ElemEnfants = listeElemEnfants
        Me.ContenuTextuel = Nothing
    End Sub

#End Region

#Region "Méthodes"
    ''' <summary>
    ''' Retourne un string comprenant le nom, les attributs et le nombre de sous-éléments de 
    ''' l'ÉlémentXml. 
    ''' </summary>
    ''' <returns>Un string au format du nom de l'élément.</returns>
    Public Overrides Function ToString() As String

        'Création du string  des attributs. 
        Dim strAttributs As String = ""
        For Each str As String In Me.Attributs
            strAttributs &= str & " "
        Next
        Return String.Format(" Nom de l'élément : {0}, Attributs : {1}, Nombre de sous-éléments : {2} ", Me.Nom,
                             strAttributs, Me.NbElementsEnfants)
    End Function
#End Region
End Class
