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

using Microsoft.Win32;
using Microsoft.VisualBasic;

using ProjetoDeSoftware.Framework.Mapa;

namespace ProjetoDeSoftware.Alimentacao.Telas
{
    /// <summary>
    /// Interaction logic for UC_maps.xaml
    /// </summary>
    public partial class UC_maps : UserControl
    {
        public UC_maps()
        {
            InitializeComponent();

            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";

            var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            Key.SetValue(appName, 9999, RegistryValueKind.DWord);
            Key.Close();

            List<String> termos = new List<String>();
            termos.Add(MainWindow.negocio_mapa); termos.Add(MainWindow.bairro_mapa); 
            termos.Add(MainWindow.cidade_mapa); 
            termos.Add(MainWindow.estado_mapa);
            navegador_maps.Opacity = 0;
            GoogleMaps.setJanela(ref navegador_maps, termos);

        }
    }
}
