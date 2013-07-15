using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class AddComFm : Form
    {
        public Common.Basic.FormMode DataMode;
        public Data.InvoiceTitel SelectTitle;
        public AddComFm()
        {
            InitializeComponent();
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            this.listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);
            //this.invoiceTitelBindingSource1.DataSource = newone();
            button1.Click += new EventHandler(button1_Click);
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var t = listBox1.SelectedItem as Data.InvoiceTitel;
            if (t != null)
            {
                SelectTitle = t;
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private object newone()
        {
            List<Data.InvoiceTitel> list_it = new List<Data.InvoiceTitel>();
            var it = new Data.InvoiceTitel() { Company_name = "new" };
            it.BeginEdit();
            list_it.Add(it);
            return list_it;
        }

        void button1_Click(object sender, EventArgs e)
        {
            Data.InvoiceTitel it = this.invoiceTitelBindingSource1.Current as Data.InvoiceTitel;
            if (it == null) {
                MessageBox.Show("數據不完整");
                return; }
            string sql = string.Empty;
            if (DataMode == Common.Basic.FormMode.modifyMode)
            {
                sql=it.GetSqlQuery(this.DataMode, "Company_id");
            }
            
            int i=Common.MsSql.ExSql(sql,it.Parameter);
            if (i == 0)
            {
                MessageBox.Show("保存失敗");
            }
            else
            {
                MessageBox.Show("保存成功");
                this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.invoiceTitelBindingSource1.Clear();
            if (listBox1.SelectedItem == null)
            {
                this.DataMode = Common.Basic.FormMode.newMode;
                this.invoiceTitelBindingSource1.AddNew();
                this.invoiceTitelBindingSource1.DataSource = newone();
            }
            else
            {
                this.DataMode = Common.Basic.FormMode.modifyMode;
                Data.InvoiceTitel it = this.invoiceTitelBindingSource.Current as Data.InvoiceTitel;
                it.BeginEdit();
                this.invoiceTitelBindingSource1.Add(it);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.invoiceTitelBindingSource1.Clear();
            this.DataMode = Common.Basic.FormMode.newMode;
            this.invoiceTitelBindingSource1.DataSource = newone();
        }
    }
}
