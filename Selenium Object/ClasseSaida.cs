using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Selenium_Object
{
    public class ClasseSaida
    {
        public string ObjetoHTML { get; set; }
        public int QuantidadeHTML { get; set; }
        public string ObjetoCSS { get; set; }
        public int QuantidadeCSS { get; set; }
        public List<Match> Conteudo { get; set; }
    }
}
