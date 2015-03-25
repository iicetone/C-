using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.DataManager;
using System.Data.OleDb;
using Cheku.BGSystem;
using Cheku.Types;
namespace Cheku
{
    public partial class CardPanel : Panel
    {
        private BGSOperater bgsOpt;
        private CardOperater cOpt;
        private int curCardID;
        public CardPanel()
        {
            InitializeComponent();

           // this.TopLevel = false;
            cOpt = CardOperater.GetInstance();

            ImageList imageList = new ImageList();   //设置行高20

            imageList.ImageSize = new System.Drawing.Size(1, 30);   //分别是宽和高

            cardForm_CardInfo_ListView.SmallImageList = imageList;   //这里设置listView的SmallImageList ,用imgList将其撑大。

            foreach (CardUnit.CAType typeCode in Enum.GetValues(typeof(CardUnit.CAType)))
            {
                this.cardForm_CarType_Combo.Items.Add(typeCode.ToString());
            }
            foreach (CardUnit.VFlag typeCode in Enum.GetValues(typeof(CardUnit.VFlag)))
            {
                this.cardForm_VF_Combo.Items.Add(typeCode.ToString());
            }

            this.cardForm_TF_Combo.Items.Add("false");
                this.cardForm_TF_Combo.Items.Add("true");            


            this.cardForm_CarType_Combo.SelectedIndex = 0;
            this.cardForm_VF_Combo.SelectedIndex = 0;
            this.cardForm_TF_Combo.SelectedIndex = 0;

            fillListView();


        }

        private void fillListView()
        {
            cardForm_CardInfo_ListView.Items.Clear();


            OleDbDataReader reader = cOpt.ShowCardInfo();
            while (reader.Read())
            {
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                li.SubItems[0].Text = reader["cardID"].ToString();
                li.SubItems.Add(reader["initTime"].ToString());
                li.SubItems.Add(reader["cardType"].ToString());
                li.SubItems.Add(reader["cardValue"].ToString());
                li.SubItems.Add(reader["validFlag"].ToString());
                li.SubItems.Add(reader["timerFlag"].ToString());
                li.SubItems.Add(reader["cardName"].ToString());
                li.SubItems.Add(reader["carType"].ToString());
                li.SubItems.Add(reader["carLic"].ToString());
                li.SubItems.Add(reader["cardTel"].ToString());
                li.SubItems.Add(reader["totalTime"].ToString());
                li.SubItems.Add(reader["lastIn"].ToString());
                li.SubItems.Add(reader["lastOut"].ToString());

                cardForm_CardInfo_ListView.Items.Add(li);


            }
        }

        private void card_NewCard_Button_Click(object sender, EventArgs e)
        {
            NewCardForm nForm = new NewCardForm();
            //nForm.Owner = this;
            nForm.ShowDialog();
        }

        private void card_DeleteCard_Button_Click(object sender, EventArgs e)
        {
            if (cardForm_CardID_Text.Text == String.Empty)
            {
                MessageBox.Show("请选择要删除的用户", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (cardForm_CardID_Text.Text != null)
                {
                    int cardID = Convert.ToInt32(cardForm_CardID_Text.Text);
                    cOpt.DeleteCard(cardID);
                    this.fillListView();
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.fillListView();
        }


        private void cardForm_CardInfo_ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[0].Text == String.Empty) return;
            
                curCardID = Convert.ToInt32(this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[0].Text);
                cardForm_CardID_Text.Text = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[0].Text;
                cardForm_CardName_Text.Text = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[6].Text;
                cardForm_CardPhone_Text.Text = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[9].Text;
                cardForm_Cardlic_Text.Text = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[8].Text;
                cardForm_CarType_Combo.SelectedItem = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[7].Text;
                cardForm_VF_Combo.SelectedItem = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[4].Text;
                cardForm_TF_Combo.SelectedItem = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[5].Text;
            
            //cardForm_CardType_Combo.SelectedText = this.cardForm_CardInfo_ListView.SelectedItems[0].SubItems[2].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cardForm_CardID_Text.Text == String.Empty)
             {
                MessageBox.Show("请选择要修改的用户", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
             }
                CardUnit card = new CardUnit();
                card.CardID = cardForm_CardID_Text.Text;
                card.CardName = cardForm_CardName_Text.Text;
                card.CardTel = cardForm_CardPhone_Text.Text;
                card.CarType = (CardUnit.CAType)Enum.Parse(typeof(CardUnit.CAType), cardForm_CarType_Combo.SelectedItem.ToString());
                card.CarLic = cardForm_Cardlic_Text.Text;
                card.ValidFlag = (CardUnit.VFlag)Enum.Parse(typeof(CardUnit.VFlag), cardForm_VF_Combo.SelectedItem.ToString());
                card.TimerFlag =Convert.ToBoolean( cardForm_TF_Combo.SelectedItem.ToString()) ; 
                cOpt.EditCard(card);
                MessageBox.Show("修改成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.fillListView();
        }

        private void cardForm_Search_Button_Click(object sender, EventArgs e)
        {
            if (cardForm_Search_Text.Text == String.Empty ) return;
            fillListView();
            string findstr = cardForm_Search_Text.Text;
            ListViewItem foundItem = cardForm_CardInfo_ListView.FindItemWithText(findstr,true,0,true);

               while(foundItem!=null )
               {
                   foundItem.BackColor = Color.Yellow;
                   if (foundItem.Index + 1 < cardForm_CardInfo_ListView.Items.Count)
                       foundItem = cardForm_CardInfo_ListView.FindItemWithText(findstr, true, foundItem.Index + 1, true);
                   else break;
               }
        }

        private void cardForm_CardInfo_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cardForm_Clear_Button_Click(object sender, EventArgs e)
        {
            if (cardForm_CardInfo_ListView.Items.Count > 0)
            {
                //清空所有项
                if (MessageBox.Show("确定要清除所有卡片信息吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (MessageBox.Show("清楚卡片信息将清除数据库数据，清除后无法恢复，确定清除吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        cardForm_CardInfo_ListView.Items.Clear();
                        cOpt.CardClear();
                    }
                 
                }
             }
              else MessageBox.Show("没有记录", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
