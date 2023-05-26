using System;

namespace FuXinTLL.Telegram.HMI
{
    [Serializable]
    public class HMI_ServerToClient_Structure
    {
        /// <summary>已三級排程覆蓋HMI</summary>
        [Serializable]
        public class SchduleChangeFormL3 : HMI_Structure
        {
            public string Message;
        }

        /// <summary>警報通知</summary>
        [Serializable]
        public class Alarm : HMI_Structure
        {
            public string Message;
        }

        /// <summary>排程更新通知</summary>
        [Serializable]
        public class ScheduleRefresh : HMI_Structure
        {
            public ScheduleRefresh()
            {
                MessageID = nameof(ScheduleRefresh);
            }
        }

        /// <summary>TrkMap更新通知</summary>
        [Serializable]
        public class TrkMapRefresh : HMI_Structure
        {
            public TrkMapRefresh()
            {
                MessageID = nameof(TrkMapRefresh);
            }
        }

        /// <summary>PDO更新通知</summary>
        [Serializable]
        public class PdoRefresh : HMI_Structure
        {

        }

        /// <summary>過度捲更新通知</summary>
        [Serializable]
        public class DummyCoilRefresh : HMI_Structure
        {

        }
        /// <summary>停複機通知</summary>
        [Serializable]
        public class DownTimeRefresh: HMI_Structure
        {

        }

        /// <summary>張力值</summary>
        [Serializable]
        public class TensionChange : HMI_Structure
        {
            public float SpeedActEn;
            public float SpeedActProcess;
            public float SpeedActEx;
            public float TenRefUnc;
            public float TenActUnc;
            public float TenRefEnLop;
            public float TenActEnLop;
            public float TenRefLeveler;
            public float TenActLeveler;
            public float TenRefExLop;
            public float TenActExLop;
            public float TenRefRec;
            public float TenActRec;
            public float ElongationRef;
            public float ElongationAct;
            public float LevelerIntermesh1Ref;
            public float LevelerIntermesh1Act;
            public float LevelerIntermesh2Ref;
            public float LevelerIntermesh2Act;
            public float LevelerIntermesh3Ref;
            public float LevelerIntermesh3Act;
            public float CoilWidthActual;
        }

        /// <summary>張力資料開始</summary>
        [Serializable]
        public class TensionBegin : HMI_Structure
        {
            public string CoilID;
        }

        /// <summary>張力資料結束</summary>
        [Serializable]
        public class TensionEnd : HMI_Structure
        {
            public string CoilID;
        }

        [Serializable]
        public class BarCodeScanDone : HMI_Structure
        {
            /// <summary>出入口旗標 0:入口 1:出口</summary>
            public int Flag;
            public string ScanStatus;
            public string ScanCoilID;
        }

        [Serializable]
        public class TrackMapLine : HMI_Structure
        {
            public float RemLengthUnc;

            public string[] CoilIDs = new string[10];

            public float[] HeadPosCoil = new float[10];

            public float Lop1Pos;

            public float Lop2Pos;

            public float ActLengthRec;
        }

        /// <summary>
        /// 產現停機通知
        /// </summary>
        [Serializable]
        public class L1ShutDown : HMI_Structure
        {

        }

        /// <summary>
        /// 試樣通知
        /// </summary>
        [Serializable]
        public class SampleCutDone : HMI_Structure
        {
            public bool CuttingSuccess;
            public string Message;
        }

        /// <summary>
        /// 更新ConnStatus
        /// </summary>
        [Serializable]
        public class ConnStatusUpdated : HMI_Structure
        {

        }

        [Serializable]
        public class MMS_ReturnCoilFail : HMI_Structure
        {
            public string CoilID;
        }

        [Serializable]
        public class CommandDone : HMI_Structure
        {
            public bool isSuccess;
            public string Message;
            /// <summary>
            /// 給刪除排程用
            /// </summary>
            public DateTime Spare;
        }

        /// <summary>資料同步通知</summary>
        [Serializable]
        public class DataSynced : HMI_Structure
        {
            public string Flag;
        }

        /// <summary>天車檢查</summary>
        [Serializable]
        public class CraneEntryCoilCheck : HMI_Structure
        {
            public int SkidNo;
            public string CoilId;
        }

        /// <summary>心跳</summary>
        [Serializable]
        public class Alive : HMI_Structure
        {
            public string IP;
        }
    }
}
