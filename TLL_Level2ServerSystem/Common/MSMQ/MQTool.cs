using System;
using System.Collections.Concurrent;

namespace Common.MSMQ
{
    public static partial class MQTool
    {
        private static readonly ConcurrentDictionary<string, MQHelper> _container = new ConcurrentDictionary<string, MQHelper>();

        /// <summary>取得MQHelper，可藉由此MQHelper控制系統上的MQ，若指定的MQ不存在會在系統建立</summary>
        /// <param name="key">Queue名稱，可忽略大小寫</param>
        /// <returns></returns>
        public static MQHelper GetMQ(string key)
        {
            string lowerKey = key.ToLower();
            if (!_container.ContainsKey(lowerKey))
            {
                _container[lowerKey] = new MQHelper(lowerKey);
            }
            return _container[lowerKey];
        }

        [Serializable]
        public class Message
        {
            /// <summary>識別碼</summary>
            public string ID;
            /// <summary>資料</summary>
            public object Data;
        }

        [Serializable]
        public class HMIMessage
        {
            /// <summary>識別碼</summary>
            public string ID;
            /// <summary>資料</summary>
            public string BroadcastType;
            /// <summary>資料</summary>
            public object Data;
        }

        [Serializable]
        public class MessageL25PDO
        {
            /// <summary>識別碼</summary>
            public string ID;
            /// <summary>資料</summary>
            public object Data;
            /// <summary>序號</summary>
            public int SerNo;
        }

        #region 內部系統
        public enum BroadcastType
        {
            onlyone, allclinet
        }
        public static void SendToLpr(string id, object msg)
        {
            GetMQ(MQPorts.LprPort).Send(id, msg);
        }

        public static void SendToHMI(string id, BroadcastType type, object msg)
        {
            GetMQ(MQPorts.ClientCoordPort).Send(id, type, msg);
        }

        public static void SendToStp(string id, object msg)
        {
            GetMQ(MQPorts.StpPort).Send(id, msg);
        }

        public static void SendToTrk(string id, object msg)
        {
            GetMQ(MQPorts.TrkPort).Send(id, msg);
        }

        public static void SendToCoil(string id, object msg)
        {
            GetMQ(MQPorts.CoilPort).Send(id, msg);
        }

        public static void SendToGtr(string id, object msg)
        {
            GetMQ(MQPorts.GtrPort).Send(id, msg);
        }

        public static void SendToLog(string id, object msg)
        {
            GetMQ(MQPorts.LogPort).Send(id, msg);
        }
        #endregion

        #region 對外部通訊接口
        public static void SendToL1(string id, object msg)
        {
            GetMQ(MQPorts.L1Port).Send(id, msg);
        }

        public static void SendToWMS(string id, object msg)
        {
            GetMQ(MQPorts.WMsPort).Send(id, msg);
        }

        public static void SendToMMS(string id, object msg)
        {
            GetMQ(MQPorts.MMsPort).Send(id, msg);
        }

        public static void SendToL25(string id, object msg)
        {
            GetMQ(MQPorts.L25Port).Send(id, msg);
        }

        public static void SendToL25PDO(string id, int serNo, object msg)
        {
            GetMQ(MQPorts.L25Port).SendL25PDO(id, serNo, msg);
        }

        #endregion
    }
}
