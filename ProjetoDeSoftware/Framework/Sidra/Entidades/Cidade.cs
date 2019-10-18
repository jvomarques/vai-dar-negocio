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
    public class Cidade : Entidade<Cidade>
    {
        private String nome, codigo;
        private Estado estado;

        public Cidade()
        {
            nome = "";
            estado = null;
            codigo = "";
        }

        public Cidade(int _id)
        {
            setId(_id);
            alimenta();
        }

        public String getNome()
        {
            if (nome != "")
                return nome;

            return nome;
        }

        public Estado getEstado()
        {
            if (!estado.Equals(null))
                return estado;

            return estado;
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

                string sql = "SELECT * FROM Cidade WHERE id = " + getId() + ";";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    nome = leitor["nome"].ToString();
                    codigo = leitor["codigo"].ToString();
                    int id_estado = int.Parse(leitor["id_estado"].ToString());
                    estado = new Estado(id_estado);
                }
            }
            conexao.Fechar();
        }




        public override List<Cidade> listAll()
        {
            List<Cidade> all = new List<Cidade>();

            conexao.Abrir();
            if (conexao.EstaAberta())
            {
                conexao.Abrir();

                string sql = "SELECT * FROM Estado;";

                SQLiteCommand cmd = new SQLiteCommand(sql, conexao.Abrir());

                SQLiteDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    Cidade c = new Cidade();
                    c.setId(int.Parse(leitor["id"].ToString()));
                    c.nome = leitor["nome"].ToString();
                    c.codigo = leitor["codigo"].ToString();
                    int id_estado = int.Parse(leitor["id_estado"].ToString());
                    c.estado = new Estado(id_estado);
                    all.Add(c);
                }
            }
            conexao.Fechar();

            return all;
        }

    }
}
