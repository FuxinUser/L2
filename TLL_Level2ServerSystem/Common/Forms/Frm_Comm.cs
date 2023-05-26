using Common.MSMQ;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Common.Forms
{
    /// <summary>
    /// 標準通訊視窗
    /// </summary>
    public partial class Frm_Comm : Form, IServerUI
    {
        public event Action<string> OnSend;
        public event Action<string> OnQuery;
        private readonly DateTime _StartUpTime;
        private MQHelper _mq;

        public Frm_Comm()
        {
            //防止多開
            string selfName = Process.GetCurrentProcess().ProcessName;
            Process[] pNames = Process.GetProcessesByName(selfName);
            if (pNames.Length > 1)
            {
                Environment.Exit(0);
            }

            //init layout
            InitializeComponent();

            //print Startup Time
            _StartUpTime = DateTime.Now;
            Lab_StartTime.Text += _StartUpTime.ToString("yyyy/MM/dd HH:mm:ss");

            //start Excute Time
            StartTimer();

            Btn_Search.Click += Btn_Search_Click;
            Btn_Resend.Click += Btn_Resend_Click;
        }

        private void StartTimer()
        {
            timer1.Tick += OnTick;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - _StartUpTime;
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}",
                            t.Days,
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
            Lab_RunningTime.Text = "執行時間： " + answer;

            Lab_CountHandle.Text = $"待處理報文 : {_mq?.CountData()}";
        }

        private void RSMSMgr_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //PublicSystem.GetDicActSels(PublicConst.Process_RSMSMgr).Tell(
            //    new StatesMessage() { ActorSetup = StatesMessage.Actor.Rcv, StatesSetup = StatesMessage.States.Stop, IP = "", Port = "" });
            //PublicSystem.GetDicActSels(PublicConst.Process_RSMSMgr).Tell(
            //    new StatesMessage() { ActorSetup = StatesMessage.Actor.Snd, StatesSetup = StatesMessage.States.Stop, IP = "", Port = "" });
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Cbo_Message.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇報文項目");
                return;
            }
            string key = Cbo_Message.SelectedItem.ToString();
            OnQuery?.Invoke(key);
        }

        private void Btn_Resend_Click(object sender, EventArgs e)
        {
            if (Cbo_Message.SelectedIndex < 0 || Cbo_Message.SelectedItem == null)
            {
                MessageBox.Show("請選擇報文項目");
                return;
            }
            string key = Cbo_Message.SelectedItem.ToString();
            OnSend?.Invoke(key);
        }

        /// <summary>
        /// 顯示連線資訊
        /// </summary>
        /// <param name="localIp"></param>
        /// <param name="localPort"></param>
        /// <param name="remoteIp"></param>
        /// <param name="remotePort"></param>
        public void InitConnectInfo(string localIp, string localPort, string remoteIp, string remotePort)
        {
            Txt_LocalIP.Text = localIp;
            Txt_LocalPort.Text = localPort;
            Txt_RemoteIP.Text = remoteIp;
            Txt_RemotePort.Text = remotePort;
        }

        /// <summary>
        /// 顯示報文清單
        /// </summary>
        /// <param name="tgs"></param>
        public void InitTelegramList(string[] tgs)
        {
            Cbo_Message.Items.Clear();
            Cbo_Message.Items.AddRange(tgs);
        }

        /// <summary>
        /// 設定視窗Icon
        /// </summary>
        /// <param name="i"></param>
        public void SetIcon(System.Drawing.Icon i)
        {
            Icon = i;
        }

        /// <summary>
        /// 監聽來自MQ的訊息
        /// </summary>
        /// <param name="port"></param>
        /// <param name="act"></param>
        public void BindMQ(string port, Action<object> act)
        {
            _mq = new MQHelper(port);
            _mq.Receive(act);
        }

        /// <summary>
        /// 取得報文列表DGV
        /// </summary>
        /// <returns></returns>
        public DataGridView GetDgv()
        {
            return Dgv_MessageHeader;
        }

        /// <summary>
        /// 在Console上寫日誌
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    WriteLog(msg);
                }));
            }
            else
            {
                Rtb_Log.AppendText($"[{DateTime.Now}] {msg}\r\n");
            }
        }
    }
}
