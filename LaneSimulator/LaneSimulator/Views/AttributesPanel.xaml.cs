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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        int amount = 1;
        int DBNumber = 0;
        int area;
        int wordlen = S7Client.S7WLBit;
        private static readonly byte[] Buffer = new byte[500];
        private static int _res;

        public AttributesPanel()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
        }

        private void WriteIOBtn(object sender, RoutedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Close();
        }

        
        
    }
}
