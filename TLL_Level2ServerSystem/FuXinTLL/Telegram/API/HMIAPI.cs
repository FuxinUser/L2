using FuXinTLL.Telegram.HMI;
using System;

namespace FuXinTLL.Telegram.API
{
    public class HMIAPI
    {
        public HMI_ServerToClient_Structure.CommandDone Create_CommandSuccess(string msgID, string msg)
        {
            return new HMI_ServerToClient_Structure.CommandDone()
            {
                MessageID = msgID,
                Message = msg,
                isSuccess = true
            };
        }

        public HMI_ServerToClient_Structure.CommandDone Create_CommandFail(string msgID, string msg)
        {
            return new HMI_ServerToClient_Structure.CommandDone()
            {
                MessageID = msgID,
                Message = msg,
                isSuccess = false
            };
        }


    }
}
