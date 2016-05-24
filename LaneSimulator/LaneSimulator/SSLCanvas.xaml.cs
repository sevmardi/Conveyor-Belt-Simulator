using System;

using System.Globalization;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Threading;
namespace LaneSimulator
{
    /// <summary>
    /// Interaction logic for SSLCanvas.xaml
    /// </summary>
    public partial class SSLCanvas : UserControl
    {
        private DragState dragging = DragState.NONE;

        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;
        public DispatcherTimer Timer1 = new DispatcherTimer();
        private double T = 0.0;
        public SSLCanvas()
        {
            InitializeComponent();
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        protected enum DragState
        {
            NONE, MOVE
        }


        public void Scroller_LayoutUpdated(object sender, EventArgs e)
        {
            //

        }
        private void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //
        }

        private void Scroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void SizeCanvas()
        {
            //    
        }

        public bool DisableSizeCanvas { get; set; }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",
                (IFormatProvider)CultureInfo.InvariantCulture);
        }


    }
}
