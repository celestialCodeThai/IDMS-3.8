namespace IDMS.Popup
{
    partial class ImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.defaultCropButton = new System.Windows.Forms.Button();
            this.crop_label = new System.Windows.Forms.Label();
            this.crop_button2 = new System.Windows.Forms.Button();
            this.crop_button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Line = new System.Windows.Forms.Button();
            this.addtxt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Clear = new System.Windows.Forms.Button();
            this.txtP = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.paintPanel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.txtP.SuspendLayout();
            this.paintPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(3, 3);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(207, 31);
            this.txt.TabIndex = 1;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_MouseDown);
            this.txt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txt_MouseMove);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.defaultCropButton);
            this.panel1.Controls.Add(this.crop_label);
            this.panel1.Controls.Add(this.crop_button2);
            this.panel1.Controls.Add(this.crop_button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtP);
            this.panel1.Controls.Add(this.Mode);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1434, 130);
            this.panel1.TabIndex = 4;
            // 
            // defaultCropButton
            // 
            this.defaultCropButton.BackColor = System.Drawing.Color.White;
            this.defaultCropButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.defaultCropButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.defaultCropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultCropButton.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultCropButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.defaultCropButton.Location = new System.Drawing.Point(760, 48);
            this.defaultCropButton.Name = "defaultCropButton";
            this.defaultCropButton.Size = new System.Drawing.Size(70, 35);
            this.defaultCropButton.TabIndex = 15;
            this.defaultCropButton.Text = "default";
            this.defaultCropButton.UseVisualStyleBackColor = false;
            this.defaultCropButton.Visible = false;
            this.defaultCropButton.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // crop_label
            // 
            this.crop_label.AutoSize = true;
            this.crop_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crop_label.Location = new System.Drawing.Point(627, 91);
            this.crop_label.Name = "crop_label";
            this.crop_label.Size = new System.Drawing.Size(243, 36);
            this.crop_label.TabIndex = 14;
            this.crop_label.Text = "   กดปุ่มเพื่อขยายหรือย่อกรอบรูป\r\n(กรอบรูปไม่สามารถออกนอกรูปภาพ)";
            this.crop_label.Visible = false;
            // 
            // crop_button2
            // 
            this.crop_button2.BackColor = System.Drawing.Color.White;
            this.crop_button2.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.crop_button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.crop_button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crop_button2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crop_button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.crop_button2.Location = new System.Drawing.Point(710, 48);
            this.crop_button2.Name = "crop_button2";
            this.crop_button2.Size = new System.Drawing.Size(35, 35);
            this.crop_button2.TabIndex = 6;
            this.crop_button2.Text = "-";
            this.crop_button2.UseVisualStyleBackColor = false;
            this.crop_button2.Visible = false;
            this.crop_button2.Click += new System.EventHandler(this.crop_button2_Click);
            // 
            // crop_button1
            // 
            this.crop_button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.crop_button1.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.crop_button1.FlatAppearance.BorderSize = 2;
            this.crop_button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.crop_button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crop_button1.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crop_button1.ForeColor = System.Drawing.Color.White;
            this.crop_button1.Location = new System.Drawing.Point(660, 48);
            this.crop_button1.Name = "crop_button1";
            this.crop_button1.Size = new System.Drawing.Size(35, 35);
            this.crop_button1.TabIndex = 6;
            this.crop_button1.Text = "+";
            this.crop_button1.UseVisualStyleBackColor = false;
            this.crop_button1.Visible = false;
            this.crop_button1.Click += new System.EventHandler(this.crop_button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Line);
            this.panel2.Controls.Add(this.addtxt);
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 60);
            this.panel2.TabIndex = 13;
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.MidnightBlue;
            this.Line.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Line.BackgroundImage")));
            this.Line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Line.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Line.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Line.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Line.ForeColor = System.Drawing.Color.White;
            this.Line.Location = new System.Drawing.Point(20, 10);
            this.Line.Margin = new System.Windows.Forms.Padding(0);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(37, 37);
            this.Line.TabIndex = 4;
            this.Line.UseVisualStyleBackColor = false;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // addtxt
            // 
            this.addtxt.BackColor = System.Drawing.Color.MidnightBlue;
            this.addtxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addtxt.BackgroundImage")));
            this.addtxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addtxt.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addtxt.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.addtxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addtxt.ForeColor = System.Drawing.Color.White;
            this.addtxt.Location = new System.Drawing.Point(90, 10);
            this.addtxt.Margin = new System.Windows.Forms.Padding(0);
            this.addtxt.Name = "addtxt";
            this.addtxt.Size = new System.Drawing.Size(37, 37);
            this.addtxt.TabIndex = 6;
            this.addtxt.UseVisualStyleBackColor = false;
            this.addtxt.Click += new System.EventHandler(this.addtxt_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.GhostWhite;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.Clear);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Location = new System.Drawing.Point(20, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 40);
            this.panel3.TabIndex = 11;
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.White;
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Clear.Location = new System.Drawing.Point(77, 3);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(68, 33);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // txtP
            // 
            this.txtP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtP.Controls.Add(this.label1);
            this.txtP.Controls.Add(this.txt);
            this.txtP.Location = new System.Drawing.Point(176, 72);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(292, 37);
            this.txtP.TabIndex = 7;
            this.txtP.Visible = false;
            this.txtP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtP_MouseDown);
            this.txtP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtP_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(216, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter to save";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Mode
            // 
            this.Mode.AutoSize = true;
            this.Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode.Location = new System.Drawing.Point(200, 10);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(103, 31);
            this.Mode.TabIndex = 9;
            this.Mode.Text = "default";
            // 
            // paintPanel
            // 
            this.paintPanel.AutoScroll = true;
            this.paintPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.paintPanel.Controls.Add(this.pic);
            this.paintPanel.Location = new System.Drawing.Point(1, 132);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(1480, 825);
            this.paintPanel.TabIndex = 5;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.LightSlateGray;
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic.Location = new System.Drawing.Point(10, 10);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(639, 295);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.paintPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageEditor";
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.txtP.ResumeLayout(false);
            this.txtP.PerformLayout();
            this.paintPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Panel txtP;
        private System.Windows.Forms.Button addtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.Button crop_button2;
        private System.Windows.Forms.Button crop_button1;
        private System.Windows.Forms.Label crop_label;
        private System.Windows.Forms.Button defaultCropButton;
    }
}