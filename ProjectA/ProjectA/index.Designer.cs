namespace ProjectA
{
    partial class index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(index));
            this.label1 = new System.Windows.Forms.Label();
            this.std = new System.Windows.Forms.Button();
            this.eval = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.proj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "FINAL YEAR PROJECT ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // std
            // 
            this.std.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.std.Cursor = System.Windows.Forms.Cursors.Hand;
            this.std.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.std.Location = new System.Drawing.Point(21, 96);
            this.std.Name = "std";
            this.std.Size = new System.Drawing.Size(117, 26);
            this.std.TabIndex = 1;
            this.std.Text = "STUDENTS";
            this.std.UseVisualStyleBackColor = true;
            this.std.Click += new System.EventHandler(this.std_Click);
            // 
            // eval
            // 
            this.eval.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eval.Location = new System.Drawing.Point(392, 96);
            this.eval.Name = "eval";
            this.eval.Size = new System.Drawing.Size(147, 26);
            this.eval.TabIndex = 2;
            this.eval.Text = "EVALUATIONS";
            this.eval.UseVisualStyleBackColor = true;
            this.eval.Click += new System.EventHandler(this.button2_Click);
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(156, 96);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(115, 26);
            this.add.TabIndex = 3;
            this.add.Text = "ADVISORS";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // proj
            // 
            this.proj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.proj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.proj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proj.Location = new System.Drawing.Point(554, 96);
            this.proj.Name = "proj";
            this.proj.Size = new System.Drawing.Size(104, 26);
            this.proj.TabIndex = 4;
            this.proj.Text = "PROJECTS";
            this.proj.UseVisualStyleBackColor = true;
            this.proj.Click += new System.EventHandler(this.proj_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(608, 72);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(282, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "GROUPS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.proj);
            this.Controls.Add(this.add);
            this.Controls.Add(this.eval);
            this.Controls.Add(this.std);
            this.Controls.Add(this.label1);
            this.Name = "index";
            this.Text = "index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button std;
        private System.Windows.Forms.Button eval;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button proj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}