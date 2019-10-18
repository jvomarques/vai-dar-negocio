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
    public class Genero : Entidade<Genero>
    {
        int qtd_homem, qtd_mulher;
        Bairro bairro;

        public Genero()
        {
            qtd_homem = qtd_mulher = -1;
            bairro = null;
        }
        public Genero(int _id)
        {
            setId(_id);
            alimenta();
        }

        public Bairro getBairro()
        {
            if (!bairro.Equals(null))
                return bairro;
            return bairro;
        }

        public int getQtdHomem()
        {
            return qtd_homem;
        }

        public int getQtdMulher()
        {
            return qtd_mulher;
        }

        public void alimenta()
        {
            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Genero WHERE id = " + getId() + ";";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    qtd_homem = int.Parse(leitor["homens"].ToString());
                    qtd_mulher = int.Parse(leitor["mulheres"].ToString());
                    int id_bairro = int.Parse(leitor["id_bairro"].ToString());
                    bairro = new Bairro(id_bairro);
                }
            }

            conexao.Fechar();
        }

        public Genero getGeneroPorBairro(int id_bairro)
        {
            List<Genero> l_genero = new List<Genero>();

            l_genero = listAll();

            for (int i = 0; i < l_genero.Count; i++)
            {
                if (l_genero[i].getBairro().getId() == id_bairro)
                    return l_genero[i];
            }

            return null;
        }

        public override List<Genero> listAll()
        {
            List<Genero> all = new List<Genero>();

            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Genero;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Genero g = new Genero();

                    g.setId(int.Parse(leitor["id"].ToString()));
                    g.qtd_homem = Convert.ToInt32(leitor["homens"]);
                    g.qtd_mulher = Convert.ToInt32(leitor["mulheres"]);
                    
                    int id_bairro = Convert.ToInt32(leitor["id_bairro"]);
                    g.bairro = new Bairro(id_bairro);

                    all.Add(g);
                }
            }
            conexao.Fechar();

            return all;
        }
    }
}
