using FuXinTLL.Telegram.API;
using FuXinTLL.Telegram.MMS;
using FuXinTLL.Telegram.WMS;
using System;
using System.Runtime.InteropServices;
/**
 Author:ICSC 鄭天智
 Date:2019/10/14
 Desc:報文工廠
**/
namespace FuXinTLL.Telegram
{
    /// <summary>
    /// 報文產生器
    /// </summary>
    public class MsgFactory
    {
        #region Header Maker
        /// <summary>產生報文標頭制式格式</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msgCode"></param>
        /// <returns></returns>
        public static MMS_Header_Structure GetMMSHeader<T>(string msgCode)
        {
            if (msgCode.Length != 6) throw new Exception("文號長度不符");
            DateTime now = DateTime.Now;
            int msgLen = Marshal.SizeOf<T>();

            var header = new MMS_Header_Structure()
            {
                Code = msgCode.ToCharArray(),
                FuncCode = "D".ToCharArray(),
                RcvWho = "MM".ToCharArray(),
                SendWho = "T2".ToCharArray(),
                Date = now.ToString("yyyyMMdd").ToCharArray(),
                Time = now.ToString("HHmmss").ToCharArray(),
                Length = msgLen.ToString("0000").ToCharArray()
            };

            return header;
        }

        /// <summary>產生報文標頭制式格式</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msgCode"></param>
        /// <returns></returns>
        public static WMS_Header_Structure GetWMSHeader<T>(string msgCode)
        {
            if (msgCode.Length != 4) throw new Exception("文號長度不符");
            DateTime now = DateTime.Now;
            int msgLen = Marshal.SizeOf<T>();

            var header = new WMS_Header_Structure()
            {
                Message_ID = msgCode.ToCharArray(),
                ID_Of_Destination_Computer = "WM".ToCharArray(),
                ID_Of_Source_Computer = "T0".ToCharArray(),
                Process_Date_Time = now.ToString("yyyyMMddHHmmss").ToCharArray(),
                Length = msgLen.ToString("0000").ToCharArray()
            };

            return header;
        }
        #endregion

        public static L1API L1 = new L1API();
        public static WMSAPI WMS = new WMSAPI();
        public static MMSAPI MMS = new MMSAPI();
        public static HMIAPI HMI = new HMIAPI();
    }
}
