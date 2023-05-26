using Common.MSMQ;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Common.Forms
{
    /// <summary>
    /// 標準邏輯視窗
    /// </summary>
    public partial class Frm_Logic : Form, IServerUI
    {
        public bool IsPrintLogDate { get; set; } = true;
        private readonly DateTime _StartUpTime;
        private MQHelper _mq;

        public Frm_Logic()
        {
            //防止多開
            string selfName = Process.GetCurrentProcess().ProcessName;
            Process[] pNames = Process.GetProcessesByName(selfName);
            if (pNames.Length > 1)
            {
                Environment.Exit(0);
            }

            InitializeComponent();

            //print Startup Time
            _StartUpTime = DateTime.Now;
            Lab_StartTime.Text += _StartUpTime.ToString("yyyy/MM/dd HH:mm:ss");

            //start Excute Time
            StartTimer();

            Rtb_Log.TextChanged += Rtb_TextChanged;
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
        /// 設定視窗Icon
        /// </summary>
        /// <param name="i"></param>
        public void SetIcon(System.Drawing.Icon i)
        {
            Icon = i;
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
                string prefix = string.Empty;
                if (IsPrintLogDate)
                    prefix = $"[{DateTime.Now}] ";
                Rtb_Log.AppendText($"{prefix}{msg}\r\n");
            }
        }

        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            Rtb_Log.SelectionStart = Rtb_Log.Text.Length;
            // scroll it automatically
            Rtb_Log.ScrollToCaret();
        }
    }
}
