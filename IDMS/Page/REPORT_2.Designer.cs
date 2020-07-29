namespace IDMS.Page
{
    partial class REPORT_2
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
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.patientHN = new System.Windows.Forms.Label();
            this.patientSurname = new System.Windows.Forms.Label();
            this.patientFirstName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.img = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AllowDrop = true;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Leelawadee UI", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RegisterLabel.Location = new System.Drawing.Point(19, 0);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(197, 70);
            this.RegisterLabel.TabIndex = 6;
            this.RegisterLabel.Text = "Report";
            // 
            // imagePanel
            // 
            this.imagePanel.AutoScroll = true;
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagePanel.Location = new System.Drawing.Point(33, 150);
            this.imagePanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(1616, 804);
            this.imagePanel.TabIndex = 9;
            // 
            // patientHN
            // 
            this.patientHN.AutoSize = true;
            this.patientHN.Location = new System.Drawing.Point(268, 45);
            this.patientHN.Name = "patientHN";
            this.patientHN.Size = new System.Drawing.Size(35, 13);
            this.patientHN.TabIndex = 10;
            this.patientHN.Text = "label1";
            this.patientHN.Visible = false;
            // 
            // patientSurname
            // 
            this.patientSurname.AutoSize = true;
            this.patientSurname.Location = new System.Drawing.Point(338, 45);
            this.patientSurname.Name = "patientSurname";
            this.patientSurname.Size = new System.Drawing.Size(35, 13);
            this.patientSurname.TabIndex = 11;
            this.patientSurname.Text = "label1";
            this.patientSurname.Visible = false;
            // 
            // patientFirstName
            // 
            this.patientFirstName.AutoSize = true;
            this.patientFirstName.Location = new System.Drawing.Point(397, 45);
            this.patientFirstName.Name = "patientFirstName";
            this.patientFirstName.Size = new System.Drawing.Size(35, 13);
            this.patientFirstName.TabIndex = 12;
            this.patientFirstName.Text = "label1";
            this.patientFirstName.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(32, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 544);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.report);
            this.panel2.Controls.Add(this.img);
            this.panel2.Location = new System.Drawing.Point(33, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1616, 68);
            this.panel2.TabIndex = 14;
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.img.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(232, 68);
            this.img.TabIndex = 0;
            this.img.Text = "Images";
            this.img.UseVisualStyleBackColor = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.report.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.report.Location = new System.Drawing.Point(230, 0);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(232, 68);
            this.report.TabIndex = 1;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = false;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // REPORT_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.patientFirstName);
            this.Controls.Add(this.patientSurname);
            this.Controls.Add(this.patientHN);
            this.Controls.Add(this.RegisterLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "REPORT_2";
            this.Size = new System.Drawing.Size(1680, 960);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Panel imagePanel;
        public System.Windows.Forms.Label patientHN;
        public System.Windows.Forms.Label patientSurname;
        public System.Windows.Forms.Label patientFirstName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.Button img;
    }
}