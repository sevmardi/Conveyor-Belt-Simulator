using System.Windows.Media.Animation;
using LaneSimulator.Lanes;

namespace LaneSimulator.Conveyor
{
    class SimulationAnimation
    {
        private LaneTop _laneTop;
        public SimulationAnimation()
        {
            _laneTop = new LaneTop();
        }
        
        // from https://blogs.msdn.microsoft.com/silverlight_sdk/2008/03/26/target-multiple-objects-with-one-animation-silverlight/
        bool storyboard1Active = false;
        bool storyboard2Active = false;
        bool storyboard3Active = false;

        public void Start_Animation()
        {
            if (!storyboard1Active)
            {
                
            }
        }

        private void storboard1()
        {
            var sub1 = _laneTop.TryFindResource("Storyboard1") as Storyboard;

            sub1.Begin();
        }

    }
}
