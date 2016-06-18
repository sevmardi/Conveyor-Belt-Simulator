using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LaneSimulator.Annotations;

namespace LaneSimulator.UIGates
{
    /// <summary>
    /// Interaction logic for SimpleTray.xaml
    /// </summary>
    public partial class SimpleTray : INotifyPropertyChanged
    {
        public SimpleTray()
        {
            InitializeComponent();   
        }

       

        public double X{ get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public ScaleTransform TrayScaleTransform { get; set; }
        public TranslateTransform TrayTranslateTransform { get; set; }
        public RotateTransform TrayRotateTransform { get; set; }

        public SimpleTray(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point GetPoint()
        {
            return new Point(X, Y);
        }

        public Rect GetRect()
        {
            return new Rect(GetPoint(), new Size(Width, Height));
        }

        public bool IsColliding(SimpleTray other)
        {
            bool ret = false;

            var dX = other.TrayTranslateTransform.X - this.TrayTranslateTransform.X;
            var dY = other.TrayTranslateTransform.Y - this.TrayTranslateTransform.Y;
            var h = Math.Sqrt(dX*dX + dY*dY);

            ret = (h < 40);

            return ret;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
