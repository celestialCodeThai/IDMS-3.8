namespace IDMS.Page
{
    partial class cameraPort
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setComport = new System.Windows.Forms.Button();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.setVsource = new System.Windows.Forms.Button();
            this.videoSourceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setComport);
            this.groupBox1.Controls.Add(this.cmbPortName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(17, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trigger Configuration";
            // 
            // setComport
            // 
            this.setComport.Location = new System.Drawing.Point(319, 19);
            this.setComport.Name = "setComport";
            this.setComport.Size = new System.Drawing.Size(43, 23);
            this.setComport.TabIndex = 3;
            this.setComport.Text = "Set";
            this.setComport.UseVisualStyleBackColor = true;
            this.setComport.Click += new System.EventHandler(this.setComport_Click);
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(151, 19);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(162, 26);
            this.cmbPortName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select COM Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.setVsource);
            this.groupBox2.Controls.Add(this.videoSourceList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(17, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Video Source";
            // 
            // setVsource
            // 
            this.setVsource.Location = new System.Drawing.Point(319, 22);
            this.setVsource.Name = "setVsource";
            this.setVsource.Size = new System.Drawing.Size(43, 23);
            this.setVsource.TabIndex = 2;
            this.setVsource.Text = "Set";
            this.setVsource.UseVisualStyleBackColor = true;
            this.setVsource.Click += new System.EventHandler(this.setVsource_Click);
            // 
            // videoSourceList
            // 
            this.videoSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoSourceList.FormattingEnabled = true;
            this.videoSourceList.Location = new System.Drawing.Point(151, 22);
            this.videoSourceList.Name = "videoSourceList";
            this.videoSourceList.Size = new System.Drawing.Size(162, 26);
            this.videoSourceList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Video Source:";
            // 
            // cameraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "cameraSettings";
            this.Size = new System.Drawing.Size(474, 301);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setComport;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button setVsource;
        private System.Windows.Forms.ComboBox videoSourceList;
        private System.Windows.Forms.Label label1;

    }
}

