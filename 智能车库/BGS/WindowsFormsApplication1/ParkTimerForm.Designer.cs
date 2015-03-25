namespace Cheku
{
    partial class ParkTimerForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pTForm_TimerMode_Combo = new System.Windows.Forms.ComboBox();
            this.dbChargeModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSet = new Cheku.DataBase.dbBGSDataSet();
            this.pTForm_AfterTimerMode_Combo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pTForm_StartTimeMinute_Combo = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.pTForm_EndTimeMinute_Combo = new System.Windows.Forms.ComboBox();
            this.pTForm_EndTimeHour_Combo = new System.Windows.Forms.ComboBox();
            this.pTForm_StartTimeHour_Combo = new System.Windows.Forms.ComboBox();
            this.pTForm_DeleteTimer_Button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dbConfigModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pTForm_ClearTimer_Button = new System.Windows.Forms.Button();
            this.pTForm_AddTimer_Button = new System.Windows.Forms.Button();
            this.pTForm_TimerList_ListBox = new System.Windows.Forms.ListBox();
            this.dbChargeModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter();
            this.dbConfigModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter();
            this.pTForm_Name_Label = new System.Windows.Forms.Label();
            this.dbChargeModeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dbConfigModeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.pTForm_Name_Label);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.pTForm_DeleteTimer_Button);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.pTForm_ClearTimer_Button);
            this.groupBox4.Controls.Add(this.pTForm_AddTimer_Button);
            this.groupBox4.Controls.Add(this.pTForm_TimerList_ListBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(805, 449);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "定时计划";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.pTForm_TimerMode_Combo);
            this.groupBox2.Controls.Add(this.pTForm_AfterTimerMode_Combo);
            this.groupBox2.Location = new System.Drawing.Point(20, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 126);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模式设定";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 30);
            this.label23.TabIndex = 1;
            this.label23.Text = "定时结束后\r\n采用模式:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(22, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 1;
            this.label22.Text = "采用模式:";
            // 
            // pTForm_TimerMode_Combo
            // 
            this.pTForm_TimerMode_Combo.DataSource = this.dbChargeModeBindingSource1;
            this.pTForm_TimerMode_Combo.DisplayMember = "modeName";
            this.pTForm_TimerMode_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_TimerMode_Combo.FormattingEnabled = true;
            this.pTForm_TimerMode_Combo.Location = new System.Drawing.Point(117, 31);
            this.pTForm_TimerMode_Combo.Name = "pTForm_TimerMode_Combo";
            this.pTForm_TimerMode_Combo.Size = new System.Drawing.Size(132, 23);
            this.pTForm_TimerMode_Combo.TabIndex = 4;
            this.pTForm_TimerMode_Combo.ValueMember = "ID";
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
            // pTForm_AfterTimerMode_Combo
            // 
            this.pTForm_AfterTimerMode_Combo.DataSource = this.dbChargeModeBindingSource;
            this.pTForm_AfterTimerMode_Combo.DisplayMember = "modeName";
            this.pTForm_AfterTimerMode_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_AfterTimerMode_Combo.FormattingEnabled = true;
            this.pTForm_AfterTimerMode_Combo.Location = new System.Drawing.Point(117, 81);
            this.pTForm_AfterTimerMode_Combo.Name = "pTForm_AfterTimerMode_Combo";
            this.pTForm_AfterTimerMode_Combo.Size = new System.Drawing.Size(132, 23);
            this.pTForm_AfterTimerMode_Combo.TabIndex = 4;
            this.pTForm_AfterTimerMode_Combo.ValueMember = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.pTForm_StartTimeMinute_Combo);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.pTForm_EndTimeMinute_Combo);
            this.groupBox1.Controls.Add(this.pTForm_EndTimeHour_Combo);
            this.groupBox1.Controls.Add(this.pTForm_StartTimeHour_Combo);
            this.groupBox1.Location = new System.Drawing.Point(20, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 158);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间设定";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 15);
            this.label19.TabIndex = 1;
            this.label19.Text = "开始时间:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "结束时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(165, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "时";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(165, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 15);
            this.label20.TabIndex = 1;
            this.label20.Text = "时";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(248, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 15);
            this.label18.TabIndex = 1;
            this.label18.Text = "分";
            // 
            // pTForm_StartTimeMinute_Combo
            // 
            this.pTForm_StartTimeMinute_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_StartTimeMinute_Combo.FormattingEnabled = true;
            this.pTForm_StartTimeMinute_Combo.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.pTForm_StartTimeMinute_Combo.Location = new System.Drawing.Point(193, 39);
            this.pTForm_StartTimeMinute_Combo.Name = "pTForm_StartTimeMinute_Combo";
            this.pTForm_StartTimeMinute_Combo.Size = new System.Drawing.Size(49, 23);
            this.pTForm_StartTimeMinute_Combo.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(248, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 15);
            this.label21.TabIndex = 1;
            this.label21.Text = "分";
            // 
            // pTForm_EndTimeMinute_Combo
            // 
            this.pTForm_EndTimeMinute_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_EndTimeMinute_Combo.FormattingEnabled = true;
            this.pTForm_EndTimeMinute_Combo.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.pTForm_EndTimeMinute_Combo.Location = new System.Drawing.Point(193, 91);
            this.pTForm_EndTimeMinute_Combo.Name = "pTForm_EndTimeMinute_Combo";
            this.pTForm_EndTimeMinute_Combo.Size = new System.Drawing.Size(49, 23);
            this.pTForm_EndTimeMinute_Combo.TabIndex = 4;
            // 
            // pTForm_EndTimeHour_Combo
            // 
            this.pTForm_EndTimeHour_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_EndTimeHour_Combo.FormattingEnabled = true;
            this.pTForm_EndTimeHour_Combo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.pTForm_EndTimeHour_Combo.Location = new System.Drawing.Point(110, 91);
            this.pTForm_EndTimeHour_Combo.Name = "pTForm_EndTimeHour_Combo";
            this.pTForm_EndTimeHour_Combo.Size = new System.Drawing.Size(49, 23);
            this.pTForm_EndTimeHour_Combo.TabIndex = 4;
            // 
            // pTForm_StartTimeHour_Combo
            // 
            this.pTForm_StartTimeHour_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pTForm_StartTimeHour_Combo.FormattingEnabled = true;
            this.pTForm_StartTimeHour_Combo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.pTForm_StartTimeHour_Combo.Location = new System.Drawing.Point(110, 39);
            this.pTForm_StartTimeHour_Combo.Name = "pTForm_StartTimeHour_Combo";
            this.pTForm_StartTimeHour_Combo.Size = new System.Drawing.Size(49, 23);
            this.pTForm_StartTimeHour_Combo.TabIndex = 4;
            // 
            // pTForm_DeleteTimer_Button
            // 
            this.pTForm_DeleteTimer_Button.Location = new System.Drawing.Point(528, 388);
            this.pTForm_DeleteTimer_Button.Name = "pTForm_DeleteTimer_Button";
            this.pTForm_DeleteTimer_Button.Size = new System.Drawing.Size(69, 55);
            this.pTForm_DeleteTimer_Button.TabIndex = 2;
            this.pTForm_DeleteTimer_Button.Text = "删除";
            this.pTForm_DeleteTimer_Button.UseVisualStyleBackColor = true;
            this.pTForm_DeleteTimer_Button.Click += new System.EventHandler(this.pTForm_DeleteTimer_Button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.dbConfigModeBindingSource;
            this.comboBox1.DisplayMember = "modeName";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 388);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.Visible = false;
            // 
            // dbConfigModeBindingSource
            // 
            this.dbConfigModeBindingSource.DataMember = "dbConfigMode";
            this.dbConfigModeBindingSource.DataSource = this.dbBGSDataSet;
            // 
            // pTForm_ClearTimer_Button
            // 
            this.pTForm_ClearTimer_Button.Location = new System.Drawing.Point(650, 388);
            this.pTForm_ClearTimer_Button.Name = "pTForm_ClearTimer_Button";
            this.pTForm_ClearTimer_Button.Size = new System.Drawing.Size(69, 55);
            this.pTForm_ClearTimer_Button.TabIndex = 2;
            this.pTForm_ClearTimer_Button.Text = "清除";
            this.pTForm_ClearTimer_Button.UseVisualStyleBackColor = true;
            this.pTForm_ClearTimer_Button.Click += new System.EventHandler(this.pTForm_ClearTimer_Button_Click);
            // 
            // pTForm_AddTimer_Button
            // 
            this.pTForm_AddTimer_Button.Location = new System.Drawing.Point(325, 201);
            this.pTForm_AddTimer_Button.Name = "pTForm_AddTimer_Button";
            this.pTForm_AddTimer_Button.Size = new System.Drawing.Size(118, 55);
            this.pTForm_AddTimer_Button.TabIndex = 2;
            this.pTForm_AddTimer_Button.Text = "加入计划==>";
            this.pTForm_AddTimer_Button.UseVisualStyleBackColor = true;
            this.pTForm_AddTimer_Button.Click += new System.EventHandler(this.pTForm_AddTimer_Button_Click);
            // 
            // pTForm_TimerList_ListBox
            // 
            this.pTForm_TimerList_ListBox.FormattingEnabled = true;
            this.pTForm_TimerList_ListBox.ItemHeight = 15;
            this.pTForm_TimerList_ListBox.Location = new System.Drawing.Point(449, 52);
            this.pTForm_TimerList_ListBox.Name = "pTForm_TimerList_ListBox";
            this.pTForm_TimerList_ListBox.Size = new System.Drawing.Size(328, 334);
            this.pTForm_TimerList_ListBox.TabIndex = 3;
            // 
            // dbChargeModeTableAdapter
            // 
            this.dbChargeModeTableAdapter.ClearBeforeFill = true;
            // 
            // dbConfigModeTableAdapter
            // 
            this.dbConfigModeTableAdapter.ClearBeforeFill = true;
            // 
            // pTForm_Name_Label
            // 
            this.pTForm_Name_Label.AutoSize = true;
            this.pTForm_Name_Label.Location = new System.Drawing.Point(21, 23);
            this.pTForm_Name_Label.Name = "pTForm_Name_Label";
            this.pTForm_Name_Label.Size = new System.Drawing.Size(55, 15);
            this.pTForm_Name_Label.TabIndex = 7;
            this.pTForm_Name_Label.Text = "label1";
            // 
            // dbChargeModeBindingSource1
            // 
            this.dbChargeModeBindingSource1.DataMember = "dbChargeMode";
            this.dbChargeModeBindingSource1.DataSource = this.dbBGSDataSet;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.dbConfigModeBindingSource1;
            this.comboBox2.DisplayMember = "modeName";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(137, 388);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 23);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.ValueMember = "ID";
            this.comboBox2.Visible = false;
            // 
            // dbConfigModeBindingSource1
            // 
            this.dbConfigModeBindingSource1.DataMember = "dbConfigMode";
            this.dbConfigModeBindingSource1.DataSource = this.dbBGSDataSet;
            // 
            // ParkTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 496);
            this.Controls.Add(this.groupBox4);
            this.Name = "ParkTimerForm";
            this.Text = "Form1";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button pTForm_DeleteTimer_Button;
        private System.Windows.Forms.Button pTForm_ClearTimer_Button;
        private System.Windows.Forms.Button pTForm_AddTimer_Button;
        private System.Windows.Forms.ListBox pTForm_TimerList_ListBox;
        private System.Windows.Forms.ComboBox pTForm_StartTimeMinute_Combo;
        private System.Windows.Forms.ComboBox pTForm_EndTimeMinute_Combo;
        private System.Windows.Forms.ComboBox pTForm_StartTimeHour_Combo;
        private System.Windows.Forms.ComboBox pTForm_AfterTimerMode_Combo;
        private System.Windows.Forms.ComboBox pTForm_TimerMode_Combo;
        private System.Windows.Forms.ComboBox pTForm_EndTimeHour_Combo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private DataBase.dbBGSDataSet dbBGSDataSet;
        private System.Windows.Forms.BindingSource dbChargeModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter dbChargeModeTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource dbConfigModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter dbConfigModeTableAdapter;
        private System.Windows.Forms.Label pTForm_Name_Label;
        private System.Windows.Forms.BindingSource dbChargeModeBindingSource1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource dbConfigModeBindingSource1;

    }
}