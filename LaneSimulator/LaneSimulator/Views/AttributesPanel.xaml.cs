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
        private string s;
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

            s = Atri.Text;
            //MessageBox.Show(s);
            if (s == "True")
            {
                Buffer[0] = 1;
                _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
            }
            if (s == "False")
            {
                Buffer[0] = 0;
                _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
            }

            //else
            //{
            //    _laneTop._0102_S1_TurnOff();
            //}
            //try
            //{
            //    Buffer[0] = Convert.ToByte(Atri.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("shit happens");
            //}
          
            // Close();
        }


        public void ShowPanel()
        {
            AttributesPanel atrPanel = new AttributesPanel();
            atrPanel.Show();
        }
    }
}
