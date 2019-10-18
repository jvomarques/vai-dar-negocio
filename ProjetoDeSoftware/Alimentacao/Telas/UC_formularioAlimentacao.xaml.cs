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

using ProjetoDeSoftware.Framework.Sidra.Entidades;
using ProjetoDeSoftware.Alimentacao.Entidades;

using ProjetoDeSoftware.Alimentacao.Analisadores;


namespace ProjetoDeSoftware.Alimentacao.Telas.Alimentacao
{
    /// <summary>
    /// Interaction logic for UC_formularioAlimentacao.xaml
    /// </summary>
    public partial class UC_formularioAlimentacao : UserControl
    {
        List<Bairro> bairros = (new Bairro()).listAll();
        bool ehDelivery;
        bool abrangenciaApenasMinhaZona;

        public UC_formularioAlimentacao()
        {
            InitializeComponent();

            ehDelivery = false;
            abrangenciaApenasMinhaZona = false;

            foreach (Bairro b in bairros)
                cb_bairro.Items.Add(b.getNome());
        }

        private void bt_verificar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.estado_mapa = cb_estado.SelectedValue.ToString();
            MainWindow.cidade_mapa = cb_cidade.SelectedValue.ToString();
            MainWindow.bairro_mapa = cb_bairro.SelectedValue.ToString();
            MainWindow.negocio_mapa = cb_tiponegocio.SelectedValue.ToString();
            
            if (cb_tiponegocio.Text == "Restaurante")
            {
                MainWindow.ehRestaurante = true;
                MainWindow.ehLanchonete = false;
                Bairro bairro = bairros[cb_bairro.SelectedIndex];
                MainWindow.ehRestaurante = true;
                MainWindow.restaurante = new Restaurante(Convert.ToDouble(tb_preco_medio.Text), Convert.ToInt32(tb_capacidade.Text), ehDelivery, abrangenciaApenasMinhaZona, bairro);
                
                UC_analiseAlimentacao uc_analise = new UC_analiseAlimentacao();
                MainWindow.grid_global.Children.Clear();
                MainWindow.grid_global.Children.Add(uc_analise);

                RestauranteAnalise analise = new RestauranteAnalise();
                //MessageBox.Show(analise.getNotaPrecoMedioPrato(MainWindow.restaurante).ToString());
            }
            else
            {
                MainWindow.ehRestaurante = false;
                MainWindow.ehLanchonete = true;
                Bairro bairro = bairros[cb_bairro.SelectedIndex];
                MainWindow.ehRestaurante = false;
                MainWindow.lanchonete = new Lanchonete(Convert.ToDouble(tb_preco_medio.Text), Convert.ToInt32(tb_capacidade.Text), ehDelivery, abrangenciaApenasMinhaZona, bairro);

                UC_analiseAlimentacao uc_analise = new UC_analiseAlimentacao();
                MainWindow.grid_global.Children.Clear();
                MainWindow.grid_global.Children.Add(uc_analise);

                LanchoneteAnalise analise = new LanchoneteAnalise();
                MessageBox.Show(analise.getNotaPrecoMedioPrato(MainWindow.lanchonete).ToString());
            }



        }

        private void cb_estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_cidade.IsEnabled = true;
        }

        private void cb_cidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_bairro.IsEnabled = true;
        }

        private void rb_sim_Checked(object sender, RoutedEventArgs e)
        {
            ehDelivery = true;
            rd_apenas_minha_zona.IsEnabled = true;
            rd_cidade_toda.IsEnabled = true;
        }

        private void rb_nao_Checked(object sender, RoutedEventArgs e)
        {
            ehDelivery = false;
            rd_apenas_minha_zona.IsEnabled = false;
            rd_cidade_toda.IsEnabled = false;
        }

        private void rd_apenas_minha_zona_Checked(object sender, RoutedEventArgs e)
        {
            abrangenciaApenasMinhaZona = true;
        }

        private void rd_cidade_toda_Checked(object sender, RoutedEventArgs e)
        {
            abrangenciaApenasMinhaZona = false;
        }

        private void cb_tiponegocio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
