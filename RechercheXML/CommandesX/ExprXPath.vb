'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : ComXPath
' Nom de l'auteur : Mathieu Morin et Mathieu Pelletier
'            Date : 30/04/19
'=================================================================================================


''' <summary>
''' Représente une commande XPath.
''' Elle permet d'encontainer chacune des commandes passées. 
''' </summary>
Public Class ExprXPath


#Region "Constantes"

    ''' <summary>
    ''' Représente le symbole /.
    ''' </summary>
    Private Const symbSlsh As Char = "/"c

    ''' <summary>
    ''' Représente le symbole *
    ''' </summary>
    Private Const symbSlashEtoile As Char = "*"c

    ''' <summary>
    ''' Représente l'expression régulière d'un filtre.
    ''' </summary>
    Public Const RegxFiltre As String = "\[@.+=(\d+|'.+')\]"
#End Region

#Region "Attributs"
    ''' <summary>
    ''' Représente la file de commande de l'expression.
    ''' </summary>
    Private _fileDeCommande As Queue(Of ICommandeX)
#End Region

#Region "Propriétés"
    ''' <summary>
    ''' Accède à la file de commande de l'expression. 
    ''' </summary>
    ''' <returns>Une file de commande.</returns>
    Public Property FileDeCommande As Queue(Of ICommandeX)
        Get
            Return Me._fileDeCommande
        End Get
        Private Set(value As Queue(Of ICommandeX))
            Me._fileDeCommande = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' Permet de créer une expression selon une recherche XPath. 
    ''' </summary>
    ''' <param name="recherche">Une expression XPath.</param>
    ''' <remarks>Une recherche ne peut référer à rien.</remarks>
    Public Sub New(recherche As String)

        If (recherche Is Nothing) Then
            Throw New ArgumentNullException("Une expression ne peut référer à rien.")
        End If

        recherche = recherche.Trim()

        'On parcourt le string : 	        
        Me.FileDeCommande = New Queue(Of ICommandeX)

        'Pour ce faire, la recherche est séparée par le symbole / et divisée en sous recherche. 
        Dim listeStr As List(Of String) = Me.DecomposerExpression(recherche)
        For Each expr In listeStr
            Select Case expr(1)
                Case symbSlsh
                    Me.FileDeCommande.Enqueue(New CommandeXDouble(expr))
                Case symbSlashEtoile
                    Me.FileDeCommande.Enqueue(New CommandeXEtoile(expr))
                Case Else
                    Me.FileDeCommande.Enqueue(New CommandeXSimple(expr))
            End Select
        Next
    End Sub

#Region "Méthodes"
    ''' <summary>
    ''' Interroge un ElementXml selon les informations IComamndeX contenu. 
    ''' </summary>
    ''' <param name="element">Une ElementXml à interroger.</param>
    ''' <returns>Une liste d'éléments Xml. </returns>
    ''' <remarks>Un élément ne peut référer à rien.</remarks>
    Public Function Interroger(element As ElementXml) As List(Of ElementXml)

        If (element Is Nothing) Then
            Throw New ArgumentNullException("Un élément ne peut référer à rien.")
        End If

        If (Me.FileDeCommande.Count = 0) Then
            Return New List(Of ElementXml)
        End If

        'On récupère la première commande
        Dim commandeEnCours As ICommandeX = Me.FileDeCommande.Dequeue()

        'FileResultat permettent de conserver les résultats de chaque recherche à toutes 
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

    ''' <summary>
    ''' Décompose une expression en une liste de string.
    ''' </summary>
    ''' <param "expression">Une expression à décomposer</param>
    ''' <returns>Une liste de string si l'expression est valide, 
    ''' sinon une liste vide.</returns>
    ''' <remarks>Une chaine ne peut référer à rien.</remarks>
    Private Function DecomposerExpression(expression As String) As List(Of String)
        If (expression Is Nothing) Then
            Throw New ArgumentException("Une expression ne peut référer à rien.")
        End If

        Dim i As Integer = 0

        Dim listeRetour As List(Of String) = New List(Of String)

        While (i < expression.Count)
            If (expression(i) <> symbSlsh) Then
                'On effectue une sous expression :
                Dim iEtat As Integer = i
                Dim stringTempo As String = ""
                While (expression(iEtat) <> symbSlsh AndAlso iEtat <> expression.Count - 1)
                    iEtat += 1
                End While
                Dim elementCouper As String
                If iEtat <> expression.Count - 1 Then
                    elementCouper = expression.Remove(iEtat)
                    expression = expression.Substring(iEtat)
                    i = 0
                Else
                    elementCouper = expression
                    i = iEtat
                End If
                Dim estOk As Boolean = True
                Select Case elementCouper(1)
                    Case symbSlsh
                        estOk = RegexMatch(CommandeXDouble.RegxDouble, elementCouper)
                    Case symbSlashEtoile
                        estOk = RegexMatch(CommandeXEtoile.RegxEtoile, elementCouper)
                    Case Else
                        estOk = RegexMatch(CommandeXSimple.RegxSimple, elementCouper)
                End Select
                If (estOk) Then
                    listeRetour.Add(elementCouper)
                Else
                    Return New List(Of String)
                End If
            End If
                i += 1
        End While
        Return listeRetour
    End Function
#End Region

End Class


