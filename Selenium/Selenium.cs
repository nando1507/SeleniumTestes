using System;

using Selenium;

namespace Selenium
{
    public class Selenium
    {
        ////Objetos Selenium

        //private Application selApp;
        //private ChromeDriver selChrome;
        //private By selBy;
        //private WebElement htmlWebElement;
        //private SelectElement htmlSelect;
        //private TableElement htmlTable;
        //private Alert htmlAlert;


        ////Auxiliares
        //private bool blnSemErro;
        //private string strError;
        //private readonly bool noError;


        ////Enum para tipo do elemento
        //public enum TipoElemento
        //{
        //    ElementWeb = 0,
        //    ElementSelect = 1,
        //    ElementTable = 2
        //}

        ////Enum para tipo de busca do elemento na página
        //public enum TipoBusca
        //{
        //    ByXPath = 0,
        //    ById = 1,
        //    ByCss = 2,
        //    ByTag = 3,
        //    ByClass = 4,
        //    ByLinkText = 5,
        //    ByName = 6,
        //    ByPartialLinkText = 7
        //}

        //private void Class_Initialize()
        //{
        //    InicializaChrome();
        //}

        //private bool InicializaChrome()
        //{
        //    try
        //    {
        //        //(Re)inicializa instância do Chrome
        //        blnSemErro = false;
        //        selChrome = null;
        //        selApp = new Application();
        //        selChrome = new ChromeDriver();
        //        selChrome.Start(browser: "chrome");
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        blnSemErro = false;
        //        return blnSemErro;
        //        throw new Exception($"Erro na Inicialização do Chrome Driver {ex.Message}");
        //    }

        //    return blnSemErro;

        //}

        //private void Class_Terminate()
        //{
        //    try
        //    {
        //        //Fecha Objeto
        //        if (selChrome != null)
        //        {
        //            selChrome.Quit();
        //        }
        //        htmlAlert = null;
        //        htmlSelect = null;
        //        htmlWebElement = null;
        //        selBy = null;
        //        selChrome = null;
        //        selApp = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro no Fechamento do Chrome Driver {ex.Message}");
        //    }
        //}

        //public bool NoError => blnSemErro;
        //public string ErrorMessage => strError;

        //private string url;

        //public string GetUrl()
        //{
        //    //Auxiliares
        //    url = string.Empty;
        //    try
        //    {
        //        //Verifica objeto inicializado
        //        if (selChrome != null)
        //        {
        //            url = selChrome.Url;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar a URL {ex.Message}");
        //    }
        //    return url;
        //}

        //public void SetUrl(string value)
        //{
        //    url = value;
        //}

        //private bool DefineBusca(TipoBusca busca, string ParametroBusca)
        //{
        //    try
        //    {
        //        blnSemErro = false;
        //        selBy = null;
        //        switch (busca)
        //        {
        //            case TipoBusca.ByXPath:
        //                selBy = By.XPath(ParametroBusca);
        //                break;
        //            case TipoBusca.ById:
        //                selBy = By.Id(ParametroBusca);
        //                break;
        //            case TipoBusca.ByCss:
        //                selBy = By.Css(ParametroBusca);
        //                break;
        //            case TipoBusca.ByTag:
        //                selBy = By.Tag(ParametroBusca);
        //                break;
        //            case TipoBusca.ByClass:
        //                selBy = By.Class(ParametroBusca);
        //                break;
        //            case TipoBusca.ByLinkText:
        //                selBy = By.LinkText(ParametroBusca);
        //                break;
        //            case TipoBusca.ByName:
        //                selBy = By.Name(ParametroBusca);
        //                break;
        //            case TipoBusca.ByPartialLinkText:
        //                selBy = By.PartialLinkText(ParametroBusca);
        //                break;
        //            default:
        //                throw new Exception("Parametro de Busca náo localizado");
        //        }
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        blnSemErro = false;
        //        throw new Exception($"Erro ao definir Busca {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public bool Maximizar()
        //{
        //    try
        //    {
        //        //Reposiciona e maximiza janela
        //        blnSemErro = false;
        //        selChrome.Window.SetPosition(0, 0);
        //        selChrome.Window.Maximize();
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao maximizar {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public bool Navegar(string url, int TimeOutSeconds = 20)
        //{
        //    try
        //    {
        //        blnSemErro = false;
        //        selChrome.Get(url, timeout(TimeOutSeconds));
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao acessar a pagina {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public bool ElementoPresente(TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    try
        //    {
        //        blnSemErro = false;
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }
        //        // Busca elemento na tela
        //        blnSemErro = selChrome.IsElementPresent(selBy, timeout(TimeOutSeconds));
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public bool ElementoVisivel(TipoElemento tipo, TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    try
        //    {
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }
        //        switch (tipo)
        //        {
        //            case TipoElemento.ElementWeb:
        //                htmlWebElement = null;
        //                htmlWebElement = selChrome.FindElement(selBy, timeout(TimeOutSeconds));
        //                blnSemErro = htmlWebElement.IsDisplayed;
        //                break;
        //            case TipoElemento.ElementSelect:
        //                htmlSelect = null;
        //                htmlSelect = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsSelect();
        //                blnSemErro = htmlSelect != null;
        //                break;
        //            case TipoElemento.ElementTable:
        //                htmlTable = null;
        //                htmlTable = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsTable();
        //                blnSemErro = htmlTable != null;
        //                break;
        //            default:
        //                throw new Exception("Parametro de Busca náo localizado");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public int ElementoQtde(TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    int intQtde = 0;
        //    try
        //    {
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }
        //        intQtde = selChrome.FindElements(selBy, 0, timeout(TimeOutSeconds)).Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return intQtde;
        //}

        //public string ElementoTexto(TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    string strTexto = string.Empty;
        //    try
        //    {
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }
        //        strTexto = selChrome.FindElements(selBy, 0, timeout(TimeOutSeconds)).ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return strTexto;
        //}

        //public bool Clicar(TipoElemento tipo, TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    string strTexto = string.Empty;
        //    try
        //    {
        //        //Limpeza objetos
        //        blnSemErro = false;
        //        htmlWebElement = null;
        //        htmlSelect = null;
        //        htmlTable = null;

        //        //Pesquisa e valida se o elemento existe na tela
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }

        //        switch (tipo)
        //        {
        //            case TipoElemento.ElementWeb:
        //                htmlWebElement = null;
        //                htmlWebElement = selChrome.FindElement(selBy, timeout(TimeOutSeconds));
        //                htmlWebElement.Click();
        //                break;
        //            case TipoElemento.ElementSelect:
        //                htmlSelect = null;
        //                htmlSelect = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsSelect();
        //                htmlSelect.SelectedOption.Click();
        //                break;
        //            case TipoElemento.ElementTable:
        //                htmlTable = null;
        //                htmlTable = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsTable();
        //                //selChrome.Actions.Click(htmlTable.Data());//htmlTable.Data().SetValue()
        //                break;
        //            default:
        //                throw new Exception("Parametro de Busca náo localizado");
        //        }
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //public bool Hover(TipoElemento tipo, TipoBusca busca, string ParametroBusca, int TimeOutSeconds = 20)
        //{
        //    string strTexto = string.Empty;
        //    try
        //    {
        //        //Limpeza objetos
        //        blnSemErro = false;
        //        htmlWebElement = null;
        //        htmlSelect = null;
        //        htmlTable = null;

        //        //Pesquisa e valida se o elemento existe na tela
        //        if (!DefineBusca(busca, ParametroBusca))
        //        {
        //            throw new Exception($"Erro na busca");
        //        }

        //        switch (tipo)
        //        {
        //            case TipoElemento.ElementWeb:
        //                htmlWebElement = null;
        //                htmlWebElement = selChrome.FindElement(selBy, timeout(TimeOutSeconds));
        //                selChrome.Actions.MoveToElement(htmlWebElement).Perform();
        //                break;
        //            case TipoElemento.ElementSelect:
        //                htmlSelect = null;
        //                htmlSelect = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsSelect();
        //                selChrome.Actions.MoveToElement(htmlSelect).Perform();
        //                break;
        //            case TipoElemento.ElementTable:
        //                htmlTable = null;
        //                htmlTable = selChrome.FindElement(selBy, timeout(TimeOutSeconds)).AsTable();
        //                selChrome.Actions.Click().MoveToElement(htmlTable).Perform();
        //                break;
        //            default:
        //                throw new Exception("Parametro de Busca náo localizado");
        //        }
        //        blnSemErro = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao Localizar o Elemento {ex.Message}");
        //    }
        //    return blnSemErro;
        //}

        //int timeout(int TimeOutSeconds)
        //{
        //    return TimeSpan.FromSeconds(TimeOutSeconds).Milliseconds;
        //}
    }
}
