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
        public MainWindow()
        {
            InitializeComponent();

            //path2.Freeze(); // For performance benefits. 
            //DoubleAnimationUsingPath daPath = new DoubleAnimationUsingPath();
            //daPath.Duration = TimeSpan.FromSeconds(5);
            //daPath.RepeatBehavior = RepeatBehavior.Forever;
            //daPath.AccelerationRatio = 0.6;
            //daPath.DecelerationRatio = 0.4;
            //daPath.AutoReverse = true;
            //daPath.PathGeometry = path2;
            //daPath.Source = PathAnimationSource.X;
            //circle2.BeginAnimation(Canvas.LeftProperty, daPath);

            //daPath = new DoubleAnimationUsingPath();
            //daPath.Duration = TimeSpan.FromSeconds(5);
            //daPath.RepeatBehavior = RepeatBehavior.Forever;
            //daPath.AccelerationRatio = 0.6;
            //daPath.DecelerationRatio = 0.4;
            //daPath.AutoReverse = true;
            //daPath.PathGeometry = path2;
            //daPath.Source = PathAnimationSource.Y;
            //circle2.BeginAnimation(Canvas.TopProperty, daPath);


            var sub = FindResource("Weeeee") as Storyboard;

           

        }
    }
}
