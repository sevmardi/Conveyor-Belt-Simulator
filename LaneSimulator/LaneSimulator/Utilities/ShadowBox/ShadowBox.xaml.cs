using System.Windows.Controls;

namespace LaneSimulator.Utilities.ShadowBox
{
    /// <summary>
    /// The shadow box is a visual wrapper that provides a rounded yellow border
    /// and supports mouse-over fading.
    /// </summary>
    public partial class ShadowBox
    {
        public ShadowBox()
        {
            InitializeComponent();
        }

        public Orientation Orientation
        {

            get
            {
                return SpContent.Orientation;
            }
            set
            {
                SpContent.Orientation = value;
            }
        }

        public UIElementCollection Children
        {
            get
            {
                return SpContent.Children;
            }
        }
    }
}
