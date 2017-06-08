using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOCXM
{
    public partial class KEYPair : Form
    {
        public KEYPair()
        {
            InitializeComponent();
        }
        public Boolean HaveValidValue = false;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            HaveValidValue = false;
            if (lb_name.Text == "")
            {
                MessageBox.Show("关键词 名称 不能为空！");
                return;
            }
            if(lb_start.Text=="")
            {
                MessageBox.Show("开始 关键词不能为空！");
                return;
            }
            if (lb_end.Text == "")
            {
                MessageBox.Show("结束 关键词不能为空！");
                return;
            }
            HaveValidValue = true;
            this.Close();
        }
        public String Start
        {
            get{
                return lb_start.Text;
            }
            
        }
        public String End
        {
            get
            {
                return lb_end.Text;
            }
        }
        public String PairName
        {
            get
            {
                return lb_name.Text;
            }
        }

        private void lb_end_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
