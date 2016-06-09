using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gates.Trays
{
    public class SmallTray : AbstractGate
    {

        public override string Name
        {
            get { return "SmallTray"; }
        }

        public override AbstractGate Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Construct a smalltray 
        /// </summary>
        public SmallTray() {}

    }
}
