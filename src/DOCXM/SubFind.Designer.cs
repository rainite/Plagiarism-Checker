namespace DOCXM
{
    partial class SubFind
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
            this.cb_find = new System.Windows.Forms.CheckBox();
            this.num_level = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_find
            // 
            this.cb_find.AutoSize = true;
            this.cb_find.Location = new System.Drawing.Point(68, 36);
            this.cb_find.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_find.Name = "cb_find";
            this.cb_find.Size = new System.Drawing.Size(116, 19);
            this.cb_find.TabIndex = 0;
            this.cb_find.Text = "查找子文件夹";
            this.cb_find.UseVisualStyleBackColor = true;
            this.cb_find.CheckedChanged += new System.EventHandler(this.cb_find_CheckedChanged);
            // 
            // num_level
            // 
            this.num_level.Location = new System.Drawing.Point(68, 99);
            this.num_level.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.num_level.Name = "num_level";
            this.num_level.Size = new System.Drawing.Size(160, 25);
            this.num_level.TabIndex = 1;
            this.num_level.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 148);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "查找层级";
            // 
            // SubFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num_level);
            this.Controls.Add(this.cb_find);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查找子文件夹";
            this.Load += new System.EventHandler(this.SubFind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_find;
        private System.Windows.Forms.DomainUpDown num_level;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}