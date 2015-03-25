namespace Cheku
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dbChargeModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSet = new Cheku.DataBase.dbBGSDataSet();
            this.dbConfigModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.topMenu_CardManager_IButton = new System.Windows.Forms.PictureBox();
            this.topMenu_ChongZhi_IButton = new System.Windows.Forms.PictureBox();
            this.topMenu_Xitong_IButton = new System.Windows.Forms.PictureBox();
            this.topMenu_Lishi_IButton = new System.Windows.Forms.PictureBox();
            this.topMenu_Cheku_IButton = new System.Windows.Forms.PictureBox();
            this.topMenu_Print_IButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.topMenu_Camera_IButton = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.topMenu_ChannelManager_IButton = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BottomPanel1 = new System.Windows.Forms.Panel();
            this.TabPanel = new System.Windows.Forms.TabControl();
            this.BottomPanel0 = new System.Windows.Forms.Panel();
            this.topMenu_RemSpace_Label = new System.Windows.Forms.Label();
            this.topMenu_OcuSpace_Label = new System.Windows.Forms.Label();
            this.topMenu_TotalSpace_Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dbConfigModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter();
            this.dbChargeModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_CardManager_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_ChongZhi_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Xitong_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Lishi_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Cheku_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Print_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Camera_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_ChannelManager_IButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.BottomPanel1.SuspendLayout();
            this.BottomPanel0.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 826);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1271, 26);
            this.statusStrip1.TabIndex = 75;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 24);
            this.toolStripStatusLabel1.Text = "登陆姓名";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 21);
            this.toolStripStatusLabel2.Text = "NAME";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(69, 21);
            this.toolStripStatusLabel3.Text = "登陆时间";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(42, 21);
            this.toolStripStatusLabel4.Text = "time";
            // 
            // dbChargeModeBindingSource
            // 
            this.dbChargeModeBindingSource.DataMember = "dbChargeMode";
            this.dbChargeModeBindingSource.DataSource = this.dbBGSDataSet;
            // 
            // dbBGSDataSet
            // 
            this.dbBGSDataSet.DataSetName = "dbBGSDataSet";
            this.dbBGSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbConfigModeBindingSource
            // 
            this.dbConfigModeBindingSource.DataMember = "dbConfigMode";
            this.dbConfigModeBindingSource.DataSource = this.dbBGSDataSet;
            // 
            // topMenu_CardManager_IButton
            // 
            this.topMenu_CardManager_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_CardManager_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_CardManager_IButton.Image = global::Cheku.Properties.Resources.用户管理;
            this.topMenu_CardManager_IButton.Location = new System.Drawing.Point(215, 0);
            this.topMenu_CardManager_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_CardManager_IButton.Name = "topMenu_CardManager_IButton";
            this.topMenu_CardManager_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_CardManager_IButton.TabIndex = 113;
            this.topMenu_CardManager_IButton.TabStop = false;
            this.topMenu_CardManager_IButton.Click += new System.EventHandler(this.topMenu_CardManager_IButton_Click);
            this.topMenu_CardManager_IButton.MouseEnter += new System.EventHandler(this.topMenu_CardManager_IButton_MouseEnter);
            this.topMenu_CardManager_IButton.MouseLeave += new System.EventHandler(this.topMenu_CardManager_IButton_MouseLeave);
            // 
            // topMenu_ChongZhi_IButton
            // 
            this.topMenu_ChongZhi_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_ChongZhi_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_ChongZhi_IButton.Image = global::Cheku.Properties.Resources.充值管理;
            this.topMenu_ChongZhi_IButton.Location = new System.Drawing.Point(6, 1);
            this.topMenu_ChongZhi_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_ChongZhi_IButton.Name = "topMenu_ChongZhi_IButton";
            this.topMenu_ChongZhi_IButton.Size = new System.Drawing.Size(77, 105);
            this.topMenu_ChongZhi_IButton.TabIndex = 114;
            this.topMenu_ChongZhi_IButton.TabStop = false;
            this.topMenu_ChongZhi_IButton.Click += new System.EventHandler(this.topMenu_Recharge_IButton_Click);
            this.topMenu_ChongZhi_IButton.MouseEnter += new System.EventHandler(this.topMenu_ChongZhi_IButton_MouseEnter);
            this.topMenu_ChongZhi_IButton.MouseLeave += new System.EventHandler(this.topMenu_ChongZhi_IButton_MouseLeave);
            // 
            // topMenu_Xitong_IButton
            // 
            this.topMenu_Xitong_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_Xitong_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_Xitong_IButton.Image = global::Cheku.Properties.Resources.系统设置;
            this.topMenu_Xitong_IButton.Location = new System.Drawing.Point(643, 3);
            this.topMenu_Xitong_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_Xitong_IButton.Name = "topMenu_Xitong_IButton";
            this.topMenu_Xitong_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_Xitong_IButton.TabIndex = 115;
            this.topMenu_Xitong_IButton.TabStop = false;
            this.topMenu_Xitong_IButton.Click += new System.EventHandler(this.topMenu_System_IButton_Click);
            this.topMenu_Xitong_IButton.MouseEnter += new System.EventHandler(this.topMenu_Xitong_IButton_MouseEnter);
            this.topMenu_Xitong_IButton.MouseLeave += new System.EventHandler(this.topMenu_Xitong_IButton_MouseLeave);
            // 
            // topMenu_Lishi_IButton
            // 
            this.topMenu_Lishi_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_Lishi_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_Lishi_IButton.Image = global::Cheku.Properties.Resources.历史记录;
            this.topMenu_Lishi_IButton.Location = new System.Drawing.Point(536, 4);
            this.topMenu_Lishi_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_Lishi_IButton.Name = "topMenu_Lishi_IButton";
            this.topMenu_Lishi_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_Lishi_IButton.TabIndex = 116;
            this.topMenu_Lishi_IButton.TabStop = false;
            this.topMenu_Lishi_IButton.Click += new System.EventHandler(this.topMenu_History_IButton_Click);
            this.topMenu_Lishi_IButton.MouseEnter += new System.EventHandler(this.topMenu_Lishi_IButton_MouseEnter);
            this.topMenu_Lishi_IButton.MouseLeave += new System.EventHandler(this.topMenu_Lishi_IButton_MouseLeave);
            // 
            // topMenu_Cheku_IButton
            // 
            this.topMenu_Cheku_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_Cheku_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_Cheku_IButton.Image = global::Cheku.Properties.Resources.车库管理;
            this.topMenu_Cheku_IButton.Location = new System.Drawing.Point(321, 2);
            this.topMenu_Cheku_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_Cheku_IButton.Name = "topMenu_Cheku_IButton";
            this.topMenu_Cheku_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_Cheku_IButton.TabIndex = 117;
            this.topMenu_Cheku_IButton.TabStop = false;
            this.topMenu_Cheku_IButton.Click += new System.EventHandler(this.topMenu_Manage_IButton_Click);
            this.topMenu_Cheku_IButton.MouseEnter += new System.EventHandler(this.topMenu_Cheku_IButton_MouseEnter);
            this.topMenu_Cheku_IButton.MouseLeave += new System.EventHandler(this.topMenu_Cheku_IButton_MouseLeave);
            // 
            // topMenu_Print_IButton
            // 
            this.topMenu_Print_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_Print_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_Print_IButton.Image = global::Cheku.Properties.Resources.打印;
            this.topMenu_Print_IButton.Location = new System.Drawing.Point(750, 4);
            this.topMenu_Print_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_Print_IButton.Name = "topMenu_Print_IButton";
            this.topMenu_Print_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_Print_IButton.TabIndex = 120;
            this.topMenu_Print_IButton.TabStop = false;
            this.topMenu_Print_IButton.MouseEnter += new System.EventHandler(this.topMenu_Print_IButton_MouseEnter);
            this.topMenu_Print_IButton.MouseLeave += new System.EventHandler(this.topMenu_Print_IButton_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox1.Location = new System.Drawing.Point(84, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 99);
            this.pictureBox1.TabIndex = 121;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox2.Location = new System.Drawing.Point(297, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 99);
            this.pictureBox2.TabIndex = 122;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox3.Location = new System.Drawing.Point(404, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 99);
            this.pictureBox3.TabIndex = 123;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox4.Location = new System.Drawing.Point(619, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 99);
            this.pictureBox4.TabIndex = 124;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox5.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox5.Location = new System.Drawing.Point(726, 9);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(22, 99);
            this.pictureBox5.TabIndex = 125;
            this.pictureBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(539, 830);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 20);
            this.label1.TabIndex = 126;
            this.label1.Text = "Hongkong Spring Technology Co., ltd";
            // 
            // topMenu_Camera_IButton
            // 
            this.topMenu_Camera_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_Camera_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_Camera_IButton.Image = global::Cheku.Properties.Resources.监控管理;
            this.topMenu_Camera_IButton.Location = new System.Drawing.Point(428, 2);
            this.topMenu_Camera_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_Camera_IButton.Name = "topMenu_Camera_IButton";
            this.topMenu_Camera_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_Camera_IButton.TabIndex = 120;
            this.topMenu_Camera_IButton.TabStop = false;
            this.topMenu_Camera_IButton.Click += new System.EventHandler(this.topMenu_Camera_IButton_Click);
            this.topMenu_Camera_IButton.MouseEnter += new System.EventHandler(this.topMenu_Camera_IButton_MouseEnter);
            this.topMenu_Camera_IButton.MouseLeave += new System.EventHandler(this.topMenu_Camera_IButton_MouseLeave);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox8.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox8.Location = new System.Drawing.Point(512, 8);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(22, 99);
            this.pictureBox8.TabIndex = 127;
            this.pictureBox8.TabStop = false;
            // 
            // topMenu_ChannelManager_IButton
            // 
            this.topMenu_ChannelManager_IButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topMenu_ChannelManager_IButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topMenu_ChannelManager_IButton.Image = global::Cheku.Properties.Resources.通道管理;
            this.topMenu_ChannelManager_IButton.Location = new System.Drawing.Point(109, 1);
            this.topMenu_ChannelManager_IButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topMenu_ChannelManager_IButton.Name = "topMenu_ChannelManager_IButton";
            this.topMenu_ChannelManager_IButton.Size = new System.Drawing.Size(81, 105);
            this.topMenu_ChannelManager_IButton.TabIndex = 128;
            this.topMenu_ChannelManager_IButton.TabStop = false;
            this.topMenu_ChannelManager_IButton.Click += new System.EventHandler(this.topMenu_ChannelManager_IButton_Click);
            this.topMenu_ChannelManager_IButton.MouseEnter += new System.EventHandler(this.topMenu_ChannelManager_IButton_MouseEnter);
            this.topMenu_ChannelManager_IButton.MouseLeave += new System.EventHandler(this.topMenu_ChannelManager_IButton_MouseLeave);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox9.Image = global::Cheku.Properties.Resources.line1;
            this.pictureBox9.Location = new System.Drawing.Point(191, 5);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(22, 99);
            this.pictureBox9.TabIndex = 121;
            this.pictureBox9.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(1163, 830);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 129;
            this.label2.Text = "Ver. 1.10";
            // 
            // BottomPanel1
            // 
            this.BottomPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BottomPanel1.Controls.Add(this.TabPanel);
            this.BottomPanel1.Location = new System.Drawing.Point(28, 119);
            this.BottomPanel1.Name = "BottomPanel1";
            this.BottomPanel1.Size = new System.Drawing.Size(1218, 688);
            this.BottomPanel1.TabIndex = 130;
            // 
            // TabPanel
            // 
            this.TabPanel.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPanel.ItemSize = new System.Drawing.Size(27, 40);
            this.TabPanel.Location = new System.Drawing.Point(0, 0);
            this.TabPanel.Multiline = true;
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 0;
            this.TabPanel.Size = new System.Drawing.Size(1218, 688);
            this.TabPanel.TabIndex = 112;
            this.TabPanel.Tag = "";
            this.TabPanel.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabPanel_Selected);
            // 
            // BottomPanel0
            // 
            this.BottomPanel0.Controls.Add(this.topMenu_RemSpace_Label);
            this.BottomPanel0.Controls.Add(this.topMenu_OcuSpace_Label);
            this.BottomPanel0.Controls.Add(this.topMenu_TotalSpace_Label);
            this.BottomPanel0.Controls.Add(this.label8);
            this.BottomPanel0.Controls.Add(this.label6);
            this.BottomPanel0.Controls.Add(this.label4);
            this.BottomPanel0.Controls.Add(this.topMenu_ChongZhi_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_ChannelManager_IButton);
            this.BottomPanel0.Controls.Add(this.pictureBox1);
            this.BottomPanel0.Controls.Add(this.pictureBox8);
            this.BottomPanel0.Controls.Add(this.pictureBox9);
            this.BottomPanel0.Controls.Add(this.pictureBox5);
            this.BottomPanel0.Controls.Add(this.pictureBox4);
            this.BottomPanel0.Controls.Add(this.pictureBox3);
            this.BottomPanel0.Controls.Add(this.pictureBox2);
            this.BottomPanel0.Controls.Add(this.topMenu_CardManager_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_Camera_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_Xitong_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_Print_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_Lishi_IButton);
            this.BottomPanel0.Controls.Add(this.topMenu_Cheku_IButton);
            this.BottomPanel0.Location = new System.Drawing.Point(59, 12);
            this.BottomPanel0.Name = "BottomPanel0";
            this.BottomPanel0.Size = new System.Drawing.Size(1164, 114);
            this.BottomPanel0.TabIndex = 131;
            // 
            // topMenu_RemSpace_Label
            // 
            this.topMenu_RemSpace_Label.AutoSize = true;
            this.topMenu_RemSpace_Label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topMenu_RemSpace_Label.Location = new System.Drawing.Point(1041, 73);
            this.topMenu_RemSpace_Label.Name = "topMenu_RemSpace_Label";
            this.topMenu_RemSpace_Label.Size = new System.Drawing.Size(42, 19);
            this.topMenu_RemSpace_Label.TabIndex = 131;
            this.topMenu_RemSpace_Label.Text = "void";
            this.topMenu_RemSpace_Label.Click += new System.EventHandler(this.topMenu_RemSpace_Label_Click);
            // 
            // topMenu_OcuSpace_Label
            // 
            this.topMenu_OcuSpace_Label.AutoSize = true;
            this.topMenu_OcuSpace_Label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topMenu_OcuSpace_Label.Location = new System.Drawing.Point(1041, 41);
            this.topMenu_OcuSpace_Label.Name = "topMenu_OcuSpace_Label";
            this.topMenu_OcuSpace_Label.Size = new System.Drawing.Size(42, 19);
            this.topMenu_OcuSpace_Label.TabIndex = 131;
            this.topMenu_OcuSpace_Label.Text = "void";
            // 
            // topMenu_TotalSpace_Label
            // 
            this.topMenu_TotalSpace_Label.AutoSize = true;
            this.topMenu_TotalSpace_Label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.topMenu_TotalSpace_Label.Location = new System.Drawing.Point(1041, 9);
            this.topMenu_TotalSpace_Label.Name = "topMenu_TotalSpace_Label";
            this.topMenu_TotalSpace_Label.Size = new System.Drawing.Size(42, 19);
            this.topMenu_TotalSpace_Label.TabIndex = 131;
            this.topMenu_TotalSpace_Label.Text = "void";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(944, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 130;
            this.label8.Text = "剩余车位:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(944, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "已占用车位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(944, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 130;
            this.label4.Text = "总车位:";
            // 
            // dbConfigModeTableAdapter
            // 
            this.dbConfigModeTableAdapter.ClearBeforeFill = true;
            // 
            // dbChargeModeTableAdapter
            // 
            this.dbChargeModeTableAdapter.ClearBeforeFill = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Cheku.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1271, 852);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BottomPanel1);
            this.Controls.Add(this.BottomPanel0);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "停  车  场  管  理  系  统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_CardManager_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_ChongZhi_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Xitong_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Lishi_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Cheku_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Print_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_Camera_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenu_ChannelManager_IButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.BottomPanel1.ResumeLayout(false);
            this.BottomPanel0.ResumeLayout(false);
            this.BottomPanel0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox topMenu_CardManager_IButton;
        private System.Windows.Forms.PictureBox topMenu_ChongZhi_IButton;
        private System.Windows.Forms.PictureBox topMenu_Xitong_IButton;
        private System.Windows.Forms.PictureBox topMenu_Lishi_IButton;
        private System.Windows.Forms.PictureBox topMenu_Cheku_IButton;
        private System.Windows.Forms.PictureBox topMenu_Print_IButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.PictureBox topMenu_Camera_IButton;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox topMenu_ChannelManager_IButton;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel BottomPanel1;
        private System.Windows.Forms.Panel BottomPanel0;
        private DataBase.dbBGSDataSet dbBGSDataSet;
        private System.Windows.Forms.BindingSource dbConfigModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter dbConfigModeTableAdapter;
        private System.Windows.Forms.BindingSource dbChargeModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter dbChargeModeTableAdapter;
        private System.Windows.Forms.TabControl TabPanel;
        private System.Windows.Forms.Label topMenu_RemSpace_Label;
        private System.Windows.Forms.Label topMenu_OcuSpace_Label;
        private System.Windows.Forms.Label topMenu_TotalSpace_Label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}

