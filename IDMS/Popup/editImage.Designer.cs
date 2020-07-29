namespace IDMS.Popup
{
    partial class editImage
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(12, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(600, 600);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(12, 618);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(250, 20);
            this.txt.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(306, 617);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(59, 20);
            this.ok.TabIndex = 2;
            this.ok.Text = "save";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // editImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 638);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.pic);
            this.Name = "editImage";
            this.Text = "editImage";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button ok;
    }
}