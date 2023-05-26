using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public static class Extension_String
    {
        public static string TrimAscode00(char[] value)
        {
            return new string(value).Trim('\0').Trim();
        }


        public static byte[] FixStrBytes(this string str, int len)
        {
            var orign = Encoding.UTF8.GetBytes(str).ToList();
            if (orign.Count < len)
            {
                for (int i = orign.Count; i < len; i++)
                {
                    orign.Add(32);
                }
                return orign.ToArray();
            }
            else
            {
                return orign.GetRange(0, len).ToArray();
            }
        }

        public static string ToStr(this char[] c)
        {
            return new string(c).Trim();
        }
    }
}
