using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaneSimulator.Models.Components
{
    /// <summary>
    /// Interaction logic for SmallTray.xaml
    /// </summary>
    public partial class SmallTray : UserControl
    {
      
        public SmallTray()
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


        public bool IsColliding(SmallTray otherSmallTray)
        {
            bool ret = false;

            var dx = otherSmallTray.TrayTranslateTransform.X - TrayTranslateTransform.X;
            var dY = otherSmallTray.TrayTranslateTransform.Y - TrayTranslateTransform.Y;

            var h = Math.Sqrt(dx*dx + dY*dY);

            ret = (h < 40);

            return ret;
        }

        public void RresolveCollision(SmallTray other)
        {
            //
        }


    }
}
