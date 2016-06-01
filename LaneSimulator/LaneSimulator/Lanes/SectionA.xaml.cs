using System.Windows.Controls;
using LaneSimulator.PLC;
using Snap7;
using System.Timers;
using System;
using System.Windows.Media;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for SectionA.xaml
    /// </summary>
    public partial class SectionA
    {
        private static int _res;
        private static readonly byte[] Buffer = new byte[500];
        private readonly PlcCalls _plcCalls;
        MainWindow main;


        public SectionA()
        {
            InitializeComponent();
           
        }


        public void Executor()
        {
           // _0102_S1Read();
            //SecondSensorTimer();
            //ThirdSensor();
            //FourthSensor();
            //FifthSensor();
            //SixthSensor();
        }


 

      








  










    }
}
