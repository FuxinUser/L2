namespace FuXinTLL.Table
{
    public enum ConectDirection
    {
        Level2, Level1, WMS, MMS
    }

    public enum TrkMapPos
    {
        UnCoiler = 4,
        ETOP = 1,
        UncSkid2 = 2,
        UncSkid3 = 3,

        ReCoiler = 5,
        RecSkid1 = 6,
        RecSkid2 = 7,
        DTOP = 8,
        EntryCar = 9,
        ExitCar = 10
    }
    public class TblConst
    {
        //分切模式
        public enum CutMode
        {
            StripBreak, SplitCut, SampleCut, HeadCut, TailCut, WeldCut, ScrapCut
        }

        //barCode 轉 L2  SKID
        public enum BarCodeToL2Skid
        {
            ETOP = 3,
            UncSkid2 = 2,
            UncSkid3 = 1,
            RecSkid1 = 4,
            RecSkid2 = 5,
            DTOP = 6,
        }

        public class HMISampleLabel
        {
            public string CoilNo;
            public string SteelGradeSign;
            public string ExitCoilThick;
            public string SampleLotNo;
            public string SamplePosiotion;
        }

        //WMS鞍座號
        public enum WmsSkid
        {
            ESK3 = 3,
            ESK2 = 2,
            ETOP = 1,
            DSK1 = 4,
            DSk2 = 5,
            DTOP = 6
        }
        public class L2SystemSetting
        {
            public const string AutoFeeding = "AutoFeeding";   //自動入料
            public const string TopScheduleLock = "TopScheduleLock";   //排成鎖前3筆
        }

        public class PDICoilStatus
        {
            public const string OffLine = "N";   //未上線
            public const string OnLine = "Y";   //已上線
            public const string RequestEntry = "R";   //請求入料中
            public const string Product = "O";   //已產出
        }

        public class PDOCoilStatus
        {
            public const string RequestExit = "R";   //請求出料中
            public const string Product = "O";   //已產出
            public const string Upload = "O";   //已上傳
        }


        public static class ProcessLocationMeter
        {
            /// <summary>
            /// 開卷機距離
            /// </summary>
            public const float UnCoil = 12.5F;
            /// <summary>
            /// 收卷機距離 
            /// </summary>
            public const float ReCoil = -404.06F;
            /// <summary>
            /// 入口活套
            /// </summary>
            public const float EnLoopMeter = -21.17F;
            /// <summary>
            /// 出口活套
            /// </summary>
            public const float ExLoopMeter = -236.56F;
            /// <summary>
            /// 拉矯機
            /// </summary>
            public const float LevelerMeter = -191F;

        }


        public class L25TelegramName
        {
            /// <summary>
            /// 心跳
            /// </summary>
            public const string Alive = "Alive";
            /// <summary>
            /// L2系統AP開啟/關閉信息
            /// </summary>
            public const string L2APStatus = "L2APStatus";
            /// <summary>
            /// L2和其他系統連線狀態資訊
            /// </summary>
            public const string DisConnection = "DisConnection";
            /// <summary>
            /// Level 1 tracking map
            /// </summary>
            public const string CoilMap = "CoilMap";
            /// <summary>
            /// 收卷機連續型資料
            /// </summary>
            public const string RECTensionCT = "RECTensionCT";
            /// <summary>
            /// 裁邊機連續型資料
            /// </summary>
            public const string SideTrimmerCT = "SideTrimmerCT";
            /// <summary>
            /// 開卷機連續型資料
            /// </summary>
            public const string UNCTensionCT = "UNCTensionCT";
            /// <summary>
            /// 能源耗用
            /// </summary>
            public const string Utility = "Utility";
            /// <summary>
            /// 休止實績
            /// </summary>
            public const string DownTime = "DownTime";
            /// <summary>
            /// PDO
            /// </summary>
            public const string CoilPDO = "CoilPDO";
            /// <summary>
            /// PDI
            /// </summary>
            public const string CoilPDI = "CoilPDI";
        }

        public class L25MessageID
        {
            /// <summary>
            /// 心跳
            /// </summary>
            public const string Alive = "113";
            /// <summary>
            /// L2系統AP開啟/關閉信息
            /// </summary>
            public const string L2APStatus = "112";
            /// <summary>
            /// L2和其他系統連線狀態資訊
            /// </summary>
            public const string DisConnection = "111";
            /// <summary>
            /// Level 1 tracking map
            /// </summary>
            public const string CoilMap = "110";
            /// <summary>
            /// 收卷機連續型資料
            /// </summary>
            public const string RECTensionCT = "109";
            /// <summary>
            /// 出口活套機連續型資料
            /// </summary>
            public const string ExLoopTensionCT = "108";
            /// <summary>
            /// 拉矯機連續型資料
            /// </summary>
            public const string LevelerTensionCT = "107";
            /// <summary>
            /// 入口活套機連續型資料
            /// </summary>
            public const string EnLoopTensionCT = "106";
            /// <summary>
            /// 開卷機連續型資料
            /// </summary>
            public const string UNCtensionCT = "105";
            /// <summary>
            /// 能源耗用
            /// </summary>
            public const string Utility = "104";
            /// <summary>
            /// 休止實績
            /// </summary>
            public const string DownTime = "103";
            /// <summary>
            /// PDO
            /// </summary>
            public const string CoilPDO = "102";
            /// <summary>
            /// PDI
            /// </summary>
            public const string CoilPDI = "101";

        }
    }


    public class LineUnit
    {
        public const string MMS_FuncCode_A = "A";   //應答電文 OK
        public const string MMS_FuncCode_B = "B";   //應答電文 NG
        public const string MMS_FuncCode_C = "C";   //心跳電文
        public const string MMS_FuncCode_D = "D";   //普通
    }

    public static class DummyFlag
    {
        public const string isDummy = "1";    //是過度捲
        public const string notDummy = "0";    //不是過度捲
    }

    public static class TelegramSkidID
    {
        public const int Unc_SK1 = 2;    
        public const int Unc_SK2 = 4;
        public const int Unc_SK3 = 8;
        public const int Rec_SK1 = 16;
        public const int Rec_SK2 = 32;
        public const int Rec_SK3 = 64;
    }

    public static class TrackingHMISkid
    {
        public const string POR = "4";
        public const string ETOP = "1";
        public const string ESK03 = "3";
        public const string ESK02 = "2";
        public const string TR = "5";
        public const string DSK01 = "6";
        public const string DSK02 = "7";
        public const string DTOP = "8";
        public const string EntryCar = "9";
        public const string ExitCar = "10";
    }

    public static class WMSKindFlag
    {
        public const string entry = "1";
        public const string exit = "2";
        public const string retrun = "3";    
    }

    public static class WMSOKorNotFlag
    {
        public const string notOK = "0";
        public const string isOK = "1";
    }


    public class CoilIDTrackingLine
    {
        public string CoilID;
        public int Index;
        public float Length;
        public string Lop1Pos;
        public string Lop2Pos;
    }
}
