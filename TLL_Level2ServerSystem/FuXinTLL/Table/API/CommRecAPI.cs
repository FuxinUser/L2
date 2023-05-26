using L2;
using Models;
using System;
using System.Text;
/**
 Author:ICSC 鄭天智
 Date:2020/1/1
 Desc:報文收發記錄業務
**/
namespace FuXinTLL.Table
{
    public class CommRecAPI
    {
        private static DBHandler dbHand;
        public CommRecAPI(DBHandler p)
        {
            dbHand = p;
        }
        /// <summary>記錄L1報文發送</summary>
        public bool Insert_L1_SndRecord(short msgCode, dynamic msgObject)
        {
            bool isOk = false;
            dynamic orm = null;
            switch (msgCode)
            {
                case 201:
                    orm = TblFactory.FromMessage<TBL_L1_Send_201_Preset>(msgObject);
                    break;
                case 202:
                    orm = TblFactory.FromMessage<TBL_L1_Send_202_TrackMapL2>(msgObject);
                    break;
                case 203:
                    orm = TblFactory.FromMessage<TBL_L1_Send_203_SplitId>(msgObject);
                    break;
                case 204:
                    orm = TblFactory.FromMessage<TBL_L1_Send_204_DelSkid>(msgObject);
                    break;
            }
            if (orm != null)
            {
                isOk = dbHand.InsertOnly(orm);
            }
            return isOk;
        }

        /// <summary>記錄L1報文接收</summary>
        public bool Insert_L1_RcvRecord(short msgCode, dynamic msgObject)
        {
            bool isOk = false;
            dynamic orm = null;
            switch (msgCode)
            {
                case 301:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_301_EnCoilCut>(msgObject);
                    break;

                case 302:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_302_CoilWeld>(msgObject);
                    break;

                case 303:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_303_ReqTrackMap>(msgObject);
                    break;

                case 304:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_304_TrackMapLine>(msgObject);
                    break;

                case 305:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_305_TrackMapEn>(msgObject);
                    break;

                case 306:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_306_TrackMapEx>(msgObject);
                    break;

                case 307:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_307_CoilDismount>(msgObject);
                    break;

                case 308:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_308_CoilWeightScale>(msgObject);
                    break;

                case 309:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_309_EquipMaint>(msgObject);
                    break;

                case 310:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_310_LineFault>(msgObject);
                    break;

                case 311:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_311_ExCoilCut>(msgObject);
                    break;

                case 312:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_312_NewCoilRec>(msgObject);
                    break;

                case 313:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_313_SpdTen>(msgObject);
                    break;

                case 315:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_315_Cdc>(msgObject);
                    break;

                case 316:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_316_Consumables>(msgObject);
                    break;

                case 317:
                    orm = TblFactory.FromMessage<TBL_L1_Receive_317_L1Init>(msgObject);
                    break;
                case 318:
                    {
                        orm = TblFactory.FromMessage<TBL_L1_Receive_318_CoilMem40>(msgObject);
                        break;
                    }
            }
            if (orm != null)
            {
                isOk = dbHand.InsertOnly(orm);
            }
            return isOk;
        }

        /// <summary>記錄MMS報文發送</summary>
        public bool Insert_MMS_SndRecord(string msgID, byte[] rawData, string ack = "N")
        {
            return dbHand.InsertOnly(new TBL_MMS_SendRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                SendDataDate = DateTime.Now.ToString("yyyyMMdd"),
                SendDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = ack
            });
        }

        /// <summary>記錄MMS報文接收</summary>
        public bool Insert_MMS_RcvRecord(string msgID, byte[] rawData, string ack = "N")
        {
            bool isOk = dbHand.InsertOnly(new TBL_MMS_ReceiveRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                ReceiveDataDate = DateTime.Now.ToString("yyyyMMdd"),
                ReceiveDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = ack
            });
            return isOk;
        }

        public bool Insert_WMS_SndRecord(string msgID, byte[] rawData, string ack = "N")
        {
            return dbHand.InsertOnly(new TBL_WMS_SendRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                SendDataDate = DateTime.Now.ToString("yyyyMMdd"),
                SendDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = ack
            });
        }

        public bool Insert_WMS_RcvRecord(string msgID, byte[] rawData)
        {
            return dbHand.InsertOnly(new TBL_WMS_ReceiveRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                FromSystemID = "WM",
                ReceiveDataDate = DateTime.Now.ToString("yyyyMMdd"),
                ReceiveDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = "0"
            });
        }

        public bool Insert_BCS_SndRecord(string msgID, byte[] rawData)
        {
            return dbHand.InsertOnly(new TBL_BCS_SendRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                SendDataDate = DateTime.Now.ToString("yyyyMMdd"),
                SendDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = "0"
            });
        }

        public bool Insert_BCS_RcvRecord(string msgID, byte[] rawData)
        {
            return dbHand.InsertOnly(new TBL_BCS_ReceiveRecord()
            {
                Header = msgID,
                Data = Encoding.UTF8.GetString(rawData),
                DataLength = rawData.Length.ToString(),
                ReceiveDataDate = DateTime.Now.ToString("yyyyMMdd"),
                ReceiveDataTime = DateTime.Now.ToString("HHmmss.fff"),
                isAck = "0"
            });
        }
    }
}
