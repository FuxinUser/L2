using System;

namespace FuXinTLL
{
    public class Formatter
    {
        public static string GetFixedString(string str, int fixedLen, string padWord = " ")
        {
            if (fixedLen == str.Length)
            {
                return str;
            }
            else if (fixedLen < str.Length)
            {
                return str.Substring(0, fixedLen);
            }
            else
            {
                if (string.IsNullOrEmpty(padWord)) padWord = " ";

                while (str.Length < fixedLen) str += padWord;

                return str.Substring(0, fixedLen);
            }
        }
        public static char[] GetFixedChar(char[] str, int fixedLen, char padWord = ' ')
        {
            char[] rtn = new char[fixedLen];
            int i;
            for (i = 0; i < fixedLen && i < str.Length; i++)
            {
                rtn[i] = str[i];
            }
            for (int k = i; k < fixedLen; k++)
            {
                rtn[k] = padWord;
            }
            return rtn;
        }
        public static char[] GetFixedChar(string str, int fixedLen, char padWord = ' ')
        {
            if (str == null) str = "";
            return GetFixedChar(str.ToCharArray(), fixedLen, padWord);
        }

        public static char[] GetFixedCharL1A24Format(string value)
        {
            //string Tvalue = string.Empty;
            if (value == null)  value = "";
            return value.PadRight(20, ' ').PadRight(24, '\0').ToCharArray();
        }




        public static int ParseToInt(char[] chars)
        {
            string str = new string(chars);

            if (int.TryParse(str, out int ans))
            {
                return ans;
            }
            else
            {
                return 0;
            }
        }

        public static float ParseToFloat(char[] chars, int decimalPlace)
        {
            string str = new string(chars);
            if (float.TryParse(str, out float ans))
            {
                ans = ans / (float)Math.Pow(10, decimalPlace);
                return ans;
            }
            else
            {
                return 0;
            }
        }
    }
}
