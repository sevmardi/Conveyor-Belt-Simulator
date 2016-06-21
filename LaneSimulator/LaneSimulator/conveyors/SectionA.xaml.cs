
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using LaneSimulator.Annotations;
using LaneSimulator.PLC;
using Snap7;

namespace LaneSimulator.conveyors
{
    /// <summary>
    /// Interaction logic for Conveyor_A.xaml
    /// </summary>
    partial class SectionA : INotifyPropertyChanged
    {

        #region attributes
        
       
         private int _res;

        public static readonly DependencyProperty ForwardDependencyProperty = DependencyProperty.Register("Forward",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));

        public static readonly DependencyProperty BackwardsDependencyProperty = DependencyProperty.Register("Reverse",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));


     

        #endregion

        #region ctor
        public SectionA()
        {
            InitializeComponent();
           
            
        }
        #endregion
       
        #region properties


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
        public double Acceleration { get; set; }
        #endregion

       


       





    

        #region events


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
