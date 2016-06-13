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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ObjectToMove.xaml
    /// </summary>
    public partial class ObjectToMove
    {
        private Point position;
        public ObjectToMove()
        {
            InitializeComponent();
        
                
        }

        public bool Go
        {
            get { return (bool)GetValue(GoProperty); }
            set { SetValue(GoProperty, value); }
        }
        public static readonly DependencyProperty GoProperty =
         DependencyProperty.Register("Go", typeof(bool), typeof(ObjectToMove), new PropertyMetadata(false));

        public TranslateTransform TrayTranslateTransform { get; set; }
        public bool IsColliding(ObjectToMove otherSmallTray)
        {
            bool ret = false;

            var dx = otherSmallTray.TrayTranslateTransform.X - TrayTranslateTransform.X;
            var dY = otherSmallTray.TrayTranslateTransform.Y - TrayTranslateTransform.Y;

            var h = Math.Sqrt(dx * dx + dY * dY);

            ret = (h < 40);

            return ret;

        }

        


    }
}
