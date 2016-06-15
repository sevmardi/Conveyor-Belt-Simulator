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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Storyboard> Slist = new List<Storyboard>();
        private bool Ispaused = false;
        private Storyboard _storyboard;

        public MainWindow()
        {
            InitializeComponent();
            _storyboard = new Storyboard();
        }

        private void AddAnimation()
        {
           

        }

        private void storyboard_Completed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ObjectToMove move = new ObjectToMove();







            Animation_Path.Children.Add((UIElement)move);
     


        }



        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
           SetStoryBoardActivity(Ispaused);
        }

        private void SetStoryBoardActivity(bool play)
        {
            if (play)
            {
                _storyboard.Resume(this);
            }
            else
            {
                _storyboard.Pause(this);
            }
        }
    }
}
