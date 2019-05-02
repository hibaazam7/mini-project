namespace ProjectA
{
    partial class asad
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
            this.advr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.advcombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addnme = new System.Windows.Forms.Label();
            this.procombo = new System.Windows.Forms.ComboBox();
            this.adadd = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // advr
            // 
            this.advr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advr.FormattingEnabled = true;
            this.advr.Location = new System.Drawing.Point(230, 164);
            this.advr.Name = "advr";
            this.advr.Size = new System.Drawing.Size(235, 26);
            this.advr.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 160);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 46;
            this.label2.Text = "Advisor Role";
            // 
            // advcombo
            // 
            this.advcombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advcombo.FormattingEnabled = true;
            this.advcombo.Location = new System.Drawing.Point(230, 120);
            this.advcombo.Name = "advcombo";
            this.advcombo.Size = new System.Drawing.Size(235, 26);
            this.advcombo.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 116);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label1.Size = new System.Drawing.Size(81, 30);
            this.label1.TabIndex = 44;
            this.label1.Text = "Advisor";
            // 
            // addnme
            // 
            this.addnme.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addnme.AutoSize = true;
            this.addnme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnme.Location = new System.Drawing.Point(56, 72);
            this.addnme.Name = "addnme";
            this.addnme.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.addnme.Size = new System.Drawing.Size(58, 30);
            this.addnme.TabIndex = 42;
            this.addnme.Text = "Title";
            // 
            // procombo
            // 
            this.procombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procombo.FormattingEnabled = true;
            this.procombo.Location = new System.Drawing.Point(230, 76);
            this.procombo.Name = "procombo";
            this.procombo.Size = new System.Drawing.Size(235, 26);
            this.procombo.TabIndex = 48;
            // 
            // adadd
            // 
            this.adadd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.adadd.AutoSize = true;
            this.adadd.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adadd.Location = new System.Drawing.Point(160, 26);
            this.adadd.Name = "adadd";
            this.adadd.Size = new System.Drawing.Size(195, 24);
            this.adadd.TabIndex = 49;
            this.adadd.Text = "ASSIGN ADVISOR";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 50;
            this.button1.Text = "Assign";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(280, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 51;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // asad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adadd);
            this.Controls.Add(this.procombo);
            this.Controls.Add(this.advr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.advcombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addnme);
            this.Name = "asad";
            this.Text = "Assign Advisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox advr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox advcombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addnme;
        private System.Windows.Forms.ComboBox procombo;
        private System.Windows.Forms.Label adadd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}