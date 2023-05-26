namespace Common
{
    public class LogHandler
    {
        public delegate void DelDebug(string format, params object[] args);
        public delegate void DelError(string format, params object[] args);
        public delegate void DelInfo(string format, params object[] args);
        public delegate void DelWarning(string format, params object[] args);

        public DelDebug _debug = null;
        public DelError _error = null;
        public DelInfo _info = null;
        public DelWarning _warning = null;


        public void Debug(string format, params object[] args)
        {
            _debug?.Invoke(format, args);
        }
        public void Error(string format, params object[] args)
        {
            _error?.Invoke(format, args);
        }
        public void Info(string format, params object[] args)
        {
            _info?.Invoke(format, args);
        }
        public void Warning(string format, params object[] args)
        {
            _warning?.Invoke(format, args);
        }
    }
}
