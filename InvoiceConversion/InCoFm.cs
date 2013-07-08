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
            this.invoicedetailBindingSource.DataSource = Common.MsSql.getInvoiceDetail(custmer_text.Text, "0351446");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceConversion.Data.Invoice i = new Data.Invoice();
        }
        
        private void manageBut_Click(object sender, EventArgs e)
        {
            //管理发票 标题
        }

        private void msleBut_Click(object sender, EventArgs e)
        {
            //修改折扣
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            //保存
        }
    }
}
