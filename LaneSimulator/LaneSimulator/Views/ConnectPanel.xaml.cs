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

            //Result = plcCalls.Client.ConnectTo(TxtIP.Text, Rack, Slot);
            var result = _plcCalls.ConnectToPlc(TxtIP.Text, rack, slot);
            if (result == 0)
            {
                DialogResult = true;
                Close();
                MessageBox.Show("cool");
            }
            else
            {
                MessageBox.Show("Not right");
                
            }

        }

        //public  bool ConnectPLC()
        //{

        //    bool connected = false;

        //    int Result;
        //    int Rack = System.Convert.ToInt32(TxtRack.Text);
        //    int Slot = System.Convert.ToInt32(TxtSlot.Text);

        //    Result = Client.ConnectTo(TxtIP.Text, Rack, Slot);
        //    // Make connection with PLC using IP, slot, etc..
        //    if (Result == 0)
        //    {
        //        DialogResult = true;
        //        MessageBox.Show("welcome");
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not right");

        //    }

        //    DialogResult = true;
        //    this.Close();

        //    return connected;
        //} 


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
