using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using LaneSimulator.UIGates;

namespace LaneSimulator.Model
{
    class ViewModel
    {
        public ViewModel()
        {
            FirstSection = new ObservableCollection<SimpleTray> { new SimpleTray() };
            ApprovedCollection = new ObservableCollection<SimpleTray>{new SimpleTray() };
            NotApproveCollection = new ObservableCollection<SimpleTray>{new  SimpleTray()};
        }

        public ObservableCollection<SimpleTray> FirstSection { get; set; }
        public ObservableCollection<SimpleTray> ApprovedCollection { get; set; }
        public ObservableCollection<SimpleTray> NotApproveCollection { get; set; }

        private RelayCommand<StoryBoardState> _changeStartCommand;

        public RelayCommand<StoryBoardState>ChangeStartCommand  
        {
            get
            {
                return _changeStartCommand
                  ?? (_changeStartCommand = new RelayCommand<StoryBoardState>(
                    go =>
                    {
                        foreach (SimpleTray b in FirstSection)
                        {
                            b.StartState = go;
                        };
                    }));
            }
        }
    }
}
