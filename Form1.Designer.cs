namespace GOL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.ForeColor = System.Drawing.Color.Cornsilk;
            this.Panel1.Location = new System.Drawing.Point(46, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(801, 801);
            this.Panel1.TabIndex = 0;
            this.Panel1.Click += new System.EventHandler(this.Panel1_Click);
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(46, 849);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 20);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "State";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(753, 845);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(94, 29);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Start";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Enabled = false;
            this.Button2.Location = new System.Drawing.Point(653, 845);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(94, 29);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "Pause";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(553, 845);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(94, 29);
            this.Button3.TabIndex = 6;
            this.Button3.Text = "Reset";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(950, 900);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel Panel1;
        private Label Label1;
        private Button Button1;
        private Button Button2;
        private Button Button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}