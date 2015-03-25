namespace Cheku
{
    partial class HistoryForm
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
            this.dbBGSDataSet = new Cheku.DataBase.dbBGSDataSet();
            this.dbBGSDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbVehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbVehicleTableAdapter = new Cheku.DataBase.dbBGSDataSetTableAdapters.dbVehicleTableAdapter();
            this.hist_HistList_ListView = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hist_Clear_Button = new System.Windows.Forms.Button();
            this.hist_Refresh_Button = new System.Windows.Forms.Button();
            this.hist_Select_Button = new System.Windows.Forms.Button();
            this.hist_Select_Text = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hist_Pic_PictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hist_CarType_Text = new System.Windows.Forms.TextBox();
            this.hist_Cardlic_Text = new System.Windows.Forms.TextBox();
            this.hist_TF_Text = new System.Windows.Forms.TextBox();
            this.hist_CardType_Text = new System.Windows.Forms.TextBox();
            this.hist_CardName_Text = new System.Windows.Forms.TextBox();
            this.hist_CardPhone_Text = new System.Windows.Forms.TextBox();
            this.hist_CardID_Text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVehicleBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hist_Pic_PictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbBGSDataSet
            // 
            this.dbBGSDataSet.DataSetName = "dbBGSDataSet";
            this.dbBGSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbBGSDataSetBindingSource
            // 
            this.dbBGSDataSetBindingSource.DataSource = this.dbBGSDataSet;
            this.dbBGSDataSetBindingSource.Position = 0;
            // 
            // dbVehicleBindingSource
            // 
            this.dbVehicleBindingSource.DataMember = "dbVehicle";
            this.dbVehicleBindingSource.DataSource = this.dbBGSDataSetBindingSource;
            // 
            // dbVehicleTableAdapter
            // 
            this.dbVehicleTableAdapter.ClearBeforeFill = true;
            // 
            // hist_HistList_ListView
            // 
            this.hist_HistList_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.hist_HistList_ListView.FullRowSelect = true;
            this.hist_HistList_ListView.GridLines = true;
            this.hist_HistList_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.hist_HistList_ListView.HideSelection = false;
            this.hist_HistList_ListView.Location = new System.Drawing.Point(13, 59);
            this.hist_HistList_ListView.MultiSelect = false;
            this.hist_HistList_ListView.Name = "hist_HistList_ListView";
            this.hist_HistList_ListView.Size = new System.Drawing.Size(1168, 336);
            this.hist_HistList_ListView.TabIndex = 6;
            this.hist_HistList_ListView.UseCompatibleStateImageBehavior = false;
            this.hist_HistList_ListView.View = System.Windows.Forms.View.Details;
            this.hist_HistList_ListView.SelectedIndexChanged += new System.EventHandler(this.hist_HistList_ListView_SelectedIndexChanged);
            this.hist_HistList_ListView.Click += new System.EventHandler(this.hist_HistList_ListView_Click);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "时间";
            this.columnHeader0.Width = 192;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "卡号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 112;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "车型";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 111;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "车牌";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 143;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "姓名";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 112;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "电话";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 124;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "行为";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 248;
            // 
            // hist_Clear_Button
            // 
            this.hist_Clear_Button.Location = new System.Drawing.Point(1086, 21);
            this.hist_Clear_Button.Name = "hist_Clear_Button";
            this.hist_Clear_Button.Size = new System.Drawing.Size(90, 33);
            this.hist_Clear_Button.TabIndex = 1;
            this.hist_Clear_Button.Text = "清空";
            this.hist_Clear_Button.UseVisualStyleBackColor = true;
            this.hist_Clear_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // hist_Refresh_Button
            // 
            this.hist_Refresh_Button.Location = new System.Drawing.Point(976, 21);
            this.hist_Refresh_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hist_Refresh_Button.Name = "hist_Refresh_Button";
            this.hist_Refresh_Button.Size = new System.Drawing.Size(94, 31);
            this.hist_Refresh_Button.TabIndex = 1;
            this.hist_Refresh_Button.Text = "刷新";
            this.hist_Refresh_Button.UseVisualStyleBackColor = true;
            this.hist_Refresh_Button.Click += new System.EventHandler(this.hist_Refresh_Button_Click);
            // 
            // hist_Select_Button
            // 
            this.hist_Select_Button.Location = new System.Drawing.Point(865, 21);
            this.hist_Select_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hist_Select_Button.Name = "hist_Select_Button";
            this.hist_Select_Button.Size = new System.Drawing.Size(94, 31);
            this.hist_Select_Button.TabIndex = 1;
            this.hist_Select_Button.Text = "查找";
            this.hist_Select_Button.UseVisualStyleBackColor = true;
            this.hist_Select_Button.Click += new System.EventHandler(this.hist_Select_Button_Click);
            // 
            // hist_Select_Text
            // 
            this.hist_Select_Text.FormattingEnabled = true;
            this.hist_Select_Text.Location = new System.Drawing.Point(554, 24);
            this.hist_Select_Text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hist_Select_Text.Name = "hist_Select_Text";
            this.hist_Select_Text.Size = new System.Drawing.Size(284, 23);
            this.hist_Select_Text.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.hist_Refresh_Button);
            this.panel1.Controls.Add(this.hist_Clear_Button);
            this.panel1.Controls.Add(this.hist_HistList_ListView);
            this.panel1.Controls.Add(this.hist_Select_Text);
            this.panel1.Controls.Add(this.hist_Select_Button);
            this.panel1.Location = new System.Drawing.Point(5, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 414);
            this.panel1.TabIndex = 22;
            // 
            // hist_Pic_PictureBox
            // 
            this.hist_Pic_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hist_Pic_PictureBox.Location = new System.Drawing.Point(12, 12);
            this.hist_Pic_PictureBox.Name = "hist_Pic_PictureBox";
            this.hist_Pic_PictureBox.Size = new System.Drawing.Size(283, 225);
            this.hist_Pic_PictureBox.TabIndex = 23;
            this.hist_Pic_PictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hist_CarType_Text);
            this.groupBox2.Controls.Add(this.hist_Cardlic_Text);
            this.groupBox2.Controls.Add(this.hist_TF_Text);
            this.groupBox2.Controls.Add(this.hist_CardType_Text);
            this.groupBox2.Controls.Add(this.hist_CardName_Text);
            this.groupBox2.Controls.Add(this.hist_CardPhone_Text);
            this.groupBox2.Controls.Add(this.hist_CardID_Text);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(317, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 225);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编辑用户";
            // 
            // hist_CarType_Text
            // 
            this.hist_CarType_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_CarType_Text.Enabled = false;
            this.hist_CarType_Text.Location = new System.Drawing.Point(326, 80);
            this.hist_CarType_Text.Name = "hist_CarType_Text";
            this.hist_CarType_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_CarType_Text.TabIndex = 23;
            // 
            // hist_Cardlic_Text
            // 
            this.hist_Cardlic_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_Cardlic_Text.Enabled = false;
            this.hist_Cardlic_Text.Location = new System.Drawing.Point(326, 29);
            this.hist_Cardlic_Text.Name = "hist_Cardlic_Text";
            this.hist_Cardlic_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_Cardlic_Text.TabIndex = 23;
            // 
            // hist_TF_Text
            // 
            this.hist_TF_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_TF_Text.Enabled = false;
            this.hist_TF_Text.Location = new System.Drawing.Point(576, 81);
            this.hist_TF_Text.Name = "hist_TF_Text";
            this.hist_TF_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_TF_Text.TabIndex = 23;
            // 
            // hist_CardType_Text
            // 
            this.hist_CardType_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_CardType_Text.Enabled = false;
            this.hist_CardType_Text.Location = new System.Drawing.Point(87, 129);
            this.hist_CardType_Text.Name = "hist_CardType_Text";
            this.hist_CardType_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_CardType_Text.TabIndex = 23;
            // 
            // hist_CardName_Text
            // 
            this.hist_CardName_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_CardName_Text.Enabled = false;
            this.hist_CardName_Text.Location = new System.Drawing.Point(87, 80);
            this.hist_CardName_Text.Name = "hist_CardName_Text";
            this.hist_CardName_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_CardName_Text.TabIndex = 23;
            // 
            // hist_CardPhone_Text
            // 
            this.hist_CardPhone_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_CardPhone_Text.Enabled = false;
            this.hist_CardPhone_Text.Location = new System.Drawing.Point(576, 30);
            this.hist_CardPhone_Text.Name = "hist_CardPhone_Text";
            this.hist_CardPhone_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_CardPhone_Text.TabIndex = 23;
            // 
            // hist_CardID_Text
            // 
            this.hist_CardID_Text.BackColor = System.Drawing.SystemColors.Info;
            this.hist_CardID_Text.Enabled = false;
            this.hist_CardID_Text.Location = new System.Drawing.Point(87, 32);
            this.hist_CardID_Text.Name = "hist_CardID_Text";
            this.hist_CardID_Text.Size = new System.Drawing.Size(121, 25);
            this.hist_CardID_Text.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "是否入库:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "车型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "车牌号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "卡片类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "车主电话:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "卡号:";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "车场名称";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 250;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "通道名称";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 250;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1198, 668);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hist_Pic_PictureBox);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryForm";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBGSDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVehicleBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hist_Pic_PictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dbBGSDataSetBindingSource;
        private DataBase.dbBGSDataSet dbBGSDataSet;
        private System.Windows.Forms.BindingSource dbVehicleBindingSource;
        private DataBase.dbBGSDataSetTableAdapters.dbVehicleTableAdapter dbVehicleTableAdapter;
        private System.Windows.Forms.ListView hist_HistList_ListView;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button hist_Clear_Button;
        private System.Windows.Forms.Button hist_Refresh_Button;
        private System.Windows.Forms.Button hist_Select_Button;
        private System.Windows.Forms.ComboBox hist_Select_Text;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox hist_Pic_PictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox hist_Cardlic_Text;
        private System.Windows.Forms.TextBox hist_CardName_Text;
        private System.Windows.Forms.TextBox hist_CardPhone_Text;
        private System.Windows.Forms.TextBox hist_CardID_Text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox hist_CarType_Text;
        private System.Windows.Forms.TextBox hist_TF_Text;
        private System.Windows.Forms.TextBox hist_CardType_Text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}