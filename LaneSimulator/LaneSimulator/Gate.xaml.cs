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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaneSimulator
{
    /// <summary>
    /// Interaction logic for Gate.xaml
    /// </summary>
    public partial class Gate : UserControl
    {

        private DropShadowEffect glow;
        private bool _sel;


        public Gate()
        {
            InitializeComponent();

            glow = new DropShadowEffect();
            glow.ShadowDepth = 0;
            glow.Color = Colors.Blue;
            glow.BlurRadius = 5;

            IsReadOnly = false;
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
