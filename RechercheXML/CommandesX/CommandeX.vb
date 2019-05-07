

''' <summary>
''' Classe virtuelle représentant une commande XPath. 
''' </summary>
Public MustInherit Class CommandeX

#Region "Attributs"
    Private ReadOnly _nom As String

    Private _filtre As String
#End Region


#Region "Propriétés"
    Public ReadOnly Property Nom As String
        Get
            Return Me._nom
        End Get

    End Property

    Public Property Filtre As String
    Get
            Return Me._filtre
    End Get
        Set(value As String)
            Me._filtre = value
        End Set
    End Property

#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Permet de creer une CommandeX sans nom d'enfant et sans filtre. 
    ''' </summary>
    Protected Sub New()
        Me._nom = Nothing
    End Sub

    ''' <summary>
    ''' Permet de créer une CommandeX avec un nom d'élément.  
    ''' </summary>
    ''' <param name="nomElement">Un nom d'élément.</param>
    Protected Sub New(nomElement As String)
        'Le nom ne peut être Nothing ou vide. 
        If (nomElement Is Nothing) Then
            Throw New ArgumentNullException("Le nom de l'élément ne peut référer à rien.")
        End If

        nomElement = nomElement.Trim()

        Me._nom = nomElement
    End Sub
#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Effectue une recherhe à partir du nom de l'élément passé en paramètre. 
    ''' </summary>
    ''' <param name="nomElem"></param>
    ''' <returns></returns>
    Public MustOverride Function Rechercher(nomElem As ElementXml) As List(Of ElementXml)

#End Region

End Class
