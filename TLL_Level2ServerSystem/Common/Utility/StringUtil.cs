using System.Text;

namespace Common.Utility
{
    public static class StringUtil
    {

        public static string ToStr(this byte[] data)
        {
            // EnCode UTF8
            return Encoding.UTF8.GetString(data).Trim();
        }

        public static byte[] ToCByteArray(this string data, int size)
        {
            return Encoding.UTF8.GetBytes(data.PadRight(size, ' '));
        }
    }
}