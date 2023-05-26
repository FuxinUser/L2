using System;
using System.Messaging;
using static Common.MSMQ.MQTool;

namespace Common.MSMQ
{
    public class MQHelper
    {
        private MessageQueue _msQueue;
        private Action<object> _rcvHand;
        private readonly string _mqPath;
        private static object _safeLock = new object();

        public MQHelper(string name)
        {
            _mqPath = @".\Private$\" + name.ToLower();
            Create(_mqPath);
            _msQueue = new MessageQueue(_mqPath)
            {
                Formatter = new BinaryMessageFormatter()
            };
        }

        public void Create(string name)
        {
            if (!MessageQueue.Exists(name))
            {
                _msQueue = MessageQueue.Create(name);
            }
        }

        public void Receive(Action<object> rceiveMessageHandler)
        {
            if (rceiveMessageHandler == null) return;
            if (_rcvHand != null) throw new Exception("重複註冊MQ監聽事件");
            _rcvHand = rceiveMessageHandler;
            _msQueue.ReceiveCompleted += HandleReceiveCompleted;
            _msQueue.BeginReceive();
        }

        private void HandleReceiveCompleted(object source, ReceiveCompletedEventArgs asyncResult)
        {
            lock (_safeLock)
            {
                var message = _msQueue.EndReceive(asyncResult.AsyncResult);
                try
                {
                    _rcvHand(message.Body);
                    _msQueue.BeginReceive();
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            
        }
        /// <summary>
        /// send to MQ hmi
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="message"></param>
        public void Send(string messageID, BroadcastType type, object message)
        {
            HMIMessage box = new HMIMessage()
            {
                ID = messageID,
                Data = message,
                BroadcastType = type.ToString()
            };
            _msQueue.Send(box);
        }
        public void Send(string messageID, object message)
        {
            MQMessage box = new MQMessage()
            {
                ID = messageID,
                Data = message
            };

            _msQueue.Send(box);
            
        }

        public void SendL25PDO(string messageID, int serNo, object message)
        {
            MessageL25PDO box = new MessageL25PDO()
            {
                ID = messageID,
                Data = message,
                SerNo = serNo
            };
            _msQueue.Send(box);
        }

        public virtual long CountData()
        {
            try
            {
                var enumerator = _msQueue.GetMessageEnumerator2();
                var count = 0L;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
            catch
            {
                throw;
            }
        }
    }
}