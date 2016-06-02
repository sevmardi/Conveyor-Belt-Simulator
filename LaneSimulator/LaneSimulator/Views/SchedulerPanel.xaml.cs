using System.Windows;
using LaneSimulator.Lanes;
using LaneSimulator.Models.Components;

namespace LaneSimulator.Views
{
    /// <summary>
    /// Presents a dialog which prompts the user to select a number of trays
    /// </summary>
    public partial class SchedulerPanel : Window
    {
        private LaneTop _laneTop;

        public SchedulerPanel()
        {
            InitializeComponent();
            _laneTop = new LaneTop();
         
            // _trays = -1;
        }

        protected int _trays;
        
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _trays = (int) bitSlider.Value;
            test(_trays);
           
             Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Number of trays selected by the user.  This is set when the user
        /// selects OK. .  If the user cancels the dialog, this value is -1.
        /// </summary>
        public int trays
        {
            get { return _trays; }
        }

        public void test(int numberOfTrays)
        {
            //for (int i = 0; i < numberOfTrays; i++)
            //{
            //    Tray tray = new Tray();
            //    _laneTop.AnimationPannel.Children.Add(tray);
            //    _laneTop.sb1.Begin(tray);
            //}
            
            _laneTop.TaskRunner();


            //MessageBox.Show("number of trays is " + numberOfTrays);
    
        }
    }
}
