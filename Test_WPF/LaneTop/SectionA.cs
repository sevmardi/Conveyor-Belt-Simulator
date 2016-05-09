using System.Timers;
using System.Windows;
using System.Windows.Media;
using Snap7;
using System;

namespace LaneTop
{
    class SectionA
    {
        private static int _res;
        private static readonly byte[] Buffer = new byte[500];
        private static LaneAnimation _laneanimatin;

        MainWindow main;

        public SectionA(MainWindow  mw)
        {
            main = mw;
        }
        public  void Executor()
        {
            _0102_S1Read();
        }

        #region MOTORS

        public void _0102_D1()
        {
            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0102_D1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0102_D1,
                        PlcCalls.Amount, PlcCalls.Wordlen, Buffer);
                    main._0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0103_D1()
        {
            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0103_D1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0103_D1,
                        PlcCalls.Amount, PlcCalls.Wordlen, Buffer);
                }
            }
        }

        public void _0104_D1()
        {
            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0104_D1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    Buffer[0] = 1;
                    _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0104_D1,
                        PlcCalls.Amount, PlcCalls.Wordlen, Buffer);
                }
            }
        }

        #endregion

        #region Sensors

        public void _0102_S1Read()
        {
            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    PlcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S1, PlcCalls.Amount,
                        PlcCalls.Wordlen, Buffer);
                    main._0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                    _0102_D1();
                }
            }
            Timer();
        }

        /// <summary>
        /// Set the sensor on true 
        /// </summary>
        public void _0102_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            PlcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);
            Buffer[0] = 0;
            _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0102_D1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            main.Dispatcher.Invoke((Action) (() =>
            {
                main._0102_S1.Fill = new SolidColorBrush(Colors.Red);
                main._0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0102_S2Read()
        {
            _res = PlcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S2, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    PlcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S2, PlcCalls.Amount,
                        PlcCalls.Wordlen, Buffer);
                    main._0102_S2.Fill = new SolidColorBrush(Colors.DarkGray);
                    _0102_D1();
                }
            }

            Timer();
        }

        public void _0102_S2Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            PlcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DBNumber, PlcTags._0102_S2, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);
            Buffer[0] = 0;
            _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PlcTags._0103_D1, PlcCalls.Amount,
                PlcCalls.Wordlen, Buffer);

            main.Dispatcher.Invoke((Action) (() =>
            {
                main._0102_S2.Fill = new SolidColorBrush(Colors.Red);
                main._0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        #endregion


        protected  void Timer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S1Write);
            aTimer.Interval = 3000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {   
                aTimer.Stop();
            };
        }
      

        

    }
}
