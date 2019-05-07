Imports System.Xml
'=================================================================================================
'  Nom du fichier : UtilitaireChargement.vb
'         Module  : UtilitaireChargement
' Nom de l'auteur : Mathieu Pelletier
'            Date : 01/04/19
'=================================================================================================

''' <summary>
''' Ensemble de méthodes utiles au chargement des fichier XML.
''' </summary>
Module UtilitaireChargement

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
        Dim doc As XmlDocument = New XmlDocument()

        Try
            doc.Load(chemin)
        Catch e As XmlException
            Throw New ArgumentException("Le fichier chercher n'existe pas ou le chemin est invalide.")
        End Try

        Dim maRacine As ElementXml
        doc.Load(chemin)
        Dim racine As XmlElement = doc.DocumentElement
        maRacine = New ElementXml(racine.Name, AttributesVersList(racine.Attributes), XmlChildVersClassRecursif(racine.ChildNodes))
        Dim monDocument As DocumentXml = New DocumentXml(maRacine)
        Return monDocument
    End Function

    ''' <summary>
    ''' Transforme une collection d'attribute XML en liste d'attribut.
    ''' </summary>
    ''' <param name="maCollection">La collection d'attribut du fichier</param>
    ''' <returns>La liste des attributes transformer en attribut.</returns>
    Private Function AttributesVersList(maCollection As XmlAttributeCollection) As List(Of Attribut)
        Dim listeRetour = New List(Of Attribut)
        For Each attribute As XmlAttribute In maCollection
            listeRetour.Add(New Attribut(attribute.Name, attribute.Value))
        Next
        Return listeRetour
    End Function

    ''' <summary>
    ''' Transforme chaque noeud XML en ElementXml. 
    ''' </summary>
    ''' <param name="maCollection">la collection Xml des noeuds</param>
    ''' <returns>retourne une liste d'Element Xml</returns>
    Private Function XmlChildVersClassRecursif(maCollection As XmlNodeList) As List(Of ElementXml)
        Dim listeRetour = New List(Of ElementXml)
        If maCollection Is Nothing OrElse maCollection.Count = 0 Then
            Return listeRetour
        End If
        Dim elem As XmlElement = TryCast(maCollection.Item(0), XmlElement)
        If elem Is Nothing Then
            Return listeRetour
        End If

        For Each element As XmlElement In maCollection
            Dim nouvelElement As ElementXml
            If (element.FirstChild.NodeType = XmlNodeType.Text) Then
                nouvelElement = New ElementXml(element.Name, AttributesVersList(element.Attributes), element.InnerText)
            Else
                nouvelElement = New ElementXml(element.Name, AttributesVersList(element.Attributes), XmlChildVersClassRecursif(element.ChildNodes))
            End If
            listeRetour.Add(nouvelElement)
        Next
        Return listeRetour
    End Function

End Module
