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
            this.invoicedetailBindingSource.DataSource = Common.MsSql.getInvoiceDetail(custmer_text.Text);
            this.Cursor = Cursors.Default;
        }
    }
}
