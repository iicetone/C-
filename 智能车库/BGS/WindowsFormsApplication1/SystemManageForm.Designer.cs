using System.Drawing;
using System.Windows.Forms;

namespace Cheku
{
    partial class SystemManageForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.manageForm_SavaChargeModeButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.manageForm_ChargeModeNameCombo = new System.Windows.Forms.ComboBox();
            this.dbChargeModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSet = new Cheku.DataBase.dbBGSDataSet();
            this.manageForm_ChargeModeRenameText = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chargeMode_TCUnitPayValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chargeMode_TCUnitValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chargeMode_EnableTCValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chargeMode_PCUnitPayValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chargeMode_PCUnitValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chargeMode_EnablePCValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chargeMode_EnableFCValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chargeMode_EnableMCValue_ComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manageForm_SavaSettingButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.manageForm_SettingRenameText = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.manageForm_enableBGSCombo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.manageForm_enableBGStopCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.manageForm_ModeNameCombo = new System.Windows.Forms.ComboBox();
            this.dbConfigModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.manageForm_enableManualCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.manageForm_enableCameraCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manageForm_enableBGOffCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.manageForm_enableBGOnCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.manageForm_enableCSenderCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.manageForm_enableCReaderCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.manageForm_Rs485PortCombo = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.manageForm_ChannelApplyButton = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.manageForm_ServerAddrText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.manageForm_SystemModeCombo = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dbBGSDataSetBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dbBGSDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dbConfigModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dbChargeModeTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.manageForm_SavaChargeModeButton);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "收费模式";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // manageForm_SavaChargeModeButton
            // 
            this.manageForm_SavaChargeModeButton.Location = new System.Drawing.Point(8, 311);
            this.manageForm_SavaChargeModeButton.Name = "manageForm_SavaChargeModeButton";
            this.manageForm_SavaChargeModeButton.Size = new System.Drawing.Size(133, 23);
            this.manageForm_SavaChargeModeButton.TabIndex = 8;
            this.manageForm_SavaChargeModeButton.Text = "保存收费模式";
            this.manageForm_SavaChargeModeButton.UseVisualStyleBackColor = true;
            this.manageForm_SavaChargeModeButton.Click += new System.EventHandler(this.manageForm_SavaChargeModeButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(501, 311);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(400, 311);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "确定";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.manageForm_ChargeModeNameCombo);
            this.groupBox2.Controls.Add(this.manageForm_ChargeModeRenameText);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.chargeMode_TCUnitPayValue_ComboBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.chargeMode_TCUnitValue_ComboBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.chargeMode_EnableTCValue_ComboBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.chargeMode_PCUnitPayValue_ComboBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chargeMode_PCUnitValue_ComboBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.chargeMode_EnablePCValue_ComboBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chargeMode_EnableFCValue_ComboBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.chargeMode_EnableMCValue_ComboBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 288);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // manageForm_ChargeModeNameCombo
            // 
            this.manageForm_ChargeModeNameCombo.DataSource = this.dbChargeModeBindingSource;
            this.manageForm_ChargeModeNameCombo.DisplayMember = "modeName";
            this.manageForm_ChargeModeNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_ChargeModeNameCombo.FormattingEnabled = true;
            this.manageForm_ChargeModeNameCombo.Location = new System.Drawing.Point(135, 60);
            this.manageForm_ChargeModeNameCombo.Name = "manageForm_ChargeModeNameCombo";
            this.manageForm_ChargeModeNameCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_ChargeModeNameCombo.TabIndex = 27;
            this.manageForm_ChargeModeNameCombo.ValueMember = "ID";
            this.manageForm_ChargeModeNameCombo.SelectedIndexChanged += new System.EventHandler(this.manageForm_ChargeModeNameCombo_SelectedIndexChanged);
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
            // manageForm_ChargeModeRenameText
            // 
            this.manageForm_ChargeModeRenameText.Location = new System.Drawing.Point(432, 58);
            this.manageForm_ChargeModeRenameText.MaxLength = 10;
            this.manageForm_ChargeModeRenameText.Name = "manageForm_ChargeModeRenameText";
            this.manageForm_ChargeModeRenameText.Size = new System.Drawing.Size(100, 25);
            this.manageForm_ChargeModeRenameText.TabIndex = 26;
            this.manageForm_ChargeModeRenameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.manageForm_ChargeModeRenameText_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(305, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 15);
            this.label20.TabIndex = 25;
            this.label20.Text = "新名称";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(305, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "临时卡单位收费";
            // 
            // chargeMode_TCUnitPayValue_ComboBox
            // 
            this.chargeMode_TCUnitPayValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_TCUnitPayValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_TCUnitPayValue_ComboBox.Location = new System.Drawing.Point(432, 237);
            this.chargeMode_TCUnitPayValue_ComboBox.Name = "chargeMode_TCUnitPayValue_ComboBox";
            this.chargeMode_TCUnitPayValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_TCUnitPayValue_ComboBox.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(305, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 15);
            this.label16.TabIndex = 22;
            this.label16.Text = "临时卡时间单位";
            // 
            // chargeMode_TCUnitValue_ComboBox
            // 
            this.chargeMode_TCUnitValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_TCUnitValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_TCUnitValue_ComboBox.Location = new System.Drawing.Point(432, 196);
            this.chargeMode_TCUnitValue_ComboBox.Name = "chargeMode_TCUnitValue_ComboBox";
            this.chargeMode_TCUnitValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_TCUnitValue_ComboBox.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "允许临时卡";
            // 
            // chargeMode_EnableTCValue_ComboBox
            // 
            this.chargeMode_EnableTCValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_EnableTCValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_EnableTCValue_ComboBox.Location = new System.Drawing.Point(137, 232);
            this.chargeMode_EnableTCValue_ComboBox.Name = "chargeMode_EnableTCValue_ComboBox";
            this.chargeMode_EnableTCValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_EnableTCValue_ComboBox.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "充值卡单位收费";
            // 
            // chargeMode_PCUnitPayValue_ComboBox
            // 
            this.chargeMode_PCUnitPayValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_PCUnitPayValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_PCUnitPayValue_ComboBox.Location = new System.Drawing.Point(432, 152);
            this.chargeMode_PCUnitPayValue_ComboBox.Name = "chargeMode_PCUnitPayValue_ComboBox";
            this.chargeMode_PCUnitPayValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_PCUnitPayValue_ComboBox.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "充值卡时间单位";
            // 
            // chargeMode_PCUnitValue_ComboBox
            // 
            this.chargeMode_PCUnitValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_PCUnitValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_PCUnitValue_ComboBox.Location = new System.Drawing.Point(432, 111);
            this.chargeMode_PCUnitValue_ComboBox.Name = "chargeMode_PCUnitValue_ComboBox";
            this.chargeMode_PCUnitValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_PCUnitValue_ComboBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "收费模式";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "允许充值卡";
            // 
            // chargeMode_EnablePCValue_ComboBox
            // 
            this.chargeMode_EnablePCValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_EnablePCValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_EnablePCValue_ComboBox.Location = new System.Drawing.Point(135, 193);
            this.chargeMode_EnablePCValue_ComboBox.Name = "chargeMode_EnablePCValue_ComboBox";
            this.chargeMode_EnablePCValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_EnablePCValue_ComboBox.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "允许免费卡";
            // 
            // chargeMode_EnableFCValue_ComboBox
            // 
            this.chargeMode_EnableFCValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_EnableFCValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_EnableFCValue_ComboBox.Location = new System.Drawing.Point(135, 152);
            this.chargeMode_EnableFCValue_ComboBox.Name = "chargeMode_EnableFCValue_ComboBox";
            this.chargeMode_EnableFCValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_EnableFCValue_ComboBox.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "允许月卡";
            // 
            // chargeMode_EnableMCValue_ComboBox
            // 
            this.chargeMode_EnableMCValue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chargeMode_EnableMCValue_ComboBox.FormattingEnabled = true;
            this.chargeMode_EnableMCValue_ComboBox.Location = new System.Drawing.Point(135, 111);
            this.chargeMode_EnableMCValue_ComboBox.Name = "chargeMode_EnableMCValue_ComboBox";
            this.chargeMode_EnableMCValue_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.chargeMode_EnableMCValue_ComboBox.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manageForm_SavaSettingButton);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(613, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "道闸模式";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manageForm_SavaSettingButton
            // 
            this.manageForm_SavaSettingButton.Location = new System.Drawing.Point(8, 311);
            this.manageForm_SavaSettingButton.Name = "manageForm_SavaSettingButton";
            this.manageForm_SavaSettingButton.Size = new System.Drawing.Size(133, 23);
            this.manageForm_SavaSettingButton.TabIndex = 5;
            this.manageForm_SavaSettingButton.Text = "保存道闸模式";
            this.manageForm_SavaSettingButton.UseVisualStyleBackColor = true;
            this.manageForm_SavaSettingButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(503, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.manageForm_SettingRenameText);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.manageForm_enableBGSCombo);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.manageForm_enableBGStopCombo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.manageForm_ModeNameCombo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.manageForm_enableManualCombo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.manageForm_enableCameraCombo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.manageForm_enableBGOffCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.manageForm_enableBGOnCombo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.manageForm_enableCSenderCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.manageForm_enableCReaderCombo);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 288);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(318, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 15);
            this.label19.TabIndex = 20;
            this.label19.Text = "新名称:";
            // 
            // manageForm_SettingRenameText
            // 
            this.manageForm_SettingRenameText.Location = new System.Drawing.Point(439, 58);
            this.manageForm_SettingRenameText.MaxLength = 10;
            this.manageForm_SettingRenameText.Name = "manageForm_SettingRenameText";
            this.manageForm_SettingRenameText.Size = new System.Drawing.Size(100, 25);
            this.manageForm_SettingRenameText.TabIndex = 19;
            this.manageForm_SettingRenameText.TextChanged += new System.EventHandler(this.manageForm_SettingRenameText_TextChanged);
            this.manageForm_SettingRenameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.manageForm_SettingRenameText_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 15);
            this.label18.TabIndex = 18;
            this.label18.Text = "允许通道";
            // 
            // manageForm_enableBGSCombo
            // 
            this.manageForm_enableBGSCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableBGSCombo.FormattingEnabled = true;
            this.manageForm_enableBGSCombo.Location = new System.Drawing.Point(135, 116);
            this.manageForm_enableBGSCombo.Name = "manageForm_enableBGSCombo";
            this.manageForm_enableBGSCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableBGSCombo.TabIndex = 17;
            this.manageForm_enableBGSCombo.SelectedIndexChanged += new System.EventHandler(this.manageForm_enableBGSCombo_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(318, 244);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 15);
            this.label17.TabIndex = 16;
            this.label17.Text = "允许停止道闸";
            // 
            // manageForm_enableBGStopCombo
            // 
            this.manageForm_enableBGStopCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableBGStopCombo.FormattingEnabled = true;
            this.manageForm_enableBGStopCombo.Location = new System.Drawing.Point(439, 244);
            this.manageForm_enableBGStopCombo.Name = "manageForm_enableBGStopCombo";
            this.manageForm_enableBGStopCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableBGStopCombo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "道闸模式";
            // 
            // manageForm_ModeNameCombo
            // 
            this.manageForm_ModeNameCombo.DataSource = this.dbConfigModeBindingSource;
            this.manageForm_ModeNameCombo.DisplayMember = "modeName";
            this.manageForm_ModeNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_ModeNameCombo.FormattingEnabled = true;
            this.manageForm_ModeNameCombo.Location = new System.Drawing.Point(135, 61);
            this.manageForm_ModeNameCombo.Name = "manageForm_ModeNameCombo";
            this.manageForm_ModeNameCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_ModeNameCombo.TabIndex = 13;
            this.manageForm_ModeNameCombo.ValueMember = "ID";
            this.manageForm_ModeNameCombo.SelectedIndexChanged += new System.EventHandler(this.manageForm_ModeNameCombo_SelectedIndexChanged);
            // 
            // dbConfigModeBindingSource
            // 
            this.dbConfigModeBindingSource.DataMember = "dbConfigMode";
            this.dbConfigModeBindingSource.DataSource = this.dbBGSDataSet;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "允许手动开闸";
            // 
            // manageForm_enableManualCombo
            // 
            this.manageForm_enableManualCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableManualCombo.FormattingEnabled = true;
            this.manageForm_enableManualCombo.Location = new System.Drawing.Point(439, 121);
            this.manageForm_enableManualCombo.Name = "manageForm_enableManualCombo";
            this.manageForm_enableManualCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableManualCombo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "摄像头开启";
            // 
            // manageForm_enableCameraCombo
            // 
            this.manageForm_enableCameraCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableCameraCombo.FormattingEnabled = true;
            this.manageForm_enableCameraCombo.Location = new System.Drawing.Point(135, 236);
            this.manageForm_enableCameraCombo.Name = "manageForm_enableCameraCombo";
            this.manageForm_enableCameraCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableCameraCombo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "允许关闭道闸";
            // 
            // manageForm_enableBGOffCombo
            // 
            this.manageForm_enableBGOffCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableBGOffCombo.FormattingEnabled = true;
            this.manageForm_enableBGOffCombo.Location = new System.Drawing.Point(439, 203);
            this.manageForm_enableBGOffCombo.Name = "manageForm_enableBGOffCombo";
            this.manageForm_enableBGOffCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableBGOffCombo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "允许开启道闸";
            // 
            // manageForm_enableBGOnCombo
            // 
            this.manageForm_enableBGOnCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableBGOnCombo.FormattingEnabled = true;
            this.manageForm_enableBGOnCombo.Location = new System.Drawing.Point(439, 162);
            this.manageForm_enableBGOnCombo.Name = "manageForm_enableBGOnCombo";
            this.manageForm_enableBGOnCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableBGOnCombo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "允许发卡";
            // 
            // manageForm_enableCSenderCombo
            // 
            this.manageForm_enableCSenderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableCSenderCombo.FormattingEnabled = true;
            this.manageForm_enableCSenderCombo.Location = new System.Drawing.Point(135, 192);
            this.manageForm_enableCSenderCombo.Name = "manageForm_enableCSenderCombo";
            this.manageForm_enableCSenderCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableCSenderCombo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "允许读卡";
            // 
            // manageForm_enableCReaderCombo
            // 
            this.manageForm_enableCReaderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_enableCReaderCombo.FormattingEnabled = true;
            this.manageForm_enableCReaderCombo.Location = new System.Drawing.Point(135, 151);
            this.manageForm_enableCReaderCombo.Name = "manageForm_enableCReaderCombo";
            this.manageForm_enableCReaderCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_enableCReaderCombo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 402);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(613, 373);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "定时计划";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(613, 373);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "配置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.manageForm_Rs485PortCombo);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.manageForm_ChannelApplyButton);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.manageForm_ServerAddrText);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.manageForm_SystemModeCombo);
            this.groupBox3.Location = new System.Drawing.Point(8, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(588, 345);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // manageForm_Rs485PortCombo
            // 
            this.manageForm_Rs485PortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_Rs485PortCombo.FormattingEnabled = true;
            this.manageForm_Rs485PortCombo.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.manageForm_Rs485PortCombo.Location = new System.Drawing.Point(100, 152);
            this.manageForm_Rs485PortCombo.Name = "manageForm_Rs485PortCombo";
            this.manageForm_Rs485PortCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_Rs485PortCombo.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 155);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 15);
            this.label24.TabIndex = 13;
            this.label24.Text = "串口号:";
            // 
            // manageForm_ChannelApplyButton
            // 
            this.manageForm_ChannelApplyButton.Location = new System.Drawing.Point(439, 38);
            this.manageForm_ChannelApplyButton.Name = "manageForm_ChannelApplyButton";
            this.manageForm_ChannelApplyButton.Size = new System.Drawing.Size(122, 73);
            this.manageForm_ChannelApplyButton.TabIndex = 12;
            this.manageForm_ChannelApplyButton.Text = "从主机获取配置";
            this.manageForm_ChannelApplyButton.UseVisualStyleBackColor = true;
            this.manageForm_ChannelApplyButton.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(236, 106);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(181, 15);
            this.label23.TabIndex = 11;
            this.label23.Text = "(格式:000.000.000.000)";
            // 
            // manageForm_ServerAddrText
            // 
            this.manageForm_ServerAddrText.Location = new System.Drawing.Point(100, 100);
            this.manageForm_ServerAddrText.Name = "manageForm_ServerAddrText";
            this.manageForm_ServerAddrText.Size = new System.Drawing.Size(121, 25);
            this.manageForm_ServerAddrText.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(486, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(385, 305);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "确定";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 106);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "主机地址:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "模式选择:";
            // 
            // manageForm_SystemModeCombo
            // 
            this.manageForm_SystemModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageForm_SystemModeCombo.FormattingEnabled = true;
            this.manageForm_SystemModeCombo.Location = new System.Drawing.Point(100, 35);
            this.manageForm_SystemModeCombo.Name = "manageForm_SystemModeCombo";
            this.manageForm_SystemModeCombo.Size = new System.Drawing.Size(121, 23);
            this.manageForm_SystemModeCombo.TabIndex = 2;
            this.manageForm_SystemModeCombo.SelectedIndexChanged += new System.EventHandler(this.manageForm_SystemModeCombo_SelectedIndexChanged);
            // 
            // dbBGSDataSetBindingSource3
            // 
            this.dbBGSDataSetBindingSource3.DataSource = this.dbBGSDataSet;
            this.dbBGSDataSetBindingSource3.Position = 0;
            // 
            // dbBGSDataSetBindingSource
            // 
            this.dbBGSDataSetBindingSource.DataSource = this.dbBGSDataSet;
            this.dbBGSDataSetBindingSource.Position = 0;
            // 
            // dbBGSDataSetBindingSource1
            // 
            this.dbBGSDataSetBindingSource1.DataSource = this.dbBGSDataSet;
            this.dbBGSDataSetBindingSource1.Position = 0;
            // 
            // dbBGSDataSetBindingSource2
            // 
            this.dbBGSDataSetBindingSource2.DataSource = this.dbBGSDataSet;
            this.dbBGSDataSetBindingSource2.Position = 0;
            // 
            // dbConfigModeTableAdapter
            // 
            this.dbConfigModeTableAdapter.ClearBeforeFill = true;
            // 
            // dbChargeModeTableAdapter
            // 
            this.dbChargeModeTableAdapter.ClearBeforeFill = true;
            // 
            // SystemManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 402);
            this.Controls.Add(this.tabControl1);
            this.Name = "SystemManageForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbChargeModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbConfigModeBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Rectangle tabArea;  
        private RectangleF tabTextArea;  

        private void Form1_Load(object sender, System.EventArgs e)
        {
            TabSetMode();

        }

        /// <summary>  
        /// 设定控件绘制模式  
        /// </summary>  
        private void TabSetMode()
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Alignment = TabAlignment.Left;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            tabArea = tabControl1.GetTabRect(e.Index);
            tabTextArea = tabArea;
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font font = this.tabControl1.Font;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);
        }
        private TabPage tabPage2;
        private TabPage tabPage1;
        private Button manageForm_SavaSettingButton;
        private Button button2;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox manageForm_enableCReaderCombo;
        private Button button1;
        private TabControl tabControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label2;
        private ComboBox manageForm_enableCSenderCombo;
        private Label label4;
        private ComboBox manageForm_enableBGOffCombo;
        private Label label3;
        private ComboBox manageForm_enableBGOnCombo;
        private Label label7;
        private ComboBox manageForm_ModeNameCombo;
        private Label label6;
        private ComboBox manageForm_enableManualCombo;
        private Label label5;
        private ComboBox manageForm_enableCameraCombo;
        private Button manageForm_SavaChargeModeButton;
        private Button button5;
        private Button button6;
        private GroupBox groupBox2;
        private Label label11;
        private ComboBox chargeMode_PCUnitPayValue_ComboBox;
        private Label label10;
        private ComboBox chargeMode_PCUnitValue_ComboBox;
        private Label label8;
        private Label label9;
        private ComboBox chargeMode_EnablePCValue_ComboBox;
        private Label label13;
        private ComboBox chargeMode_EnableFCValue_ComboBox;
        private Label label14;
        private ComboBox chargeMode_EnableMCValue_ComboBox;
        private Label label15;
        private ComboBox chargeMode_TCUnitPayValue_ComboBox;
        private Label label16;
        private ComboBox chargeMode_TCUnitValue_ComboBox;
        private Label label12;
        private ComboBox chargeMode_EnableTCValue_ComboBox;
        private TabPage tabPage3;
        private Label label18;
        private ComboBox manageForm_enableBGSCombo;
        private Label label17;
        private ComboBox manageForm_enableBGStopCombo;
        private BindingSource dbBGSDataSetBindingSource;
        private DataBase.dbBGSDataSet dbBGSDataSet;
        private BindingSource dbBGSDataSetBindingSource1;
        private BindingSource dbBGSDataSetBindingSource3;
        private BindingSource dbBGSDataSetBindingSource2;
        private BindingSource dbConfigModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbConfigModeTableAdapter dbConfigModeTableAdapter;
        private ColorDialog colorDialog1;
        private Label label19;
        private TextBox manageForm_SettingRenameText;
        private TextBox manageForm_ChargeModeRenameText;
        private Label label20;
        private BindingSource dbChargeModeBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbChargeModeTableAdapter dbChargeModeTableAdapter;
        private ComboBox manageForm_ChargeModeNameCombo;
        private TabPage tabPage4;
        private GroupBox groupBox3;
        private Button button4;
        private Button button7;
        private Label label21;
        private ComboBox manageForm_SystemModeCombo;
        private Label label23;
        private TextBox manageForm_ServerAddrText;
        private Label label22;
        private Button manageForm_ChannelApplyButton;
        private ComboBox manageForm_Rs485PortCombo;
        private Label label24;  
    }
}