using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Cheku.BGSystem;

namespace Cheku
{
    public partial class HistoryForm : Form
    {
        CardOperater cOpt;
        public HistoryForm()
        {
            InitializeComponent();

            cOpt = CardOperater.GetInstance();
            cOpt.historyMessageArrived += updateHistoryMessage;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "bmp文件(*.bmp)|*.bmp|gif文件(*.gif)|*.gif|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png|tif文件(*.tif)|*.tif|wmf文件(*.wmf)|*.wmf";

            fillListView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (hist_HistList_ListView.Items.Count > 0)
            {
                //清空所有项
                if (MessageBox.Show("确定要清除记录吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    hist_HistList_ListView.Items.Clear();
                    cOpt.HistoryClear();
                }
             }
              else MessageBox.Show("没有记录", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dbBGSDataSet.dbVehicle”中。您可以根据需要移动或删除它。
           // this.dbVehicleTableAdapter.Fill(this.dbBGSDataSet.dbVehicle);

        }
        private void fillListView()
        {
            hist_HistList_ListView.Items.Clear();

            OleDbDataReader reader = cOpt.HistoryLoader();
            while (reader.Read())
            {
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                li.SubItems[0].Text = reader["carTime"].ToString();
                li.SubItems.Add(reader["cardID"].ToString());
                li.SubItems.Add(reader["cardType"].ToString());
                li.SubItems.Add(reader["carType"].ToString());
                li.SubItems.Add(reader["carLic"].ToString());
                li.SubItems.Add(reader["cardName"].ToString());
                li.SubItems.Add(reader["cardTel"].ToString());
                li.SubItems.Add(reader["entryFlag"].ToString());
                li.SubItems.Add(reader["parkName"].ToString());
                li.SubItems.Add(reader["channelName"].ToString());


              //  li.SubItems.Add(reader["carData"].ToString());
                hist_HistList_ListView.Items.Add(li);
            } 
        }
        private void updateHistoryMessage(object sender, MessageEventArgs e)
        {
            fillListView();
        }

        private void hist_Refresh_Button_Click(object sender, EventArgs e)
        {
            fillListView();
        }

        private void hist_Select_Button_Click(object sender, EventArgs e)
        {
            if (hist_Select_Text.Text == String.Empty) return;
            fillListView();
            string findstr = hist_Select_Text.Text;
            ListViewItem foundItem =  hist_HistList_ListView.FindItemWithText(findstr, true, 0, true);

            while (foundItem != null)
            {
                foundItem.BackColor = Color.Yellow;
                if (foundItem.Index + 1 < hist_HistList_ListView.Items.Count)
                    foundItem = hist_HistList_ListView.FindItemWithText(findstr, true, foundItem.Index + 1, true);
                else break;
            }
        }

        

        private void hist_HistList_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hist_HistList_ListView_Click(object sender, EventArgs e)
        {
            if (this.hist_HistList_ListView.SelectedItems[0].SubItems[0].Text == String.Empty) return;

            //curCardID = Convert.ToInt32(this.hist_HistList_ListView.SelectedItems[0].SubItems[0].Text);
            hist_CardID_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[1].Text;
            hist_CardName_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[5].Text;
            hist_CardPhone_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[6].Text;
            hist_Cardlic_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[4].Text;
            hist_CarType_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[3].Text;
            hist_CardType_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[2].Text;
            hist_TF_Text.Text = this.hist_HistList_ListView.SelectedItems[0].SubItems[7].Text;
            


        }
    }

}
