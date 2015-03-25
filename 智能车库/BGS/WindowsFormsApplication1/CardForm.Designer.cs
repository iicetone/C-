namespace Cheku
{
    partial class CardPanel
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cardForm_CardInfo_ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardForm_Search_Button = new System.Windows.Forms.Button();
            this.cardForm_Search_Text = new System.Windows.Forms.ComboBox();
            this.card_NewCard_Button = new System.Windows.Forms.Button();
            this.card_DeleteCard_Button = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cardForm_Refresh_Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cardForm_TF_Combo = new System.Windows.Forms.ComboBox();
            this.cardForm_VF_Combo = new System.Windows.Forms.ComboBox();
            this.cardForm_CarType_Combo = new System.Windows.Forms.ComboBox();
            this.cardForm_Cardlic_Text = new System.Windows.Forms.TextBox();
            this.cardForm_CardName_Text = new System.Windows.Forms.TextBox();
            this.cardForm_CardPhone_Text = new System.Windows.Forms.TextBox();
            this.cardForm_CardID_Text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cardForm_Clear_Button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cardForm_CardInfo_ListView
            // 
            this.cardForm_CardInfo_ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardForm_CardInfo_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader0,
            this.columnHeader2,
            this.columnHeader12,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader11,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.cardForm_CardInfo_ListView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cardForm_CardInfo_ListView.FullRowSelect = true;
            this.cardForm_CardInfo_ListView.GridLines = true;
            this.cardForm_CardInfo_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.cardForm_CardInfo_ListView.Location = new System.Drawing.Point(9, 64);
            this.cardForm_CardInfo_ListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardForm_CardInfo_ListView.MultiSelect = false;
            this.cardForm_CardInfo_ListView.Name = "cardForm_CardInfo_ListView";
            this.cardForm_CardInfo_ListView.Size = new System.Drawing.Size(1167, 379);
            this.cardForm_CardInfo_ListView.TabIndex = 7;
            this.cardForm_CardInfo_ListView.UseCompatibleStateImageBehavior = false;
            this.cardForm_CardInfo_ListView.View = System.Windows.Forms.View.Details;
            this.cardForm_CardInfo_ListView.SelectedIndexChanged += new System.EventHandler(this.cardForm_CardInfo_ListView_SelectedIndexChanged);
            this.cardForm_CardInfo_ListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cardForm_CardInfo_ListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "卡号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 124;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "注册时间";
            this.columnHeader0.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 89;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "卡内余额";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "有效性";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "是否入库";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "卡主姓名";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 90;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "车型";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "车牌号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 107;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "车主电话";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 115;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "入库总时间";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 193;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "最后入库时间";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 160;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "最后出库时间";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 160;
            // 
            // cardForm_Search_Button
            // 
            this.cardForm_Search_Button.Location = new System.Drawing.Point(861, 13);
            this.cardForm_Search_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardForm_Search_Button.Name = "cardForm_Search_Button";
            this.cardForm_Search_Button.Size = new System.Drawing.Size(94, 31);
            this.cardForm_Search_Button.TabIndex = 1;
            this.cardForm_Search_Button.Text = "查找";
            this.cardForm_Search_Button.UseVisualStyleBackColor = true;
            this.cardForm_Search_Button.Click += new System.EventHandler(this.cardForm_Search_Button_Click);
            // 
            // cardForm_Search_Text
            // 
            this.cardForm_Search_Text.FormattingEnabled = true;
            this.cardForm_Search_Text.Location = new System.Drawing.Point(549, 16);
            this.cardForm_Search_Text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardForm_Search_Text.Name = "cardForm_Search_Text";
            this.cardForm_Search_Text.Size = new System.Drawing.Size(284, 28);
            this.cardForm_Search_Text.TabIndex = 0;
            // 
            // card_NewCard_Button
            // 
            this.card_NewCard_Button.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.card_NewCard_Button.Location = new System.Drawing.Point(1018, 29);
            this.card_NewCard_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.card_NewCard_Button.Name = "card_NewCard_Button";
            this.card_NewCard_Button.Size = new System.Drawing.Size(170, 143);
            this.card_NewCard_Button.TabIndex = 12;
            this.card_NewCard_Button.Text = "注册新用户";
            this.card_NewCard_Button.UseVisualStyleBackColor = true;
            this.card_NewCard_Button.Click += new System.EventHandler(this.card_NewCard_Button_Click);
            // 
            // card_DeleteCard_Button
            // 
            this.card_DeleteCard_Button.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.card_DeleteCard_Button.Location = new System.Drawing.Point(798, 14);
            this.card_DeleteCard_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.card_DeleteCard_Button.Name = "card_DeleteCard_Button";
            this.card_DeleteCard_Button.Size = new System.Drawing.Size(145, 61);
            this.card_DeleteCard_Button.TabIndex = 14;
            this.card_DeleteCard_Button.Text = "删除用户";
            this.card_DeleteCard_Button.UseVisualStyleBackColor = true;
            this.card_DeleteCard_Button.Click += new System.EventHandler(this.card_DeleteCard_Button_Click);
            // 
            // cardForm_Refresh_Button
            // 
            this.cardForm_Refresh_Button.Location = new System.Drawing.Point(973, 14);
            this.cardForm_Refresh_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardForm_Refresh_Button.Name = "cardForm_Refresh_Button";
            this.cardForm_Refresh_Button.Size = new System.Drawing.Size(94, 31);
            this.cardForm_Refresh_Button.TabIndex = 1;
            this.cardForm_Refresh_Button.Text = "刷新";
            this.cardForm_Refresh_Button.UseVisualStyleBackColor = true;
            this.cardForm_Refresh_Button.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cardForm_TF_Combo);
            this.groupBox2.Controls.Add(this.cardForm_VF_Combo);
            this.groupBox2.Controls.Add(this.cardForm_CarType_Combo);
            this.groupBox2.Controls.Add(this.cardForm_Cardlic_Text);
            this.groupBox2.Controls.Add(this.cardForm_CardName_Text);
            this.groupBox2.Controls.Add(this.cardForm_CardPhone_Text);
            this.groupBox2.Controls.Add(this.cardForm_CardID_Text);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.card_DeleteCard_Button);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 178);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编辑用户";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1.Location = new System.Drawing.Point(798, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 59);
            this.button1.TabIndex = 12;
            this.button1.Text = "修改信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cardForm_TF_Combo
            // 
            this.cardForm_TF_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardForm_TF_Combo.FormattingEnabled = true;
            this.cardForm_TF_Combo.Location = new System.Drawing.Point(576, 84);
            this.cardForm_TF_Combo.Name = "cardForm_TF_Combo";
            this.cardForm_TF_Combo.Size = new System.Drawing.Size(122, 28);
            this.cardForm_TF_Combo.TabIndex = 24;
            // 
            // cardForm_VF_Combo
            // 
            this.cardForm_VF_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardForm_VF_Combo.FormattingEnabled = true;
            this.cardForm_VF_Combo.Location = new System.Drawing.Point(89, 133);
            this.cardForm_VF_Combo.Name = "cardForm_VF_Combo";
            this.cardForm_VF_Combo.Size = new System.Drawing.Size(129, 28);
            this.cardForm_VF_Combo.TabIndex = 24;
            // 
            // cardForm_CarType_Combo
            // 
            this.cardForm_CarType_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardForm_CarType_Combo.FormattingEnabled = true;
            this.cardForm_CarType_Combo.Location = new System.Drawing.Point(323, 84);
            this.cardForm_CarType_Combo.Name = "cardForm_CarType_Combo";
            this.cardForm_CarType_Combo.Size = new System.Drawing.Size(121, 28);
            this.cardForm_CarType_Combo.TabIndex = 24;
            // 
            // cardForm_Cardlic_Text
            // 
            this.cardForm_Cardlic_Text.BackColor = System.Drawing.SystemColors.Info;
            this.cardForm_Cardlic_Text.Location = new System.Drawing.Point(326, 29);
            this.cardForm_Cardlic_Text.Name = "cardForm_Cardlic_Text";
            this.cardForm_Cardlic_Text.Size = new System.Drawing.Size(121, 27);
            this.cardForm_Cardlic_Text.TabIndex = 23;
            // 
            // cardForm_CardName_Text
            // 
            this.cardForm_CardName_Text.BackColor = System.Drawing.SystemColors.Info;
            this.cardForm_CardName_Text.Location = new System.Drawing.Point(87, 86);
            this.cardForm_CardName_Text.Name = "cardForm_CardName_Text";
            this.cardForm_CardName_Text.Size = new System.Drawing.Size(121, 27);
            this.cardForm_CardName_Text.TabIndex = 23;
            // 
            // cardForm_CardPhone_Text
            // 
            this.cardForm_CardPhone_Text.BackColor = System.Drawing.SystemColors.Info;
            this.cardForm_CardPhone_Text.Location = new System.Drawing.Point(576, 30);
            this.cardForm_CardPhone_Text.Name = "cardForm_CardPhone_Text";
            this.cardForm_CardPhone_Text.Size = new System.Drawing.Size(121, 27);
            this.cardForm_CardPhone_Text.TabIndex = 23;
            // 
            // cardForm_CardID_Text
            // 
            this.cardForm_CardID_Text.BackColor = System.Drawing.SystemColors.Info;
            this.cardForm_CardID_Text.Location = new System.Drawing.Point(87, 32);
            this.cardForm_CardID_Text.Name = "cardForm_CardID_Text";
            this.cardForm_CardID_Text.Size = new System.Drawing.Size(121, 27);
            this.cardForm_CardID_Text.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "是否入库:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "有效性:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "车型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "车牌号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "车主电话:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "卡号:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cardForm_CardInfo_ListView);
            this.panel1.Controls.Add(this.cardForm_Search_Text);
            this.panel1.Controls.Add(this.cardForm_Clear_Button);
            this.panel1.Controls.Add(this.cardForm_Refresh_Button);
            this.panel1.Controls.Add(this.cardForm_Search_Button);
            this.panel1.Location = new System.Drawing.Point(9, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 463);
            this.panel1.TabIndex = 22;
            // 
            // cardForm_Clear_Button
            // 
            this.cardForm_Clear_Button.Location = new System.Drawing.Point(1081, 13);
            this.cardForm_Clear_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardForm_Clear_Button.Name = "cardForm_Clear_Button";
            this.cardForm_Clear_Button.Size = new System.Drawing.Size(94, 31);
            this.cardForm_Clear_Button.TabIndex = 1;
            this.cardForm_Clear_Button.Text = "清空";
            this.cardForm_Clear_Button.UseVisualStyleBackColor = true;
            this.cardForm_Clear_Button.Click += new System.EventHandler(this.cardForm_Clear_Button_Click);
            // 
            // CardPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.card_NewCard_Button);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CardPanel";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView cardForm_CardInfo_ListView;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button cardForm_Search_Button;
        private System.Windows.Forms.ComboBox cardForm_Search_Text;
        private System.Windows.Forms.Button card_NewCard_Button;
        private System.Windows.Forms.Button card_DeleteCard_Button;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button cardForm_Refresh_Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cardForm_CarType_Combo;
        private System.Windows.Forms.TextBox cardForm_Cardlic_Text;
        private System.Windows.Forms.TextBox cardForm_CardName_Text;
        private System.Windows.Forms.TextBox cardForm_CardPhone_Text;
        private System.Windows.Forms.TextBox cardForm_CardID_Text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cardForm_TF_Combo;
        private System.Windows.Forms.ComboBox cardForm_VF_Combo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button cardForm_Clear_Button;

    }
}