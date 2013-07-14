using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class InManage : Form
    {
        public Data.Invoice_master Data;
        public InManage()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                initData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initData();
        }

        void initData()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請輸入發票編號!");
                return;
            }

            this.invoicemasterBindingSource.DataSource = Common.MsSql.InvoiceMasterBy("%"+this.textBox1.Text+"%", null);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            getCurrentItem();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                getCurrentItem();
            }
        }


        void getCurrentItem()
        {
            var master = this.invoicemasterBindingSource.Current as Data.Invoice_master;
            if (master == null)
            {
                return;
            }
            this.Data = master;
            this.DialogResult = DialogResult.OK;
        }
    }
}
