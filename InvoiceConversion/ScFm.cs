using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class ScFm : Form
    {
        string inp_txt = "請輸入客戶名稱...";
        System.Drawing.Color inp_color= System.Drawing.SystemColors.ControlLight;
        System.Drawing.Color def_color = System.Drawing.SystemColors.WindowText;
        public ScFm()
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
                this.customerBindingSource.DataSource = Common.MsSql.getCustmer(textBox1.Text);
            }
            else
            {
                if (inp_txt.Equals(textBox1.Text))
                {
                    textBox1.SelectAll();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = (sender as System.Windows.Forms.TextBox).Text;
            if (s.Equals(inp_txt))
                return;
            input_style(s);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Use_Data = this.customerBindingSource.Current as Data.Customer;
        }
        public Data.Customer Use_Data { get;private set; }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
