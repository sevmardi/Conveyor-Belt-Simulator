using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snap7;
using System.Windows;
using System.Runtime.InteropServices;


namespace LaneTop
{
    class PlcCalls
    {
        //** Snap7 client library **//
        public static S7Client Client;

        //List<PLCTags> tags = new List<PLCTags>();

        private const int Amount = 1;
        private const int DbNumber = 0;
        private static readonly int Wordlen = S7Client.S7WLBit;
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
        /// Disconnect from plc 
        /// </summary>
        public static void Disconnect()
        {
            Client.Disconnect();
            Client = null;
            MessageBox.Show("cool man, we're good");
        }

        public static void StartBtnInput()
        {
            Buffer[0] = 1;
           _res =  Client.WriteArea(S7Client.S7AreaPE, DbNumber, PlcTags.StartButtonInput, Amount, Wordlen, Buffer);
        }

        public static void StopBtnInput()
        {
            _res = Client.ReadArea(S7Client.S7AreaPE, DbNumber, PlcTags.StopButtonInput, Amount, Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, PlcTags.StopButtonInput, Amount, Wordlen, Buffer);
                }
                else
                {
                    Buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, PlcTags.StopButtonInput, Amount, Wordlen, Buffer);
                }
            }
        }


        public static void ResetBtn()
        {
            Buffer[0] = 1;
            Client.WriteArea(S7Client.S7AreaMK, DbNumber, PlcTags.ResetButtonMerker, Amount, Wordlen, Buffer);
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
                    Items[0].Start = PlcTags.NoodstopReclaimerInput;
                    Items[0].pData = startupPtr;

                    Items[1].Area = S7Client.S7AreaPE;
                    Items[1].Amount = 1;
                    Items[1].DBNumber = 0;
                    Items[1].WordLen = S7Client.S7WLBit;
                    Items[1].Start = PlcTags.NoodstopDivestInput;
                    Items[1].pData = startupPtr;


                    Items[2].Area = S7Client.S7AreaPE;
                    Items[2].Amount = 1;
                    Items[2].DBNumber = 0;
                    Items[2].WordLen = S7Client.S7WLBit;
                    Items[2].Start = PlcTags.NoodstopXrayInput;
                    Items[2].pData = startupPtr;

                    Items[3].Area = S7Client.S7AreaPE;
                    Items[3].Amount = 1;
                    Items[3].DBNumber = 0;
                    Items[3].WordLen = S7Client.S7WLBit;
                    Items[3].Start = PlcTags.SwitchDegradedModeInput;
                    Items[3].pData = startupPtr;            
            
                    _res = Client.WriteMultiVars(Items, 20);
           
                }

        #endregion

        #region sensors 
                public static void SensorsOnTrueBatch1()
                {
                    GCHandle myGcHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
                    IntPtr batch1 = myGcHandle.AddrOfPinnedObject();

                    Items[0].Area = S7Client.S7AreaPE;
                    Items[0].Amount = 1;
                    Items[0].DBNumber = 0;
                    Items[0].WordLen = S7Client.S7WLBit;
                    Items[0].Start = PlcTags._0102_S1;
                    Items[0].pData = batch1;

                    Items[1].Area = S7Client.S7AreaPE;
                    Items[1].Amount = 1;
                    Items[1].DBNumber = 0;
                    Items[1].WordLen = S7Client.S7WLBit;
                    Items[1].Start = PlcTags._0102_S2;
                    Items[1].pData = batch1;


                    Items[2].Area = S7Client.S7AreaPE;
                    Items[2].Amount = 1;
                    Items[2].DBNumber = 0;
                    Items[2].WordLen = S7Client.S7WLBit;
                    Items[2].Start = PlcTags._0103_S1;
                    Items[2].pData = batch1;

                    Items[3].Area = S7Client.S7AreaPE;
                    Items[3].Amount = 1;
                    Items[3].DBNumber = 0;
                    Items[3].WordLen = S7Client.S7WLBit;
                    Items[3].Start = PlcTags._0104_S1;
                    Items[3].pData = batch1;            

                } 

        #endregion
    }
}