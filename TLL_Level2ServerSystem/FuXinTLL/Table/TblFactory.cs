using FuXinTLL.Table;
using FuXinTLL.Telegram.L1;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuXinTLL
{
    /// <summary>
    /// Tbl產生器L25 用
    /// </summary>
    public static class TblL25Factory
    {
        /// <summary>
        /// 報文格式轉換成Tbl
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msgStruct"></param>
        /// <returns></returns>
        public static T FromL25Message<T>(object msgStruct)
        {
            //產生實例:
            T orm = Activator.CreateInstance<T>();
            var msgFields = msgStruct.GetType().GetFields();
            var ormProps = orm.GetType().GetProperties();

            foreach (var property in ormProps)
            {
                //if (filed.GetValue(message) == null)
                //{
                //    filed.SetValue(message, 0);
                //}
                foreach (var filed in msgFields)
                {
                    //把相同欄位名稱的值指派給orm:
                    if (property.Name == filed.Name)
                    {
                        var value = filed.GetValue(msgStruct);
                        try
                        {
                            if (property.PropertyType == typeof(string) && value.GetType() == typeof(char[]))
                            {
                                property.SetValue(orm, new string(value as char[]));
                            }
                            else
                            {
                                //不可能到這裡喔!
                                property.SetValue(orm, value);
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            //處理特有欄位
            //orm.GetType().GetProperties().Where(x => x.Name == "Message_Length").FirstOrDefault().SetValue(orm,"");
            //orm.GetType().GetProperties().Where(x => x.Name == "Message_Id").FirstOrDefault().SetValue(orm, l25MessageID);

            //var createTime = orm.GetType().GetProperty("Create_DateTime");
            //    if (null != createTime)
            //    {
            //        createTime.SetValue(orm, DateTime.Now);
            //    }

            return (T)orm;
        }
        //public static L2L25_CoilMap GetL25CoilMap(L1ToL2_Structure.L1L2_TrackMap_206 l1L2_TrackMap_206)
        //{
        //    L2L25_CoilMap l2L25_CoilMap = new L2L25_CoilMap();
        //    l2L25_CoilMap.Message_Length = "108";
        //    l2L25_CoilMap.Message_Id = TblConst.L25MessageID.CoilMap;
        //    l2L25_CoilMap.Date = DateTime.Now.ToString("yyyyMMdd");
        //    l2L25_CoilMap.Time = DateTime.Now.ToString("HHmmssfff");
        //    l2L25_CoilMap.CoilIDPos1 = new string(l1L2_TrackMap_206.CoilIDUnCoiler).Trim('\0').Trim();
        //    l2L25_CoilMap.CoilIDPos2 = new string(l1L2_TrackMap_206.CoilIDSkid2).Trim('\0').Trim();
        //    l2L25_CoilMap.CoilIDPos3 = new string(l1L2_TrackMap_206.CoilIDSkid1).Trim('\0').Trim();
        //    l2L25_CoilMap.CoilIDPos4 = new string(l1L2_TrackMap_206.CoilIDReCoiler).Trim('\0').Trim();
        //    l2L25_CoilMap.CoilIDPos5 = new string(l1L2_TrackMap_206.CoilIDRecSkid1).Trim('\0').Trim();
        //    l2L25_CoilMap.CoilIDPos6 = new string(l1L2_TrackMap_206.CoilIDRecSkid2).Trim('\0').Trim();

        //    return l2L25_CoilMap;
        //}

        //public static L2L25_Utility GetL25Utility(L1ToL2_Structure.L1L2_Consumables_215 l1L2_Consumables_215)
        //{
        //    L2L25_Utility l2L25_Utility = new L2L25_Utility();
        //    l2L25_Utility.Message_Length = "54";
        //    l2L25_Utility.Message_Id = TblConst.L25MessageID.Utility;
        //    l2L25_Utility.Date = DateTime.Now.ToString("yyyyMMdd");
        //    l2L25_Utility.Time = DateTime.Now.ToString("HHmmssfff");
        //    l2L25_Utility.CompressedAir = IntToStringLimiltLength(l1L2_Consumables_215.CA, 12);
        //    //l2L25_Utility.CoolingWater = IntToStringLimiltLength(l1L2_Consumables_215.IDCW, 12);

        //    return l2L25_Utility;
        //}
        public static L2L25_DownTime GetL25DownTime(TBL_DownTime downTime)
        {
            L2L25_DownTime l2L25_DownTime = new L2L25_DownTime();
            l2L25_DownTime.Message_Length = "165";
            l2L25_DownTime.Message_Id = TblConst.L25MessageID.DownTime;
            l2L25_DownTime.Date = DateTime.Now.ToString("yyyyMMdd");
            l2L25_DownTime.Time = DateTime.Now.ToString("HHmmssfff");
            l2L25_DownTime.OP_FLAG = "1";
            l2L25_DownTime.UNIT_CODE = downTime.UnitCode;
            l2L25_DownTime.PROD_DATE = downTime.ProdTime;
            l2L25_DownTime.PROD_SHIFT_NO = downTime.ProdShiftNo;
            l2L25_DownTime.PROD_SHIFT_GROUP = downTime.ProdShiftGroup;
            l2L25_DownTime.STOP_START_TIME = downTime.StopStartTime;
            l2L25_DownTime.STOP_END_TIME = downTime.StopEndTime;
            l2L25_DownTime.DELAY_LOCATION = downTime.DelayLocation;
            l2L25_DownTime.DELAY_LOCATION_DESC = downTime.DelayLocationDesc;
            l2L25_DownTime.STOP_ELASED_TIME = Convert.ToString(downTime.StopElasedTime);
            l2L25_DownTime.STOP_REASON = downTime.DelayReasonCode;
            l2L25_DownTime.DELAY_REASON_DESC = downTime.DelayReasonDesc;
            l2L25_DownTime.DELAY_REMARK = downTime.DelayRemark;
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_M = Convert.ToString(downTime.RespDepartDelayTimeM);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_E = Convert.ToString(downTime.RespDepartDelayTimeE);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_C = Convert.ToString(downTime.RespDepartDelayTimeC);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_P = Convert.ToString(downTime.RespDepartDelayTimeP);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_U = Convert.ToString(downTime.RespDepartDelayTimeU);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_O = Convert.ToString(downTime.RespDepartDelayTimeO);
            l2L25_DownTime.RESP_DEPART_DELAY_TIME_RS = Convert.ToString(downTime.RespDepartDelayTimeRS);
            l2L25_DownTime.DECELERATION_CODE = downTime.DecelerationCode;
            l2L25_DownTime.DECELERATION_CAUSE = downTime.DecelerationCause;

            return l2L25_DownTime;
        }

        public static L2L25_CoilPDI GetL25PDI(TBL_CoilPDI pdi, List<TBL_PDI_DefectData> defect)
        {
            L2L25_CoilPDI l2L25_CoilPDI = new L2L25_CoilPDI();
            l2L25_CoilPDI.Message_Length = "1867";
            l2L25_CoilPDI.Message_Id = TblConst.L25MessageID.CoilPDI;
            l2L25_CoilPDI.Date = DateTime.Now.ToString("yyyyMMdd");
            l2L25_CoilPDI.Time = DateTime.Now.ToString("HHmmssfff");
            l2L25_CoilPDI.PLAN_NO = pdi.PlanNo;
            l2L25_CoilPDI.MAT_PLAN_SEQ_NO = IntToStringLimiltLength(pdi.MatSeqNo, 8);
            l2L25_CoilPDI.PLAN_TYPE = pdi.PlanSort;
            l2L25_CoilPDI.IN_MAT_NO = pdi.EntryCoilID;
            l2L25_CoilPDI.IN_MAT_THICK = IntToStringLimiltLength(pdi.EntryCoilThick, 8, 1000);
            l2L25_CoilPDI.IN_MAT_WIDTH = IntToStringLimiltLength(pdi.EntryCoilWidth, 8, 10);
            l2L25_CoilPDI.IN_MAT_WT = IntToStringLimiltLength(pdi.EntryCoilWidth, 8);
            l2L25_CoilPDI.IN_MAT_LEN = IntToStringLimiltLength(pdi.EntryCoilLength, 8);
            l2L25_CoilPDI.IN_MAT_INNER_DIA = IntToStringLimiltLength(pdi.EntryCoilInnerDiam, 8);
            l2L25_CoilPDI.IN_MAT_OUTER_DIA = IntToStringLimiltLength(pdi.EntryCoilOuterDiam, 8);
            l2L25_CoilPDI.PAPER_REQ_CODE = pdi.PaperEntryFlag;
            l2L25_CoilPDI.PAPER_CODE = pdi.PaperEntryType;
            l2L25_CoilPDI.HEAD_PAPER_LENGTH = IntToStringLimiltLength(pdi.PaperEntryHeadLength, 8);
            l2L25_CoilPDI.HEAD_PAPER_WIDTH = IntToStringLimiltLength(pdi.PaperEntryHeadWidth, 8, 10);
            l2L25_CoilPDI.TAIL_PAPER_LENGTH = IntToStringLimiltLength(pdi.PaperEntryTailLength, 8);
            l2L25_CoilPDI.TAIL_PAPER_WIDTH = IntToStringLimiltLength(pdi.PaperEntryTailWidth, 8, 10);
            l2L25_CoilPDI.SLEEVE_TYPE_CODE = pdi.EntrySleeveType;
            l2L25_CoilPDI.SLEEVE_DIAMTER = IntToStringLimiltLength(pdi.EntrySleeveInnerDiam, 8);
            l2L25_CoilPDI.OUT_SLEEVE_DIAMTER = IntToStringLimiltLength(pdi.OutCoilInnerDiam, 8);
            l2L25_CoilPDI.OUT_SLEEVE_TYPE_CODE = pdi.ExitSleeveFlag;
            l2L25_CoilPDI.OUT_PAPER_CODE = pdi.PaperUnwinderType;
            l2L25_CoilPDI.OUT_PAPER_REQ_CODE = pdi.PaperUnwinderFlag;
            l2L25_CoilPDI.PACK_MODE = pdi.StrapNum;
            l2L25_CoilPDI.FIXED_WT_FLAG = pdi.DividingFlag;
            l2L25_CoilPDI.DIVIDE_NUM = IntToStringLimiltLength(pdi.DividingNum, 2);
            l2L25_CoilPDI.ORDER_UNIT_MAX_WT = IntToStringLimiltLength(pdi.OrderWeightMax, 5);
            l2L25_CoilPDI.ORDER_UNIT_MIN_WT = IntToStringLimiltLength(pdi.OrderWeightMin, 5);
            l2L25_CoilPDI.ORDER_WT1 = IntToStringLimiltLength(pdi.SplitWt1, 8);
            l2L25_CoilPDI.ORDER_WT2 = IntToStringLimiltLength(pdi.SplitWt2, 8);
            l2L25_CoilPDI.ORDER_WT3 = IntToStringLimiltLength(pdi.SplitWt3, 8);
            l2L25_CoilPDI.ORDER_WT4 = IntToStringLimiltLength(pdi.SplitWt4, 8);
            l2L25_CoilPDI.ORDER_WT5 = IntToStringLimiltLength(pdi.SplitWt5, 5);
            l2L25_CoilPDI.ORDER_NO1 = pdi.OrderNo1;
            l2L25_CoilPDI.ORDER_NO2 = pdi.OrderNo2;
            l2L25_CoilPDI.ORDER_NO3 = pdi.OrderNo3;
            l2L25_CoilPDI.ORDER_NO4 = pdi.OrderNo4;
            l2L25_CoilPDI.ORDER_NO5 = pdi.OrderNo5;
            l2L25_CoilPDI.ORDER_THICK = IntToStringLimiltLength(pdi.OrderThick, 8, 1000);
            l2L25_CoilPDI.ORDER_MIN_THICK = IntToStringLimiltLength(pdi.OrderThickMin, 8, 1000);
            l2L25_CoilPDI.ORDER_MAX_THICK = IntToStringLimiltLength(pdi.OrderThickMax, 8, 1000);
            l2L25_CoilPDI.ORDER_INNER_DIA = IntToStringLimiltLength(pdi.OrderInner, 8);
            l2L25_CoilPDI.EL_MAX = IntToStringLimiltLength(pdi.OrderElongationMax, 8);
            l2L25_CoilPDI.EL_MIN = IntToStringLimiltLength(pdi.OrderElongationMin, 8);
            l2L25_CoilPDI.YS_MAX = IntToStringLimiltLength(pdi.YdStandMax, 8);
            l2L25_CoilPDI.YS_MIN = IntToStringLimiltLength(pdi.YdStandMin, 8);
            l2L25_CoilPDI.HARDNESS_MAX = IntToStringLimiltLength(pdi.HardnessMax, 8);
            l2L25_CoilPDI.HARDNESS_MIN = IntToStringLimiltLength(pdi.HardnessMin, 8);
            l2L25_CoilPDI.TS_MAX = IntToStringLimiltLength(pdi.TsStandMax, 8);
            l2L25_CoilPDI.TS_MIN = IntToStringLimiltLength(pdi.TsStandMin, 8);
            l2L25_CoilPDI.FLAT_AIM = IntToStringLimiltLength(pdi.OrderFlatness, 8);
            l2L25_CoilPDI.ORIGIN_CODE = pdi.CoilOrigin;
            l2L25_CoilPDI.PREV_WHOLE_BACKLOG_CODE = pdi.WholebacklogCode;
            l2L25_CoilPDI.NEXT_WHOLE_BACKLOG_CODE = pdi.NextWholebacklogCode;
            l2L25_CoilPDI.ORDER_NO = pdi.OrderNo;
            l2L25_CoilPDI.SG_SIGN = pdi.SteelGradeSign;
            l2L25_CoilPDI.ST_NO = pdi.SteelGradeCode;
            l2L25_CoilPDI.DENSITY = IntToStringLimiltLength(pdi.Density, 8);
            l2L25_CoilPDI.SURFACE_ACCU_CODE = pdi.OrderSurfaceCode;
            l2L25_CoilPDI.SURFACE_ACCURACY = pdi.SourceSurfaceCode;
            l2L25_CoilPDI.PACK_TYPE_CODE = pdi.PackType;
            l2L25_CoilPDI.TRIM_FLAG = pdi.TrimFlag;
            l2L25_CoilPDI.BETTER_SURF_WARD_CODE = pdi.BaseSurface;
            l2L25_CoilPDI.ORDER_BETTER_SURF_WARD_CODE = pdi.OrderBetterSurfWardCode;
            l2L25_CoilPDI.UNCOIL_DIRECTION = pdi.DecoilerDirection;
            l2L25_CoilPDI.REPAIR_TYPE = pdi.ReworkType;
            l2L25_CoilPDI.SAMPLE_FLAG = pdi.SampleFlag;
            l2L25_CoilPDI.SAMPLE_FRQN_CODE = pdi.SampleFrqnCode;
            l2L25_CoilPDI.SAMPLE_LOT_NO = pdi.SampleLotNo;
            l2L25_CoilPDI.TEST_PLAN_NO = pdi.TestPlanNo;
            l2L25_CoilPDI.QC_REMARK = pdi.QCState;
            l2L25_CoilPDI.HEAD_OFF_GAUGE = IntToStringLimiltLength(pdi.HeadOffGauge, 8);
            l2L25_CoilPDI.TAIL_OFF_GAUGE = IntToStringLimiltLength(pdi.TailOffGauge, 8);
            l2L25_CoilPDI.SURFACE_ACCU_CODE_IN = pdi.SurfaceAccuCodeIn;
            l2L25_CoilPDI.SURFACE_ACCU_CODE_OUT = pdi.SurfaceAccuCodeOut;
            l2L25_CoilPDI.COIL_DIRECTION = pdi.WindingDire;
            l2L25_CoilPDI.PROCESS_CODE = pdi.ProcessCode;
            l2L25_CoilPDI.ORDER_CUST_ENAME = pdi.CustomerNameEng;
            l2L25_CoilPDI.ORDER_CUST_CNAME = pdi.CustomerNameChn;
            l2L25_CoilPDI.ORDER_CUST_CODE = pdi.CustomerNo;
            l2L25_CoilPDI.SURFACE_ACCU_DESC = pdi.OrderSurfaceDesc;
            l2L25_CoilPDI.SURFACE_ACCURACY_DESC = pdi.SourceSurfaceDesc;
            l2L25_CoilPDI.SURFACE_ACCU_DESC_IN = pdi.OrderSurfaceDescIn;
            l2L25_CoilPDI.SURFACE_ACCU_DESC_OUT = pdi.OrderSurfaceDescOut;

            //l2L25_CoilPDI.OUT_SLEEVE_DIAMTER = IntToStringLimiltLength(pdi.ExitSleeveInnerDiam, 8);
            //l2L25_CoilPDI.PACK_MODE = pdi.PackCode;
            //l2L25_CoilPDI.OUT_MAT_NO = pdi.ExitCoilID;
            //l2L25_CoilPDI.OUT_MAT_THICK = IntToStringLimiltLength(pdi.ExitCoilThick, 8, 1000);
            //l2L25_CoilPDI.OUT_MAT_WIDTH = IntToStringLimiltLength(pdi.ExitCoilWidth, 8, 10);
            //l2L25_CoilPDI.OUT_MAT_INNER_DIA = IntToStringLimiltLength(pdi.ExitCoilInnerDiam, 8);
            //l2L25_CoilPDI.ORDER_UNIT_MIN_WT = IntToStringLimiltLength(pdi.OrderWeightMin, 8);
            //l2L25_CoilPDI.ORDER_UNIT_MAX_WT = IntToStringLimiltLength(pdi.OrderWeightMax, 8);

            //l2L25_CoilPDI.ORDER_UNIT_MIN_WT = IntToStringLimiltLength(pdi.OrderThickMin, 8, 1000);
            //l2L25_CoilPDI.ORDER_UNIT_MAX_WT = IntToStringLimiltLength(pdi.OrderThickMax, 8, 1000);
            //l2L25_CoilPDI.ORDER_WIDTH = IntToStringLimiltLength(pdi.OrderWidth, 8, 10);
            //l2L25_CoilPDI.ORDER_MIN_WIDTH = IntToStringLimiltLength(pdi.OrderWidthMin, 8, 10);
            //l2L25_CoilPDI.ORDER_MAX_WIDTH = IntToStringLimiltLength(pdi.OrderWidthMax, 8, 10);

            #region 缺陷資料 物件反射取值
            for (int i = 0; i < defect.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(defect.ElementAt(i).DefectCode))
                {
                    FromPDIDefect(i + 1, defect.ElementAt(i), l2L25_CoilPDI);
                }
            }
            #endregion
            return l2L25_CoilPDI;
        }

        public static L2L25_CoilPDO GetL25PDO(TBL_CoilPDO pdo, List<TBL_PDO_DefectData> defect)
        {
            L2L25_CoilPDO l2L25_CoilPDO = new L2L25_CoilPDO();
            l2L25_CoilPDO.Message_Length = "639";
            l2L25_CoilPDO.Message_Id = TblConst.L25MessageID.CoilPDO;
            l2L25_CoilPDO.Date = DateTime.Now.ToString("yyyyMMdd");
            l2L25_CoilPDO.Time = DateTime.Now.ToString("HHmmssfff");
            l2L25_CoilPDO.ORDER_NO = pdo.OrderNo;
            l2L25_CoilPDO.PLAN_NO = pdo.PlanNo;
            l2L25_CoilPDO.OUT_MAT_NO = pdo.ExitCoilID;
            l2L25_CoilPDO.IN_MAT_NO = pdo.EntryCoilID;
            l2L25_CoilPDO.START_PROD_TIME = pdo.StartTime;
            l2L25_CoilPDO.END_PROD_TIME = pdo.FinishTime;
            l2L25_CoilPDO.PROD_SHIFT_NO = pdo.Shift;
            l2L25_CoilPDO.PROD_SHIFT_GROUP = pdo.Team;
            l2L25_CoilPDO.ST_NO = pdo.SteelNo;
            l2L25_CoilPDO.PAPER_REQ_CODE = pdo.ExitPaperCode;
            l2L25_CoilPDO.PAPER_CODE = pdo.ExitPaperType;
            l2L25_CoilPDO.HEAD_PAPER_LENGTH = IntToStringLimiltLength(pdo.ExitPaperHeadLength, 8);
            l2L25_CoilPDO.HEAD_PAPER_WIDTH = IntToStringLimiltLength(pdo.ExitPaperHeadWidth, 8, 10);
            l2L25_CoilPDO.TAIL_PAPER_LENGTH = IntToStringLimiltLength(pdo.ExitPaperTailLength, 8);
            l2L25_CoilPDO.TAIL_PAPER_WIDTH = IntToStringLimiltLength(pdo.PaperEntryTailWidth, 8, 10);
            l2L25_CoilPDO.OUT_MAT_USE_SLEEVE_FLAG = pdo.ExitSleeveFlag;
            l2L25_CoilPDO.SLEEVE_TYPE_CODE = pdo.ExitSleeveCode;
            l2L25_CoilPDO.SLEEVE_DIAMTER = IntToStringLimiltLength(pdo.ExitSleeveDiameter, 8);
            l2L25_CoilPDO.OUT_MAT_ACT_OUTER_DIA = IntToStringLimiltLength(pdo.ExitCoilOuterDiam, 8);
            l2L25_CoilPDO.OUT_MAT_ACT_INNER_DIA = IntToStringLimiltLength(pdo.ExitCoilInnerDiam, 8);
            l2L25_CoilPDO.OUT_MAT_ACT_THICK = IntToStringLimiltLength(pdo.ExitCoilThick, 8, 1000);
            l2L25_CoilPDO.OUT_MAT_MIN_THICK = IntToStringLimiltLength(pdo.ExitCoilThickMin, 8, 1000);
            l2L25_CoilPDO.OUT_MAT_MAX_THICK = IntToStringLimiltLength(pdo.ExitCoilThickMax, 8, 1000);
            l2L25_CoilPDO.OUT_MAT_ACT_WIDTH = IntToStringLimiltLength(pdo.ExitCoilWidth, 8, 10);
            l2L25_CoilPDO.OUT_MAT_MIN_WIDTH = IntToStringLimiltLength(pdo.ExitCoilWidthMin, 8, 10);
            l2L25_CoilPDO.OUT_MAT_MAX_WIDTH = IntToStringLimiltLength(pdo.ExitCoilWidthMax, 8, 10);
            l2L25_CoilPDO.HEAD_DS_THICK = IntToStringLimiltLength(pdo.HeadDriveSideThick, 8, 1000);
            l2L25_CoilPDO.HEAD_CT_THICK = IntToStringLimiltLength(pdo.HeadMiddleSideThick, 8, 1000);
            l2L25_CoilPDO.HEAD_OS_THICK = IntToStringLimiltLength(pdo.HeadOperSideThick, 8, 1000);
            l2L25_CoilPDO.HEAD_WIDTH = IntToStringLimiltLength(pdo.HeadWidth, 8, 10);
            l2L25_CoilPDO.MID_DS_THICK = IntToStringLimiltLength(pdo.HalfDriveSideThick, 8, 1000);
            l2L25_CoilPDO.MID_CT_THICK = IntToStringLimiltLength(pdo.HalfMiddleSideThick, 8, 1000);
            l2L25_CoilPDO.MID_OS_THICK = IntToStringLimiltLength(pdo.HalfOperSideThick, 8, 1000);
            l2L25_CoilPDO.MID_WIDTH = IntToStringLimiltLength(pdo.HalfWidth, 8, 10);
            l2L25_CoilPDO.TAIL_DS_THICK = IntToStringLimiltLength(pdo.TailDriveSideThick, 8, 1000);
            l2L25_CoilPDO.TAIL_CT_THICK = IntToStringLimiltLength(pdo.TailMiddleSideThick, 8, 1000);
            l2L25_CoilPDO.TAIL_OS_THICK = IntToStringLimiltLength(pdo.TailOperSideThick, 8, 1000);
            l2L25_CoilPDO.TAIL_WIDTH = IntToStringLimiltLength(pdo.TailWidth, 8, 10);
            l2L25_CoilPDO.OUT_MAT_ACT_LEN = IntToStringLimiltLength(pdo.ExitCoilLength, 8);
            l2L25_CoilPDO.OUT_MAT_ACT_WT = IntToStringLimiltLength(pdo.ExitCoilNW, 8);
            l2L25_CoilPDO.OUT_MAT_GROSS_WT = IntToStringLimiltLength(pdo.ExitCoilGW, 8);
            l2L25_CoilPDO.TRIM_FLAG = pdo.TrimFlag;
            l2L25_CoilPDO.SPM_ELONG = IntToStringLimiltLength(pdo.Elongation, 8);

            #region 缺陷資料 物件反射取值
            for (int i = 0; i < defect.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(defect.ElementAt(i).DefectCode))
                {
                    FromPDODefect(i + 1, defect.ElementAt(i), l2L25_CoilPDO);
                }
            }
            #endregion

            l2L25_CoilPDO.WINDING_DIRE = pdo.CoilerDirection;
            l2L25_CoilPDO.BETTER_SURF_WARD_CODE = pdo.BaseSurface;
            l2L25_CoilPDO.HOLD_MAKER = pdo.BaseSurface;
            l2L25_CoilPDO.HOLD_FLAG = pdo.HoldFlag;
            l2L25_CoilPDO.HOLD_CAUSE_CODE = pdo.HoldCauseCode;
            l2L25_CoilPDO.SAMPLE_FLAG = pdo.SampleFlag;
            l2L25_CoilPDO.DUMMY_COIL_FLAG = pdo.DummyFlag;
            l2L25_CoilPDO.FIXED_WT_FLAG = pdo.DividFlag;
            l2L25_CoilPDO.FINAL_COIL_FLAG = pdo.EndFlag;
            l2L25_CoilPDO.SCRAP_FLAG = pdo.ScrapFlag;
            l2L25_CoilPDO.SAMPLE_POS_CODE = pdo.SampleFrqnCode;
            l2L25_CoilPDO.FLATNESS_WAVE_HIGHT = IntToStringLimiltLength(pdo.Flatness, 8);
            l2L25_CoilPDO.SURFACE_ACCU_CODE = pdo.SurfaceCode;
            l2L25_CoilPDO.OFF_ROLL_LEN_HEAD = IntToStringLimiltLength(pdo.HeadOffGauge, 8);
            l2L25_CoilPDO.OFF_ROLL_LEN_TAIL = IntToStringLimiltLength(pdo.TailOffGauge, 8);
            l2L25_CoilPDO.SURFACE_ACCU_CODE_IN = pdo.SurfaceAccuCodeIn;
            l2L25_CoilPDO.SURFACE_ACCU_CODE_OUT = pdo.SurfaceAccuCodeOut;
            l2L25_CoilPDO.FLIP_TAG = pdo.FlipTag;
            l2L25_CoilPDO.PROCESS_CODE = pdo.ProcessCode;
            l2L25_CoilPDO.UNCOIL_DIRECTION = pdo.UnCoilDirection;

            return l2L25_CoilPDO;
        }


        private static void FromPDIDefect(int groupNo, TBL_PDI_DefectData defect, L2L25_CoilPDI l2L25_CoilPDI)
        {
            var datetime = DateTime.Now;
            var DEFECT_CODEValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectCode").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_CODE" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_CODEValue);

            var DEFECT_FROMValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectOrigin").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_FROM" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_FROMValue);

            var DEFECT_SURFValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectSide").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_SURF" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_SURFValue);

            var DEFECT_POSITION_WIDTHValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionWidthDirection").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_POSITION_WIDTH" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_POSITION_WIDTHValue);

            var DEFECT_LEN_STARTValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionLengthStartDirection").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_LEN_START" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_LEN_STARTValue);

            var DEFECT_LEN_ENDValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionLengthEndDirection").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_LEN_END" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_LEN_ENDValue);

            var DEFECT_CLASSValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectLevel").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_CLASS" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_CLASSValue);

            var DEFECT_PERCENTValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPercent").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_PERCENT" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_PERCENTValue);

            var DEFECT_QUALITY_GRADEValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "QuilityLevel").GetValue(defect).ToString();
            l2L25_CoilPDI.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_QUALITY_GRADE" + groupNo).SetValue(l2L25_CoilPDI, DEFECT_QUALITY_GRADEValue);
        }


        private static void FromPDODefect(int groupNo, TBL_PDO_DefectData defect, L2L25_CoilPDO l2L25_CoilPDO)
        {
            var datetime = DateTime.Now;
            string actGroupNo = groupNo == 10 ? "A" : groupNo.ToString();
            var DEFECT_CODEValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectCode").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_CODE_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_CODEValue);

            var DEFECT_FROMValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectOrigin").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_FROM_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_FROMValue);

            var DEFECT_SURFValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectSide").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_SURF_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_SURFValue);

            var DEFECT_POSITION_WIDTHValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionWidthDirection").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_POSITION_WIDTH_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_POSITION_WIDTHValue);

            var DEFECT_LEN_STARTValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionLengthStartDirection").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_LEN_START_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_LEN_STARTValue);

            var DEFECT_LEN_ENDValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPositionLengthEndDirection").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_LEN_END_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_LEN_ENDValue);

            var DEFECT_CLASSValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectLevel").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_CLASS_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_CLASSValue);

            var DEFECT_PERCENTValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "DefectPercent").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_PERCENT_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_PERCENTValue);

            var DEFECT_QUALITY_GRADEValue = defect.GetType().GetProperties().FirstOrDefault(x => x.Name == "QuilityLevel").GetValue(defect).ToString();
            l2L25_CoilPDO.GetType().GetProperties().FirstOrDefault(x => x.Name == "DEFECT_QUALITY_GRADE_" + actGroupNo).SetValue(l2L25_CoilPDO, DEFECT_QUALITY_GRADEValue);
        }


        public static L2L25_CoilPDO GetL25PDO()
        {
            L2L25_CoilPDO l2L25_CoilPDO = new L2L25_CoilPDO();
            return l2L25_CoilPDO;
        }


        private static string IntToStringLimiltLength(int value, int lengh, int point = 1)
        {
            var actValue = Convert.ToString(value * point);
            if (actValue.Length < lengh)
            {
                return actValue.Substring(0);
            }
            else
            {
                return actValue.Substring(0, lengh);
            }
        }

        private static string IntToStringLimiltLength(float value, int lengh, int point = 1)
        {
            var actValue = Convert.ToString(value * point);
            if (actValue.Length < lengh)
            {
                return actValue.Substring(0);
            }
            else
            {
                return actValue.Substring(0, lengh);
            }
        }
    }

    public static class TblFactory
    {
        /// <summary>報文格式轉換成Tbl , 當作儲存Log之用</summary>
        /// <typeparam name="T">ORM</typeparam>
        /// <param name="msgStruct">報文</param>
        public static T FromMessage<T>(object msgStruct, bool containsDateTime = true)
        {
            //產生ORM實例:
            T orm = Activator.CreateInstance<T>();

            var msgKV = msgStruct.GetType().GetFields().ToDictionary(x => x.Name, x => x.GetValue(msgStruct));
            var ormProps = orm.GetType().GetProperties();

            foreach (var property in ormProps)
            {
                if (msgKV.ContainsKey(property.Name))
                {
                    var value = msgKV[property.Name];
                    if (value.GetType() == typeof(char[]) && property.PropertyType == typeof(string))
                    {
                        property.SetValue(orm, new string(value as char[]).Trim('\0').Trim());
                    }
                    else
                    {
                        property.SetValue(orm, value);
                    }
                }
            }

            if (containsDateTime)
            {
                var createTime = ormProps.FirstOrDefault(x => x.Name.Replace("_", "").ToLower() == "createdatetime");
                if (null != createTime)
                {
                    createTime.SetValue(orm, DateTime.Now);
                }
            }
            return orm;
        }
    }
}
