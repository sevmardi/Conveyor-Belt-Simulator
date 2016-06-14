using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gates.Trays
{
    public class LargeTray : AbstractGate
    {

        public override string Name
        {
            get { return "LargeTray"; }
        }

        public override AbstractGate Clone()
        {
            return Clone();
        }

        /// <summary>
        /// construcotr 
        /// </summary>
        public LargeTray(){}
    }
}
