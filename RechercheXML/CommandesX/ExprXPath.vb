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

    Public Const RegxFiltre As String = ".+=("".+ ""|\d)"
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
        'On va juste creer une nouvelle expressionSimple.

    End Sub

#Region "Méthodes"

    ''' <summary>
    ''' Interroge le document XML selon les informations Xpath contenu. 
    ''' </summary>
    ''' <returns></returns>
    Public Function Interroger(element As ElementXml) As List(Of ElementXml)

        'On récupère la première commande
        Dim commandeEnCours As CommandeX = Me.FileDeCommande.Dequeue()

        'FileResultat permettant de conserver les résultats de chaque recherche à toutes 
        'les itérations. 
        'On effectue la première commande sur l'élément.
        Dim fileTempo As Queue(Of ElementXml) = commandeEnCours.Rechercher(element)
        Me.FileDeCommande.Enqueue(commandeEnCours)

        'On effectue le reste des commandes : 
        For i = 1 To Me.FileDeCommande.Count - 1
            commandeEnCours = Me.FileDeCommande.Dequeue()
            Dim nbResulat = fileTempo.Count
            For iFile = 1 To nbResulat
                Dim fileAjouter As Queue(Of ElementXml) = commandeEnCours.Rechercher(fileTempo.Dequeue())
                While fileAjouter.Count <> 0
                    fileTempo.Enqueue(fileAjouter.Dequeue)
                End While
            Next
            Me.FileDeCommande.Enqueue(commandeEnCours)
        Next

        Dim listeRetour As List(Of ElementXml)

        'On convertit la file en liste 
        While fileTempo.Count <> 0
            listeRetour.Add(fileTempo.Dequeue())
        End While

        'On retourne la liste
        Return listeRetour
    End Function


#End Region

End Class


