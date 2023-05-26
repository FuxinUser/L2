using Akka.Actor;
using L2;

namespace Common.Actor
{
    public abstract class LogHandlerActor : ReceiveActor
    {
        public LogHandlerActor()
        {
            Receive<EventLog>(Handle_Logger);
        }

        protected abstract void Handle_Logger(EventLog logMsg);

    }
}
