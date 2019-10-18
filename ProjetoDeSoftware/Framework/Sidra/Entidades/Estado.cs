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
    public class Estado : Entidade<Estado>
    {
        private String nome, sigla, codigo;

        public Estado() {
            nome = "";
            sigla = "";
            codigo = "";
        }

        public Estado(int _id) {
            setId(_id);
            alimenta();
        }

        public String getNome() {
            if (nome != "")
                return nome;

            return nome;
        }

        public String getSigla()
        {
            if (sigla != "")
                return sigla;

            return sigla;
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

                string sql = "SELECT * FROM Estado WHERE id = " + getId() + ";";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    nome = leitor["nome"].ToString();
                    codigo = leitor["codigo"].ToString();
                    sigla = leitor["sigla"].ToString();
                }
            }
            conexao.Fechar();
        }
 
        public override List<Estado> listAll()
        {
            List<Estado> all = new List<Estado>();

            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Estado;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Estado e = new Estado();
                    e.setId(int.Parse(leitor["id"].ToString()));
                    e.nome = leitor["nome"].ToString();
                    e.codigo = leitor["codigo"].ToString();
                    e.sigla = leitor["sigla"].ToString();
                    all.Add(e);
                }
            }
            conexao.Fechar();
            return all;
        }


    }
}
