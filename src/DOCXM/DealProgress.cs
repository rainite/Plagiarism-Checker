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
    public partial class DealProgress : Form
    {
        public DealProgress()
        {
            InitializeComponent();
        }

        public void setMax(int max)
        {
            progressBar1.Maximum = max;
        }
        public void setProgress(int p)
        { 
            progressBar1.Value = p;
        }
        public void setProgress(int p,int t)
        {
            progressBar1.Maximum = t;
            progressBar1.Value = p;
        }
        private void DealProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
             
            //e.Cancel = true;
        }

        private void DealProgress_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
