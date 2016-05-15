using System.Windows;
using System.Windows.Controls;

namespace LaneSimulator.Objects
{
    /// <summary>
    /// Interaction logic for Tray.xaml
    /// </summary>
    public partial class Tray : UserControl
    {

        private Point _position;
        private int _number;

        public Tray()
        {
            InitializeComponent();
        }

        public int GetNumber()
        {
            return _number;
        }

        //public int GetPositionX()
        //{
        //    return _position.X;
        //}

        //public int GetPositionY()
        //{
        //    return _position.Y;
        //}

        public void SetPosition(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public void SetNumber(int number)
        {
            _number = number;
        }

        public void MoveTray(int xDelta, int yDelta)
        {
            _position.X += xDelta;
            _position.Y += yDelta;
        }

        //TODO
        public bool IsColliding(Tray tray)
        {
            bool ret = false;


            return ret;


        }


        //TODO
        public void ResolveCollision(Tray tray)
        {
            //
        }

    }
}
