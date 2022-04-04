Option Explicit On

'Pagina para baixar o selenium
'https://github.com/florentbr/SeleniumBasic/releases/tag/v2.0.9.0

'Objetos Selenium
Private selApp As Selenium.Application, _
        selChrome As New Selenium.ChromeDriver, _
        selBy As Selenium.By, _
        htmlWebElement As Selenium.WebElement, _
        htmlSelect As Selenium.SelectElement, _
        htmlTable As Selenium.TableElement, _
        htmlAlert As Selenium.alert
    
'Auxiliares
Private blnSemErro As Boolean, _
        strError As String


'Enum para tipo do elemento
Public Enum TipoElemento
    ElementWeb = 0
    ElementSelect = 1
    ElementTable = 2
End Enum

'Enum para tipo de busca do elemento na página
Public Enum TipoBusca
    ByXPath = 0
    ById = 1
    ByCss = 2
    ByTag = 3
End Enum



Private Sub Class_Initialize()
    InicializaChrome
End Sub

Private Sub Class_Terminate()
    On Error Resume Next
    
    'Fecha objetos
    If Not selChrome Is Nothing Then selChrome.Quit
    
    Set htmlAlert = Nothing
    Set htmlSelect = Nothing
    Set htmlWebElement = Nothing
    Set selBy = Nothing
    Set selChrome = Nothing
    Set selApp = Nothing
End Sub

Property Get NoError() As Boolean
    NoError = blnSemErro
End Property

Property Get ErrorMessage() As String
    ErrorMessage = strError
End Property

Property Get Url() As String
    'Auxiliares
    Dim strUrl As String
    
    'Verifica objeto inicializado
    If Not selChrome Is Nothing Then
        On Error Resume Next
        strUrl = selChrome.Url
        If Err.Number <> 0 Then Err.Clear
    End If
    Url = strUrl
    
End Property


Private Function InicializaChrome() As Boolean
    On Error GoTo Err_
    
    '(Re)inicializa instância do Chrome
    blnSemErro = False
    Set selChrome = Nothing
    Set selApp = New Selenium.Application
    Set selChrome = selApp.ChromeDriver
    selChrome.Start "chrome"
    
    blnSemErro = True
    
Exit_:
    InicializaChrome = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Private Function DefineBusca(Busca As TipoBusca, ParametroBusca As String) As Boolean
    On Error GoTo Err_

    'Parâmetro de pesquisa
    blnSemErro = False   
    Set selBy = Nothing
    Select Case Busca
        Case ByXPath
            Set selBy = selApp.By.XPath(ParametroBusca)
        
        Case ById
            Set selBy = selApp.By.ID(ParametroBusca)
        
        Case ByCss
            Set selBy = selApp.By.Css(ParametroBusca)
        
        Case ByTag
            Set selBy = selApp.By.Tag(ParametroBusca)
            

    End Select
    
    blnSemErro = True
    
Exit_:
    DefineBusca = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function Maximizar() As Boolean
    On Error GoTo Err_
     
    'Reposiciona e maximiza janela
    blnSemErro = False
    With selChrome.Window
        .SetPosition 0, 0
        .Maximize
   End With
   
   blnSemErro = True
   
Exit_:
    Maximizar = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function Navegar(Url As String, Optional TimeOutSeconds As Integer) As Boolean
    On Error GoTo Err_
    
    'Navega e aguarda timeout
    blnSemErro = False
    selChrome.Get Url, (TimeOutSeconds * 1000)
    
    blnSemErro = True
    
Exit_:
    Navegar = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function



Public Function ElementoPresente( _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As Boolean
    On Error GoTo Err_
    
    'Limpeza objetos
    blnSemErro = False
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    'Busca elemento na tela
    blnSemErro = selChrome.IsElementPresent(selBy, TimeOutSeconds * 1000)
   
   
Exit_:
    ElementoPresente = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function ElementoVisivel( _
    Tipo As TipoElemento, _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As Boolean
    On Error GoTo Err_
    
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    'Tipo do elemento
    Select Case Tipo
        Case ElementWeb
            Set htmlWebElement = Nothing
            Set htmlWebElement = selChrome.FindElement(selBy, TimeOutSeconds * 1000)
            blnSemErro = htmlWebElement.IsDisplayed
            
        Case ElementSelect
            Set htmlSelect = Nothing
            Set htmlSelect = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsSelect
            blnSemErro = htmlSelect.IsDisplayed
        
        Case ElementTable
            Set htmlTable = Nothing
            Set htmlTable = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsTable
            blnSemErro = htmlTable.IsDisplayed
        
    End Select
   
   
Exit_:
    ElementoVisivel = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function ElementoQtde( _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As Integer
    On Error GoTo Err_
    
    'Auxiliares
    Dim intQtde As Integer
    
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If

    'Busca elemento na tela
    intQtde = 0
    intQtde = selChrome.FindElements(selBy, , TimeOutSeconds * 1000).Count


Exit_:
    ElementoQtde = intQtde
    Exit Function

Err_:
    intQtde = 0
    strError = Err.Description
    Resume Exit_
End Function


Public Function ElementoTexto( _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As String
    On Error GoTo Err_
    
    'Auxiliares
    Dim strTexto As String
    
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
        
    'Busca elemento na tela
    strTexto = ""
    Set htmlWebElement = selChrome.FindElement(selBy, TimeOutSeconds * 1000)
    strTexto = htmlWebElement.text
    
   
Exit_:
    ElementoTexto = strTexto
    Exit Function

Err_:
    strTexto = ""
    strError = Err.Description
    Resume Exit_
End Function


Public Function Clicar( _
    Tipo As TipoElemento, _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As Boolean
    
    'Limpeza objetos
    blnSemErro = False
    Set htmlWebElement = Nothing
    Set htmlSelect = Nothing
    Set htmlTable = Nothing
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    'Tipo do elemento
    Select Case Tipo
        Case ElementWeb
            Set htmlWebElement = selChrome.FindElement(selBy, TimeOutSeconds * 1000)
            htmlWebElement.Click
            
        Case ElementSelect
            Set htmlSelect = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsSelect
            htmlSelect.Click
        
        Case ElementTable
            Set htmlTable = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsTable
            htmlTable.Click
        
    End Select
    
    blnSemErro = True
    
  
Exit_:
    Clicar = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function Hover( _
    Tipo As TipoElemento, _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Optional TimeOutSeconds As Integer _
) As Boolean
    
    'Limpeza objetos
    blnSemErro = False
    Set htmlWebElement = Nothing
    Set htmlSelect = Nothing
    Set htmlTable = Nothing
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    'Tipo do elemento
    Select Case Tipo
        Case ElementWeb
            Set htmlWebElement = selChrome.FindElement(selBy, TimeOutSeconds * 1000)
            selChrome.Actions.MoveToElement(htmlWebElement).Perform
            
        Case ElementSelect
            Set htmlSelect = selChrome.htmlSelect(selBy, TimeOutSeconds * 1000).AsSelect
            selChrome.Actions.MoveToElement(htmlSelect).Perform

        Case ElementTable
            Set htmlTable = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsTable
            selChrome.Actions.MoveToElement(htmlSelect).Perform
        
    End Select
    
    blnSemErro = True
    
  
Exit_:
    Hover = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function Digitar( _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Texto As String, _
    Optional TimeOutSeconds As Integer _
) As Boolean
    
    'Limpeza objetos
    blnSemErro = False
    Set htmlWebElement = Nothing
    Set htmlSelect = Nothing
    Set htmlTable = Nothing
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    'Preenche texto
    Set htmlWebElement = selChrome.FindElement(selBy, TimeOutSeconds * 1000)
    'htmlWebElement.Clear
    htmlWebElement.SendKeys Texto


    blnSemErro = True
  
Exit_:
    Digitar = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function Selecionar( _
    Busca As TipoBusca, _
    ParametroBusca As String, _
    Valor As String, _
    Optional TimeOutSeconds As Integer _
)
    'Limpeza objetos
    blnSemErro = False
    Set htmlWebElement = Nothing
    Set htmlSelect = Nothing
    Set htmlTable = Nothing
    
    'Parâmetro de pesquisa
    If Not DefineBusca(Busca, ParametroBusca) Then
        strError = "Erro na busca"
        GoTo Err_
    End If
    
    
    'Preenche texto
    Set htmlSelect = selChrome.FindElement(selBy, TimeOutSeconds * 1000).AsSelect
    htmlSelect.SelectByValue Valor

Exit_:
    Selecionar = blnSemErro
    Exit Function

Err_:
    blnSemErro = False
    strError = Err.Description
    Resume Exit_
End Function


Public Function EsperarDownload() As String
    Dim shadowRoot As Selenium.WebElement, _
        downloadsManager As Selenium.WebElement, _
        downloadsItem As Selenium.WebElement, _
        name As Selenium.WebElement, _
        pct As Selenium.WebElement
    Dim strName As String, _
        strPct As String
    
    
    'Abre página de downloads
    On Error Resume Next
    selChrome.SwitchToWindowByTitle "Downloads", 0
    If Err.Number <> 0 Then
        Err.Clear
        selChrome.ExecuteScript ("window.open('about:blank')")
        selChrome.SwitchToNextWindow
        selChrome.Get ("chrome://downloads")
    End If
    
DownIni_:
    'Aguarda início do download
    Do While Not ElementoPresente(ByTag, "downloads-manager", 5)
        Sleep 10
    Loop
    
    'Localiza informação do último download
    Set downloadsManager = selChrome.FindElementByTag("downloads-manager")
    Set shadowRoot = selChrome.ExecuteScript("return arguments[0].shadowRoot", downloadsManager)
    On Error Resume Next
    Set downloadsItem = selChrome.ExecuteScript("return arguments[0].querySelectorAll('downloads-item')[0];", shadowRoot)
    If Err.Number <> 0 Then
        Err.Clear
        GoTo DownIni_
    End If
    Set shadowRoot = selChrome.ExecuteScript("return arguments[0].shadowRoot", downloadsItem)
    
    'Captura nome do arquivo baixado
    Set name = shadowRoot.FindElementById("name")
    strName = name.Attribute("innerHTML")
    
    'Aguarda fim do download
    strPct = ""
    Do
        On Error Resume Next
        Set pct = shadowRoot.FindElementById("progress", 0)
        If Err.Number <> 0 Then
            Err.Clear
            Exit Do
        End If
        strPct = pct.Value
        Sleep 50
    Loop While strPct <> "100"
    
    'Fecha aba de download
    selChrome.SwitchToPreviousWindow
    
    'Retorna nome do arquivo
    EsperarDownload = strName

End Function
