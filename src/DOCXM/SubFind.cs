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
    public partial class SubFind : Form
    {
        public SubFind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Boolean Circule
        {
            get
            {
                return cb_find.Checked;
            }
        }
        public int Level
        {
            get
            {
                return Convert.ToInt32( num_level.Text);
            }
        }

        private void cb_find_CheckedChanged(object sender, EventArgs e)
        {
            num_level.Enabled = cb_find.Checked;
        }

        private void SubFind_Load(object sender, EventArgs e)
        {
            cb_find.Checked = false;
        }
    }
}
