using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaneSimulator.Models.Components;
using LaneSimulator.PLC;
using LaneSimulator.Views;
using Snap7;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for LaneTop.xaml
    /// </summary>
    public partial class LaneTop : UserControl
    {
        private readonly PlcCalls _plcCalls;
        private static readonly byte[] Buffer = new byte[500];
        private static int _res;
        public Storyboard sb1;
        private S7Client myclient;
        int amount = 1;
        int DBNumber = 0;
        int area;
        int wordlen = S7Client.S7WLBit;
        byte[] buffer = new byte[10];
        int res;
       
        public LaneTop()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
            sb1 = FindResource("LongPathAnimation") as Storyboard; 
        }

        public void Executor()
        {
            _0102_S1Read();
           
           // SecondSensorTimer();
            //ThirdSensor();
            //FourthSensor();
            //FifthSensor();
            //SixthSensor();
        }


        private void Total()
        {
         // total_text1.Text= (this.tray_Wrap.Children.Count).ToString();
        }


        #region motoren
        public void _0102_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount,_plcCalls.Wordlen, Buffer);
           
            try
            {
                if (_res == 0)
                {
                    if (Buffer[0] == 0)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                    }
                    
                }
            }
            catch (Exception)
            {
                
               sb1.Stop();
                MessageBox.Show("Motor not working!");
            }
  
        }

        public void _0103_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount,_plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 0)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0103_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));

                    }
                    else
                    {
                        MessageBox.Show("Motor not working!");
                        sb1.Stop();
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
         
            }
        }

        public void _0104_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                     _0104_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0105_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    //   main._0105_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

       
        
        
        
        #endregion
        
        #region Sensoren
        
        public void _0102_S1Read()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            try
            {
                if (_res == 0)
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;
                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
                        
                        _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                        
                        _0102_D1Motor();
                    }
                }
                else
                {
                    sb1.Stop();
                    MessageBox.Show("Sensor on false");
                }
            }
            catch (Exception)
            {
                
                throw;
            }


            FirstSensor();
        }

        public void _0102_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                      _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                      _0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));

        }

        public void _0102_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0102_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0103_D1Motor();

                }
            }

            SecondSensorWrite();
        }

        public void _0102_S2Write(object source, ElapsedEventArgs e)
        {
             Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;

            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                _0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0103_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0103_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0104_D1Motor();

                }
            }

            ThirdSensorWrite();

        }

        public void _0103_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);
            Buffer[0] = 0;
            _res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                _0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0104_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0104_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));


                }
            }
            FourthSensorWrite();

        }

        public void _0104_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
             
            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0105_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0105_D1Motor();
                }
            }
            FifthSensorWrite();

        }

        public void _0105_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
            //Buffer[0] = 0;
            //_res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0105_D1, PlcCalls.Amount,
            //    PlcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S2Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0105_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));
                }
            }
            SixthSensorWrite();

        }

        public void _0105_S2Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        
        public void _0301_S1_TurnOFF()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
            
            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0301_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                 //   _0301_D1_Motor();

                }
            }
        }

        public void _0301_S1_Write()
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);


            Dispatcher.Invoke((Action)(() =>
            {
                _0301_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }




        #endregion

        #region timers

        protected void FirstSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S1Write);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void SecondSensorTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2_TurnOff);
            aTimer.Interval = 800;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void SecondSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2Write);
            aTimer.Interval = 3000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void ThirdSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Read);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void ThirdSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Write);
            aTimer.Interval = 3500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FourthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Read);
            aTimer.Interval = 2500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void FourthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Write);
            aTimer.Interval = 3500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void FifthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Read);
            aTimer.Interval = 3600;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FifthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Write);
            aTimer.Interval = 3800;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void SixthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Read);
            aTimer.Interval = 4500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void SixthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Write);
            aTimer.Interval = 4100;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

    #endregion


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _plcCalls.EstablishContact();
          

      
               // myclient.ConnectTo("192.168.2.16", 0, 0);
              
                if (_plcCalls.Client.Connected())
                {
                    
                    _plcCalls.StartUp();
                    _plcCalls.SectionA();
                    _plcCalls.SectionB();
                    _plcCalls.SectionC();
                    _plcCalls.SectionD();
                    _plcCalls.SectionE();
                    _plcCalls.SectionF();
                    _plcCalls.SectionG();

                    //buffer[0] = 1;
                   // myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
                    
                    
                    _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0301_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0301_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0302_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0303_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S3.Fill = new SolidColorBrush(Colors.Red);
                    _0701_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0702_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0701_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0702_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1001_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1001_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1002_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1004_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S4.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S5.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1002_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1004_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S3T.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S3T.Fill = new SolidColorBrush(Colors.Red);





                    ContactPlcBtn.IsEnabled = false;
                }

            }
       

        private void MakeTrayBtn_Click(object sender, RoutedEventArgs e)
        {
            //Tray tray = new Tray();
            //AnimationPannel.Children.Add(tray);
            //sb1.Begin(tray);
            TaskRunner();
            // Executor();
        }

        private void storyboard_Completed(object sender, EventArgs eventArgs)
        {
            // Tray tray =  (Tray) this.Animation_Pannel.Children[0];
        }

        private void StopSimBtn_Click(object sender, RoutedEventArgs e)
        {
            SchedulerPanel schedulerPanel = new SchedulerPanel();
            schedulerPanel.Show();
        }


        public void TaskRunner()
        {
            int testtrays = 5;
            for (int i = 0; i < testtrays; i++)
            {
                Tray tray = new Tray();
                AnimationPannel.Children.Add(tray);
                sb1.Begin(tray);
            }



        }
    }
}
