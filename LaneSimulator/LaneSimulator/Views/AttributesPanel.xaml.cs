using System;
using System.Windows;
using LaneSimulator.Lanes;
using LaneSimulator.PLC;
using Snap7;

namespace LaneSimulator.Views
{
    /// <summary>
    /// Interaction logic for AttributesPanel.xaml
    /// </summary>
    public partial class AttributesPanel
    {
        private readonly PlcCalls _plcCalls;
        private int s;
        private Lanes.LaneTop _laneTop;
        private static readonly byte[] Buffer = new byte[500];


        public AttributesPanel()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
            _laneTop = new LaneTop();
        }

        private void WriteIoBtn(object sender, RoutedEventArgs e)
        {

      //     s = int.Parse(Atri.Text);


            try
            {
                Buffer[0] = Convert.ToByte(Atri.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("shit happens");
            }
          



            // Close();
        }


        public void ShowPanel()
        {
            AttributesPanel atrPanel = new AttributesPanel();
            atrPanel.Show();
        }
    }
}
