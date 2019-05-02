'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : ComXPath
' Nom de l'auteur : Mathieu Morin 
'            Date : 30/04/19
'=================================================================================================


''' <summary>
''' Représente une commande XPath.
''' Elle permet d'encontainer les éléments importants de la commande passé. 
''' </summary>
Public Class ExprXPath


#Region "Constantes"
    Private Const symbSlsh As String = "/"
    Private Const symbSlashEtoile As String = "/*"
    Private Const symDoubleSlash As String = "//"

    Private Const filtre As String = "[@x=y]"
#End Region

#Region "Attributs"
    Private _fileDeCommande As Queue(Of CommandeX)
#End Region

#Region "Propriétés"
    Public Property FileDeCommande As Queue(Of CommandeX)
        Get
            Return Me._fileDeCommande
        End Get
        Set(value As Queue(Of CommandeX))
            Me._fileDeCommande = value
        End Set
    End Property
#End Region

    Public Sub New(recherhe As String)
        'On doit décomposer le string en commandes.
        'Pour ce faire, on récupère un tableau de string où les éléments sont séparés par les symbole.
        'On parcourt le string : 


        'Dim commandeX As CommandeX
        'For i = 0 To recherhe.Count - 1
        '    If (recherhe(i) = symbSlsh) Then
        '        'Dim commandeXd As CommandeXDouble = New CommandeXDouble()
        '        Me.FileDeCommande.Enqueue(commandeXd)
        '    End If
        'Next
    End Sub

#Region "Méthodes"

    ''' <summary>
    ''' Interroge le document XML selon les informations Xpath contenu. 
    ''' </summary>
    ''' <returns></returns>
    Public Function Interroger() As List(Of ElementXml)

        'File permettant de récupérer et d'appliquer les résultat des commandes en ordre. 
        'Dim fileDeResultat As Queue(Of ElementXml) = New Queue(Of ElementXml)

        'La commande en cours. 
        'Dim commandeEnCours As CommandeX

        'Liste permettant de conserver les éléments de la commande en cours.
        'commandeEnCours = Me.FileDeCommande.Dequeue()

        'On effectue la première commande avec le premier élément. 
        'Dim fileTempo As Queue(Of ElementXml) = Me.ListeToFile(Of ElementXml)(commandeEnCours.Rechercher(), fileTempo)
        'Me.FileDeCommande.Enqueue(commandeEnCours)

        'On le fait pour le reste des autres commandes 
        'For i = 1 To Me.FileDeCommande.Count - 1
        '    commandeEnCours = Me.FileDeCommande.Dequeue()
        '    Dim nbElemTempo As Integer = fileTempo.Count
        '    For index = 1 To nbElemTempo
        '        On récupère la liste 
        '        Dim listeElemTrouve As List(Of ElementXml) = commandeEnCours.Rechercher(fileTempo.Dequeue())
        '        On rajoute chacun des éléments à la file
        '        Me.ListeToFile(Of ElementXml)(listeElemTrouve, fileTempo)
        '    Next
        '    Me.FileDeCommande.Enqueue(commandeEnCours)
        'Next
    End Function


    ''' <summary>
    ''' Fonction simple qui transfert les éléments d'une liste à une file existante.  
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="liste">Une liste d'éléments T.</param>
    ''' <param name="file">Une file d'éléments T.</param>
    Private Sub ListeToFile(Of T)(liste As List(Of T), file As Queue(Of T))
        If (liste Is Nothing) Then
            Throw New ArgumentNullException("Une liste ne peut référé à rien.")
        End If

        If (file Is Nothing) Then
            Throw New ArgumentNullException("Une file ne peut référé à rien.")
        End If
        For Each elem As T In liste
            file.Enqueue(elem)
        Next
    End Sub

#End Region

End Class


