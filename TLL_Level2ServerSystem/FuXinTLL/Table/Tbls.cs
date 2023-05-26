using L2;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	/// <summary>
	/// 紀錄線上剛捲  來自304電文
	/// </summary>
	public class TBL_OnlineCoil
	{
		[PrimaryKey]
		public int SerNo { get; set; }
		public string CoilID { get; set; }
		public string HeadPosCoil { get; set; }
		public string Lop1Pos { get; set; }
		public string Lop2Pos { get; set; }
	}


	public class TBL_L2SystemSetting
	{
		[PrimaryKey]
		public string FuntionName { get; set; }
		public string Value { get; set; }
	}

	public class TBL_LineStatus
	{
		public System.DateTime CreateDateTime { get; set; }
		public int StatusEn { get; set; }
		public int StatusTLL { get; set; }
		public int StatusEx { get; set; }
	}

	public class TBL_L1_Send_201_Preset
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		[PrimaryKey]
		public string CoilID { get; set; }
		public string SteelGrade { get; set; }
		public float Thickness { get; set; }
		public float Width { get; set; }
		public float Density { get; set; }
		public float CoilLength { get; set; }
		public float CoilWeight { get; set; }
		public string ProcessCode { get; set; }
		public float InnerDiam { get; set; }
		public float Diameter { get; set; }
		public float UncoilerTension { get; set; }
		public int SleeveFlag { get; set; }
		public int PaperWinder_Flag { get; set; }
		public float FlatterDepth1 { get; set; }
		public float FlatterDepth2 { get; set; }
		public int SleeveCodeEntry { get; set; }
		public float SleeveDmEntry { get; set; }
		public float EntryLooperTension { get; set; }
		public float EntryYieldStress { get; set; }
		public int LevelerControlMode { get; set; }
		public float LevelerTension { get; set; }
		public float LevelerTensionMax { get; set; }
		public float LevelerTensionMin { get; set; }
		public float LevelerSpeed { get; set; }
		public float Elongation { get; set; }
		public float ElongationMax { get; set; }
		public float ElongationMin { get; set; }
		public float LevelerIntermesh1 { get; set; }
		public float LevelerIntermesh2 { get; set; }
		public float LevelerIntermesh3 { get; set; }
		public float ExitLooperTension { get; set; }
		public float ExitYieldStress { get; set; }
		public float SideTrimmerGap { get; set; }
		public float SideTrimmerLap { get; set; }
		public float SideTrimmerWidth { get; set; }
		public int CoilSplit { get; set; }
		public float SplitWeight1 { get; set; }
		public float SplitWeight2 { get; set; }
		public float SplitWeight3 { get; set; }
		public float SplitWeight4 { get; set; }
		public float SplitWeight5 { get; set; }
		public float SplitWeight6 { get; set; }
		public float SplitWeightMax { get; set; }
		public float SplitWeightMin { get; set; }
		public float RecoilerTension { get; set; }
		public int TailSampleCount { get; set; }
		public float TailSampleLength { get; set; }
		public int HeadSampleCount { get; set; }
		public float HeadSampleLength { get; set; }
		public int ExitPaperCode { get; set; }
		public float ExitPaperType { get; set; }
		public int ExitSleeveCode { get; set; }
		public float ExitSleeveDiameter { get; set; }
		public int PrrPosId { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_ScheduleDelete_CoilReject_Record
	{
		public System.DateTime Create_DateTime { get; set; }
		public string Coil_ID { get; set; }
		public int ScheduleDelete_CoilReject_GroupNo { get; set; }
		public string ScheduleDelete_CoilReject_Code { get; set; }
		public string Remarks { get; set; }
		public string Create_UserID { get; set; }
	}

	public class TBL_AlloyElementData
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string CoilID { get; set; }
		[PrimaryKey]
		public string ElementCode { get; set; }
		public float ElementActual { get; set; }
	}

	public class TBL_DownTime
	{
		public System.DateTime CreateDateTime { get; set; }
		public string UnitCode { get; set; }
		[PrimaryKey]
		public string ProdTime { get; set; }
		public string ProdShiftNo { get; set; }
		public string ProdShiftGroup { get; set; }
		[PrimaryKey]
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
		public string IsUpload { get; set; }
	}

	public class TBL_CobData
	{
		[PrimaryKey]
		public int SerNO { get; set; }
		public string ChineseFormName { get; set; }
		public string FormName { get; set; }
		public string ChineseCobName { get; set; }
		public string CobName { get; set; }
		public string CobValue { get; set; }
		public string CobText { get; set; }
		public int CobNo { get; set; }
		public string IsCanChange { get; set; }
	}

	public class TBL_CoilDivisionData
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		[PrimaryKey]
		public string In_CoilID { get; set; }
		public string Out_CoilID { get; set; }
	}

	public class TBL_CoilMap
	{
		[PrimaryKey]
		public int SerNo { get; set; }
		public string CoilIDPos1 { get; set; }
		public string CoilIDPos2 { get; set; }
		public string CoilIDPos3 { get; set; }
		public string CoilIDPos4 { get; set; }
		public bool CoilIDPos4_Sensor { get; set; }
		public string CoilIDPos5 { get; set; }
		public string CoilIDPos6 { get; set; }
		public string CoilIDPos7 { get; set; }
		public string CoilIDPos8 { get; set; }
		public string CoilIDPos9 { get; set; }
		public bool CoilIDPos9_Sensor { get; set; }
		public string CoilIDPos10 { get; set; }
	}

	public class TBL_CoilPDO
	{
		[PrimaryKey]
		public int SerNo { get; set; }
		public System.DateTime Create_DateTime { get; set; }
		public string OrderNo { get; set; }
		[PrimaryKey]
		public string PlanNo { get; set; }
		[PrimaryKey]
		public string ExitCoilID { get; set; }
		public string EntryCoilID { get; set; }
		public string StartTime { get; set; }
		public string FinishTime { get; set; }
		public string Shift { get; set; }
		public string Team { get; set; }
		public string SteelNo { get; set; }
		public string ExitPaperCode { get; set; }
		public string ExitPaperType { get; set; }
		public int ExitPaperHeadLength { get; set; }
		public float ExitPaperHeadWidth { get; set; }
		public int ExitPaperTailLength { get; set; }
		public float PaperEntryTailWidth { get; set; }
		public string ExitSleeveFlag { get; set; }
		public int ExitSleeveDiameter { get; set; }
		public string ExitSleeveCode { get; set; }
		public int ExitCoilOuterDiam { get; set; }
		public int ExitCoilInnerDiam { get; set; }
		public float ExitCoilThick { get; set; }
		public float ExitCoilThickMin { get; set; }
		public float ExitCoilThickMax { get; set; }
		public float ExitCoilWidth { get; set; }
		public float ExitCoilWidthMin { get; set; }
		public float ExitCoilWidthMax { get; set; }
		public float HeadDriveSideThick { get; set; }
		public float HeadMiddleSideThick { get; set; }
		public float HeadOperSideThick { get; set; }
		public float HeadWidth { get; set; }
		public float HalfDriveSideThick { get; set; }
		public float HalfMiddleSideThick { get; set; }
		public float HalfOperSideThick { get; set; }
		public float HalfWidth { get; set; }
		public float TailDriveSideThick { get; set; }
		public float TailMiddleSideThick { get; set; }
		public float TailOperSideThick { get; set; }
		public float TailWidth { get; set; }
		public int ExitCoilLength { get; set; }
		public int ExitCoilNW { get; set; }
		public int ExitCoilGW { get; set; }
		public int ExitCoilTW { get; set; }
		public string TrimFlag { get; set; }
		public int Elongation { get; set; }
		public string CoilerDirection { get; set; }
		public string BaseSurface { get; set; }
		public string InspectorCode { get; set; }
		public string HoldFlag { get; set; }
		public string HoldCauseCode { get; set; }
		public string SampleFlag { get; set; }
		public string DummyFlag { get; set; }
		public string DividFlag { get; set; }
		public string EndFlag { get; set; }
		public string ScrapFlag { get; set; }
		public string SampleFrqnCode { get; set; }
		public float Flatness { get; set; }
		public string SurfaceCode { get; set; }
		public int HeadOffGauge { get; set; }
		public int TailOffGauge { get; set; }
		public string SurfaceAccuCodeIn { get; set; }
		public string SurfaceAccuCodeOut { get; set; }
		public string FlipTag { get; set; }
		public string ProcessCode { get; set; }

		public string UnCoilDirection { get; set; }

		public string State { get; set; }
		public string IsPrint { get; set; }
		public string ReprintUserID { get; set; }
		public System.DateTime? PrintDateTime { get; set; }
		public string ExitScanStatus { get; set; }
		public string ExitScanCoilID { get; set; }
		public string ExitConfirmCoilID { get; set; }
		public string ExitConfirmUserID { get; set; }
		public string CoilRejectFlag { get; set; }
		public string IsReject { get; set; }
		public System.DateTime? RejectDateTime { get; set; }
		public System.DateTime? UploadPDO { get; set; }
	}

	public class TBL_ConnectionStatus
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string ConnectionFrom { get; set; }
		[PrimaryKey]
		public string ConnectionTo { get; set; }
		[PrimaryKey]
		public string ConnectionType { get; set; }
		public string ConnectionIP { get; set; }
		public string ConnectionPort { get; set; }
		public string ConnectionStatus { get; set; }
	}

	public class TBL_L1_Receive_301_EnCoilCut
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilID { get; set; }
		public int CutMode { get; set; }
		public float CutLength { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_CoilPDI
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string PlanNo { get; set; }
		[PrimaryKey]
		public int MatSeqNo { get; set; }
		public string PlanSort { get; set; }
		[PrimaryKey]
		public string EntryCoilID { get; set; }
		public float EntryCoilThick { get; set; }
		public float EntryCoilWidth { get; set; }
		public int EntryCoilWeight { get; set; }
		public int EntryCoilLength { get; set; }
		public int EntryCoilInnerDiam { get; set; }
		public int EntryCoilOuterDiam { get; set; }
		public int MaterialCoilFlatness { get; set; }
		public string OutCoilID { get; set; }
		public float OutCoilThick { get; set; }
		public float OutCoilWidth { get; set; }
		public int OutCoilInnerDiam { get; set; }
		public string PaperEntryFlag { get; set; }
		public string PaperEntryType { get; set; }
		public int PaperEntryHeadLength { get; set; }
		public float PaperEntryHeadWidth { get; set; }
		public int PaperEntryTailLength { get; set; }
		public float PaperEntryTailWidth { get; set; }
		public int EntrySleeveInnerDiam { get; set; }
		public string EntrySleeveType { get; set; }
		public int ExitSleeveInnerDiam { get; set; }
		public string ExitSleeveFlag { get; set; }
		public string PaperUnwinderFlag { get; set; }
		public string PaperUnwinderType { get; set; }
		public string StrapNum { get; set; }
		public string DividingFlag { get; set; }
		public int DividingNum { get; set; }
		public int OrderWeightMin { get; set; }
		public int OrderWeightMax { get; set; }
		public int SplitWt1 { get; set; }
		public int SplitWt2 { get; set; }
		public int SplitWt3 { get; set; }
		public int SplitWt4 { get; set; }
		public int SplitWt5 { get; set; }
		public string OrderNo1 { get; set; }
		public string OrderNo2 { get; set; }
		public string OrderNo3 { get; set; }
		public string OrderNo4 { get; set; }
		public string OrderNo5 { get; set; }
		public float OrderThick { get; set; }
		public float OrderThickMin { get; set; }
		public float OrderThickMax { get; set; }
		public float OrderWidth { get; set; }
		public float OrderWidthMax { get; set; }
		public float OrderWidthMin { get; set; }
		public int OrderInner { get; set; }
		public int OrderElongationMax { get; set; }
		public int OrderElongationMin { get; set; }
		public int YdStandMax { get; set; }
		public int YdStandMin { get; set; }
		public int HardnessMax { get; set; }
		public int HardnessMin { get; set; }
		public int TsStandMax { get; set; }
		public int TsStandMin { get; set; }
		public int OrderFlatness { get; set; }
		public string CoilOrigin { get; set; }
		public string WholebacklogCode { get; set; }
		public string NextWholebacklogCode { get; set; }
		public string OrderNo { get; set; }
		public string SteelGradeSign { get; set; }
		public string SteelGradeCode { get; set; }
		public int Density { get; set; }
		public string OrderSurfaceCode { get; set; }
		public string SourceSurfaceCode { get; set; }
		public string PackType { get; set; }
		public string TrimFlag { get; set; }
		public string BaseSurface { get; set; }
		public string OrderBetterSurfWardCode { get; set; }
		public string DecoilerDirection { get; set; }
		public string ReworkType { get; set; }
		public string SampleFlag { get; set; }
		public string SampleFrqnCode { get; set; }
		public string SampleLotNo { get; set; }
		public string TestPlanNo { get; set; }
		public string QCState { get; set; }
		public int HeadOffGauge { get; set; }
		public int TailOffGauge { get; set; }
		public string SurfaceAccuCodeIn { get; set; }
		public string SurfaceAccuCodeOut { get; set; }
		public string WindingDire { get; set; }
		public string ProcessCode { get; set; }
		public string DummyFlag { get; set; }
		public string CustomerNameEng { get; set; }
		public string CustomerNameChn { get; set; }
		public string CustomerNo { get; set; }
		public string OrderSurfaceDesc { get; set; }
		public string SourceSurfaceDesc { get; set; }
		public string OrderSurfaceDescIn { get; set; }
		public string OrderSurfaceDescOut { get; set; }
		public string State { get; set; }
		public System.DateTime? UpdateDateTime_State { get; set; }
		public string EntryScanStatus { get; set; }
		public string EntryScanCoilID { get; set; }
		public string EntryConfirmCoilID { get; set; }
		public string EntryConfirmUserID { get; set; }
	}

	public class TBL_L1_Receive_302_CoilWeld
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilID { get; set; }
		public int WeldCurrent { get; set; }
		public int WeldSpd { get; set; }
		public int WeldWheelForce { get; set; }
		public int PlannishRollForce { get; set; }
		public int OpSideOverlap { get; set; }
		public int DrSideOverlap { get; set; }
		public int ExStripGrade { get; set; }
		public int EnStripGrade { get; set; }
		public int ExStripThick { get; set; }
		public int EnStripThick { get; set; }
		public int SchlNumber { get; set; }
		public int WeldTempSetPoint { get; set; }
		public string ExCoilID { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_303_ReqTrackMap
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_304_TrackMapLine
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public float RemDiamUnc { get; set; }
		public float RemLengthUnc { get; set; }
		public string Coil1ID { get; set; }
		public string Coil2ID { get; set; }
		public string Coil3ID { get; set; }
		public string Coil4ID { get; set; }
		public string Coil5ID { get; set; }
		public string Coil6ID { get; set; }
		public string Coil7ID { get; set; }
		public string Coil8ID { get; set; }
		public string Coil9ID { get; set; }
		public string Coil10ID { get; set; }
		public int DummyCoil { get; set; }
		public float HeadPosCoil1 { get; set; }
		public float HeadPosCoil2 { get; set; }
		public float HeadPosCoil3 { get; set; }
		public float HeadPosCoil4 { get; set; }
		public float HeadPosCoil5 { get; set; }
		public float HeadPosCoil6 { get; set; }
		public float HeadPosCoil7 { get; set; }
		public float HeadPosCoil8 { get; set; }
		public float HeadPosCoil9 { get; set; }
		public float HeadPosCoil10 { get; set; }
		public float Lop1Pos { get; set; }
		public float Lop2Pos { get; set; }
		public float ActDiamRec { get; set; }
		public float ActLengthRec { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_305_TrackMapEn
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilIDUnCoiler { get; set; }
		public string CoilIDSkid1 { get; set; }
		public string CoilIDSkid2 { get; set; }
		public string CoilIDSkid3 { get; set; }
		public int UncSk1_Sensor { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_306_TrackMapEx
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilIDReCoiler { get; set; }
		public string CoilIDRecSkid1 { get; set; }
		public string CoilIDRecSkid2 { get; set; }
		public string CoilIDRecSkid3 { get; set; }
		public int RecSk3_Sensor { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_307_CoilDismount
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public float CoilWeight { get; set; }
		public float CoilLength { get; set; }
		public float Diameter { get; set; }
		public float CoiInsideDiam { get; set; }
		public string CoilID { get; set; }
		public int SleeveCode { get; set; }
		public float SleeveDiameter { get; set; }
		public int PaperCode { get; set; }
		public int PaperType { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_308_CoilWeightScale
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public float CoilWeight { get; set; }
		public string CoilId { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_ClassData
	{
		[PrimaryKey]
		public int SerNo { get; set; }
		public System.DateTime CreateDateTime { get; set; }
		public System.DateTime Date { get; set; }
		public string Shift { get; set; }
		public string Team { get; set; }
		public string ShiftStartTime { get; set; }
		public string ShiftEndTime { get; set; }
		public string ShiftCase { get; set; }
		public string UserID { get; set; }
		public string UpdatedProc { get; set; }
	}

	public class TBL_L1_Receive_309_EquipMaint
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int StatusEn { get; set; }
		public int StatusTLL { get; set; }
		public int StatusEx { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_310_LineFault
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int FaultCode { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public int StopCategory { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_311_ExCoilCut
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilID { get; set; }
		public float CutLength { get; set; }
		public int CutMode { get; set; }
		public float DiamRec { get; set; }
		public float LengthRec { get; set; }
		public float CalculateWeightRec { get; set; }
		public int PUWFlag { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_312_NewCoilRec
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilID { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_ExCoilCutData
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string CoilID { get; set; }
		public float CutLength { get; set; }
		public int CutMode { get; set; }
		public float DiamRec { get; set; }
		public float LengthRec { get; set; }
		public float CalculateWeightRec { get; set; }
		public int PUWFlag { get; set; }
	}

	public class TBL_L1_Receive_313_SpdTen
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public float SpeedActEn { get; set; }
		public float SpeedActProcess { get; set; }
		public float SpeedActEx { get; set; }
		public float TenRefUnc { get; set; }
		public float TenActUnc { get; set; }
		public float TenRefEnLop { get; set; }
		public float TenActEnLop { get; set; }
		public float TenRefLeveler { get; set; }
		public float TenActLeveler { get; set; }
		public float TenRefExLop { get; set; }
		public float TenActExLop { get; set; }
		public float TenRefRec { get; set; }
		public float TenActRec { get; set; }
		public float ElongationRef { get; set; }
		public float ElongationAct { get; set; }
		public float LevelerIntermesh1Ref { get; set; }
		public float LevelerIntermesh1Act { get; set; }
		public float LevelerIntermesh2Ref { get; set; }
		public float LevelerIntermesh2Act { get; set; }
		public float LevelerIntermesh3Ref { get; set; }
		public float LevelerIntermesh3Act { get; set; }
		public float CoilWidthActual { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_315_Cdc
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int Cdc1 { get; set; }
		public int Cdc2 { get; set; }
		public int Cdc3 { get; set; }
		public int Cdc4 { get; set; }
		public int Cdc5 { get; set; }
		public int Cdc6 { get; set; }
		public int Cdc7 { get; set; }
		public int Cdc8 { get; set; }
		public int Cdc9 { get; set; }
		public int Cdc10 { get; set; }
		public int Cdc11 { get; set; }
		public int Cdc12 { get; set; }
		public int Cdc13 { get; set; }
		public int Cdc14 { get; set; }
		public int Cdc15 { get; set; }
		public int Cdc16 { get; set; }
		public int Cdc17 { get; set; }
		public int Cdc18 { get; set; }
		public int Cdc19 { get; set; }
		public int Cdc20 { get; set; }
		public int Cdc21 { get; set; }
		public int Cdc22 { get; set; }
		public int Cdc23 { get; set; }
		public int Cdc24 { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_316_Consumables
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public float CompressedAir { get; set; }
		public float Steam { get; set; }
		public float PortableWater { get; set; }
		public float DeW { get; set; }
		public float IW { get; set; }
		public float IndirectCollingWater { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_L1_Receive_317_L1Init
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
	}

	public class TBL_L1_Receive_318_CoilMem40
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		//public string CoilID140 { get; set; } = "";
		public string CoilID1 { get; set; } = "";
		public string CoilID2 { get; set; } = "";
		public string CoilID3 { get; set; } = "";
		public string CoilID4 { get; set; } = "";
		public string CoilID5 { get; set; } = "";
		public string CoilID6 { get; set; } = "";
		public string CoilID7 { get; set; } = "";
		public string CoilID8 { get; set; } = "";
		public string CoilID9 { get; set; } = "";
		public string CoilID10 { get; set; } = "";
		public string CoilID11 { get; set; } = "";
		public string CoilID12 { get; set; } = "";
		public string CoilID13 { get; set; } = "";
		public string CoilID14 { get; set; } = "";
		public string CoilID15 { get; set; } = "";
		public string CoilID16 { get; set; } = "";
		public string CoilID17 { get; set; } = "";
		public string CoilID18 { get; set; } = "";
		public string CoilID19 { get; set; } = "";
		public string CoilID20 { get; set; } = "";
		public string CoilID21 { get; set; } = "";
		public string CoilID22 { get; set; } = "";
		public string CoilID23 { get; set; } = "";
		public string CoilID24 { get; set; } = "";
		public string CoilID25 { get; set; } = "";
		public string CoilID26 { get; set; } = "";
		public string CoilID27 { get; set; } = "";
		public string CoilID28 { get; set; } = "";
		public string CoilID29 { get; set; } = "";
		public string CoilID30 { get; set; } = "";
		public string CoilID31 { get; set; } = "";
		public string CoilID32 { get; set; } = "";
		public string CoilID33 { get; set; } = "";
		public string CoilID34 { get; set; } = "";
		public string CoilID35 { get; set; } = "";
		public string CoilID36 { get; set; } = "";
		public string CoilID37 { get; set; } = "";
		public string CoilID38 { get; set; } = "";
		public string CoilID39 { get; set; } = "";
		public string CoilID40 { get; set; } = "";

	}



	public class TBL_WMS_ReceiveRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string FromSystemID { get; set; }
		public string ReceiveDataDate { get; set; }
		public string ReceiveDataTime { get; set; }
		public string isAck { get; set; }
	}

	public class TBL_L1_Send_202_TrackMapL2
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilIDUnc { get; set; }
		public string CoilIDUncSk1 { get; set; }
		public string CoilIDUncSk2 { get; set; }
		public string CoilIDUncSk3 { get; set; }
		public string CoilIDRec { get; set; }
		public string CoilIDRecSk1 { get; set; }
		public string CoilIDRecSk2 { get; set; }
		public string CoilIDRecSk3 { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_WMS_SendRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string ToSystemID { get; set; }
		public string SendDataDate { get; set; }
		public string SendDataTime { get; set; }
		public string isAck { get; set; }
	}

	public class TBL_L1_Send_203_SplitId
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public string CoilID { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_OperatorAuthorityColumns
	{
		[PrimaryKey]
		public string TableName { get; set; }
		[PrimaryKey]
		public string ColumnsName { get; set; }
		public string Administrator { get; set; }
		public string Manager { get; set; }
		public string Operator { get; set; }
	}

	public class TBL_L1_Send_204_DelSkid
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public short MessageLength { get; set; }
		public short MessageId { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int DelPosId { get; set; }
		public int Spare1 { get; set; }
		public int Spare2 { get; set; }
		public int Spare3 { get; set; }
		public int Spare4 { get; set; }
		public int Spare5 { get; set; }
	}

	public class TBL_CoilSchedule
	{
		public System.DateTime Create_DateTime { get; set; }
		
		public float Sequence_No { get; set; }
		[PrimaryKey]
		public string Coil_ID { get; set; }
	}

	public class TBL_AuthorityData
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string UserID { get; set; }
		public string Password { get; set; }
		public string Department { get; set; }
		public string Team { get; set; }
		public int AuthorityClass { get; set; }
		public string Description { get; set; }
	}

	public class TBL_MMS_ReceiveRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string FromSystemID { get; set; }
		[PrimaryKey]
		public string ReceiveDataDate { get; set; }
		[PrimaryKey]
		public string ReceiveDataTime { get; set; }
		public string isAck { get; set; }
		
	}

	public class TBL_MMS_SendRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string ToSystemID { get; set; }
		public string SendDataDate { get; set; }
		public string SendDataTime { get; set; }
		public string isAck { get; set; }
    }

	public class TBL_BCS_ReceiveRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string FromSystemID { get; set; }
		[PrimaryKey]
		public string ReceiveDataDate { get; set; }
		[PrimaryKey]
		public string ReceiveDataTime { get; set; }
		public string isAck { get; set; }
	}

	public class TBL_BCS_SendRecord
	{
		public string Header { get; set; }
		public string Data { get; set; }
		public string DataLength { get; set; }
		public string ToSystemID { get; set; }
		public string SendDataDate { get; set; }
		public string SendDataTime { get; set; }
		public string isAck { get; set; }
	}

	public class TBL_PDI_DefectData
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string CoilID { get; set; }
		[PrimaryKey]
		public int DefectGroupNo { get; set; }
		public string DefectCode { get; set; }
		public string DefectOrigin { get; set; }
		public string DefectSide { get; set; }
		public string DefectPositionWidthDirection { get; set; }
		public string DefectPositionLengthStartDirection { get; set; }
		public string DefectPositionLengthEndDirection { get; set; }
		public string DefectLevel { get; set; }
		public string DefectPercent { get; set; }
		public string DefectQualityGrade { get; set; }
	}

	public class TBL_AuthoritySetting
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string UserID { get; set; }
		[PrimaryKey]
		public string Frame_ID { get; set; }
		public int Frame_Function { get; set; }
	}

	public class TBL_PDO_DefectData
	{
		public System.DateTime CreateDateTime { get; set; }
		[PrimaryKey]
		public string CoilID { get; set; }
		[PrimaryKey]
		public int DefectGroupNo { get; set; }
		public string DefectCode { get; set; }
		public string DefectOrigin { get; set; }
		public string DefectSide { get; set; }
		public string DefectPositionWidthDirection { get; set; }
		public string DefectPositionLengthStartDirection { get; set; }
		public string DefectPositionLengthEndDirection { get; set; }
		public string DefectLevel { get; set; }
		public string DefectPercent { get; set; }
		public string DefectQualityGrade { get; set; }
	}

	public class NotPrimaryKey : Attribute
	{
		//不是key 的serNo 標籤
		//用於dapper 物件反射 新增 修改 刪除等
	}

	public partial class TBL_ProcessDataCT
	{
		public string Out_Coil_No { get; set; }
		public string In_Coil_No { get; set; }
		public string Plan_No { get; set; }
		[NotPrimaryKey]
		public int SerNo { get; set; }
		public string BeginDate { get; set; }
		public string BeginTime { get; set; }
		public string StopDate { get; set; }
		public string StopTime { get; set; }
		public string SeqUnit { get; set; }
		public string DataCode { get; set; }
		public string DataDesc { get; set; }
		public int DataCount { get; set; }
		public string DataString { get; set; }
		public System.DateTime Create_DateTime { get; set; }
	}

	public class TBL_ProcessData
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string CoilID { get; set; }
		public float SpeedActEn { get; set; }
		public float SpeedActProcess { get; set; }
		public float SpeedActEx { get; set; }
		public float TenRefUnc { get; set; }
		public float TenActUnc { get; set; }
		public float TenRefEnLop { get; set; }
		public float TenActEnLop { get; set; }
		public float TenRefLeveler { get; set; }
		public float TenActLeveler { get; set; }
		public float TenRefExLop { get; set; }
		public float TenActExLop { get; set; }
		public float TenRefRec { get; set; }
		public float TenActRec { get; set; }
		public float ElongationRef { get; set; }
		public float ElongationAct { get; set; }
		public float LevelerIntermesh1Ref { get; set; }
		public float LevelerIntermesh1Act { get; set; }
		public float LevelerIntermesh2Ref { get; set; }
		public float LevelerIntermesh2Act { get; set; }
		public float LevelerIntermesh3Ref { get; set; }
		public float LevelerIntermesh3Act { get; set; }
		public float CoilWidthActual { get; set; }
		public string UnCoilMeter { get; set; }
		public string EnLoopMeter { get; set; }
		public string LevelerMeter { get; set; }
		public string ExLoopMeter { get; set; }
		public string ReCoilMeter { get; set; }
	}

	public class TBL_ScheduleDelete_CoilReject_CodeDefinition
	{
		public System.DateTime Create_DateTime { get; set; }
		[PrimaryKey]
		public int ScheduleDelete_CoilReject_Code { get; set; }
		public string ScheduleDelete_CoilReject_Name { get; set; }
		public string Create_UserID { get; set; }
	}

	public class TBL_ScheduleDelete_CoilReject_GroupNoDefinition
	{
		public System.DateTime Create_DateTime { get; set; }
		[PrimaryKey]
		public int ScheduleDelete_CoilReject_GroupNo { get; set; }
		public string ScheduleDelete_CoilReject_GroupName { get; set; }
		public string Create_UserID { get; set; }
	}

	public class TBL_SystemSetting
	{
		[PrimaryKey]
		public string Parameter_Group { get; set; }
		[PrimaryKey]
		public string Parameter { get; set; }
		public string Value { get; set; }
		public string Remark { get; set; }
	}

	public class TBL_TrackMap
	{
		public string CoilID { get; set; }
		[PrimaryKey]
		public string Position { get; set; }
		public System.DateTime UpdateTime { get; set; }
	}

	public class TBL_TW01
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string Count { get; set; }
		public string CoilNo { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_TW02
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string sk11 { get; set; }
		public string sk12 { get; set; }
		public string sk13 { get; set; }
		public string TopSensor1 { get; set; }
		public string EntryExit1 { get; set; }
		public string sk21 { get; set; }
		public string sk22 { get; set; }
		public string sk23 { get; set; }
		public string TopSensor2 { get; set; }
		public string EntryExit2 { get; set; }
		public string sk31 { get; set; }
		public string sk32 { get; set; }
		public string sk33 { get; set; }
		public string TopSensor3 { get; set; }
		public string EntryExit3 { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_SleeveData
	{
		[PrimaryKey]
		public string CODE { get; set; }
		public string OUT_MAT_INNER_DIA { get; set; }
		public string SLEEVE_THICK { get; set; }
		public string SLEEVE_WIDTH { get; set; }
		public string SLEEVE_WT { get; set; }
		public string SLEEVE_TYPE { get; set; }
		public string OUT_MAT_WIDTH_MIN { get; set; }
		public string OUT_MAT_WIDTH_MAX { get; set; }
		public System.DateTime CreateDateTime { get; set; }
		public int Sequence_No { get; set; }
	}

	public class TBL_TW03
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string Coilno { get; set; }
		public string Orderno { get; set; }
		public string PackType { get; set; }
		public string InnerDia { get; set; }
		public string OuterDia { get; set; }
		public string CoilThick { get; set; }
		public string CoilWidth { get; set; }
		public string CoilWeight { get; set; }
		public string CoilTurn { get; set; }
		public string CoilContainsOil { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_TW04
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string Flag { get; set; }
		public string CoilNo { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_TW05
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string Flag { get; set; }
		public string CoilNo { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_PaperData
	{
		[PrimaryKey]
		public string CODE { get; set; }
		public string PAPER_WT { get; set; }
		public string PAPER_WIDTH { get; set; }
		public string PAPER_MIN_THICK { get; set; }
		public string PAPER_MAX_THICK { get; set; }
		public string PAPER_THICK { get; set; }
		public System.DateTime CreateDateTime { get; set; }
		public int Sequence_No { get; set; }
	}

	public class TBL_Utility
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public float CompressedAir { get; set; }
		public float Steam { get; set; }
		public float PortableWater { get; set; }
		public float DeW { get; set; }
		public float IW { get; set; }
		public float IndirectCollingWater { get; set; }
	}

	public class TBL_WT01
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string MessageID { get; set; }
		public string ProcessDateTime { get; set; }
		public string IDOfSourceComputer { get; set; }
		public string IDOfDestinationComputer { get; set; }
		public string Length { get; set; }
		public string CoilNo { get; set; }
		public string SkidNo { get; set; }
		public string Flag { get; set; }
		public string Spare { get; set; }
	}

	public class TBL_LookupTable_Trimmer
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string SteelNo { get; set; }
		public float EntryCoilThickMax { get; set; }
		public float EntryCoilThickMin { get; set; }
		public float Gap { get; set; }
		public float Lap { get; set; }
	}

	public class TBL_LookupTable_Tension
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string SteelNo { get; set; }
		public float EntryCoilThickMax { get; set; }
		public float EntryCoilThickMin { get; set; }
		public float EntryCoilWidthMax { get; set; }
		public float EntryCoilWidthMin { get; set; }
		public float UncoilerTension { get; set; }
		public float EntryLooperTension { get; set; }
		public float LevelerTension { get; set; }
		public float LevelerTensionMax { get; set; }
		public float LevelerTensionMin { get; set; }
		public float ExitLooperTension { get; set; }
		public float RecoilerTension { get; set; }
	}

	public class TBL_LookupTable_Leveler
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string SteelNo { get; set; }
		public float EntryCoilThickMax { get; set; }
		public float EntryCoilThickMin { get; set; }
		public float LevelerIntermesh1 { get; set; }
		public float LevelerIntermesh2 { get; set; }
		public float LevelerIntermesh3 { get; set; }
		public float Elongation { get; set; }
	}

	public class TBL_EventLog
	{
		[PrimaryKey]
		public System.DateTime Create_DateTime { get; set; }
		public string SystemID { get; set; }
		public string FunctionBlock { get; set; }
		public string FrameGroupNo { get; set; }
		public string FrameNo { get; set; }
		public string EventType { get; set; }
		public string EventDescription { get; set; }
		public string Command { get; set; }
	}

	public class TBL_LookupTable_Mapping
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string SteelNo { get; set; }
		public string STNo { get; set; }
		public string YS { get; set; }
		public string TS { get; set; }

	}

	public class TBL_LookupTable_Flatter
	{
		[PrimaryKey]
		public System.DateTime CreateDateTime { get; set; }
		public string SteelNo { get; set; }
		public float EntryCoilThickMax { get; set; }
		public float EntryCoilThickMin { get; set; }
		public float FlatterDepth1 { get; set; }
		public float FlatterDepth2 { get; set; }
	}

	#region L25
	//L25
	[Serializable]
	public partial class L2L25_Alive
	{
		public string Message_Length { get; set; }

		public string Message_Id { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }
	}
	[Serializable]
	public partial class L2L25_CoilMap
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(20)]
		public string CoilIDPos1 { get; set; }

		[StringLength(20)]
		public string CoilIDPos2 { get; set; }

		[StringLength(20)]
		public string CoilIDPos3 { get; set; }

		[StringLength(20)]
		public string CoilIDPos4 { get; set; }

		[StringLength(20)]
		public string CoilIDPos5 { get; set; }

		[StringLength(20)]
		public string CoilIDPos6 { get; set; }

		[StringLength(20)]
		public string CoilIDPos7 { get; set; }

		[StringLength(20)]
		public string CoilIDPos8 { get; set; }
	}
	[Serializable]
	public partial class L2L25_CoilPDI
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(10)]
		public string PLAN_NO { get; set; }

		[StringLength(3)]
		public string MAT_PLAN_SEQ_NO { get; set; }

		[StringLength(3)]
		public string PLAN_TYPE { get; set; }

		[StringLength(20)]
		public string IN_MAT_NO { get; set; }

		[StringLength(8)]
		public string IN_MAT_THICK { get; set; }

		[StringLength(8)]
		public string IN_MAT_WIDTH { get; set; }

		[StringLength(8)]
		public string IN_MAT_WT { get; set; }

		[StringLength(8)]
		public string IN_MAT_LEN { get; set; }

		[StringLength(8)]
		public string IN_MAT_INNER_DIA { get; set; }

		[StringLength(8)]
		public string IN_MAT_OUTER_DIA { get; set; }

		[StringLength(8)]
		public string FLATNESS_AVG_CR { get; set; }

		[StringLength(20)]
		public string OUT_MAT_NO { get; set; }

		[StringLength(8)]
		public string OUT_MAT_THICK { get; set; }

		[StringLength(8)]
		public string OUT_MAT_WIDTH { get; set; }

		[StringLength(8)]
		public string OUT_MAT_INNER_DIA { get; set; }

		[StringLength(3)]
		public string PAPER_CODE { get; set; }

		[StringLength(1)]
		public string PAPER_REQ_CODE { get; set; }

		[StringLength(8)]
		public string HEAD_PAPER_LENGTH { get; set; }

		[StringLength(8)]
		public string HEAD_PAPER_WIDTH { get; set; }

		[StringLength(8)]
		public string TAIL_PAPER_LENGTH { get; set; }

		[StringLength(8)]
		public string TAIL_PAPER_WIDTH { get; set; }

		[StringLength(8)]
		public string SLEEVE_DIAMTER { get; set; }

		[StringLength(4)]
		public string SLEEVE_TYPE_CODE { get; set; }

		[StringLength(8)]
		public string OUT_SLEEVE_DIAMTER { get; set; }

		[StringLength(4)]
		public string OUT_SLEEVE_TYPE_CODE { get; set; }

		[StringLength(3)]
		public string OUT_PAPER_CODE { get; set; }

		[StringLength(1)]
		public string OUT_PAPER_REQ_CODE { get; set; }

		[StringLength(5)]
		public string PACK_MODE { get; set; }

		[StringLength(1)]
		public string FIXED_WT_FLAG { get; set; }

		[StringLength(2)]
		public string DIVIDE_NUM { get; set; }

		[StringLength(5)]
		public string ORDER_UNIT_MAX_WT { get; set; }

		[StringLength(5)]
		public string ORDER_UNIT_MIN_WT { get; set; }

		[StringLength(8)]
		public string ORDER_WT1 { get; set; }

		[StringLength(8)]
		public string ORDER_WT2 { get; set; }

		[StringLength(8)]
		public string ORDER_WT3 { get; set; }

		[StringLength(8)]
		public string ORDER_WT4 { get; set; }

		[StringLength(5)]
		public string ORDER_WT5 { get; set; }

		[StringLength(8)]
		public string ORDER_NO1 { get; set; }

		[StringLength(10)]
		public string ORDER_NO2 { get; set; }

		[StringLength(10)]
		public string ORDER_NO3 { get; set; }

		[StringLength(10)]
		public string ORDER_NO4 { get; set; }

		[StringLength(10)]
		public string ORDER_NO5 { get; set; }

		[StringLength(8)]
		public string ORDER_THICK { get; set; }

		[StringLength(8)]
		public string ORDER_MIN_THICK { get; set; }

		[StringLength(8)]
		public string ORDER_MAX_THICK { get; set; }

		[StringLength(8)]
		public string ORDER_WIDTH { get; set; }

		[StringLength(8)]
		public string ORDER_MAX_WIDTH { get; set; }

		[StringLength(8)]
		public string ORDER_MIN_WIDTH { get; set; }

		[StringLength(8)]
		public string ORDER_INNER_DIA { get; set; }

		[StringLength(8)]
		public string EL_MAX { get; set; }

		[StringLength(8)]
		public string EL_MIN { get; set; }

		[StringLength(8)]
		public string YS_MAX { get; set; }

		[StringLength(8)]
		public string YS_MIN { get; set; }

		[StringLength(8)]
		public string HARDNESS_MAX { get; set; }

		[StringLength(8)]
		public string HARDNESS_MIN { get; set; }

		[StringLength(8)]
		public string TS_MAX { get; set; }

		[StringLength(8)]
		public string TS_MIN { get; set; }

		[StringLength(8)]
		public string FLAT_AIM { get; set; }

		[StringLength(3)]
		public string ORIGIN_CODE { get; set; }

		[StringLength(2)]
		public string PREV_WHOLE_BACKLOG_CODE { get; set; }

		[StringLength(2)]
		public string NEXT_WHOLE_BACKLOG_CODE { get; set; }

		[StringLength(10)]
		public string ORDER_NO { get; set; }

		[StringLength(50)]
		public string SG_SIGN { get; set; }

		[StringLength(8)]
		public string ST_NO { get; set; }

		[StringLength(8)]
		public string DENSITY { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCURACY { get; set; }

		[StringLength(4)]
		public string PACK_TYPE_CODE { get; set; }

		[StringLength(1)]
		public string TRIM_FLAG { get; set; }

		[StringLength(1)]
		public string BETTER_SURF_WARD_CODE { get; set; }

		[StringLength(1)]
		public string ORDER_BETTER_SURF_WARD_CODE { get; set; }

		[StringLength(1)]
		public string UNCOIL_DIRECTION { get; set; }

		[StringLength(4)]
		public string REPAIR_TYPE { get; set; }

		[StringLength(1)]
		public string SAMPLE_FLAG { get; set; }

		[StringLength(3)]
		public string SAMPLE_FRQN_CODE { get; set; }

		[StringLength(20)]
		public string SAMPLE_LOT_NO { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE1 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM1 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF1 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH1 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START1 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END1 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS1 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT1 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE1 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE2 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM2 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF2 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH2 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START2 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END2 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS2 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT2 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE2 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE3 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM3 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF3 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH3 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START3 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END3 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS3 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT3 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE3 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE4 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM4 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF4 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH4 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START4 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END4 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS4 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT4 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE4 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE5 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM5 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF5 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH5 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START5 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END5 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS5 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT5 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE5 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE6 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM6 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF6 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH6 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START6 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END6 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS6 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT6 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE6 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE7 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM7 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF7 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH7 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START7 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END7 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS7 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT7 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE7 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE8 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM8 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF8 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH8 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START8 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END8 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS8 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT8 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE8 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE9 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM9 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF9 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH9 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START9 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END9 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS9 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT9 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE9 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE10 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM10 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF10 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH10 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START10 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END10 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS10 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT10 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE10 { get; set; }

		[StringLength(50)]
		public string TEST_PLAN_NO { get; set; }

		[StringLength(500)]
		public string QC_REMARK { get; set; }

		[StringLength(8)]
		public string HEAD_OFF_GAUGE { get; set; }

		[StringLength(8)]
		public string TAIL_OFF_GAUGE { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE_IN { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE_OUT { get; set; }

		[StringLength(1)]
		public string COIL_DIRECTION { get; set; }

		[StringLength(6)]
		public string PROCESS_CODE { get; set; }

		[StringLength(200)]
		public string ORDER_CUST_ENAME { get; set; }

		[StringLength(200)]
		public string ORDER_CUST_CNAME { get; set; }

		[StringLength(20)]
		public string ORDER_CUST_CODE { get; set; }

		[StringLength(20)]
		public string SURFACE_ACCU_DESC { get; set; }

		[StringLength(20)]
		public string SURFACE_ACCURACY_DESC { get; set; }

		[StringLength(20)]
		public string SURFACE_ACCU_DESC_IN { get; set; }

		[StringLength(20)]
		public string SURFACE_ACCU_DESC_OUT { get; set; }
	}
	[Serializable]
	public partial class L2L25_CoilPDO
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(10)]
		public string ORDER_NO { get; set; }

		[StringLength(10)]
		public string PLAN_NO { get; set; }

		[StringLength(20)]
		public string OUT_MAT_NO { get; set; }

		[StringLength(20)]
		public string IN_MAT_NO { get; set; }

		[StringLength(14)]
		public string START_PROD_TIME { get; set; }

		[StringLength(14)]
		public string END_PROD_TIME { get; set; }

		[StringLength(1)]
		public string PROD_SHIFT_NO { get; set; }

		[StringLength(1)]
		public string PROD_SHIFT_GROUP { get; set; }

		[StringLength(8)]
		public string ST_NO { get; set; }

		[StringLength(3)]
		public string PAPER_CODE { get; set; }

		[StringLength(1)]
		public string PAPER_REQ_CODE { get; set; }

		[StringLength(8)]
		public string HEAD_PAPER_LENGTH { get; set; }

		[StringLength(8)]
		public string HEAD_PAPER_WIDTH { get; set; }

		[StringLength(8)]
		public string TAIL_PAPER_LENGTH { get; set; }

		[StringLength(8)]
		public string TAIL_PAPER_WIDTH { get; set; }

		[StringLength(1)]
		public string OUT_MAT_USE_SLEEVE_FLAG { get; set; }

		[StringLength(8)]
		public string SLEEVE_DIAMTER { get; set; }

		[StringLength(4)]
		public string SLEEVE_TYPE_CODE { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_OUTER_DIA { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_INNER_DIA { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_THICK { get; set; }

		[StringLength(8)]
		public string OUT_MAT_MIN_THICK { get; set; }

		[StringLength(8)]
		public string OUT_MAT_MAX_THICK { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_WIDTH { get; set; }

		[StringLength(8)]
		public string OUT_MAT_MIN_WIDTH { get; set; }

		[StringLength(8)]
		public string OUT_MAT_MAX_WIDTH { get; set; }

		[StringLength(8)]
		public string HEAD_DS_THICK { get; set; }

		[StringLength(8)]
		public string HEAD_CT_THICK { get; set; }

		[StringLength(8)]
		public string HEAD_OS_THICK { get; set; }

		[StringLength(8)]
		public string HEAD_WIDTH { get; set; }

		[StringLength(8)]
		public string MID_DS_THICK { get; set; }

		[StringLength(8)]
		public string MID_CT_THICK { get; set; }

		[StringLength(8)]
		public string MID_OS_THICK { get; set; }

		[StringLength(8)]
		public string MID_WIDTH { get; set; }

		[StringLength(8)]
		public string TAIL_DS_THICK { get; set; }

		[StringLength(8)]
		public string TAIL_CT_THICK { get; set; }

		[StringLength(8)]
		public string TAIL_OS_THICK { get; set; }

		[StringLength(8)]
		public string TAIL_WIDTH { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_LEN { get; set; }

		[StringLength(8)]
		public string OUT_MAT_ACT_WT { get; set; }

		[StringLength(8)]
		public string OUT_MAT_GROSS_WT { get; set; }

		[StringLength(1)]
		public string TRIM_FLAG { get; set; }

		[StringLength(8)]
		public string SPM_ELONG { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_1 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_1 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_1 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_1 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_1 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_1 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_1 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_1 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_1 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_2 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_2 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_2 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_2 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_2 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_2 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_2 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_2 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_2 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_3 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_3 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_3 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_3 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_3 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_3 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_3 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_3 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_3 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_4 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_4 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_4 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_4 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_4 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_4 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_4 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_4 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_4 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_5 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_5 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_5 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_5 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_5 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_5 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_5 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_5 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_5 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_6 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_6 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_6 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_6 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_6 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_6 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_6 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_6 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_6 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_7 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_7 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_7 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_7 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_7 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_7 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_7 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_7 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_7 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_8 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_8 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_8 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_8 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_8 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_8 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_8 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_8 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_8 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_9 { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_9 { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_9 { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_9 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_9 { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_9 { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_9 { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_9 { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_9 { get; set; }

		[StringLength(3)]
		public string DEFECT_CODE_A { get; set; }

		[StringLength(3)]
		public string DEFECT_FROM_A { get; set; }

		[StringLength(1)]
		public string DEFECT_SURF_A { get; set; }

		[StringLength(1)]
		public string DEFECT_POSITION_WIDTH_A { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_START_A { get; set; }

		[StringLength(4)]
		public string DEFECT_LEN_END_A { get; set; }

		[StringLength(1)]
		public string DEFECT_CLASS_A { get; set; }

		[StringLength(3)]
		public string DEFECT_PERCENT_A { get; set; }

		[StringLength(1)]
		public string DEFECT_QUALITY_GRADE_A { get; set; }

		[StringLength(1)]
		public string WINDING_DIRE { get; set; }

		[StringLength(1)]
		public string BETTER_SURF_WARD_CODE { get; set; }

		[StringLength(10)]
		public string HOLD_MAKER { get; set; }

		[StringLength(1)]
		public string HOLD_FLAG { get; set; }

		[StringLength(4)]
		public string HOLD_CAUSE_CODE { get; set; }

		[StringLength(1)]
		public string SAMPLE_FLAG { get; set; }

		[StringLength(1)]
		public string DUMMY_COIL_FLAG { get; set; }

		[StringLength(1)]
		public string FIXED_WT_FLAG { get; set; }

		[StringLength(1)]
		public string FINAL_COIL_FLAG { get; set; }

		[StringLength(1)]
		public string SCRAP_FLAG { get; set; }

		[StringLength(3)]
		public string SAMPLE_POS_CODE { get; set; }

		[StringLength(8)]
		public string FLATNESS_WAVE_HIGHT { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE { get; set; }

		[StringLength(8)]
		public string OFF_ROLL_LEN_HEAD { get; set; }

		[StringLength(8)]
		public string OFF_ROLL_LEN_TAIL { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE_IN { get; set; }

		[StringLength(2)]
		public string SURFACE_ACCU_CODE_OUT { get; set; }

		[StringLength(1)]
		public string FLIP_TAG { get; set; }

		[StringLength(6)]
		public string PROCESS_CODE { get; set; }

		[StringLength(1)]
		public string UNCOIL_DIRECTION { get; set; }
	}
	[Serializable]
	public partial class L2L25_DisConnection
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(1)]
		public string SystemID_1 { get; set; }

		[StringLength(1)]
		public string SystemID_2 { get; set; }

		[StringLength(1)]
		public string SystemID_3 { get; set; }

		[StringLength(1)]
		public string SystemID_6 { get; set; }

		[StringLength(1)]
		public string SystemID_8 { get; set; }

		[StringLength(1)]
		public string SystemID_9 { get; set; }

		[StringLength(1)]
		public string SystemID_10 { get; set; }
	}
	[Serializable]
	public partial class L2L25_DownTime
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(1)]
		public string OP_FLAG { get; set; }

		[StringLength(4)]
		public string UNIT_CODE { get; set; }

		[StringLength(8)]
		public string PROD_DATE { get; set; }

		[StringLength(1)]
		public string PROD_SHIFT_NO { get; set; }

		[StringLength(1)]
		public string PROD_SHIFT_GROUP { get; set; }

		[StringLength(14)]
		public string STOP_START_TIME { get; set; }

		[StringLength(14)]
		public string STOP_END_TIME { get; set; }

		[StringLength(6)]
		public string DELAY_LOCATION { get; set; }

		[StringLength(30)]
		public string DELAY_LOCATION_DESC { get; set; }

		[StringLength(7)]
		public string STOP_ELASED_TIME { get; set; }

		[StringLength(2)]
		public string STOP_REASON { get; set; }

		[StringLength(50)]
		public string DELAY_REASON_DESC { get; set; }

		[StringLength(200)]
		public string DELAY_REMARK { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_M { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_E { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_C { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_P { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_U { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_O { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_R { get; set; }

		[StringLength(7)]
		public string RESP_DEPART_DELAY_TIME_RS { get; set; }

		[StringLength(200)]
		public string DECELERATION_CAUSE { get; set; }

		[StringLength(10)]
		public string DECELERATION_CODE { get; set; }
	}
	[Serializable]
	public partial class L2L25_EnLoopTensionCT
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(2)]
		public string passNo { get; set; }

		[StringLength(20)]
		public string Out_mat_No { get; set; }

		[StringLength(5)]
		public string lineCode { get; set; }

		[StringLength(6)]
		public string seqUnit { get; set; }

		[StringLength(12)]
		public string dataCode { get; set; }

		[StringLength(30)]
		public string dataDesc { get; set; }

		[StringLength(6)]
		public string resultUnit { get; set; }

		[StringLength(8)]
		public string genBeginDate { get; set; }

		[StringLength(6)]
		public string genBeginTime { get; set; }

		[StringLength(8)]
		public string genStopDate { get; set; }

		[StringLength(6)]
		public string genStopTime { get; set; }

		[StringLength(4)]
		public string frequency { get; set; }

		[StringLength(4)]
		public string DataCount { get; set; }

		public string DataString { get; set; }
	}
	[Serializable]
	public partial class L2L25_ExLoopTensionCT
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(2)]
		public string passNo { get; set; }

		[StringLength(20)]
		public string Out_mat_No { get; set; }

		[StringLength(5)]
		public string lineCode { get; set; }

		[StringLength(6)]
		public string seqUnit { get; set; }

		[StringLength(12)]
		public string dataCode { get; set; }

		[StringLength(30)]
		public string dataDesc { get; set; }

		[StringLength(6)]
		public string resultUnit { get; set; }

		[StringLength(8)]
		public string genBeginDate { get; set; }

		[StringLength(6)]
		public string genBeginTime { get; set; }

		[StringLength(8)]
		public string genStopDate { get; set; }

		[StringLength(6)]
		public string genStopTime { get; set; }

		[StringLength(4)]
		public string frequency { get; set; }

		[StringLength(4)]
		public string DataCount { get; set; }

		public string DataString { get; set; }
	}
	[Serializable]
	public partial class L2L25_L2APStatus
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(1)]
		public string SystemAP_1 { get; set; }

		[StringLength(1)]
		public string SystemAP_2 { get; set; }

		[StringLength(1)]
		public string SystemAP_3 { get; set; }

		[StringLength(1)]
		public string SystemAP_4 { get; set; }

		[StringLength(1)]
		public string SystemAP_5 { get; set; }

		[StringLength(1)]
		public string SystemAP_6 { get; set; }

		[StringLength(1)]
		public string SystemAP_7 { get; set; }

		[StringLength(1)]
		public string SystemAP_8 { get; set; }

		[StringLength(1)]
		public string SystemAP_9 { get; set; }

		[StringLength(1)]
		public string SystemAP_10 { get; set; }

		[StringLength(1)]
		public string SystemAP_11 { get; set; }

		[StringLength(1)]
		public string SystemAP_12 { get; set; }

		[StringLength(1)]
		public string SystemAP_13 { get; set; }

		[StringLength(1)]
		public string SystemAP_14 { get; set; }

		[StringLength(1)]
		public string SystemAP_15 { get; set; }

		[StringLength(1)]
		public string SystemAP_16 { get; set; }
	}
	[Serializable]
	public partial class L2L25_LevelerTensionCT
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(2)]
		public string passNo { get; set; }

		[StringLength(20)]
		public string Out_mat_No { get; set; }

		[StringLength(5)]
		public string lineCode { get; set; }

		[StringLength(6)]
		public string seqUnit { get; set; }

		[StringLength(12)]
		public string dataCode { get; set; }

		[StringLength(30)]
		public string dataDesc { get; set; }

		[StringLength(6)]
		public string resultUnit { get; set; }

		[StringLength(8)]
		public string genBeginDate { get; set; }

		[StringLength(6)]
		public string genBeginTime { get; set; }

		[StringLength(8)]
		public string genStopDate { get; set; }

		[StringLength(6)]
		public string genStopTime { get; set; }

		[StringLength(4)]
		public string frequency { get; set; }

		[StringLength(4)]
		public string DataCount { get; set; }

		public string DataString { get; set; }
	}
	[Serializable]
	public partial class L2L25_RECTensionCT
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(2)]
		public string passNo { get; set; }

		[StringLength(20)]
		public string Out_mat_No { get; set; }

		[StringLength(5)]
		public string lineCode { get; set; }

		[StringLength(6)]
		public string seqUnit { get; set; }

		[StringLength(12)]
		public string dataCode { get; set; }

		[StringLength(30)]
		public string dataDesc { get; set; }

		[StringLength(6)]
		public string resultUnit { get; set; }

		[StringLength(8)]
		public string genBeginDate { get; set; }

		[StringLength(6)]
		public string genBeginTime { get; set; }

		[StringLength(8)]
		public string genStopDate { get; set; }

		[StringLength(6)]
		public string genStopTime { get; set; }

		[StringLength(4)]
		public string frequency { get; set; }

		[StringLength(4)]
		public string DataCount { get; set; }

		public string DataString { get; set; }
	}
	[Serializable]
	public partial class L2L25_UNCTensionCT
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(2)]
		public string passNo { get; set; }

		[StringLength(20)]
		public string Out_mat_No { get; set; }

		[StringLength(5)]
		public string lineCode { get; set; }

		[StringLength(6)]
		public string seqUnit { get; set; }

		[StringLength(12)]
		public string dataCode { get; set; }

		[StringLength(30)]
		public string dataDesc { get; set; }

		[StringLength(6)]
		public string resultUnit { get; set; }

		[StringLength(8)]
		public string genBeginDate { get; set; }

		[StringLength(6)]
		public string genBeginTime { get; set; }

		[StringLength(8)]
		public string genStopDate { get; set; }

		[StringLength(6)]
		public string genStopTime { get; set; }

		[StringLength(4)]
		public string frequency { get; set; }

		[StringLength(4)]
		public string DataCount { get; set; }

		public string DataString { get; set; }
	}
	[Serializable]
	public partial class L2L25_Utility
	{
		[StringLength(6)]
		public string Message_Length { get; set; }

		[StringLength(3)]
		public string Message_Id { get; set; }

		[Key]
		[Column(Order = 0)]
		[StringLength(8)]
		public string Date { get; set; }

		[Key]
		[Column(Order = 1)]
		[StringLength(9)]
		public string Time { get; set; }

		[StringLength(8)]
		public string CompressedAir { get; set; }

		[StringLength(8)]
		public string Steam { get; set; }

		[StringLength(8)]
		public string PortableWater { get; set; }

		[StringLength(8)]
		public string DeW { get; set; }

		[StringLength(8)]
		public string IW { get; set; }

		[StringLength(8)]
		public string IndirectCollingWater { get; set; }

		[StringLength(8)]
		public string spare { get; set; }
	}
	#endregion
}
