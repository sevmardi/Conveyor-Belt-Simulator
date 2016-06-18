using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace wpf_ItemsControl_Canvas_Animation
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ItemsA = new ObservableCollection<BoxData> { new BoxData() };
            
            ItemsB = new ObservableCollection<BoxData> { new BoxData() };
        }

        public ObservableCollection<BoxData> ItemsA { get; set; }
       
        public ObservableCollection<BoxData> ItemsB { get; set; }


        public void NextAnimation(ObservableCollection<BoxData> from,ObservableCollection<BoxData> to,BoxData thing)
        {
 if (thing.GoState != StoryBoardState.Start)
                return;   
            from.Remove(thing);
            to.Add(thing);
        }
        private RelayCommand<StoryBoardState> _changeAGoCommand;
        public RelayCommand<StoryBoardState> ChangeAGoCommand
        {
            get
            {
                return _changeAGoCommand
                  ?? (_changeAGoCommand = new RelayCommand<StoryBoardState>(
                    go =>
                    {
                        foreach (BoxData b in ItemsA)
                        {
                            b.GoState = go;
                        };
                    }));
            }
        }
    }
}
