using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Selenium_Object
{
    public class Selenium
    {
        TimeSpan time = TimeSpan.FromSeconds(60);
        IWebDriver driver;

        public ChromeDriver startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.LeaveBrowserRunning = true;
            options.UseWebSocketUrl = true;

            return new ChromeDriver(FindChromeDriver(), options);

        }

        public void test(string url)
        {
            driver.Url = url;
        }

        public void closeBrowser()
        {
            driver.Close();
        }

        public string FindChromeDriver()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var info = dir.GetFiles("chromedriver.exe", SearchOption.TopDirectoryOnly);

            return info[0].DirectoryName;
        }

        public void Inicio()
        {
            using (IWebDriver driver = startBrowser())
            {
                driver.Navigate().GoToUrl("https://www.palmeiras.com.br/listas-e-rankings/");

                Console.Clear();

                StringBuilder builder = new StringBuilder();
                builder.Append(driver.PageSource.ToString());
                List<ClasseSaida> lst = new List<ClasseSaida>();


                //string page = driver.PageSource.ToString();
                foreach (var item in tags())
                {
                    ClasseSaida saida = new ClasseSaida();

                    string pattern = $@"<{item} .*\>([^:]+)</{item}>";
                    RegexOptions options = RegexOptions.Multiline;
                    MatchCollection collection = Regex.Matches(builder.ToString(), pattern, options);

                    saida.ObjetoHTML = item;
                    saida.QuantidadeHTML = collection.Count();

                    foreach (var obj in collection)
                    {
                        foreach (string objInterno in new string[] { "target", "class", "id" })
                        {
                            string patternCss = $"{objInterno}[=|:]\"([^:\"$]+)\"";
                            MatchCollection collection1 = Regex.Matches(obj.ToString(), patternCss, options);
                            
                            saida.ObjetoCSS = objInterno.ToString();
                            saida.QuantidadeCSS = collection1.Count();
                            saida.Conteudo = collection1.ToList();
                        }
                    }

                    lst.Add(saida);

                }


                Console.Clear();
                foreach (ClasseSaida item in lst)
                {
                    Console.WriteLine($"{item.ObjetoHTML} {item.QuantidadeHTML} {item.ObjetoCSS} {item.QuantidadeCSS} {item.Conteudo}");
                }


                driver.Quit();
                Console.ReadKey();
            }
        }

        public List<string> tags()
        {
            List<string> tag = new List<string>();

            tag.Add("!--...--");
            tag.Add("!doctype");
            tag.Add("a");
            tag.Add("abbr");
            tag.Add("acronym");
            tag.Add("address");
            tag.Add("applet");
            tag.Add("area");
            tag.Add("article");
            tag.Add("aside");
            tag.Add("audio");
            tag.Add("b");
            tag.Add("base");
            tag.Add("basefont");
            tag.Add("bb");
            tag.Add("bdo");
            tag.Add("big");
            tag.Add("blockquote");
            tag.Add("body");
            tag.Add("br");
            tag.Add("button");
            tag.Add("canvas");
            tag.Add("caption");
            tag.Add("center");
            tag.Add("cite");
            tag.Add("code");
            tag.Add("col");
            tag.Add("colgroup");
            tag.Add("command");
            tag.Add("datagrid");
            tag.Add("datalist");
            tag.Add("dd");
            tag.Add("del");
            tag.Add("details");
            tag.Add("dfn");
            tag.Add("dialog");
            tag.Add("dir");
            tag.Add("div");
            tag.Add("dl");
            tag.Add("dt");
            tag.Add("em");
            tag.Add("embed");
            tag.Add("eventsource");
            tag.Add("fieldset");
            tag.Add("figcaption");
            tag.Add("figure");
            tag.Add("font");
            tag.Add("footer");
            tag.Add("form");
            tag.Add("frame");
            tag.Add("frameset");
            tag.Add("h1 to h6");
            tag.Add("head");
            tag.Add("header");
            tag.Add("hgroup");
            tag.Add("hr /");
            tag.Add("html");
            tag.Add("i");
            tag.Add("iframe");
            tag.Add("img");
            tag.Add("input");
            tag.Add("ins");
            tag.Add("isindex");
            tag.Add("kbd");
            tag.Add("keygen");
            tag.Add("label");
            tag.Add("legend");
            tag.Add("li");
            tag.Add("link");
            tag.Add("map");
            tag.Add("mark");
            tag.Add("menu");
            tag.Add("meta");
            tag.Add("meter");
            tag.Add("nav");
            tag.Add("noframes");
            tag.Add("noscript");
            tag.Add("object");
            tag.Add("ol");
            tag.Add("optgroup");
            tag.Add("option");
            tag.Add("output");
            tag.Add("p");
            tag.Add("param");
            tag.Add("pre");
            tag.Add("progress");
            tag.Add("q");
            tag.Add("rp");
            tag.Add("rt");
            tag.Add("ruby");
            tag.Add("s");
            tag.Add("samp");
            tag.Add("script");
            tag.Add("section");
            tag.Add("select");
            tag.Add("small");
            tag.Add("source");
            tag.Add("span");
            tag.Add("strike");
            tag.Add("strong");
            tag.Add("style");
            tag.Add("sub");
            tag.Add("sup");
            tag.Add("table");
            tag.Add("tbody");
            tag.Add("td");
            tag.Add("textarea");
            tag.Add("tfoot");
            tag.Add("th");
            tag.Add("thead");
            tag.Add("time");
            tag.Add("title");
            tag.Add("tr");
            tag.Add("track");
            tag.Add("tt");
            tag.Add("u");
            tag.Add("ul");
            tag.Add("var");
            tag.Add("video");
            tag.Add("wbr");


            return tag;
        }
    }
}
