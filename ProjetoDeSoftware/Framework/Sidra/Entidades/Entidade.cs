using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeSoftware.Framework.Sidra.Entidades
{
    public abstract class Entidade <T>
    {
        private int id;
        public Conexao conexao = new Conexao();

        public int getId()
        {
            return id;
        }
        public void setId(int _id)
        {
            id = _id;
        }

        public abstract List<T> listAll();

    }
}
