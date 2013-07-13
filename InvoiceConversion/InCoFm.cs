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
            this.printBut.Enabled = false;
            this.SaveBut.Enabled = false;
            DataMode = Common.Basic.FormMode.newMode;
            dataGridView1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.invoicedetailBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicedetailBindingSource_DataError);
            this.invoicemasterBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicemasterBindingSource_DataError);
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            this.customerBindingSource.DataSource = Common.MsSql.getCustmer();
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            this.invoicedetailBindingSource.DataSource = List_detail;
            this.invoicemasterBindingSource.CurrentChanged += new EventHandler(invoicemasterBindingSource_CurrentChanged);

        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // MessageBox.Show(e.Exception.Message);
            
            var d = sender as DataGridView;
            if (string.IsNullOrEmpty(e.Exception.Message))
                return;
            e.Cancel = true;
            d.AllowUserToDeleteRows = true;
            d.Rows.Clear();
            d.AllowUserToDeleteRows = false;
            
        }

        void invoicemasterBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            var obj = sender as BindingSource;
            //if (e.Exception.GetHashCode() != 0)
           // {
                
                MessageBox.Show(e.Exception.Message);
                e.Exception.Data.Clear();
           // }
        }

        void invoicedetailBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            var obj = sender as BindingSource;
           // if (e.Exception.GetHashCode() != 0)
            //{
               
                MessageBox.Show(e.Exception.Message);
                e.Exception.Data.Clear();
           // }
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
                    dataGridView1.AllowUserToDeleteRows = true;

                    dataGridView1.Rows.Clear();
                    dataGridView1.AllowUserToDeleteRows = false;
                }
            }
            else
            {
                List_detail = Common.MsSql.getInvoiceDetail(currim.Client_name, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            if (List_detail.Count == 0)
            {
                dataGridView1.AllowUserToDeleteRows = true;

                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToDeleteRows = false;
            }
            this.invoicedetailBindingSource.DataSource = List_detail;
            this.SaveBut.Enabled = this.invoicemasterBindingSource.Count > 0 && this.invoicedetailBindingSource.Count > 0;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceConversion.Data.Invoice_master i = new Data.Invoice_master();
        }
        
        private void manageBut_Click(object sender, EventArgs e)
        {
            //管理发票 标题
            AddComFm acf = new AddComFm();
           DialogResult d=acf.ShowDialog();
           if (d == DialogResult.OK)
           {
               bool s=false;
               foreach (Data.InvoiceTitel l in title_combox.Items)
               {
                   s = (acf.SelectTitle.Company_id == l.Company_id);
                   if (s) break;
                   
               }
               if (!s)
               {
                   this.invoiceTitelBindingSource.Add(acf.SelectTitle);
               }
               title_combox.SelectedItem = acf.SelectTitle;
           }
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
                if (dv.Cells[3].Value == null) continue;
                float p;
                float.TryParse(dv.Cells[3].Value.ToString(), out p);

                float.TryParse(string.Format("{0:F2}", (p * savl)), out p);
               // List_detail[i].Rpice = p;
                dv.Cells[3].Value = p;
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
            imaster.Invoice_nmber = Common.MsSql.Next_No();
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
                System.Diagnostics.Debug.WriteLine(imaster.Invoice_nmber);
                sqls[i]=d.GetSqlQuery(DataMode, string.Empty);
                objs[i] = d.Parameter;
                
            }
            if (Common.MsSql.ExcMulSql(sqls, objs))
            {
                MessageBox.Show("生成了新的發票號", imaster.Invoice_nmber);
                this.printBut.Enabled = true;
                this.SaveBut.Enabled = false;
            }
            else
            {
                MessageBox.Show("生成了新的發票失敗","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.printBut.Enabled = false;
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
            var t = this.invoiceTitelBindingSource.Current as Data.InvoiceTitel;
            PrInFm pf = new PrInFm();
            pf.Preview(t);
            pf.ShowDialog();
        }
    }
}
