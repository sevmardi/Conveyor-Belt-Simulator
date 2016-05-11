using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Snap7;

namespace PLC
{
    internal class Calls
    {
        //** Snap7 client library **//
        public static S7Client Client;

        public const int Amount = 1;
        public const int DbNumber = 0;
        public static readonly int Wordlen = S7Client.S7WLBit;
        private static readonly byte[] Buffer = new byte[500];
        private static int _res;


        static readonly S7Client.S7DataItem[] Items = new S7Client.S7DataItem[20];

        /// <summary>
        /// Establish connection
        /// </summary>
        public static void EstablishContact()
        {
            Client = new S7Client();
            Client.ConnectTo("192.168.2.16", 0, 0);

            MessageBox.Show(Client.Connected() ? "Connection Established" : "Something went wrong");
        }

        /// <summary>
        /// Disconnect from PLC 
        /// </summary>
        public static void Disconnect()
        {
            Client.Disconnect();
            Client = null;
            MessageBox.Show("cool man, we're good");
        }

        /// <summary>
        /// Start the system by setting the press button either True or False
        /// </summary>
        public static void StartBtnInput()
        {
            _res = Client.WriteArea(S7Client.S7AreaPE, DbNumber, Tags.StartButtonInput, Amount, Wordlen, Buffer);
            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, Tags.StartButtonInput, Amount, Wordlen, Buffer);
                }
                else
                {
                    Buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, Tags.StartButtonInput, Amount, Wordlen, Buffer);
                }
            }

        }


        /// <summary>
        /// Stop the system by either setting true or false 
        /// </summary>
        public static void StopBtnInput()
        {
            _res = Client.ReadArea(S7Client.S7AreaPE, DbNumber, Tags.StopButtonInput, Amount, Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, Tags.StopButtonInput, Amount, Wordlen, Buffer);
                }
                else
                {
                    Buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, Tags.StopButtonInput, Amount, Wordlen, Buffer);
                }
            }
        }

        /// <summary>
        /// RESET System
        /// </summary>
        public static void ResetBtn()
        {
            _res = Client.ReadArea(S7Client.S7AreaMK, DbNumber, Tags.ResetButtonMerker, Amount, Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaMK, DbNumber, Tags.ResetButtonMerker, Amount, Wordlen, Buffer);
                }
                else
                {
                    Buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaMK, DbNumber, Tags.ResetButtonMerker, Amount, Wordlen, Buffer);
                }
            }
        }


        #region Startup

        /// <summary>
        /// The first startup in which amount of Inputs & meker(s) are set to true, this to avoid
        /// any headahcs during simulation 
        /// </summary>
        public static void StartUp()
        {
            GCHandle myGcHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            IntPtr startupPtr = myGcHandle.AddrOfPinnedObject();

            Buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = Tags.NoodstopReclaimerInput;
            Items[0].pData = startupPtr;

            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = Tags.NoodstopDivestInput;
            Items[1].pData = startupPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = Tags.NoodstopXrayInput;
            Items[2].pData = startupPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = Tags.SwitchDegradedModeInput;
            Items[3].pData = startupPtr;

            _res = Client.WriteMultiVars(Items, 20);
        }

        #endregion



        public static void AllSensorsOnTrue()
        {
            GCHandle myGcHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            Buffer[0] = 1;


            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = Tags._0102_S1;
            Items[0].pData = sensortIntPtr;

            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = Tags._0102_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = Tags._0103_S1;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = Tags._0104_S1;
            Items[3].pData = sensortIntPtr;


            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = Tags._0105_S1;
            Items[4].pData = sensortIntPtr;


            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = Tags._0105_S2;
            Items[5].pData = sensortIntPtr;


            Items[6].Area = S7Client.S7AreaPE;
            Items[6].Amount = 1;
            Items[6].DBNumber = 0;
            Items[6].WordLen = S7Client.S7WLBit;
            Items[6].Start = Tags._0301_S1;
            Items[6].pData = sensortIntPtr;


            Items[7].Area = S7Client.S7AreaPE;
            Items[7].Amount = 1;
            Items[7].DBNumber = 0;
            Items[7].WordLen = S7Client.S7WLBit;
            Items[7].Start = Tags._0301_S2;
            Items[7].pData = sensortIntPtr;


            Items[8].Area = S7Client.S7AreaPE;
            Items[8].Amount = 1;
            Items[8].DBNumber = 0;
            Items[8].WordLen = S7Client.S7WLBit;
            Items[8].Start = Tags._0302_S1;
            Items[8].pData = sensortIntPtr;

            Items[9].Area = S7Client.S7AreaPE;
            Items[9].Amount = 1;
            Items[9].DBNumber = 0;
            Items[9].WordLen = S7Client.S7WLBit;
            Items[9].Start = Tags._0303_S1;
            Items[9].pData = sensortIntPtr;


            _res = Client.WriteMultiVars(Items, 20);
        }







    }
}
