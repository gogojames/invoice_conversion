using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class InCoFm : Form
    {
        public InCoFm()
        {
            InitializeComponent();
            this.customerBindingSource.DataSource = Common.MsSql.getCustmer();
            this.invoicemasterBindingSource.CurrentChanged += new EventHandler(invoicemasterBindingSource_CurrentChanged);
        }

        void invoicemasterBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Data.Invoice_master currim = invoicemasterBindingSource.Current as Data.Invoice_master;
            if (currim == null)
            {
                try
                {
                    currim = invoicemasterBindingSource[0] as Data.Invoice_master;
                }
                catch {
                    this.invoicedetailBindingSource.DataSource=typeof( Data.Invoice_detail);
                    return; }
            }
            this.invoicedetailBindingSource.DataSource = Common.MsSql.getInvoiceDetail(currim.Client_name, dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceConversion.Data.Invoice_master i = new Data.Invoice_master();
        }
        
        private void manageBut_Click(object sender, EventArgs e)
        {
            //管理发票 标题
            AddComFm acf = new AddComFm();
            acf.ShowDialog();
        }

        private void msleBut_Click(object sender, EventArgs e)
        {
            //修改折扣
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            //保存
        }

        private void custmer_text_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.invoicemasterBindingSource.DataSource = Common.MsSql.getInvoice(custmer_text.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            this.Cursor = Cursors.Default;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.invoicemasterBindingSource.DataSource = Common.MsSql.getInvoice(custmer_text.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            this.Cursor = Cursors.Default;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.invoicemasterBindingSource.DataSource = Common.MsSql.getInvoice(custmer_text.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            this.Cursor = Cursors.Default;
        }
    }
}
