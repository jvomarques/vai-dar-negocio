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


namespace ProjetoDeSoftware.Alimentacao.Telas
{
    /// <summary>
    /// Interaction logic for UC_pesquisar.xaml
    /// </summary>
    public partial class UC_pesquisar : UserControl
    {

        List<Bairro> bairros = (new Bairro()).listAll();
        Idade idade = new Idade();
        bool ehReligiosa;
        List<int> lista_idades_piso = new List<int>();
        List<int> lista_idades_teto = new List<int>();

        public UC_pesquisar()
        {
            InitializeComponent();

            MainWindow.uc_pesquisar = this;

            //DESABILITANDO CHECK_BOX
            check_alfabetizacao.IsEnabled = false;
            check_fundamental1.IsEnabled = false;
            check_fundamental2.IsEnabled = false;
            check_medio.IsEnabled = false;

            cb_tiponegocio.Items.Add("Creche");
            cb_tiponegocio.Items.Add("Escola");
            
            Estado estado = new Estado(1);
            cb_estado.Items.Add(estado.getSigla());

            Cidade cidade = new Cidade(1);
            cb_cidade.Items.Add(cidade.getNome());

            foreach (Bairro b in bairros)
                cb_bairro.Items.Add(b.getNome());
        }

        private void bt_verificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lista_idades_piso.Clear();
                lista_idades_teto.Clear();
                
                MainWindow.estado_mapa = cb_estado.SelectedValue.ToString();
                MainWindow.cidade_mapa = cb_cidade.SelectedValue.ToString();
                MainWindow.bairro_mapa = cb_bairro.SelectedValue.ToString();
                MainWindow.negocio_mapa = cb_tiponegocio.SelectedValue.ToString();

                if (cb_tiponegocio.SelectedValue.ToString() == "Escola")
                {
                    MainWindow.ehEscola = true;
                    MainWindow.ehCreche = false;
                    Bairro bairro = bairros[cb_bairro.SelectedIndex];

                    int idade_inicio, idade_fim;

                    if (check_alfabetizacao.IsChecked == true)
                    {
                        lista_idades_piso.Add(4);
                        lista_idades_teto.Add(6);
                    }

                    if (check_fundamental1.IsChecked == true)
                    {
                        lista_idades_piso.Add(6);
                        lista_idades_teto.Add(11);
                    }

                    if (check_fundamental2.IsChecked == true)
                    {
                        lista_idades_piso.Add(11);
                        lista_idades_teto.Add(16);
                    }

                    if (check_medio.IsChecked == true) 
                    {
                        lista_idades_piso.Add(16);
                        lista_idades_teto.Add(19);
                    }

                    idade_inicio = lista_idades_piso[0];
                    for (int i = 0; i < lista_idades_piso.Count; i++)
                    {
                        if (lista_idades_piso[i] < idade_inicio)
                            idade_inicio = lista_idades_piso[i];
                    }

                    idade_fim = lista_idades_teto[0];
                    for (int i = 0; i < lista_idades_teto.Count; i++)
                    {
                        if (lista_idades_teto[i] > idade_fim)
                            idade_fim = lista_idades_teto[i];
                    }

                    MainWindow.escola = new Escola(Convert.ToInt32(tb_mensalidade.Text), Convert.ToInt32(tb_numeroalunos.Text), idade_inicio, idade_fim, ehReligiosa, bairro);
                }
                else if (cb_tiponegocio.SelectedValue.ToString() == "Creche")
                {
                    MainWindow.ehCreche = true;

                    MainWindow.ehEscola = false;
                    Bairro bairro = bairros[cb_bairro.SelectedIndex];

                    MainWindow.creche = new Creche(Convert.ToInt32(tb_mensalidade.Text), Convert.ToInt32(tb_numeroalunos.Text), bairro);
                }

                UC_analise uc_analise = new UC_analise();
                MainWindow.grid_global.Children.Clear();
                MainWindow.grid_global.Children.Add(uc_analise);
            }
            catch 
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            ehReligiosa = true;
        }

        private void rb_nao_Checked(object sender, RoutedEventArgs e)
        {
            ehReligiosa = false;
        }

        private void cb_estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_cidade.IsEnabled = true;
        }

        private void cb_cidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_bairro.IsEnabled = true;
        }

        private void bt_voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grid_global.Children.Clear();
            MainWindow.grid_global.Children.Add(MainWindow.uc_escolha);
        }

        private void cb_tiponegocio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cb_tiponegocio.SelectedValue.ToString() == "Escola")
            {
                check_alfabetizacao.IsEnabled = true;
                check_fundamental1.IsEnabled = true;
                check_fundamental2.IsEnabled = true;
                check_medio.IsEnabled = true;
            }
            else 
            {
                check_alfabetizacao.IsEnabled = false;
                check_fundamental1.IsEnabled = false;
                check_fundamental2.IsEnabled = false;
                check_medio.IsEnabled = false;
            }

        }

        private void check_fundamental1_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (check_alfabetizacao.IsChecked == true)
            {
                MessageBox.Show("OI");
            }
            else
                MessageBox.Show("AAA");
        }
    }
}
