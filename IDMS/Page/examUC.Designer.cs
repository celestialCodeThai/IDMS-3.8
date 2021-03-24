using System;

namespace IDMS.Page
{
    partial class examUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(examUC));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rec = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.screenShotBtn = new System.Windows.Forms.Button();
            this.settingButton = new System.Windows.Forms.Button();
            this.hideRightBar = new System.Windows.Forms.Panel();
            this.videoPanel = new AForge.Controls.PictureBox();
            this.BRONCO = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ERCP = new System.Windows.Forms.RadioButton();
            this.colono = new System.Windows.Forms.RadioButton();
            this.egd = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pro = new System.Windows.Forms.Label();
            this.patientFirstName = new System.Windows.Forms.TextBox();
            this.patientAge = new System.Windows.Forms.TextBox();
            this.sex = new System.Windows.Forms.TextBox();
            this.patientLastName = new System.Windows.Forms.TextBox();
            this.patientHN = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.screenCaptureList = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.videoCaptureList = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new AForge.Controls.PictureBox();
            this.ExamLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MODE = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ENT = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoPanel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(176, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 628);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rec);
            this.panel1.Controls.Add(this.Connect);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.hideRightBar);
            this.panel1.Controls.Add(this.videoPanel);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 597);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rec
            // 
            this.rec.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rec.BackColor = System.Drawing.Color.Maroon;
            this.rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rec.ForeColor = System.Drawing.Color.White;
            this.rec.Image = ((System.Drawing.Image)(resources.GetObject("rec.Image")));
            this.rec.Location = new System.Drawing.Point(9, -72);
            this.rec.Name = "rec";
            this.rec.Size = new System.Drawing.Size(120, 40);
            this.rec.TabIndex = 19;
            this.rec.Text = "REC";
            this.rec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rec.UseVisualStyleBackColor = false;
            this.rec.Visible = false;
            // 
            // Connect
            // 
            this.Connect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Connect.BackColor = System.Drawing.Color.Black;
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Connect.ForeColor = System.Drawing.Color.White;
            this.Connect.Location = new System.Drawing.Point(135, -72);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(120, 40);
            this.Connect.TabIndex = 11;
            this.Connect.Text = "Connect";
            this.Connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.screenShotBtn);
            this.flowLayoutPanel1.Controls.Add(this.settingButton);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 536);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(504, 59);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(162, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Record";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // screenShotBtn
            // 
            this.screenShotBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.screenShotBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.screenShotBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.screenShotBtn.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenShotBtn.ForeColor = System.Drawing.Color.White;
            this.screenShotBtn.Image = ((System.Drawing.Image)(resources.GetObject("screenShotBtn.Image")));
            this.screenShotBtn.Location = new System.Drawing.Point(171, 3);
            this.screenShotBtn.Name = "screenShotBtn";
            this.screenShotBtn.Size = new System.Drawing.Size(167, 49);
            this.screenShotBtn.TabIndex = 10;
            this.screenShotBtn.Text = "Capture";
            this.screenShotBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.screenShotBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.screenShotBtn.UseVisualStyleBackColor = false;
            this.screenShotBtn.Click += new System.EventHandler(this.screenShotBtn_Click);
            // 
            // settingButton
            // 
            this.settingButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.settingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.settingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingButton.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingButton.Location = new System.Drawing.Point(344, 3);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(145, 49);
            this.settingButton.TabIndex = 20;
            this.settingButton.Text = "Port Setting";
            this.settingButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingButton.UseVisualStyleBackColor = false;
            this.settingButton.Visible = false;
            // 
            // hideRightBar
            // 
            this.hideRightBar.BackColor = System.Drawing.SystemColors.Control;
            this.hideRightBar.Location = new System.Drawing.Point(550, 63);
            this.hideRightBar.Name = "hideRightBar";
            this.hideRightBar.Size = new System.Drawing.Size(240, 460);
            this.hideRightBar.TabIndex = 27;
            this.hideRightBar.Visible = false;
            // 
            // videoPanel
            // 
            this.videoPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.videoPanel.Image = null;
            this.videoPanel.Location = new System.Drawing.Point(9, 63);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(760, 460);
            this.videoPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoPanel.TabIndex = 25;
            this.videoPanel.TabStop = false;
            // 
            // BRONCO
            // 
            this.BRONCO.AutoSize = true;
            this.BRONCO.Enabled = false;
            this.BRONCO.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRONCO.Location = new System.Drawing.Point(39, 211);
            this.BRONCO.Name = "BRONCO";
            this.BRONCO.Size = new System.Drawing.Size(93, 25);
            this.BRONCO.TabIndex = 21;
            this.BRONCO.TabStop = true;
            this.BRONCO.Text = "BRONCO";
            this.BRONCO.UseVisualStyleBackColor = true;
            this.BRONCO.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Image Procedure";
            // 
            // ERCP
            // 
            this.ERCP.AutoSize = true;
            this.ERCP.Enabled = false;
            this.ERCP.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ERCP.Location = new System.Drawing.Point(14, 111);
            this.ERCP.Name = "ERCP";
            this.ERCP.Size = new System.Drawing.Size(65, 25);
            this.ERCP.TabIndex = 2;
            this.ERCP.TabStop = true;
            this.ERCP.Text = "ERCP";
            this.ERCP.UseVisualStyleBackColor = true;
            // 
            // colono
            // 
            this.colono.AutoSize = true;
            this.colono.Enabled = false;
            this.colono.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colono.Location = new System.Drawing.Point(14, 80);
            this.colono.Name = "colono";
            this.colono.Size = new System.Drawing.Size(118, 25);
            this.colono.TabIndex = 1;
            this.colono.TabStop = true;
            this.colono.Text = "Colonoscopy";
            this.colono.UseVisualStyleBackColor = true;
            // 
            // egd
            // 
            this.egd.AutoSize = true;
            this.egd.Enabled = false;
            this.egd.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.egd.Location = new System.Drawing.Point(14, 49);
            this.egd.Name = "egd";
            this.egd.Size = new System.Drawing.Size(58, 25);
            this.egd.TabIndex = 0;
            this.egd.TabStop = true;
            this.egd.Text = "EGD";
            this.egd.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(1497, 36);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 49);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Save";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pro);
            this.groupBox3.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1034, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 80);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procedure";
            // 
            // pro
            // 
            this.pro.AutoSize = true;
            this.pro.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro.Location = new System.Drawing.Point(9, 32);
            this.pro.Name = "pro";
            this.pro.Size = new System.Drawing.Size(84, 32);
            this.pro.TabIndex = 0;
            this.pro.Text = "label1";
            // 
            // patientFirstName
            // 
            this.patientFirstName.Location = new System.Drawing.Point(118, 70);
            this.patientFirstName.Name = "patientFirstName";
            this.patientFirstName.ReadOnly = true;
            this.patientFirstName.Size = new System.Drawing.Size(429, 33);
            this.patientFirstName.TabIndex = 16;
            // 
            // patientAge
            // 
            this.patientAge.Location = new System.Drawing.Point(118, 148);
            this.patientAge.MaxLength = 3;
            this.patientAge.Name = "patientAge";
            this.patientAge.ReadOnly = true;
            this.patientAge.Size = new System.Drawing.Size(69, 33);
            this.patientAge.TabIndex = 4;
            // 
            // sex
            // 
            this.sex.Location = new System.Drawing.Point(118, 187);
            this.sex.MaxLength = 3;
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Size = new System.Drawing.Size(89, 33);
            this.sex.TabIndex = 6;
            // 
            // patientLastName
            // 
            this.patientLastName.Location = new System.Drawing.Point(118, 109);
            this.patientLastName.Name = "patientLastName";
            this.patientLastName.ReadOnly = true;
            this.patientLastName.Size = new System.Drawing.Size(429, 33);
            this.patientLastName.TabIndex = 3;
            // 
            // patientHN
            // 
            this.patientHN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.patientHN.Location = new System.Drawing.Point(118, 31);
            this.patientHN.Name = "patientHN";
            this.patientHN.ReadOnly = true;
            this.patientHN.Size = new System.Drawing.Size(429, 33);
            this.patientHN.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1034, 427);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 513);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.screenCaptureList);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pictures";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // screenCaptureList
            // 
            this.screenCaptureList.AutoScroll = true;
            this.screenCaptureList.BackColor = System.Drawing.Color.White;
            this.screenCaptureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenCaptureList.Location = new System.Drawing.Point(3, 3);
            this.screenCaptureList.Margin = new System.Windows.Forms.Padding(0);
            this.screenCaptureList.Name = "screenCaptureList";
            this.screenCaptureList.Size = new System.Drawing.Size(569, 469);
            this.screenCaptureList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.videoCaptureList);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(575, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // videoCaptureList
            // 
            this.videoCaptureList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.videoCaptureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoCaptureList.ItemHeight = 25;
            this.videoCaptureList.Location = new System.Drawing.Point(0, 0);
            this.videoCaptureList.Margin = new System.Windows.Forms.Padding(0);
            this.videoCaptureList.Name = "videoCaptureList";
            this.videoCaptureList.Size = new System.Drawing.Size(575, 475);
            this.videoCaptureList.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(10, 715);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ExamLabel
            // 
            this.ExamLabel.AutoSize = true;
            this.ExamLabel.Font = new System.Drawing.Font("Leelawadee UI", 39F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExamLabel.Location = new System.Drawing.Point(19, 0);
            this.ExamLabel.Name = "ExamLabel";
            this.ExamLabel.Size = new System.Drawing.Size(335, 70);
            this.ExamLabel.TabIndex = 22;
            this.ExamLabel.Text = "Examination";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.patientHN);
            this.groupBox2.Controls.Add(this.patientAge);
            this.groupBox2.Controls.Add(this.sex);
            this.groupBox2.Controls.Add(this.patientFirstName);
            this.groupBox2.Controls.Add(this.patientLastName);
            this.groupBox2.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1034, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 230);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patient\'s information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.label6.Location = new System.Drawing.Point(10, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Gender:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.label5.Location = new System.Drawing.Point(10, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.label4.Location = new System.Drawing.Point(10, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "HN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.label3.Location = new System.Drawing.Point(10, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Last name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "First name:";
            // 
            // MODE
            // 
            this.MODE.AutoSize = true;
            this.MODE.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODE.Location = new System.Drawing.Point(340, 44);
            this.MODE.Name = "MODE";
            this.MODE.Size = new System.Drawing.Size(86, 15);
            this.MODE.TabIndex = 24;
            this.MODE.Text = "Normal MODE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ENT);
            this.groupBox4.Controls.Add(this.egd);
            this.groupBox4.Controls.Add(this.colono);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.BRONCO);
            this.groupBox4.Controls.Add(this.ERCP);
            this.groupBox4.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(10, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 628);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // ENT
            // 
            this.ENT.AutoSize = true;
            this.ENT.Enabled = false;
            this.ENT.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENT.Location = new System.Drawing.Point(39, 250);
            this.ENT.Name = "ENT";
            this.ENT.Size = new System.Drawing.Size(56, 25);
            this.ENT.TabIndex = 22;
            this.ENT.TabStop = true;
            this.ENT.Text = "ENT";
            this.ENT.UseVisualStyleBackColor = true;
            this.ENT.Visible = false;
            // 
            // examUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.MODE);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.ExamLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "examUC";
            this.Size = new System.Drawing.Size(1680, 977);
            this.Load += new System.EventHandler(this.ExaminationPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoPanel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button screenShotBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox patientFirstName;
        private System.Windows.Forms.TextBox patientAge;
        private System.Windows.Forms.TextBox patientLastName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.FlowLayoutPanel screenCaptureList;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListBox videoCaptureList;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.Label ExamLabel;
        public System.Windows.Forms.TextBox patientHN;
        private System.Windows.Forms.Label pro;
        private System.Windows.Forms.TextBox sex;
        public System.Windows.Forms.Button Connect;
        public System.Windows.Forms.Button rec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ERCP;
        private System.Windows.Forms.RadioButton colono;
        private System.Windows.Forms.RadioButton egd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton BRONCO;
        private AForge.Controls.PictureBox pictureBox1;
        private AForge.Controls.PictureBox videoPanel;
        private System.Windows.Forms.Panel hideRightBar;
        private System.Windows.Forms.Label MODE;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton ENT;
    }
}