'=================================================================================================
'  Nom du fichier : Principal.vb
'         Module  : Principale
' Nom de l'auteur : Mathieu Pelletier et Mathieu Morin
'            Date : 01/04/19
'=================================================================================================

Imports System.IO

''' <summary>
''' Module Contenant le programme principal du projet. 
''' </summary>
Module Principal
    ''' <summary>
    ''' Méthode principal permettant de charger un document Xml, de l'afficher, d'afficher les statistiques
    ''' du fichier, de l'interroger avec une commande XPath et d'éxécuter une série de test. 
    ''' </summary>
    Sub Main()
        'Document chargé en mémoire. 
        Dim monDoc As DocumentXml
        'Le nom du fichier chargé. 
        Dim nomFichier As String = ""
        'Le choix du menu initialisé à "". 
        Dim entrer As String = ""
        Do
            Console.Clear()
            Console.Write("Veuillez choisir une des options suivante : " & vbCrLf & vbCrLf &
                          " 1 - Charger un document XML" & vbCrLf &
                          " 2 - Afficher un document XML" & vbCrLf &
                          " 3 - Afficher statistique" & vbCrLf &
                          " 4 - Interroger" & vbCrLf &
                          " 5 - Exécuter" & vbCrLf &
                          " 6 - Quitter" & vbCrLf)
            Console.WriteLine()
            Console.Write("Choix : ")
            entrer = Console.ReadLine()
            Console.Clear()
            Select Case entrer
                Case "1"
                    Console.WriteLine("Veuillez entrer le chemin/le nom du fichier à charger : ")
                    nomFichier = Console.ReadLine()
                    If File.Exists(nomFichier) Then
                        monDoc = ChargerFichierXml(nomFichier)
                        Console.WriteLine(vbCrLf & "Fichier chargé!")
                    Else
                        Console.WriteLine("Le chemin ou le nom du fichier est invalide.")
                    End If
                Case "2"
                    If (monDoc IsNot Nothing) Then
                        Console.WriteLine(monDoc.ToString())
                    Else
                        Console.WriteLine("Aucun fichier n'est chargé présentement")
                    End If
                Case "3"
                    If (monDoc IsNot Nothing) Then
                        Console.WriteLine(monDoc.ObtenirStats())
                    Else
                        Console.WriteLine("Aucun fichier n'est chargé présentement")
                    End If
                Case "4"
                    If (monDoc IsNot Nothing) Then
                        Console.Write("Entrez expression XPath : ")
                        Dim expr As ExprXPath = New ExprXPath(Console.ReadLine())
                        Dim listeRecherche As List(Of ElementXml) = expr.Interroger(monDoc.Racine)
                        For Each elem As ElementXml In listeRecherche
                            Console.WriteLine(elem.ToString())
                        Next
                    Else
                        Console.WriteLine("Aucun fichier n'est chargé présentement")
                    End If
                Case "5"
                    Executer()
                Case "6"
                    'Ne rien faire
                Case Else
                    Console.WriteLine("Choix invalide.")
            End Select
            Console.Write("Appuyer sur entrée pour continuer...")
            Console.ReadLine()
        Loop While entrer <> "6"
    End Sub

    ''' <summary>
    ''' Exécute une série de tests de commandes XPath. 
    ''' </summary>
    Public Sub Executer()

        Dim cheminCaliforniations As String = "exemples-californication-rhcp.xml"
        Dim cheminRecette As String = "exemples-recettes.xml"

        'Commandes séparées d'un espace permettant facilement d'en ajouter.
        Dim choixRecettes As String = "/livre-recettes/recettes/recette /livre-recettes/recettes/recette/nom" &
        " /livre-recettes/* /livre-recettes/recettes/recette/ingredients/* //ingredient /livre-recettes/recettes//ingredient " &
        "/livre-recettes/recettes/recette[@cat='entrée'] " & "/livre-recettes/recettes/recette/ingredients/ingredient[@unite='gramme']"

        Dim choixCalifornication As String = "/cd/liste-pieces/piece[@no-sequence=6] /cd/* /cd//titre" &
            " /cd/liste-pieces//minutes"

        'Le doc à tester
        Dim docTester As DocumentXml

        'Accumulateur initialisé à 0. 
        Dim choix As Integer = 0

        'Affichage des choix
        Console.WriteLine("1-Exemples-Californications" & vbCrLf &
                      "2-Exemples-Recettes")
        Console.WriteLine()
        Console.Write("Choix du document : ")
        While (Not Integer.TryParse(Console.ReadLine(), choix) AndAlso choix < 1 OrElse choix > 2)
            Console.Write("Entrez un choix valide!")
        End While
        Console.WriteLine()
        Dim tabChoix() As String
        Select Case choix
            Case 1
                docTester = ChargerFichierXml(cheminCaliforniations)
                tabChoix = choixCalifornication.Split(" "c)
            Case 2
                docTester = ChargerFichierXml(cheminRecette)
                tabChoix = choixRecettes.Split(" "c)
        End Select

        'Création et affichage des choix 
        Do
            Dim i As Integer = 0
            For i = 0 To tabChoix.Length - 1
                Console.WriteLine(i + 1 & "-" & tabChoix(i))
            Next
            Console.WriteLine(i + 1 & "-" & "Quitter")
            choix = 0
            Do
                If choix <> 0 Then
                    Console.WriteLine("Entrez un choix valide!")
                End If
                Console.WriteLine()
                Console.Write("Choix : ")
            Loop While (Not Integer.TryParse(Console.ReadLine(), choix) AndAlso choix < 1 OrElse choix > i + 1)
            If (choix <> tabChoix.Length + 1) Then
                Dim expr As ExprXPath = New ExprXPath(tabChoix(choix - 1))
                Dim listeRecherche As List(Of ElementXml) = expr.Interroger(docTester.Racine)
                For Each elem As ElementXml In listeRecherche
                    Console.WriteLine(elem.ToString())
                Next
                Console.ReadLine()
            End If
            Console.Clear()
        Loop While choix <> tabChoix.Length + 1
    End Sub
End Module

