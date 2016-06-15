using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
        
        public double X { get; set; }
        public double Y { get; set; }
        
        public static DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(Sensor), new PropertyMetadata(new PropertyChangedCallback(SizeChanged)));
       
        public ScaleTransform SensorScaleTransform { get; set; }
        public TranslateTransform SensorTranslateTransform { get; set; }
        public RotateTransform SensorRotateTransform { get; set; }

        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public static void SizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sensor sensor = d as Sensor;
            sensor.Size = (double)e.NewValue;
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
