namespace USBManager.UI.Views.OperationViews
{
    partial class ConnectComputerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTConnect = new System.Windows.Forms.Button();
            this.RBLocal = new System.Windows.Forms.RadioButton();
            this.RBRemote = new System.Windows.Forms.RadioButton();
            this.TBIP = new System.Windows.Forms.TextBox();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTConnect
            // 
            this.BTConnect.Location = new System.Drawing.Point(228, 128);
            this.BTConnect.Name = "BTConnect";
            this.BTConnect.Size = new System.Drawing.Size(99, 23);
            this.BTConnect.TabIndex = 0;
            this.BTConnect.Text = "连接";
            this.BTConnect.UseVisualStyleBackColor = true;
            this.BTConnect.Click += new System.EventHandler(this.BTConnect_Click);
            // 
            // RBLocal
            // 
            this.RBLocal.AutoSize = true;
            this.RBLocal.Checked = true;
            this.RBLocal.Location = new System.Drawing.Point(23, 21);
            this.RBLocal.Name = "RBLocal";
            this.RBLocal.Size = new System.Drawing.Size(83, 16);
            this.RBLocal.TabIndex = 1;
            this.RBLocal.TabStop = true;
            this.RBLocal.Text = "本地计算机";
            this.RBLocal.UseVisualStyleBackColor = true;
            this.RBLocal.CheckedChanged += new System.EventHandler(this.RBLocal_CheckedChanged);
            // 
            // RBRemote
            // 
            this.RBRemote.AutoSize = true;
            this.RBRemote.ForeColor = System.Drawing.Color.Gray;
            this.RBRemote.Location = new System.Drawing.Point(23, 57);
            this.RBRemote.Name = "RBRemote";
            this.RBRemote.Size = new System.Drawing.Size(83, 16);
            this.RBRemote.TabIndex = 2;
            this.RBRemote.Text = "远程计算机";
            this.RBRemote.UseVisualStyleBackColor = true;
            this.RBRemote.CheckedChanged += new System.EventHandler(this.RBRemote_CheckedChanged);
            // 
            // TBIP
            // 
            this.TBIP.Enabled = false;
            this.TBIP.Location = new System.Drawing.Point(112, 55);
            this.TBIP.MaxLength = 15;
            this.TBIP.Name = "TBIP";
            this.TBIP.Size = new System.Drawing.Size(127, 21);
            this.TBIP.TabIndex = 3;
            this.TBIP.Text = "192.168.123.199";
            this.TBIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBPort
            // 
            this.TBPort.Enabled = false;
            this.TBPort.Location = new System.Drawing.Point(245, 55);
            this.TBPort.MaxLength = 5;
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(64, 21);
            this.TBPort.TabIndex = 4;
            this.TBPort.Text = "52810";
            this.TBPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConnectComputerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 193);
            this.Controls.Add(this.RBRemote);
            this.Controls.Add(this.TBIP);
            this.Controls.Add(this.RBLocal);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.BTConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectComputerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接到另一台计算机";
            this.Load += new System.EventHandler(this.ConnectComputerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTConnect;
        private System.Windows.Forms.RadioButton RBLocal;
        private System.Windows.Forms.RadioButton RBRemote;
        private System.Windows.Forms.TextBox TBIP;
        private System.Windows.Forms.TextBox TBPort;
    }
}