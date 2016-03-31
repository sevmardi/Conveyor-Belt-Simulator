using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSL_WPF.MainPanel
{
    /// <summary>
    /// Interaction logic for MainPanel.xaml
    /// </summary>
    public partial class MainPanel : Window
    {
        public static string APP_TITLE;
        public static string APP_VERSION;
        public static string APP_COPYRIGHT;

        public static string LOAD_ON_START = "";
        private ShadowBox sbZoom, sbSpeed, sbGates;

        public MainPanel()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayConnectScreen();
        }

        private void DisplayConnectScreen()
        {
            SSL_WPF.ConnectPanel.ConnectPanel connectpanel = new SSL_WPF.ConnectPanel.ConnectPanel();

            connectpanel.Owner = this;
            connectpanel.ShowDialog();

            if (connectpanel.DialogResult.HasValue && connectpanel.DialogResult.Value)
            {
                MessageBox.Show("Connected!");
            }
            else
                this.Close();
        }

    }
}
