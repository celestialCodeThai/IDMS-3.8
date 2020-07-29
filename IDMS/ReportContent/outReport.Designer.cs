namespace IDMS.ReportContent
{
    partial class outReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(outReport));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.pagetxt = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Location = new System.Drawing.Point(0, 55);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(848, 700);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.menuPanel.Controls.Add(this.pagetxt);
            this.menuPanel.Controls.Add(this.savebtn);
            this.menuPanel.Controls.Add(this.ExitButton);
            this.menuPanel.Controls.Add(this.button3);
            this.menuPanel.Controls.Add(this.Next);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(849, 49);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            this.menuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseDown);
            // 
            // pagetxt
            // 
            this.pagetxt.AutoSize = true;
            this.pagetxt.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagetxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pagetxt.Location = new System.Drawing.Point(731, 10);
            this.pagetxt.Name = "pagetxt";
            this.pagetxt.Size = new System.Drawing.Size(76, 30);
            this.pagetxt.TabIndex = 19;
            this.pagetxt.Text = "Page 1";
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.White;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.savebtn.Image = global::IDMS.Properties.Resources.save_dark;
            this.savebtn.Location = new System.Drawing.Point(5, 4);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(120, 40);
            this.savebtn.TabIndex = 18;
            this.savebtn.Text = "Save";
            this.savebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.savebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(606, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(39, 33);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(701, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 43);
            this.button3.TabIndex = 2;
            this.button3.Text = "<";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(60)))), ((int)(((byte)(125)))));
            this.Next.FlatAppearance.BorderSize = 0;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next.ForeColor = System.Drawing.Color.White;
            this.Next.Location = new System.Drawing.Point(813, 3);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(24, 45);
            this.Next.TabIndex = 1;
            this.Next.Text = ">";
            this.Next.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // outReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(849, 749);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "outReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label pagetxt;
    }
}