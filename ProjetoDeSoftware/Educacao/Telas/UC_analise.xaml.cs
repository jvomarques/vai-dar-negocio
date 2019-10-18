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

using ProjetoDeSoftware.Alimentacao.Entidades;

using ProjetoDeSoftware.Educacao.Telas;


using ProjetoDeSoftware.Framework.Sidra.Entidades;
using ProjetoDeSoftware.Framework.Graficos;


namespace ProjetoDeSoftware.Alimentacao.Telas
{
    /// <summary>
    /// Interaction logic for UC_analise.xaml
    /// </summary>
    public partial class UC_analise : UserControl
    {

        public UC_analise()
        {
            InitializeComponent();
            MainWindow.uc_analise = this;

            if (MainWindow.ehEscola)
            {
                Genero g = new Genero();
                Grafico g_populacao = new Grafico();

                if (MainWindow.ehEscola)
                {
                    g_populacao.setDados("Homens", g.getGeneroPorBairro(MainWindow.escola.getBairro().getId()).getQtdHomem().ToString());
                    g_populacao.setDados("Mulheres", g.getGeneroPorBairro(MainWindow.escola.getBairro().getId()).getQtdMulher().ToString());
                }
                else 
                {
                    g_populacao.setDados("Homens", g.getGeneroPorBairro(MainWindow.creche.getBairro().getId()).getQtdHomem().ToString());
                    g_populacao.setDados("Mulheres", g.getGeneroPorBairro(MainWindow.creche.getBairro().getId()).getQtdMulher().ToString());                
                }
                
                //grafico_pop.DataContext = g_populacao.getGrafico();
                
            }

            SolidColorBrush borda = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            borda.Opacity = 0;
            rt_concorrencia.Stroke = borda;

            analisa();
            
        }

        private void rt_concorrencia_MouseEnter(object sender, MouseEventArgs e)
        {
            rt_concorrencia.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void rt_concorrencia_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush borda = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            borda.Opacity = 0;
            rt_concorrencia.Stroke = borda;

        }

        private void rt_concorrencia_MouseUp(object sender, MouseButtonEventArgs e)
        {
            w_maps w_maps = new w_maps();
            w_maps.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EscolaAnalise controle = new EscolaAnalise();
            controle.getViabilidade(MainWindow.escola);
            int tam = controle.getDicas().Count();

            if (tam > 0) lb_dica1.Content = controle.getDicas()[0] + "\n";
            if (tam > 1) lb_dica1.Content = controle.getDicas()[1] + "\n";
            if (tam > 2) lb_dica1.Content = controle.getDicas()[2] + "\n";
            if (tam > 3) lb_dica1.Content = controle.getDicas()[3] + "\n";
        }

        private void analisa() {
            double viabilidade = 0;
            if (MainWindow.ehEscola)
            {
                EscolaAnalise controle = new EscolaAnalise();
                viabilidade = controle.getViabilidade(MainWindow.escola);
                int tam = controle.getDicas().Count();

                if (tam > 0) lb_dica1.Content = controle.getDicas()[0];
                if (tam > 1) lb_dica2.Content = controle.getDicas()[1];
                if (tam > 2) lb_dica3.Content = controle.getDicas()[2];
                if (tam > 3) lb_dica4.Content = controle.getDicas()[3];
            }
            else {
                CrecheAnalise controle = new CrecheAnalise();
                viabilidade = controle.getViabilidade(MainWindow.creche);
                int tam = controle.getDicas().Count();

                if (tam > 0) lb_dica1.Content = controle.getDicas()[0];
                if (tam > 1) lb_dica2.Content = controle.getDicas()[1];
                if (tam > 2) lb_dica3.Content = controle.getDicas()[2];
                if (tam > 3) lb_dica4.Content = controle.getDicas()[3];
            }
            label_viabilidade.Content = viabilidade.ToString();
        }

        private void bt_voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grid_global.Children.Clear();
            MainWindow.grid_global.Children.Add(MainWindow.uc_pesquisar);
        }

        private void rt_graficos_MouseEnter(object sender, MouseEventArgs e)
        {
            rt_graficos.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void rt_graficos_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush borda = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            borda.Opacity = 0;
            rt_graficos.Stroke = borda;
        }

        private void rt_graficos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            w_graficos w_graficos = new w_graficos();
            w_graficos.ShowDialog();
        }
    }
}
