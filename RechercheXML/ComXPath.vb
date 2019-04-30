'=================================================================================================
'  Nom du fichier : DocumentXml.vb
'         Classe  : ComXPath
' Nom de l'auteur : ??????? 
'            Date : 30/04/19
'=================================================================================================


'La classe va permettre de convertir les éléments importants d'une commandeXpath : 

'1- Elle va permettre de faire la validation directement de la commande. 
'2- Elle va nous permettre de conserver l'élément trouvé directement dans un attribut. 
'3- Finalement, elle pourra contenir une pile d'objet "OperateurXpath" correspondant à la commande. 
'4- Utiliser des méthodes comme EffectuerRecherhce avec la commande.


'!!!!!!!!!!!!-Il faudra créer une classe/Interface pour les opérateurXPath afin de les uniformiser. 


''' <summary>
''' Représente une commande XPath.
''' Elle permet d'encontainer les éléments importants de la commande passée. 
''' </summary>
Public Class ComXPath

    Public Sub New(recherhe As String)
        Throw New NotImplementedException("À faire..")
    End Sub

End Class


