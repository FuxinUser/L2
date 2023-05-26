using System;

namespace L2
{
    [Serializable]
    public class EventLog
    {
        public enum Type
        {
            Error = 1, Alarm = 2, Info = 3, Debug = 4
        }
        /// <summary>來源</summary>
        public string Source;
        /// <summary>事件類型</summary>
        public Type EventType;
        /// <summary>訊息描述</summary>
        public string MessageDesc;
        /// <summary>命令描述</summary>
        public string Command;
        /// <summary>Log時間</summary>
        public DateTime LogTime = DateTime.Now;
    }
}
