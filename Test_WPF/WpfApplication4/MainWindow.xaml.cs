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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4
{//http://www.codeproject.com/Questions/275857/Animate-objects-through-path-AND-in-steps
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sb1"];
            sb.Begin();
        }

        private void StopBtn(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sb1"];
            sb.Pause();
        }


    }
}
