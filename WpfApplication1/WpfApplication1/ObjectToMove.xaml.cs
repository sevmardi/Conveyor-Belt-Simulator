using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ObjectToMove.xaml
    /// </summary>
    public partial class ObjectToMove : INotifyPropertyChanged
    {
        private Point position;
        public ObjectToMove()
        {
            InitializeComponent();  
        }

       
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



        public StoryBoardState GoState
        {
            get { return goState; }
            set { goState = value; }
        }

        
        private StoryBoardState goState = StoryBoardState.Start;


        private StoryBoardState stopState = StoryBoardState.Pause;

        public StoryBoardState StopState
        {
            get { return stopState; }
            set { stopState = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum StoryBoardState { Start, Pause, Stop }
}
