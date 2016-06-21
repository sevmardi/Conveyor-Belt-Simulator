using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication3
{
    //http://stackoverflow.com/questions/3341558/how-can-i-animate-an-image-along-a-circular-path-in-wpf
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
       

        public MainWindow()
        {
           
            InitializeComponent();
    
        }

        public static double GetMovingObjectPos(DependencyObject obj)
        {
            return (double)obj.GetValue(MovingObjectPosProperty);
        }

        public static void SetMovingObjectPos(DependencyObject obj, double value)
        {
            obj.SetValue(MovingObjectPosProperty, value);
        }

        // Using a DependencyProperty as the backing store for MovingObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MovingObjectPosProperty =
            DependencyProperty.RegisterAttached("MovingObjectPos", typeof(double), typeof(MainWindow), new PropertyMetadata(0.0, new PropertyChangedCallback(MovingObjectPosChanged)));


        private static void MovingObjectPosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double leftOfMovingObject = (double)e.NewValue;
            Path beam = (Path)d;

            System.Diagnostics.Debug.WriteLine("Left = " + e.NewValue.ToString());

            double leftOfBeam = Canvas.GetLeft(beam);
            double widthOfBeam = 20.0;

            if (leftOfMovingObject > leftOfBeam && leftOfMovingObject < leftOfBeam + widthOfBeam)
            {
                System.Diagnostics.Debug.WriteLine("Hit >>>>> = " + e.NewValue.ToString());

                beam.Fill = Brushes.Gray;
            }
        }


















        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Control box = new Control { Template = (ControlTemplate)Resources["RectangleTemplate"] };
           // root.Children.Add(box);
            timer();
            
        }

        private void timer()
        {

            Timer tr = new Timer();

            tr.Interval = 2500;
            tr.Elapsed += new ElapsedEventHandler(rectanglebuild);
            tr.Enabled = true;
        }

        private void rectanglebuild(object sender, ElapsedEventArgs e)
        {
       

            Application.Current.Dispatcher.Invoke((Action)delegate
            {

                Control box = new Control { Template = (ControlTemplate)Resources["RectangleTemplate"] };
                //root.Children.Add(box);

            });

        }
        static int count = 0;


        



    }
}
