namespace Common.Forms
{
    partial class Frm_Comm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Lab_RunningTime = new System.Windows.Forms.Label();
            this.Lab_StartTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tab_Control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Grb_Log = new System.Windows.Forms.GroupBox();
            this.Rtb_Log = new System.Windows.Forms.RichTextBox();
            this.Grb_Buffer = new System.Windows.Forms.GroupBox();
            this.Lab_CountSend = new System.Windows.Forms.Label();
            this.Lab_CountHandle = new System.Windows.Forms.Label();
            this.Grb_Connect = new System.Windows.Forms.GroupBox();
            this.Lab_RemotePortHeader = new System.Windows.Forms.Label();
            this.Lab_RemoteIPHeader = new System.Windows.Forms.Label();
            this.Txt_RemotePort = new System.Windows.Forms.TextBox();
            this.Txt_RemoteIP = new System.Windows.Forms.TextBox();
            this.Txt_LocalPort = new System.Windows.Forms.TextBox();
            this.Txt_LocalIP = new System.Windows.Forms.TextBox();
            this.Lab_LocalPortHeader = new System.Windows.Forms.Label();
            this.Lab_LocalIPHeader = new System.Windows.Forms.Label();
            this.Lab_RemoteHeader = new System.Windows.Forms.Label();
            this.Lab_LocalHeader = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Dgv_MessageHeader = new System.Windows.Forms.DataGridView();
            this.Btn_Resend = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Cbo_Message = new System.Windows.Forms.ComboBox();
            this.Lab_MessageHeader = new System.Windows.Forms.Label();
            this.Tab_Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Grb_Log.SuspendLayout();
            this.Grb_Buffer.SuspendLayout();
            this.Grb_Connect.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_MessageHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // Lab_RunningTime
            // 
            this.Lab_RunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_RunningTime.AutoSize = true;
            this.Lab_RunningTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.Lab_RunningTime.Location = new System.Drawing.Point(580, 4);
            this.Lab_RunningTime.Name = "Lab_RunningTime";
            this.Lab_RunningTime.Size = new System.Drawing.Size(89, 17);
            this.Lab_RunningTime.TabIndex = 41;
            this.Lab_RunningTime.Text = "已運行時間： ";
            // 
            // Lab_StartTime
            // 
            this.Lab_StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_StartTime.AutoSize = true;
            this.Lab_StartTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.Lab_StartTime.Location = new System.Drawing.Point(360, 4);
            this.Lab_StartTime.Name = "Lab_StartTime";
            this.Lab_StartTime.Size = new System.Drawing.Size(76, 17);
            this.Lab_StartTime.TabIndex = 40;
            this.Lab_StartTime.Text = "起動時間： ";
            // 
            // Tab_Control
            // 
            this.Tab_Control.Controls.Add(this.tabPage1);
            this.Tab_Control.Controls.Add(this.tabPage2);
            this.Tab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Control.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Tab_Control.Location = new System.Drawing.Point(0, 0);
            this.Tab_Control.Name = "Tab_Control";
            this.Tab_Control.SelectedIndex = 0;
            this.Tab_Control.Size = new System.Drawing.Size(784, 561);
            this.Tab_Control.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Grb_Log);
            this.tabPage1.Controls.Add(this.Grb_Buffer);
            this.tabPage1.Controls.Add(this.Grb_Connect);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "監看";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Grb_Log
            // 
            this.Grb_Log.Controls.Add(this.Rtb_Log);
            this.Grb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grb_Log.Location = new System.Drawing.Point(3, 129);
            this.Grb_Log.Name = "Grb_Log";
            this.Grb_Log.Size = new System.Drawing.Size(770, 399);
            this.Grb_Log.TabIndex = 1;
            this.Grb_Log.TabStop = false;
            this.Grb_Log.Text = "訊息";
            // 
            // Rtb_Log
            // 
            this.Rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Log.Location = new System.Drawing.Point(3, 21);
            this.Rtb_Log.Name = "Rtb_Log";
            this.Rtb_Log.ReadOnly = true;
            this.Rtb_Log.Size = new System.Drawing.Size(764, 375);
            this.Rtb_Log.TabIndex = 0;
            this.Rtb_Log.Text = "";
            // 
            // Grb_Buffer
            // 
            this.Grb_Buffer.Controls.Add(this.Lab_CountSend);
            this.Grb_Buffer.Controls.Add(this.Lab_CountHandle);
            this.Grb_Buffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grb_Buffer.Location = new System.Drawing.Point(3, 79);
            this.Grb_Buffer.Name = "Grb_Buffer";
            this.Grb_Buffer.Size = new System.Drawing.Size(770, 50);
            this.Grb_Buffer.TabIndex = 2;
            this.Grb_Buffer.TabStop = false;
            this.Grb_Buffer.Text = "佇列資訊";
            // 
            // Lab_CountSend
            // 
            this.Lab_CountSend.AutoSize = true;
            this.Lab_CountSend.Location = new System.Drawing.Point(210, 21);
            this.Lab_CountSend.Name = "Lab_CountSend";
            this.Lab_CountSend.Size = new System.Drawing.Size(106, 17);
            this.Lab_CountSend.TabIndex = 1;
            this.Lab_CountSend.Text = "待發送報文 : 123";
            // 
            // Lab_CountHandle
            // 
            this.Lab_CountHandle.AutoSize = true;
            this.Lab_CountHandle.Location = new System.Drawing.Point(72, 21);
            this.Lab_CountHandle.Name = "Lab_CountHandle";
            this.Lab_CountHandle.Size = new System.Drawing.Size(106, 17);
            this.Lab_CountHandle.TabIndex = 0;
            this.Lab_CountHandle.Text = "待處理報文 : 123";
            // 
            // Grb_Connect
            // 
            this.Grb_Connect.Controls.Add(this.Lab_RemotePortHeader);
            this.Grb_Connect.Controls.Add(this.Lab_RemoteIPHeader);
            this.Grb_Connect.Controls.Add(this.Txt_RemotePort);
            this.Grb_Connect.Controls.Add(this.Txt_RemoteIP);
            this.Grb_Connect.Controls.Add(this.Txt_LocalPort);
            this.Grb_Connect.Controls.Add(this.Txt_LocalIP);
            this.Grb_Connect.Controls.Add(this.Lab_LocalPortHeader);
            this.Grb_Connect.Controls.Add(this.Lab_LocalIPHeader);
            this.Grb_Connect.Controls.Add(this.Lab_RemoteHeader);
            this.Grb_Connect.Controls.Add(this.Lab_LocalHeader);
            this.Grb_Connect.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grb_Connect.Location = new System.Drawing.Point(3, 3);
            this.Grb_Connect.Name = "Grb_Connect";
            this.Grb_Connect.Size = new System.Drawing.Size(770, 76);
            this.Grb_Connect.TabIndex = 0;
            this.Grb_Connect.TabStop = false;
            this.Grb_Connect.Text = "連線資訊";
            // 
            // Lab_RemotePortHeader
            // 
            this.Lab_RemotePortHeader.AutoSize = true;
            this.Lab_RemotePortHeader.Location = new System.Drawing.Point(572, 42);
            this.Lab_RemotePortHeader.Name = "Lab_RemotePortHeader";
            this.Lab_RemotePortHeader.Size = new System.Drawing.Size(34, 17);
            this.Lab_RemotePortHeader.TabIndex = 9;
            this.Lab_RemotePortHeader.Text = "Port";
            // 
            // Lab_RemoteIPHeader
            // 
            this.Lab_RemoteIPHeader.AutoSize = true;
            this.Lab_RemoteIPHeader.Location = new System.Drawing.Point(452, 42);
            this.Lab_RemoteIPHeader.Name = "Lab_RemoteIPHeader";
            this.Lab_RemoteIPHeader.Size = new System.Drawing.Size(20, 17);
            this.Lab_RemoteIPHeader.TabIndex = 8;
            this.Lab_RemoteIPHeader.Text = "IP";
            // 
            // Txt_RemotePort
            // 
            this.Txt_RemotePort.Location = new System.Drawing.Point(606, 38);
            this.Txt_RemotePort.Name = "Txt_RemotePort";
            this.Txt_RemotePort.ReadOnly = true;
            this.Txt_RemotePort.Size = new System.Drawing.Size(100, 25);
            this.Txt_RemotePort.TabIndex = 7;
            // 
            // Txt_RemoteIP
            // 
            this.Txt_RemoteIP.Location = new System.Drawing.Point(472, 38);
            this.Txt_RemoteIP.Name = "Txt_RemoteIP";
            this.Txt_RemoteIP.ReadOnly = true;
            this.Txt_RemoteIP.Size = new System.Drawing.Size(100, 25);
            this.Txt_RemoteIP.TabIndex = 6;
            // 
            // Txt_LocalPort
            // 
            this.Txt_LocalPort.Location = new System.Drawing.Point(226, 38);
            this.Txt_LocalPort.Name = "Txt_LocalPort";
            this.Txt_LocalPort.ReadOnly = true;
            this.Txt_LocalPort.Size = new System.Drawing.Size(100, 25);
            this.Txt_LocalPort.TabIndex = 5;
            // 
            // Txt_LocalIP
            // 
            this.Txt_LocalIP.Location = new System.Drawing.Point(92, 38);
            this.Txt_LocalIP.Name = "Txt_LocalIP";
            this.Txt_LocalIP.ReadOnly = true;
            this.Txt_LocalIP.Size = new System.Drawing.Size(100, 25);
            this.Txt_LocalIP.TabIndex = 4;
            // 
            // Lab_LocalPortHeader
            // 
            this.Lab_LocalPortHeader.AutoSize = true;
            this.Lab_LocalPortHeader.Location = new System.Drawing.Point(192, 42);
            this.Lab_LocalPortHeader.Name = "Lab_LocalPortHeader";
            this.Lab_LocalPortHeader.Size = new System.Drawing.Size(34, 17);
            this.Lab_LocalPortHeader.TabIndex = 3;
            this.Lab_LocalPortHeader.Text = "Port";
            // 
            // Lab_LocalIPHeader
            // 
            this.Lab_LocalIPHeader.AutoSize = true;
            this.Lab_LocalIPHeader.Location = new System.Drawing.Point(72, 42);
            this.Lab_LocalIPHeader.Name = "Lab_LocalIPHeader";
            this.Lab_LocalIPHeader.Size = new System.Drawing.Size(20, 17);
            this.Lab_LocalIPHeader.TabIndex = 2;
            this.Lab_LocalIPHeader.Text = "IP";
            // 
            // Lab_RemoteHeader
            // 
            this.Lab_RemoteHeader.AutoSize = true;
            this.Lab_RemoteHeader.Location = new System.Drawing.Point(410, 42);
            this.Lab_RemoteHeader.Name = "Lab_RemoteHeader";
            this.Lab_RemoteHeader.Size = new System.Drawing.Size(34, 17);
            this.Lab_RemoteHeader.TabIndex = 1;
            this.Lab_RemoteHeader.Text = "遠端";
            // 
            // Lab_LocalHeader
            // 
            this.Lab_LocalHeader.AutoSize = true;
            this.Lab_LocalHeader.Location = new System.Drawing.Point(30, 42);
            this.Lab_LocalHeader.Name = "Lab_LocalHeader";
            this.Lab_LocalHeader.Size = new System.Drawing.Size(34, 17);
            this.Lab_LocalHeader.TabIndex = 0;
            this.Lab_LocalHeader.Text = "本地";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Dgv_MessageHeader);
            this.tabPage2.Controls.Add(this.Btn_Resend);
            this.tabPage2.Controls.Add(this.Btn_Search);
            this.tabPage2.Controls.Add(this.Cbo_Message);
            this.tabPage2.Controls.Add(this.Lab_MessageHeader);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "報文記錄";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Dgv_MessageHeader
            // 
            this.Dgv_MessageHeader.AllowUserToAddRows = false;
            this.Dgv_MessageHeader.AllowUserToDeleteRows = false;
            this.Dgv_MessageHeader.AllowUserToResizeColumns = false;
            this.Dgv_MessageHeader.AllowUserToResizeRows = false;
            this.Dgv_MessageHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_MessageHeader.Location = new System.Drawing.Point(8, 55);
            this.Dgv_MessageHeader.MultiSelect = false;
            this.Dgv_MessageHeader.Name = "Dgv_MessageHeader";
            this.Dgv_MessageHeader.ReadOnly = true;
            this.Dgv_MessageHeader.RowHeadersVisible = false;
            this.Dgv_MessageHeader.RowTemplate.Height = 24;
            this.Dgv_MessageHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_MessageHeader.Size = new System.Drawing.Size(760, 470);
            this.Dgv_MessageHeader.TabIndex = 6;
            // 
            // Btn_Resend
            // 
            this.Btn_Resend.Location = new System.Drawing.Point(472, 17);
            this.Btn_Resend.Name = "Btn_Resend";
            this.Btn_Resend.Size = new System.Drawing.Size(75, 23);
            this.Btn_Resend.TabIndex = 5;
            this.Btn_Resend.Text = "重送";
            this.Btn_Resend.UseVisualStyleBackColor = true;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(389, 17);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 4;
            this.Btn_Search.Text = "查詢";
            this.Btn_Search.UseVisualStyleBackColor = true;
            // 
            // Cbo_Message
            // 
            this.Cbo_Message.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Message.FormattingEnabled = true;
            this.Cbo_Message.Location = new System.Drawing.Point(80, 16);
            this.Cbo_Message.Name = "Cbo_Message";
            this.Cbo_Message.Size = new System.Drawing.Size(301, 25);
            this.Cbo_Message.TabIndex = 3;
            // 
            // Lab_MessageHeader
            // 
            this.Lab_MessageHeader.AutoSize = true;
            this.Lab_MessageHeader.Location = new System.Drawing.Point(25, 20);
            this.Lab_MessageHeader.Name = "Lab_MessageHeader";
            this.Lab_MessageHeader.Size = new System.Drawing.Size(47, 17);
            this.Lab_MessageHeader.TabIndex = 2;
            this.Lab_MessageHeader.Text = "報文號";
            // 
            // Frm_Comm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Lab_RunningTime);
            this.Controls.Add(this.Lab_StartTime);
            this.Controls.Add(this.Tab_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Comm";
            this.Text = "標準通訊程式";
            this.Tab_Control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Grb_Log.ResumeLayout(false);
            this.Grb_Buffer.ResumeLayout(false);
            this.Grb_Buffer.PerformLayout();
            this.Grb_Connect.ResumeLayout(false);
            this.Grb_Connect.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_MessageHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lab_RunningTime;
        private System.Windows.Forms.Label Lab_StartTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl Tab_Control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox Grb_Log;
        private System.Windows.Forms.GroupBox Grb_Connect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox Rtb_Log;
        private System.Windows.Forms.Label Lab_LocalPortHeader;
        private System.Windows.Forms.Label Lab_LocalIPHeader;
        private System.Windows.Forms.Label Lab_RemoteHeader;
        private System.Windows.Forms.Label Lab_LocalHeader;
        private System.Windows.Forms.Label Lab_RemotePortHeader;
        private System.Windows.Forms.Label Lab_RemoteIPHeader;
        private System.Windows.Forms.TextBox Txt_RemotePort;
        private System.Windows.Forms.TextBox Txt_RemoteIP;
        private System.Windows.Forms.TextBox Txt_LocalPort;
        private System.Windows.Forms.TextBox Txt_LocalIP;
        private System.Windows.Forms.Label Lab_MessageHeader;
        private System.Windows.Forms.ComboBox Cbo_Message;
        private System.Windows.Forms.Button Btn_Resend;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.DataGridView Dgv_MessageHeader;
        private System.Windows.Forms.GroupBox Grb_Buffer;
        private System.Windows.Forms.Label Lab_CountSend;
        private System.Windows.Forms.Label Lab_CountHandle;
    }
}

