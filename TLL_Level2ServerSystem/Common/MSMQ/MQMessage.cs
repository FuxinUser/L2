using System;

namespace Common.MSMQ
{
    [Serializable]
    public class MQMessage
    {
        /// <summary>識別碼</summary>
        public string ID;
        /// <summary>資料</summary>
        public object Data;
    }
}