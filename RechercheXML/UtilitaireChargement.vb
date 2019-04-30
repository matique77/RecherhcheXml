Imports System.Xml
'=================================================================================================
'  Nom du fichier : UtilitaireChargement.vb
'         Module  : UtilitaireChargement
' Nom de l'auteur : ???
'            Date : 30/04/19
'=================================================================================================

''' <summary>
''' Ensemble de méthodes utiles au chargement des fichier XML.
''' </summary>
Module UtilitaireChargment

    ''' <summary>
    ''' Permet de charger un fichier xml et de le sérialisé 
    ''' en "DocumentXml". 
    ''' </summary>
    ''' <param name="chemin">un chemin valide vers le fichier..</param>
    ''' <returns>Un "DocumentXml".</returns>
    Public Function ChargerFichierXml(chemin As String) As DocumentXml

        'Validation simple du chemin  :
        If (chemin Is Nothing) Then
            Throw New ArgumentNullException("Un chemin ne peut référé à rien.")
        End If

        'On vérifie que le chemin pointe vers un fichier xml valide.

        '!Important : Utilisation de la  classe XmlDocument pour lire les informations du fichier. 
        Dim docCharger As XmlDocument = New XmlDocument()

        'Si une exception est lancé on lance nous même une autre exception plus spécifique à la classe. .  
        Try
            docCharger.LoadXml(chemin)
        Catch
            Throw New ArgumentException("Le fichier chercher n'existe pas ou le chemin est invalide.")
        End Try

        'Déclaration du DocumentXml retourné. 
        Dim docXml As DocumentXml



        '!!!!Il faut parcourrir l'entièreté du document xml et ajouter chacun des noeuds. 

        Throw New NotImplementedException("À faire..")


    End Function

End Module
