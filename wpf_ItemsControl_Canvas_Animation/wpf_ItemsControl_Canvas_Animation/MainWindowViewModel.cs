using System.Collections.ObjectModel;

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
            from.Remove(thing);
            to.Add(thing);
        }
    }
}
