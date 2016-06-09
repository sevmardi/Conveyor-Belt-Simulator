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
            //ObjectToMove move = new ObjectToMove();

            Ellipse ellipse = new Ellipse();
          //  ellipse.Fill = Color;
            ellipse.Width = 40.0;
            ellipse.Height = 40.0;
            ellipse.Stroke = (Brush)Brushes.Black;
            ellipse.StrokeThickness = 1.5;


            DoubleAnimationUsingPath path1 = new DoubleAnimationUsingPath();


            this.Animation_Path.Children.Add((UIElement)ellipse);
            Canvas.SetLeft((UIElement)ellipse, 350.0);
            Canvas.SetTop((UIElement)ellipse, 4.0);
            this.Slist.Add(_storyboard);

            _storyboard = this.Slist[this.Slist.Count - 1];

            // storyboard.Completed += new EventHandler(this.storyboard_Completed);

            DoubleAnimation doubleAnimation = new DoubleAnimation(1000, 0.0, (Duration)TimeSpan.FromSeconds(10));


            Storyboard.SetTarget((DependencyObject)doubleAnimation, (DependencyObject)ellipse);
            Storyboard.SetTargetProperty((DependencyObject)doubleAnimation, new PropertyPath((object)Canvas.LeftProperty));

            _storyboard.Children.Add((Timeline)doubleAnimation);

            if (Slist.Count == 0)
            {
                _storyboard.Begin();
            }
            else if (this.Ispaused)
            {
                _storyboard.Begin();
                _storyboard.Pause();
            }
            else
                _storyboard.Begin();


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
