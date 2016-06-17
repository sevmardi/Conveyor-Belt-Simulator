using System.Windows;
using LaneSimulator.PLC;

namespace LaneSimulator.Views
{
    /// <summary>
    /// Interaction logic for ConnectPanel.xaml
    /// </summary>
    public partial class ConnectPanel
    {
        private readonly PlcCalls _plcCalls;
        
        public ConnectPanel()
        {
            _plcCalls = new PlcCalls();
            InitializeComponent();
            
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Make connection with PLC using IP, slot, etc..
            int rack = System.Convert.ToInt32(TxtRack.Text);
            int slot = System.Convert.ToInt32(TxtSlot.Text);

             _plcCalls.ConnectToPlc(TxtIP.Text, rack, slot);
            
            if (_plcCalls.Client.Connected())
            {
                DialogResult = true;
                
                Close();
               // _plcCalls.StartUp();  
            }

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
