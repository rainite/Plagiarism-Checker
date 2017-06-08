namespace DOCXM
{
    partial class DOCXM
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_content = new System.Windows.Forms.TextBox();
            this.lv_words = new System.Windows.Forms.ListView();
            this.lbPyOut = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnReadKeyFile = new System.Windows.Forms.Button();
            this.btnDelKey = new System.Windows.Forms.Button();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_keypair = new System.Windows.Forms.ListView();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lv_doc_same = new System.Windows.Forms.ListView();
            this.btnExcutePy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_2Txt = new System.Windows.Forms.Button();
            this.lb_keypair = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_content
            // 
            this.tb_content.Location = new System.Drawing.Point(453, 237);
            this.tb_content.Multiline = true;
            this.tb_content.Name = "tb_content";
            this.tb_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_content.Size = new System.Drawing.Size(325, 235);
            this.tb_content.TabIndex = 1;
            // 
            // lv_words
            // 
            this.lv_words.FullRowSelect = true;
            this.lv_words.GridLines = true;
            this.lv_words.HideSelection = false;
            this.lv_words.Location = new System.Drawing.Point(5, 36);
            this.lv_words.MultiSelect = false;
            this.lv_words.Name = "lv_words";
            this.lv_words.Size = new System.Drawing.Size(173, 382);
            this.lv_words.TabIndex = 2;
            this.lv_words.UseCompatibleStateImageBehavior = false;
            this.lv_words.View = System.Windows.Forms.View.Details;
            this.lv_words.SelectedIndexChanged += new System.EventHandler(this.lv_words_SelectedIndexChanged);
            this.lv_words.DoubleClick += new System.EventHandler(this.lv_words_DoubleClick);
            // 
            // lbPyOut
            // 
            this.lbPyOut.FormattingEnabled = true;
            this.lbPyOut.ItemHeight = 12;
            this.lbPyOut.Location = new System.Drawing.Point(455, 12);
            this.lbPyOut.Name = "lbPyOut";
            this.lbPyOut.Size = new System.Drawing.Size(323, 100);
            this.lbPyOut.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveKey);
            this.panel1.Controls.Add(this.btnReadKeyFile);
            this.panel1.Controls.Add(this.btnDelKey);
            this.panel1.Controls.Add(this.btnAddKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lv_keypair);
            this.panel1.Controls.Add(this.btnOpenFolder);
            this.panel1.Controls.Add(this.lv_doc_same);
            this.panel1.Controls.Add(this.lv_words);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 463);
            this.panel1.TabIndex = 4;
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.Location = new System.Drawing.Point(339, 10);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(91, 23);
            this.btnSaveKey.TabIndex = 10;
            this.btnSaveKey.Text = "保存到文件";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // btnReadKeyFile
            // 
            this.btnReadKeyFile.Location = new System.Drawing.Point(243, 10);
            this.btnReadKeyFile.Name = "btnReadKeyFile";
            this.btnReadKeyFile.Size = new System.Drawing.Size(91, 23);
            this.btnReadKeyFile.TabIndex = 10;
            this.btnReadKeyFile.Text = "从文件读取";
            this.btnReadKeyFile.UseVisualStyleBackColor = true;
            this.btnReadKeyFile.Click += new System.EventHandler(this.btnReadKeyFile_Click);
            // 
            // btnDelKey
            // 
            this.btnDelKey.Location = new System.Drawing.Point(243, 33);
            this.btnDelKey.Name = "btnDelKey";
            this.btnDelKey.Size = new System.Drawing.Size(90, 23);
            this.btnDelKey.TabIndex = 9;
            this.btnDelKey.Text = "删除";
            this.btnDelKey.UseVisualStyleBackColor = true;
            this.btnDelKey.Click += new System.EventHandler(this.btnDelKey_Click);
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(340, 33);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(90, 23);
            this.btnAddKey.TabIndex = 9;
            this.btnAddKey.Text = "添加";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Word文档：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "对比结果：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "关键词组：";
            // 
            // lv_keypair
            // 
            this.lv_keypair.FullRowSelect = true;
            this.lv_keypair.GridLines = true;
            this.lv_keypair.HideSelection = false;
            this.lv_keypair.Location = new System.Drawing.Point(187, 58);
            this.lv_keypair.MultiSelect = false;
            this.lv_keypair.Name = "lv_keypair";
            this.lv_keypair.Size = new System.Drawing.Size(243, 117);
            this.lv_keypair.TabIndex = 7;
            this.lv_keypair.UseCompatibleStateImageBehavior = false;
            this.lv_keypair.View = System.Windows.Forms.View.Details;
            this.lv_keypair.SelectedIndexChanged += new System.EventHandler(this.lv_keypair_SelectedIndexChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(5, 424);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(173, 36);
            this.btnOpenFolder.TabIndex = 6;
            this.btnOpenFolder.Text = "打开文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // lv_doc_same
            // 
            this.lv_doc_same.FullRowSelect = true;
            this.lv_doc_same.GridLines = true;
            this.lv_doc_same.HideSelection = false;
            this.lv_doc_same.Location = new System.Drawing.Point(187, 193);
            this.lv_doc_same.MultiSelect = false;
            this.lv_doc_same.Name = "lv_doc_same";
            this.lv_doc_same.Size = new System.Drawing.Size(243, 256);
            this.lv_doc_same.TabIndex = 5;
            this.lv_doc_same.UseCompatibleStateImageBehavior = false;
            this.lv_doc_same.View = System.Windows.Forms.View.Details;
            // 
            // btnExcutePy
            // 
            this.btnExcutePy.Location = new System.Drawing.Point(455, 160);
            this.btnExcutePy.Name = "btnExcutePy";
            this.btnExcutePy.Size = new System.Drawing.Size(323, 36);
            this.btnExcutePy.TabIndex = 6;
            this.btnExcutePy.Text = "计算关键信息相似度";
            this.btnExcutePy.UseVisualStyleBackColor = true;
            this.btnExcutePy.Click += new System.EventHandler(this.btnExcutePy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "关键词组内包含的内容：";
            // 
            // btn_2Txt
            // 
            this.btn_2Txt.Location = new System.Drawing.Point(455, 118);
            this.btn_2Txt.Name = "btn_2Txt";
            this.btn_2Txt.Size = new System.Drawing.Size(323, 36);
            this.btn_2Txt.TabIndex = 6;
            this.btn_2Txt.Text = "提取关键信息";
            this.btn_2Txt.UseVisualStyleBackColor = true;
            this.btn_2Txt.Click += new System.EventHandler(this.btn_2Txt_Click);
            // 
            // lb_keypair
            // 
            this.lb_keypair.AutoSize = true;
            this.lb_keypair.Location = new System.Drawing.Point(463, 205);
            this.lb_keypair.Name = "lb_keypair";
            this.lb_keypair.Size = new System.Drawing.Size(0, 12);
            this.lb_keypair.TabIndex = 9;
            // 
            // DOCXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 487);
            this.Controls.Add(this.lb_keypair);
            this.Controls.Add(this.btn_2Txt);
            this.Controls.Add(this.btnExcutePy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbPyOut);
            this.Controls.Add(this.tb_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DOCXM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOCXM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_content;
        private System.Windows.Forms.ListView lv_words;
        private System.Windows.Forms.ListBox lbPyOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcutePy;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ListView lv_doc_same;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_keypair;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_2Txt;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.Button btnDelKey;
        private System.Windows.Forms.Button btnReadKeyFile;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Label lb_keypair;
    }
}

