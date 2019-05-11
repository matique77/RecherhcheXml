'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : DocumentXml
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 30/04/19
'=================================================================================================

''' <summary>
''' Représente un document Xml sérialisé
''' composé de sous-éléments de type "ElementXml".
''' </summary>
Public Class DocumentXml

#Region "Constantes"
    ''' <summary>
    ''' Le nom donné à la MetaRacine. 
    ''' </summary>
    Private Const nomMetaRacine As String = "DocumentXml"

    ''' <summary>
    ''' L'écart lors de l'affichage des balises. 
    ''' </summary>
    Private Const ecartBalise As String = "  "

#End Region


#Region "Attributs"
    ''' <summary>
    ''' Représente le premier élément Xml du fichier.
    ''' </summary>
    Private _racine As ElementXml
#End Region


#Region "Propriétés"
    ''' <summary>
    ''' Accède à la racine du document XML. 
    ''' </summary>
    ''' <returns>La racine du document XML.</returns>
    ''' <remarks>La racine ne peut référer à rien.</remarks>
    Public Property Racine As ElementXml
        Get
            Return Me._racine
        End Get
        Private Set(value As ElementXml)
            'On valide que l'élément ne soit pas Nothing : 
            If (value Is Nothing) Then
                Throw New ArgumentNullException("Un élément ne peut être initialisé à Rien")
            End If
            Me._racine = value
        End Set
    End Property


    ''' <summary>
    ''' Accède aux nombre d'éléments contenu dans le fichier.
    ''' </summary>
    ''' <returns>Le nombre d'éléments contenu dans le fichier.</returns>
    Public ReadOnly Property NbElements As Integer
        Get
            Return ListerEnProfondeurPrefixRec(Me.Racine).Count
        End Get
    End Property


    ''' <summary>
    ''' Accède aux nombres d'attributs contenu dans le ficier.
    ''' </summary>
    ''' <returns>Le nombre d'attributs dans le fichier.</returns>
    Public ReadOnly Property NbAttributs As Integer
        Get
            Return ListerAttributsEnProfondeurRec(Me.Racine).Count
        End Get
    End Property

    ''' <summary>
    ''' Retourne la profondeur du fichier. 
    ''' </summary>
    ''' <returns>La profondeur du fichier.</returns>
    Public ReadOnly Property Profondeur As Integer
        Get
            Return CompterProfondeur(Me.Racine)
        End Get
    End Property
#End Region


#Region "Constructeur"
    ''' <summary>
    ''' Constructeur paramétré. 
    ''' Il crée un document avec un premier élément. 
    ''' </summary>
    Public Sub New(racine As ElementXml)
        Me.Racine = New ElementXml(DocumentXml.nomMetaRacine, New List(Of Attribut), "")
        Me.Racine.ElemEnfants.Add(racine)
    End Sub
#End Region


#Region "Méthodes"

#Region "Méthodes privées"
    ''' <summary>
    ''' Permet de  lister en profondeur préfixe les éléments d'un document. 
    ''' </summary>
    ''' <param name="elemCourant">L'élément où démarer la recherhce.</param>
    ''' <returns>Une liste d'ElementXml. </returns>
    ''' <remarks>Un élément ne peut référer à rien.</remarks>
    Private Function ListerEnProfondeurPrefixRec(elemCourant As ElementXml) As List(Of ElementXml)
        Dim liste As List(Of ElementXml) = New List(Of ElementXml)({elemCourant})
        If elemCourant Is Nothing Then
            Return New List(Of ElementXml)
        Else
            For Each fils As ElementXml In elemCourant.ElemEnfants
                liste.AddRange(ListerEnProfondeurPrefixRec(fils))
            Next
            Return liste
        End If
    End Function

    ''' <summary>
    ''' Permet de lister les attributs et attributs enfants en profondeur.
    ''' </summary>
    ''' <param name="elemCourant">L'ElementXml courant.</param>
    ''' <returns>Une liste de tous les attributs</returns>
    ''' <remarks>Un élément ne peut référer à rien.</remarks>
    Private Function ListerAttributsEnProfondeurRec(elemCourant As ElementXml) As List(Of Attribut)
        If elemCourant Is Nothing Then
            Return New List(Of Attribut)
        Else
            Dim listeRetour As List(Of Attribut) = New List(Of Attribut)
            listeRetour.AddRange(elemCourant.Attributs)

            For Each fils As ElementXml In elemCourant.ElemEnfants
                listeRetour.AddRange(ListerAttributsEnProfondeurRec(fils))
            Next
            Return listeRetour
        End If
    End Function


    ''' <summary>
    ''' Génère un string représentant un DocumentXml par le biais d'une recherche récurssive. 
    ''' </summary>
    ''' <param name="elemCourant">L'élément courant traité. </param>
    ''' <param name="nbDecalage">Le nombre de décalages à effectuer lors de l'affichage. </param>
    ''' <returns></returns>
    Private Function ListerEnStrRec(elemCourant As ElementXml, nbDecalage As Integer) As String

        'Si enfant contient du texte : 
        If (elemCourant.ContenuTextuel IsNot Nothing) Then
            'On ajoute comme contenu textuel 
            Return StrDup(nbDecalage, DocumentXml.ecartBalise) & elemCourant.EnBalise() & DocumentXml.ecartBalise & elemCourant.ContenuTextuel & " " _
                        & elemCourant.EnBalise(True) & vbCrLf
        Else
            'On liste ses enfants : 
            Dim strBalise As String = StrDup(nbDecalage, DocumentXml.ecartBalise) & elemCourant.EnBalise() & vbCrLf
            nbDecalage += 1
            'On parcourt les enfants si il y en a. 
            For Each sousElem As ElementXml In elemCourant.ElemEnfants
                strBalise &= ListerEnStrRec(sousElem, nbDecalage)
            Next
            nbDecalage -= 1

            'On ajoute la balise de fermeture 
            strBalise &= StrDup(nbDecalage, DocumentXml.ecartBalise) & elemCourant.EnBalise(True) & vbCrLf
            Return strBalise
        End If
    End Function

    ''' <summary>
    ''' Permet de compter la profondeur du DocumentXml courrant. 
    ''' </summary>
    ''' <param name="elemCourant">Un ElementXml</param>
    ''' <returns>La profondeur du DocumentXml.</returns>
    Private Function CompterProfondeur(elemCourant As ElementXml) As Integer
        Dim valeurMax = 0

        'Si l'élément courant est vide :
        If elemCourant Is Nothing Then
            Return valeurMax
        Else
            For Each fils As ElementXml In elemCourant.ElemEnfants
                Dim profondeurFils As Integer = 1 + CompterProfondeur(fils)
                If (profondeurFils > valeurMax) Then
                    valeurMax = profondeurFils
                End If
            Next
            Return valeurMax
        End If
        Return valeurMax
    End Function


#End Region

#Region "Méthodes publiques"
    ''' <summary>
    ''' Génère une chaine de caractère contenant les statistiques du DocumentXml. 
    ''' </summary>
    ''' <returns>Une chaine de caractère représentant les statistiques du document.</returns>
    Public Function ObtenirStats() As String
        Return String.Format("Le nom de la racine est : {0}" & vbCrLf &
                             "Le nombre d'élément du document est : {1}" & vbCrLf &
                             "Le nombre d'attributs est : {2}" & vbCrLf &
                             "La profondeur du document est : {3}", Me.Racine.ElemEnfants(0).Nom,
                                                                    Me.NbElements - 1,
                                                                    Me.NbAttributs,
                                                                    Me.Profondeur)
    End Function


    ''' <summary>
    ''' Génère un chaine de caractère du DocumentXml et de ses éléments sous une forme lisible. 
    ''' </summary>
    ''' <returns>Une chaine de caractère rerpésentant chacun des ÉlémentsXml du document.</returns>
    Public Overrides Function ToString() As String
        Return Me.ListerEnStrRec(Me.Racine.ElemEnfants(0), 0)
    End Function

#End Region

#End Region


End Class
