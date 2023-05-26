using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

namespace Common.Zebra
{
    public class Zebra
    {
        #region "Properties"

        /// <summary>
        /// False = No response
        /// </summary>
        public bool State_Connected
        {
            get
            {
                return _State_Connected;
            }
            private set
            {
                if (_State_Connected != value)
                {
                    _State_Connected = value;
                    StateChange?.Invoke();
                }
            }
        }

        /// <summary>
        /// 缺紙
        /// </summary>
        public bool State_PaperOut
        {
            get
            {
                return _State_PaperOut;
            }
            private set
            {
                if (_State_PaperOut != value)
                {
                    _State_PaperOut = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// 碳帶不足
        /// </summary>
        public bool State_RibbonOut
        {
            get
            {
                return _State_RibbonOut;
            }
            private set
            {
                if (_State_RibbonOut != value)
                {
                    _State_RibbonOut = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// 暫停狀態
        /// </summary>
        public bool State_Pause
        {
            get
            {
                return _State_Pause;
            }
            private set
            {
                if (_State_Pause != value)
                {
                    _State_Pause = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// Printer Errorrrrrrrrrrrrr!!
        /// </summary>
        public bool State_Error
        {
            get
            {
                return _State_Error;
            }
            private set
            {
                if (_State_Error != value)
                {
                    _State_Error = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// Printer Warning!!
        /// </summary>
        public bool State_Warning
        {
            get
            {
                return _State_Warning;
            }
            private set
            {
                if (_State_Warning != value)
                {
                    _State_Warning = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// Error Number
        /// </summary>
        public int State_ErrorNum
        {
            get
            {
                return _State_ErrorNum;
            }
            private set
            {
                if (_State_ErrorNum != value)
                {
                    _State_ErrorNum = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// Warning Number
        /// </summary>
        public int State_WarningNum
        {
            get
            {
                return _State_WarningNum;
            }
            private set
            {
                if (_State_WarningNum != value)
                {
                    _State_WarningNum = value;
                    _State_Change = true;
                }
            }
        }

        /// <summary>
        /// Return Program Error
        /// </summary>
        public int State_SystemNum
        {
            get
            {
                return _State_SystemNum;
            }
            private set
            {
                if (_State_SystemNum != value)
                {
                    _State_SystemNum = value;
                    _State_Change = true;
                }
            }
        }

        private bool _State_Change = false;
        private bool _State_Connected = false;
        private bool _State_PaperOut = false;
        private bool _State_RibbonOut = false;
        private bool _State_Pause = false;
        private bool _State_Error = false;
        private bool _State_Warning = false;
        private int _State_ErrorNum = 0;
        private int _State_WarningNum = 0;
        private int _State_SystemNum = 0;

        #endregion

        public event StateChangeEventHandler StateChange;
        public delegate void StateChangeEventHandler();

        private const int CheckInterval = 5; //sec
        private UdpClient ClientZP = null;
        private IPEndPoint SiteEndPoint = null;
        private DateTime LastCheckDT = new DateTime();
        private Timer timCheckState = null;
        private Timer timCheckConn = null;
        private Timer timInit = null;

        private string PrinterIP = "";
        private int PrinterPort = 0;

        public Zebra(string IP, int Port)
        {
            try
            {
                //Init
                SiteEndPoint = new IPEndPoint(IPAddress.Any, Port);

                // Set Parameter
                this.PrinterIP = IP;
                this.PrinterPort = Port;

                //Init Call
                CheckState();

                // Start Check State
                timCheckState = new Timer(1000 * CheckInterval);
                timCheckState.Elapsed += new ElapsedEventHandler(timCheckState_Tick);
                timCheckState.Enabled = true;

                // Start Check Conn
                timCheckConn = new Timer(1000 * CheckInterval);
                timCheckConn.Elapsed += new ElapsedEventHandler(timCheckConn_Tick);
                timCheckConn.Enabled = true;

                // Only Call First Time
                timInit = new Timer(10);
                timInit.Elapsed += new ElapsedEventHandler(timInit_Tick);
                timInit.Enabled = true;


            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Check Printer State
        /// </summary>
        public void CheckState()
        {
            try
            {
                SendZPL("~HS~HQES");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckState : " + ex.Message);
            }
        }

        /// <summary>
        /// 傳送 ZPL Code
        /// </summary>
        /// <param name="Code"></param>
        public void SendZPL(string Code)
        {
            try
            {
                if (Code.Length < 1) return;

                ClientZP = new UdpClient(PrinterIP, PrinterPort);
                ClientZP.BeginReceive(UDPRecv, null);
                ClientZP.Send(Encoding.UTF8.GetBytes(Code), Encoding.UTF8.GetBytes(Code).Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendZPL : {ex.Message} Code : {Code}");
            }
        }

        /// <summary>
        /// Handle Receive Data
        /// </summary>
        /// <param name="ar"></param>
        private void UDPRecv(IAsyncResult ar)
        {
            try
            {
                if (ar != null)
                {
                    Byte[] recvBytes = ClientZP.EndReceive(ar, ref SiteEndPoint);
                    String recvMsg = Encoding.ASCII.GetString(recvBytes);

                    // Message Handling
                    recvMsg = recvMsg.Replace("\u0002", "").Replace("\u0003", "").Replace(" ", "").Replace("\r\nPRINTERSTATUS", "").Replace("\r\n\r\n", "");
                    recvMsg = Regex.Replace(recvMsg, @"(\r\n)$", "");
                    String pat = @"\,|\r\nERRORS:|\r\nWARNINGS:|\r\n";
                    string[] recvData = Regex.Split(recvMsg, pat);

                    // Set Printer State
                    LastCheckDT = DateTime.Now;
                    if (recvData.Length == 27)
                    {
                        State_Connected = true;
                        State_PaperOut = recvData[1] == "1" ? true : false;
                        State_Pause = recvData[2] == "1" ? true : false;
                        State_RibbonOut = recvData[15] == "1" ? true : false;
                        State_Error = recvData[25].Substring(0, 1) == "1" ? true : false;
                        State_Warning = recvData[26].Substring(0, 1) == "1" ? true : false;
                        State_ErrorNum = int.TryParse(recvData[25].Substring(9, 8), out int eNum) ? eNum : 0;
                        State_WarningNum = int.TryParse(recvData[26].Substring(9, 8), out int wNum) ? wNum : 0;

                        // State Change Event
                        if (_State_Change)
                        {
                            _State_Change = false;
                            StateChange?.Invoke();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("RECV : " + ex.Message);
            }
        }

        /// <summary>
        /// loop check printer state
        /// </summary>
        private void timCheckState_Tick(object sender, ElapsedEventArgs e)
        {
            timCheckState.Stop();
            CheckState();
            timCheckState.Start();
        }

        private void timInit_Tick(object sender, ElapsedEventArgs e)
        {
            timInit.Stop();
            while (StateChange == null)
            {
                System.Threading.Thread.Sleep(5);
            }
            StateChange?.Invoke();
            timInit.Enabled = false;
        }

        /// <summary>
        /// Connection Check
        /// </summary>
        private void timCheckConn_Tick(object sender, ElapsedEventArgs e)
        {
            timCheckConn.Stop();
            TimeSpan UpdateDuration = new TimeSpan(DateTime.Now.Ticks - LastCheckDT.Ticks);
            if (UpdateDuration.TotalSeconds > CheckInterval * 2)
            {
                State_Connected = false;
            }
            timCheckConn.Start();
        }

        /// <summary>
        /// Set a bit value in a int
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="Value"></param>
        /// <param name="Position"></param>
        private void SetBit(ref int Target, bool Value, int Position)
        {
            if (Value)
            {
                Target |= 1 << Position;
            }
            else
            {
                Target &= ~(1 << Position);
            }
        }
    }
}
