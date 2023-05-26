using Common.Utility;
using FuXinTLL.Table;
using FuXinTLL.Telegram.HMI;
using FuXinTLL.Telegram.MMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuXinTLL.Telegram
{
    public class MMSAPI
    {
        /// <summary>
        /// 請求生產命令
        /// </summary>
        /// <param name="coilID"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Request_Coil_Schedule_T2MM01 Create_ScheduleReq(string coilID = "0")
        {
            return new L2ToMms_Structure.Request_Coil_Schedule_T2MM01()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Request_Coil_Schedule_T2MM01>("T2MM01"),
                Requested_Coil_No = coilID.PadRight(20).ToCharArray()
            };
        }

        /// <summary>
        /// 請求PDI
        /// </summary>
        /// <param name="coilNo"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Request_Coil_PDI_T2MM02 Create_PDIReq(string coilNo)
        {
            return new L2ToMms_Structure.Request_Coil_PDI_T2MM02()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Request_Coil_PDI_T2MM02>("T2MM02"),
                Requested_Coil_No = coilNo.PadRight(20).ToCharArray()
            };
        }
        /// <summary>
        /// 生產命令應答
        /// </summary>
        /// <param name="coilID"></param>
        /// <param name="processResult"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Response_For_Coil_Schedule_T2MM03 Create_ReponseForSchedule(string coilID, string processResult, string cause)
        {
            return new L2ToMms_Structure.Response_For_Coil_Schedule_T2MM03()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Response_For_Coil_Schedule_T2MM03>("T2MM03"),
                Requested_Coil_No = (coilID ?? "").PadRight(20).ToCharArray(),
                Process_Result = (processResult ?? "").PadRight(1).ToCharArray(),
                Reject_Cause = (cause ?? "").PadRight(80).ToCharArray(),
            };
        }

        /// <summary>
        /// 鋼捲PDI應答
        /// </summary>
        /// <param name="coilID"></param>
        /// <param name="processResult"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Response_For_Coil_PDI_T2MM04 Create_ResponseForPDI(string coilID, string processResult, string cause)
        {
            return new L2ToMms_Structure.Response_For_Coil_PDI_T2MM04()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Response_For_Coil_PDI_T2MM04>("T2MM04"),
                Requested_Coil_No = coilID.PadRight(20).ToArray(),
                Process_Result = processResult.ToArray(),
                Reject_Cause = cause.PadRight(80).ToArray()
            };
        }

        /// <summary>
        /// 回退鋼捲
        /// </summary>
        /// <param name="pdi"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Coil_Reject_Result_T2MM05 Create_CoilReject(TBL_CoilPDI pdi, HMI_ClientToServer_Structure.ReturnCoil msg)
        {
            var pdidefect = DBService.CoilAPI.Query_PdiDefect(msg.EntryCoilNo);
            var coilReject = new L2ToMms_Structure.Coil_Reject_Result_T2MM05()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Coil_Reject_Result_T2MM05>("T2MM05"),
                RejectCoilNo = msg.RejectCoilNo.PadRight(20).ToCharArray(),
                EntryCoilNo = pdi.EntryCoilID.PadRight(20).ToCharArray(),
                InnerDiameterOfRejectedCoil = pdi.EntryCoilInnerDiam.ToString("0000").ToCharArray(),
                OuterDiameterOfRejectedCoil = pdi.EntryCoilOuterDiam.ToString("0000").ToCharArray(),
                PaperExitCode = pdi.PaperEntryType.PadRight(1).ToCharArray(),
                PLANNO = pdi.PlanNo.PadRight(10).ToCharArray(),
                TimeOfReject = DateTime.Now.ToString("yyyyMMddHHmmss").ToCharArray(),
                LengthOfRejectedCoil = pdi.EntryCoilLength.ToString("00000").ToCharArray(),
                WeightOfRejectedCoil = pdi.EntryCoilWeight.ToString("00000").ToCharArray(),
                ReasonOfReject = msg.RejectReasonCode.PadRight(4).ToCharArray(),
                ModeOfReject =  msg.MadeOfReject.PadRight(1).ToCharArray(),
                TurnOfReject = msg.RejectTurn.PadRight(1).ToCharArray(),
                ShiftOfReject =  msg.RejectShift.PadRight(1).ToCharArray(),

                HeadPaperLength = msg.HeadPaperLength.PadRight(5).ToCharArray(),
                HeadPaperWidth = msg.HeadPaperWidth.PadRight(5).ToCharArray(),
                TailPaperLength = msg.TailPaperLength.PadRight(5).ToCharArray(),
                TailPaperWidth = msg.TailPaperWidth.PadRight(5).ToCharArray(),

                FinalFlag = msg.FinalFlag.PadRight(1).ToCharArray(),
                PaperType = msg.PaperType.PadRight(4).ToCharArray(),
                //L1 給不出缺陷，一律帶入PDI缺陷
            };
            if (pdidefect.Count > 0)
            {
                coilReject.Defect1 = Create_PdiDefect(pdidefect.ElementAt(0));
                coilReject.Defect2 = Create_PdiDefect(pdidefect.ElementAt(1));
                coilReject.Defect3 = Create_PdiDefect(pdidefect.ElementAt(2));
                coilReject.Defect4 = Create_PdiDefect(pdidefect.ElementAt(3));
                coilReject.Defect5 = Create_PdiDefect(pdidefect.ElementAt(4));
                coilReject.Defect6 = Create_PdiDefect(pdidefect.ElementAt(5));
                coilReject.Defect7 = Create_PdiDefect(pdidefect.ElementAt(6));
                coilReject.Defect8 = Create_PdiDefect(pdidefect.ElementAt(7));
                coilReject.Defect9 = Create_PdiDefect(pdidefect.ElementAt(8));
                coilReject.Defect10 = Create_PdiDefect(pdidefect.ElementAt(9));
            }
            else
            {
                coilReject.Defect1 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect2 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect3 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect4 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect5 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect6 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect7 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect8 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect9 = Create_PdiDefect(new TBL_PDI_DefectData());
                coilReject.Defect10 = Create_PdiDefect(new TBL_PDI_DefectData());
            }


            return coilReject;
        }

        /// <summary>
        /// 鋼捲上鞍座
        /// </summary>
        /// <param name="planNo"></param>
        /// <param name="coilID"></param>
        /// <param name="loadTime"></param>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Coil_Loaded_Skid_T2MM06 Create_CoilLoadedSkid(string planNo, string coilID, string loadTime, string unitCode)
        {
            return new L2ToMms_Structure.Coil_Loaded_Skid_T2MM06()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Coil_Loaded_Skid_T2MM06>("T2MM06"),
                Plan_No = planNo.PadRight(10).ToCharArray(),
                Entry_Coil_No = coilID.PadRight(20).ToCharArray(),
                Loaded_Time = loadTime.PadRight(14).ToCharArray(),
                unit_Code = unitCode.PadRight(4).ToCharArray()//undone 機組號 待用戶定義,20200226
            };
        }

        /// <summary>
        /// 鋼捲生產實績
        /// </summary>
        /// <param name="tblPdi"></param>
        /// <param name="tblPdo"></param>
        /// <param name="pdoDefects"></param>
        /// <returns></returns>
        public L2ToMms_Structure.PDO_T2MM07 Create_PDO(TBL_CoilPDO tblPdo, List<TBL_PDO_DefectData> pdoDefects)
        {
            // 
            var pdo = new L2ToMms_Structure.PDO_T2MM07
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.PDO_T2MM07>("T2MM07")
            };
            pdo.OrderNo = Fix(tblPdo.OrderNo, 10);
            pdo.PlanNo = Fix(tblPdo.PlanNo, 10);
            pdo.Out_mat_No = Fix(tblPdo.ExitCoilID.Trim('\0'), 20);
            pdo.In_mat_No = Fix(tblPdo.EntryCoilID.Trim('\0'), 20);
            pdo.Starttime = Fix(tblPdo.StartTime, 14);
            pdo.Finishtime = Fix(tblPdo.FinishTime, 14);
            pdo.Shift = Fix(tblPdo.Shift, 1);
            pdo.Team = Fix(tblPdo.Team, 1);
            pdo.SteelGradeCode = Fix(tblPdo.SteelNo, 8);
            pdo.Exitpapercode = Fix(tblPdo.ExitPaperCode, 3);
            pdo.PAPER_REQ_CODE = Fix(tblPdo.ExitPaperType, 1);

            //頭/尾 墊紙
            pdo.HEAD_PAPER_LENGTH = tblPdo.ExitPaperHeadLength.ToString("00000").ToCharArray();
            pdo.HEAD_PAPER_WIDTH = (tblPdo.ExitPaperHeadWidth * 10).ToString("00000").ToCharArray();
            pdo.TAIL_PAPER_LENGTH = tblPdo.ExitPaperTailLength.ToString("00000").ToCharArray();
            pdo.TAIL_PAPER_WIDTH = (tblPdo.PaperEntryTailWidth * 10).ToString("00000").ToCharArray();

            //出口套筒
            pdo.Exitsleeveuse = Fix(tblPdo.ExitSleeveFlag, 1);
            pdo.ExitSleeveDiameter = tblPdo.ExitSleeveDiameter.ToString("0000").ToCharArray();
            pdo.ExitSleeveCode = Fix(tblPdo.ExitSleeveCode, 4);

            //出口捲資訊
            pdo.Out_mat_Outer_Diameter = tblPdo.ExitCoilOuterDiam.ToString("0000").ToCharArray();
            pdo.Out_mat_inner = tblPdo.ExitCoilInnerDiam.ToString("0000").ToCharArray();
            pdo.Out_mat_thick = (tblPdo.ExitCoilThick * 1000).ToString("00000").ToCharArray();
            pdo.OUT_MAT_MIN_THICK = (tblPdo.ExitCoilThickMin * 1000).ToString("00000").ToCharArray();
            pdo.OUT_MAT_MAX_THICK = (tblPdo.ExitCoilThickMax * 1000).ToString("00000").ToCharArray();
            pdo.Out_mat_width = (tblPdo.ExitCoilWidth * 10).ToString("00000").ToCharArray();
            pdo.OUT_MAT_MIN_WIDTH = (tblPdo.ExitCoilWidthMax * 10).ToString("00000").ToCharArray();
            pdo.OUT_MAT_MAX_WIDTH = (tblPdo.ExitCoilWidthMin * 10).ToString("00000").ToCharArray();

            //頭
            pdo.HEAD_DS_THICK = (tblPdo.HeadDriveSideThick * 1000).ToString("00000").ToCharArray();
            pdo.HEAD_CT_THICK = (tblPdo.HeadMiddleSideThick * 1000).ToString("00000").ToCharArray();
            pdo.HEAD_OS_THICK = (tblPdo.HeadOperSideThick * 1000).ToString("00000").ToCharArray();
            pdo.HEAD_WIDTH = (tblPdo.HeadWidth * 10).ToString("00000").ToCharArray();

            //中
            pdo.MID_DS_THICK = (tblPdo.HalfDriveSideThick * 1000).ToString("00000").ToCharArray();
            pdo.MID_CT_THICK = (tblPdo.HalfMiddleSideThick * 1000).ToString("00000").ToCharArray();
            pdo.MID_OS_THICK = (tblPdo.HalfOperSideThick * 1000).ToString("00000").ToCharArray();
            pdo.MID_WIDTH = (tblPdo.HalfWidth * 10).ToString("00000").ToCharArray();

            //尾
            pdo.TAIL_DS_THICK = (tblPdo.TailDriveSideThick * 1000).ToString("00000").ToCharArray();
            pdo.TAIL_CT_THICK = (tblPdo.TailMiddleSideThick * 1000).ToString("00000").ToCharArray();
            pdo.TAIL_OS_THICK = (tblPdo.TailOperSideThick * 1000).ToString("00000").ToCharArray();
            pdo.TAIL_WIDTH = (tblPdo.TailWidth * 10).ToString("00000").ToCharArray();


            pdo.Out_mat_Length = tblPdo.ExitCoilLength.ToString("00000").ToCharArray();
            pdo.Out_mat_wt = tblPdo.ExitCoilNW.ToString("00000").ToCharArray();
            pdo.OUT_MAT_GROSS_WT = tblPdo.ExitCoilGW.ToString("00000").ToCharArray();
            pdo.TrimFlag = Fix(tblPdo.TrimFlag, 1);
            pdo.Elongation = (tblPdo.Elongation * 100).ToString("00000").ToCharArray();

            pdo.WINDING_DIRE = Fix(tblPdo.CoilerDirection, 1);
            pdo.BaseSurface = Fix(tblPdo.BaseSurface, 1);
            pdo.Inspector = Fix(tblPdo.InspectorCode, 10);
            pdo.Hold_flag = Fix(tblPdo.HoldFlag, 1);
            pdo.Hold_cause_code = Fix(tblPdo.HoldCauseCode, 4);
            pdo.Sample_flag = Fix(tblPdo.SampleFlag, 1);
            pdo.Dummy_flag = Fix(tblPdo.DummyFlag, 1);
            pdo.FIXED_WT_FLAG = Fix(tblPdo.DividFlag, 1);
            pdo.End_flag = Fix(tblPdo.EndFlag, 1);
            pdo.SCRAP_FLAG = Fix(tblPdo.ScrapFlag, 1);
            pdo.SAMPLE_FRQN_CODE = Fix(tblPdo.SampleFrqnCode, 3);
            pdo.FLATNESS_WAVE_HIGHT = (tblPdo.Flatness * 1000).ToString("00000").ToCharArray();
            pdo.SURFACE_ACCU_CODE = Fix(tblPdo.SurfaceCode, 2);
            pdo.SURFACE_ACCU_CODE_IN = Fix(tblPdo.SurfaceAccuCodeIn, 2);
            pdo.SURFACE_ACCU_CODE_OUT = Fix(tblPdo.SurfaceAccuCodeOut, 2);
            pdo.HEAD_OFF_GAUGE = tblPdo.HeadOffGauge.ToString("00000").ToCharArray();
            pdo.Tail_off_gauge = tblPdo.TailOffGauge.ToString("00000").ToCharArray();
            pdo.UNCOIL_DIRECTION = Fix(tblPdo.UnCoilDirection, 1);

            
            pdo.FLIP_TAG = Fix(tblPdo.FlipTag, 1);
            pdo.PROCESS_CODE = Fix(tblPdo.ProcessCode, 6);

            #region 缺陷
            if (pdoDefects.Count == 0)
            {
                pdo.Defect1 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect2 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect3 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect4 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect5 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect6 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect7 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect8 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect9 = Create_PdoDefect(new TBL_PDO_DefectData());
                pdo.Defect10 = Create_PdoDefect(new TBL_PDO_DefectData());
            }
            else
            {
                foreach (var d in pdoDefects)
                {
                    switch (d.DefectGroupNo)
                    {
                        case 1:
                            pdo.Defect1 = Create_PdoDefect(d);
                            break;
                        case 2:
                            pdo.Defect2 = Create_PdoDefect(d);
                            break;
                        case 3:
                            pdo.Defect3 = Create_PdoDefect(d);
                            break;
                        case 4:
                            pdo.Defect4 = Create_PdoDefect(d);
                            break;
                        case 5:
                            pdo.Defect5 = Create_PdoDefect(d);
                            break;
                        case 6:
                            pdo.Defect6 = Create_PdoDefect(d);
                            break;
                        case 7:
                            pdo.Defect7 = Create_PdoDefect(d);
                            break;
                        case 8:
                            pdo.Defect8 = Create_PdoDefect(d);
                            break;
                        case 9:
                            pdo.Defect9 = Create_PdoDefect(d);
                            break;
                        case 10:
                            pdo.Defect10 = Create_PdoDefect(d);
                            break;
                    }
                }
            }
            #endregion

            return pdo;
        }
        /// <summary>
        /// 休止實績
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08 Create_DownTime(HMI_ClientToServer_Structure.OrignData tbl, string flag)
        {
            var msg = new L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08>("T2MM08"),
                op_flag = flag.PadRight(1).ToCharArray(),
                unit_code = "TL".PadRight(4).ToCharArray(),

                prod_time = tbl.ProdTime.PadRight(8).Substring(0, 8).ToCharArray(),
                prod_shift_group = tbl.ProdShiftGroup.PadRight(1).Substring(0, 1).ToCharArray(),
                prod_shift_no = tbl.ProdShiftNo.PadRight(1).Substring(0, 1).ToCharArray(),

                delay_location = tbl.DelayLocation.PadRight(6).ToCharArray(),
                delay_reason_code = tbl.DelayReasonCode.PadRight(2).ToCharArray(),

                
                delay_reason_desc = tbl.DelayReasonDesc.FixStrBytes(50),
                delay_remark = tbl.DelayRemark.FixStrBytes(200),
                delay_location_desc = tbl.DelayReasonDesc.FixStrBytes(30),

                resp_depart_delay_time_c = tbl.RespDepartDelayTimeC.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_e = tbl.RespDepartDelayTimeE.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_m = tbl.RespDepartDelayTimeM.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_o = tbl.RespDepartDelayTimeO.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_p = tbl.RespDepartDelayTimeP.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_r = tbl.RespDepartDelayTimeR.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_u = tbl.RespDepartDelayTimeU.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_rs = tbl.RespDepartDelayTimeRS.ToString("0000000").ToCharArray(),

                stop_elased_time = tbl.StopElasedTime.ToString("0000000").ToCharArray(),
                stop_end_time = tbl.StopEndTime.PadRight(14).ToCharArray(),
                stop_start_time = tbl.StopStartTime.PadRight(14).ToCharArray(),

                DECELERATION_CODE = tbl.DecelerationCode.FixStrBytes(10),
                DECELERATION_CAUSE = tbl.DecelerationCause.FixStrBytes(200)
            };

            return msg;
        }
        /// <summary>
        /// 休止實績
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08 Create_DownTime(TBL_DownTime tbl, string flag)
        {
            var msg = new L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Equipment_Down_Result_Message_T2MM08>("T2MM08"),
                op_flag = flag.PadRight(1).ToCharArray(),
                unit_code = "TL".PadRight(4).ToCharArray(),

                prod_time = tbl.ProdTime.PadRight(8).Substring(0, 8).ToCharArray(),
                prod_shift_group = tbl.ProdShiftGroup.PadRight(1).Substring(0, 1).ToCharArray(),
                prod_shift_no = tbl.ProdShiftNo.PadRight(1).Substring(0, 1).ToCharArray(),

                delay_location = tbl.DelayLocation.PadRight(6).ToCharArray(),
                delay_reason_code = tbl.DelayReasonCode.PadRight(2).ToCharArray(),

                //undone 中文
                delay_remark = tbl.DelayRemark.FixStrBytes(200),
                delay_reason_desc = tbl.DelayReasonDesc.FixStrBytes(50),
                delay_location_desc = tbl.DelayReasonDesc.FixStrBytes(200),

                resp_depart_delay_time_c = tbl.RespDepartDelayTimeC.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_e = tbl.RespDepartDelayTimeE.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_m = tbl.RespDepartDelayTimeM.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_o = tbl.RespDepartDelayTimeO.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_p = tbl.RespDepartDelayTimeP.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_r = tbl.RespDepartDelayTimeR.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_u = tbl.RespDepartDelayTimeU.ToString("0000000").ToCharArray(),
                resp_depart_delay_time_rs = tbl.RespDepartDelayTimeRS.ToString("0000000").ToCharArray(),

                stop_elased_time = tbl.StopElasedTime.ToString("0000000").ToCharArray(),
                stop_end_time = tbl.StopEndTime.PadRight(14).ToCharArray(),
                stop_start_time = tbl.StopStartTime.PadRight(14).ToCharArray(),

                DECELERATION_CODE = tbl.DecelerationCode.FixStrBytes(10),
                DECELERATION_CAUSE = tbl.DecelerationCause.FixStrBytes(200)
            };

            return msg;
        }

        //undone MMS能源耗用報文待定義
        /// <summary>
        /// 能源耗用
        /// </summary>
        /// <returns></returns>
        public L2ToMms_Structure.Energy_Consumption_Information_T2MM09 Create_Energy()
        {
            return new L2ToMms_Structure.Energy_Consumption_Information_T2MM09()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Energy_Consumption_Information_T2MM09>("T2MM09"),
            };
        }

        /// <summary>
        /// 生產命令順序變更
        /// </summary>
        /// <param name="CoilNos"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Coil_Schedule_Changed_T2MM10 Create_ScheduleChange(List<string> CoilNos)
        {
            string totalCoils = string.Join("", CoilNos.Select(x => x.PadRight(20)));

            var msg = new L2ToMms_Structure.Coil_Schedule_Changed_T2MM10()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Coil_Schedule_Changed_T2MM10>("T2MM10"),
                Number_Of_Coils = CoilNos.Count.ToString().PadLeft(3).ToCharArray(),
                Entry_Coil_No = totalCoils.PadRight(6000).ToCharArray(),
            };

            return msg;
        }

        public L2ToMms_Structure.Dummy_Coil_List_Result_Request_T2MM15 Create_DummyCoilListReq(string dummyCoilID)
        {
            return new L2ToMms_Structure.Dummy_Coil_List_Result_Request_T2MM15()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Dummy_Coil_List_Result_Request_T2MM15>("T2MM15"),
                Dummy_Coil_No = dummyCoilID.PadRight(20).ToCharArray()
            };
        }

        public L2ToMms_Structure.Dummy_Coil_List_Delete_T2MM16 Create_DummyCoilListDelete(string dummyCoilID, string DeleteReason, string DeleteTime)
        {
            return new L2ToMms_Structure.Dummy_Coil_List_Delete_T2MM16()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Dummy_Coil_List_Delete_T2MM16>("T2MM16"),
                Dummy_Coil_No = dummyCoilID.PadRight(20).ToCharArray(),
                DeleteReason = DeleteReason.PadRight(5).ToCharArray(),
                DeleteTime = DeleteTime.PadRight(14).ToCharArray()
            };
        }

        /// <summary>
        /// 生產命令刪除
        /// </summary>
        /// <param name="coilID"></param>
        /// <param name="opID"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Coil_Schedule_Delete Create_ScheduleDelete(string coilID, string opID, string cause)
        {
            return new L2ToMms_Structure.Coil_Schedule_Delete()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Coil_Schedule_Delete>("T2MM18"),

                EntryCoilID = coilID.PadRight(20).ToArray(),
                OperatorID = opID.PadRight(10).ToCharArray(),
                ReasonCode = cause.PadRight(4).ToCharArray()
            };
        }

        /// <summary>
        /// 整計畫刪除應答
        /// </summary>
        /// <param name="planNo"></param>
        /// <param name="processResult"></param>
        /// <param name="cause"></param>
        /// <returns></returns>
        public L2ToMms_Structure.Response_PlanNoShedDelResult_T2MM25 Create_ResponseForPlanNoScheduleDelete(string planNo, string processResult, string cause)
        {
            return new L2ToMms_Structure.Response_PlanNoShedDelResult_T2MM25()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Response_PlanNoShedDelResult_T2MM25>("T2MM25"),
                Plan_No = (planNo ?? "").PadRight(10).ToCharArray(),
                Process_Result = (processResult ?? "").PadRight(1).ToCharArray(),
                Reject_Cause = cause.FixStrBytes(80)
            };
        }
        public L2ToMms_Structure.Energy_Consumption_Information_T2MM09 Create_Energy(HMI_ClientToServer_Structure.UploadEnergyConsumption msg)
        {
            var tg = new L2ToMms_Structure.Energy_Consumption_Information_T2MM09()
            {
                Header = MsgFactory.GetMMSHeader<L2ToMms_Structure.Energy_Consumption_Information_T2MM09>("T2MM09"),
            };

            //比對一樣的欄位
            foreach (var tgField in tg.GetType().GetFields())
            {
                var msgField = msg.GetType().GetFields().Where(x => x.Name == tgField.Name).FirstOrDefault();

                object value;
                if (msgField != null)
                {
                    value = msgField.GetValue(msg);
                }
                else { continue; }

                try
                {
                    if (tgField.Name != "Date" && tgField.Name != "Shift_No" && tgField.Name != "Group_No" && tgField.Name != "Unit_code")
                    {
                        if (value == null)
                        {
                            tgField.SetValue(tg, "".PadRight(20, '0').ToCharArray());
                        }
                        else
                        {
                            var val = (float.Parse((string)value) * 1000000).ToString();
                            tgField.SetValue(tg, (val).PadLeft(20, '0').ToCharArray());
                        }
                    }
                }
                catch (Exception)
                {
                    //為float
                    tgField.SetValue(tg, Convert.ToString(value).PadRight(20).ToCharArray());
                }
            }
            tg.DATE_TIME = msg.Date.ToCharArray();
            tg.SHIFT_NO = msg.Date.ToCharArray();
            tg.SHIFT_GROUP = msg.Date.ToCharArray();
            tg.UNIT_CODE = msg.Date.PadRight(4).ToCharArray();

            return tg;
        }

        private char[] Fix(string str, int fill)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "".PadRight(fill).ToCharArray();
            }
            else
            {
                return str.PadRight(fill).ToCharArray();
            }
        }

        private MMS_Defect_Structure Create_PdoDefect(TBL_PDO_DefectData defectData)
        {
            var d = new MMS_Defect_Structure()
            {
                Code = string.IsNullOrWhiteSpace(defectData.DefectCode) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectCode, 3),
                Origin = string.IsNullOrWhiteSpace(defectData.DefectOrigin) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectOrigin, 3),
                Side = string.IsNullOrWhiteSpace(defectData.DefectSide) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectSide, 1),
                LengthStartDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionLengthStartDirection) ? "".PadRight(4).ToCharArray() : Fix(defectData.DefectPositionLengthStartDirection, 4),
                LengthEndDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionLengthEndDirection) ? "".PadRight(4).ToCharArray() : Fix(defectData.DefectPositionLengthEndDirection, 4),
                WidthDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionWidthDirection) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectPositionWidthDirection, 1),
                Level = string.IsNullOrWhiteSpace(defectData.DefectLevel) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectLevel, 1),
                Percent = string.IsNullOrWhiteSpace(defectData.DefectPercent) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectPercent, 3),
                Quakity_Grade = string.IsNullOrWhiteSpace(defectData.DefectQualityGrade) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectQualityGrade, 1)

            };
            return d;
        }

        private MMS_Defect_Structure Create_PdiDefect(TBL_PDI_DefectData defectData)
        {
            var d = new MMS_Defect_Structure()
            {
                Code = string.IsNullOrWhiteSpace(defectData.DefectCode) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectCode, 3),
                Origin = string.IsNullOrWhiteSpace(defectData.DefectOrigin) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectOrigin, 3),
                Side = string.IsNullOrWhiteSpace(defectData.DefectSide) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectSide, 1),
                LengthStartDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionLengthStartDirection) ? "".PadRight(4).ToCharArray() : Fix(defectData.DefectPositionLengthStartDirection, 4),
                LengthEndDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionLengthEndDirection) ? "".PadRight(4).ToCharArray() : Fix(defectData.DefectPositionLengthEndDirection, 4),
                WidthDirection = string.IsNullOrWhiteSpace(defectData.DefectPositionWidthDirection) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectPositionWidthDirection, 1),
                Level = string.IsNullOrWhiteSpace(defectData.DefectLevel) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectLevel, 1),
                Percent = string.IsNullOrWhiteSpace(defectData.DefectPercent) ? "".PadRight(3).ToCharArray() : Fix(defectData.DefectPercent, 3),
                Quakity_Grade = string.IsNullOrWhiteSpace(defectData.DefectQualityGrade) ? "".PadRight(1).ToCharArray() : Fix(defectData.DefectQualityGrade, 1)

            };
            return d;
        }
    }
}
