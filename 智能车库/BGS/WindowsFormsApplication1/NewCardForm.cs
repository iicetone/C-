using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.Types;
using Cheku.BGSystem;
namespace Cheku
{
    public partial class NewCardForm : Form
    {
        CardOperater co;
        BGSOperater bo;
        public NewCardForm()
        {
             co = CardOperater.GetInstance();
             bo = BGSOperater.GetInstance();
            InitializeComponent();
            newCard_CardTypeValue_ComboBox_Init();
        }
        private void newCard_CardTypeValue_ComboBox_Init()
        {
            foreach (CardUnit.CType typeCode in Enum.GetValues(typeof(CardUnit.CType)))
            {
                String typeName = typeCode.ToString();//获取名称
                this.newCard_CardTypeValue_ComboBox.Items.Add(typeName);
            }
            this.newCard_CardTypeValue_ComboBox.SelectedIndex = 0;
            foreach (CardUnit.CAType typeCode in Enum.GetValues(typeof(CardUnit.CAType)))
            {
                String typeName = typeCode.ToString();//获取名称
                this.newCard_CarType_ComboBox.Items.Add(typeName);
            }
            this.newCard_CarType_ComboBox.SelectedIndex = 0;

        }

        private void newCard_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newCard_NewCard_Button_Click(object sender, EventArgs e)
        {

            if (newCard_CardIDValue_TextBox.Text == String.Empty)
            {
                MessageBox.Show("添加的卡号不能为空", "注册", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CardUnit cs = new CardUnit();
            cs.CardID =this.newCard_CardIDValue_TextBox.Text;
            cs.CardType = (CardUnit.CType)Enum.Parse(typeof(CardUnit.CType), this.newCard_CardTypeValue_ComboBox.Text);
            cs.ValidFlag = CardUnit.VFlag.有效;

            cs.CardName = this.newCard_CardNameValue_TextBox.Text;
            cs.CardTel = this.newCard_CardTelValue_TextBox.Text;
            cs.CarType = (CardUnit.CAType)Enum.Parse(typeof(CardUnit.CAType), this.newCard_CarType_ComboBox.Text);
            cs.CarLic = this.newCard_CardLicValue_TextBox.Text;
            cs.CardValue = this.newCard_CardValueValue_TextBox.Text;



            String mess = co.AddCard(cs) ? "注册成功" : "注册失败";
           MessageBox.Show(mess, "注册", MessageBoxButtons.OK, MessageBoxIcon.Information);
           MessageStc mes = new MessageStc();
           mes.card = cs;
           mes.type = MessageTypeEnum.NEWCARD;
           bo.DeployNewCard(mes);
           

          // bo.DeployNewCard("12422028");

          // CardPanel ower = (CardPanel)this.Owner;
          // ower.FillListView();
        }

        private void newCard_CardIDValue_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void newCard_CardIDValue_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void newCard_CardValueValue_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
