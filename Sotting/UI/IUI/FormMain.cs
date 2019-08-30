using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HalconDotNet;
using SortCommon;
using ThridLibray;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Media;
using SortModel;

namespace UI.IUI
{
    public partial class FormMain : Form
    {

        private FormSetting myFormSetting;
        IniHelper iniHelper = new IniHelper("ParaSeting.ini");
        SoundPlayer player = new SoundPlayer();
        WeiShiPost weiShiPost = new WeiShiPost();
        Comm serialComm = new Comm();
        Comm weightComm = new Comm();
        private bool isSavaCode = false;
        private bool isReversal;
        private bool isOpenVoice;
        //重量设置
        private string weightStr;
        double weight;
        double[] weight2 = new double[6];
        private bool WeightReady = false;
        //条码设置
        List<string> types=new List<string>();
        private string codePattern;
        private string filterPattern= @"[-|;|:|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']";
        private bool Filter;
        //
        string url;
        private string workConsole;
        DataTable dt = new DataTable("Datas");
        string pattern = @"[-|;|:|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']";
        /**改变方向* */
        static string CHANGE_DIRECTION = "0106801E000781CE";
        /** 刹车* */
        private static string BRACK = "0106801E000241CD";
        /** 使能* */
        private static string ENABLE = "0106801E0003800D";
        private int stopTime = 0;

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            
            //禁止自动分列
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = dt;
            dt.Columns.Add("单号", Type.GetType("System.String"));
            dt.Columns.Add("重量(Kg)", Type.GetType("System.String"));
            dt.Columns.Add("目的地", Type.GetType("System.String"));
            dt.Columns.Add("时间", Type.GetType("System.String"));
            dt.Columns.Add("扫描时间(ms)", Type.GetType("System.String"));

            LoadFormInfo();
            LoadSetting();
            x = this.Width;
            y = this.Height;
            setTag(this);

        }

        // 设备对象
        private IDevice m_dev;
        private HalconHelper halconHelper;

        private int CodeSum=0;
        private void LoadFormInfo()
        {

            try
            {
                halconHelper = new HalconHelper(hWindowControl1.HalconWindow);
                List<IDeviceInfo> li = ThridLibray.Enumerator.EnumerateDevices();
                //if (Convert.ToInt32(this.Tag) != -1)
                if (li.Count > 0)
                {
                    m_dev = ThridLibray.Enumerator.GetDeviceByIndex(0);
                    //m_dev = Enumerator.GetDeviceByIndex(Convert.ToInt32(this.Tag));
                    // 注册链接时间

                    m_dev.CameraOpened += OnCameraOpen;
                    m_dev.ConnectionLost += OnConnectLoss;
                    m_dev.CameraClosed += OnCameraClose;
                    // 打开设备
                    if (!m_dev.Open())
                    {
                        MessageBox.Show(@"连接相机失败");
                        return;
                    }

                    // 关闭Trigger
                    //m_dev.TriggerSet.Close();
                    // 打开Software Trigger
                    m_dev.TriggerSet.Open(TriggerSourceEnum.Software);
                    // 设置图像格式
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                    {                     
                        p.SetValue("Mono8");
                    }

                    // 注册码流回调事件
                    m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                    // 开启码流
                    if (!m_dev.GrabUsingGrabLoopThread())
                    {
                        MessageBox.Show(@"开启码流失败");
                        return;
                    }
                    else
                    {
                        m_dev.ExecuteSoftwareTrigger();
                    }
                    
                }
                else
                {                  
                }
                //注册一维码识别完成事件
                halconHelper.Complete += OnComplete;
                halconHelper.Error += OnError;
                //注册串口接收事件
                serialComm.DateReceived += new Comm.EventHandle(OnDataReceived);
                weightComm.DateReceived += new Comm.EventHandle(OnWeightDataReceived);
            }
            catch(Exception ex)
            {
                Catcher.Show(ex);
            }
        }

        private void OnWeightDataReceived(byte[] readBuffer)
        {
            string id2 = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            try
             {               
                byte[] readstring=new byte[readBuffer.Length]; //= Encoding.UTF8.GetString(readBuffer);
                for (int i = 0; i < 8; i++)
                {                   
                    readstring[i] = readBuffer[readBuffer.Length - i - 1];
                }
                weightStr = Encoding.UTF8.GetString(readstring).TrimEnd('\0');
                weightStr = weightStr.Trim('=');
                weight = Convert.ToDouble(weightStr);
                for (int i = 0; i < 5; i++)
                {
                    weight2[i] = weight2[i + 1];            
                }
                weight2[5] = weight;
                for(int j=0;j<5;j++)
                {
                    if (Math.Abs(weight2[j+1] - weight2[j]) > 0.003 )
                    {
                        WeightReady = false;
                        break;
                    }
                    if(j==4)
                    {
                        WeightReady = true ;
                    }
                }

                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        lbWeight.Text = "重量    " + weightStr + "Kg";
                    }));
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void OnDataReceived(byte[] readBuffer)
        {
            //var readstring = Encoding.UTF8.GetString(readBuffer);

            //跑步机收到的回来指令没有用
            //string returnStr = "";
            //if (readBuffer != null)
            //{
            //    for (int i = 0; i < readBuffer.Length; i++)
            //    {
            //        returnStr += readBuffer[i].ToString("X2");
            //    }
            //}            
        }

        private void OnError(object sender, OnErrorEventArgs e)
        {
            this.Invoke(new Action(() => {

                if(e.Num==0)
                {
                    lbCode.ForeColor = Color.DarkBlue;
                    lbCode.Text = "单号   无有效单号";
                }                     
                else
                {

                    lbCode.ForeColor = Color.Red;
                    lbCode.Text = "单号   多个单号";
                }
                    
            }));
            
        }


        long nowtick,firsttick;
        private double rate;
        private void OnComplete(object sender, OnCompleteEventArgs e)
        {
            string rotation_RL="false";
            string  httpResponse;
            string time = DateTime.Now.ToString();
            bool result = false;

            if (e.DataStrings.Length < 5)
                return;
            var isContain = types.Contains(e.DataTypes);
            if(!isContain)
            {
                this.Invoke(new Action(() =>
                {
                    lbCode.ForeColor = Color.Red;
                    lbCode.Text = "单号    不支持的条码类型";
                }));
                return;
            }
            if(Filter)
            {
                result = Regex.IsMatch(e.DataStrings, filterPattern);
                if (result)
                {
                    this.Invoke(new Action(() =>
                    {
                        lbCode.ForeColor = Color.Red;
                        lbCode.Text = "单号    条码不符合规则";
                    }));
                    return;
                }
            }
            if(codePattern!=string.Empty)
            {
                result = Regex.IsMatch(e.DataStrings, codePattern );
                if(!result)
                {
                    this.Invoke(new Action(() =>
                    {
                        lbCode.ForeColor = Color.Red;
                        lbCode.Text = "单号    条码不符合规则";
                    }));
                    return;
                }
            }
            if (CodeSum==0)//记录第一次扫到条码的时间
            {
                firsttick = TimeTransitionHelper.GetCurrentTimeUnix();
            }
            this.Invoke(new Action(() =>
            {
                lbCode.ForeColor = Color.DarkBlue;
                lbCode.Text = "单号    " + e.DataStrings;             
            }));
            try
            {
                if (NetWork.IsConnectInternet() && stopTime == 0 && Convert.ToDouble(weightStr) >= 0.003 && WeightReady)
                {
                    if (url == "")
                        return;
                    List<WeiShiPost> weiShiPosts = new List<WeiShiPost>();
                    weiShiPost.ticketsNum = e.DataStrings;
                    weiShiPost.weight = weightStr;
                    weiShiPost.workConsoe = workConsole;
                    weiShiPosts.Add(weiShiPost);
                    string data = JsonConvert.SerializeObject(weiShiPosts);

                    httpResponse = HttpHelper.PostDataGetHtml(url, data);
                    JObject array = (JObject)JsonConvert.DeserializeObject(httpResponse);
                    rotation_RL = array["result"].ToString();
                    if (rotation_RL.Contains("true"))
                    {
                        
                        Forward(1);
                        if (isOpenVoice)
                        {
                            player.SoundLocation = @"./succeed.wav";
                            player.LoadAsync();
                            player.Play();
                        }
                    }
                    else
                    {
                        Forward(0);
                        if (isOpenVoice)
                        {
                            player.SoundLocation = @"./failed.wav";
                            player.LoadAsync();
                            player.Play();
                        }
                    }                       

                    CodeSum++;
                    this.Invoke(new Action(() =>
                    {
                        lbSum.Text = "总数    " + Convert.ToString(CodeSum) + "/件";
                        lbDestination.Text = "目的地    " +  "无";
                        if (dt != null)
                        {
                            if (dgvData.RowCount > 3000)
                            {
                                SaveLog();
                                dt.Clear();
                            }
                            DataRow dr = dt.NewRow();
                            dr["单号"] = e.DataStrings;
                            dr["重量(Kg)"] = weightStr;
                            dr["目的地"] = "无";
                            dr["时间"] = time;
                            dr["扫描时间(ms)"] = e.UseTime;
                            dt.Rows.Add(dr);
                            dgvData.FirstDisplayedScrollingRowIndex = dgvData.Rows.Count - 1;
                        }
                    }));
                }
                else if(stopTime == 0 && Convert.ToDouble(weightStr) >= 0.003 && WeightReady)
                {
                    //this.Invoke(new Action(() =>
                    //{
                    //    lbDestination.Text = weightStr;
                    //}));
                    //if (stopTime == 0)
                    //{
                    //    string str = e.DataStrings.Substring(e.DataStrings.Length - 1, 1);
                    //    if (Convert.ToInt32(str) % 2 == 0)
                    //    {
                    //        player.SoundLocation = @"./succeed.wav";
                    //        player.LoadAsync();
                    //        player.Play();
                    //        Forward(1);
                    //    }
                    //    else
                    //    {
                    //        player.SoundLocation = @"./failed.wav";
                    //        player.LoadAsync();
                    //        player.Play();
                    //        Forward(0);
                    //    }
                    //    CodeSum++;
                    //    this.Invoke(new Action(() =>
                    //    {
                    //        lbSum.Text = "总数    " + Convert.ToString(CodeSum) + "/件";
                    //        lbDestination.Text = "目的地    " + "无";
                    //        if (dt != null)
                    //        {
                    //            if (dgvData.RowCount > 3000)
                    //            {
                    //                SaveLog();
                    //                dt.Clear();
                    //            }
                    //            DataRow dr = dt.NewRow();
                    //            dr["单号"] = e.DataStrings;
                    //            dr["重量(Kg)"] = weightStr;
                    //            dr["目的地"] = "无";
                    //            dr["时间"] = time;
                    //            dr["扫描时间(ms)"] = e.UseTime;
                    //            dt.Rows.Add(dr);
                    //            dgvData.FirstDisplayedScrollingRowIndex = dgvData.Rows.Count - 1;
                    //        }
                    //    }));
                    //}
                    return;
                }      
            }
            catch (Exception ex)
            {
            }
        }

       
        //相机回流事件
        private void OnImageGrabbed(object sender, GrabbedEventArgs e)
        {
            HObject image;   
            try
            {
                HOperatorSet.GenImage1(out image, "byte", e.GrabResult.Width, e.GrabResult.Height, e.GrabResult.Raw);
                halconHelper.BarRecognition(image);
                m_dev.ExecuteSoftwareTrigger();
            }
            
            catch(Exception ex)
            {
                ex.ToString();
            }
        }


        // 相机打开回调
        private void OnCameraOpen(object sender, EventArgs e)
        {          
            this.Invoke(new Action(() =>
            {
                lbCemra.BackColor = Color.Lime;
            }));
        }
        // 相机关闭回调
        private void OnCameraClose(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lbCemra.BackColor = Color.Red;
            }));
        }

        // 相机丢失回调
        private void OnConnectLoss(object sender, EventArgs e)
        {
            m_dev.ShutdownGrab();
            m_dev.Dispose();
            m_dev = null;           
            this.Invoke(new Action(() =>
            {
                lbCemra.BackColor = Color.Red;
                System.Environment.Exit(0);
            }));

        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.notifyIcon1.Dispose();
                SaveLog();
                if (m_dev != null)
                {
                    m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         /* 反注册回调 */
                    m_dev.TriggerSet.Close();
                }

            }
            catch(Exception ex)
            {
               // Catcher.Show(ex);
            }
            System.Environment.Exit(0);
        }
        //跑步机前进或后退
        void Forward(int mode)
        {
            if (isReversal)
            {
                if (mode == 0)
                    mode = 1;
                else
                    mode = 0;
            }
 
            if (mode == 0)
            {
                byte[] send = new byte[CHANGE_DIRECTION.Length / 2];
                for (int i = 0; i < CHANGE_DIRECTION.Length/2; i++)
                {
                    send[i]= Convert.ToByte(CHANGE_DIRECTION.Substring(i * 2, 2), 16);
                }
               
                serialComm.WritePort(send, 0, send.Length);
                stopTime = 5;
            }
            else
            {
                byte[] send = new byte[ENABLE.Length / 2];
                for (int i = 0; i < ENABLE.Length / 2; i++)
                {
                    send[i] = Convert.ToByte(ENABLE.Substring(i * 2, 2), 16);
                }
                serialComm.WritePort(send, 0, send.Length);
                stopTime = 5;
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
            serialComm.WritePort(send, 0, send.Length);
        }
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                serialComm.Close();
                weightComm.Close();
                if (myFormSetting == null || myFormSetting.IsDisposed)
                {
                    myFormSetting = new FormSetting();
                    myFormSetting.ShowDialog();
                }
                else
                    myFormSetting.ShowDialog();
                LoadSetting();
            }
            catch(Exception ex)
            { }
        }

        private void LoadSetting()
        {
            //串口设置
            IniHelper.GetAllKeyValues("SerialPort_Setting", out string[] keys2, out string[] values2, iniHelper.FileName);
            IniHelper.GetAllKeyValues("WeightPort_Setting", out string[] keys3, out string[] values3, iniHelper.FileName);
            IniHelper.GetAllKeyValues("Other_Setting", out string[] keys4, out string[] values4, iniHelper.FileName);
            //post请求地址
            IniHelper.GetAllKeyValues("Http_Setting", out string[] keys, out string[] values, iniHelper.FileName);
            //条码设置
            IniHelper.GetAllKeyValues("Code_Setting", out string[] keys5, out string[] values5, iniHelper.FileName);
            try
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys.Length == 1)
                    {
                        url = values[0];                     
                    }
                }
                if (values5.Length > 0)
                {
                    for(int i =0;i<4;i++)
                    {                 
                        if(Convert.ToBoolean(values5[i]))
                            types.Add(keys5[i]);                       
                    }
                    Filter = Convert.ToBoolean(values5[4]);
                    codePattern = values5[5];
                    codePattern = codePattern.Trim();
                }

                if (values2.Length>1)
                {
                    if (Convert.ToBoolean(values2[2]))
                    {
                        isReversal = true;
                    }
                }
                if (values3.Length > 1)
                {               
                    weightComm.Close();
                    weightComm._serialPort.PortName = values3[0];
                    weightComm._serialPort.BaudRate = Convert.ToInt32(values3[1]);
                    if (values3.Length > 2) workConsole = values3[2];
                    weightComm.Open();
                }
                if(values4.Length>0)
                {
                    if(Convert.ToBoolean(values4[0]))
                    {
                        isSavaCode = true;
                    }
                    if (Convert.ToBoolean(values4[1]))
                    {
                        isOpenVoice = true;
                    }
                }
                if (values2.Length > 1)
                {
                    serialComm.Close();
                    serialComm._serialPort.PortName = values2[0];
                    serialComm._serialPort.BaudRate = Convert.ToInt32(values2[1]);
                    serialComm.Open();
                }
            }
            catch(Exception ex)
            {
                //Catcher.Show(ex);
            }
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度        

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Show();
            }
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Initializenotifyicon();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            weightStr = "000.000";
            if (stopTime>0)
            {
                stopTime--;
                if(stopTime<=0)
                {
                    StopForward();
                    stopTime = 0;
                }
            }
            if(weightComm.IsOpen)           
                lbWeighter.BackColor = Color.Lime;
            else
                lbWeighter.BackColor = Color.Red;
            if (serialComm.IsOpen)
                lbRun.BackColor = Color.Lime;
            else
                lbRun.BackColor = Color.Red;

            if (NetWork.IsConnectInternet())            
                lbNetwork.BackColor = Color.Lime;     
            else
                lbNetwork.BackColor = Color.Red;

            if (CodeSum != 0)
            {
                nowtick = TimeTransitionHelper.GetCurrentTimeUnix();           
                rate = (CodeSum /((nowtick - firsttick+1)/60.0));
                lbRate.Text = "速率    " + rate.ToString("#0.00") + "件/分钟";
            }
        }
        private void SaveLog()
        {
            try
            {
                if (isSavaCode)
                {
                    string time = DateTime.Now.ToString();
                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\条码记录";
                    if (!System.IO.Directory.Exists(dir))
                    {
                        //创建pic文件夹
                        System.IO.Directory.CreateDirectory(dir);
                    }
                    string time2 = Regex.Replace(time, pattern, string.Empty, RegexOptions.IgnoreCase);
                    ExcelHelper.ExportToExcel(dt, dir + "\\" + time2 + ".xls");
                }
            }
            catch(Exception ex)
            {

            }

        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            setControls(newx, newy, groupBox1);
            setControls(newx, newy, dgvData);
            setControls(newx, newy, panel1);
        }

        #endregion


        #region 最小化到任务栏
        private ContextMenu notifyiconMnu;
        private string port;

        /// <summary>
        /// 最小化到任务栏
        /// </summary>
        private void Initializenotifyicon()
        {
            //定义一个MenuItem数组，并把此数组同时赋值给ContextMenu对象 
            MenuItem[] mnuItms = new MenuItem[3];
            mnuItms[0] = new MenuItem();
            mnuItms[0].Text = "显示窗口";
            mnuItms[0].Click += new System.EventHandler(this.notifyIcon1_showfrom);

            mnuItms[1] = new MenuItem("-");

            mnuItms[2] = new MenuItem();
            mnuItms[2].Text = "退出系统";
            mnuItms[2].Click += new System.EventHandler(this.ExitSelect);
            mnuItms[2].DefaultItem = true;

            notifyiconMnu = new ContextMenu(mnuItms);
            notifyIcon1.ContextMenu = notifyiconMnu;
            //为托盘程序加入设定好的ContextMenu对象 
        }

        public void notifyIcon1_showfrom(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        public void ExitSelect(object sender, System.EventArgs e)
        {
            //隐藏托盘程序中的图标 
            notifyIcon1.Visible = false;
            //关闭系统 
            this.Dispose(true);
            Environment.Exit(0);
        }
        #endregion
    }
}
