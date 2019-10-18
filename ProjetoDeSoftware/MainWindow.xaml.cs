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

using ProjetoDeSoftware.Alimentacao.Telas.Alimentacao;

using ProjetoDeSoftware.Alimentacao.Telas;
using ProjetoDeSoftware.Alimentacao.Entidades;

using ProjetoDeSoftware.Framework.Graficos;
using ProjetoDeSoftware.Framework.Sidra.Entidades;

namespace ProjetoDeSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Grid grid_global = new Grid();
        public static String estado_mapa, cidade_mapa, bairro_mapa, negocio_mapa;
        public static Escola escola = new Escola(-1, -1, -1, -1, false, null);
        public static Creche creche = new Creche(-1, -1, null);
        public static Restaurante restaurante = new Restaurante(-1.0, -1, false, false, null);
        public static Lanchonete lanchonete = new Lanchonete(-1.0, -1, false, false, null);
        public static bool ehEscola = false;
        public static bool ehRestaurante = false;
        public static bool ehCreche = false;
        public static bool ehLanchonete = false;


        public static double renda_bairro;


        public static UC_analise uc_analise;
        public static UC_EscolhaAnalise uc_escolha;
        public static UC_pesquisar uc_pesquisar;

        public MainWindow()
        {
            InitializeComponent();
            Religiao a = new Religiao();
            a.setProporcoes();
            //MessageBox.Show(a.getPercentualCatolico().ToString());

            /*Grafico g_populacao = new Grafico();
            g_populacao.setDados("Homens", "100");
            g_populacao.setDados("Mulheres", "50");
            grafico_pop.DataContext = g_populacao.getGrafico();*/

            grid_global = g_global;
            Conexao con = new Conexao();
            con.Abrir();
        }

        private void bt_educacao_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void bt_educacao_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void bt_educacao_Click(object sender, RoutedEventArgs e)
        {
            //UC_EscolhaAnalise uc_escolhaanalise = new UC_EscolhaAnalise();
            UC_pesquisar uc_pesquisar = new UC_pesquisar();
            grid_global.Children.Clear();
            grid_global.Children.Add(uc_pesquisar);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            UC_formularioAlimentacao uc_formulario = new UC_formularioAlimentacao();

            grid_global.Children.Clear();
            grid_global.Children.Add(uc_formulario);
        }


    }
}
