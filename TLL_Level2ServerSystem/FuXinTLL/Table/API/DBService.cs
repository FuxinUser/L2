using L2;


namespace FuXinTLL.Table
{
    public class DBService
    {
        /// <summary>系統業務</summary>
        public static SysAPI SysAPI;
        /// <summary>報文收發記錄業務</summary>
        public static CommRecAPI CommRecAPI;
        /// <summary>資料收集業務</summary>
        public static DtGtrAPI DtGtrAPI;
        /// <summary>鋼捲生產業務</summary>
        public static CoilAPI CoilAPI;
        /// <summary>鋼捲追蹤業務</summary>
        public static TrkAPI TrkAPI;
        /// <summary>L25業務</summary>
        public static L25API L25API;

        public static void Init(DBHandler p)
        {
            SysAPI = new SysAPI(p);
            CommRecAPI = new CommRecAPI(p);
            DtGtrAPI = new DtGtrAPI(p);
            CoilAPI = new CoilAPI(p);
            TrkAPI = new TrkAPI(p);
            L25API = new L25API(new DBL25Handler(new Common.LogHandler()));
        }
    }
}
