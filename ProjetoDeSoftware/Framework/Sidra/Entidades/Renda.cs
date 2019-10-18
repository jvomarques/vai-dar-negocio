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
    public class Renda : Entidade<Renda>
    {
        private Dictionary<string, double> grupos_idade = new Dictionary<string, double>();
        private Bairro bairro;
        
        public Renda() 
        {
            grupos_idade.Add("10_14", -1);
            grupos_idade.Add("15_19", -1);
            grupos_idade.Add("15_17", -1);
            grupos_idade.Add("20_24", -1);
            grupos_idade.Add("25_29", -1);
            grupos_idade.Add("30_34", -1);
            grupos_idade.Add("35_39", -1);
            grupos_idade.Add("40_44", -1);
            grupos_idade.Add("45_49", -1);
            grupos_idade.Add("50_54", -1);
            grupos_idade.Add("55_59", -1);
            grupos_idade.Add("60_69", -1);
            grupos_idade.Add("70+", -1);

            bairro = null;

        }

        public Bairro getBairro()
        {
            if (!bairro.Equals(null))
                return bairro;

            return bairro;
        }

        public Dictionary<string, double> getGrupoIdade() 
        {
            return this.grupos_idade;
        }

        public Renda getRendaPorBairro(int id_bairro) 
        {
            List<Renda> l_renda = new List<Renda>();

            l_renda = listAll();
            
            for (int i = 0; i < l_renda.Count; i++) 
            {
                if (l_renda[i].getBairro().getId() == id_bairro)
                    return l_renda[i];
            }

            return null;
        }

        public override List<Renda> listAll()
        {
            List<Renda> l_renda = new List<Renda>();

            conexao.Abrir();

            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Renda;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Renda r = new Renda();
                    
                    r.grupos_idade["10_14"] = Convert.ToDouble(leitor["10_14"]);
                    r.grupos_idade["15_19"] = Convert.ToDouble(leitor["15_19"]);
                    r.grupos_idade["15_17"] = Convert.ToDouble(leitor["15_17"]);
                    r.grupos_idade["20_24"] = Convert.ToDouble(leitor["20_24"]);
                    r.grupos_idade["25_29"] = Convert.ToDouble(leitor["25_29"]);
                    r.grupos_idade["30_34"] = Convert.ToDouble(leitor["30_34"]);
                    r.grupos_idade["35_39"] = Convert.ToDouble(leitor["35_39"]);
                    r.grupos_idade["40_44"] = Convert.ToDouble(leitor["40_44"]);
                    r.grupos_idade["45_49"] = Convert.ToDouble(leitor["45_49"]);
                    r.grupos_idade["50_54"] = Convert.ToDouble(leitor["50_54"]);
                    r.grupos_idade["55_59"] = Convert.ToDouble(leitor["55_59"]);
                    r.grupos_idade["60_69"] = Convert.ToDouble(leitor["60_69"]);
                    r.grupos_idade["70+"] = Convert.ToDouble(leitor["70+"]);
                    
                    r.setId(Convert.ToInt32(leitor["id"]));
                    
                    int id_bairro = Convert.ToInt32(leitor["id_bairro"]);
                    r.bairro = new Bairro(id_bairro);

                    l_renda.Add(r);
                }
            }
            
            
            conexao.Fechar();

            return l_renda;
        }


    }
}
