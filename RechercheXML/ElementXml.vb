Imports RechercheXML
'=================================================================================================
'  Nom du fichier : ElementXml.vb
'         Classe  : ElementXml
' Nom de l'auteur : Mathieu Morin 
'            Date : 30/04/19
'=================================================================================================


''' <summary>
''' Représente un élément Xml avec son nom,
''' ses attributs, le texte qu'il contient ou ses sous-éléments. 
''' </summary>
Public Class ElementXml

#Region "Attributs"

    ''' <summary>
    ''' Représente le nom de l'élément.
    ''' </summary>
    Private _nom As String

    ''' <summary>
    ''' Représente les attributs de l'élément Xml. 
    ''' </summary>
    Private _attributs As List(Of Attribut)

    ''' <summary>
    ''' Représente la liste des sous-éléments, s'il en contient.
    ''' </summary>
    Private _elemEnfants As List(Of ElementXml)

    ''' <summary>
    ''' Représente le contenu textuel de l'élément Xml, s'il en contient. 
    ''' Sinon, initialisé à Nothing. 
    ''' </summary>
    Private _contenuTextuel As String

#End Region


#Region "Propriétés"



    ''' <summary>
    ''' Permet d'accéder au nom de l'élément. 
    ''' </summary>
    ''' <returns>Le nom de l'élément.</returns>
    ''' <remarks>Le nom ne peut être vide ou référer à rien.</remarks>
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
    '''<remarks>Une liste d'attributs ne peut référer à rien.</remarks>
    Public Property Attributs As List(Of Attribut)
        Get
            Return Me._attributs
        End Get
        Private Set(value As List(Of Attribut))

            'La liste ne peut-être initialisé à nothing.  
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Une liste d'attributs ne peut référé à rien.")
            End If

            Me._attributs = value
        End Set
    End Property

    ''' <summary>
    ''' Permet d'accéder à la liste des éléments enfants de l'élément.  
    ''' </summary>
    ''' <returns>La liste des éléments enfants.</returns>
    '''<remarks>Une liste d'éléements enfants ne peut référer à rien.</remarks>
    Public Property ElemEnfants As List(Of ElementXml)
        Get
            Return _elemEnfants
        End Get
        Private Set(value As List(Of ElementXml))
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Une liste d'enfant ne peut référer à rien.")
            End If
            Me._elemEnfants = value
        End Set
    End Property

    ''' <summary>
    ''' Le contenu textuel contenu dans l'ElementXml.. 
    ''' </summary>
    ''' <returns>Le contenu textuel, s'il en a.
    ''' Sinon, retourne Rien.</returns>
    ''' <remarks>Le contenu textuel ne peut être vide.</remarks>
    Public Property ContenuTextuel As String
        Get
            Return _contenuTextuel
        End Get
        Private Set(value As String)
            'Le contenu textuel peut être vide
            If (value IsNot Nothing) Then
                value = value.Trim()
            End If
            Me._contenuTextuel = value
        End Set
    End Property

    ''' <summary>
    ''' Permet d'accéder au nombre d'éléments enfants. 
    ''' </summary>
    ''' <returns>Le nombre d'éléments enfants de l'ElementXml.</returns>
    Public ReadOnly Property NbElementsEnfants As Integer
        Get
            Return Me._elemEnfants.Count
        End Get
    End Property



#End Region


#Region "Constructeur"
    ''' <summary>
    ''' Constructeur paramétré privé.
    ''' Crée un ElementXml sans enfant et sans contenu textuel. 
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttributs">La liste des attributs.</param>
    Private Sub New(nom As String, listeAttributs As List(Of Attribut))
        Me.Nom = nom
        Me.Attributs = listeAttributs
        Me.ContenuTextuel = Nothing
        Me.ElemEnfants = New List(Of ElementXml)
    End Sub

    ''' <summary>
    ''' Constructeur paramétré permettant de créer un ElementXml possédant
    ''' un contenu textuel. 
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttributs">La liste des attributs.</param>
    ''' <param name="contenuTextuel">Le contenu textuel.</param>
    Public Sub New(nom As String, listeAttributs As List(Of Attribut), contenuTextuel As String)
        Me.New(nom, listeAttributs)
        Me.ContenuTextuel = contenuTextuel
        Me.ElemEnfants = New List(Of ElementXml)
    End Sub

    ''' <summary>
    ''' Constructeur permettant de créer un "ElementXml"
    ''' possédant des éléments enfants.
    ''' </summary>
    ''' <param name="nom">Le nom de l'élément.</param>
    ''' <param name="listeAttributs">Liste des attributs.</param>
    ''' <param name="listeElemEnfants">Liste des éléments enfants.</param>
    Public Sub New(nom As String, listeAttributs As List(Of Attribut), listeElemEnfants As List(Of ElementXml))
        Me.New(nom, listeAttributs)
        Me.ElemEnfants = listeElemEnfants
        Me.ContenuTextuel = Nothing
    End Sub

#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Génère une représentation de la balise sous forme de chaine de caractère. 
    ''' </summary>
    ''' <param name="estFermante">Indique si la balise est une balise d'ouverture ou de fermeture.</param>
    ''' <returns>
    ''' Une chaine de caractère représentant une balise ouvrante ou fermante. 
    ''' </returns>
    Public Function EnBalise(Optional estFermante As Boolean = False) As String
        If (Not estFermante) Then
            Dim strAtt As String = ""
            Dim nbElemEnfants = Me.Attributs.Count
            For iAtt = 0 To nbElemEnfants - 1
                strAtt &= Me.Attributs(iAtt).ToString()
                If (iAtt <> nbElemEnfants - 1) Then
                    strAtt &= " "
                End If
            Next
            Return String.Format("<{0} {1}>", Me.Nom, strAtt)
        Else
            Return String.Format("</{0}>", Me.Nom)
        End If
    End Function

    ''' <summary>
    ''' Retourne un string comprenant le nom, les attributs et le nombre de sous-éléments de 
    ''' l'ElementXml. 
    ''' </summary>
    ''' <returns>Un string au format du nom de l'élément.</returns>
    Public Overrides Function ToString() As String

        'Création du string  des attributs. 
        Dim strAttributs As String = ""
        For Each atr As Attribut In Me.Attributs
            strAttributs &= atr.ToString() & ", "
        Next

        Return String.Format(" Nom de l'élément : {0}, Attributs : {1} {3}", Me.Nom,
                             If(strAttributs = "", "Aucun,", strAttributs), Me.NbElementsEnfants,
                             If(Me.ContenuTextuel Is Nothing, "Nb sous-éléments : " &
                             Me.NbElementsEnfants, "Contenu textuel : " & Me.ContenuTextuel))
    End Function

#End Region

End Class
