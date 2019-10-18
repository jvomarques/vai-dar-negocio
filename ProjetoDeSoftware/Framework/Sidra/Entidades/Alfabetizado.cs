using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoDeSoftware.Framework.Sidra.Entidades
{
    public class Alfabetizado : Entidade<Alfabetizado>
    {
        private Dictionary<string, double> grupos_idade = new Dictionary<string, double>();
        private Bairro bairro;

        public Alfabetizado() 
        {
            grupos_idade.Add("5_9", -1);
            grupos_idade.Add("10_14", -1);
            grupos_idade.Add("15_19", -1);
            grupos_idade.Add("20_29", -1);
            grupos_idade.Add("30_39", -1);
            grupos_idade.Add("40_49", -1);
            grupos_idade.Add("50_59", -1);
            grupos_idade.Add("60+", -1);

            bairro = null;
        }

        public Dictionary<string, double> getGrupoIdade()
        {
            return this.grupos_idade;
        }

        public Bairro getBairro()
        {
            if (!bairro.Equals(null))
                return bairro;

            return bairro;
        }

        public Alfabetizado getAlfabetizadoPorBairro(int id_bairro)
        {
            List<Alfabetizado> l_alfabetizado = new List<Alfabetizado>();

            l_alfabetizado = listAll();

            for (int i = 0; i < l_alfabetizado.Count; i++)
            {
                if (l_alfabetizado[i].getBairro().getId() == id_bairro)
                    return l_alfabetizado[i];
            }

            return null;
        }

        public override List<Alfabetizado> listAll()
        {
            List<Alfabetizado> l_alfabetizado = new List<Alfabetizado>();

            conexao.Abrir();

            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Alfabetizado;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Alfabetizado a = new Alfabetizado();

                    a.grupos_idade["5_10"] = Convert.ToDouble(leitor["10_14"]);
                    a.grupos_idade["10_14"] = Convert.ToDouble(leitor["10_14"]);
                    a.grupos_idade["15_19"] = Convert.ToDouble(leitor["15_19"]);
                    a.grupos_idade["20_29"] = Convert.ToDouble(leitor["20_29"]);
                    a.grupos_idade["30_39"] = Convert.ToDouble(leitor["30_39"]);
                    a.grupos_idade["40_49"] = Convert.ToDouble(leitor["40_49"]);
                    a.grupos_idade["50_59"] = Convert.ToDouble(leitor["50_59"]);
                    a.grupos_idade["60+"] = Convert.ToDouble(leitor["60+"]);

                    a.setId(Convert.ToInt32(leitor["id"]));

                    int id_bairro = Convert.ToInt32(leitor["id_bairro"]);
                    a.bairro = new Bairro(id_bairro);

                    l_alfabetizado.Add(a);
                }
            }

            conexao.Fechar();

            return l_alfabetizado;
        }

    }
}
