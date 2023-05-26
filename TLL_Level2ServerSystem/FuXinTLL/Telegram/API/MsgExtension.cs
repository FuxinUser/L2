namespace FuXinTLL.Telegram
{
    public static class MsgExtension
    {
        //todo 報文補滿用
        public static char[] ToChars(this string str, int? len = null)
        {
            if (len != null)
            {
                if (str.Length > len)
                {
                    return str.Substring(0, len.Value).ToCharArray();
                }
                else
                {
                    return str.PadRight(len.Value).ToCharArray();
                }
            }
            else
            {
                return str.ToCharArray();
            }
        }
    }
}