using System.Windows;
using System.Windows.Controls;

namespace LaneSimulator.UIGates
{
    /// <summary>
    /// Interaction logic for Conveyor_A.xaml
    /// </summary>
    partial class SectionA
    {
        #region attributes

        public static readonly DependencyProperty ForwardDependencyProperty = DependencyProperty.Register("Forward",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));

        public static readonly DependencyProperty BackwardsDependencyProperty = DependencyProperty.Register("Reverse",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));

        public static DependencyProperty MaxSpeeDependencyProperty = DependencyProperty.Register("MaxSpeed",
            typeof(double), typeof(SectionA), new PropertyMetadata(new PropertyChangedCallback(MaxSpeedChanged)));

        double maxSpeed = 20.0;

        #endregion

        #region ctor
        public SectionA()
        {
            InitializeComponent();

            Speed = 5.0;
        }
        #endregion
       
        #region properties
        public double MaxSpeed
        {
            get { return (double)GetValue(MaxSpeeDependencyProperty); }
            set { SetValue(MaxSpeeDependencyProperty, value); }
        }

        public bool Forward
        {
            get { return (bool)GetValue(ForwardDependencyProperty); }
            set { SetValue(ForwardDependencyProperty, value); }
        }

        public bool Reverse
        {
            get { return (bool)GetValue(BackwardsDependencyProperty); }
            set { SetValue(BackwardsDependencyProperty, value); }
        }

        public double Speed { get; set; }
        #endregion

        #region methods

        #endregion

        #region events
        public static void MaxSpeedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SectionA sectionA = d as SectionA;
            if (sectionA != null) sectionA.MaxSpeed = (double)e.NewValue;
        }

        #endregion
    }
}
