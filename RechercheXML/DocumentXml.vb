'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : DocumentXml
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 30/04/19
'=================================================================================================
Imports System.Xml

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
    Public ReadOnly Property NbElements As Integer
        Get
            '***************** FAIRE DEKOI DE MIEU EVENTUELLEMENT ,MAIS JPENSE QUE LA METHODE PX ETRE UTILSE DONC JAL MODIFIE PAS TT SUITE
            Return ListerEnProfondeurPrefixRec(Racine).Count
        End Get
    End Property

    Public ReadOnly Property NbAttributs As Integer
        Get
           '***************** FAIRE DEKOI DE MIEU EVENTUELLEMENT ,MAIS JPENSE QUE LA METHODE PX ETRE UTILSE DONC JAL MODIFIE PAS TT SUITE
            Dim liste As List(Of Attribut(Of String)) = New List(Of Attribut(Of String))
            Dim resultat As List(Of Attribut(Of String)) = ListerAttributsEnProfondeurRec(Racine, liste)
            Return resultat.Count
        End Get
    End Property

    Public ReadOnly Property Profondeur As Integer
        Get
            Return CompterProfondeur(Racine, 0)
        End Get
    End Property
#End Region

#Region "Constructeur"

    ''' <summary>
    ''' Constructeur de base.
    ''' Il crée un document vide sans racine, ni aucun élément. 
    ''' </summary>
    Public Sub New()
        Me.Racine = Nothing

    End Sub

    ''' <summary>
    ''' Constructeur paramétré. 
    ''' Il crée un document avec un premier élément. 
    ''' </summary>
    ''' <param name="racine"></param>
    Public Sub New(racine As ElementXml)
        Me.Racine = racine
    End Sub
#End Region


#Region "Méthodes"

    ''' <summary>
    ''' Permet de mettre la l'arbre en ordre Prefix dans une liste pour l'affichage.
    ''' </summary>
    ''' <param name="noeudCourant">Le nœud ou démarrer le parcour de l'arbre.</param>
    ''' <returns>retourne une liste d'ElementXml</returns>
#Region "Méthodes publics "
    Private Function ListerEnProfondeurPrefixRec(noeudCourant As ElementXml) As List(Of ElementXml)
        Dim liste As List(Of ElementXml) = New List(Of ElementXml)({noeudCourant})
        If noeudCourant Is Nothing Then
            Return New List(Of ElementXml)
        Else

            For Each fils As ElementXml In noeudCourant.ElemEnfants
                liste.AddRange(ListerEnProfondeurPrefixRec(fils))
            Next
            Return liste
        End If
    End Function

    Private Function ListerAttributsEnProfondeurRec(noeudCourant As ElementXml, ByRef liste As List(Of Attribut(Of String))) As List(Of Attribut(Of String))
        If noeudCourant Is Nothing Then
            Return New List(Of Attribut(Of String))
        Else
            liste.AddRange(noeudCourant.Attributs)

            For Each fils As ElementXml In noeudCourant.ElemEnfants
                ListerAttributsEnProfondeurRec(fils, liste)
            Next
            Return liste
        End If
    End Function

    Private Function CompterProfondeur(noeudCourant As ElementXml, num As Integer) As Integer
        Dim valeurMax = num
        If noeudCourant Is Nothing Then
            Return num
        Else
            For Each fils As ElementXml In noeudCourant.ElemEnfants
                Dim profondeurFils As Integer = CompterProfondeur(fils, num + 1)
                If profondeurFils > valeurMax Then
                    valeurMax = profondeurFils
                End If
            Next
        End If
        Return valeurMax
    End Function
#End Region

#Region "Méthodes privées"

#End Region

#End Region


End Class
