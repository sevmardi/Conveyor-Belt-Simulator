﻿using System.Windows;
using LaneSimulator.Lanes;

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


        /// <summary>
        /// Number of trays selected by the user.  This is set when the user
        /// selects OK. .  If the user cancels the dialog, this value is -1.
        /// </summary>
        public int trays
        {
            get { return _trays; }
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _trays = (int) bitSlider.Value;
             Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
