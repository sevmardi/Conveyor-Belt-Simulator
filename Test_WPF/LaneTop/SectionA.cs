using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snap7;

namespace LaneTop
{
    
    class SectionA
    {
        private static int _res;
        private static readonly byte[] Buffer = new byte[500];
        private static LaneAnimation _laneanimatin;

        /// <summary>
        /// Check if motor is working, otherwise stop the object. 
        /// </summary>
        public static bool motor1()
        {
            bool _0102_D1 = true;

            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0102_D1, PlcCalls.Amount, PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    _laneanimatin.SB.Pause();
                }

            }

            return _0102_D1;
        }


  

    }
}
