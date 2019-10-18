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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ProjetoDeSoftware.Alimentacao.Analisadores;

namespace ProjetoDeSoftware.Alimentacao.Telas
{
    /// <summary>
    /// Interaction logic for UC_analiseAlimentacao.xaml
    /// </summary>
    public partial class UC_analiseAlimentacao : UserControl
    {
        public UC_analiseAlimentacao()
        {
            InitializeComponent();
            analisa();
        }

        private void analisa()
        {
            double viabilidade = 0;
            if (MainWindow.ehRestaurante)
            {
                RestauranteAnalise controle = new RestauranteAnalise();
                viabilidade = controle.getViabilidade(MainWindow.restaurante);
                int tam = controle.getDicas().Count();

                if (tam > 0) lb_dica1.Content = controle.getDicas()[0];
                if (tam > 1) lb_dica2.Content = controle.getDicas()[1];
                if (tam > 2) lb_dica1.Content = controle.getDicas()[2];
                if (tam > 3) lb_dica1.Content = controle.getDicas()[3];
            }
            else
            {
                LanchoneteAnalise controle = new LanchoneteAnalise();
                viabilidade = controle.getViabilidade(MainWindow.lanchonete);
                int tam = controle.getDicas().Count();

                if (tam > 0) lb_dica1.Content = controle.getDicas()[0];
                if (tam > 1) lb_dica2.Content = controle.getDicas()[1];
                if (tam > 2) lb_dica1.Content = controle.getDicas()[2];
                if (tam > 3) lb_dica1.Content = controle.getDicas()[3];
            }
            label_viabilidade.Content = viabilidade.ToString();
        }

        private void rt_concorrencia_MouseUp(object sender, MouseButtonEventArgs e)
        {
            w_maps w_maps = new w_maps();
            w_maps.ShowDialog();
        }

    }
}
