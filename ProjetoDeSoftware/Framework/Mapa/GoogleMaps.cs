using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetoDeSoftware.Framework.Mapa
{
    class GoogleMaps
    {
        static List<String> termos;

        public static WebBrowser setJanela(ref WebBrowser browser, List<String> _termos) {
            termos = _termos;
            String pesquisa = "";
            foreach (String s in termos)
                pesquisa += s + "+";

            pesquisa = "https://www.google.com.br/maps/search/" + pesquisa;
            browser.Navigate(pesquisa);
            return browser;
        }
    }
}
