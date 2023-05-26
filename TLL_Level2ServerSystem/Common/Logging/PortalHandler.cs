using Common;

namespace L2
{
    public class PortalHandler
    {

        public LogHandler Logger = new LogHandler();
        public ExLogHandler Exlog = null;
        public DBHandler DbHand = null;

        public PortalHandler()
        {
            Exlog = new ExLogHandler(Logger);
            DbHand = new DBHandler(Logger);
        }

        public PortalHandler(Akka.Event.ILoggingAdapter log)
        {
            Exlog = new ExLogHandler(Logger);
            DbHand = new DBHandler(Logger);

            Logger._debug = log.Debug;
            Logger._error = log.Error;
            Logger._info = log.Info;
            Logger._warning = log.Warning;

            Logger.Debug("actor system name：" + PublicSystem.ActSystem.Name);
            Logger.Debug("db conn string：" + PublicSystem.ConnectDBStr);
        }
    }
}
