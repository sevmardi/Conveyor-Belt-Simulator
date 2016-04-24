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

namespace SSL_WPF
{
    /// <summary>
    /// The shadow box is a visual wrapper that provides a rounded yellow border
    /// and supports mouse-over fading.
    /// </summary>
    public partial class ShadowBox : UserControl
    {
        public ShadowBox()
        {
            InitializeComponent();
        }

        public Orientation Orientation
        {
            get
            {
                return spContent.Orientation;
            }
            set
            {
                spContent.Orientation = value;
            }
        }
        public UIElementCollection Children
        {
            get
            {
                return spContent.Children;
            }

        }
    }
}
