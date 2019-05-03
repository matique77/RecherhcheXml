Imports System.Text.RegularExpressions

Module UtilitaireRegx
    ''' <summary>
    ''' Permet d'obtenir une sous-chaine , si elle est contenu dans un string à partir
    ''' d'une expression régulière. 
    ''' </summary>
    ''' <returns>Un filtre si il est contenu, sinon une chaîne vide.</returns>
    Public Function ObtenirSousChaineRegx(expressionRegx As String, str As String) As String
        'On valide les strings
        StringValide(expressionRegx)
        StringValide(str)

        'On vérifie que le string est contenu. 
        If Not RegexMatch(expressionRegx, str) Then
            Return ""
        End If

        Dim filtre As String = Regex.Replace(str, expressionRegx, "")
        Return filtre
    End Function

    ''' <summary>
    ''' Vérifie si une expression régulière est contenu.
    ''' </summary>
    ''' <param name="expressionRegx">Une expression régulière</param>
    ''' <param name="str">Le string à valider.</param>
    ''' <returns>Vrai si l'expression est contenu
    '''          Faux si elle ne l'est pas.</returns>
    Public Function RegexMatch(expressionRegx As String, str As String) As Boolean
        'Validation et uniformisation des strings.
        StringValide(expressionRegx)
        StringValide(str)

        Return Regex.IsMatch(str, expressionRegx)
    End Function

    ''' <summary>
    ''' Valide et uniformise un string.
    ''' </summary>
    ''' <param name="str">Un string à uniformiser.</param>
    Public Sub StringValide(ByRef str As String)
        If (str Is Nothing) Then
            Throw New ArgumentNullException("Le string ne peut référé à rien.")
        End If

        str = str.Trim()

        If str = "" Then
            Throw New ArgumentException("Un string ne peut être vide.")
        End If
    End Sub

End Module
