namespace IDMS
{
    partial class idmsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(idmsPage));
            this.IDMS_Main = new System.Windows.Forms.TableLayoutPanel();
            this.IDMSleftPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Statistic = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.IDMSrightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menu_Panel = new System.Windows.Forms.Panel();
            this.Btnpanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.Minbtn = new System.Windows.Forms.Button();
            this.usercontrolPanel = new System.Windows.Forms.Panel();
            this.IDMS_Main.SuspendLayout();
            this.IDMSleftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.IDMSrightPanel.SuspendLayout();
            this.menu_Panel.SuspendLayout();
            this.Btnpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDMS_Main
            // 
            this.IDMS_Main.BackColor = System.Drawing.SystemColors.Control;
            this.IDMS_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IDMS_Main.ColumnCount = 2;
            this.IDMS_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.538462F));
            this.IDMS_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.46154F));
            this.IDMS_Main.Controls.Add(this.IDMSleftPanel, 0, 0);
            this.IDMS_Main.Controls.Add(this.IDMSrightPanel, 1, 0);
            this.IDMS_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDMS_Main.Location = new System.Drawing.Point(0, 0);
            this.IDMS_Main.Name = "IDMS_Main";
            this.IDMS_Main.RowCount = 1;
            this.IDMS_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IDMS_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 788F));
            this.IDMS_Main.Size = new System.Drawing.Size(1820, 1040);
            this.IDMS_Main.TabIndex = 1;
            // 
            // IDMSleftPanel
            // 
            this.IDMSleftPanel.BackColor = System.Drawing.Color.Transparent;
            this.IDMSleftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IDMSleftPanel.BackgroundImage")));
            this.IDMSleftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IDMSleftPanel.Controls.Add(this.button1);
            this.IDMSleftPanel.Controls.Add(this.Statistic);
            this.IDMSleftPanel.Controls.Add(this.Logo);
            this.IDMSleftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDMSleftPanel.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDMSleftPanel.Location = new System.Drawing.Point(3, 3);
            this.IDMSleftPanel.Name = "IDMSleftPanel";
            this.IDMSleftPanel.Size = new System.Drawing.Size(113, 1034);
            this.IDMSleftPanel.TabIndex = 0;
            this.IDMSleftPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseDown);
            this.IDMSleftPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseMove);
            this.IDMSleftPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 927);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 84);
            this.button1.TabIndex = 2;
            this.button1.Text = "Setting";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Statistic
            // 
            this.Statistic.BackColor = System.Drawing.Color.Transparent;
            this.Statistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Statistic.FlatAppearance.BorderSize = 0;
            this.Statistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Statistic.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statistic.ForeColor = System.Drawing.Color.White;
            this.Statistic.Image = ((System.Drawing.Image)(resources.GetObject("Statistic.Image")));
            this.Statistic.Location = new System.Drawing.Point(0, 842);
            this.Statistic.Name = "Statistic";
            this.Statistic.Size = new System.Drawing.Size(113, 84);
            this.Statistic.TabIndex = 1;
            this.Statistic.Text = "Statistic";
            this.Statistic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Statistic.UseVisualStyleBackColor = false;
            this.Statistic.Visible = false;
            this.Statistic.Click += new System.EventHandler(this.Statistic_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo.Location = new System.Drawing.Point(28, 34);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(60, 60);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // IDMSrightPanel
            // 
            this.IDMSrightPanel.BackColor = System.Drawing.SystemColors.Control;
            this.IDMSrightPanel.ColumnCount = 1;
            this.IDMSrightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IDMSrightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.IDMSrightPanel.Controls.Add(this.menu_Panel, 0, 0);
            this.IDMSrightPanel.Controls.Add(this.usercontrolPanel, 0, 1);
            this.IDMSrightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDMSrightPanel.Location = new System.Drawing.Point(122, 3);
            this.IDMSrightPanel.Name = "IDMSrightPanel";
            this.IDMSrightPanel.RowCount = 2;
            this.IDMSrightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.IDMSrightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.IDMSrightPanel.Size = new System.Drawing.Size(1695, 1034);
            this.IDMSrightPanel.TabIndex = 1;
            // 
            // menu_Panel
            // 
            this.menu_Panel.BackColor = System.Drawing.Color.Transparent;
            this.menu_Panel.Controls.Add(this.Btnpanel);
            this.menu_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu_Panel.Location = new System.Drawing.Point(3, 3);
            this.menu_Panel.Name = "menu_Panel";
            this.menu_Panel.Size = new System.Drawing.Size(1689, 45);
            this.menu_Panel.TabIndex = 0;
            this.menu_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseDown);
            this.menu_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseMove);
            this.menu_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelMove_MouseUp);
            // 
            // Btnpanel
            // 
            this.Btnpanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btnpanel.BackColor = System.Drawing.Color.Transparent;
            this.Btnpanel.Controls.Add(this.CloseBtn);
            this.Btnpanel.Controls.Add(this.Minbtn);
            this.Btnpanel.Location = new System.Drawing.Point(1597, 7);
            this.Btnpanel.Name = "Btnpanel";
            this.Btnpanel.Size = new System.Drawing.Size(92, 30);
            this.Btnpanel.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CloseBtn.Location = new System.Drawing.Point(47, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(45, 30);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Minbtn
            // 
            this.Minbtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.Minbtn.FlatAppearance.BorderSize = 0;
            this.Minbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minbtn.Location = new System.Drawing.Point(0, 0);
            this.Minbtn.Name = "Minbtn";
            this.Minbtn.Size = new System.Drawing.Size(46, 30);
            this.Minbtn.TabIndex = 1;
            this.Minbtn.Text = "__";
            this.Minbtn.UseVisualStyleBackColor = true;
            // 
            // usercontrolPanel
            // 
            this.usercontrolPanel.AutoScroll = true;
            this.usercontrolPanel.BackColor = System.Drawing.Color.Transparent;
            this.usercontrolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usercontrolPanel.Location = new System.Drawing.Point(3, 54);
            this.usercontrolPanel.Name = "usercontrolPanel";
            this.usercontrolPanel.Size = new System.Drawing.Size(1689, 977);
            this.usercontrolPanel.TabIndex = 1;
            // 
            // idmsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1820, 1040);
            this.ControlBox = false;
            this.Controls.Add(this.IDMS_Main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "idmsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IDMS_FormClosing);
            this.Shown += new System.EventHandler(this.firstPage_Shown);
            this.IDMS_Main.ResumeLayout(false);
            this.IDMSleftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.IDMSrightPanel.ResumeLayout(false);
            this.menu_Panel.ResumeLayout(false);
            this.Btnpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel IDMS_Main;
        private System.Windows.Forms.Panel IDMSleftPanel;
        private System.Windows.Forms.TableLayoutPanel IDMSrightPanel;
        private System.Windows.Forms.Panel menu_Panel;
        private System.Windows.Forms.Panel Btnpanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button Minbtn;
        private System.Windows.Forms.Panel usercontrolPanel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Statistic;
    }
}

