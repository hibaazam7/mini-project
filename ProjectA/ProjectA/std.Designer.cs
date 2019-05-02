namespace ProjectA
{
    partial class std
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
            this.studlist = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.ind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "STUDENT";
            // 
            // studlist
            // 
            this.studlist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studlist.Location = new System.Drawing.Point(125, 92);
            this.studlist.Name = "studlist";
            this.studlist.Size = new System.Drawing.Size(117, 26);
            this.studlist.TabIndex = 2;
            this.studlist.Text = "STUDENTS";
            this.studlist.UseVisualStyleBackColor = true;
            this.studlist.Click += new System.EventHandler(this.studlist_Click);
            // 
            // create
            // 
            this.create.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.Location = new System.Drawing.Point(125, 143);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(117, 26);
            this.create.TabIndex = 3;
            this.create.Text = "CREATE";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // ind
            // 
            this.ind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ind.Location = new System.Drawing.Point(125, 193);
            this.ind.Name = "ind";
            this.ind.Size = new System.Drawing.Size(117, 26);
            this.ind.TabIndex = 4;
            this.ind.Text = "INDEX";
            this.ind.UseVisualStyleBackColor = true;
            this.ind.Click += new System.EventHandler(this.ind_Click);
            // 
            // std
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 294);
            this.Controls.Add(this.ind);
            this.Controls.Add(this.create);
            this.Controls.Add(this.studlist);
            this.Controls.Add(this.label1);
            this.Name = "std";
            this.Text = "STUDENT";
            this.Load += new System.EventHandler(this.std_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button studlist;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button ind;
    }
}