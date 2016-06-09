using System.Windows;
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


        private static readonly byte[] Buffer = new byte[500];


        public AttributesPanel()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
        }

        private void WriteIoBtn(object sender, RoutedEventArgs e)
        {
            _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Close();
        }
    }
}
