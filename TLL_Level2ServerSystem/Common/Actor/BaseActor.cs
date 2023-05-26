using Akka.Actor;
using Common.MSMQ;
using L2;
using System;

namespace Common.Actor
{
    public class BaseActor : ReceiveActor
    {
        protected LogMgrProcess LogMgr = new LogMgrProcess();
        public BaseActor()
        {
            LogMgr.SetSrc(GetType().FullName);
        }
    }
    public class LogMgrProcess
    {
        private string Source;
        public void SetSrc(string src)
        {
            Source = src;
        }

        public void Alarm(string title, string content)
        {
            var log = new EventLog()
            {
                EventType = EventLog.Type.Alarm,
                Source = Source,
                Command = title,
                MessageDesc = content,
                LogTime = DateTime.Now
            };
            MQTool.SendToLog("", log);
        }

        public void Error(string title, string content)
        {
            var log = new EventLog()
            {
                EventType = EventLog.Type.Error,
                Source = Source,
                Command = title,
                MessageDesc = content,
                LogTime = DateTime.Now
            };
            MQTool.SendToLog("", log);
        }

        public void Info(string title, string content)
        {
            var log = new EventLog()
            {
                EventType = EventLog.Type.Info,
                Source = Source,
                Command = title,
                MessageDesc = content,
                LogTime = DateTime.Now
            };
            MQTool.SendToLog("", log);
        }

        public void Debug(string title, string content)
        {
            var log = new EventLog()
            {
                EventType = EventLog.Type.Debug,
                Source = Source,
                Command = title,
                MessageDesc = content,
                LogTime = DateTime.Now
            };
            MQTool.SendToLog("", log);
        }
    }
}
