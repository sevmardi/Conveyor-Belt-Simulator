using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObjectToMove _pMove;
        public MainWindow()
        {
            InitializeComponent();

            _pMove = new ObjectToMove();
        }


        private void TestAnimation()
        {
            var sub1 = FindResource("Storyboard1") as Storyboard;

            if (sub1 != null) sub1.Begin(_pMove);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestAnimation();
        }
    }
}
