using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using LaneSimulator.conveyors;

namespace LaneSimulator.UIGates
{
    /// <summary>
    /// Interaction logic for Sensor.xaml
    /// </summary>
    public partial class Sensor
    {
        public Sensor()
        {
            InitializeComponent();
            this.Timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.Timer.Tick += new EventHandler(this.Timer_Tick);
            this.Timer1.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.Timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Image_Off.Opacity < 1.0)
                this.Image_Off.Opacity = this.Image_Off.Opacity + 0.1;
            else
                this.Timer1.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Image_Off.Opacity > 0.0)
            {
                this.Image_Off.Opacity = this.Image_Off.Opacity - 0.1;
            }
            else
            {
                this.Timer.Stop();
                this.Timer1.Start();
            }

        }
        private DispatcherTimer Timer1 = new DispatcherTimer();
        private DispatcherTimer Timer = new DispatcherTimer();
        
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        
 
        public TranslateTransform SensorTranslateTransform { get; set; }


        public Sensor(Point p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }

        public Point GetPoint()
        {
            return new Point(X, Y);
        }

        public Rect GetRect()
        {
            return new Rect(GetPoint(), new Size(Width, Height));

        }


        private void Image_Off_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SetOn();
        }

        public void SetOn()
        {
           Timer1.Stop();
           Timer.Stop();
           Timer.Start();
        }


    }
}
