namespace IDMS.ReportContent
{
    partial class IMAGE_REPORT_2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IMAGE = new System.Windows.Forms.Panel();
            this.VIEWSELECT_BTN = new System.Windows.Forms.Button();
            this.VIEWALL_BTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MARK_PANEL = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // IMAGE
            // 
            this.IMAGE.AutoScroll = true;
            this.IMAGE.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.IMAGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IMAGE.Location = new System.Drawing.Point(3, 2);
            this.IMAGE.Name = "IMAGE";
            this.IMAGE.Size = new System.Drawing.Size(1068, 742);
            this.IMAGE.TabIndex = 0;
            // 
            // VIEWSELECT_BTN
            // 
            this.VIEWSELECT_BTN.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VIEWSELECT_BTN.Location = new System.Drawing.Point(113, 750);
            this.VIEWSELECT_BTN.Name = "VIEWSELECT_BTN";
            this.VIEWSELECT_BTN.Size = new System.Drawing.Size(102, 26);
            this.VIEWSELECT_BTN.TabIndex = 5;
            this.VIEWSELECT_BTN.Text = "View Selected";
            this.VIEWSELECT_BTN.UseVisualStyleBackColor = false;
            this.VIEWSELECT_BTN.Click += new System.EventHandler(this.VIEWSELECT_BTN_Click);
            // 
            // VIEWALL_BTN
            // 
            this.VIEWALL_BTN.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VIEWALL_BTN.Location = new System.Drawing.Point(6, 750);
            this.VIEWALL_BTN.Name = "VIEWALL_BTN";
            this.VIEWALL_BTN.Size = new System.Drawing.Size(101, 26);
            this.VIEWALL_BTN.TabIndex = 4;
            this.VIEWALL_BTN.Text = "View All";
            this.VIEWALL_BTN.UseVisualStyleBackColor = false;
            this.VIEWALL_BTN.Click += new System.EventHandler(this.VIEWALL_BTN_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(775, 750);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(926, 751);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select All";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MARK_PANEL
            // 
            this.MARK_PANEL.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MARK_PANEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MARK_PANEL.Location = new System.Drawing.Point(1084, 13);
            this.MARK_PANEL.Name = "MARK_PANEL";
            this.MARK_PANEL.Size = new System.Drawing.Size(522, 780);
            this.MARK_PANEL.TabIndex = 1;
            // 
            // IMAGE_REPORT_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.VIEWSELECT_BTN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MARK_PANEL);
            this.Controls.Add(this.VIEWALL_BTN);
            this.Controls.Add(this.IMAGE);
            this.DoubleBuffered = true;
            this.Name = "IMAGE_REPORT_2";
            this.Size = new System.Drawing.Size(1614, 802);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel IMAGE;
        private System.Windows.Forms.Panel MARK_PANEL;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button VIEWSELECT_BTN;
        private System.Windows.Forms.Button VIEWALL_BTN;
    }
}
