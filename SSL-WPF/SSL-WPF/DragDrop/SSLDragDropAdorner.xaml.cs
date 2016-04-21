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

// FROM http://blogs.claritycon.com/blogs/lee_roth/archive/2009/03/31/generic-wpf-drag-and-drop-adorner.aspx

namespace SSL_WPF.DragDrop
{
    /// <summary>
    /// Interaction logic for SSLDragDropAdorner.xaml
    /// </summary>
    public partial class SSLDragDropAdorner : DragDropAdornerBase
    {
        public SSLDragDropAdorner()
        {
            InitializeComponent();
        }

        public override void StateChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SSLDragDropAdorner myclass = (SSLDragDropAdorner)d;

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
