using System;
using System.Collections.Generic;
using Akka.Actor;
using Common.Forms;

namespace L2
{
    public class PublicSystem
    {
        // Save the created of logs
        private static Dictionary<string, Akka.Event.ILoggingAdapter> _dicLogs = new Dictionary<string, Akka.Event.ILoggingAdapter>();
        // Save the created of actor
        private static Dictionary<string, IActorRef> _dicCtrls = new Dictionary<string, IActorRef>();
        // Record the ActorSystem for this main program
        public static ActorSystem ActSystem;
        // Connection string for handlers to access database
        public static string ConnectDBStr = string.Empty;

        //L2.5 資料庫 連接字串
        public static string ConnectL25DBStr = string.Empty;

        //UI界面
        //public static IServerUI ServerUI { private set; get; }
        public static IServerUI ServerUI { private set; get; }

        //每日排程
        public static QuartzHelper QuartzSchedule = new QuartzHelper();

        //資料測試工具
        public static TextTool TextTool = new TextTool();

        #region "Private"
        /// <summary>
        /// Set dictionary
        /// </summary>
        /// <typeparam name="T">Input tyoe</typeparam>
        /// <param name="dic">Dictionary to be set</param>
        /// <param name="key">Keyword</param>
        /// <param name="tVal">Value</param>
        /// <returns></returns>
        private static bool SetDic<T>(ref Dictionary<string, T> dic, string key, T tVal)
        {
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, tVal);

                return true;
            }
            else return false;
        }

        /// <summary>
        /// Set log of the dictionary
        /// </summary>
        /// <param name="key">Keyword</param>
        /// <param name="log">Builded log</param>
        /// <returns></returns>
        private static bool SetDicLogs(string key, Akka.Event.ILoggingAdapter log)
        {
            return SetDic(ref _dicLogs, key, log);
        }
        /// <summary>
        /// Get log by key of the dictionary
        /// </summary>
        /// <param name="key">Keyword</param>
        /// <returns></returns>
        private static Akka.Event.ILoggingAdapter GetDicLogs(string key)
        {
            return _dicLogs[key];
        }

        /// <summary>
        /// Set actor of the dictionary
        /// </summary>
        /// <param name="key">Keyword</param>
        /// <param name="ctrl">Builded actor</param>
        /// <returns></returns>
        private static bool SetDicCtrls(string key, IActorRef ctrl)
        {
            return SetDic(ref _dicCtrls, key, ctrl);
        }

        /// <summary>
        /// Create new ActorSystem
        /// </summary>
        /// <param name="sysName">The name of this ActorSystem</param>
        private static void CreateSystem(string sysName)
        {
            if (ActSystem == null)
            {
                ActSystem = ActorSystem.Create(sysName);
            }
        }

        /// <summary>
        /// Set the ConnectionString for this main program
        /// </summary>
        /// <param name="strConn"></param>
        private static void SetConnectionString(string strConn)
        {
            ConnectDBStr = strConn;
        }

        #endregion

        /// <summary>First Init</summary>
        /// <param name="sysName">Actor System</param>
        /// <param name="connStr">Db Connnection string</param>
        /// <param name="serverUI">Front Side UI</param>
        public static void Init(string sysName, string connStr, IServerUI serverUI)
        {
            CreateSystem(sysName);
            SetConnectionString(connStr);
            ServerUI = serverUI;

            // Initialize akka logging
            Akka.Event.ILoggingAdapter akkaLog = Akka.Event.Logging.GetLogger(ActSystem, "AkkaLog");
            akkaLog.Info("AkkaLog start.....");
        }

        /// <summary>Get actor by key of the dictionary</summary>
        /// <param name="key">Actor Name</param>
        public static IActorRef GetDicCtrls(string key)
        {
            return _dicCtrls[key];
        }

        /// <summary>Create a Actor and save into dictionary</summary>
        public static void CreateActor<T>() where T : ActorBase
        {
            // Get actor name from class name
            string actName = typeof(T).Name;

            // Create logging in ActorSystem
            SetDicLogs(actName, Akka.Event.Logging.GetLogger(ActSystem, actName + "Log"));
            GetDicLogs(actName).Info($"{actName}Logs start.....");

            // Create actor in ActorSystem
            SetDicCtrls(actName, ActSystem.ActorOf(Props.Create(() => (T)Activator.CreateInstance(typeof(T), GetDicLogs(actName))), actName));
        }

        /// <summary>Create a Child Actor and save into dictionary</summary>
        /// <param name="context">Parent Actor's Context</param>
        public static void CreateChild<T>(IUntypedActorContext context) where T : ActorBase
        {
            string actName = typeof(T).Name;        // Get actor name from class name

            SetDicLogs(actName, Akka.Event.Logging.GetLogger(ActSystem, actName + "Log"));
            GetDicLogs(actName).Info($"{actName}Logs start.....");

            // Create actor in ActorSystem
            SetDicCtrls(actName, context.ActorOf(Props.Create(() => (T)Activator.CreateInstance(typeof(T), GetDicLogs(actName))), actName));
        }

        /// <summary>Create a Child Actor For Communication</summary>
        /// <param name="context">Parent Actor's Context</param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void CreateCommChild<T>(IUntypedActorContext context, string ip, int port) where T : ActorBase
        {
            string actName = typeof(T).Name;        // Get actor name from class name

            SetDicLogs(actName, Akka.Event.Logging.GetLogger(ActSystem, actName + "Log"));
            GetDicLogs(actName).Info($"{actName}Logs start.....");

            // Create actor in ActorSystem
            SetDicCtrls(actName, context.ActorOf(Props.Create(() => (T)Activator.CreateInstance(typeof(T), GetDicLogs(actName), ip, port)), actName));
        }
    }
}