'=================================================================================================
'  Nom du fichier : Principal.vb
'         Module  : Principale
' Nom de l'auteur : Mathieu Pelletier
'            Date : 01/04/19
'=================================================================================================

Imports System.Xml
Imports System.IO

Module Principal
    Sub Main()
        Dim monDoc As DocumentXml = Nothing
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
                    Dim nomFichier As String = Console.ReadLine
                    If File.Exists(nomFichier) Then
                        monDoc = ChargerFichierXml(nomFichier)
                    End If
                Case "2"

                Case "3"
                    Console.Clear()
                    Console.WriteLine("Le nom de la racine est {0}", monDoc.Racine.Nom)
                    Console.WriteLine("le nombre d'élément du document est : {0}", monDoc.NbElements)
                    Console.WriteLine("Le nombre d'attributs est {0}", monDoc.NbAttributs)
                    Console.WriteLine("La profondeur du document est {0}", monDoc.Profondeur)
                    Console.ReadLine()
                Case "4"

                Case "5"

            End Select
        Loop While entrer <> "6"
    End Sub
End Module
