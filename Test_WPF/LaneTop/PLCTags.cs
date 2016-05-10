using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneTop
{
    class PlcTags
    {
        //System general
        public static int StartButtonInput = 448;
        public static int StopButtonInput = 322;
        public static int ResetButtonMerker = 7997;
        public static int DegradedModeMerker = 162;
        public static int LMcomFailMerker = 74;
        public static int RfiDcomFailMerker = 12;
        public static int SystemStartMerker = 7336;
        public static int SystemStopMerker = 7337;
        public static int SystemResetMerker = 323;

        public static int NoodstopReclaimerInput = 594;
        public static int NoodstopDivestInput = 592;
        public static int NoodstopXrayInput = 593;
        public static int SwitchDegradedModeInput = 288;
        public static int TechnicalErrorMerker = 169;


        // LANE TOP - SENSORS
        //SECTION-A
        internal static int _0102_S1 = 16;
        internal static int _0102_S2 = 17;
        public static int _0103_S1 = 18;
        public static int _0104_S1 = 144;
        public static int _0105_S1 = 156;

        public static int _0105_S2 = 157;
        public static int _0301_S1 = 36;
        public static int _0301_S2 = 37;
        public static int _0302_S1 = 38;
        public static int _0303_S1 = 164;
        public static int _0304_S1 = 165;
        public static int _0304_S2 = 166;
        public static int _0304_S3 = 167;
        //section C
        public static int _0701_S1 = 163;
        public static int _0701_S2 = 40;
        public static int _0702_S1 = 41;
        public static int _0702_S2 = 42;
        //section D
        public static int _1001_S1 = 272;
        public static int _1001_S2 = 273;
        public static int _1002_S1 = 274;
        public static int _1002_S2 = 275;
        public static int _1003_S1 = 400;
        public static int _1003_S4 = 412;
        public static int _1003_S5 = 413;
        public static int _1003_S2 = 401;
        public static int _1004_S1 = 280;
        public static int _1003_S3 = 415;
        public static int _1004_S2 = 281;

        // SECTION E
        public static int _1101_S1 = 292;
        public static int _1101_S2 = 293;
        public static int _1101_S3 = 294;
        public static int _1102_S1 = 295;
        public static int _1102_S2 = 420;
        public static int _1102_S3 = 421;
        
        // SECTION F
        public static int _1601_S1 = 432;
        public static int _1601_S2 = 433;
        public static int _1601_S3 = 434;
        public static int _1602_S1 = 435;
        public static int _1602_S2 = 316;
        public static int _1602_S3 = 317;

        // SECTION G
        public static int _1701_S1 = 428;
        public static int _1701_S2 = 445;
        public static int SafetySensorReclaim = 596;
        public static int SafetySensorReject = 595;
        public static int _1702_S1 = 446;
        public static int _1702_S2 = 447;

        // MOTORS - SECTION-A
        public static int _0102_D1 = 16;
        public static int _0103_D1 = 18;
        public static int _0104_D1 = 144;
        public static int _0105_D1 = 156;
        
        // MOTORS - SECTION-B
        public static int _0301_D1 = 36;
        public static int _0302_D1 = 38;
        public static int _0303_D1 = 164;
        public static int _0304_D1 = 166;
       
        //MOTORS - SECTION-C
        public static int _0702_D1 = 40;

        //MOTORS - SECTION-D
        public static int _1001_D1 = 000;
        public static int _1002_D1 = 274;
        public static int _1003_D2 = 284;
        public static int _1003_D1 = 535;
        public static int _1003_D3 = 286;
        public static int _1003_D4 = 412;
        public static int _1004_D1 = 280;
        public static int _1004_D2 = 282;
        public static int _1004_D3 = 332;

        //MOTORS - SECTION-E
        public static int _1701_D1 = 000;
        public static int _1702_D1 = 000;
        
    }
}