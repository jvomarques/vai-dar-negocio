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
    public class Bairro : Entidade<Bairro>
    {
        private String nome, codigo, zona;
        private Cidade cidade;

        public Bairro()
        {
            cidade = null;
            codigo = "";
        }

        public Bairro(int _id)
        {
            setId(_id);
            alimenta();
            //getNome();
            //getCidade();
            //getCodigo();
        }

        public String getNome()
        {
            if (nome != "")
                return nome;
            return nome;
        }

        public Cidade getCidade()
        {
            if (!cidade.Equals(null))
                return cidade;

            return cidade;
        }

        public String getCodigo()
        {
            if (codigo != "")
                return codigo;
            return codigo;
        }

        public void alimenta()
        {
            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Bairro WHERE id = " + getId() + ";";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    nome = leitor["nome"].ToString();
                    codigo = leitor["id"].ToString();
                    int id_cidade = int.Parse(leitor["id_cidade"].ToString());
                    zona = leitor["zona"].ToString();
                    cidade = new Cidade(id_cidade);
                }
            }
            conexao.Fechar();
        }

        public String getZona() 
        {
            return zona;
        }

        public int getIdPorNome(string nome) 
        {
            int id_bairro = -1;
            
            conexao.Abrir();
            
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT id FROM Bairro WHERE nome = '"+ nome +"';";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    id_bairro = Convert.ToInt32(leitor["id"]);
                }
            }

            conexao.Fechar();

            return id_bairro;

        }


        public override List<Bairro> listAll()
        {
            List<Bairro> all = new List<Bairro>();

            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Bairro;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Bairro b = new Bairro();
                    b.setId(int.Parse(leitor["id"].ToString()));
                    b.nome = leitor["nome"].ToString();
                    b.codigo = leitor["codigo"].ToString();
                    int id_cidade = int.Parse(leitor["id_cidade"].ToString());
                    b.cidade = new Cidade(id_cidade);
                    all.Add(b);
                }
            }
            conexao.Fechar();


            return all;
        }
    }
}
