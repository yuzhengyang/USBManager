namespace USBManager.Views.MainViews
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.DGVUSBList = new System.Windows.Forms.DataGridView();
            this.CMS_DGVUSBList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.详细ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.启用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MSMain = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助主题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.技术中心网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于USBManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBIDWebSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVUSBList_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_VID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_InstanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_Storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVUSBList_Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUSBList)).BeginInit();
            this.CMS_DGVUSBList.SuspendLayout();
            this.MSMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVUSBList
            // 
            this.DGVUSBList.AllowUserToAddRows = false;
            this.DGVUSBList.AllowUserToDeleteRows = false;
            this.DGVUSBList.BackgroundColor = System.Drawing.Color.White;
            this.DGVUSBList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUSBList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVUSBList_Desc,
            this.DGVUSBList_VID,
            this.DGVUSBList_PID,
            this.DGVUSBList_InstanceID,
            this.DGVUSBList_Status,
            this.DGVUSBList_VendorName,
            this.DGVUSBList_ProductName,
            this.DGVUSBList_Storage,
            this.DGVUSBList_Volume});
            this.DGVUSBList.ContextMenuStrip = this.CMS_DGVUSBList;
            this.DGVUSBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVUSBList.Location = new System.Drawing.Point(0, 0);
            this.DGVUSBList.MultiSelect = false;
            this.DGVUSBList.Name = "DGVUSBList";
            this.DGVUSBList.ReadOnly = true;
            this.DGVUSBList.RowHeadersVisible = false;
            this.DGVUSBList.RowTemplate.Height = 23;
            this.DGVUSBList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVUSBList.Size = new System.Drawing.Size(767, 391);
            this.DGVUSBList.TabIndex = 0;
            this.DGVUSBList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVUSBList_CellMouseDown);
            // 
            // CMS_DGVUSBList
            // 
            this.CMS_DGVUSBList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.详细ToolStripMenuItem1,
            this.启用ToolStripMenuItem,
            this.禁用ToolStripMenuItem,
            this.刷新ToolStripMenuItem1});
            this.CMS_DGVUSBList.Name = "CMS_DGVUSBList";
            this.CMS_DGVUSBList.Size = new System.Drawing.Size(101, 92);
            // 
            // 详细ToolStripMenuItem1
            // 
            this.详细ToolStripMenuItem1.Name = "详细ToolStripMenuItem1";
            this.详细ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.详细ToolStripMenuItem1.Text = "详细";
            // 
            // 启用ToolStripMenuItem
            // 
            this.启用ToolStripMenuItem.Name = "启用ToolStripMenuItem";
            this.启用ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.启用ToolStripMenuItem.Text = "启用";
            this.启用ToolStripMenuItem.Click += new System.EventHandler(this.启用ToolStripMenuItem_Click);
            // 
            // 禁用ToolStripMenuItem
            // 
            this.禁用ToolStripMenuItem.Name = "禁用ToolStripMenuItem";
            this.禁用ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.禁用ToolStripMenuItem.Text = "禁用";
            this.禁用ToolStripMenuItem.Click += new System.EventHandler(this.禁用ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
            // 
            // MSMain
            // 
            this.MSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MSMain.Location = new System.Drawing.Point(0, 0);
            this.MSMain.Name = "MSMain";
            this.MSMain.Size = new System.Drawing.Size(767, 25);
            this.MSMain.TabIndex = 1;
            this.MSMain.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出列表ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 导出列表ToolStripMenuItem
            // 
            this.导出列表ToolStripMenuItem.Name = "导出列表ToolStripMenuItem";
            this.导出列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出列表ToolStripMenuItem.Text = "导出列表";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.详细信息ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 详细信息ToolStripMenuItem
            // 
            this.详细信息ToolStripMenuItem.Name = "详细信息ToolStripMenuItem";
            this.详细信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.详细信息ToolStripMenuItem.Text = "详细信息";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助主题ToolStripMenuItem,
            this.技术中心网站ToolStripMenuItem,
            this.关于USBManagerToolStripMenuItem,
            this.uSBIDWebSiteToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助主题ToolStripMenuItem
            // 
            this.帮助主题ToolStripMenuItem.Name = "帮助主题ToolStripMenuItem";
            this.帮助主题ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.帮助主题ToolStripMenuItem.Text = "帮助主题";
            // 
            // 技术中心网站ToolStripMenuItem
            // 
            this.技术中心网站ToolStripMenuItem.Name = "技术中心网站ToolStripMenuItem";
            this.技术中心网站ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.技术中心网站ToolStripMenuItem.Text = "技术中心网站";
            this.技术中心网站ToolStripMenuItem.Click += new System.EventHandler(this.技术中心网站ToolStripMenuItem_Click);
            // 
            // 关于USBManagerToolStripMenuItem
            // 
            this.关于USBManagerToolStripMenuItem.Name = "关于USBManagerToolStripMenuItem";
            this.关于USBManagerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.关于USBManagerToolStripMenuItem.Text = "关于 USB Manager";
            this.关于USBManagerToolStripMenuItem.Click += new System.EventHandler(this.关于USBManagerToolStripMenuItem_Click);
            // 
            // uSBIDWebSiteToolStripMenuItem
            // 
            this.uSBIDWebSiteToolStripMenuItem.Name = "uSBIDWebSiteToolStripMenuItem";
            this.uSBIDWebSiteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.uSBIDWebSiteToolStripMenuItem.Text = "访问 linux-usb";
            this.uSBIDWebSiteToolStripMenuItem.Click += new System.EventHandler(this.uSBIDWebSiteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(767, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGVUSBList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 391);
            this.panel1.TabIndex = 5;
            // 
            // DGVUSBList_Desc
            // 
            this.DGVUSBList_Desc.HeaderText = "设备描述";
            this.DGVUSBList_Desc.Name = "DGVUSBList_Desc";
            this.DGVUSBList_Desc.ReadOnly = true;
            // 
            // DGVUSBList_VID
            // 
            this.DGVUSBList_VID.HeaderText = "厂商序号";
            this.DGVUSBList_VID.Name = "DGVUSBList_VID";
            this.DGVUSBList_VID.ReadOnly = true;
            // 
            // DGVUSBList_PID
            // 
            this.DGVUSBList_PID.HeaderText = "产品序号";
            this.DGVUSBList_PID.Name = "DGVUSBList_PID";
            this.DGVUSBList_PID.ReadOnly = true;
            // 
            // DGVUSBList_InstanceID
            // 
            this.DGVUSBList_InstanceID.HeaderText = "Instance ID";
            this.DGVUSBList_InstanceID.Name = "DGVUSBList_InstanceID";
            this.DGVUSBList_InstanceID.ReadOnly = true;
            // 
            // DGVUSBList_Status
            // 
            this.DGVUSBList_Status.HeaderText = "状态";
            this.DGVUSBList_Status.Name = "DGVUSBList_Status";
            this.DGVUSBList_Status.ReadOnly = true;
            // 
            // DGVUSBList_VendorName
            // 
            this.DGVUSBList_VendorName.HeaderText = "厂商名称";
            this.DGVUSBList_VendorName.Name = "DGVUSBList_VendorName";
            this.DGVUSBList_VendorName.ReadOnly = true;
            // 
            // DGVUSBList_ProductName
            // 
            this.DGVUSBList_ProductName.HeaderText = "产品名称";
            this.DGVUSBList_ProductName.Name = "DGVUSBList_ProductName";
            this.DGVUSBList_ProductName.ReadOnly = true;
            // 
            // DGVUSBList_Storage
            // 
            this.DGVUSBList_Storage.HeaderText = "存储设备";
            this.DGVUSBList_Storage.Name = "DGVUSBList_Storage";
            this.DGVUSBList_Storage.ReadOnly = true;
            // 
            // DGVUSBList_Volume
            // 
            this.DGVUSBList_Volume.HeaderText = "驱动器";
            this.DGVUSBList_Volume.Name = "DGVUSBList_Volume";
            this.DGVUSBList_Volume.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 438);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MSMain);
            this.MainMenuStrip = this.MSMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUSBList)).EndInit();
            this.CMS_DGVUSBList.ResumeLayout(false);
            this.MSMain.ResumeLayout(false);
            this.MSMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVUSBList;
        private System.Windows.Forms.MenuStrip MSMain;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 详细信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助主题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 技术中心网站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于USBManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_DGVUSBList;
        private System.Windows.Forms.ToolStripMenuItem 详细ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 启用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uSBIDWebSiteToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_VID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_InstanceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_VendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_Storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVUSBList_Volume;
    }
}