using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LaneSimulator.UIGates
{
    /// <summary>
    /// A graphical wrapper around a single gate; Provides resizing and selection capabilities.
    /// </summary>
    public partial class Gate : UserControl
    {

        private DropShadowEffect glow;
        private bool _sel;
        protected Gates.AbstractGate _gate;

        public Gate()
        {
            InitializeComponent();

            glow = new DropShadowEffect();
            glow.ShadowDepth = 0;
            glow.Color = Colors.Blue;
            glow.BlurRadius = 5;

         //   IsReadOnly = false;
        }


        /// <summary>
        /// Gets or sets if this gate is selected. Note that in this application
        /// the gate canvas also retains a selected list which is used for most
        /// selected decisions.
        /// </summary>
        public bool Selected
        {
            get
            {
                return _sel;
            }
            set
            {
                _sel = value;
                if (value)
                    Effect = glow;
                else
                    Effect = null;
            }
        }

        /// <summary>
        /// The gate "behind" this visual gate
        /// </summary>
        public Gates.AbstractGate AbGate
        {
            get
            {
                return _gate;
            }
        }

        public void Gate_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            topGrid.Width = Width;
            bottomGrid.Width = Width;
            // these last two are still width because they are just rotated
            leftGrid.Width = Height;
            rightGrid.Width = Height;

            SetValue(ExtraWidthProperty, Width - 64.0);
            SetValue(ExtraHeightProperty, Height - 64.0);
        }

        public virtual Gate CreateUserInstance()
        {
            return (Gate)Activator.CreateInstance(GetType());
        }

        public virtual bool IsReadOnly { get; set; }


        protected static readonly DependencyProperty ExtraWidthProperty =
             DependencyProperty.Register("ExtraWidth", typeof(double), typeof(Gate));

        protected static readonly DependencyProperty ExtraHeightProperty =
            DependencyProperty.Register("ExtraHeight", typeof(double), typeof(Gate));




    }
}
