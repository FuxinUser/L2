using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public class PublicDef
    {
        public static string _iniPath = string.Empty;
        public static string _connDBString = string.Empty;
        public static string _connL25DBString = string.Empty;
        public static string _line = string.Empty;
        public static string _dumpPath = string.Empty;

        public static string _l1RemoteIP = string.Empty;
        public static string _l1RemotePort = string.Empty;

        public static string _mmsLocalIP = string.Empty;
        public static string _mmsLocalPort = string.Empty;
        public static string _mmsRemoteIP = string.Empty;
        public static string _mmsRemotePort = string.Empty;

        public static string _wmsLocalIP = string.Empty;
        public static string _wmsLocalPort = string.Empty;
        public static string _wmsRemoteIP = string.Empty;
        public static string _wmsRemotePort = string.Empty;

        public static string _bcLocalIP = string.Empty;
        public static string _bcLocalPort = string.Empty;

        public static string _lprRemoteIP = string.Empty;
        public static string _lprRemotePort = string.Empty;

        public static string _lprRemoteSampleCutIP = string.Empty;
        public static string _lprRemoteSampleCuytPort = string.Empty;

        /// <summary>
        /// Read SystemConfig get setting parameters
        /// </summary>
        public void ReadIni()
        {
            DeserializeIniData();
            IniDef iniDef = new IniDef(_iniPath);

            if (iniDef.IsExists)
            {
                _connL25DBString = iniDef.ReadIni("Sql", "L25ConnectionString");
                _connDBString = iniDef.ReadIni("Sql", "L2ConnectionString");
                _line = iniDef.ReadIni("Line", "Line");
                _dumpPath = iniDef.ReadIni("Dump", "Path");

                _l1RemoteIP = iniDef.ReadIni("L1", "RemoteIP");
                _l1RemotePort = iniDef.ReadIni("L1", "RemotePort");

                _mmsLocalIP = iniDef.ReadIni("MMS", "LocalIP");
                _mmsLocalPort = iniDef.ReadIni("MMS", "LocalPort");
                _mmsRemoteIP = iniDef.ReadIni("MMS", "RemoteIP");
                _mmsRemotePort = iniDef.ReadIni("MMS", "RemotePort");


                _wmsLocalIP = iniDef.ReadIni("WMS", "LocalIP");
                _wmsLocalPort = iniDef.ReadIni("WMS", "LocalPort");
                _wmsRemoteIP = iniDef.ReadIni("WMS", "RemoteIP");
                _wmsRemotePort = iniDef.ReadIni("WMS", "RemotePort");

                _bcLocalIP = iniDef.ReadIni("BC", "LocalIP");
                _bcLocalPort = iniDef.ReadIni("BC", "LocalPort");

                _lprRemoteIP = iniDef.ReadIni("LPR", "RemoteIP");
                _lprRemotePort = iniDef.ReadIni("LPR", "RemotePort");

                _lprRemoteSampleCutIP = iniDef.ReadIni("LPR", "RemoteSampleCutIP");
                _lprRemoteSampleCuytPort = iniDef.ReadIni("LPR", "RemoteSampleCutPort");
            }
        }

        private void DeserializeIniData()
        {
            var processPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathArray = processPath.Split('\\');
            var iniPath = new Func<string>(() =>
            {
                var sb = new StringBuilder();
                for (int i = 0; i < pathArray.Length - 4; i++)
                {
                    sb.Append($"{pathArray[i]}\\");
                    if (pathArray[i] == "TLL_Level2ServerSystem")
                    {
                        break;
                    }
                }
                return $"{sb}SystemConfig.ini";
            })();
            _iniPath = iniPath;
        }
    }

    public class IniDef
    {
        public enum States
        {
            Finished,
            FileExists
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public bool IsExists { get; private set; } = false;
        public string FilePath { get; private set; } = string.Empty;
        public IniDef(string filePath)
        {
            this.FilePath = filePath;

            CheckFileExists();
        }
        private void CheckFileExists()
        {
            IsExists = File.Exists(FilePath);
        }
        public States CreateFile()
        {
            if (!IsExists)
            {
                File.Create(FilePath);

                return States.Finished;
            }
            else return States.FileExists;
        }
        public void WriteIni(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, FilePath);
        }
        public string ReadIni(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, FilePath);
            return temp.ToString();
        }
    }
}
