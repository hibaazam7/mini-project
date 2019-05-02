namespace ProjectA
{
    partial class adv
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
            this.ind = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.addlist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ind
            // 
            this.ind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ind.Location = new System.Drawing.Point(126, 195);
            this.ind.Name = "ind";
            this.ind.Size = new System.Drawing.Size(117, 26);
            this.ind.TabIndex = 8;
            this.ind.Text = "INDEX";
            this.ind.UseVisualStyleBackColor = true;
            this.ind.Click += new System.EventHandler(this.ind_Click);
            // 
            // create
            // 
            this.create.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.Location = new System.Drawing.Point(126, 145);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(117, 26);
            this.create.TabIndex = 7;
            this.create.Text = "CREATE";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // addlist
            // 
            this.addlist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addlist.Location = new System.Drawing.Point(126, 94);
            this.addlist.Name = "addlist";
            this.addlist.Size = new System.Drawing.Size(117, 26);
            this.addlist.TabIndex = 6;
            this.addlist.Text = "ADVISORS";
            this.addlist.UseVisualStyleBackColor = true;
            this.addlist.Click += new System.EventHandler(this.addlist_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "ADVISOR";
            // 
            // adv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 318);
            this.Controls.Add(this.ind);
            this.Controls.Add(this.create);
            this.Controls.Add(this.addlist);
            this.Controls.Add(this.label1);
            this.Name = "adv";
            this.Text = "adv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ind;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button addlist;
        private System.Windows.Forms.Label label1;
    }
}