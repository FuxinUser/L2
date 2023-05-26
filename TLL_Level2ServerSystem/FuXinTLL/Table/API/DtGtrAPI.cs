using L2;
using Models;
using FuXinTLL.Telegram.L1;
using System;
using System.Collections.Generic;
/**
 Author:ICSC 鄭天智
 Date:2020/1/1
 Desc:資料收集業務
**/
namespace FuXinTLL.Table
{
    public class DtGtrAPI
    {
        private static DBHandler dbHand;
        public DtGtrAPI(DBHandler p)
        {
            dbHand = p;
        }

        public bool Insert_EquipStatus(L1ToL2_Structure.L1L2_EquipMaint msg)
        {
            //undone 接收設備狀態
            var equip = new TBL_LineStatus()
            {
                CreateDateTime = DateTime.Now,
                StatusEn = msg.StatusEn,
                StatusTLL = msg.StatusTLL,
                StatusEx = msg.StatusEx
            };
            return dbHand.InsertOnly(equip);
        }

        //2021/11/22 改為by meter  
        public void Insert_ProcessData(string coilID, string headPos,string lop1Pos,string lop2Pos, L1ToL2_Structure.L1L2_SpdTen msg)
        {
            //計算各位置米數，從鋼捲焊接完後，開始計算
            string UnCoilMeter;
            string EnLoopMeter;
            string LevelerMeter;
            string ExLoopMeter;
            string ReCoilMeter;

            float meter;
            meter = (float)Math.Round(Convert.ToDouble(headPos), 3);
            if (meter <= 0) return;
            UnCoilMeter = (TblConst.ProcessLocationMeter.UnCoil + meter).ToString();
            ReCoilMeter = TblConst.ProcessLocationMeter.ReCoil + meter > 0 ? (TblConst.ProcessLocationMeter.ReCoil + meter).ToString() : "Null";
            EnLoopMeter = TblConst.ProcessLocationMeter.EnLoopMeter + meter > 0 ? (TblConst.ProcessLocationMeter.EnLoopMeter + meter).ToString() : "Null";
            ExLoopMeter = TblConst.ProcessLocationMeter.ExLoopMeter + meter > 0 ? (TblConst.ProcessLocationMeter.ExLoopMeter + meter).ToString() : "Null";
            LevelerMeter = TblConst.ProcessLocationMeter.LevelerMeter + meter > 0 ? (TblConst.ProcessLocationMeter.LevelerMeter + meter).ToString() : "Null";

            //計算loop距離

            //新增TBL_ProcessData資料
            TBL_ProcessData pd = new TBL_ProcessData()
            {
                CreateDateTime = DateTime.Now,
                CoilID = coilID,
                CoilWidthActual = msg.CoilWidthActual,
                ElongationAct = msg.ElongationAct,
                ElongationRef = msg.ElongationRef,
                LevelerIntermesh1Act = msg.LevelerIntermesh1Act,
                LevelerIntermesh1Ref = msg.LevelerIntermesh1Ref,
                LevelerIntermesh2Act = msg.LevelerIntermesh2Act,
                LevelerIntermesh2Ref = msg.LevelerIntermesh2Ref,
                LevelerIntermesh3Act = msg.LevelerIntermesh3Act,
                LevelerIntermesh3Ref = msg.LevelerIntermesh3Ref,
                SpeedActEn = msg.SpeedActEn,
                SpeedActEx = msg.SpeedActEx,
                SpeedActProcess = msg.SpeedActProcess,
                TenActEnLop = msg.TenActEnLop,
                TenRefEnLop = msg.TenRefEnLop,
                TenActExLop = msg.TenActExLop,
                TenRefExLop = msg.TenRefExLop,
                TenActLeveler = msg.TenActLeveler,
                TenRefLeveler = msg.TenRefLeveler,
                TenActRec = msg.TenActRec,
                TenRefRec = msg.TenRefRec,
                TenActUnc = msg.TenActUnc,
                TenRefUnc = msg.TenRefUnc,
                EnLoopMeter = EnLoopMeter,
                ExLoopMeter = ExLoopMeter,
                LevelerMeter = LevelerMeter,
                UnCoilMeter = UnCoilMeter,
                ReCoilMeter = ReCoilMeter             
            };
            dbHand.InsertOnly(pd);
        }

        ///查詢TBL_ProcessData第一筆
        public TBL_ProcessData Query_TBL_ProcessDataFirstData(string coilID)
        {
            string sqlstr = $"select Top (1) * from {nameof(TBL_ProcessData)} Where {nameof(TBL_ProcessData.CoilID)} = '{coilID}' Order by {nameof(TBL_ProcessData.CreateDateTime)} desc";
            return dbHand.QueryFirst<TBL_ProcessData>(sqlstr);
        }

        ///查詢ALL TBL_ProcessData 資料
        public List<TBL_ProcessData> Query_TBL_ProcessDataALLData()
        {
            string sqlstr = $"select * from {nameof(TBL_ProcessData)} Order by {nameof(TBL_ProcessData.CreateDateTime)}";
            return dbHand.QueryList<TBL_ProcessData>(sqlstr);
        }


        ///刪除ALL TBL_ProcessData 資料
        public bool Delete_TBL_ProcessDataALLData()
        {
            string sqlstr = $"Delete FROM {nameof(TBL_ProcessData)}";
            return dbHand.Execute(sqlstr);
        }

        //新增 TBL_ProcessDataCT 資料
        public bool Insert_TBL_ProcessDataCT(List<TBL_ProcessDataCT> tBL_ProcessDataCTs)
        {
            return dbHand.InsertList(tBL_ProcessDataCTs);
        }

        //查詢 TBL_ProcessDataCT 資料
        public List<TBL_ProcessDataCT> Query_TBL_ProcessDataCT(string exitCoil, string planNo, int SerNo)
        {
            string sqlstr = $"select * from {nameof(TBL_ProcessDataCT)} where {nameof(TBL_ProcessDataCT.SerNo)} = {SerNo} and  {nameof(TBL_ProcessDataCT.Out_Coil_No)} = '{exitCoil}' and  {nameof(TBL_ProcessDataCT.Plan_No)} = '{planNo}' Order by {nameof(TBL_ProcessDataCT.Create_DateTime)} desc";
            return dbHand.QueryList<TBL_ProcessDataCT>(sqlstr);
        }


        public TBL_DownTime Query_LastLineFault()
        {
            string sql = $"Select Top (1) * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.StopEndTime) } = '' Order by {nameof(TBL_DownTime.CreateDateTime)} DESC";
            return dbHand.QueryFirst<TBL_DownTime>(sql);
        }

        public TBL_DownTime Query_LineFault(string prodTime)
        {
            string sql = $"Select * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.ProdTime)} = '{prodTime}'";
            return dbHand.QueryFirst<TBL_DownTime>(sql);
        }

        public TBL_DownTime Query_LineFault(string prodTime, string startTime)
        {
            string sql = $"Select * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.ProdTime)} = '{prodTime}' and {nameof(TBL_DownTime.StopStartTime)} = '{startTime}'";
            return dbHand.QueryFirst<TBL_DownTime>(sql);
        }

        /// <summary>
        /// 更新停復機紀錄 upload
        /// </summary>
        /// <param name="recoverTime"></param>
        /// <returns></returns>
        public bool Update_DownTime(TBL_DownTime downTime)
        {
            return dbHand.UpdateOnly(downTime);
        }

        public bool Insert_LineFault(string prodTime, int faultCode, string stopTime)
        {
            string shit = string.Empty;
            string team = string.Empty;
            var shiftTable = DBService.SysAPI.Query_ShiftTable(DateTime.Now);
            if (shiftTable != null)
            {
                shit = shiftTable.Shift;
                team = shiftTable.Team;

            }

            var shutDown = new TBL_DownTime()
            {
                CreateDateTime = DateTime.Now,
                ProdTime = prodTime,
                FaultCode = faultCode,
                StopStartTime = stopTime,
                StopEndTime = "",
                ProdShiftNo = shit,
                ProdShiftGroup = team,
                UnitCode = "TL"
            };
            return dbHand.InsertOnly(shutDown);
        }

        /// <summary>
        /// 更新最後一筆停機記錄的復機時間
        /// </summary>
        /// <param name="recoverTime"></param>
        /// <returns></returns>
        public bool Update_LastLineFault(string et)
        {
            var lastLineFault = Query_LastLineFault();

            var endDt = et;
            bool isOk = false;
            if (lastLineFault != null)
            {
                //更新覆機時間
                DateTime stopTime = DateTime.ParseExact(endDt, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                DateTime startTime = DateTime.ParseExact(lastLineFault.StopStartTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                lastLineFault.StopEndTime = endDt;
                //更新持續時間
                lastLineFault.StopElasedTime = (int)(stopTime - startTime).TotalMinutes;
                isOk = dbHand.UpdateOnly(lastLineFault);
            }

            return isOk;
        }

        /// <summary>
        /// 新增停機記錄
        /// </summary>
        /// <param name="prodTime"></param>
        /// <param name="shift"></param>
        /// <param name="team"></param>
        /// <param name="faultCode"></param>
        /// <returns></returns>
        public bool Insert_LineFault(string prodTime, string shift, string team, int faultCode, string strStopStartTime)
        {
            ///check 是否重複
            string[] stopStartTimeArray = strStopStartTime.Split('-', ' ', ':');
            string stopStartTime = string.Empty;
            foreach (var item in stopStartTimeArray)
            {
                stopStartTime += item;
            }
            var record = Query_CheckBeginLineFault();
            if (record == null)
            {
                var shutDown = new TBL_DownTime()
                {
                    CreateDateTime = DateTime.Now,
                    ProdTime = prodTime,
                    FaultCode = faultCode,
                    StopStartTime = stopStartTime,
                    StopEndTime = "",//停機時間
                    ProdShiftNo = shift,
                    ProdShiftGroup = team,
                    UnitCode = "TL",
                };
                dbHand.InsertOnly(shutDown);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 預防發送連續停機
        /// </summary>
        /// <returns></returns>
        public TBL_DownTime Query_CheckBeginLineFault()
        {
            string sql = $"Select Top (1) * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.StopEndTime) } = '' Order by {nameof(TBL_DownTime.CreateDateTime)} DESC";
            return dbHand.QueryFirst<TBL_DownTime>(sql);
        }

        public bool Update_LineRecover(string prodTime, string endTime, string startTime)
        {
            string sql = $"Select * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.ProdTime)} = '{prodTime}' and {nameof(TBL_DownTime.StopStartTime)} = '{startTime}'";

            var dt = dbHand.QueryFirst<TBL_DownTime>(sql);

            //更新覆機時間
            DateTime stopDateTime = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            DateTime startDateTime = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            dt.StopEndTime = endTime;
            //更新持續時間
            dt.StopElasedTime = (int)(stopDateTime - startDateTime).TotalMinutes;

            return dbHand.UpdateOnly(dt);
        }

        public List<TBL_DownTime> Query_LineFault(DateTime current)
        {
            string sqlStr = $"Select * From {nameof(TBL_DownTime)} Where {nameof(TBL_DownTime.StopEndTime)} >= {current.ToString("yyyyMMddHHmmss")}";
            return dbHand.QueryList<TBL_DownTime>(sqlStr);
        }

        public bool Insert_Utility(L1ToL2_Structure.L1L2_Consumables msg)
        {
            var utility = new TBL_Utility()
            {
                CreateDateTime = DateTime.Now,
                CompressedAir = msg.CompressedAir,
                Steam = msg.Steam,
                PortableWater = msg.PortableWater,
                IndirectCollingWater = msg.IndirectCollingWater,
                DeW = msg.DeW,
                IW = msg.IW
            };
            return dbHand.InsertOnly(utility);
        }
    }
}
