﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    'à l'aide d'un outil, tel que ResGen ou Visual Studio.
    'Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    'avec l'option /str ou régénérez votre projet VS.
    '''<summary>
    '''  Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("RechercheXML.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Remplace la propriété CurrentUICulture du thread actuel pour toutes
        '''  les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Recherche une chaîne localisée semblable à &lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;exemples-californication-rhcp.xsl&quot; ?&gt;
        '''
        '''&lt;cd no-serie=&quot;B2-589C-730&quot;&gt;
        '''	&lt;titre&gt;Californication&lt;/titre&gt;
        '''	&lt;artiste&gt;Red Hot Chili Peppers&lt;/artiste&gt;
        '''	&lt;date-parution&gt;1999&lt;/date-parution&gt;
        '''	&lt;duree-total&gt;
        '''		&lt;minutes&gt;56&lt;/minutes&gt;
        '''		&lt;secondes&gt;17&lt;/secondes&gt;
        '''	&lt;/duree-total&gt;
        '''
        '''	&lt;liste-pieces&gt;
        '''
        '''		&lt;piece no-sequence=&quot;1&quot;&gt;
        '''			&lt;titre&gt;Around The World&lt;/titre&gt;
        '''			&lt;duree&gt;
        '''			
        '''				&lt;minutes&gt;3&lt;/minutes&gt;
        '''				&lt;secondes&gt;58&lt;/secondes&gt;
        '''			&lt;/duree&gt;
        '''		&lt;/piece&gt;
        '''
        '''		&lt;piece no-sequence=&quot;2&quot;&gt;
        '''			&lt;titre&gt;Paralle [le reste de la chaîne a été tronqué]&quot;;.
        '''</summary>
        Friend ReadOnly Property exemples_californication_rhcp() As String
            Get
                Return ResourceManager.GetString("exemples_californication_rhcp", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Recherche une chaîne localisée semblable à &lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;exemples-recettes.xsl&quot; ?&gt;
        '''
        '''&lt;livre-recettes&gt;
        '''	&lt;ingredients-base&gt;
        '''		&lt;ingredient&gt;Sel&lt;/ingredient&gt;
        '''		&lt;ingredient&gt;Poivre&lt;/ingredient&gt;
        '''		&lt;ingredient&gt;Huile&lt;/ingredient&gt;
        '''	&lt;/ingredients-base&gt;
        '''	&lt;recettes&gt;
        '''		&lt;recette portions=&quot;4&quot; cat=&quot;entrée&quot;&gt;
        '''			&lt;nom&gt;Pattes de poulet à l&apos;asiatique&lt;/nom&gt;
        '''			&lt;ingredients&gt;
        '''				&lt;ingredient qt=&quot;16&quot;&gt;Pattes de poulet&lt;/ingredient&gt;
        '''				&lt;ingredient qt=&quot;500&quot; unite=&quot;ml&quot;&gt;Bouillon épicé&lt;/ingredient&gt;
        '''			&lt;/ingredients&gt;
        '''		&lt;/recette&gt;
        '''		&lt;recette portions=&quot;3&quot; cat=&quot; [le reste de la chaîne a été tronqué]&quot;;.
        '''</summary>
        Friend ReadOnly Property exemples_recettes() As String
            Get
                Return ResourceManager.GetString("exemples_recettes", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
