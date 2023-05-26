using System;
using System.Runtime.InteropServices;

namespace FuXinTLL.Telegram.BCScaner
{
    public class L2ToBCScn_Structure
    {
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class L2BCScn_ScnResult_SB01
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageId = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageLength = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] MessageDateTime = new char[14];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public char[] Result = new char[1];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] Coil_ID = new char[14];
        }
    }
}
