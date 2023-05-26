using Newtonsoft.Json;
using System;
using System.Text;

namespace L2
{
    public class TextTool
    {
        public string DumpByteInfo(byte[] bytes)
        {
            string tmpHexString = "";
            string tmpAsciiString = "";
            string retString = Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine;

            for (int idx = 0; idx < bytes.Length; idx++)
            {
                string tmpStr = bytes[idx].ToString("X");

                if (tmpStr.Length == 1) tmpStr = "0" + tmpStr;

                tmpHexString += " " + tmpStr;

                if (bytes[idx] < 20)
                {
                    tmpAsciiString += ".";
                }
                else
                {
                    tmpAsciiString += Encoding.ASCII.GetString(bytes, idx, 1);
                }

                if (idx % 16 == 15)
                {
                    retString += tmpHexString + " " + tmpAsciiString + Environment.NewLine;
                    tmpHexString = "";
                    tmpAsciiString = "";
                }
            }

            if ((bytes.Length - 1) % 16 != 15)
            {
                for (int idx = 0; idx < 15 - ((bytes.Length - 1) % 16); idx++)
                {
                    tmpHexString += "   ";
                    tmpAsciiString += " ";
                }

                retString += tmpHexString + " " + tmpAsciiString + Environment.NewLine;
            }
            retString += "-----------------------------------------------------------------" + Environment.NewLine;
            return retString;
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ToJson(object obj, bool formatting = false)
        {
            if (formatting)
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            else
                return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public string GetFixedString(string str, int fixedLen, string padWord = " ")
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

        public string RandStr(int strLength)
        {
            string s = "23456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < strLength; i++)
            {
                int r = rand.Next(0, s.Length);
                sb.Append(s[r]);
            }
            return sb.ToString();
        }

        public char[] RandChar(int length)
        {
            return RandStr(length).ToCharArray();
        }

        public string SerialStr(int len)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(i % 10);
            }
            return sb.ToString();
        }

        public char[] SerialChar(int len)
        {
            return SerialStr(len).ToCharArray();
        }

        public int SerialInt(int len)
        {
            return Convert.ToInt32(SerialStr(len));
        }

        public int RandInt()
        {
            return RandInt(int.MaxValue);
        }

        public int RandInt(int max)
        {
            Random rand = new Random();
            return rand.Next(max);
        }

        public float RandFloat()
        {
            int i = RandInt();
            if (i % 2 == 0) i += 1;
            return (float)Math.Pow(i, 0.5);
        }

        public string RandFloatStr(int len, int dotIndex)
        {
            string nums = "0123456789";
            Random rand = new Random();
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < len - 1; i++)
            {
                int n = rand.Next(0, 10);
                ans.Append(nums[n]);
            }
            ans.Insert(len - dotIndex - 1, '.');
            return ans.ToString();
        }
    }
}
