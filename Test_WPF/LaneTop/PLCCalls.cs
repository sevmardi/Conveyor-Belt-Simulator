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
    class PLCCalls
    {
        public static  S7Client myclient;
        public static PLCTags tags;
        //List<PLCTags> tags = new List<PLCTags>();
       
        private static int amount = 1;
        private static int DBNumber = 0;
        private static int area;
        private static int wordlen = S7Client.S7WLBit;
        private static byte[] buffer = new byte[500];
        private static int res;


        static S7Client.S7DataItem[] items = new S7Client.S7DataItem[20];

        public PLCCalls()
        {
             PLCTags tags = new PLCTags();
        }

        /// <summary>
        /// Establish connection
        /// </summary>
        public static void EstablishContact()
        {
            myclient = new S7Client();
            myclient.ConnectTo("192.168.2.16", 0, 0);

            if (myclient.Connected())
            {
                MessageBox.Show("Connection Established");
                //stopsystem();
            }
            else
                MessageBox.Show("Something went wrong");
        }

        /// <summary>
        /// Disconnect from plc 
        /// </summary>
        public static void Disconnect()
        {
            myclient.Disconnect();
            MessageBox.Show("cool man, we're good");
        }

        /// <summary>
        /// Stop plc
        /// </summary>
        public static void StopSystem()
        {
            buffer[0] = 0;
            myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
        }

        /// <summary>
        /// Reset system
        /// </summary>
        public static void ResetSystem()
        {
            buffer[0] = 1;
            myclient.WriteArea(S7Client.S7AreaMK, DBNumber, 7997, amount, wordlen, buffer);
        }


        public void StartUp()
        {
            GCHandle myGcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            IntPtr systemstat = myGcHandle.AddrOfPinnedObject();

            buffer[0] = 0;

            items[0].Area = S7Client.S7AreaPE;
            items[0].Amount = 1;
            items[0].DBNumber = 0;
            items[0].WordLen = S7Client.S7WLBit;
            items[0].Start = PLCTags.Start_Button_Input;
            items[0].pData = systemstat;

            items[1].Area = S7Client.S7AreaPE;
            items[1].Amount = 1;
            items[1].DBNumber = 0;
            items[1].WordLen = S7Client.S7WLBit;
            items[1].Start = 50;
            items[1].pData = systemstat;


            res = myclient.WriteMultiVars(items, 20);

            myclient = null;


        }





    }
}
