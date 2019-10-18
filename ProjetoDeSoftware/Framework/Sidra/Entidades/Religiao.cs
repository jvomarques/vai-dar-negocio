using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;

namespace ProjetoDeSoftware.Framework.Sidra.Entidades
{
    class Religiao : Entidade<Religiao>
    {
        Cidade cidade;
        int qtd_catolico, qtd_evangelico;
        double proporcao_catolico, proporcao_evangelico;

        public Religiao() 
        {

            proporcao_catolico = proporcao_evangelico = qtd_catolico = qtd_evangelico = -1;
        }

        public int getQtdCatolico() 
        {
            return this.qtd_catolico;
        }

        public int getQtdEvangelico()
        {
            return this.qtd_evangelico;
        }

        public void setProporcoes()
        {
            conexao.Abrir();
            int aux_catolico = 0; 
            int aux_evangelico = 0;

            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Religiao WHERE id_bairro = -1;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    qtd_catolico = int.Parse(leitor["catolico"].ToString());
                    qtd_evangelico = int.Parse(leitor["evangelico"].ToString());
                }
            }

            conexao.Fechar();

            conexao.Abrir();
            int populacao_total = 0;

            if (conexao.EstaAberta()) 
            {
                conexao.Abrir();

                string sql = "SELECT sum(total) FROM Genero;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    populacao_total = int.Parse(leitor["sum(total)"].ToString());
                }
            }
            conexao.Fechar();
            double a = Convert.ToDouble(populacao_total);
            double b = Convert.ToDouble(qtd_catolico);
            double c = Convert.ToDouble(qtd_evangelico);

            proporcao_catolico = Convert.ToDouble(b/a);
            proporcao_evangelico = Convert.ToDouble(c/a);
        }

        public double getPercentualCatolico() 
        {
            return proporcao_catolico;
        }

        public double getPercentualEvangelico()
        {

            return proporcao_evangelico;
        }

        public void alimenta() 
        {
            for (int i = 1; i < 37; i++)
            {
                Genero g = new Genero(i);
                int populacao_total = g.getQtdHomem() + g.getQtdMulher();

                conexao.Abrir();
                if (conexao.EstaAberta()) 
                {
                    conexao.Abrir();

                    string sql = "INSERT INTO Religiao (id, id_cidade, catolico, evangelico, id_bairro) VALUES (" + i + 1 + ", 1," + populacao_total * proporcao_catolico + ", " + populacao_total * proporcao_evangelico + ", " + i + ";";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());
                    SQLiteDataReader leitor = cmd.ExecuteReader();
                    
                }
                conexao.Fechar();
            }
        }

        public override List<Religiao> listAll()
        {
            List<Religiao> l_religiao = new List<Religiao>();

            return l_religiao;
        }


    }
}
