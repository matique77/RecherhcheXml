'=================================================================================================
'  Nom du fichier : Attribut.vb
'         Classe  : Attribut
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 30/04/19
'=================================================================================================

''' <summary>
''' Classe représentant un attribut d'ElementXml. 
''' </summary>
Public Structure Attribut

#Region "Attributs"

    ''' <summary>
    ''' Le nom de l'attribut.
    ''' </summary>
    Private _nom As String

    ''' <summary>
    ''' La valeur liée à l'attribut. 
    ''' </summary>
    Private _valeur As String

#End Region

#Region "Propriété"
    ''' <summary>
    ''' Accède au nom de l'attribut.
    ''' </summary>
    ''' <returns>Le nom de l'attribut.</returns>
    ''' <remarks>Un nom d'attribut ne peut référer à rien.</remarks>
    Public Property Nom As String
        Get
            Return Me._nom
        End Get
        Set(value As String)
            'Le nom d'un attribut ne peut être vide ou référé à Nothing.
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Le nom de l'attribut ne peut référer à rien.")
            End If

            value = value.Trim()

            If value = "" Then
                Throw New ArgumentException("Le nom de l'attribut ne peut être vide.")
            End If

            Me._nom = value
        End Set
    End Property

    ''' <summary>
    ''' Accède à la valeur de l'attribut.
    ''' </summary>
    ''' <returns>La valeur de l'attribut.</returns>
    ''' <remarks>La valeur de l'attribut ne peut référer à rien.</remarks>
    Public Property Valeur As String
        Get
            Return Me._valeur
        End Get
        Set(value As String)
            'La valeur de l'attribut ne peut référer à rien. 
            If (value Is Nothing) Then
                Throw New ArgumentNullException("La valeur de l'attribut ne peut référé à rien.")
            End If
            Me._valeur = value
        End Set
    End Property

#End Region

#Region "Constructeur"
    ''' <summary>
    ''' Constructeur paramétré. 
    ''' Il crée un attribut avec un nom et une valeur passée en paramètre. 
    ''' </summary>
    ''' <param name="nom">Le nom de l'attribut.</param>
    ''' <param name="valeur">La valeur de l'attribut.</param>
    Public Sub New(nom As String, valeur As String)
        Me.Nom = nom
        Me.Valeur = valeur
    End Sub
#End Region

#Region "Méthodes"
    ''' <summary>
    ''' Génère une chaîne de caractère représentant un attribut. 
    ''' </summary>
    ''' <returns>Une chaine de caractère représentant l'attribut.</returns>
    Public Overrides Function ToString() As String
        Return String.Format("{0}=""{1}""", Me.Nom, Me.Valeur)
    End Function

#End Region
End Structure
