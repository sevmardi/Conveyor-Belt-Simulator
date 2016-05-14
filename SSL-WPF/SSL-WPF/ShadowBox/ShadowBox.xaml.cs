using System.Windows.Controls;

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
