using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snap7;

namespace LaneSimulator.PLC
{
    /// <summary>
    /// Class to read/write sensor and motor I/O. 
    /// </summary>
    class PLCAbstract
    {
        public S7Client Client;

        public int Amount = 1;
        public int DbNumber = 0;
        public readonly int Wordlen = S7Client.S7WLBit;
        private readonly byte[] _buffer = new byte[500];
        private int _res;

        public PLCAbstract()
        {
            Client = new S7Client();
        }

        /// <summary>
        /// Write a bit to the PLC sensor 
        /// </summary>
        /// <param name="address"></param>
        public int WriteSensorInput(int address)
        {
            _buffer[0] = 1;
            _res = Client.ReadArea(S7Client.S7AreaPA, DbNumber, address, Amount, Wordlen, _buffer);

            return _res;
        }

        /// <summary>
        /// Read a bit from PLC 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int ReadSensorInput(int address)
        {
            _res = Client.ReadArea(S7Client.S7AreaPA, DbNumber, address, Amount, Wordlen, _buffer);

            return _res;
        }

        /// <summary>
        /// Read Motor Status
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int ReadMotorStatus(int address)
        {
            _res = Client.ReadArea(S7Client.S7AreaPA, DbNumber, address, Amount, Wordlen, _buffer);

            return _res;
        }
    }
}
