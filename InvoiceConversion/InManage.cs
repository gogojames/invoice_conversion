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
        string inp_txt = "請輸入發票編號...";
        System.Drawing.Color inp_color = System.Drawing.SystemColors.ControlLight;
        System.Drawing.Color def_color = System.Drawing.SystemColors.WindowText;
        public InManage()
        {
            InitializeComponent();
            input_style(string.Empty);
        }

        void input_style(string txt)
        {
            if (string.IsNullOrEmpty(txt) || txt.Equals(inp_txt))
            {
                textBox1.ForeColor = inp_color;
                textBox1.Text = inp_txt;
                textBox1.Select();
            }
            else
            {
                textBox1.Text = txt;
                textBox1.ForeColor = def_color;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                initData();
            }
            else
            {
                if (inp_txt.Equals(textBox1.Text))
                {
                    textBox1.SelectAll();
                }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = (sender as System.Windows.Forms.TextBox).Text;
            if (s.Equals(inp_txt))
                return;
            input_style(s);
        }
    }
}
