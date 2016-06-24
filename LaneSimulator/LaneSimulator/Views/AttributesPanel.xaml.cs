using System.Windows;
using LaneSimulator.PLC;

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

        public void WriteIoBtn(object sender, RoutedEventArgs e)
        {
            //Atri.Text 

            
        }
    }
}
