namespace Cheku
{
    partial class CameraPanel
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
            this.cForm_CameraManager_TreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cForm_AddCamera_Button = new System.Windows.Forms.Button();
            this.cForm_DeleteCamera_Button = new System.Windows.Forms.Button();
            this.cForm_CameraPanel_Panel = new System.Windows.Forms.GroupBox();
            this.cForm_CameraType_ComboBox = new System.Windows.Forms.ComboBox();
            this.cForm_CameraSpeed_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cForm_AutoCamera_Button = new System.Windows.Forms.Button();
            this.cForm_DownCamera_Button = new System.Windows.Forms.Button();
            this.cForm_UpCamera_Button = new System.Windows.Forms.Button();
            this.cForm_RightCamera_Button = new System.Windows.Forms.Button();
            this.cForm_LeftCamera_Button = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnPTZ = new System.Windows.Forms.Button();
            this.cForm_Record_Button = new System.Windows.Forms.Button();
            this.cForm_CameraChannel_Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cForm_JPEG_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cForm_CameraPort_Text = new System.Windows.Forms.TextBox();
            this.cForm_CameraIP_Text = new System.Windows.Forms.TextBox();
            this.cForm_CameraName_Text = new System.Windows.Forms.TextBox();
            this.cForm_CameraPlay_Picture = new System.Windows.Forms.PictureBox();
            this.cForm_Preview_Button = new System.Windows.Forms.Button();
            this.cForm_Login_Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.cForm_CameraPanel_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cForm_CameraPlay_Picture)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cForm_CameraManager_TreeView
            // 
            this.cForm_CameraManager_TreeView.Location = new System.Drawing.Point(23, 24);
            this.cForm_CameraManager_TreeView.Name = "cForm_CameraManager_TreeView";
            this.cForm_CameraManager_TreeView.Size = new System.Drawing.Size(206, 452);
            this.cForm_CameraManager_TreeView.TabIndex = 1;
            this.cForm_CameraManager_TreeView.TabStop = false;
            this.cForm_CameraManager_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.cForm_CameraManager_TreeView_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cForm_AddCamera_Button);
            this.groupBox2.Controls.Add(this.cForm_DeleteCamera_Button);
            this.groupBox2.Controls.Add(this.cForm_CameraManager_TreeView);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 550);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // cForm_AddCamera_Button
            // 
            this.cForm_AddCamera_Button.Location = new System.Drawing.Point(42, 500);
            this.cForm_AddCamera_Button.Name = "cForm_AddCamera_Button";
            this.cForm_AddCamera_Button.Size = new System.Drawing.Size(75, 23);
            this.cForm_AddCamera_Button.TabIndex = 2;
            this.cForm_AddCamera_Button.Text = "添加";
            this.cForm_AddCamera_Button.UseVisualStyleBackColor = true;
            this.cForm_AddCamera_Button.Click += new System.EventHandler(this.cForm_AddCamera_Button_Click);
            // 
            // cForm_DeleteCamera_Button
            // 
            this.cForm_DeleteCamera_Button.Location = new System.Drawing.Point(148, 500);
            this.cForm_DeleteCamera_Button.Name = "cForm_DeleteCamera_Button";
            this.cForm_DeleteCamera_Button.Size = new System.Drawing.Size(75, 23);
            this.cForm_DeleteCamera_Button.TabIndex = 2;
            this.cForm_DeleteCamera_Button.Text = "删除";
            this.cForm_DeleteCamera_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_CameraPanel_Panel
            // 
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraType_ComboBox);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraSpeed_ComboBox);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label1);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_AutoCamera_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_DownCamera_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_UpCamera_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_RightCamera_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_LeftCamera_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label15);
            this.cForm_CameraPanel_Panel.Controls.Add(this.btnPTZ);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_Record_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraChannel_Text);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label3);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label13);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_JPEG_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label6);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label2);
            this.cForm_CameraPanel_Panel.Controls.Add(this.label5);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraPort_Text);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraIP_Text);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraName_Text);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_CameraPlay_Picture);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_Preview_Button);
            this.cForm_CameraPanel_Panel.Controls.Add(this.cForm_Login_Button);
            this.cForm_CameraPanel_Panel.Location = new System.Drawing.Point(265, 3);
            this.cForm_CameraPanel_Panel.Name = "cForm_CameraPanel_Panel";
            this.cForm_CameraPanel_Panel.Size = new System.Drawing.Size(828, 550);
            this.cForm_CameraPanel_Panel.TabIndex = 2;
            this.cForm_CameraPanel_Panel.TabStop = false;
            this.cForm_CameraPanel_Panel.Text = "groupBox1";
            // 
            // cForm_CameraType_ComboBox
            // 
            this.cForm_CameraType_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cForm_CameraType_ComboBox.FormattingEnabled = true;
            this.cForm_CameraType_ComboBox.Location = new System.Drawing.Point(664, 199);
            this.cForm_CameraType_ComboBox.Name = "cForm_CameraType_ComboBox";
            this.cForm_CameraType_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.cForm_CameraType_ComboBox.TabIndex = 61;
            // 
            // cForm_CameraSpeed_ComboBox
            // 
            this.cForm_CameraSpeed_ComboBox.FormattingEnabled = true;
            this.cForm_CameraSpeed_ComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cForm_CameraSpeed_ComboBox.Location = new System.Drawing.Point(46, 460);
            this.cForm_CameraSpeed_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_CameraSpeed_ComboBox.Name = "cForm_CameraSpeed_ComboBox";
            this.cForm_CameraSpeed_ComboBox.Size = new System.Drawing.Size(139, 23);
            this.cForm_CameraSpeed_ComboBox.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 423);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "云台速度";
            // 
            // cForm_AutoCamera_Button
            // 
            this.cForm_AutoCamera_Button.Location = new System.Drawing.Point(330, 436);
            this.cForm_AutoCamera_Button.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_AutoCamera_Button.Name = "cForm_AutoCamera_Button";
            this.cForm_AutoCamera_Button.Size = new System.Drawing.Size(69, 41);
            this.cForm_AutoCamera_Button.TabIndex = 57;
            this.cForm_AutoCamera_Button.Text = "Auto";
            this.cForm_AutoCamera_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_DownCamera_Button
            // 
            this.cForm_DownCamera_Button.Location = new System.Drawing.Point(330, 483);
            this.cForm_DownCamera_Button.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_DownCamera_Button.Name = "cForm_DownCamera_Button";
            this.cForm_DownCamera_Button.Size = new System.Drawing.Size(69, 41);
            this.cForm_DownCamera_Button.TabIndex = 56;
            this.cForm_DownCamera_Button.Text = "Down";
            this.cForm_DownCamera_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_UpCamera_Button
            // 
            this.cForm_UpCamera_Button.Location = new System.Drawing.Point(330, 386);
            this.cForm_UpCamera_Button.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_UpCamera_Button.Name = "cForm_UpCamera_Button";
            this.cForm_UpCamera_Button.Size = new System.Drawing.Size(69, 41);
            this.cForm_UpCamera_Button.TabIndex = 55;
            this.cForm_UpCamera_Button.Text = "UP";
            this.cForm_UpCamera_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_RightCamera_Button
            // 
            this.cForm_RightCamera_Button.Location = new System.Drawing.Point(407, 437);
            this.cForm_RightCamera_Button.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_RightCamera_Button.Name = "cForm_RightCamera_Button";
            this.cForm_RightCamera_Button.Size = new System.Drawing.Size(69, 41);
            this.cForm_RightCamera_Button.TabIndex = 54;
            this.cForm_RightCamera_Button.Text = "Right";
            this.cForm_RightCamera_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_LeftCamera_Button
            // 
            this.cForm_LeftCamera_Button.Location = new System.Drawing.Point(252, 437);
            this.cForm_LeftCamera_Button.Margin = new System.Windows.Forms.Padding(4);
            this.cForm_LeftCamera_Button.Name = "cForm_LeftCamera_Button";
            this.cForm_LeftCamera_Button.Size = new System.Drawing.Size(69, 41);
            this.cForm_LeftCamera_Button.TabIndex = 53;
            this.cForm_LeftCamera_Button.Text = "Left";
            this.cForm_LeftCamera_Button.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(645, 768);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 51;
            this.label15.Text = "云台控制";
            // 
            // btnPTZ
            // 
            this.btnPTZ.Location = new System.Drawing.Point(630, 795);
            this.btnPTZ.Name = "btnPTZ";
            this.btnPTZ.Size = new System.Drawing.Size(100, 44);
            this.btnPTZ.TabIndex = 50;
            this.btnPTZ.Text = "PTZ";
            this.btnPTZ.UseVisualStyleBackColor = true;
            // 
            // cForm_Record_Button
            // 
            this.cForm_Record_Button.Location = new System.Drawing.Point(540, 347);
            this.cForm_Record_Button.Name = "cForm_Record_Button";
            this.cForm_Record_Button.Size = new System.Drawing.Size(106, 60);
            this.cForm_Record_Button.TabIndex = 40;
            this.cForm_Record_Button.Text = "录像";
            this.cForm_Record_Button.UseVisualStyleBackColor = true;
            // 
            // cForm_CameraChannel_Text
            // 
            this.cForm_CameraChannel_Text.Location = new System.Drawing.Point(665, 158);
            this.cForm_CameraChannel_Text.Name = "cForm_CameraChannel_Text";
            this.cForm_CameraChannel_Text.Size = new System.Drawing.Size(133, 25);
            this.cForm_CameraChannel_Text.TabIndex = 35;
            this.cForm_CameraChannel_Text.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 48;
            this.label3.Text = "相机种类：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(537, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 15);
            this.label13.TabIndex = 48;
            this.label13.Text = "预览/抓图通道:";
            // 
            // cForm_JPEG_Button
            // 
            this.cForm_JPEG_Button.Location = new System.Drawing.Point(694, 347);
            this.cForm_JPEG_Button.Name = "cForm_JPEG_Button";
            this.cForm_JPEG_Button.Size = new System.Drawing.Size(104, 60);
            this.cForm_JPEG_Button.TabIndex = 39;
            this.cForm_JPEG_Button.Text = "截图";
            this.cForm_JPEG_Button.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 41;
            this.label6.Text = "设备端口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "设备IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 38;
            this.label5.Text = "设备名称";
            // 
            // cForm_CameraPort_Text
            // 
            this.cForm_CameraPort_Text.Location = new System.Drawing.Point(664, 116);
            this.cForm_CameraPort_Text.Name = "cForm_CameraPort_Text";
            this.cForm_CameraPort_Text.Size = new System.Drawing.Size(149, 25);
            this.cForm_CameraPort_Text.TabIndex = 31;
            this.cForm_CameraPort_Text.Text = "8000";
            // 
            // cForm_CameraIP_Text
            // 
            this.cForm_CameraIP_Text.Location = new System.Drawing.Point(664, 77);
            this.cForm_CameraIP_Text.Name = "cForm_CameraIP_Text";
            this.cForm_CameraIP_Text.Size = new System.Drawing.Size(152, 25);
            this.cForm_CameraIP_Text.TabIndex = 30;
            this.cForm_CameraIP_Text.Text = "10.16.4.221";
            // 
            // cForm_CameraName_Text
            // 
            this.cForm_CameraName_Text.Location = new System.Drawing.Point(664, 46);
            this.cForm_CameraName_Text.Name = "cForm_CameraName_Text";
            this.cForm_CameraName_Text.Size = new System.Drawing.Size(152, 25);
            this.cForm_CameraName_Text.TabIndex = 30;
            this.cForm_CameraName_Text.Text = "入口相机";
            // 
            // cForm_CameraPlay_Picture
            // 
            this.cForm_CameraPlay_Picture.BackColor = System.Drawing.SystemColors.WindowText;
            this.cForm_CameraPlay_Picture.Location = new System.Drawing.Point(20, 23);
            this.cForm_CameraPlay_Picture.Name = "cForm_CameraPlay_Picture";
            this.cForm_CameraPlay_Picture.Size = new System.Drawing.Size(457, 340);
            this.cForm_CameraPlay_Picture.TabIndex = 33;
            this.cForm_CameraPlay_Picture.TabStop = false;
            // 
            // cForm_Preview_Button
            // 
            this.cForm_Preview_Button.Location = new System.Drawing.Point(689, 254);
            this.cForm_Preview_Button.Name = "cForm_Preview_Button";
            this.cForm_Preview_Button.Size = new System.Drawing.Size(104, 64);
            this.cForm_Preview_Button.TabIndex = 36;
            this.cForm_Preview_Button.Text = "预览";
            this.cForm_Preview_Button.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cForm_Login_Button
            // 
            this.cForm_Login_Button.Location = new System.Drawing.Point(542, 254);
            this.cForm_Login_Button.Name = "cForm_Login_Button";
            this.cForm_Login_Button.Size = new System.Drawing.Size(104, 64);
            this.cForm_Login_Button.TabIndex = 29;
            this.cForm_Login_Button.Text = "Login";
            this.cForm_Login_Button.Click += new System.EventHandler(this.cForm_Login_Button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 40);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1114, 596);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.cForm_CameraPanel_Panel);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1106, 548);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1106, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机预览";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 511);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1050, 11);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(22, 497);
            this.vScrollBar1.TabIndex = 35;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox6.Location = new System.Drawing.Point(746, 328);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(288, 235);
            this.pictureBox6.TabIndex = 34;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox5.Location = new System.Drawing.Point(406, 328);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(288, 235);
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox3.Location = new System.Drawing.Point(746, 41);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(288, 235);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox4.Location = new System.Drawing.Point(53, 328);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(288, 235);
            this.pictureBox4.TabIndex = 34;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox2.Location = new System.Drawing.Point(406, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(288, 235);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.pictureBox1.Location = new System.Drawing.Point(53, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 235);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // CameraPanel
            // 
            this.ClientSize = new System.Drawing.Size(1123, 601);
            this.Controls.Add(this.tabControl1);
            this.Name = "CameraPanel";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.cForm_CameraPanel_Panel.ResumeLayout(false);
            this.cForm_CameraPanel_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cForm_CameraPlay_Picture)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView cForm_CameraManager_TreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox cForm_CameraPanel_Panel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnPTZ;
        private System.Windows.Forms.Button cForm_Record_Button;
        private System.Windows.Forms.TextBox cForm_CameraChannel_Text;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cForm_JPEG_Button;
        private System.Windows.Forms.PictureBox cForm_CameraPlay_Picture;
        private System.Windows.Forms.Button cForm_Preview_Button;
        private System.Windows.Forms.Button cForm_Login_Button;
        private System.Windows.Forms.ComboBox cForm_CameraSpeed_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cForm_AutoCamera_Button;
        private System.Windows.Forms.Button cForm_DownCamera_Button;
        private System.Windows.Forms.Button cForm_UpCamera_Button;
        private System.Windows.Forms.Button cForm_RightCamera_Button;
        private System.Windows.Forms.Button cForm_LeftCamera_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cForm_CameraPort_Text;
        private System.Windows.Forms.TextBox cForm_CameraName_Text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cForm_CameraIP_Text;
        private System.Windows.Forms.Button cForm_AddCamera_Button;
        private System.Windows.Forms.Button cForm_DeleteCamera_Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cForm_CameraType_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}