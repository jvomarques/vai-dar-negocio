using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;

namespace ProjetoDeSoftware.Framework.Sidra.Entidades
{
    public class Conexao
    {
        private SQLiteConnection sqlite_conn;

        public SQLiteConnection Abrir()
        {
            if (sqlite_conn == null)
            {
                sqlite_conn = new SQLiteConnection("Data Source=framework.sqlite;Version=3;New=false;Compress=True;");

            }
            if (sqlite_conn.State == System.Data.ConnectionState.Closed)
            {
                sqlite_conn.Open();
            }

            return sqlite_conn;
        }

        public void Fechar()
        {
            if (sqlite_conn != null && sqlite_conn.State != System.Data.ConnectionState.Closed)
            {

                sqlite_conn.Close();
            }
        }

        public bool EstaAberta()
        {
            if (sqlite_conn == null)
            {
                return false;
            }
            else
            {
                if (sqlite_conn.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
