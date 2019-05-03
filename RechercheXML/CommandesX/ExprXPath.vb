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
    Private Const Etoile As Char = "*"c
    Private Const filtre As Char = "["c

    Private Const filtre2 As String = "[@x=y]"
#End Region

#Region "Attributs"
    Private _fileDeCommande As Queue(Of CommandeX)

#End Region

#Region "Propriétés"


    Public Property FileString As Queue(Of String)

#End Region

    Public Sub New(recherche As String)
        'On doit décomposer le string en commandes.
        'Pour ce faire, on récupère un tableau de string où les éléments sont séparés par les symbole.
        'On parcourt le string : 
        Me._fileString = New Queue(Of String)
        Dim fileString = New Queue(Of String)
        Dim tabChar() As Char = recherche.ToCharArray
        Dim unstring As String = ""
        Dim i As Integer = 0
        While i < tabChar.Length
            Select Case tabChar(i)
                'Si c'est un symbole special on regarde si qu'il y a apres sinon ont ajoute le char au string a empiller.
                Case symbSlsh
                    If unstring IsNot "" Then
                        Me.FileString.Enqueue(unstring)
                        unstring = ""
                        unstring = unstring.Insert(unstring.Length, tabChar(i))
                    End If
                    If i <> tabChar.Length - 1 Then
                        'Si ce n'est pas la fin
                        Select Case tabChar(i + 1)
                            'Ont regarde si le symbole suivant est une barre oblique sinon ont ajoute le string a empiller a la pile.
                            Case symbSlsh
                                unstring = unstring.Insert(unstring.Length, tabChar(i))
                                i += 1
                        End Select
                        If i = 0 Then
                            unstring = unstring.Insert(unstring.Length, tabChar(i))
                        End If
                    End If
                Case Else
                    unstring = unstring.Insert(unstring.Length, tabChar(i))
            End Select
            i += 1
        End While
        Me.FileString.Enqueue(unstring)

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


