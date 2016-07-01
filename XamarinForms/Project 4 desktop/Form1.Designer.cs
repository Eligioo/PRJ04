namespace Project_4_desktop
{
    partial class Form1
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
            this.Vraag1 = new System.Windows.Forms.Button();
            this.Vraag2 = new System.Windows.Forms.Button();
            this.Vraag3 = new System.Windows.Forms.Button();
            this.Vraag4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Vraag1
            // 
            this.Vraag1.Location = new System.Drawing.Point(60, 86);
            this.Vraag1.Name = "Vraag1";
            this.Vraag1.Size = new System.Drawing.Size(75, 23);
            this.Vraag1.TabIndex = 0;
            this.Vraag1.Text = "Vraag 1";
            this.Vraag1.UseVisualStyleBackColor = true;
            this.Vraag1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Vraag2
            // 
            this.Vraag2.Location = new System.Drawing.Point(60, 115);
            this.Vraag2.Name = "Vraag2";
            this.Vraag2.Size = new System.Drawing.Size(75, 23);
            this.Vraag2.TabIndex = 1;
            this.Vraag2.Text = "Vraag 2";
            this.Vraag2.UseVisualStyleBackColor = true;
            this.Vraag2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Vraag3
            // 
            this.Vraag3.Location = new System.Drawing.Point(60, 144);
            this.Vraag3.Name = "Vraag3";
            this.Vraag3.Size = new System.Drawing.Size(75, 23);
            this.Vraag3.TabIndex = 2;
            this.Vraag3.Text = "Vraag 3";
            this.Vraag3.UseVisualStyleBackColor = true;
            this.Vraag3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Vraag4
            // 
            this.Vraag4.Location = new System.Drawing.Point(60, 174);
            this.Vraag4.Name = "Vraag4";
            this.Vraag4.Size = new System.Drawing.Size(75, 23);
            this.Vraag4.TabIndex = 3;
            this.Vraag4.Text = "Vraag 4";
            this.Vraag4.UseVisualStyleBackColor = true;
            this.Vraag4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 738);
            this.Controls.Add(this.Vraag4);
            this.Controls.Add(this.Vraag3);
            this.Controls.Add(this.Vraag2);
            this.Controls.Add(this.Vraag1);
            this.Name = "Form1";
            this.Text = "Project 4";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Vraag1;
        private System.Windows.Forms.Button Vraag2;
        private System.Windows.Forms.Button Vraag3;
        private System.Windows.Forms.Button Vraag4;
    }
}

