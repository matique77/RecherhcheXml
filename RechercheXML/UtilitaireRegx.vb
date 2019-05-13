Imports System.Text.RegularExpressions
'=================================================================================================
'  Nom du fichier : UtilitaireRegx.vb
'         Module  : UtilitaireRegx
' Nom de l'auteur : Mathieu Morin
'            Date : 01/04/19
'=================================================================================================
Module UtilitaireRegx
    ''' <summary>
    ''' Vérifie si une expression régulière est contenu.
    ''' </summary>
    ''' <param name="expressionRegx">Une expression régulière</param>
    ''' <param name="str">Le string à valider.</param>
    ''' <returns>Vrai si l'expression est contenu
    '''          Faux si elle ne l'est pas.</returns>
    '''<remarks>Une expression ou un string ne peut référer à rien 
    ''' ou être vide.</remarks>
    Public Function RegexMatch(expressionRegx As String, str As String) As Boolean
        If (expressionRegx Is Nothing) Then
            Throw New ArgumentNullException("Une expression de caractère ne référer à rien.")
        End If

        expressionRegx = expressionRegx.Trim()
        If (str Is Nothing) Then
            Throw New ArgumentNullException("Une chaine de caractère ne peut référer à rien.")
        End If
        str = str.Trim()

        If (expressionRegx = "") Then
            Throw New ArgumentException("Une expression ne peut être vide.")
        End If

        If (str = "") Then
            Throw New ArgumentException("Une chaine de caractère ne peut être vide.")
        End If

        Return Regex.IsMatch(str, expressionRegx)
    End Function


End Module
