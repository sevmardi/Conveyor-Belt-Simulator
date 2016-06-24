using LaneSimulator.UIGates;

namespace LaneSimulator.Model
{
    public abstract class Behaviour
    {

        public Behaviour()
        {
            
        }

        private void ObjectCollision(object sender)
        {
            
        }

        //TODO: Update the object when about to collide 
        protected virtual void AboutToAttach(SimpleTray simpleTray)
        {
            
        }
        //TODO: Update the object when 
        public void Detach(SimpleTray simpleTray)
        {
            
        }

//        public void SimObjectUpdating(object sender, StateUpdateEventArgs e)
//        {
//            
//        }
       
    }
}
