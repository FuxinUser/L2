using Models;
using System;

namespace FuXinTLL.Telegram.HMI
{
    [Serializable]
    /// <summary>來自HMI的訊息</summary>
    public class HMI_ClientToServer_Structure
    {
        [Serializable]
        /// <summary>鋼捲排程變更</summary>
        public class CoilScheduleChanged : HMI_Structure
        {
            public bool IsSendToMMS { get; set; }
        }

        [Serializable]
        /// <summary>要求PDI</summary>
        public class PDIRequest : HMI_Structure
        {
            public string CoilID { get; set; }
        }

        [Serializable]
        /// <summary>要求排程</summary>
        public class ScheduleRequest : HMI_Structure
        {
            public string CoilId { get; set; }
        }

        /// <summary>鋼捲排程刪除</summary>
        [Serializable]
        public class CoilSecheduleDelete : HMI_Structure
        {
            public string CoilID { get; set; }

            ///<summary>處理結果</summary>
            public string ProcessResult { get; set; }

            ///<summary>原因代碼</summary>
            public string RejectCause { get; set; }

            public string ScheduleDeleteCoilRejectGroupNo { get; set; }

            public string ScheduleDeleteCoilRejectCode { get; set; }

            ///<summary>備註</summary>
            public string Remarks { get; set; }

            ///// <summary>使用者ID</summary>
            public string CreateUserID { get; set; }
        }

        /// <summary>
        /// 自動入料
        /// </summary>
        [Serializable]
        public class AutoFeedMode : HMI_Structure
        {
            public bool Enable;
        }

        /// <summary>鋼捲入料</summary>
        [Serializable]
        public class InsertCoil : HMI_Structure
        {
            public string CoilID { get; set; }
            /// <summary>
            /// 鞍座代碼
            ///1: POR
            ///2: ESK1
            ///3: ETOP
            ///4: TR
            ///5: DSK1
            ///6: DTOP
            /// </summary>
            public int SkidID { get; set; }
        }

        /// <summary>鋼捲退料</summary>
        [Serializable]
        public class ReturnCoil : HMI_Structure
        {
            public string UserID { get; set; }
            public string RejectCoilNo { get; set; }
            public string EntryCoilNo { get; set; }
            public string PlanNo { get; set; }
            public string MadeOfReject { get; set; }
            public string RejectCoilLength { get; set; }
            public string RejectCoilWeight { get; set; }
            public string RejectCoilInnerDiameter { get; set; }
            public string RejectCoilOutterDiameter { get; set; }

            /// <summary>
            /// 鞍座代碼
            ///1: POR
            ///2: ESK1
            ///3: ETOP
            ///4: TR
            ///5: DSK1
            ///6: DTOP
            /// </summary>
            public int SkidID { get; set; }

            public string RejectTime { get; set; }

            public string RejectShift { get; set; }

            public string RejectTurn { get; set; }

            public string PaperExitCode { get; set; }

            public string PaperType { get; set; }

            public string FinalFlag { get; set; }

            /// <summary>回退代碼</summary>
            public string RejectReasonCode { get; set; }

            public string HeadPaperLength { get; set; }

            public string HeadPaperWidth { get; set; }

            public string TailPaperLength { get; set; }

            public string TailPaperWidth { get; set; }

        }

        /// <summary>請料</summary>
        [Serializable]
        public class CoilEntryRequest : HMI_Structure
        {

        }

        /// <summary>出料</summary>
        [Serializable]
        public class CoilCraneRequest : HMI_Structure
        {
            public string CoilID;
            public int SkidNo;
        }

        /// <summary>鋼捲移除</summary>
        [Serializable]
        public class DeleteCoil : HMI_Structure
        {
            public string CoilID { get; set; }
            /// <summary>
            /// 鞍座代碼
            ///1: POR
            ///2: ESK1
            ///3: ETOP
            ///4: TR
            ///5: DSK1
            ///6: DTOP
            /// </summary>
            public int SkidID { get; set; }
        }

        /// <summary>鋼捲秤重</summary>
        [Serializable]
        public class CoilWeight : HMI_Structure
        {
            public string CoilID { get; set; }
            public float Weight { get; set; }
        }

        /// <summary>貼標籤</summary>
        [Serializable]
        public class Labeling : HMI_Structure
        {
            public string CoilID { get; set; }
        }
        //[Serializable]
        ///// <summary>上傳能源耗用</summary>
        //public class UploadEnergyConsumption : HMI_Structure
        //{
        //    public string Date;
        //    public string ShiftNo;
        //    public string GroupNo;
        //    public string UnitCode;
        //    public string PW;
        //    public string CA;
        //    public string Steam;
        //    public string DEW;
        //    public string IW;
        //    public string ICW;
        //}

        /// <summary>上傳能源耗用</summary>
        [Serializable]
        public class UploadEnergyConsumption : HMI_Structure
        {
            public string Date;
            public string Shift_No;
            public string Group_No;
            public string Unit_code;

            public string PW_1;
            public string PW_2;
            public string PW_3;
            public string PW_4;
            public string PW_5;
            public string PW_6;
            public string PW_7;
            public string PW_8;
            public string PW_9;
            public string PW_10;
            public string PW_11;
            public string PW_12;
            public string PW_13;
            public string PW_14;
            public string PW_15;
            public string DCW_1;
            public string DCW_2;
            public string DCW_3;
            public string DCW_4;
            public string DCW_5;
            public string DCW_6;
            public string DCW_7;
            public string DCW_8;
            public string DCW_9;
            public string DCW_10;
            public string DCW_11;
            public string DCW_12;
            public string DCW_13;
            public string DCW_14;
            public string DCW_15;
            public string IDCW_1;
            public string IDCW_2;
            public string IDCW_3;
            public string IDCW_4;
            public string IDCW_5;
            public string IDCW_6;
            public string IDCW_7;
            public string IDCW_8;
            public string IDCW_9;
            public string IDCW_10;
            public string IDCW_11;
            public string IDCW_12;
            public string IDCW_13;
            public string IDCW_14;
            public string IDCW_15;
            public string DEW_1;
            public string DEW_2;
            public string DEW_3;
            public string DEW_4;
            public string DEW_5;
            public string DEW_6;
            public string DEW_7;
            public string DEW_8;
            public string DEW_9;
            public string DEW_10;
            public string DEW_11;
            public string DEW_12;
            public string DEW_13;
            public string DEW_14;
            public string DEW_15;
            public string NG_1;
            public string NG_2;
            public string NG_3;
            public string NG_4;
            public string NG_5;
            public string NG_6;
            public string NG_7;
            public string NG_8;
            public string NG_9;
            public string NG_10;
            public string NG_11;
            public string NG_12;
            public string NG_13;
            public string NG_14;
            public string NG_15;
            public string CA_1;
            public string CA_2;
            public string CA_3;
            public string CA_4;
            public string CA_5;
            public string CA_6;
            public string CA_7;
            public string CA_8;
            public string CA_9;
            public string CA_10;
            public string CA_11;
            public string CA_12;
            public string CA_13;
            public string CA_14;
            public string CA_15;
            public string STEAM_1;
            public string STEAM_2;
            public string STEAM_3;
            public string STEAM_4;
            public string STEAM_5;
            public string STEAM_6;
            public string STEAM_7;
            public string STEAM_8;
            public string STEAM_9;
            public string STEAM_10;
            public string STEAM_11;
            public string STEAM_12;
            public string STEAM_13;
            public string STEAM_14;
            public string STEAM_15;
            public string N2_1;
            public string N2_2;
            public string N2_3;
            public string N2_4;
            public string N2_5;
            public string N2_6;
            public string N2_7;
            public string N2_8;
            public string N2_9;
            public string N2_10;
            public string N2_11;
            public string N2_12;
            public string N2_13;
            public string N2_14;
            public string N2_15;
            public string NH3_1;
            public string NH3_2;
            public string NH3_3;
            public string NH3_4;
            public string NH3_5;
            public string NH3_6;
            public string NH3_7;
            public string NH3_8;
            public string NH3_9;
            public string NH3_10;
            public string NH3_11;
            public string NH3_12;
            public string NH3_13;
            public string NH3_14;
            public string NH3_15;
            public string ELECTRICAL_1;
            public string ELECTRICAL_2;
            public string ELECTRICAL_3;
            public string ELECTRICAL_4;
            public string ELECTRICAL_5;
            public string ELECTRICAL_6;
            public string ELECTRICAL_7;
            public string ELECTRICAL_8;
            public string ELECTRICAL_9;
            public string ELECTRICAL_10;
            public string ELECTRICAL_11;
            public string ELECTRICAL_12;
            public string ELECTRICAL_13;
            public string ELECTRICAL_14;
            public string ELECTRICAL_15;
            public string ELECTRICAL_TOTAL_1;
            public string ELECTRICAL_TOTAL_2;
            public string ELECTRICAL_TOTAL_3;
            public string ELECTRICAL_TOTAL_4;
            public string ELECTRICAL_TOTAL_5;
            public string ELECTRICAL_TOTAL_6;
            public string ELECTRICAL_TOTAL_7;
            public string ELECTRICAL_TOTAL_8;
            public string ELECTRICAL_TOTAL_9;
            public string ELECTRICAL_TOTAL_10;
            public string ELECTRICAL_TOTAL_11;
            public string ELECTRICAL_TOTAL_12;
            public string ELECTRICAL_TOTAL_13;
            public string ELECTRICAL_TOTAL_14;
            public string ELECTRICAL_TOTAL_15;
            public string IW_1;
            public string IW_2;
            public string IW_3;
            public string IW_4;
            public string IW_5;
            public string IW_6;
            public string IW_7;
            public string IW_8;
            public string IW_9;
            public string IW_10;
            public string IW_11;
            public string IW_12;
            public string IW_13;
            public string IW_14;
            public string IW_15;
            public string FW_1;
            public string FW_2;
            public string FW_3;
            public string FW_4;
            public string FW_5;
            public string FW_6;
            public string FW_7;
            public string FW_8;
            public string FW_9;
            public string FW_10;
            public string FW_11;
            public string FW_12;
            public string FW_13;
            public string FW_14;
            public string FW_15;

        }

        /// <summary>
        /// 上傳PDO
        /// </summary>
        [Serializable]
        public class UploadPDO : HMI_Structure
        {
            public int SerNo;
            public string EntryCoilID;
            public string ExitCoilID;
        }

        /// <summary>
        /// 上傳LineFault
        /// </summary>
        [Serializable]
        public class UploadDownTime : HMI_Structure
        {
            public string ProdTime;
            public string StopTime;
            public string StartTime;
            public OrignData OrignData;
        }

        [Serializable]
        public class OrignData
        {
            public string UnitCode { get; set; }

            public string ProdTime { get; set; }
            public string ProdShiftNo { get; set; }
            public string ProdShiftGroup { get; set; }

            public string StopStartTime { get; set; }
            public string StopEndTime { get; set; }
            public string DelayLocation { get; set; }
            public string DelayLocationDesc { get; set; }
            public int StopElasedTime { get; set; }
            public string DelayReasonCode { get; set; }
            public string DelayReasonDesc { get; set; }
            public string DelayRemark { get; set; }
            public int RespDepartDelayTimeM { get; set; }
            public int RespDepartDelayTimeE { get; set; }
            public int RespDepartDelayTimeC { get; set; }
            public int RespDepartDelayTimeP { get; set; }
            public int RespDepartDelayTimeU { get; set; }
            public int RespDepartDelayTimeO { get; set; }
            public int RespDepartDelayTimeR { get; set; }
            public int RespDepartDelayTimeRS { get; set; }
            public int FaultCode { get; set; }
            public string DecelerationCode { get; set; }
            public string DecelerationCause { get; set; }
        }

        /// <summary>
        /// 過渡捲請求
        /// </summary>
        [Serializable]
        public class DummyCoilListReq : HMI_Structure
        {
            public string DummyCoilID;
        }

        /// <summary>
        /// 過渡捲刪除
        /// </summary>
        [Serializable]
        public class DummyCoilListDelete : HMI_Structure
        {
            public string DummyCoilID;
            public string DeleteReasonCode;
            public string DeleteTime;
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
