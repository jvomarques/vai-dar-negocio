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
    public class Idade : Entidade<Idade>
    {
        private Dictionary<string, double> grupos_idade = new Dictionary<string, double>();
        private Bairro bairro;

        public Idade() 
        {
            grupos_idade.Add("-1", -1);
            grupos_idade.Add("0_4", -1);
            grupos_idade.Add("5_9", -1);
            grupos_idade.Add("10_14", -1);
            grupos_idade.Add("15_19", -1);
            grupos_idade.Add("20_24", -1);
            grupos_idade.Add("25_29", -1);
            grupos_idade.Add("30_34", -1);
            grupos_idade.Add("35_39", -1);
            grupos_idade.Add("40_44", -1);
            grupos_idade.Add("45_49", -1);
            grupos_idade.Add("50_54", -1);
            grupos_idade.Add("55_59", -1);
            grupos_idade.Add("60_69", -1);
            grupos_idade.Add("70_74", -1);
            grupos_idade.Add("75_79", -1);
            grupos_idade.Add("80_89", -1);
            grupos_idade.Add("90_99", -1);
            //grupos_idade.Add("70+", -1);
            //grupos_idade.Add("100+", -1);

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

        public Idade getIdadePorBairro(int id_bairro)
        {
            List<Idade> l_idade = new List<Idade>();

            l_idade = listAll();

            for (int i = 0; i < l_idade.Count; i++)
            {
                if (l_idade[i].getBairro().getId() == id_bairro)
                    return l_idade[i];
            }

            return null;
        }

        public override List<Idade> listAll()
        {
            List<Idade> l_idade = new List<Idade>();

            conexao.Abrir();

            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Idade;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Idade i = new Idade();

                    i.grupos_idade["-1"] = Convert.ToInt32(leitor["-1"]);
                    i.grupos_idade["0_4"] = Convert.ToInt32(leitor["0_4"]);
                    i.grupos_idade["5_9"] = Convert.ToInt32(leitor["5_9"]);
                    i.grupos_idade["10_14"] = Convert.ToInt32(leitor["10_14"]);
                    i.grupos_idade["15_19"] = Convert.ToInt32(leitor["15_19"]);
                    i.grupos_idade["20_24"] = Convert.ToInt32(leitor["20_24"]);
                    i.grupos_idade["25_29"] = Convert.ToInt32(leitor["25_29"]);
                    i.grupos_idade["30_34"] = Convert.ToInt32(leitor["30_34"]);
                    i.grupos_idade["35_39"] = Convert.ToInt32(leitor["35_39"]);
                    i.grupos_idade["40_44"] = Convert.ToInt32(leitor["40_44"]);
                    i.grupos_idade["45_49"] = Convert.ToInt32(leitor["45_49"]);
                    i.grupos_idade["50_54"] = Convert.ToInt32(leitor["50_54"]);
                    i.grupos_idade["55_59"] = Convert.ToInt32(leitor["55_59"]);
                    i.grupos_idade["60_69"] = Convert.ToInt32(leitor["60_69"]);
                    i.grupos_idade["60_64"] = Convert.ToInt32(leitor["60_64"]);
                    i.grupos_idade["70_74"] = Convert.ToInt32(leitor["70_74"]);
                    i.grupos_idade["75_79"] = Convert.ToInt32(leitor["75_79"]);
                    i.grupos_idade["80_89"] = Convert.ToInt32(leitor["80_89"]);
                    i.grupos_idade["90_99"] = Convert.ToInt32(leitor["90_99"]);
                    //i.grupos_idade["70+"] = Convert.ToInt32(leitor["70+"]);
                    //i.grupos_idade["100+"] = Convert.ToInt32(leitor["100+"]);

                    i.setId(Convert.ToInt32(leitor["id"]));

                    int id_bairro = Convert.ToInt32(leitor["id_bairro"]);
                    i.bairro = new Bairro(id_bairro);

                    l_idade.Add(i);
                }
            }

            conexao.Fechar();

            return l_idade;
        }


    }
}
