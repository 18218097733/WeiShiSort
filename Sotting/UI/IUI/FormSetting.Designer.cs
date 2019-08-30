namespace UI.IUI
{
    partial class FormSetting
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
            this.tCtest = new System.Windows.Forms.TabControl();
            this.tabPageHttp = new System.Windows.Forms.TabPage();
            this.btHttp = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageWalk = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxReversal = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btForword = new System.Windows.Forms.Button();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.btRun = new System.Windows.Forms.Button();
            this.cBBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBCom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageWeigher = new System.Windows.Forms.TabPage();
            this.cbWorkSole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btWeight = new System.Windows.Forms.Button();
            this.cBWeightBaund = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBWeightComm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageCode = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cB_filter = new System.Windows.Forms.CheckBox();
            this.tB_Rule = new System.Windows.Forms.TextBox();
            this.lable11 = new System.Windows.Forms.Label();
            this.btCode = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cB_Code128 = new System.Windows.Forms.CheckBox();
            this.cBEAN13 = new System.Windows.Forms.CheckBox();
            this.cB_Code39 = new System.Windows.Forms.CheckBox();
            this.cB_Code93 = new System.Windows.Forms.CheckBox();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.buttonOther = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cB_voice = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveCode = new System.Windows.Forms.CheckBox();
            this.tCtest.SuspendLayout();
            this.tabPageHttp.SuspendLayout();
            this.tabPageWalk.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageWeigher.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tCtest
            // 
            this.tCtest.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tCtest.Controls.Add(this.tabPageHttp);
            this.tCtest.Controls.Add(this.tabPageWalk);
            this.tCtest.Controls.Add(this.tabPageWeigher);
            this.tCtest.Controls.Add(this.tabPageCode);
            this.tCtest.Controls.Add(this.tabPageOther);
            this.tCtest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCtest.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tCtest.ItemSize = new System.Drawing.Size(40, 100);
            this.tCtest.Location = new System.Drawing.Point(0, 0);
            this.tCtest.Multiline = true;
            this.tCtest.Name = "tCtest";
            this.tCtest.SelectedIndex = 0;
            this.tCtest.Size = new System.Drawing.Size(634, 290);
            this.tCtest.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tCtest.TabIndex = 0;
            this.tCtest.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TCtest_DrawItem);
            // 
            // tabPageHttp
            // 
            this.tabPageHttp.BackColor = System.Drawing.Color.LightGreen;
            this.tabPageHttp.Controls.Add(this.btHttp);
            this.tabPageHttp.Controls.Add(this.tbURL);
            this.tabPageHttp.Controls.Add(this.label3);
            this.tabPageHttp.Location = new System.Drawing.Point(104, 4);
            this.tabPageHttp.Name = "tabPageHttp";
            this.tabPageHttp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHttp.Size = new System.Drawing.Size(526, 282);
            this.tabPageHttp.TabIndex = 0;
            this.tabPageHttp.Text = "Http设置";
            // 
            // btHttp
            // 
            this.btHttp.Location = new System.Drawing.Point(451, 259);
            this.btHttp.Name = "btHttp";
            this.btHttp.Size = new System.Drawing.Size(75, 23);
            this.btHttp.TabIndex = 8;
            this.btHttp.Text = "确定";
            this.btHttp.UseVisualStyleBackColor = true;
            this.btHttp.Click += new System.EventHandler(this.btHttp_Click);
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(75, 35);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(443, 21);
            this.tbURL.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "URL";
            // 
            // tabPageWalk
            // 
            this.tabPageWalk.BackColor = System.Drawing.Color.LightGreen;
            this.tabPageWalk.Controls.Add(this.label10);
            this.tabPageWalk.Controls.Add(this.checkBoxReversal);
            this.tabPageWalk.Controls.Add(this.groupBox1);
            this.tabPageWalk.Controls.Add(this.btRun);
            this.tabPageWalk.Controls.Add(this.cBBaud);
            this.tabPageWalk.Controls.Add(this.label2);
            this.tabPageWalk.Controls.Add(this.cBCom);
            this.tabPageWalk.Controls.Add(this.label1);
            this.tabPageWalk.Location = new System.Drawing.Point(104, 4);
            this.tabPageWalk.Name = "tabPageWalk";
            this.tabPageWalk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWalk.Size = new System.Drawing.Size(526, 282);
            this.tabPageWalk.TabIndex = 1;
            this.tabPageWalk.Text = "跑步机设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "传送带方向:";
            // 
            // checkBoxReversal
            // 
            this.checkBoxReversal.AutoSize = true;
            this.checkBoxReversal.Location = new System.Drawing.Point(114, 90);
            this.checkBoxReversal.Name = "checkBoxReversal";
            this.checkBoxReversal.Size = new System.Drawing.Size(84, 16);
            this.checkBoxReversal.TabIndex = 9;
            this.checkBoxReversal.Text = "传送带反转";
            this.checkBoxReversal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btStop);
            this.groupBox1.Controls.Add(this.btBack);
            this.groupBox1.Controls.Add(this.btForword);
            this.groupBox1.Controls.Add(this.checkBoxTest);
            this.groupBox1.Location = new System.Drawing.Point(23, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 133);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(230, 104);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(186, 23);
            this.btStop.TabIndex = 4;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(230, 63);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(186, 23);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "反转";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // btForword
            // 
            this.btForword.Location = new System.Drawing.Point(230, 20);
            this.btForword.Name = "btForword";
            this.btForword.Size = new System.Drawing.Size(186, 23);
            this.btForword.TabIndex = 2;
            this.btForword.Text = "正转";
            this.btForword.UseVisualStyleBackColor = true;
            this.btForword.Click += new System.EventHandler(this.BtForword_Click);
            // 
            // checkBoxTest
            // 
            this.checkBoxTest.AutoSize = true;
            this.checkBoxTest.Location = new System.Drawing.Point(6, 63);
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.Size = new System.Drawing.Size(84, 16);
            this.checkBoxTest.TabIndex = 1;
            this.checkBoxTest.Text = "跑步机测试";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            this.checkBoxTest.CheckedChanged += new System.EventHandler(this.CheckBoxTest_CheckedChanged);
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(451, 259);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 7;
            this.btRun.Text = "确定";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // cBBaud
            // 
            this.cBBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBBaud.FormattingEnabled = true;
            this.cBBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cBBaud.Location = new System.Drawing.Point(114, 54);
            this.cBBaud.Name = "cBBaud";
            this.cBBaud.Size = new System.Drawing.Size(95, 20);
            this.cBBaud.TabIndex = 3;
            this.cBBaud.SelectedIndexChanged += new System.EventHandler(this.CBCom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率:";
            // 
            // cBCom
            // 
            this.cBCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBCom.FormattingEnabled = true;
            this.cBCom.Location = new System.Drawing.Point(114, 16);
            this.cBCom.Name = "cBCom";
            this.cBCom.Size = new System.Drawing.Size(95, 20);
            this.cBCom.TabIndex = 1;
            this.cBCom.SelectedIndexChanged += new System.EventHandler(this.CBCom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口设置:";
            // 
            // tabPageWeigher
            // 
            this.tabPageWeigher.BackColor = System.Drawing.Color.LightGreen;
            this.tabPageWeigher.Controls.Add(this.cbWorkSole);
            this.tabPageWeigher.Controls.Add(this.label7);
            this.tabPageWeigher.Controls.Add(this.btWeight);
            this.tabPageWeigher.Controls.Add(this.cBWeightBaund);
            this.tabPageWeigher.Controls.Add(this.label5);
            this.tabPageWeigher.Controls.Add(this.cBWeightComm);
            this.tabPageWeigher.Controls.Add(this.label6);
            this.tabPageWeigher.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageWeigher.Location = new System.Drawing.Point(104, 4);
            this.tabPageWeigher.Name = "tabPageWeigher";
            this.tabPageWeigher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeigher.Size = new System.Drawing.Size(526, 282);
            this.tabPageWeigher.TabIndex = 2;
            this.tabPageWeigher.Text = "称台号";
            // 
            // cbWorkSole
            // 
            this.cbWorkSole.AutoCompleteCustomSource.AddRange(new string[] {
            "SM01",
            "SM02",
            "SM03",
            "SM04",
            "SM05",
            "SM06",
            "SM07",
            "SM08",
            "SM09"});
            this.cbWorkSole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkSole.FormattingEnabled = true;
            this.cbWorkSole.Items.AddRange(new object[] {
            "SM01",
            "SM02",
            "SM03",
            "SM04",
            "SM05",
            "SM06",
            "SM07",
            "SM08",
            "SM09",
            "SM10",
            "SM11",
            "SM12",
            "SM13",
            "SM14",
            "SM15",
            "SM16",
            "SM17",
            "SM18",
            "SM19",
            "SM20"});
            this.cbWorkSole.Location = new System.Drawing.Point(133, 99);
            this.cbWorkSole.Name = "cbWorkSole";
            this.cbWorkSole.Size = new System.Drawing.Size(95, 20);
            this.cbWorkSole.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "称台号:";
            // 
            // btWeight
            // 
            this.btWeight.Location = new System.Drawing.Point(451, 259);
            this.btWeight.Name = "btWeight";
            this.btWeight.Size = new System.Drawing.Size(75, 23);
            this.btWeight.TabIndex = 8;
            this.btWeight.Text = "确定";
            this.btWeight.UseVisualStyleBackColor = true;
            this.btWeight.Click += new System.EventHandler(this.btWeight_Click);
            // 
            // cBWeightBaund
            // 
            this.cBWeightBaund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBWeightBaund.FormattingEnabled = true;
            this.cBWeightBaund.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cBWeightBaund.Location = new System.Drawing.Point(133, 57);
            this.cBWeightBaund.Name = "cBWeightBaund";
            this.cBWeightBaund.Size = new System.Drawing.Size(95, 20);
            this.cBWeightBaund.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "波特率:";
            // 
            // cBWeightComm
            // 
            this.cBWeightComm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBWeightComm.FormattingEnabled = true;
            this.cBWeightComm.Location = new System.Drawing.Point(133, 19);
            this.cBWeightComm.Name = "cBWeightComm";
            this.cBWeightComm.Size = new System.Drawing.Size(95, 20);
            this.cBWeightComm.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "串口设置:";
            // 
            // tabPageCode
            // 
            this.tabPageCode.BackColor = System.Drawing.Color.LightGreen;
            this.tabPageCode.Controls.Add(this.groupBox4);
            this.tabPageCode.Controls.Add(this.btCode);
            this.tabPageCode.Controls.Add(this.GroupBox3);
            this.tabPageCode.Location = new System.Drawing.Point(104, 4);
            this.tabPageCode.Name = "tabPageCode";
            this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCode.Size = new System.Drawing.Size(526, 282);
            this.tabPageCode.TabIndex = 4;
            this.tabPageCode.Text = "扫码设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cB_filter);
            this.groupBox4.Controls.Add(this.tB_Rule);
            this.groupBox4.Controls.Add(this.lable11);
            this.groupBox4.Location = new System.Drawing.Point(30, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 175);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "条码过滤";
            // 
            // cB_filter
            // 
            this.cB_filter.AutoSize = true;
            this.cB_filter.Location = new System.Drawing.Point(6, 20);
            this.cB_filter.Name = "cB_filter";
            this.cB_filter.Size = new System.Drawing.Size(96, 16);
            this.cB_filter.TabIndex = 8;
            this.cB_filter.Text = "特殊字符过滤";
            this.cB_filter.UseVisualStyleBackColor = true;
            // 
            // tB_Rule
            // 
            this.tB_Rule.Location = new System.Drawing.Point(8, 57);
            this.tB_Rule.Multiline = true;
            this.tB_Rule.Name = "tB_Rule";
            this.tB_Rule.Size = new System.Drawing.Size(449, 112);
            this.tB_Rule.TabIndex = 7;
            // 
            // lable11
            // 
            this.lable11.AutoSize = true;
            this.lable11.Location = new System.Drawing.Point(6, 42);
            this.lable11.Name = "lable11";
            this.lable11.Size = new System.Drawing.Size(101, 12);
            this.lable11.TabIndex = 6;
            this.lable11.Text = "自定义过滤规则：";
            // 
            // btCode
            // 
            this.btCode.Location = new System.Drawing.Point(451, 259);
            this.btCode.Name = "btCode";
            this.btCode.Size = new System.Drawing.Size(75, 23);
            this.btCode.TabIndex = 5;
            this.btCode.Text = "确定";
            this.btCode.UseVisualStyleBackColor = true;
            this.btCode.Click += new System.EventHandler(this.BtCode_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cB_Code128);
            this.GroupBox3.Controls.Add(this.cBEAN13);
            this.GroupBox3.Controls.Add(this.cB_Code39);
            this.GroupBox3.Controls.Add(this.cB_Code93);
            this.GroupBox3.Location = new System.Drawing.Point(30, 8);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(443, 64);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "条码类型";
            // 
            // cB_Code128
            // 
            this.cB_Code128.AutoSize = true;
            this.cB_Code128.Location = new System.Drawing.Point(6, 30);
            this.cB_Code128.Name = "cB_Code128";
            this.cB_Code128.Size = new System.Drawing.Size(72, 16);
            this.cB_Code128.TabIndex = 0;
            this.cB_Code128.Text = "Code 128";
            this.cB_Code128.UseVisualStyleBackColor = true;
            // 
            // cBEAN13
            // 
            this.cBEAN13.AutoSize = true;
            this.cBEAN13.Location = new System.Drawing.Point(303, 30);
            this.cBEAN13.Name = "cBEAN13";
            this.cBEAN13.Size = new System.Drawing.Size(60, 16);
            this.cBEAN13.TabIndex = 3;
            this.cBEAN13.Text = "EAN-13";
            this.cBEAN13.UseVisualStyleBackColor = true;
            // 
            // cB_Code39
            // 
            this.cB_Code39.AutoSize = true;
            this.cB_Code39.Location = new System.Drawing.Point(109, 30);
            this.cB_Code39.Name = "cB_Code39";
            this.cB_Code39.Size = new System.Drawing.Size(66, 16);
            this.cB_Code39.TabIndex = 1;
            this.cB_Code39.Text = "Code 39";
            this.cB_Code39.UseVisualStyleBackColor = true;
            // 
            // cB_Code93
            // 
            this.cB_Code93.AutoSize = true;
            this.cB_Code93.Location = new System.Drawing.Point(198, 30);
            this.cB_Code93.Name = "cB_Code93";
            this.cB_Code93.Size = new System.Drawing.Size(66, 16);
            this.cB_Code93.TabIndex = 2;
            this.cB_Code93.Text = "Code 93";
            this.cB_Code93.UseVisualStyleBackColor = true;
            // 
            // tabPageOther
            // 
            this.tabPageOther.BackColor = System.Drawing.Color.LightGreen;
            this.tabPageOther.Controls.Add(this.buttonOther);
            this.tabPageOther.Controls.Add(this.groupBox2);
            this.tabPageOther.Location = new System.Drawing.Point(104, 4);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(526, 282);
            this.tabPageOther.TabIndex = 3;
            this.tabPageOther.Text = "其它设置";
            // 
            // buttonOther
            // 
            this.buttonOther.Location = new System.Drawing.Point(451, 259);
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.Size = new System.Drawing.Size(75, 23);
            this.buttonOther.TabIndex = 3;
            this.buttonOther.Text = "确定";
            this.buttonOther.UseVisualStyleBackColor = true;
            this.buttonOther.Click += new System.EventHandler(this.buttonOther_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cB_voice);
            this.groupBox2.Controls.Add(this.checkBoxSaveCode);
            this.groupBox2.Location = new System.Drawing.Point(19, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 117);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cB_voice
            // 
            this.cB_voice.AutoSize = true;
            this.cB_voice.Location = new System.Drawing.Point(17, 57);
            this.cB_voice.Name = "cB_voice";
            this.cB_voice.Size = new System.Drawing.Size(72, 16);
            this.cB_voice.TabIndex = 1;
            this.cB_voice.Text = "语音提示";
            this.cB_voice.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveCode
            // 
            this.checkBoxSaveCode.AutoSize = true;
            this.checkBoxSaveCode.Location = new System.Drawing.Point(17, 20);
            this.checkBoxSaveCode.Name = "checkBoxSaveCode";
            this.checkBoxSaveCode.Size = new System.Drawing.Size(126, 16);
            this.checkBoxSaveCode.TabIndex = 0;
            this.checkBoxSaveCode.Text = "条码导出xls(桌面)";
            this.checkBoxSaveCode.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 290);
            this.Controls.Add(this.tCtest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tCtest.ResumeLayout(false);
            this.tabPageHttp.ResumeLayout(false);
            this.tabPageHttp.PerformLayout();
            this.tabPageWalk.ResumeLayout(false);
            this.tabPageWalk.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageWeigher.ResumeLayout(false);
            this.tabPageWeigher.PerformLayout();
            this.tabPageCode.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.tabPageOther.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tCtest;
        private System.Windows.Forms.TabPage tabPageHttp;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageWalk;
        private System.Windows.Forms.ComboBox cBBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageWeigher;
        private System.Windows.Forms.Button btHttp;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.ComboBox cBCom;
        private System.Windows.Forms.Button btWeight;
        private System.Windows.Forms.ComboBox cBWeightBaund;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBWeightComm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbWorkSole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.Button buttonOther;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxSaveCode;
        private System.Windows.Forms.CheckBox cB_voice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxTest;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btForword;
        private System.Windows.Forms.CheckBox checkBoxReversal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPageCode;
        private System.Windows.Forms.CheckBox cB_Code93;
        private System.Windows.Forms.CheckBox cB_Code39;
        private System.Windows.Forms.CheckBox cB_Code128;
        private System.Windows.Forms.Button btCode;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.CheckBox cBEAN13;
        private System.Windows.Forms.TextBox tB_Rule;
        private System.Windows.Forms.Label lable11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cB_filter;
    }
}