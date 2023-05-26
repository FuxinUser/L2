namespace Common.Forms
{
    partial class Frm_Logic
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
            this.Tab_Control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Grb_Log = new System.Windows.Forms.GroupBox();
            this.Rtb_Log = new System.Windows.Forms.RichTextBox();
            this.Grb_Buffer = new System.Windows.Forms.GroupBox();
            this.Lab_CountHandle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tab_Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Grb_Log.SuspendLayout();
            this.Grb_Buffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_RunningTime
            // 
            this.Lab_RunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_RunningTime.AutoSize = true;
            this.Lab_RunningTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lab_RunningTime.Location = new System.Drawing.Point(580, 4);
            this.Lab_RunningTime.Name = "Lab_RunningTime";
            this.Lab_RunningTime.Size = new System.Drawing.Size(89, 17);
            this.Lab_RunningTime.TabIndex = 12;
            this.Lab_RunningTime.Text = "已運行時間： ";
            // 
            // Lab_StartTime
            // 
            this.Lab_StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_StartTime.AutoSize = true;
            this.Lab_StartTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lab_StartTime.Location = new System.Drawing.Point(360, 4);
            this.Lab_StartTime.Name = "Lab_StartTime";
            this.Lab_StartTime.Size = new System.Drawing.Size(76, 17);
            this.Lab_StartTime.TabIndex = 11;
            this.Lab_StartTime.Text = "起動時間： ";
            // 
            // Tab_Control
            // 
            this.Tab_Control.Controls.Add(this.tabPage1);
            this.Tab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Control.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab_Control.Location = new System.Drawing.Point(0, 0);
            this.Tab_Control.Name = "Tab_Control";
            this.Tab_Control.SelectedIndex = 0;
            this.Tab_Control.Size = new System.Drawing.Size(784, 561);
            this.Tab_Control.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Grb_Log);
            this.tabPage1.Controls.Add(this.Grb_Buffer);
            this.tabPage1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "監控";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Grb_Log
            // 
            this.Grb_Log.Controls.Add(this.Rtb_Log);
            this.Grb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grb_Log.Location = new System.Drawing.Point(3, 53);
            this.Grb_Log.Name = "Grb_Log";
            this.Grb_Log.Size = new System.Drawing.Size(770, 475);
            this.Grb_Log.TabIndex = 0;
            this.Grb_Log.TabStop = false;
            this.Grb_Log.Text = "訊息";
            // 
            // Rtb_Log
            // 
            this.Rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Log.Location = new System.Drawing.Point(3, 21);
            this.Rtb_Log.Name = "Rtb_Log";
            this.Rtb_Log.ReadOnly = true;
            this.Rtb_Log.Size = new System.Drawing.Size(764, 451);
            this.Rtb_Log.TabIndex = 0;
            this.Rtb_Log.Text = "";
            // 
            // Grb_Buffer
            // 
            this.Grb_Buffer.Controls.Add(this.Lab_CountHandle);
            this.Grb_Buffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grb_Buffer.Location = new System.Drawing.Point(3, 3);
            this.Grb_Buffer.Name = "Grb_Buffer";
            this.Grb_Buffer.Size = new System.Drawing.Size(770, 50);
            this.Grb_Buffer.TabIndex = 3;
            this.Grb_Buffer.TabStop = false;
            this.Grb_Buffer.Text = "佇列資訊";
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
            // Frm_Logic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Lab_RunningTime);
            this.Controls.Add(this.Lab_StartTime);
            this.Controls.Add(this.Tab_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Logic";
            this.Text = "標準內部邏輯程式";
            this.Tab_Control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Grb_Log.ResumeLayout(false);
            this.Grb_Buffer.ResumeLayout(false);
            this.Grb_Buffer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab_RunningTime;
        private System.Windows.Forms.Label Lab_StartTime;
        private System.Windows.Forms.TabControl Tab_Control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox Grb_Log;
        private System.Windows.Forms.RichTextBox Rtb_Log;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox Grb_Buffer;
        private System.Windows.Forms.Label Lab_CountHandle;
    }
}