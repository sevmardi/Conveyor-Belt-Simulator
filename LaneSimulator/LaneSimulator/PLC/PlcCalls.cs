using System;
using System.Runtime.InteropServices;
using System.Windows;
using Snap7;

namespace LaneSimulator.PLC
{
    public class PlcCalls
    {
        //** Snap7 client library **//
        public  S7Client Client;
        
        //private static LaneAnimation _laneanimatin;

        public  int Amount = 1;
        public  int DbNumber = 0;
        public  readonly int Wordlen = S7Client.S7WLBit;
        private  readonly byte[] _buffer = new byte[500];
        private  int _res;
       
        static readonly S7Client.S7DataItem[] Items = new S7Client.S7DataItem[20];

        public PlcCalls()
        {
            Client = new S7Client();
        }

        /// <summary>
        /// TEMP 
        /// </summary>
        public  void EstablishContact()
        {
            Client.ConnectTo("192.168.2.16", 0, 0);
        }

        /// <summary>
        /// This executes a method to make contact with the PLC
        /// </summary>
        /// <param name="ipAdress"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        public void ConnectToPlc(string ipAdress, int rack, int slot)
        {
            Client.ConnectTo(ipAdress, rack, slot);

            MessageBox.Show(Client.Connected() ? "Connection Established" : "Something went wrong");
        }


        /// <summary>
        /// Disconnect from PLC 
        /// </summary>
        public void Disconnect()
        {
            Client.Disconnect();
            Client = null;
        }

        /// <summary>
        /// Start the system by setting the press button either True or False
        /// </summary>
        public  void StartBtnInput()
        {
            _res = Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.StartButtonInput, Amount, Wordlen, _buffer);
            if (_res == 0)
            {
                if (_buffer[0] == 0)
                {
                    _buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.StartButtonInput, Amount, Wordlen, _buffer);
                }
                else
                {
                    _buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.StartButtonInput, Amount, Wordlen, _buffer);
                }
            }

        }


        /// <summary>
        /// Stop the system by either 
        /// </summary>
        public void StopBtnInput()
        {
            _buffer[0] = 0;
            Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.StopButtonInput, Amount, Wordlen, _buffer);
            Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.StartButtonInput, Amount, Wordlen, _buffer);
        }


        /// <summary>
        /// RESET System
        /// </summary>
        public  void ResetBtn()
        {
            _res = Client.ReadArea(S7Client.S7AreaMK, DbNumber, PLCTags.ResetButtonMerker, Amount, Wordlen, _buffer);

            if (_res == 0)
            {
                if (_buffer[0] == 0)
                {
                    _buffer[0] = 1;
                    Client.WriteArea(S7Client.S7AreaMK, DbNumber, PLCTags.ResetButtonMerker, Amount, Wordlen, _buffer);
                }
                else
                {
                    _buffer[0] = 0;
                    Client.WriteArea(S7Client.S7AreaMK, DbNumber, PLCTags.ResetButtonMerker, Amount, Wordlen, _buffer);
                }
            }
        }

        /// <summary>
        /// The first startup in which amount of Inputs & meker(s) are set to true, this to avoid
        /// any headaches during simulation 
        /// </summary>
        public  void StartUp()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr startupPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags.NoodstopReclaimerInput;
            Items[0].pData = startupPtr;

            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags.NoodstopDivestInput;
            Items[1].pData = startupPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags.NoodstopXrayInput;
            Items[2].pData = startupPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags.SwitchDegradedModeInput;
            Items[3].pData = startupPtr;


            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags.StartButtonInput;
            Items[4].pData = startupPtr;


            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags.StopButtonInput;
            Items[5].pData = startupPtr;

            _res = Client.WriteMultiVars(Items, 20);
        }

        public  void SectionA()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;


            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._0102_S1;
            Items[0].pData = sensortIntPtr;

            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._0102_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._0103_S1;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags._0104_S1;
            Items[3].pData = sensortIntPtr;


            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._0105_S1;
            Items[4].pData = sensortIntPtr;


            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._0105_S2;
            Items[5].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 6);
        }

        public  void SectionB()
        {

            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._0301_S1;
            Items[0].pData = sensortIntPtr;


            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._0301_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._0302_S1;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags._0303_S1;
            Items[3].pData = sensortIntPtr;

            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._0304_S1;
            Items[4].pData = sensortIntPtr;

            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._0304_S2;
            Items[5].pData = sensortIntPtr;

            Items[6].Area = S7Client.S7AreaPE;
            Items[6].Amount = 1;
            Items[6].DBNumber = 0;
            Items[6].WordLen = S7Client.S7WLBit;
            Items[6].Start = PLCTags._0304_S3;
            Items[6].pData = sensortIntPtr;

            Items[7].Area = S7Client.S7AreaPE;
            Items[7].Amount = 1;
            Items[7].DBNumber = 0;
            Items[7].WordLen = S7Client.S7WLBit;
            Items[7].Start = PLCTags._0701_S1;
            Items[7].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 9);
        }

        public  void SectionC()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._0701_S2;
            Items[0].pData = sensortIntPtr;


            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._0702_S1;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._0702_S2;
            Items[2].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 4);

        }

        public  void SectionD()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._1001_S1;
            Items[0].pData = sensortIntPtr;


            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._1001_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._1002_S1;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags._1002_S2;
            Items[3].pData = sensortIntPtr;

            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._1003_S1;
            Items[4].pData = sensortIntPtr;

            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._1003_S4;
            Items[5].pData = sensortIntPtr;

            Items[6].Area = S7Client.S7AreaPE;
            Items[6].Amount = 1;
            Items[6].DBNumber = 0;
            Items[6].WordLen = S7Client.S7WLBit;
            Items[6].Start = PLCTags._1003_S5;
            Items[6].pData = sensortIntPtr;

            Items[7].Area = S7Client.S7AreaPE;
            Items[7].Amount = 1;
            Items[7].DBNumber = 0;
            Items[7].WordLen = S7Client.S7WLBit;
            Items[7].Start = PLCTags._1003_S2;
            Items[7].pData = sensortIntPtr;

            Items[8].Area = S7Client.S7AreaPE;
            Items[8].Amount = 1;
            Items[8].DBNumber = 0;
            Items[8].WordLen = S7Client.S7WLBit;
            Items[8].Start = PLCTags._1004_S1;
            Items[8].pData = sensortIntPtr;

            Items[9].Area = S7Client.S7AreaPE;
            Items[9].Amount = 1;
            Items[9].DBNumber = 0;
            Items[9].WordLen = S7Client.S7WLBit;
            Items[9].Start = PLCTags._1003_S3;
            Items[9].pData = sensortIntPtr;

            Items[10].Area = S7Client.S7AreaPE;
            Items[10].Amount = 1;
            Items[10].DBNumber = 0;
            Items[10].WordLen = S7Client.S7WLBit;
            Items[10].Start = PLCTags._1004_S2;
            Items[10].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 13);
        }

        public  void SectionE()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._1101_S1;
            Items[0].pData = sensortIntPtr;


            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._1101_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._1101_S3;
            Items[2].pData = sensortIntPtr;


            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags._1102_S1;
            Items[3].pData = sensortIntPtr;


            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._1102_S2;
            Items[4].pData = sensortIntPtr;


            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._1102_S3;
            Items[5].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 7);

        }

        public  void SectionF()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._1601_S1;
            Items[0].pData = sensortIntPtr;


            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._1601_S2;
            Items[1].pData = sensortIntPtr;


            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags._1601_S3;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags._1602_S1;
            Items[3].pData = sensortIntPtr;

            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._1602_S2;
            Items[4].pData = sensortIntPtr;

            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._1602_S3;
            Items[5].pData = sensortIntPtr;

            _res = Client.WriteMultiVars(Items, 7);

        }

        public  void SectionG()
        {
            GCHandle myGcHandle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            IntPtr sensortIntPtr = myGcHandle.AddrOfPinnedObject();

            _buffer[0] = 1;

            Items[0].Area = S7Client.S7AreaPE;
            Items[0].Amount = 1;
            Items[0].DBNumber = 0;
            Items[0].WordLen = S7Client.S7WLBit;
            Items[0].Start = PLCTags._1701_S1;
            Items[0].pData = sensortIntPtr;

            Items[1].Area = S7Client.S7AreaPE;
            Items[1].Amount = 1;
            Items[1].DBNumber = 0;
            Items[1].WordLen = S7Client.S7WLBit;
            Items[1].Start = PLCTags._1701_S2;
            Items[1].pData = sensortIntPtr;

            Items[2].Area = S7Client.S7AreaPE;
            Items[2].Amount = 1;
            Items[2].DBNumber = 0;
            Items[2].WordLen = S7Client.S7WLBit;
            Items[2].Start = PLCTags.SafetySensorReclaim;
            Items[2].pData = sensortIntPtr;

            Items[3].Area = S7Client.S7AreaPE;
            Items[3].Amount = 1;
            Items[3].DBNumber = 0;
            Items[3].WordLen = S7Client.S7WLBit;
            Items[3].Start = PLCTags.SafetySensorReject;
            Items[3].pData = sensortIntPtr;

            Items[4].Area = S7Client.S7AreaPE;
            Items[4].Amount = 1;
            Items[4].DBNumber = 0;
            Items[4].WordLen = S7Client.S7WLBit;
            Items[4].Start = PLCTags._1702_S1;
            Items[4].pData = sensortIntPtr;

            Items[5].Area = S7Client.S7AreaPE;
            Items[5].Amount = 1;
            Items[5].DBNumber = 0;
            Items[5].WordLen = S7Client.S7WLBit;
            Items[5].Start = PLCTags._1702_S2;
            Items[5].pData = sensortIntPtr;



            _res = Client.WriteMultiVars(Items, 7);

        }

        /// <summary>
        /// Degraded mode approval
        /// </summary>
        public void DegradedDecisionEventOk()
        {
            _buffer[0] = 1;
           
            Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.PushButtonOperatorOk, Amount, Wordlen, _buffer);
        }

        /// <summary>
        /// Degraded mode not approved
        /// </summary>
        public void DegradedDecisionEventNotOk()
        {
            _buffer[0] = 1;
            Client.WriteArea(S7Client.S7AreaPE, DbNumber, PLCTags.PushButtonOperatorNotOk, Amount, Wordlen, _buffer);
        }

    }
}
