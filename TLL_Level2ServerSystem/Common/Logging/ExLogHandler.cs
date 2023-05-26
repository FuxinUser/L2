using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics; // for Stopwatch

namespace L2
{
    public class ExLogHandler
    {

        private readonly LogHandler _logger = new LogHandler();
        private readonly Dictionary<string, Stopwatch> _funcRunTime = new Dictionary<string, Stopwatch>();

        public ExLogHandler(LogHandler log)
        {
            _logger = log;
        }

        /*
         * LogAtFunctionStart and LogAtFunctionEnd are
         * paired functions used at function start and function end 
         * giving logging information and performace data
         */
        public void LogAtFunctionStart(string funcName)
        {
            _logger.Debug($"{funcName} function start....");
            _funcRunTime[funcName] = new Stopwatch();
            _funcRunTime[funcName].Start();
        }
        public void LogAtFunctionEnd(string funcName)
        {
            _funcRunTime[funcName].Stop();
            _logger.Debug($"{funcName} function ends.....  in {_funcRunTime[funcName].Elapsed.TotalMilliseconds * 1000:n3} us");
            _funcRunTime.Remove(funcName);
        }

        public void LogMessage<msg>(msg message)
        {
            try
            {
                string msgString = Newtonsoft.Json.JsonConvert.SerializeObject(message);
                _logger.Debug("message = " + msgString);
            }
            catch
            {
                _logger.Debug("message cannot be converted by NewtonsoftJson. message type:" + message.GetType().Name);
            }
        }

        #region "Log class data in different levels"
        public void DebugData<myClass>(myClass data)
        {
            string logString = GetLogString<myClass>(data);
            _logger.Debug(logString);
        }
        public void ErrorData<myClass>(myClass data)
        {
            string logString = GetLogString<myClass>(data);
            _logger.Error(logString);
        }
        public void InfoData<myClass>(myClass data)
        {
            string logString = GetLogString<myClass>(data);
            _logger.Info(logString);
        }
        public void WarningData<myClass>(myClass data)
        {
            string logString = GetLogString<myClass>(data);
            _logger.Warning(logString);
        }
        private string GetLogString<myClass>(myClass data)
        {
            string retString = "LogForDataType:" + data.GetType().Name + Environment.NewLine;

            try
            {
                retString += Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch
            {
                retString = "message cannot be converted by NewtonsoftJson. message type:" + data.GetType().Name;
            }

            return retString;
        }
        #endregion
    }
}
