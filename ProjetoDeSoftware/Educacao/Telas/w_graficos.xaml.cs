using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using ProjetoDeSoftware.Framework.Graficos;
using ProjetoDeSoftware.Framework.Sidra.Entidades;


namespace ProjetoDeSoftware.Educacao.Telas
{
    /// <summary>
    /// Interaction logic for w_graficos.xaml
    /// </summary>
    public partial class w_graficos : Window
    {
        public w_graficos()
        {
            InitializeComponent();

            if (MainWindow.ehEscola)
            {
                Grafico g = new Grafico();
                Renda r = new Renda();
                int mensalidade = Convert.ToInt32(MainWindow.renda_bairro*0.15);

                g.setDados("Mensalidade ideal", Convert.ToString(mensalidade));
                g.setDados("Sua mensalidade", MainWindow.escola.getMensalidade().ToString());

                grafico_mensalidade.DataContext = g.getGrafico();
            }
            else if (MainWindow.ehCreche)
            {
                Grafico g = new Grafico();
                Renda r = new Renda();
                int mensalidade = Convert.ToInt32(MainWindow.renda_bairro * 0.15);

                g.setDados("Mensalidade ideal", Convert.ToString(mensalidade));
                g.setDados("Sua mensalidade", MainWindow.creche.getMensalidade().ToString());

                grafico_mensalidade.DataContext = g.getGrafico();
            }


        }
    }
}
