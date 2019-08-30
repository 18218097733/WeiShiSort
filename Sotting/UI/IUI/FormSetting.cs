using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortCommon;

namespace UI.IUI
{
    public partial class FormSetting : Form
    {
        #region variable       
        IniHelper iniHelper = new IniHelper("ParaSeting.ini");
        Comm serialComm1 = new Comm();
        /**改变方向* */
        static string CHANGE_DIRECTION = "0106801E000781CE";
        /** 刹车* */
        private static string BRACK = "0106801E000241CD";
        /** 使能* */
        private static string ENABLE = "0106801E0003800D";
        #endregion
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            string[] portName;
            int i;
            
            //post请求地址
            IniHelper.GetAllKeyValues("Http_Setting", out string[] keys, out string[] values, iniHelper.FileName);
            if(values.Length>0)
            {
                tbURL.Text = values[0];
            }
            //串口初始化设置
            cBCom.Items.Clear();
            cBWeightComm.Items.Clear();
            IniHelper.GetAllKeyValues("SerialPort_Setting", out string[] keys2, out string[] values2, iniHelper.FileName);
            IniHelper.GetAllKeyValues("WeightPort_Setting", out string[] keys3, out string[] values3, iniHelper.FileName);
            portName = System.IO.Ports.SerialPort.GetPortNames();
            if (values2[2] == "true")
                checkBoxReversal.Checked = true;
            if (portName.Length > 0)
            {
                for (i = 0; i < portName.Length; i++)
                {
                    cBCom.Items.Add(portName[i]);
                    cBWeightComm.Items.Add(portName[i]);
                    if (values2.Length > 1)
                    {
                        if (values2[0] == portName[i])
                        {
                            cBCom.Text = values2[0];
                            cBBaud.Text = values2[1];
                        }

                    }
                    if (values3.Length > 1)
                    {
                        if (values3[0] == portName[i])
                        {
                            cBWeightComm.Text = values3[0];
                            cBWeightBaund.Text = values3[1];
                            cbWorkSole.Text = values3[2];
                        }
                    }
                }
            }
            IniHelper.GetAllKeyValues("Other_Setting", out string[] keys4, out string[] values4, iniHelper.FileName);
            if (values4.Length > 1)
            {
                if (values4[0] == "true")
                    checkBoxSaveCode.Checked = true;
                if (values4[1] == "true")
                    cB_voice.Checked = true;
            }
            else
            {
                IniHelper.Write("Other_Setting", "SaveCode", "false", iniHelper.FileName);
                IniHelper.Write("Other_Setting", "OpenVoice", "false", iniHelper.FileName);
                IniHelper.Write("Other_Setting", "Reversal", "false", iniHelper.FileName);
            }
            //条码设置
            IniHelper.GetAllKeyValues("Code_Setting", out string[] keys5, out string[] values5, iniHelper.FileName);
            if(values5.Length>0)
            {
                if(values5[0]=="true")               
                    cB_Code128.Checked = true;               
                if (values5[1] == "true")               
                    cB_Code39.Checked = true;
                if (values5[2] == "true")
                    cB_Code93.Checked = true;
                if (values5[3] == "true")
                    cBEAN13.Checked = true;

            }
        }


        private void btHttp_Click(object sender, EventArgs e)
        {
            //匹配(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$　　//匹配url
            bool result = false;
            string pattern = @"(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]";
            result = Regex.IsMatch(tbURL.Text, pattern);
            if(result)
            {
                IniHelper.Write("Http_Setting", "请求地址", tbURL.Text, iniHelper.FileName);
                this.Close();
            }        
            else
                MessageBox.Show("URL格式不正确");
           
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            IniHelper.Write("SerialPort_Setting", "串口", cBCom.Text, iniHelper.FileName);
            IniHelper.Write("SerialPort_Setting", "波特率", cBBaud.Text, iniHelper.FileName);
            if (checkBoxReversal.Checked)
            {
                IniHelper.Write("SerialPort_Setting", "Reversal", "true", iniHelper.FileName);
            }
            else
            {
                IniHelper.Write("SerialPort_Setting", "Reversal", "false", iniHelper.FileName);
            }
            this.Close();
        }



        private void btWeight_Click(object sender, EventArgs e)
        {
            IniHelper.Write("WeightPort_Setting", "串口", cBWeightComm.Text, iniHelper.FileName);
            IniHelper.Write("WeightPort_Setting", "波特率", cBWeightBaund.Text, iniHelper.FileName);
            IniHelper.Write("WeightPort_Setting", "称台号", cbWorkSole.Text, iniHelper.FileName);
            this.Close();
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialComm1.Close();
            }
            catch
            { }
        }


        private void buttonOther_Click(object sender, EventArgs e)
        {
            if(checkBoxSaveCode.Checked)
            {
                IniHelper.Write("Other_Setting", "SaveCode", "true", iniHelper.FileName);
            }
            else
            {
                IniHelper.Write("Other_Setting", "SaveCode", "false", iniHelper.FileName);
            }
            if (cB_voice.Checked)
            {
                IniHelper.Write("Other_Setting", "OpenVoice", "true", iniHelper.FileName);
            }
            else
            {
                IniHelper.Write("Other_Setting", "OpenVoice", "false", iniHelper.FileName);
            }

            this.Close();
        }

        private void CheckBoxTest_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTest.Checked)
            {
                try
                {
                    serialComm1.Close();
                    serialComm1._serialPort.PortName = cBCom.Text;
                    serialComm1._serialPort.BaudRate = Convert.ToInt32(cBBaud.Text);
                    serialComm1.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtForword_Click(object sender, EventArgs e)
        {
            if (checkBoxTest.Checked)
            {
                try
                {
                    serialComm1.Close();
                    serialComm1._serialPort.PortName = cBCom.Text;
                    serialComm1._serialPort.BaudRate = Convert.ToInt32(cBBaud.Text);
                    serialComm1.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Forward(0);
        }

        private void BtBack_Click(object sender, EventArgs e)
        {
            if (checkBoxTest.Checked)
            {
                try
                {
                    serialComm1.Close();
                    serialComm1._serialPort.PortName = cBCom.Text;
                    serialComm1._serialPort.BaudRate = Convert.ToInt32(cBBaud.Text);
                    serialComm1.Open();
                }
                catch
                {

                }
            }
            Forward(1);
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            StopForward();
        }
        void Forward(int mode)
        {
            if (checkBoxReversal.Checked)
            {
                if (mode == 0)
                    mode = 1;
                else
                    mode = 0;
            }
            if (mode == 0)
            {
                byte[] send = new byte[CHANGE_DIRECTION.Length / 2];
                for (int i = 0; i < CHANGE_DIRECTION.Length / 2; i++)
                {
                    send[i] = Convert.ToByte(CHANGE_DIRECTION.Substring(i * 2, 2), 16);
                }

                serialComm1.WritePort(send, 0, send.Length);           
            }
            else
            {
                byte[] send = new byte[ENABLE.Length / 2];
                for (int i = 0; i < ENABLE.Length / 2; i++)
                {
                    send[i] = Convert.ToByte(ENABLE.Substring(i * 2, 2), 16);
                }
                serialComm1.WritePort(send, 0, send.Length);           
            }
        }

        //跑步机停止
        void StopForward()
        {
            byte[] send = new byte[BRACK.Length / 2];
            for (int i = 0; i < BRACK.Length / 2; i++)
            {
                send[i] = Convert.ToByte(BRACK.Substring(i * 2, 2), 16);
            }
            serialComm1.WritePort(send, 0, send.Length);
        }

        private void CBCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxTest.Checked)
            {
                try
                {
                    serialComm1.Close();
                    serialComm1._serialPort.PortName = cBCom.Text;
                    serialComm1._serialPort.BaudRate = Convert.ToInt32(cBBaud.Text);
                    serialComm1.Open();
                }
                catch
                {

                }
            }
        }

        private void TCtest_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)tCtest.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(tCtest.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);

        }

        private void BtCode_Click(object sender, EventArgs e)
        {
            if(cB_Code128.Checked)
                IniHelper.Write("Code_Setting", "Code 128", "true", iniHelper.FileName);
            else
                IniHelper.Write("Code_Setting", "Code 128", "false", iniHelper.FileName);
            if (cB_Code39.Checked)
                IniHelper.Write("Code_Setting", "Code 39", "true", iniHelper.FileName);
            else
                IniHelper.Write("Code_Setting", "Code 39", "false", iniHelper.FileName);
            if (cB_Code93.Checked)
                IniHelper.Write("Code_Setting", "Code 93", "true", iniHelper.FileName);
            else
                IniHelper.Write("Code_Setting", "Code 93", "false", iniHelper.FileName);
            if (cBEAN13.Checked)
                IniHelper.Write("Code_Setting", "EAN-13", "true", iniHelper.FileName);
            else
                IniHelper.Write("Code_Setting", "EAN-13", "false", iniHelper.FileName);
            if(cB_filter.Checked)
                IniHelper.Write("Code_Setting", "Filter", "true", iniHelper.FileName);
            else
                IniHelper.Write("Code_Setting", "Filter", "false", iniHelper.FileName);
            IniHelper.Write("Code_Setting", "RULE", tB_Rule.Text, iniHelper.FileName);
            this.Close();
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
