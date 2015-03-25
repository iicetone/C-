using Cheku.BGSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.Types;

namespace Cheku
{
    public partial class RechargePanel : Panel
    {

        private CardUnit card;
        CardOperater co;
        public RechargePanel()
        {
            InitializeComponent();
            co = CardOperater.GetInstance();
            co.RechargeCardMessageArrived += this.displayRechargeCardInfo;
            //*******************DEBUGGING*****************

        //    co.SetCurrentCard(33333, MessageTypeEnum.充值);
            //*******************DEBUGGING*****************
            RechargePanelReload();
        }
        private void RechargePanelReload()
        {
            chongZhi_OK_Button.Enabled = false;
            chongZhi_Change_Button.Enabled = false;
            groupBox2.Enabled = false;
            groupBox8.Enabled = false;
        }
        
        private void displayRechargeCardInfo(object sender, MessageEventArgs e)
        {


            card = e.Mes.card;
          //  this.chongZhi_KahaoValue_TextBox.Text = Convert.ToString(e.Card.CardID);
            this.chongZhi_LeixingValue_TextBox.Text = Convert.ToString(card.CardType);
            this.chongZhi_XingmingValue_TextBox.Text = Convert.ToString(card.CardName);
            this.chongZhi_ChepaiValue_TextBox.Text = Convert.ToString(card.CarLic);
            this.chongZhi_RechargeTime_TextBox.Text = card.LastRecharge;
            this.chongZhi_ResigerTime_TextBox.Text = card.InitTime;
            this.chongZhi_EduValue_TextBox.Text = card.CardValue;
            this.chongZhi_Valide_TextBox.Text = card.ValidFlag.ToString();
            for (int i = 0; i < this.panel7.Controls.Count; i++)
            {
                RadioButton rb = this.panel7.Controls[i] as RadioButton;
                if (rb.Name.Equals(card.CardType.ToString()))
                {
                    rb.Checked = true;
                    break;
                }
            }

            chongZhi_Change_Button.Enabled = true;
            chongZhi_ChangeNO_Button.Checked = true;
            groupBox8.Enabled = true;

            switch ( card.CardType)
            {
                case CardUnit.CType.免费卡:
                    return;
                case CardUnit.CType.临时卡:
                    return;
                case CardUnit.CType.充值卡:
                    this.chongZhi_Jine_Label.Text = "元";
                    this.chongZhi_EduValue_TextBox.Text += " 元";

                    break;
                case CardUnit.CType.月卡:
                    int mv = Convert.ToInt32(card.CardValue,10)/30;
                    this.chongZhi_EduValue_TextBox.Text = mv.ToString();
                    this.chongZhi_Jine_Label.Text = "月";
                    this.chongZhi_EduValue_TextBox.Text += " 月";
                    break;
                case CardUnit.CType.日卡:
                    this.chongZhi_Jine_Label.Text = "日";
                    this.chongZhi_EduValue_TextBox.Text += " 日";
                    break;
                case CardUnit.CType.特权卡:
                    return;
                case CardUnit.CType.授权卡:
                    this.chongZhi_Jine_Label.Text = "次";
                    this.chongZhi_EduValue_TextBox.Text += " 次";


                    break;
                case CardUnit.CType.员工卡:
                    this.chongZhi_Jine_Label.Text = "元";
                    this.chongZhi_EduValue_TextBox.Text += " 元";


                    break;
                default:
                    break;
            }
            chongZhi_OK_Button.Enabled = true;
            groupBox2.Enabled = true;


        }

        private void RechargeForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chongZhi_LeiXing_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chongZhi_Jine_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }


        private void chongZhi_OK_Button_Click(object sender, EventArgs e)
        {
            if (chongZhi_Jine_TextBox.Text == null)
            {
                MessageBox.Show("请输入有效充值金额", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
            int value = Convert.ToInt32(chongZhi_Jine_TextBox.Text);
            if ( co.RechargeCard(value, card))
            {
                MessageBox.Show("充值成功！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                RechargePanelReload();
            }
            else
            {
                MessageBox.Show("充值失败！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            }
        }


        private void chongZhi_KahaoValue_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void chongZhi_Delete_Button_Click(object sender, EventArgs e)
        {

        }




        private void button5_Click(object sender, EventArgs e)
        {
            if (chongZhi_KahaoValue_TextBox.Text.Length == 8)
            {
                MessageStc mes = new MessageStc();
                mes.type = MessageTypeEnum.RECHARGE;
                mes.card.CardID = chongZhi_KahaoValue_TextBox.Text;
                co.SetCurrentCard(ref mes);
                if (mes.card.CardID == null)
                {
                    MessageBox.Show("输入的卡号不存在，请核实后再输入!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RechargePanelReload();
                }

            }
            else
            {
                MessageBox.Show("输入的卡号错误，请核实后再输入!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RechargePanelReload();

            }
        }

        private void chongZhi_Change_Button_Click(object sender, EventArgs e)
        {
            if (chongZhi_ChangeYES_Button.Checked == true)
            {
                for (int i = 0; i < this.panel7.Controls.Count; i++)
                {
                    RadioButton rb = this.panel7.Controls[i] as RadioButton;
                    if (rb.Checked)
                    {
                        string selectedItem = rb.Text;
                        if (MessageBox.Show("转变类型将使卡片以前的余额清空，确定要转变类型吗？转变类型后，请重新读卡充值", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            co.RechargeCard(0, (CardUnit.CType)Enum.Parse(typeof(CardUnit.CType), selectedItem), card);
                            MessageBox.Show("转换成功，请重新读卡充值", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            RechargePanelReload();
                        }
                        break;
                    }
                }

            }
            else MessageBox.Show("请先选定“转变类型” 中的“ 是” 后再使用。", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

        }


    }
}
