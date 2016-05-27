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
using LaneSimulator.Models.Components;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for LaneTop.xaml
    /// </summary>
    public partial class LaneTop : UserControl
    {
        public LaneTop()
        {
            InitializeComponent();
        }

        private void Total()
        {
           total_text1.Text= (this.tray_Wrap.Children.Count).ToString();
        }

        private void storyboard_Completed()
        {
            this.tray_Wrap.Children.Add((UIElement) new Tray());

        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
