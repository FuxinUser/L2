using System;

namespace L2
{
    /// <summary>
    /// CommonMessage這個Class的功用有兩個
    /// 1.Server內部Actor Send給[SndEdit]的Message的通用格式
    /// 2.[RcvEdit] Send給Server內部Actor的Message的通用格式
    /// 其具有不可變特性
    /// </summary>
    [Serializable]
    public class CommMessage
    {
        public int MessageLength { set; get; }
        public string MessageID { set; get; }
        public byte[] RawData { set; get; }
    }
}
