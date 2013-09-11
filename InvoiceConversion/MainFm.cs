using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class MainFm : Form
    {
        public MainFm()
        {
            InitializeComponent();
            this.Text = string.Format("{0}-{1}", this.Text, Access.Login.Table.Rows[0]["userName"]);
            this.IsMdiContainer = true;
        }
        private bool closeMdiChildren()
        {
            foreach (Form mf in this.MdiChildren)
                mf.Close();
            if (this.MdiChildren.Length == 0)
                return true;
            else
                return false;
        }
        private void colseMe_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void invoiceMe_Click(object sender, EventArgs e)
        {
            if (closeMdiChildren())
            {
                InCoFm icf = new InCoFm();
                icf.MdiParent = this;
                icf.Show();
            }
        }

        private void printMe_Click(object sender, EventArgs e)
        {
           // if (closeMdiChildren())
           // {
                PrInFm icf = new PrInFm();
                icf.MdiParent = this;
                icf.Show();
           // }
        }

        private void manageInMe_Click(object sender, EventArgs e)
        {
            //管理发票
            InManage im = new InManage();
            var dr = im.ShowDialog();
            if (DialogResult.OK == dr)
            {
                if (closeMdiChildren())
                {
                    InCoFm icf = new InCoFm(im.Data);
                    icf.MdiParent = this;
                    icf.Show();
                }
            }
        }

        private void a1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void a2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
