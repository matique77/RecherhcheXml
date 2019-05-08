'=================================================================================================
'  Nom du fichier : Principal.vb
'         Module  : Principale
' Nom de l'auteur : Mathieu Pelletier
'            Date : 01/04/19
'=================================================================================================

Imports System.IO

Module Principal
    Sub Main()
        Dim monDoc As DocumentXml = Nothing
        Dim nomFichier As String = Nothing
        Dim entrer As String = Nothing
        Do
            Console.Clear()
            Console.WriteLine("Veuillez choisir une des options suivante : ")
            Console.WriteLine(" 1 - Charger un document XML")
            Console.WriteLine(" 2 - Afficher un document XML")
            Console.WriteLine(" 3 - Afficher statistique")
            Console.WriteLine(" 4 - Interroger")
            Console.WriteLine(" 5 - Exécuter")
            Console.WriteLine(" 6 - Quitter")
            entrer = Console.ReadLine()
            Select Case entrer
                Case "1"
                    Console.Clear()
                    Console.WriteLine("Veuillez entrer le nom du fichier")
                    nomFichier = Console.ReadLine()
                    If File.Exists(nomFichier) Then
                        monDoc = ChargerFichierXml(nomFichier)
                    End If
                Case "2"
                    Console.Clear()
                    Console.WriteLine(monDoc.ToString())
                    Console.ReadLine()
                Case "3"
                    Console.Clear()
                    Console.WriteLine(monDoc.ObtenirStats())
                    Console.ReadLine()
                Case "4"
                    Console.Write("Entrez expression XPath : ")
                    Dim expr As ExprXPath = New ExprXPath(Console.ReadLine())
                    Dim listeRecherche As List(Of ElementXml) = expr.Interroger(monDoc.Racine)
                    For Each elem As ElementXml In listeRecherche
                        Console.WriteLine(elem.ToString())
                    Next
                    Console.ReadLine()
                Case "5"
                    Dim uneCommandeXml As String = Nothing
                    Dim fichierValide As Boolean = True
                    Console.Clear()
                    Console.WriteLine("                                       Veuillez entrer l'indice désiré.")
                    Select Case nomFichier
                        Case "exemples-recettes.xml"
                            Console.WriteLine("1 : /livre-recettes/recettes/recette")
                            Console.WriteLine("2 : /livre-recettes/recettes/recette/nom")
                            Console.WriteLine("3 : /livre-recettes/*")
                            Console.WriteLine("4 : /livre-recettes/recettes/recette/ingredients/*")
                            Console.WriteLine("5 : //ingredient")
                            Console.WriteLine("6 : /livre-recettes/recettes//ingredient")
                            Console.WriteLine("7 : /livre-recettes/recettes/recette[@cat='entrée']")
                            Console.WriteLine("8 : /livre-recettes/recettes/recette/ingredients/ingredient[@unite='gramme']")
                            Dim entrerXml As String = Console.ReadLine()
                            Select Case entrerXml
                                Case "1"
                                    uneCommandeXml = "/livre-recettes/recettes/recette"
                                Case "2"
                                    uneCommandeXml = "/livre-recettes/recettes/recette/nom"
                                Case "3"
                                    uneCommandeXml = "/livre-recettes/*"
                                Case "4"
                                    uneCommandeXml = "/livre-recettes/recettes/recette/ingredients/*"
                                Case "5"
                                    uneCommandeXml = "//ingredient"
                                Case "6"
                                    uneCommandeXml = "/livre-recettes/recettes//ingredient"
                                Case "7"
                                    uneCommandeXml = "/livre-recettes/recettes/recette[@cat='entrée']"
                                Case "8"
                                    uneCommandeXml = "/livre-recettes/recettes/recette/ingredients/ingredient[@unite='gramme']"
                            End Select
                        Case "exemples-californication-rhcp.xml"
                            Console.Clear()
                            Console.WriteLine("1 : /cd/liste-pieces/piece[@no-sequence=6]")
                            Console.WriteLine("2 : /cd/*")
                            Console.WriteLine("3 : /cd//titre")
                            Console.WriteLine("4 : /cd/liste-pieces//minutes")
                            Dim entrerXml As String = Console.ReadLine()
                            Console.Clear()
                            Select Case entrerXml
                                Case "1"
                                    uneCommandeXml = "/cd/liste-pieces/piece[@no-sequence=6]"
                                Case "2"
                                    uneCommandeXml = "/cd/*"
                                Case "3"
                                    uneCommandeXml = "/cd//titre"
                                Case "4"
                                    uneCommandeXml = "/cd/liste-pieces//minutes"
                            End Select
                        Case Else
                            Console.Clear()
                            fichierValide = False
                            Console.WriteLine("Veuillez charger un fichier valide.")
                    End Select
                    If fichierValide Then
                        Dim expr As ExprXPath = New ExprXPath(uneCommandeXml)
                        Dim listeRecherche As List(Of ElementXml) = expr.Interroger(monDoc.Racine)
                        For Each elem As ElementXml In listeRecherche
                            Console.WriteLine(elem.ToString())
                        Next
                    End If
                    Console.ReadLine()
            End Select
        Loop While entrer <> "6"
    End Sub
End Module

