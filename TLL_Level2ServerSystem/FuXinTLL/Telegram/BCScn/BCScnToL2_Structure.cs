using System;
using System.Runtime.InteropServices;

namespace FuXinTLL.Telegram.BCScaner
{
    public class BCScnToL2_Structure
    {
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class BCScnL2_InsertCoil_BS01
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageId = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageLength = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] MessageDateTime = new char[14];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] Coil_ID = new char[14];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public char[] Coil_Pos = new char[1];
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class BCScnL2_BCScnClose_BS02
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageId = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] MessageLength = new char[4];

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] MessageDateTime = new char[14];

        }
    }
}
