using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoDeSoftware.Framework.Graficos
{
    class Grafico
    {
        private Dictionary<string, string> grafico_dados = new Dictionary<string, string>();

        public void setDados(string titulo, string valor)
        {
            this.grafico_dados.Add(titulo, valor);
        }

        public Dictionary<string, string> getGrafico()
        {
            return grafico_dados;
        }

        public string getValor(string titulo)
        {
            return grafico_dados[titulo];
        }
    }
}
