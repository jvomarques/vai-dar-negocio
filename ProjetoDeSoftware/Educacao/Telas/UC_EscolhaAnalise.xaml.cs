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

namespace ProjetoDeSoftware.Alimentacao.Telas
{
    /// <summary>
    /// Interaction logic for EscolhaAnalisexaml.xaml
    /// </summary>
    public partial class UC_EscolhaAnalise : UserControl
    {
        public UC_EscolhaAnalise()
        {
            InitializeComponent();
            MainWindow.uc_escolha = this;
        }

        private void rt_pesquisabairro_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UC_pesquisar uc_pesquisar = new UC_pesquisar();

            MainWindow.grid_global.Children.Clear();
            MainWindow.grid_global.Children.Add(uc_pesquisar);
        }

        private void rt_pesquisabairro_MouseEnter(object sender, MouseEventArgs e)
        {
            rt_pesquisabairro.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void rt_pesquisabairro_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush borda = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            borda.Opacity = 0;
            rt_pesquisabairro.Stroke = borda;
        }

        private void bt_voltar_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.grid_global.Children.Clear();
            //MainWindow.grid_global = MainWindow.grid_main;
        }


    }
}
