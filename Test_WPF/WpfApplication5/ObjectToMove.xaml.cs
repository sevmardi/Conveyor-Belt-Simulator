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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for ObjectToMove.xaml
    /// </summary>
    public partial class ObjectToMove : UserControl
    {
        private Point position;
        private int destination; 

        public ObjectToMove()
        {
            InitializeComponent();
            this.position = position;
        }

        
        public int getDestination()
        {
            return this.destination;
        }


        public void setPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }
        public void setDestination(int destination)
        {
            this.destination = destination;
        }

    }
}
