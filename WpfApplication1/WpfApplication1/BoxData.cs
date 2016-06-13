using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace WpfApplication1
{
    public class BoxData : INotifyPropertyChanged
    {
        private StoryBoardState goState = StoryBoardState.Start;


        public StoryBoardState GoState
        {
            get { return goState; }
            set { goState = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum StoryBoardState { Start, Pause, Resume };
}
