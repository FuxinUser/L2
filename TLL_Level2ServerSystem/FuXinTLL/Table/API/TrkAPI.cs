using L2;
using Models;
using System;
using System.Collections.Generic;
/**
 Author:ICSC 鄭天智
 Date:2020/1/1
 Desc:鋼捲追蹤業務
**/
namespace FuXinTLL.Table
{
    public class TrkAPI
    {
        private static DBHandler dbHand;
        public TrkAPI(DBHandler p)
        {
            dbHand = p;
        }

        public List<TBL_TrackMap> Query_TrkMap()
        {
            var ans = dbHand.QueryAll<TBL_TrackMap>();
            return ans;
        }


        //20210825
        public TBL_L2SystemSetting Query_L2SystemSetting(string functionName)
        {
            string sqlstr = $"Select Top 1 * from {nameof(TBL_L2SystemSetting)} where {nameof(TBL_L2SystemSetting.FuntionName)} = '{functionName}'";
            var ans = dbHand.QueryFirst<TBL_L2SystemSetting>(sqlstr);
            return ans;
        }

        //查詢線上鋼捲
        public List<TBL_OnlineCoil> Query_OnlineCoil()
        {
            string sqlstr = $"Select * from {nameof(TBL_OnlineCoil)}";
            var ans = dbHand.QueryList<TBL_OnlineCoil>(sqlstr);
            return ans;
        }
        //修改 onlineCoil 資料
        public bool Update_OnlineCoil(TBL_OnlineCoil tBL_OnlineCoil)
        {
            //string sqlstr = $"Select * from {nameof(TBL_OnlineCoil)}";
            return dbHand.UpdateOnly(tBL_OnlineCoil);
        }

        public TBL_TrackMap Query_TrkMap(int skid)
        {
            string pos = "";
            try
            {
                pos = Enum.GetName(typeof(TrkMapPos), skid);
            }
            catch (Exception) { }
            string sqlstr = $"SELECT TOP 1 {nameof(TBL_TrackMap.CoilID)} FROM {nameof(TBL_TrackMap)} WHERE {nameof(TBL_TrackMap.Position)}='{pos}'";
            return dbHand.QueryFirst<TBL_TrackMap>(sqlstr);
        }

        public bool Update_TrkMap(string coildId, int posID)
        {
            string pos = Enum.GetName(typeof(TrkMapPos), posID);
            if (pos == null) return false;
            var trkMap = new TBL_TrackMap()
            {
                UpdateTime = DateTime.Now,
                CoilID = coildId,
                Position = pos
            };
            return dbHand.UpdateOnly(trkMap);
        }

        public void Update_TrkMap(string coildId, string pos)
        {
            var trkMap = new TBL_TrackMap()
            {
                UpdateTime = DateTime.Now,
                CoilID = coildId,
                Position = pos
            };
            dbHand.UpdateOnly(trkMap);
        }


        public void Update_TrkLine(string[] line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                var trkMap = new TBL_TrackMap()
                {
                    CoilID = line[i],
                    Position = $"line{(i + 1)}",
                    UpdateTime = DateTime.Now
                };
                dbHand.InsertOrUpdate(trkMap);
            }
        }
    }
}
