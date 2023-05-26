using FuXinTLL.Telegram.L1;
using FuXinTLL.Telegram.WMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuXinTLL.Telegram
{
    public class WMSAPI
    {
        public L2ToWms_Structure.TW01 Create_TW01(List<string> coilNos)
        {
            string totalCoils = string.Join("", coilNos.Select(x => x.PadRight(20)));

            var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW01>("TW01");
            var wt01 = new L2ToWms_Structure.TW01()
            {
                MessageID = header.Message_ID,
                Length = header.Length,
                IDOfDestinationComputer = header.ID_Of_Destination_Computer,
                IDOfSourceComputer = header.ID_Of_Source_Computer,
                ProcessDateTime = header.Process_Date_Time,
                Count = coilNos.Count.ToString().ToChars(4),
                CoilNo = totalCoils.PadRight(6000).ToCharArray(),
                Spare = "".PadRight(10).ToCharArray()
            };
            return wt01;
        }

        public L2ToWms_Structure.TW02 Create_TW02_ByTrkEn(L1ToL2_Structure.L1L2_TrackMapEn msg, TBL_TrackMap RecSkid1, TBL_TrackMap RecSkid2, TBL_TrackMap Dtop,bool _isAutoFeedMode)
        {
            var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW02>("TW02");
            L2ToWms_Structure.TW02 tw02 = new L2ToWms_Structure.TW02()
            {
                MessageID = header.Message_ID,
                Length = header.Length,
                IDOfDestinationComputer = header.ID_Of_Destination_Computer,
                IDOfSourceComputer = header.ID_Of_Source_Computer,
                ProcessDateTime = header.Process_Date_Time,

                EntryExit1 = "1".ToCharArray(),

                sk11 = Formatter.GetFixedChar(msg.CoilIDSkid1, 20),
                sk12 = Formatter.GetFixedChar(msg.CoilIDSkid2, 20),
                sk13 = Formatter.GetFixedChar(msg.CoilIDSkid3, 20),
                TopSensor1 = "".PadRight(1).ToCharArray(),

                EntryExit2 = "2".ToCharArray(),
                sk21 = Formatter.GetFixedChar(Dtop.CoilID, 20),
                sk22 = Formatter.GetFixedChar(RecSkid1.CoilID, 20),
                sk23 = Formatter.GetFixedChar(RecSkid2.CoilID, 20),
                TopSensor2 = "".PadRight(1).ToCharArray(),

                EntryExit3 = "0".ToCharArray(),
                sk31 = "".PadRight(20).ToCharArray(),
                sk32 = "".PadRight(20).ToCharArray(),
                sk33 = "".PadRight(20).ToCharArray(),
                TopSensor3 = "".PadRight(1).ToCharArray(),
                Line_Satus = _isAutoFeedMode ? "2".ToCharArray() : "1".ToCharArray(),
                Spare = "".PadRight(7).ToCharArray()
            };
            return tw02;
        }

        //public L2ToWms_Structure.TW02 Create_TW02_ByTrkEx(L1ToL2_Structure.Msg_306 msg, TBL_TrackMap Skid1, TBL_TrackMap Skid2, TBL_TrackMap Etop)
        //{
        //    var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW02>("TW02");
        //    L2ToWms_Structure.TW02 tw02 = new L2ToWms_Structure.TW02()
        //    {
        //        MessageID = header.Message_ID,
        //        Length = header.Length,
        //        IDOfDestinationComputer = header.ID_Of_Destination_Computer,
        //        IDOfSourceComputer = header.ID_Of_Source_Computer,
        //        ProcessDateTime = header.Process_Date_Time,

        //        EntryExit1 = "1".ToCharArray(),
        //        sk11 = Formatter.GetFixedChar(Skid1.CoilID, 20),
        //        sk12 = Formatter.GetFixedChar(Skid2.CoilID, 20),
        //        sk13 = Formatter.GetFixedChar(Etop.CoilID, 20),

        //        EntryExit2 = "2".ToCharArray(),
        //        sk21 = Formatter.GetFixedChar(msg.CoilIDRecSkid1, 20),
        //        sk22 = Formatter.GetFixedChar(msg.CoilIDRecSkid2, 20),
        //        sk23 = Formatter.GetFixedChar(msg.CoilIDRecSkid3, 20),

        //        EntryExit3 = "0".ToCharArray(),
        //        Line_Satus = "2".ToCharArray()
        //    };
        //    return tw02;
        //}

        public L2ToWms_Structure.TW03 Create_TW03(TBL_CoilPDO pdo, float GW,string WholebacklogCode)
        {
            var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW03>("TW03");   //undone: 缺少PDO資料

            var tw03 = new L2ToWms_Structure.TW03()
            {
                MessageID = header.Message_ID,
                ProcessDateTime = header.Process_Date_Time,
                IDOfSourceComputer = header.ID_Of_Source_Computer,
                IDOfDestinationComputer = header.ID_Of_Destination_Computer,
                Length = header.Length,

                Orderno = pdo.OrderNo.PadRight(20).ToCharArray(),
                InCoilno = pdo.EntryCoilID.PadRight(20).ToCharArray(),
                OutCoilno = pdo.ExitCoilID.PadRight(20).ToCharArray(),
                CoilContainsOil = (true ? "1" : "0").ToChars(1),
                CoilThick = System.Convert.ToString(System.Math.Round(pdo.ExitCoilThick, 3)).PadLeft(9, '0').ToCharArray(),
                CoilWidth = System.Convert.ToString(System.Math.Round(pdo.ExitCoilWidth, 1)).PadLeft(7, '0').ToCharArray(),
                CoilWeight = System.Convert.ToString(System.Math.Round(GW)).PadLeft(5, '0').ToCharArray(),
                CoilTurn = pdo.CoilerDirection == "U" ? "0".ToCharArray() : "1".ToCharArray(),
                InnerDia = System.Convert.ToString(pdo.ExitCoilInnerDiam).PadLeft(4, '0').ToCharArray(),
                OuterDia = System.Convert.ToString(pdo.ExitCoilOuterDiam).PadLeft(4, '0').ToCharArray(),
                Next_WholeBackLog_Code = WholebacklogCode.PadRight(2).ToCharArray(),
                PackType = pdo.ExitPaperType.PadRight(5).ToCharArray(),
                Spare = "".PadRight(16).ToCharArray()
            };
            return tw03;
        }

        /// <summary>出料/叫料 取消</summary>
        /// <param name="isEn"></param>
        /// <returns></returns>
        //public L2ToWms_Structure.TW04 Create_TW04(bool isEn, string coilID)
        //{
        //    //undone 畫面沒有先不作
        //    var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW04>("TW04");
        //    char[] isEnRequest = new char[1];
        //    isEnRequest[0] = isEn ? '1' : '2';

        //    L2ToWms_Structure.TW04 wt04 = new L2ToWms_Structure.TW04()
        //    {
        //        MessageID = header.Message_ID,
        //        Length = header.Length,
        //        IDOfDestinationComputer = header.ID_Of_Destination_Computer,
        //        IDOfSourceComputer = header.ID_Of_Source_Computer,
        //        ProcessDateTime = header.Process_Date_Time,

        //        CoilNo = coilID.PadRight(20).ToCharArray(),
        //        Flag = isEnRequest,
        //        Spare = Formatter.GetFixedChar("", 3)
        //    };
        //    return wt04;
        //}

        /// <summary>入料/出料/退料 要求</summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public L2ToWms_Structure.TW05 Create_TW05(WmsCmd flag, string coilID, int skidNo)
        {
            var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW05>("TW05");
            L2ToWms_Structure.TW05 wt05 = new L2ToWms_Structure.TW05()
            {
                MessageID = header.Message_ID,
                Length = header.Length,
                IDOfDestinationComputer = header.ID_Of_Destination_Computer,
                IDOfSourceComputer = header.ID_Of_Source_Computer,
                ProcessDateTime = header.Process_Date_Time,

                SkidNo = skidNo.ToString().ToCharArray(),
                Flag = ((int)flag).ToString().ToCharArray(),
                CoilNo = coilID.PadRight(20).ToCharArray(),
                Spare = "".PadRight(12).ToCharArray(),
            };
            return wt05;
        }

        /// <summary>天車入料 鋼捲掃描通知</summary>
        /// <returns></returns>
        public L2ToWms_Structure.TW06 Create_TW06(int skid, string scanedCoilId)
        {
            var header = MsgFactory.GetWMSHeader<L2ToWms_Structure.TW06>("TW06");
            L2ToWms_Structure.TW06 tw06 = new L2ToWms_Structure.TW06()
            {
                MessageID = header.Message_ID,
                Length = header.Length,
                IDOfDestinationComputer = header.ID_Of_Destination_Computer,
                IDOfSourceComputer = header.ID_Of_Source_Computer,
                ProcessDateTime = header.Process_Date_Time,

                SkidNo = skid.ToString().ToCharArray(),
                CoilNo = scanedCoilId.PadRight(20).ToCharArray(),
                Spare = "".PadRight(13).ToCharArray(),
            };
            return tw06;
        }
    }
}
