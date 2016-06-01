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
            ObjectToMove move = new ObjectToMove();
            
            //Ellipse ellipse = new Ellipse();
            //ellipse.Fill = Color;
            //ellipse.Width = 40.0;
            //ellipse.Height = 40.0;
            //ellipse.Stroke = (Brush)Brushes.Black;
            //ellipse.StrokeThickness = 1.5;


            DoubleAnimationUsingPath path1 = new DoubleAnimationUsingPath();


            this.Animation_Path.Children.Add((UIElement)move);
            Canvas.SetLeft((UIElement)move, 220.0);
            Canvas.SetTop((UIElement)move, 4.0);
            this.Slist.Add(_storyboard);





            _storyboard = this.Slist[this.Slist.Count - 1];

           // storyboard.Completed += new EventHandler(this.storyboard_Completed);

            DoubleAnimation doubleAnimation = new DoubleAnimation(500, 0.0, (Duration)TimeSpan.FromSeconds(10));


            Storyboard.SetTarget((DependencyObject)doubleAnimation, (DependencyObject)move);
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

        private void storyboard_Completed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
          AddAnimation();
           // testingmethodonmsdn();
        }



        private void testingmethodonmsdn()
        {
            NameScope.SetNameScope(this, new NameScope());

            EllipseGeometry animatedEllipseGeometry =
             new EllipseGeometry(new Point(10, 100), 15, 15);

            this.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry);

            Path ellipsePath = new Path();
            ellipsePath.Data = animatedEllipseGeometry;
            ellipsePath.Fill = Brushes.Blue;
            ellipsePath.Margin = new Thickness(15);

            Canvas mainPanel = new Canvas();
            mainPanel.Width = 400;
            mainPanel.Height = 400;
            mainPanel.Children.Add(ellipsePath);
            this.Content = mainPanel;

            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(10, 100);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(35, 0));
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(160, 100));
            pBezierSegment.Points.Add(new Point(180, 190));
            pBezierSegment.Points.Add(new Point(285, 200));
            pBezierSegment.Points.Add(new Point(310, 100));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation = new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);
            centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;



            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);

            // Start the Storyboard when ellipsePath is loaded.
            ellipsePath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };


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
