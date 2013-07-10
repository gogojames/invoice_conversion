using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InvoiceConversion
{
    public partial class InCoFm : Form
    {
        private List<Data.Invoice_detail> list_detail;

        public List<Data.Invoice_detail> List_detail
        {
            get { return list_detail; }
            set { list_detail = value; }
        }
        public Common.Basic.FormMode DataMode;
        public InCoFm()
        {
            InitializeComponent();
            DataMode = Common.Basic.FormMode.newMode;
            this.customerBindingSource.DataSource = Common.MsSql.getCustmer();
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            this.invoicedetailBindingSource.DataSource = List_detail;
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
                catch
                {
                    //this.invoicedetailBindingSource.DataSource=typeof( Data.Invoice_detail);
                    List_detail.Clear();
                }
            }
            else
            {
                List_detail = Common.MsSql.getInvoiceDetail(currim.Client_name, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            this.invoicedetailBindingSource.DataSource = List_detail;
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
            Double savl = 0.00;
            string savl_str = string.Format("0.{0}", textBox2.Text);
            Double.TryParse(savl_str, out savl);

            for(int i =0;i<dataGridView1.RowCount;i++)
            {
                var dv = dataGridView1.Rows[i];
                double p;
                double.TryParse(dv.Cells[3].Value.ToString(), out p);

                double.TryParse(string.Format("{0:F2}", (p * savl)), out p);
                List_detail[i].Rpice = p;
                dv.Cells[3].Selected = true;
            }

            MessageBox.Show("修改成功");
           // invoicedetailBindingSource.DataSource = List_detail;

        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            Data.Invoice_master imaster = this.invoicemasterBindingSource.Current as Data.Invoice_master;
            Data.InvoiceTitel title = this.title_combox.SelectedItem as Data.InvoiceTitel;
            imaster.Remake = reme.Text;
            imaster.Invoice_title_id = title.Company_id;
            
            string sql=imaster.GetSqlQuery(DataMode,String.Empty);
            //Common.MsSql.ExSql(sql, imaster.Parameter);
            string[] sqls = new string[List_detail.Count+1];
            object[] objs = new object[List_detail.Count+1];
            int i=0;
            sqls[i] = sql;
            objs[i] = imaster.Parameter;
            foreach (Data.Invoice_detail d in this.List_detail)
            {
                i++;
                d.Invoice_nmber = imaster.Invoice_nmber;
                sqls[i]=d.GetSqlQuery(DataMode, string.Empty);
                objs[i] = d.Parameter;
                
            }
            if (Common.MsSql.ExcMulSql(sqls, objs))
            {
                MessageBox.Show("生成了新的發票號：" + imaster.Invoice_nmber);
            }
            else
            {
                MessageBox.Show("生成了新的發票失敗");
            }
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

        private void printBut_Click(object sender, EventArgs e)
        {
            //打印
        }
    }
}
