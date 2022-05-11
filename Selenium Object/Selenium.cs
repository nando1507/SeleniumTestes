using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_Object.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Object
{
    public class Selenium
    {
        TimeSpan time = TimeSpan.FromSeconds(60);
        ChromeDriver selChrome = new ChromeDriver();
        By selBy;
        WebElement htmlWebElement;
        SelectElement htmlSelect;
        //TableElement htmlTable;
        //alert htmlAlert;
        Boolean blnSemErro;
        String strError;

        public ChromeDriver startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = false;
            options.LeaveBrowserRunning = false;
            options.UseWebSocketUrl = false;
            ChromeDriver startBrowser = new ChromeDriver(FindChromeDriver(), options, time);
            startBrowser.CloseDevToolsSession();
            startBrowser.ClearNetworkConditions();

            return startBrowser;

        }
        public bool maximizar(IWebDriver driver, bool maximizar = false)
        {            
            driver.Manage().Window.Position.Offset(0,0);
            driver.Manage().Window.Maximize();
            return !maximizar;
        }



        public bool navegar(IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        bool DefineBusca(EnumTipoBusca Busca, String ParametroBusca)
        {
            try
            {
                //Parâmetro de pesquisa                
                switch (Busca)
                {
                    case EnumTipoBusca.ByXPath:
                        selBy = By.XPath(ParametroBusca);
                        break;
                    case EnumTipoBusca.ById:
                        selBy = By.Id(ParametroBusca);
                        break;
                    case EnumTipoBusca.ByCss:
                        selBy = By.CssSelector(ParametroBusca);
                        break;
                    case EnumTipoBusca.ByTag:
                        selBy = By.TagName(ParametroBusca);
                        break;
                    case EnumTipoBusca.ClassName:
                        selBy = By.TagName(ParametroBusca);
                        break;
                    case EnumTipoBusca.LinkText:
                        selBy = By.TagName(ParametroBusca);
                        break;
                    case EnumTipoBusca.Name:
                        selBy = By.TagName(ParametroBusca);
                        break;
                    case EnumTipoBusca.PartialLinkText:
                        selBy = By.TagName(ParametroBusca);
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        bool closeBrowser(IWebDriver driver)
        {
            try
            {
                driver.Close();
                driver.Quit();
                driver.Dispose();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        string FindChromeDriver()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var info = dir.GetFiles("chromedriver.exe", SearchOption.TopDirectoryOnly);

            return info[0].DirectoryName;
        }



        public void Inicio()
        {
            using (IWebDriver driver = startBrowser())
            {
                maximizar(driver,true);


                navegar(driver, "https://www.palmeiras.com.br/listas-e-rankings/");
                Thread.Sleep(1000);




                closeBrowser(driver);
                Console.ReadKey();
            }
        }
    }
}
