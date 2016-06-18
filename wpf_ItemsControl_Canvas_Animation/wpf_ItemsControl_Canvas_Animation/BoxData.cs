using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace wpf_ItemsControl_Canvas_Animation
{
    public class BoxData : INotifyPropertyChanged
    {
        private StoryBoardState goState = StoryBoardState.Start;

        public StoryBoardState GoState
        {
            get { return goState; }
            set { goState = value; NotifyPropertyChanged(); }
        }

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
    public enum StoryBoardState { Start, Pause, Resume };
}
