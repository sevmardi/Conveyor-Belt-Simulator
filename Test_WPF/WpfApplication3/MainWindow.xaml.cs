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

namespace WpfApplication3
{
    //http://stackoverflow.com/questions/3341558/how-can-i-animate-an-image-along-a-circular-path-in-wpf
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
            var sub = FindResource("ellipseSB") as Storyboard;
            if (sub != null)
            {
               sub.Begin();
               

            }
    
        }


        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            var sub = FindResource("ellipseSB") as Storyboard;

            sub.Pause();
        }

        private void DoubleAnimationUsingPath()
        {
            DoubleAnimationUsingPath db = new DoubleAnimationUsingPath();

        }

       
            
    }
}
