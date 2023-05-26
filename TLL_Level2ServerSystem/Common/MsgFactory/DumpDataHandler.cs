using Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MessageAnalUtil
{
    public static class DumpDataHandler
    {
        /// <summary>
        /// 備份電文原始資料到檔案
        /// </summary>
        /// <param name="data"></param>
        public static void DumpDataToFile(this byte[] data, string filePath = "")
        {
            //先不處理

            //PublicDef DBconn = new PublicDef();
            //DBconn.ReadIni();
            //filePath = PublicDef._dumpPath;
            //try
            //{
            //    FileStream fs = File.Open($"{filePath}{DateTime.Now.ToString("yyyyMMdd_HHmmss_fff")}_MsgID_{GetMsgID(data)}.blob", FileMode.Create);
            //    fs.Write(data, 0, data.Length);
            //    fs.Close();
            //}
            //catch
            //{
            //    throw;
            //}
        }
        /// <summary>
        /// 取得電文的Msg ID
        /// </summary>
        /// <param name="data">電文資料</param>
        /// <returns></returns>
        public static string GetMsgID(byte[] data)
        {
            string strResult = "";
            byte[] tmp = { 0x00, 0x00 };

            if (data.Length >= 4)
            {
                Buffer.BlockCopy(data, 2, tmp, 0, 2);
                Array.Reverse(tmp);
                strResult = BitConverter.ToInt16(tmp, 0).ToString("000");
            }

            return strResult;
        }

        /// <summary>
        ///     Dump information of byte[]
        /// </summary>
        /// <param name="bytes"> Input byte[] </param>
        public static string DumpByteInfo(byte[] bytes)
        {
            string tmpHexString = "";
            string tmpAsciiString = "";
            string retString = Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine;

            for (int idx = 0; idx < bytes.Length; idx++)
            {
                string tmpStr = bytes[idx].ToString("X");

                if (tmpStr.Length == 1) tmpStr = "0" + tmpStr;

                tmpHexString += " " + tmpStr;

                if (bytes[idx] < 20)
                {
                    tmpAsciiString += ".";
                }
                else
                {
                    tmpAsciiString += Encoding.ASCII.GetString(bytes, idx, 1);
                }

                if (idx % 16 == 15)
                {
                    retString += tmpHexString + " " + tmpAsciiString + Environment.NewLine;
                    tmpHexString = "";
                    tmpAsciiString = "";
                }
            }

            if ((bytes.Length - 1) % 16 != 15)
            {
                for (int idx = 0; idx < 15 - ((bytes.Length - 1) % 16); idx++)
                {
                    tmpHexString += "   ";
                    tmpAsciiString += " ";
                }

                retString += tmpHexString + " " + tmpAsciiString + Environment.NewLine;
            }
            retString += "-----------------------------------------------------------------" + Environment.NewLine;
            return retString;
        }
    }
}
