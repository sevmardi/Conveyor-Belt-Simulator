using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaneSimulator.Models.Components
{
    /// <summary>
    /// Interaction logic for Tray.xaml
    /// </summary>
    public partial class Tray : UserControl
    {
      
        public Tray()
        {
            InitializeComponent();           
        }

        public double Acceleration
        {
            get; set;
            
        }

        public double speed
        {
            get; set;
            
        }

        public TranslateTransform TrayTranslateTransform { get; set; }


        public bool IsColliding(Tray otherTray)
        {
            bool ret = false;

            var dx = otherTray.TrayTranslateTransform.X - TrayTranslateTransform.X;
            var dY = otherTray.TrayTranslateTransform.Y - TrayTranslateTransform.Y;

            var h = Math.Sqrt(dx*dx + dY*dY);

            ret = (h < 40);

            return ret;
        }

        public void RresolveCollision(Tray other)
        {
            //
        }


    }
}
