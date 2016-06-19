using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LaneSimulator.Annotations;

namespace LaneSimulator.UIGates
{
    /// <summary>
    /// Interaction logic for SimpleTray.xaml
    /// </summary>
    public partial class SimpleTray : INotifyPropertyChanged
    {
        public SimpleTray()
        {
            InitializeComponent();   
        }

        private StoryBoardState _starteState = StoryBoardState.Start;
        private StoryBoardState _resumeState = StoryBoardState.Resume;


        public StoryBoardState StartState
        {
            get { return _starteState; }
            set { _starteState = value; NotifyPropertyChanged(); }
        }



        public double X{ get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public ScaleTransform TrayScaleTransform { get; set; }
        public TranslateTransform TrayTranslateTransform { get; set; }
        public RotateTransform TrayRotateTransform { get; set; }

        public SimpleTray(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point GetPoint()
        {
            return new Point(X, Y);
        }

        public Rect GetRect()
        {
            return new Rect(GetPoint(), new Size(Width, Height));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public enum StoryBoardState
    {
        Start, 
        Pause,
        Resume
    }
}
