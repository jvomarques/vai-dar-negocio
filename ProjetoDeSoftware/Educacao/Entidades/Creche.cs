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

using ProjetoDeSoftware.Alimentacao.Telas;

using ProjetoDeSoftware.Framework.Sidra.Entidades;

namespace ProjetoDeSoftware.Alimentacao.Entidades
{
    public class Creche
    {
        int mensalidade, numero_alunos, idade_min, idade_max;
        bool religiosa;
        Bairro bairro;

        public Creche(int _mensalidade, int _numero_alunos)
        {
            mensalidade = _mensalidade;
            numero_alunos = _numero_alunos;
        }

        public Creche(int _mensalidade, int _numero_alunos, Bairro _bairro)
        {
            mensalidade = _mensalidade;
            numero_alunos = _numero_alunos;
            bairro = _bairro;
        }

        public int getMensalidade()
        {
            return mensalidade;
        }

        public int getNumeroAlunos()
        {
            return numero_alunos;
        }

        public int getIdadeMin()
        {
            return idade_min;
        }

        public int getIdadeMax()
        {
            return idade_max;
        }

        public bool getReligiosa()
        {
            return religiosa;
        }

        public Bairro getBairro()
        {
            return bairro;
        }
    }
}
