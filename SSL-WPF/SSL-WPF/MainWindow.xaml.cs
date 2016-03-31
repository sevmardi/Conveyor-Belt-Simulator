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

namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayConnectScreen();
        } 

        private void DisplayConnectScreen()
        {
            ConnectPanel connectpanel = new ConnectPanel();

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
