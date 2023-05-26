using L2;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuXinTLL.Table
{
    public class SysAPI
    {
        private static DBHandler dbHand;
        public SysAPI(DBHandler p)
        {
            dbHand = p;
        }

        public string Query_AutoFeeding()
        {
            string sql = $"SELECT {nameof(TBL_L2SystemSetting.Value)} FROM {nameof(TBL_L2SystemSetting)}";
            return dbHand.QueryFirst<TBL_L2SystemSetting>(sql)?.Value;
        }

        public void Update_AutoFeeding(bool flag)
        {
            bool isok = dbHand.UpdateOnly(new TBL_L2SystemSetting()
            {
                FuntionName = "AutoFeeding",
                Value = flag.ToString()
            });
        }

        /// <summary>
        /// 查詢班表
        /// </summary>
        /// <returns></returns>
        public TBL_ClassData Query_ShiftTable(DateTime now)
        {
            string sql = $"Select * From {nameof(TBL_ClassData)} Where {nameof(TBL_ClassData.Date)} = '{now.ToString("yyyy-MM-dd")}' And {nameof(TBL_ClassData.ShiftStartTime)} !='' And {nameof(TBL_ClassData.ShiftEndTime)} !=''";
            var ls = dbHand.QueryList<TBL_ClassData>(sql);
            if (ls != null)
            {
                var ans = ls.Where(x => int.Parse(x.ShiftStartTime) <= int.Parse(now.ToString("HHmm")) && int.Parse(x.ShiftEndTime) > int.Parse(now.ToString("HHmm")));
                return ans.FirstOrDefault();
            }

            return null;
        }

        /// <summary>更新Server連線狀態</summary>
        public bool Update_ConnectStatus(string ip, int port, ConectDirection from, ConectDirection to, bool isOk)
        {
            var connStatus = dbHand.QueryFirst<TBL_ConnectionStatus>($"Select Top 1 * From {nameof(TBL_ConnectionStatus)} Where {nameof(TBL_ConnectionStatus.ConnectionFrom)} = '{from}' and {nameof(TBL_ConnectionStatus.ConnectionTo)} = '{to}'");
            connStatus.CreateDateTime = DateTime.Now;
            connStatus.ConnectionIP = ip;
            connStatus.ConnectionPort = port.ToString();
            connStatus.ConnectionStatus = (isOk ? "1" : "0");
            bool isSuccess = dbHand.UpdateOnly(connStatus);
            return isSuccess;
        }
        /// <summary>
        /// 查詢連線狀態
        /// </summary>
        public List<TBL_ConnectionStatus> Query_ConnectStatus()
        {
            string sql = $"Select * From {nameof(TBL_ConnectionStatus)}";
            var ls = dbHand.QueryList<TBL_ConnectionStatus>(sql);
            if (ls != null)
            {
                return ls;
            }
            return null;
        }

    }
}