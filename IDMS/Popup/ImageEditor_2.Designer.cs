namespace IDMS.Popup
{
    partial class ImageEditor_2
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addtxt = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Line = new System.Windows.Forms.Button();
            this.txtP = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel1.SuspendLayout();
            this.txtP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(0, 1);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(523, 505);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
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
            this.button2.Location = new System.Drawing.Point(15, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.addtxt);
            this.panel1.Controls.Add(this.Clear);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Line);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(522, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 505);
            this.panel1.TabIndex = 4;
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
            this.addtxt.Location = new System.Drawing.Point(32, 13);
            this.addtxt.Name = "addtxt";
            this.addtxt.Size = new System.Drawing.Size(35, 35);
            this.addtxt.TabIndex = 6;
            this.addtxt.UseVisualStyleBackColor = false;
            this.addtxt.Click += new System.EventHandler(this.addtxt_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.White;
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Clear.Location = new System.Drawing.Point(15, 462);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(68, 33);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 500);
            this.panel2.TabIndex = 7;
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
            this.Line.Location = new System.Drawing.Point(32, 56);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(35, 35);
            this.Line.TabIndex = 4;
            this.Line.UseVisualStyleBackColor = false;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // txtP
            // 
            this.txtP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtP.Controls.Add(this.label1);
            this.txtP.Controls.Add(this.txt);
            this.txtP.Location = new System.Drawing.Point(119, 24);
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
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press Enter";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 513);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.txtP.ResumeLayout(false);
            this.txtP.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
    }
}