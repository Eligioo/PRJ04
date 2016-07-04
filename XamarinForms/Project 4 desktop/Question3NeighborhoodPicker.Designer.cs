namespace Project_4_desktop
{
    partial class Question3NeighborhoodPicker
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
            this.label1 = new System.Windows.Forms.Label();
            this.neigborhoodComboBox = new System.Windows.Forms.ComboBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kies een buurt:";
            // 
            // neigborhoodComboBox
            // 
            this.neigborhoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.neigborhoodComboBox.FormattingEnabled = true;
            this.neigborhoodComboBox.Location = new System.Drawing.Point(95, 52);
            this.neigborhoodComboBox.Name = "neigborhoodComboBox";
            this.neigborhoodComboBox.Size = new System.Drawing.Size(121, 21);
            this.neigborhoodComboBox.TabIndex = 1;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(95, 131);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 2;
            this.viewButton.Text = "laad";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // Question3NeighborhoodPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 266);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.neigborhoodComboBox);
            this.Controls.Add(this.label1);
            this.Name = "Question3NeighborhoodPicker";
            this.Text = "Question3NeighborhoodPicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox neigborhoodComboBox;
        private System.Windows.Forms.Button viewButton;
    }
}