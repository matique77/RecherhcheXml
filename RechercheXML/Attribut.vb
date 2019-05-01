''' <summary>
''' Classe générique représentant un attribut d'un ElementXml. 
''' </summary>
Public Structure Attribut(Of T)

#Region "Attributs"

    ''' <summary>
    ''' Le nom de l'attribut.
    ''' </summary>
    Private _nom As String

    ''' <summary>
    ''' La valeur liée à l'attribut. 
    ''' </summary>
    Private _valeur As T

#End Region

#Region "Propriété"
    ''' <summary>
    ''' Accède au nom de l'attribut.
    ''' </summary>
    ''' <returns>Le nom de l'attribut.</returns>
    Public Property Nom As String
        Get
            Return Me._nom
        End Get
        Set(value As String)
            'Le nom d'un attribut ne peut être vide ou référé à Nothing. 
            'Le nom ne peut être Nothing ou vide. 
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Le nom de l'attribut ne peut référer à rien.")
            End If

            value = value.Trim()

            If value = "" Then
                Throw New ArgumentException("Le nom de l'attribut ne peut être vide.")
            End If
        End Set
    End Property

    ''' <summary>
    ''' Accède à la valeur de l'attribut.
    ''' </summary>
    ''' <returns>La valeur de l'attribut.</returns>
    Public Property Valeur As T
        Get
            Return Me._valeur
        End Get
        Set(value As T)
            Me._valeur = value
        End Set
    End Property

#End Region

#Region "Constructeur"

    Public Sub New(nom As String, valeur As T)
        Me.Nom = nom
        Me.Valeur = valeur
    End Sub

#End Region
End Structure
