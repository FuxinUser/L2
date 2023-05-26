using L2;
using Models;
using FuXinTLL.Telegram.HMI;
using FuXinTLL.Telegram.L1;
using FuXinTLL.Telegram.MMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuXinTLL.Table
{
    public class CoilAPI
    {
        private static DBHandler dbHand;
        public CoilAPI(DBHandler p)
        {
            dbHand = p;
        }

        public bool Insert_SampleCutData(TBL_L1_ExCoilCutData data)
        {
            return dbHand.InsertOnly(data);
        }

        public List<TBL_L1_ExCoilCutData> Query_ExCutData(string exitCoilID, int cutMode)
        {
            string sql = $"Select * From {nameof(TBL_L1_ExCoilCutData)} Where {nameof(TBL_L1_ExCoilCutData.CoilID)} = '{exitCoilID}' And {nameof(TBL_L1_ExCoilCutData.CutMode)} = {cutMode}";
            return dbHand.QueryList<TBL_L1_ExCoilCutData>(sql);
        }

        public TBL_CoilPDI Query_PDI(string coilID)
        {
            string sqlstr = $"select * from {nameof(TBL_CoilPDI)} where {nameof(TBL_CoilPDI.EntryCoilID)} = '{coilID}' Order by {nameof(TBL_CoilPDI.CreateDateTime)} desc";
            return dbHand.QueryFirst<TBL_CoilPDI>(sqlstr);
        }

        public TBL_CoilPDI Query_PDI_By_PlanNo(string coilID, string planNo)
        {
            string sqlstr = $"Select Top 1 * from {nameof(TBL_CoilPDI)} where {nameof(TBL_CoilPDI.EntryCoilID)} = '{coilID}' and {nameof(TBL_CoilPDI.PlanNo)} = '{planNo}'  order by  {nameof(TBL_CoilPDI.CreateDateTime)} desc";
            var ans = dbHand.QueryFirst<TBL_CoilPDI>(sqlstr);
            return ans;
        }

        /// <summary>依計畫案刪除生產命令</summary>
        /// <param name="PlanNo">計畫案號</param>
        public bool Delete_ScheduleByPlanNo(string PlanNo)
        {
            string sqlstr = $"Delete From {nameof(TBL_CoilSchedule)} Where {nameof(TBL_CoilSchedule.Coil_ID)} In (Select {nameof(TBL_CoilPDI.EntryCoilID)} From {nameof(TBL_CoilPDI)} Where {nameof(TBL_CoilPDI.PlanNo)} ='{PlanNo}')";
            return dbHand.Execute(sqlstr);
        }

        public List<TBL_CoilSchedule> Query_CoilSchedule()
        {
            return dbHand.QueryAll<TBL_CoilSchedule>();
        }

        public List<string> Query_First3CoilSchedule()
        {
            string sql = $"Select Top 3 {nameof(TBL_CoilSchedule.Coil_ID)} From {nameof(TBL_CoilSchedule)} Order by {nameof(TBL_CoilSchedule.Sequence_No)}";
            return dbHand.QueryList<string>(sql);
        }

        public List<TBL_CoilPDI> Query_PDIByPlanNoAndSchedule(string planNo)
        {
            string sqlstr = $"Select * From {nameof(TBL_CoilPDI)} Right Join {nameof(TBL_CoilSchedule)} On {nameof(TBL_CoilPDI.EntryCoilID)} = {nameof(TBL_CoilSchedule.Coil_ID)}  Where {nameof(TBL_CoilPDI.PlanNo)} = '{planNo}'";
            return dbHand.QueryList<TBL_CoilPDI>(sqlstr);
        }


        public List<TBL_PDI_DefectData> Query_PdiDefect(string CoilID)
        {
            string sqlStr = $"Select * from {nameof(TBL_PDI_DefectData)} Where {nameof(TBL_PDI_DefectData.CoilID)} = '{CoilID}'";
            return dbHand.QueryList<TBL_PDI_DefectData>(sqlStr);
        }

        public List<TBL_PDO_DefectData> Query_PdoDefect(string CoilID)
        {
            string sqlStr = $"Select * from {nameof(TBL_PDO_DefectData)} Where {nameof(TBL_PDO_DefectData.CoilID)} = '{CoilID}'";
            return dbHand.QueryList<TBL_PDO_DefectData>(sqlStr);
        }

        public TBL_LookupTable_Flatter Query_LookupTable_Flatter(string steelCode, float EntryCoilThick)
        {
            string sqlStr = $@"Select top 1 * From {nameof(TBL_LookupTable_Flatter)} 
                            WHERE {nameof(TBL_LookupTable_Flatter.SteelNo)}='{steelCode}'  
                            And {nameof(TBL_LookupTable_Flatter.EntryCoilThickMax)} >= {EntryCoilThick} 
                            And {nameof(TBL_LookupTable_Flatter.EntryCoilThickMin)} <= {EntryCoilThick}";

            return dbHand.QueryFirst<TBL_LookupTable_Flatter>(sqlStr);
        }

        public TBL_LookupTable_Leveler Query_LookupTable_Leveler(string steelCode, float EntryCoilThick)
        {
            string sqlStr = $@"Select top 1 * From {nameof(TBL_LookupTable_Leveler)} 
                            WHERE {nameof(TBL_LookupTable_Leveler.SteelNo)}='{steelCode}'  
                            And {nameof(TBL_LookupTable_Leveler.EntryCoilThickMax)} >= {EntryCoilThick} 
                            And {nameof(TBL_LookupTable_Leveler.EntryCoilThickMin)} <= {EntryCoilThick}";

            return dbHand.QueryFirst<TBL_LookupTable_Leveler>(sqlStr);
        }

        public TBL_LookupTable_Tension Query_LookupTable_Tension(string steelCode, float EntryCoilWidth, float EntryCoilThick)
        {
            string sqlStr = $@"Select top 1 * From {nameof(TBL_LookupTable_Tension)} 
                            WHERE {nameof(TBL_LookupTable_Tension.SteelNo)}='{steelCode}'  
                            And {nameof(TBL_LookupTable_Tension.EntryCoilWidthMax)} >= {EntryCoilWidth}
                            And {nameof(TBL_LookupTable_Tension.EntryCoilWidthMin)} <= {EntryCoilWidth} 
                            And {nameof(TBL_LookupTable_Tension.EntryCoilThickMax)} >= {EntryCoilThick} 
                            And {nameof(TBL_LookupTable_Tension.EntryCoilThickMin)} <= {EntryCoilThick}";

            return dbHand.QueryFirst<TBL_LookupTable_Tension>(sqlStr);
        }

        public TBL_LookupTable_Trimmer Query_LookupTable_Trimmer(string steelCode, float EntryCoilThick)
        {
            string sqlStr = $@"Select top 1 * From {nameof(TBL_LookupTable_Trimmer)} 
                            WHERE {nameof(TBL_LookupTable_Trimmer.SteelNo)}='{steelCode}'  
                            And {nameof(TBL_LookupTable_Trimmer.EntryCoilThickMax)} >= {EntryCoilThick} 
                            And {nameof(TBL_LookupTable_Trimmer.EntryCoilThickMin)} <= {EntryCoilThick}";

            return dbHand.QueryFirst<TBL_LookupTable_Trimmer>(sqlStr);
        }

        public TBL_LookupTable_Mapping Query_LookupTabl_Mapping(string steelNo)
        {
            string sqlStr = $@"Select top 1 * From {nameof(TBL_LookupTable_Mapping)} 
                            WHERE {nameof(TBL_LookupTable_Mapping.STNo)} like '{steelNo}%'";


            return dbHand.QueryFirst<TBL_LookupTable_Mapping>(sqlStr);
        }


        public bool InsertOrUpdate_PDI(TBL_CoilPDI pdi)
        {
            if (pdi.CreateDateTime == null) pdi.CreateDateTime = DateTime.Now;
            var isOk = dbHand.InsertOrUpdate(pdi);
            return isOk;
        }

        public void InsertOrUpdate_PDI(MmsToL2_Structure.PDI_MMT202 msg)
        {
            string CoilNo = new string(msg.in_mat_No).Trim();
            string PlanNo = new string(msg.Plan_No).Trim();

            #region PDI資料
            var tblPdi = new TBL_CoilPDI()
            {
                CreateDateTime = DateTime.Now,
                PlanNo = PlanNo,
                MatSeqNo = Formatter.ParseToInt(msg.Mat_Seq_No),
                PlanSort = new string(msg.Plan_Sort).Trim(),
                EntryCoilID = CoilNo,

                EntryCoilThick = Formatter.ParseToFloat(msg.in_mat_Thick, 3),
                EntryCoilWidth = Formatter.ParseToFloat(msg.in_mat_Width, 1),
                EntryCoilWeight = Formatter.ParseToInt(msg.in_mat_wt),
                EntryCoilLength = Formatter.ParseToInt(msg.In_mat_Length),
                EntryCoilInnerDiam = Formatter.ParseToInt(msg.In_mat_Inner),
                EntryCoilOuterDiam = Formatter.ParseToInt(msg.In_mat_Dcos),

                MaterialCoilFlatness = Formatter.ParseToInt(msg.MaterialCoilFlatness),
                OutCoilID = new string(msg.out_mat_No).Trim(),
                OutCoilThick = Formatter.ParseToFloat(msg.OUT_MAT_THICK, 3),
                OutCoilWidth = Formatter.ParseToFloat(msg.OUT_MAT_WIDTH, 1),
                OutCoilInnerDiam = Formatter.ParseToInt(msg.Out_Coil_Inner),
                //PaperEntryFlag = new string(msg.Paper_code),

                PaperEntryType = new string(msg.Paper_code).Trim().PadLeft(2, '0'),
                PaperEntryHeadLength = Formatter.ParseToInt(msg.HEAD_PAPER_LENGTH),
                PaperEntryHeadWidth = Formatter.ParseToFloat(msg.HEAD_PAPER_WIDTH, 1),
                PaperEntryTailLength = Formatter.ParseToInt(msg.TAIL_PAPER_LENGTH),
                PaperEntryTailWidth = Formatter.ParseToFloat(msg.TAIL_PAPER_WIDTH, 1),

                OrderNo = new string(msg.Order_No).Trim(),

                OrderWeightMin = Formatter.ParseToInt(msg.Order_Weight_Min),
                OrderWeightMax = Formatter.ParseToInt(msg.Order_Weight_Max),
                OrderThick = Formatter.ParseToFloat(msg.Order_Thick, 3),
                OrderThickMin = Formatter.ParseToFloat(msg.Order_Thick_Min, 3),
                OrderThickMax = Formatter.ParseToFloat(msg.Order_Thick_Max, 3),
                OrderWidth = Formatter.ParseToFloat(msg.Order_width, 1),
                OrderWidthMax = Formatter.ParseToFloat(msg.ORDER_MAX_WIDTH, 1),
                OrderWidthMin = Formatter.ParseToFloat(msg.ORDER_MIN_WIDTH, 1),
                OrderInner = Formatter.ParseToInt(msg.Order_Inner),
                OrderElongationMax = Formatter.ParseToInt(msg.Elongation_max),
                OrderElongationMin = Formatter.ParseToInt(msg.Elongation_min),

                YdStandMax = Formatter.ParseToInt(msg.Yd_stand_max),
                YdStandMin = Formatter.ParseToInt(msg.Yd_stand_min),
                HardnessMax = Formatter.ParseToInt(msg.Hardness_max),
                HardnessMin = Formatter.ParseToInt(msg.Hardness_min),
                TsStandMax = Formatter.ParseToInt(msg.Ts_stand_max),
                TsStandMin = Formatter.ParseToInt(msg.Ts_stand_min),
                Density = Formatter.ParseToInt(msg.Density),
                CoilOrigin = new string(msg.Coil_Origin).Trim(),
                WholebacklogCode = new string(msg.Wholebacklog_code).Trim(),
                NextWholebacklogCode = new string(msg.Next_wholebacklog_code).Trim(),

                DividingFlag = new string(msg.Dividing_Flag).Trim(),
                TestPlanNo = new string(msg.test_plan_no).Trim(),

                SurfaceAccuCodeIn = new string(msg.SURFACE_ACCU_CODE_IN).Trim(),
                SurfaceAccuCodeOut = new string(msg.SURFACE_ACCU_CODE_OUT).Trim(),

                SteelGradeSign = new string(msg.SG_Sign).Trim(),
                SteelGradeCode = new string(msg.St_no).Trim(),
                PackType = new string(msg.Pack_code).Trim(),
                //StrapNum = new string(msg.Strap_num),

                OrderSurfaceCode = new string(msg.SURFACE_ACCU_CODE).Trim(),
                SourceSurfaceCode = new string(msg.SURFACE_ACCURACY).Trim(),

                //PaperUnwinderFlag = new string(msg.paper),
                ExitSleeveFlag = new string(msg.SLEEVE_TYPE_CODE).Trim(),
                EntrySleeveType = new string(msg.SLEEVE_TYPE_CODE).Trim(),
                EntrySleeveInnerDiam = Formatter.ParseToInt(msg.SLEEVE_DIAMTER),
                ExitSleeveInnerDiam = Formatter.ParseToInt(msg.OUT_SLEEVE_DIAMTER),
                BaseSurface = new string(msg.Base_Surface).Trim(),
                DecoilerDirection = new string(msg.Decoiler_Direction).Trim(),
                SampleFlag = new string(msg.SAMP_FLAG).Trim(),
                SampleFrqnCode = new string(msg.SAMPLE_FRQN_CODE).Trim(),
                SampleLotNo = new string(msg.sample_lot_no).Trim(),
                TrimFlag = new string(msg.Trimmer_Flag).Trim(),

                OrderBetterSurfWardCode = new string(msg.ORDER_BETTER_SURF_WARD_CODE).Trim(),
                QCState = Encoding.UTF8.GetString(msg.QC_REMARK),
                WindingDire = new string(msg.WINDING_DIRE).Trim(),
                CustomerNameEng = Encoding.UTF8.GetString(msg.Customer_Name_E),
                CustomerNameChn = Encoding.UTF8.GetString(msg.Customer_Name_C),
                OrderSurfaceDesc = new string(msg.SURFACE_ACCU_DESC).Trim(),
                SourceSurfaceDesc = new string(msg.SURFACE_ACCURACY_DESC).Trim(),

                //undone lookup table
                DividingNum = Formatter.ParseToInt(msg.dividing_num),
                DummyFlag = DummyFlag.notDummy,
                State = "N"//預設[N:未上線]
            };

            //未定案的特例先設成0
            foreach (var item in tblPdi.GetType().GetProperties())
            {
                if (item.GetValue(tblPdi) == null && item.PropertyType == typeof(string))
                {
                    item.SetValue(tblPdi, "0");
                }
            }
            dbHand.InsertOrUpdate(tblPdi);
            #endregion

            #region 缺陷資料
            var tblPdiDefect = new List<TBL_PDI_DefectData>();

            if (!string.IsNullOrWhiteSpace(new string(msg.Defect1.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 1, msg.Defect1);
                tblPdiDefect.Add(tblDefect);
            }

            if (!string.IsNullOrWhiteSpace(new string(msg.Defect2.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 2, msg.Defect2);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect3.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 3, msg.Defect3);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect4.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 4, msg.Defect4);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect5.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 5, msg.Defect5);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect6.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 6, msg.Defect6);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect7.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 7, msg.Defect7);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect8.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 8, msg.Defect8);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect9.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 9, msg.Defect9);
                tblPdiDefect.Add(tblDefect);
            }
            if (!string.IsNullOrWhiteSpace(new string(msg.Defect10.Code)))
            {
                Models.TBL_PDI_DefectData tblDefect = FromDefect(CoilNo, 10, msg.Defect10);
                tblPdiDefect.Add(tblDefect);
            }
            if (tblPdiDefect.Count > 0)
            {
                dbHand.InsertOrUpdate(tblPdiDefect);
            }
            #endregion
        }

        private static TBL_PDI_DefectData FromDefect(string coilNo, int groupNo, MMS_Defect_Structure defect)
        {
            var tblDefect = new TBL_PDI_DefectData()
            {
                CoilID = coilNo,
                DefectGroupNo = groupNo,
                DefectCode = new string(defect.Code),
                DefectLevel = new string(defect.Level),
                DefectOrigin = new string(defect.Origin),
                DefectSide = new string(defect.Side),
                DefectPercent = new string(defect.Percent),
                DefectPositionLengthStartDirection = new string(defect.LengthStartDirection),
                DefectPositionLengthEndDirection = new string(defect.LengthEndDirection),
                DefectPositionWidthDirection = new string(defect.WidthDirection),
                DefectQualityGrade = new string(defect.Quakity_Grade)
            };
            return tblDefect;
        }

        /// <summary>清除生產命令</summary>
        /// <param name="coilID">鋼捲號</param>
        public bool Clear_Schedule(string coilID)
        {
            //if (coilID.Trim() == "0")
            //{
            //    //排程全部清空
            //    DBService.CoilAPI.Delete_Schedule();
            //    //2021/8/25 下發排程0  HMI可從新選擇排成一次
            //    var systemData = DBService.TrkAPI.Query_L2SystemSetting(TblConst.L2SystemSetting.TopScheduleLock);
            //    systemData.Value = "False";
            //    dbHand.InsertOrUpdate(systemData);
            //}
            //else
            //{
            //    //undone 判斷L3給的鋼捲是否正確 錯誤訊息: This Coil is not found in L2 coil schedule
            //    //判斷此鋼捲是否在排程資料表裡面
            //    //bool isExist =  DBService.CoilAPI.Query_ScheduleForCoilNo(coilID);
            //    //把此鋼捲之後的清除
            //    string sqlstr = $"delete from {nameof(TBL_CoilSchedule)} where {nameof(TBL_CoilSchedule.SequenceNo)} > (select  Min({nameof(TBL_CoilSchedule.SequenceNo)}) from {nameof(TBL_CoilSchedule)} Where {nameof(TBL_CoilSchedule.CoilID)} = '{coilID}')";
            //    dbHand.Execute(sqlstr);
            //}
            //return true;

            if (coilID.Trim() == "0")
            {
                //2021/8/25 下發排程0  HMI可從新選擇排成一次
                var systemData = DBService.TrkAPI.Query_L2SystemSetting(TblConst.L2SystemSetting.TopScheduleLock);
                systemData.Value = "False";

                dbHand.InsertOrUpdate(systemData);

                //排程全部清空
                return dbHand.DelAll<TBL_CoilSchedule>();
            }
            string sqlstr = $"Select * from {nameof(TBL_CoilSchedule)} Where {nameof(TBL_CoilSchedule.Coil_ID)} = '{coilID}'";
            var coil = dbHand.QueryFirst<TBL_CoilSchedule>(sqlstr);
            if (coil != null)
            {
                //把此鋼捲之後的清除
                float seq = coil.Sequence_No;
                //var coilsforSched = dbHand.QueryList<TBL_CoilSchedule>();
                string delSqlstr = $"Delete TBL_CoilSchedule Where {nameof(TBL_CoilSchedule.Sequence_No)} >= {seq}";
                return dbHand.Execute(delSqlstr);
            }
            return true;
        }

        /// <summary>插入生產命令</summary>
        /// <param name="coilID">指定鋼捲號</param>
        /// <param name="coilArr">鋼捲列表</param>
        public bool Insert_Schedule(int seq, string[] coilArr)
        {
            List<TBL_CoilSchedule> scheds = new List<TBL_CoilSchedule>();
            for (int i = 0; i < coilArr.Length; i++)
            {
                var sched = new TBL_CoilSchedule()
                {
                    Create_DateTime = DateTime.Now,
                    Coil_ID = coilArr[i].Trim(),
                    Sequence_No = seq + i
                };
                scheds.Add(sched);

            }
            //插入資料表
            return dbHand.InsertList(scheds);
        }

        /// <summary>刪除指定鋼捲號的生產命令</summary>
        /// <param name="coilID">鋼捲號</param>
        public bool Delete_Schedule(string coilID)
        {
            string sqlstr = $"Delete {nameof(TBL_CoilSchedule)} Where {nameof(TBL_CoilSchedule.Coil_ID)} = '{coilID}'";
            return dbHand.Execute(sqlstr);
        }

        /// <summary>Log刪除生產命令</summary>
        /// <param name="msg">刪除生產命令報文</param>
        public bool Insert_ScheduleDeleteRecord(string entryCoilId, string op, string reason, string remark)
        {
            var orm = new TBL_ScheduleDelete_CoilReject_Record()
            {
                Create_DateTime = DateTime.Now,
                Coil_ID = entryCoilId,
                Create_UserID = op,
                ScheduleDelete_CoilReject_Code = reason,
                Remarks = remark
            };
            return dbHand.InsertOnly(orm);
        }

        public bool Insert_PDIDefects(List<TBL_PDI_DefectData> lsDefect)
        {
            bool isOk = false;
            try
            {
                foreach (var defect in lsDefect)
                {
                    defect.CreateDateTime = DateTime.Now;
                    dbHand.InsertOrUpdate(defect);
                }
                isOk = true;
            }
            catch { }
            return isOk;
        }
        #region 墊紙
        public int Count_Paper()
        {
            return dbHand.QueryAll<TBL_PaperData>().Count;
        }

        public TBL_PaperData Query_Paper(string code)
        {
            string sql = $"Select * from {nameof(TBL_PaperData)} Where {nameof(TBL_PaperData.CODE)} ='{code}'";
            return dbHand.QueryFirst<TBL_PaperData>(sql);
        }

        public bool InsertOrUpdatePaper(TBL_PaperData pd)
        {
            return dbHand.InsertOrUpdate(pd);
        }

        public bool Update_Paper(TBL_PaperData pd)
        {
            return dbHand.UpdateOnly(pd);
        }

        public bool Delete_Paper(string code)
        {
            string sql = $"Delete From {nameof(TBL_PaperData)} Where {nameof(TBL_PaperData.CODE)} = '{code}'";
            return dbHand.Execute(sql);
        }
        #endregion

        #region 套筒
        public int Count_Sleeve()
        {
            return dbHand.QueryAll<TBL_SleeveData>().Count;
        }

        public TBL_SleeveData Query_Sleeve(string code)
        {
            string sql = $"Select * from {nameof(TBL_SleeveData)} Where {nameof(TBL_SleeveData.CODE)} ='{code}'";
            return dbHand.QueryFirst<TBL_SleeveData>(sql);
        }
        /// <summary>
        /// 2021/09/10
        /// </summary>
        /// <param name="sd"></param>
        /// <returns></returns>
        public bool InsertOrUpdateSleeve(TBL_SleeveData sd)
        {
            return dbHand.InsertOrUpdate(sd);
        }

        public bool Update_Sleeve(TBL_SleeveData sd)
        {
            return dbHand.UpdateOnly(sd);
        }

        public bool Delete_Sleeve(string code)
        {
            string sql = $"Delete From {nameof(TBL_SleeveData)} Where {nameof(TBL_SleeveData.CODE)} = '{code}'";
            return dbHand.Execute(sql);
        }
        #endregion

        public TBL_CoilPDO Query_Pdo(string exitCoilId, int SerNo)
        {
            string sqlstr = $"select * from {nameof(TBL_CoilPDO)} where {nameof(TBL_CoilPDO.ExitCoilID)} = '{exitCoilId }' and {nameof(TBL_CoilPDO.SerNo)} = '{SerNo }' order by {nameof(TBL_CoilPDO.Create_DateTime)} desc";
            return dbHand.QueryFirst<TBL_CoilPDO>(sqlstr);
        }

        public TBL_CoilPDO Query_Pdo(string exitCoilId, string planNo)
        {
            string sqlstr = $"select * from {nameof(TBL_CoilPDO)} where {nameof(TBL_CoilPDO.ExitCoilID)} = '{exitCoilId }' order by {nameof(TBL_CoilPDO.Create_DateTime)} desc";
            return dbHand.QueryFirst<TBL_CoilPDO>(sqlstr);
        }

        public TBL_CoilPDO Query_Pdo(string exitCoilId)
        {
            string sqlstr = $"select * from {nameof(TBL_CoilPDO)} where {nameof(TBL_CoilPDO.ExitCoilID)} = '{exitCoilId }' order by {nameof(TBL_CoilPDO.Create_DateTime)} desc";
            return dbHand.QueryFirst<TBL_CoilPDO>(sqlstr);
        }

        public bool Update_PDO(TBL_CoilPDO pdo)
        {
            return dbHand.UpdateOnly(pdo);
        }

        public string Query_ProdStartTime(string exitCoilID)
        {

            string sqlStr = $"select * from {nameof(TBL_L1_Receive_302_CoilWeld)} where {nameof(TBL_L1_Receive_302_CoilWeld.CoilID)}='{exitCoilID}' Order By {nameof(TBL_L1_Receive_302_CoilWeld.Create_DateTime)} desc ";

            var coilMount = dbHand.QueryFirst<TBL_L1_Receive_302_CoilWeld>(sqlStr);
            if (coilMount == null)
            {
                return "99981231000000";
            }
            else
            {
                return coilMount.Create_DateTime.ToString("yyyyMMddHHmmss");
            }
        }

        /// <summary>更新卸載資訊</summary>
        /// <param name="pdi"></param>
        /// <param name="msg"></param>
        public bool Update_PDO_ForDismount(L1ToL2_Structure.L1L2_CoilDismount msg, out TBL_CoilPDO newPdo,out TBL_CoilPDI pdi)
        {
            //鋼捲卸載 補齊PDO資料
            newPdo = DBService.CoilAPI.Query_Pdo(new string(msg.CoilID).Trim('\0').Trim());
            if (newPdo == null) { pdi = null; return false; }
            //出口墊紙種類 01、02、03等
            newPdo.ExitPaperType = msg.PaperType.ToString("00");
            //出口墊紙方式 0:不墊紙 1:全卷墊
            string code = Convert.ToString(msg.PaperCode);
            newPdo.ExitPaperCode = code;
            //type確定後，在自動帶入
            //出口墊紙頭部長度
            //出口墊紙尾部長度
            switch (code)
            {
                case "0":
                    {
                        newPdo.ExitPaperHeadLength = 0;
                        newPdo.ExitPaperTailLength = 0;
                        break;
                    }
                case "1":
                    {
                        bool isOdd = (msg.CoilLength % 2 == 1);
                        newPdo.ExitPaperHeadLength = isOdd ? ((int)(msg.CoilLength / 2)) + 1 : (int)(msg.CoilLength / 2);
                        newPdo.ExitPaperTailLength = (int)(msg.CoilLength / 2);
                        break;
                    }
                case "2":
                    {
                        newPdo.ExitPaperHeadLength = 50;
                        newPdo.ExitPaperTailLength = 50;
                        break;
                    }
                case "3":
                    {
                        newPdo.ExitPaperHeadLength = 30;
                        newPdo.ExitPaperTailLength = 30;
                        break;
                    }
                case "4":
                    {
                        newPdo.ExitPaperHeadLength = 0;
                        newPdo.ExitPaperTailLength = 80;
                        break;
                    }
                default:
                    {
                        newPdo.ExitPaperHeadLength = 0;
                        newPdo.ExitPaperTailLength = 0;
                        break;
                    }

            }

            //出口墊紙頭部寬度
            //出口墊紙尾部寬度
            //查套筒、墊紙表帶入
            var sleeve = DBService.CoilAPI.Query_Paper(msg.PaperCode.ToString("00"));
            if (sleeve != null)
            {
                newPdo.ExitPaperHeadWidth = float.Parse(sleeve.PAPER_WIDTH);
                newPdo.PaperEntryTailWidth = float.Parse(sleeve.PAPER_WIDTH);
            }
            else
            {
                newPdo.ExitPaperHeadWidth = 0;
                newPdo.PaperEntryTailWidth = 0;
            }
            //捲曲方向(收卷方向)
            newPdo.CoilerDirection = msg.RecDir == 0 ? "U" : "L";
            //重量  以307為主(311電文也有重量) 2021/10/7加入理論重
            newPdo.ExitCoilGW = (int)msg.CoilWeight;
            newPdo.ExitCoilNW = (int)msg.CoilWeight;
            newPdo.ExitCoilTW = (int)msg.CoilWeight;
            //出口捲外徑 以307為主(311電文也有重量)
            newPdo.ExitCoilOuterDiam = (int)msg.Diameter;
            //出口捲內徑
            newPdo.ExitCoilInnerDiam = (int)msg.CoiInsideDiam;
            //出口套筒種類 307時補上
            newPdo.ExitSleeveCode = msg.SleeveCode.ToString("00");
            //出口套筒內徑 307時補上
            newPdo.ExitSleeveDiameter = (int)msg.SleeveDiameter;

            //2021/11/29  307dismount 電文新增寬度
            if (msg.CoilWidth != 0)
                newPdo.ExitCoilWidth = msg.CoilWidth;


            //pdi
            pdi = DBService.CoilAPI.Query_PDI(newPdo.EntryCoilID);

            return dbHand.UpdateOnly(newPdo);
        }

        /// <summary>分切產子捲</summary>
        /// <param name="pdi"></param>
        /// <param name="msg"></param>
        public bool InsertOrUpdate_PDO_ForDivision(TBL_CoilPDI pdi, string divisionID, L1ToL2_Structure.L1L2_ExCoilCut msg, string shift, string team, out TBL_CoilPDO newPdo)
        {
            string prodStartTime = Query_ProdStartTime(pdi.EntryCoilID);

            DateTime now = DateTime.Now;
            string exitCoilID = divisionID;
            //無PDI還是產生PDO  方便測試用
            if (pdi == null)
            {
                newPdo = new TBL_CoilPDO();
                newPdo.Create_DateTime = now;
                //出口捲號
                newPdo.ExitCoilID = exitCoilID;
                //班次
                newPdo.Shift = shift;
                //班別
                newPdo.Team = team;
                //計畫號
                newPdo.PlanNo = now.ToString("HHmmssfff");
                newPdo.ExitCoilGW = (int)msg.CalculateWeightRec;
                newPdo.ExitCoilNW = (int)msg.CalculateWeightRec;
                newPdo.ExitCoilTW = (int)msg.CalculateWeightRec;
                //生產開始時間
                newPdo.StartTime = prodStartTime;
                //生產結束時間
                newPdo.FinishTime = now.ToString("yyyyMMddHHmmss");
                //出口測量長度
                newPdo.ExitCoilLength = (int)(msg.LengthRec);
                newPdo.UploadPDO = null;
                //狀態
                newPdo.State = "O";

                return dbHand.InsertOrUpdate(newPdo);
            }


            //分捲標記
            bool divFlag = (pdi.EntryCoilID.Substring(10, 4) != exitCoilID.Substring(10, 4));

            //最終捲標記
            bool finalFlag = true;

            //orderNo
            string orderNo;
            List<TBL_CoilDivisionData> divs = Query_Division(pdi.EntryCoilID);

            if (divFlag)
            {
                orderNo = pdi.GetType().GetProperty("OrderNo" + divs.Count).GetValue(pdi)?.ToString() ?? "";
                finalFlag = !divs.Select(x => x.Out_CoilID).Contains(exitCoilID);
            }
            else
            {
                orderNo = pdi.OrderNo;
            }

            //判斷是否一顆捲 因為第一顆捲的子捲ID沒有Mount
            //bool isFirstCoil = (divs.Count == 1 && !finalFlag);
            //string tragetCoil;
            ////判斷是否第一顆捲
            //if (isFirstCoil)
            //{
            //    tragetCoil = pdi.EntryCoilID.PadRight(20);
            //}
            //else
            //{
            //    tragetCoil = exitCoilID.PadRight(20);

            //}


            //var oldPdo = Query_Pdo(pdi.EntryCoilID);//開張力會先建一個有生產開始時間的PDO

            //string prodStartTime = Query_ProdStartTime(pdi.EntryCoilID);

         

            newPdo = new TBL_CoilPDO();

            newPdo.Create_DateTime = now;
            //合同號
            newPdo.OrderNo = orderNo;
            //計畫號
            newPdo.PlanNo = pdi.PlanNo;
            //出口捲號
            newPdo.ExitCoilID = exitCoilID;
            //入口捲號
            newPdo.EntryCoilID = pdi.EntryCoilID;
            //生產開始時間
            newPdo.StartTime = prodStartTime;
            //生產結束時間
            newPdo.FinishTime = now.ToString("yyyyMMddHHmmss");
            //班次
            newPdo.Shift = shift;
            //班別
            newPdo.Team = team;
            //鋼種代碼
            newPdo.SteelNo = pdi.SteelGradeCode;


            //出口墊紙方式  307時補上
            newPdo.ExitPaperType = "";
            //出口墊紙種類  307時補上
            newPdo.ExitPaperCode = "";
            //出口墊紙頭部長度  307時補上
            newPdo.ExitPaperHeadLength = 0;
            //出口墊紙頭部寬度  307時補上
            newPdo.ExitPaperHeadWidth = 0;
            //出口墊紙尾部長度  307時補上
            newPdo.ExitPaperTailLength = 0;
            //出口墊紙尾部寬度  307時補上
            newPdo.TailWidth = 0;


            //undone PDO 延伸率給值、翻面標記給值
            //newPdo.Elongation = 
            //newPdo.FlipTag =

            //出口捲外徑
            newPdo.ExitCoilOuterDiam = (int)msg.DiamRec;
            //出口捲內徑
            newPdo.ExitCoilInnerDiam = pdi.EntryCoilInnerDiam;

            //出口套筒種類 307時補上
            newPdo.ExitSleeveCode = "";
            //出口套筒內徑 307時補上
            newPdo.ExitSleeveDiameter = 0;

            //出口測量厚度
            newPdo.ExitCoilThick = pdi.OutCoilThick;
            //出口測量寬度
            newPdo.ExitCoilWidth = pdi.OutCoilWidth;

            //出口測量長度
            newPdo.ExitCoilLength = (int)msg.LengthRec;

            //出口測量寬度最小值(人工輸入)
            //出口寬度最大值(人工輸入)
            //頭部驅動側厚度(人工輸入)
            //頭部中間側厚度(人工輸入)
            //頭部操作側厚度(人工輸入)
            //頭部寬度(人工輸入)
            //中部驅動側厚度(人工輸入)
            //中部中間側厚度(人工輸入)
            //中部操作側厚度(人工輸入)
            //中部寬度(人工輸入)
            //尾部驅動側厚度(人工輸入)
            //尾部中間側厚度(人工輸入)
            //尾部操作側厚度(人工輸入)
            //尾部寬度(人工輸入)


            newPdo.ExitCoilGW = (int)msg.CalculateWeightRec;
            newPdo.ExitCoilNW = (int)msg.CalculateWeightRec;
            newPdo.ExitCoilTW = (int)msg.CalculateWeightRec;
            //切邊
            newPdo.TrimFlag = pdi.TrimFlag ?? "0";
            //捲曲方向(收卷方向) 307才有
            newPdo.CoilerDirection = "";
            //開捲方向
            newPdo.UnCoilDirection = pdi.DecoilerDirection == "0" ? "U" : "L";
            //好面朝向
            newPdo.BaseSurface = pdi.BaseSurface;

            //質檢員(已移到L3)
            //封鎖標記(已移到L3)
            //封鎖原因代碼(已移到L3)
            //取樣標記
            //SampleFlag = Query_SampleCut_Record(exitCoilID) ? "1" ; "0";
            //分捲標記
            newPdo.DividFlag = divFlag ? "1" : "0";
            //最終捲標記
            newPdo.EndFlag = finalFlag ? "1" : "0";
            //過度捲標記
            newPdo.DummyFlag = pdi.DummyFlag;
            //廢品標記(人工輸入)
            newPdo.ScrapFlag = "0";
            //取樣位置
            newPdo.SampleFrqnCode = pdi.SampleFrqnCode;
            //表面精度代碼
            newPdo.SurfaceCode = pdi.OrderSurfaceCode;
            //頭部未軋制區
            newPdo.HeadOffGauge = pdi.HeadOffGauge;
            //尾部未軋制區
            newPdo.TailOffGauge = pdi.TailOffGauge;
            //平坦度波高
            newPdo.Flatness = pdi.OrderFlatness;

            newPdo.ProcessCode = pdi.ProcessCode;

            newPdo.UploadPDO = null;
            //狀態
            newPdo.State = "O";

            return dbHand.InsertOnly(newPdo);
        }

        /// <summary>更新PDO的秤重值</summary>
        /// <param name="exitCoilId"></param>
        /// <param name="GW"></param>
        /// <param name="NW"></param>
        public bool Update_PDOWeight(string exitCoilId, float GW, float NW)
        {
            var pdo = Query_Pdo(exitCoilId);
            if (pdo != null)
            {
                pdo.ExitCoilNW = (int)NW;
                pdo.ExitCoilGW = (int)GW;
            }
            else
            {
                throw new Exception("無鋼捲PDO，exitCoilID: " + exitCoilId + " ，作業流程錯誤");
            }

            bool isOk = dbHand.UpdateOnly(pdo);
            return isOk;
        }

        /// <summary>記錄PDO的生產時間</summary>
        /// <param name="coilID"></param>
        public bool Insert_PDOStartTime(string planNo, string coilID)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");

            TBL_CoilPDO pdo = dbHand.QueryFirst<TBL_CoilPDO>($"Select * From {nameof(TBL_CoilPDO)} Where {nameof(TBL_CoilPDO.ExitCoilID)} = '{coilID}'");
            if (pdo == null)
            {
                pdo = new TBL_CoilPDO()
                {
                    Create_DateTime = DateTime.Now,
                    PlanNo = planNo,
                    ExitCoilID = coilID,
                };
            }
            pdo.StartTime = time;
            return dbHand.InsertOrUpdate(pdo);
        }

        public TBL_CoilSchedule Query_Schedule_First()
        {
            string sql = $"Select * From {nameof(TBL_CoilSchedule)} Order by ";
            return dbHand.QueryFirst<TBL_CoilSchedule>(sql);
        }

        /// <summary>查詢生產命令最後的序號</summary>
        /// <returns>序號</returns>
        public int Query_Schedule_LastSeq()
        {
            string sqlStr = $"SELECT {nameof(TBL_CoilSchedule.Sequence_No)} = MAX ({nameof(TBL_CoilSchedule.Sequence_No)}) FROM {nameof(TBL_CoilSchedule)};";
            var sched = dbHand.QueryFirst<TBL_CoilSchedule>(sqlStr);
            if (sched != null) return (int)sched.Sequence_No;
            else return 0;
        }

        /// <summary>查詢未上線的生產命令</summary>
        /// <param name="count">最大筆數</param>
        public List<TBL_CoilPDI> Query_Schedule_OfflinePDI(int count)
        {
            List<TBL_CoilPDI> pdi = new List<TBL_CoilPDI>();

            //string sqlStr = $"SELECT Top {count} b.* FROM {nameof(TBL_CoilSchedule)} as a, {nameof(TBL_CoilPDI)} as b where a.{nameof(TBL_CoilSchedule.Coil_ID)} = b.{nameof(TBL_CoilPDI.EntryCoilID)} and (b.{nameof(TBL_CoilPDI.State)}='N' or b.{nameof(TBL_CoilPDI.State)}='R') Order By {nameof(TBL_CoilSchedule.Sequence_No)}";
            //var ans = dbHand.QueryList<TBL_CoilPDI>(sqlStr);
            //return ans;

            string sqlStr1 = $"SELECT * FROM {nameof(TBL_CoilSchedule)} Order By {nameof(TBL_CoilSchedule.Sequence_No)}";
            var sch = dbHand.QueryList<TBL_CoilSchedule>(sqlStr1);

            foreach (TBL_CoilSchedule item in sch)
            {
                string sqlStr2 = $"SELECT * FROM {nameof(TBL_CoilPDI)} where {nameof(TBL_CoilPDI.EntryCoilID)} = '{item.Coil_ID}' and ( {nameof(TBL_CoilPDI.State)} = 'N' or {nameof(TBL_CoilPDI.State)} = 'R' ) ";
                var ans = dbHand.QueryFirst<TBL_CoilPDI>(sqlStr2);
                if (ans != null)
                {
                    pdi.Add(ans);
                }
                if (pdi.Count >= count) return pdi;
            }
            return pdi;
        }

        public List<string> Query_Schedule_OfflineCoilIDs(int count)
        {
            return Query_Schedule_OfflinePDI(count).Select(x => x.EntryCoilID).ToList();
        }

        /// <summary>取得CoilID從Schedule資料表</summary>
        /// <returns>CoilID List</returns>
        public List<string> GetCoilIDFromSchedule(int count)
        {
            List<string> coilIDs = new List<string>();

            string sqlStr = $"SELECT Top {count} a.* FROM {nameof(TBL_CoilSchedule)} as a, {nameof(TBL_CoilPDI)} as b where a.{nameof(TBL_CoilSchedule.Coil_ID)} = b.{nameof(TBL_CoilPDI.EntryCoilID)} and b.{nameof(TBL_CoilPDI.State)}='N' Order By {nameof(TBL_CoilSchedule.Sequence_No)}";

            var orm = dbHand.QueryList<TBL_CoilSchedule>(sqlStr);
            foreach (var item in orm)
            {
                coilIDs.Add(item.Coil_ID);
            }
            return coilIDs;
        }

        public List<string> GetCoilSchedule(int count)
        {
            List<string> coilIDs = new List<string>();
            string sqlStr = $"SELECT Top {count} * FROM {nameof(TBL_CoilSchedule)} Order By {nameof(TBL_CoilSchedule.Sequence_No)}";

            var orm = dbHand.QueryList<TBL_CoilSchedule>(sqlStr);

            foreach (var item in orm)
            {
                coilIDs.Add(item.Coil_ID);
            }
            return coilIDs;
        }

        public List<string> GetCoilScheduleWithNoDummy()
        {
            List<string> coilIDs = new List<string>();
            string sqlStr = $"SELECT * FROM {nameof(TBL_CoilSchedule)} Order By {nameof(TBL_CoilSchedule.Sequence_No)}";
            string sqlStr1 = $"SELECT Top 500 * FROM {nameof(TBL_CoilPDI)} Order By {nameof(TBL_CoilPDI.CreateDateTime)} desc";

            var ormSchedule = dbHand.QueryList<TBL_CoilSchedule>(sqlStr);
            var ormCoilPDI = dbHand.QueryList<TBL_CoilPDI>(sqlStr1);

            foreach (var item in ormSchedule)
            {
                var coilID = ormCoilPDI.Where(x => x.EntryCoilID == item.Coil_ID && x.DummyFlag != "1").FirstOrDefault();
                if (coilID != null) coilIDs.Add(coilID.EntryCoilID);
                if (coilIDs.Count >= 300) break;
            }
            return coilIDs;
        }

        #region 分切表相關
        //public string Query_MatCoil(string childCoilID)
        //{
        //    string sql = $"Select Top 1 * From {nameof(TBL_CoilDivisionData)} where {nameof(TBL_CoilDivisionData.Out_CoilID)} = '{childCoilID}' order by {nameof(TBL_CoilDivisionData.Create_DateTime)} desc";

        //    var tbl = dbHand.QueryFirst<TBL_CoilDivisionData>(sql);
        //    string matCoil = null;
        //    if (tbl != null)
        //    {
        //        matCoil = tbl.In_CoilID.Trim();
        //    }

        //    return matCoil;
        //}

        public List<TBL_CoilDivisionData> Query_Division(string matCoilID)
        {
            string sqlstr = $"Select * from {nameof(TBL_CoilDivisionData)} where {nameof(TBL_CoilDivisionData.In_CoilID)} = '{matCoilID}'";
            return dbHand.QueryList<TBL_CoilDivisionData>(sqlstr);
        }

        /// <summary>紀錄分切表</summary>
        /// <param name="inCoil"></param>
        /// <param name="outCoil"></param>
        /// <returns></returns>

        public bool InsertOrUpdate_Division(string inCoil, string outCoil)
        {
            //紀錄分切
            return dbHand.InsertOrUpdate(new TBL_CoilDivisionData()
            {
                Create_DateTime = DateTime.Now,
                In_CoilID = inCoil,
                Out_CoilID = outCoil
            });
        }

        /// <summary>刪除分切表</summary>
        /// <param name="coilID"></param>
        /// <returns></returns>
        public bool Delete_Division()
        {
            string sql = $"Delete From {nameof(TBL_CoilDivisionData)}";
            return dbHand.Execute(sql);
        }

        /// <summary>計算分捲數</summary>
        /// <param name="coilID"></param>
        /// <returns></returns>
        //public int Count_Division(string coilID)
        //{
        //    string sqlstr = $"Select * From {nameof(TBL_CoilDivisionData)} Where {nameof(TBL_CoilDivisionData.In_CoilID)} = '{coilID}'";
        //    var divs = dbHand.QueryList<TBL_CoilDivisionData>(sqlstr);
        //    int count = (divs == null ? 0 : divs.Count);
        //    return count;
        //}
        #endregion

    }
}
