using System.Windows;
using System.Windows.Media;

namespace LaneSimulator.Utilities.DragDrop
{
    /// <summary>
    /// Interaction logic for ObjectDragDropAdorner.xaml
    /// </summary>
    public partial class ObjectDragDropAdorner : DragDropAdornerBase
    {
        public ObjectDragDropAdorner()
        {
            InitializeComponent();
        }

        public override void StateChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ObjectDragDropAdorner myclass = (ObjectDragDropAdorner)d;

            switch ((DropState)e.NewValue)
            {
                case DropState.CanDrop:
                    myclass.back.Stroke = Resources["canDropBrush"] as SolidColorBrush;
                    myclass.indicator.Source = Resources["dropIcon"] as DrawingImage;
                    break;
                case DropState.CannotDrop:
                    myclass.back.Stroke = Resources["solidRed"] as SolidColorBrush;
                    myclass.indicator.Source = Resources["noDropIcon"] as DrawingImage;
                    break;
            }

        }

    }
}
