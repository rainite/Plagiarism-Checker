namespace DOCXM
{
    partial class KEYPair
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
            this.lb_start = new System.Windows.Forms.TextBox();
            this.lb_end = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lb_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_start
            // 
            this.lb_start.Location = new System.Drawing.Point(12, 60);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(178, 21);
            this.lb_start.TabIndex = 1;
            // 
            // lb_end
            // 
            this.lb_end.Location = new System.Drawing.Point(217, 60);
            this.lb_end.Name = "lb_end";
            this.lb_end.Size = new System.Drawing.Size(170, 21);
            this.lb_end.TabIndex = 2;
            this.lb_end.TextChanged += new System.EventHandler(this.lb_end_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始关键词";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束关键词";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 93);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(375, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lb_name
            // 
            this.lb_name.Location = new System.Drawing.Point(13, 22);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(177, 21);
            this.lb_name.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "开始关键词组名称";
            // 
            // KEYPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 128);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.lb_end);
            this.Controls.Add(this.lb_start);
            this.MaximizeBox = false;
            this.Name = "KEYPair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KEYPair";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lb_start;
        private System.Windows.Forms.TextBox lb_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox lb_name;
        private System.Windows.Forms.Label label3;
    }
}