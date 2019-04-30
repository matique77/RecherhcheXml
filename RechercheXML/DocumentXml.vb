'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : DocumentXml
' Nom de l'auteur : Mathieu Morin 
'            Date : 30/04/19
'=================================================================================================


''' <summary>
''' Représente un document xml sérialisé
''' composé de sous-éléments de type "ElementXml".
''' </summary>
Public Class DocumentXml

#Region "Attributs"

    ''' <summary>
    ''' Représente le premier élément Xml du fichier. 
    ''' </summary>
    Private _racine As ElementXml

    ''' <summary>
    ''' Le nombre d'élément contenu dans le fichier. 
    ''' </summary>
    Private _nbElements As Integer
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Accède à la racine du document XML. 
    ''' </summary>
    ''' <returns>La racine du document XML.</returns>
    Public Property Racine As ElementXml
        Get
            Return Me._racine
        End Get
        Private Set(value As ElementXml)
            Me._racine = value
        End Set
    End Property


    ''' <summary>
    ''' Accède aux nombre d'éléments cotenu dans le fichier
    ''' </summary>
    ''' <returns>Le nombre d'éléments contenu dans le fichier.</returns>
    Public Property NbElements As Integer
        Get
            Return Me._nbElements
        End Get
        Private Set(value As Integer)
            'Le nombre d'éléments doit être supérieur ou égal à 0. 
            If (value < 0) Then
                Throw New ArgumentOutOfRangeException("Le nombre d'élément doit être positif ou égal à 0.")
            End If

            Me._nbElements = value
        End Set
    End Property
#End Region

#Region "Constructeur"

    ''' <summary>
    ''' Constructeur de base.
    ''' Il crée un document vide sans racine, ni aucun élément. 
    ''' </summary>
    Public Sub New()
        Me.Racine = Nothing
        Me.NbElements = 0
    End Sub

    ''' <summary>
    ''' Constructeur paramétré. 
    ''' Il crée un document avec un premier élément. 
    ''' </summary>
    ''' <param name="racine"></param>
    Public Sub New(racine As ElementXml)
        Me.Racine = racine
        Me.NbElements = 1
    End Sub
#End Region


#Region "Méthodes"

#Region "Méthodes publics "

#End Region

#Region "Méthodes privées"

#End Region

#End Region


End Class
