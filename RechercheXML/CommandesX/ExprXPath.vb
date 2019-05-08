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
    Private Const symbSlsh As Char = "/"c
    Private Const symbSlashEtoile As Char = "*"c
    Private Const symDoubleSlash As String = "//"

    Private Const filtre As String = "[@x=y]"

    Public Const RegxFiltre As String = "\[@.+=(\d+|'.+')\]"
#End Region

#Region "Attributs"
    Private _fileDeCommande As Queue(Of ICommandeX)
#End Region

#Region "Propriétés"
    Public Property FileDeCommande As Queue(Of ICommandeX)
        Get
            Return Me._fileDeCommande
        End Get
        Set(value As Queue(Of ICommandeX))
            Me._fileDeCommande = value
        End Set
    End Property
#End Region

    Public Sub New(recherhe As String)

        'On doit décomposer le string en commandes.	        'On doit décomposer le string en commandes.
        'Pour ce faire, on récupère un tableau de string où les éléments sont séparés par les symbole.	        'Pour ce faire, on récupère un tableau de string où les éléments sont séparés par les symbole.
        'On parcourt le string : 	        
        Me.FileDeCommande = New Queue(Of ICommandeX)
        Dim i As Integer = 0
        While (i < recherhe.Count)
            If (recherhe(i) <> symbSlsh) Then
                'On démarre une sous recherche 
                Dim iEtat As Integer = i
                Dim stringTempo As String = ""
                While (recherhe(iEtat) <> symbSlsh AndAlso iEtat <> recherhe.Count - 1)
                    iEtat += 1
                End While
                Dim elementCouper As String
                If iEtat <> recherhe.Count - 1 Then
                    elementCouper = recherhe.Remove(iEtat)
                    recherhe = recherhe.Substring(iEtat)
                    i = 0
                Else
                    elementCouper = recherhe
                    i = iEtat
                End If
                Select Case elementCouper(1)
                    Case symbSlsh
                        Me.FileDeCommande.Enqueue(New CommandeXDouble(elementCouper))
                    Case symbSlashEtoile
                        Me.FileDeCommande.Enqueue(New CommandeXEtoile(elementCouper))
                    Case Else
                        Me.FileDeCommande.Enqueue(New CommandeXSimple(elementCouper))
                End Select
            End If
            i += 1
        End While

    End Sub

#Region "Méthodes"

    ''' <summary>
    ''' Interroge le document XML selon les informations Xpath contenu. 
    ''' </summary>
    ''' <returns></returns>
    Public Function Interroger(element As ElementXml) As List(Of ElementXml)
        If (Me.FileDeCommande.Count = 0) Then
            Return New List(Of ElementXml)
        End If
        'On récupère la première commande
        Dim commandeEnCours As ICommandeX = Me.FileDeCommande.Dequeue()

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

        Dim listeRetour As List(Of ElementXml) = New List(Of ElementXml)

        'On convertit la file en liste 
        While fileTempo.Count <> 0
            listeRetour.Add(fileTempo.Dequeue())
        End While

        'On retourne la liste
        Return listeRetour
    End Function


#End Region

End Class


