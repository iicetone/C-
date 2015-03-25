using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cheku.BGSystem;
using Cheku.Types;

namespace Cheku
{
    public partial class CameraPanel : Panel
    {
        BGSOperater bgsOpt;
        CameraManager camOpt;
        private ChannelUnit curChan;
        private CameraStc curCam;
 

        public CameraPanel()
        {

            InitializeComponent();
            bgsOpt = BGSOperater.GetInstance();
            camOpt = bgsOpt.CamManager;
            curCam = new CameraStc();
            curChan = new ChannelUnit();
            foreach (CameraStc.CameraType ct in (CameraStc.CameraType[])System.Enum.GetValues(typeof(CameraStc.CameraType)))
                cForm_CameraType_ComboBox.Items.Add(ct.ToString());
            cForm_CameraType_ComboBox.SelectedIndex = 0;
            loadTreeView();
        }
        private void loadTreeView()
        {

            TreeNode rootnode = new TreeNode();
            rootnode.Text = "停车场";
            cForm_CameraManager_TreeView.Nodes.Add(rootnode);
            List<ChannelUnit> list = camOpt.GetChannelWithCamera();
            foreach (ChannelUnit chan in list)
            {
                TreeNode node = new TreeNode();
                node.Tag = chan.channelID;
                node.Text = chan.channelName;
                node.NodeFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                rootnode.Nodes.Add(node);
                if (chan.cameraCount != 0)
                {
                    foreach (CameraStc cam in chan.cameraList)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Tag = cam.cameraID;
                        childNode.Text = cam.cameraName;
                        node.Nodes.Add(childNode);
                    }
                }

            }
            rootnode.ExpandAll();
            cForm_CameraPanel_Panel.Enabled = false;
        }
        private void loadPanel()
        {

            if (curCam.cameraID != 0)
            {
                cForm_CameraPanel_Panel.Enabled = true;

                cForm_CameraName_Text.Text = curCam.cameraName.ToString();
                cForm_CameraIP_Text.Text = curCam.tcpAddr.ToString();
                cForm_CameraPort_Text.Text = curCam.tcpPort.ToString();
                cForm_CameraChannel_Text.Text = "1";
                cForm_CameraType_ComboBox.SelectedItem = curCam.cameraType.ToString();
            }

            else
            {
                cForm_CameraName_Text.Text = "请选择设备";
                cForm_CameraPanel_Panel.Enabled = false;
            }
        }

        private void addCamer()
        {

                curCam = new CameraStc();
                curCam.cameraName = "新设备";
                curCam.cameraType = CameraStc.CameraType.通道摄像头;
                curCam.tcpAddr = "0";
                curCam.tcpPort = "0";

                camOpt.updateCamera(ref curChan, ref curCam);

                TreeNode newCNode = new TreeNode();
                newCNode.Tag = curCam.cameraID;
                newCNode.Text = curCam.cameraName;
                cForm_CameraManager_TreeView.SelectedNode.Nodes.Add(newCNode);
               
                cForm_CameraManager_TreeView.SelectedNode = newCNode;

                loadPanel();

            

        }
        private void updateCamer()
        {

            if (cForm_CameraManager_TreeView.SelectedNode != null && cForm_CameraManager_TreeView.SelectedNode.Level == 2)
            {
                getCamerFormInfo();
               // camOpt.LoginCamera(ref curCam);
                cForm_CameraManager_TreeView.SelectedNode.Text = curCam.cameraName;
            }
            //else
            //{
            //    //未选择设备,不进行更新
            //}
        }
        private void getCamerFormInfo()
        {
            //cForm_CameraName_Text.Text = curCam.cameraName.ToString();
            //cForm_CameraIP_Text.Text = curCam.tcpAddr.ToString();
            //cForm_CameraPort_Text.Text = curCam.tcpPort.ToString();
            //cForm_CameraChannel_Text.Text = "1";
            //cForm_CameraType_ComboBox.SelectedItem = curCam.cameraType.ToString();

            curCam.cameraName = cForm_CameraName_Text.Text;
            curCam.tcpAddr = cForm_CameraIP_Text.Text;
            curCam.tcpPort = cForm_CameraPort_Text.Text;
            curCam.cameraType = (CameraStc.CameraType)Enum.Parse(typeof(CameraStc.CameraType), cForm_CameraType_ComboBox.SelectedItem.ToString());

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            String str = camOpt.GetCameraPreView(curCam,ref cForm_CameraPlay_Picture);
            if (str.Length <= 6)
            {
                cForm_Record_Button.Text = str;
            }
            else
            {
                MessageBox.Show(str);
            }
        }

        private void cForm_AddCamera_Button_Click(object sender, EventArgs e)
        {
            if (cForm_CameraManager_TreeView.SelectedNode != null && cForm_CameraManager_TreeView.SelectedNode.Level == 1)
            {
                addCamer();
            }
            else
            {
                MessageBox.Show("只能在通道内添加设备,请先选择一个通道,或者添加通道！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void cForm_CameraManager_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (cForm_CameraManager_TreeView.SelectedNode != null)
            {
                if (cForm_CameraManager_TreeView.SelectedNode.Parent == null)
                {
                    curChan.channelID = 0;
                    curCam.cameraID = 0;
                    //选中的为停车场
                    this.loadPanel();
                }
                else if (cForm_CameraManager_TreeView.SelectedNode.Parent.Parent == null)
                {
                    //选中的是通道
                    curChan = bgsOpt.GetCurrentChannel((int)cForm_CameraManager_TreeView.SelectedNode.Tag);
                    curCam.cameraID = 0;
                    this.loadPanel();
                }
                else if (cForm_CameraManager_TreeView.SelectedNode.Parent.Parent.Parent == null)
                {
                    //选中的是设备
                    curChan.channelID = (int)cForm_CameraManager_TreeView.SelectedNode.Parent.Tag;
                     camOpt.getChannel(ref curChan);
                    curCam.cameraID = (int)cForm_CameraManager_TreeView.SelectedNode.Tag;
                    camOpt.GetCamera(ref curCam);
                    this.loadPanel();
                }

            }
        }

        private void cForm_Login_Button_Click(object sender, EventArgs e)
        {
            string str;

            getCamerFormInfo();
            cForm_CameraManager_TreeView.SelectedNode.Text = curCam.cameraName;

            if (cForm_CameraName_Text.Text == "" || cForm_CameraIP_Text.Text == "" ||
                cForm_CameraPort_Text.Text == "" || cForm_CameraType_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }

            str = camOpt.LoginCamera(ref curCam);
            if (str.Length <= 6)
            {
                cForm_Login_Button.Text = str;

            }
            else
            {
                MessageBox.Show(str);
            }
            camOpt.updateCamera(ref curChan, ref curCam);

            return;
        }
    }
}
