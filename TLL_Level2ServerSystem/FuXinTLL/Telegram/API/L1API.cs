using FuXinTLL.Telegram.L1;
using FuXinTLL.Table;
using Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
/**
 Author:ICSC 鄭天智
 Date:2020/3/27
 Desc:報文工廠
**/
namespace FuXinTLL.Telegram
{
    public class L1API
    {
        public L2ToL1_Structure.Msg_201 Create_Preset201(TBL_CoilPDI pdi,
            TBL_LookupTable_Flatter flatter,
            TBL_LookupTable_Leveler leveler,
            TBL_LookupTable_Tension tension,
            TBL_LookupTable_Trimmer trimmer,
            int pos)
        {

            var preset = new L2ToL1_Structure.Msg_201();

            #region Header
            preset.MessageId = 201;
            preset.MessageLength = (short)Marshal.SizeOf<L2ToL1_Structure.Msg_201>();
            preset.Date = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            preset.Time = int.Parse(DateTime.Now.ToString("HHmmss"));
            #endregion

            preset.CoilID = Formatter.GetFixedCharL1A24Format(pdi.EntryCoilID);
            preset.SteelGrade = Formatter.GetFixedCharL1A24Format(pdi.SteelGradeCode); 

            //float:
            preset.Thickness = pdi.EntryCoilThick;
            preset.Width = pdi.EntryCoilWidth;
            preset.EntryYieldStress = (pdi.YdStandMax + pdi.YdStandMin) / 2;
            preset.ExitYieldStress = (pdi.YdStandMax + pdi.YdStandMin) / 2;
            //preset.Elongation = (pdi.OrderElongationMax + pdi.OrderElongationMin) / 2;

            //float <- int
            preset.Density = pdi.Density;
            preset.CoilLength = pdi.EntryCoilLength;
            preset.CoilWeight = pdi.EntryCoilWeight;
            preset.InnerDiam = pdi.EntryCoilInnerDiam;
            preset.Diameter = pdi.EntryCoilOuterDiam;

            preset.ElongationMax = pdi.OrderElongationMax;
            preset.ElongationMin = pdi.OrderElongationMin;

            //string => char[]:
            preset.ProcessCode = Formatter.GetFixedCharL1A24Format(pdi.ProcessCode);
            //char [] 8碼填滿到24碼
            //preset.SteelGrade = Formatter.GetFixedChar(pdi.SteelGradeCode, 24);

            // lookupTable
            preset.LevelerControlMode = 0;
            //總是給100  //2021/11/15
            preset.LevelerSpeed = 100;

            preset.FlatterDepth1 = (flatter == null ? 0 : flatter.FlatterDepth1);
            preset.FlatterDepth2 = (flatter == null ? 0 : flatter.FlatterDepth2);

            preset.LevelerIntermesh1 = (leveler == null ? 0 : leveler.LevelerIntermesh1);
            preset.LevelerIntermesh2 = (leveler == null ? 0 : leveler.LevelerIntermesh2);
            preset.LevelerIntermesh3 = (leveler == null ? 0 : leveler.LevelerIntermesh3);
            preset.Elongation = (leveler == null ? 0 : leveler.Elongation);

            preset.EntryLooperTension = (tension == null ? 0 : (tension.EntryLooperTension * pdi.EntryCoilThick * pdi.EntryCoilWidth)/1000 );
            preset.ExitLooperTension = (tension == null ? 0 : (tension.ExitLooperTension * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);

            preset.LevelerTension = (tension == null ? 0 : (tension.LevelerTension * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);
            preset.LevelerTensionMax = (tension == null ? 0 : (tension.LevelerTensionMax * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);
            preset.LevelerTensionMin = (tension == null ? 0 : (tension.LevelerTensionMin * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);
            preset.UncoilerTension = (tension == null ? 0 : (tension.UncoilerTension * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);
            preset.RecoilerTension = (tension == null ? 0 : (tension.RecoilerTension * pdi.EntryCoilThick * pdi.EntryCoilWidth) / 1000);

            preset.SideTrimmerGap = (trimmer == null ? 0 : trimmer.Gap);
            preset.SideTrimmerLap = (trimmer == null ? 0 : trimmer.Lap);
            //出口寬度
            preset.SideTrimmerWidth = pdi.OutCoilWidth;

            //來料墊紙方式  0:無墊紙 1:全卷墊...
            preset.PaperWinder_Flag = string.IsNullOrWhiteSpace(pdi.PaperEntryFlag)? 0 : Convert.ToInt32(pdi.PaperEntryFlag);
            preset.ExitPaperCode = string.IsNullOrWhiteSpace(pdi.PaperUnwinderFlag) ? 0 : Convert.ToInt32(pdi.PaperUnwinderFlag);
            preset.ExitPaperType = string.IsNullOrWhiteSpace(pdi.PaperUnwinderType) ? 0 : Convert.ToInt32(pdi.PaperUnwinderType);

            //套筒
            preset.SleeveCodeEntry = string.IsNullOrWhiteSpace(pdi.EntrySleeveType) ? 0 : Convert.ToInt32(pdi.EntrySleeveType);
            preset.SleeveDmEntry = pdi.EntrySleeveInnerDiam;
            preset.ExitSleeveCode = string.IsNullOrWhiteSpace(pdi.ExitSleeveFlag) ? 0 : Convert.ToInt32(pdi.ExitSleeveFlag);
            preset.ExitSleeveDiameter = pdi.ExitSleeveInnerDiam; 

            //分切
            preset.CoilSplit = string.IsNullOrWhiteSpace(pdi.DividingFlag) ? 0 : Convert.ToInt32(pdi.DividingFlag);
            preset.SplitWeight1 = pdi.SplitWt1;
            preset.SplitWeight2 = pdi.SplitWt2;
            preset.SplitWeight3 = pdi.SplitWt3;
            preset.SplitWeight4 = pdi.SplitWt4;
            preset.SplitWeight5 = pdi.SplitWt5;
            preset.SplitWeight6 = 0;
  
            preset.SplitWeightMax = pdi.EntryCoilWeight;
            preset.SplitWeightMin = 0;

            preset.TailSampleLength = pdi.PaperEntryTailLength;
            preset.HeadSampleCount = 0;
            preset.HeadSampleLength = 0;
            preset.TailSampleCount = 0;
            preset.TailSampleLength = 0;

            preset.PrrPosId = pos;

            return preset;
        }

        public L2ToL1_Structure.Msg_201 Create_EmptyPreset(int pos)
        {
            return new L2ToL1_Structure.Msg_201()
            {
                #region Header
                MessageId = 201,
                MessageLength = (short)Marshal.SizeOf<L2ToL1_Structure.Msg_201>(),
                Date = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                Time = int.Parse(DateTime.Now.ToString("HHmmss")),

                // JT 2021.04.28
                CoilID = "".PadRight(20, ' ').PadRight(24, '\0').ToCharArray(),
                ProcessCode = "".PadRight(20, ' ').PadRight(24, '\0').ToCharArray(),
                SteelGrade = "".PadRight(20, ' ').PadRight(24, '\0').ToCharArray(),

                PrrPosId = pos
                #endregion

            };
        }

        public L2ToL1_Structure.Msg_202 Create_TrackMap202(List<TBL_TrackMap> trkMap)
        {
            var msg = new L2ToL1_Structure.Msg_202()
            {
                MessageId = 202,
                MessageLength = (short)Marshal.SizeOf<L2ToL1_Structure.Msg_202>(),
                Date = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                Time = int.Parse(DateTime.Now.ToString("HHmmssfff")),
                CoilIDRec = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDRecSk1 = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDRecSk2 = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDRecSk3 = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDUnc = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDUncSk1 = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDUncSk2 = Formatter.GetFixedCharL1A24Format(string.Empty),
                CoilIDUncSk3 = Formatter.GetFixedCharL1A24Format(string.Empty),
                Spare1 = 0,
                Spare2 = 0,
                Spare3 = 0,
                Spare4 = 0,
                Spare5 = 0
            };

            foreach (var item in trkMap)
            {
                string pos = item.Position.Trim();
                switch (pos)
                {
                    case nameof(TrkMapPos.ReCoiler):
                        msg.CoilIDRec = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.RecSkid1):
                        msg.CoilIDRecSk1 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.RecSkid2):
                        msg.CoilIDRecSk2 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.DTOP):
                        msg.CoilIDRecSk3 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.UnCoiler):
                        msg.CoilIDUnc = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.ETOP):
                        msg.CoilIDUncSk1 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.UncSkid2):
                        msg.CoilIDUncSk2 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;

                    case nameof(TrkMapPos.UncSkid3):
                        msg.CoilIDUncSk3 = Formatter.GetFixedCharL1A24Format(item.CoilID);
                        break;
                }
            }
            return msg;
        }

        public L2ToL1_Structure.Msg_203 Create_SplitId203(string outCoilID)
        {
            return new L2ToL1_Structure.Msg_203()
            {
                MessageId = 203,
                MessageLength = (short)Marshal.SizeOf<L2ToL1_Structure.Msg_203>(),
                Date = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                Time = int.Parse(DateTime.Now.ToString("HHmmss")),
                CoilID = Formatter.GetFixedCharL1A24Format(outCoilID),
                Spare1 = 0,
                Spare2 = 0,
                Spare3 = 0,
                Spare4 = 0,
                Spare5 = 0,
            };
        }

        public L2ToL1_Structure.Msg_204 Create_DelSkid204(int PosId)
        {
            return new L2ToL1_Structure.Msg_204()
            {
                MessageId = 204,
                MessageLength = (short)Marshal.SizeOf<L2ToL1_Structure.Msg_204>(),
                Date = int.Parse(DateTime.Now.ToString("yyyyMMdd")),
                Time = int.Parse(DateTime.Now.ToString("HHmmss")),
                DelPosId = PosId,
                Spare1 = 0,
                Spare2 = 0,
                Spare3 = 0,
                Spare4 = 0,
                Spare5 = 0
            };
        }
    }
}
