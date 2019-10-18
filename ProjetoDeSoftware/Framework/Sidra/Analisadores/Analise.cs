using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoDeSoftware.Framework.Sidra.Analisadores
{
    public abstract class Analise <T>
    {
        List<string> dicas = new List<string>();
        public abstract double getViabilidade(T t);

        public List<string> getDicas()
        {
            return dicas;
        }
        public void addDicas(string s)
        {
            dicas.Add(s);
        }

    }
}
