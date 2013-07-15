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
        List<Data.Invoice_master> list_master;
        public Common.Basic.FormMode DataMode;
        public InCoFm()
        {
            InitializeComponent();
            this.printBut.Enabled = false;
            this.SaveBut.Enabled = false;
            DataMode = Common.Basic.FormMode.newMode;
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.invoicedetailBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicedetailBindingSource_DataError);
            this.invoicemasterBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicemasterBindingSource_DataError);
            this.customerBindingSource.DataSource = Common.MsSql.getCustmer();
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            this.invoicedetailBindingSource.DataSource = List_detail;
            this.invoicemasterBindingSource.CurrentChanged += new EventHandler(invoicemasterBindingSource_CurrentChanged);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
        }

        public InCoFm(Data.Invoice_master master)
        {
            InitializeComponent();
            this.edit_but.Visible = true;
            this.SaveBut.Enabled = false;
            label6.Visible = true;
            label1.Visible = false;
            custmer_text.Visible = false;
            edit_but.Click += new EventHandler(SaveBut_Click);
            this.custmer_text.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoicemasterBindingSource, "Client_name", true));
            this.title_combox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoicemasterBindingSource, "invoice_title_id", true));
            DataMode = Common.Basic.FormMode.modifyMode;
            list_master = new List<Data.Invoice_master>();
            list_master.Add(master);
            this.invoicemasterBindingSource.DataSource = list_master;
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.invoicedetailBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicedetailBindingSource_DataError);
            this.invoicemasterBindingSource.DataError += new BindingManagerDataErrorEventHandler(invoicemasterBindingSource_DataError);
           // this.customerBindingSource.DataSource = Common.MsSql.getCustmer();
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            List_detail= Common.MsSql.InvoiceDetailByNmber(master.Invoice_nmber);
            this.invoicedetailBindingSource.DataSource = List_detail;
            //this.invoicemasterBindingSource.CurrentChanged += new EventHandler(invoicemasterBindingSource_CurrentChanged);
           
            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            invoiceNmber_text.Text = master.Invoice_nmber;
            invoiceNmber_text.Enabled = false;
            invoiceNmber_text.Visible = true;
            reme.Text = master.Remake;

        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // MessageBox.Show(e.Exception.Message);
            
            var d = sender as DataGridView;
           // System.Diagnostics.Debug.WriteLine(d.Rows[e.RowIndex].Cells[7].Value);
            if (!string.IsNullOrEmpty(e.Exception.Message))
            {
                //MessageBox.Show(e.Exception.Message);
                e.Cancel = true;
                d.AllowUserToDeleteRows = true;
                d.Rows.Clear();
                d.AllowUserToDeleteRows = false;
            }
            
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

           // MessageBox.Show("修改成功");
           // invoicedetailBindingSource.DataSource = List_detail;

        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            Data.Invoice_master imaster = this.invoicemasterBindingSource.Current as Data.Invoice_master;
            
            Data.InvoiceTitel title = this.title_combox.SelectedItem as Data.InvoiceTitel;
            if (DataMode == Common.Basic.FormMode.newMode)
            {
                imaster.Remake = reme.Text;
                imaster.Invoice_nmber = Common.MsSql.Next_No();
                imaster.Invoice_title_id = title.Company_id;

                string sql = imaster.GetSqlQuery(DataMode, String.Empty);
                //Common.MsSql.ExSql(sql, imaster.Parameter);
                string[] sqls = new string[List_detail.Count + 1];
                object[] objs = new object[List_detail.Count + 1];
                int i = 0;
                sqls[i] = sql;
                objs[i] = imaster.Parameter;
                foreach (Data.Invoice_detail d in this.List_detail)
                {
                    i++;
                    d.BeginEdit();
                    d.Invoice_nmber = imaster.Invoice_nmber;
                    System.Diagnostics.Debug.WriteLine(d.Invoice_nmber);
                    sqls[i] = d.GetSqlQuery(DataMode, string.Empty);
                    objs[i] = d.Parameter;

                }
                if (Common.MsSql.ExcMulSql(sqls, objs))
                {
                    MessageBox.Show("生成了新的發票號:" + imaster.Invoice_nmber, "發票", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.printBut.Enabled = true;
                    this.SaveBut.Enabled = false;
                }
                else
                {
                    MessageBox.Show("生成了新的發票失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.printBut.Enabled = false;
                }
            }
            if (DataMode == Common.Basic.FormMode.modifyMode)
            {
                imaster.Remake = reme.Text;
                imaster.Invoice_title_id = title.Company_id;

                string sql = imaster.GetSqlQuery(DataMode, "Invoice_nmber");
                //Common.MsSql.ExSql(sql, imaster.Parameter);
                string[] sqls = new string[List_detail.Count + 1];
                object[] objs = new object[List_detail.Count + 1];
                int i = 0;
                sqls[i] = sql;
                objs[i] = imaster.Parameter;
                foreach (Data.Invoice_detail d in this.List_detail)
                {
                    
                    i++;
                    d.BeginEdit();
                    d.Invoice_nmber = imaster.Invoice_nmber;
                    System.Diagnostics.Debug.WriteLine(d.Invoice_nmber);
                    sqls[i] = d.GetSqlQuery(DataMode, "Detail_id");
                    objs[i] = d.Parameter;

                }
                if (Common.MsSql.ExcMulSql(sqls, objs))
                {
                    MessageBox.Show("修改發票成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改發票失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
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
            var m = this.invoicemasterBindingSource.Current as Data.Invoice_master;
            PrInFm pf = new PrInFm();
            pf.Preview(t,m);
            pf.ShowDialog();
        }

        private void InCoFm_Load(object sender, EventArgs e)
        {

        }
    }
}
