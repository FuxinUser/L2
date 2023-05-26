using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public static class MsgAnalUtil
    {
        /// <summary>
        /// 備份電文原始資料到檔案
        /// </summary>
        /// <param name="data"></param>
        public static void DumpDataToFile(this byte[] data, String filePath, string msgID, bool isReverse = false)
        {
            try
            {
                var fileName = $"{filePath}\\{DateTime.Now.ToString("yyyyMMdd_HHmmss_fff")}_MsgID_{msgID}.blob";
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(data);
                bw.Flush();
                bw.Close();
                fs.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 取得電文的Msg ID
        /// </summary>
        /// <param name="data">電文資料</param>
        /// <returns></returns>
        public static string GetMMSMsgID(this byte[] data)
        {
            string strResult = "";
            byte[] tmp = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            if (data.Length >= 29)
            {
                Buffer.BlockCopy(data, 4, tmp, 0, 6);
                strResult = Encoding.UTF8.GetString(tmp).Trim();
            }

            return strResult;
        }

    }
}
