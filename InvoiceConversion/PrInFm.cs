using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InvoiceConversion.Common;

namespace InvoiceConversion
{
    public partial class PrInFm : Form
    {
        public PrInFm()
        {
            InitializeComponent();
            this.invoiceTitelBindingSource.CurrentChanged += new EventHandler(invoiceTitelBindingSource_CurrentChanged);
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
            
        }

        void invoiceTitelBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var detail = this.invoiceTitelBindingSource.Current as Data.InvoiceTitel;

            this.invoicemasterBindingSource.DataSource = Common.MsSql.InvoiceMasterBy(string.Empty, detail.Company_id);
        }



        private void button1_Click(object sender, EventArgs e)
        {            
            var title = this.comboBox1.SelectedItem as Data.InvoiceTitel;
            var nmber = this.invoicemasterBindingSource.Current as Data.Invoice_master;
            Preview(title,nmber);
        }

        public void Preview(Data.InvoiceTitel title,Data.Invoice_master master)
        {
            if (title == null || master == null)
            {
                MessageBox.Show("請選擇發標題和編號.");
                return;
            }
            int ri = comboBox3.SelectedIndex;
            if (ri < 0)
            {
                MessageBox.Show("請選擇報表.");
                return;
            }
            string[] reports = new string[] {"InvoiceConversion.RePort.Report1.rdlc","InvoiceConversion.RePort.Report2.rdlc" };
            
            this.reportViewer1.LocalReport.ReportEmbeddedResource = reports[ri];
            this.reportViewer1.LocalReport.DataSources.Clear();
            var data = new List<Data.Invoice_master>();

            var intitel = new List<Data.InvoiceTitel>();
            
            var m = getMaster(title.Company_id,master.Invoice_nmber);
            data.Add(m);
            var indetail = getMasterDetail(m.Invoice_nmber);
            intitel.Add(title);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("inmaster", data));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("indetail", indetail));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("intitel", intitel));
            // this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("customerName", dr.customer.Cname));
            this.reportViewer1.RefreshReport();
        }

        Data.Invoice_master getMaster(int? company_id, string _Invoice_nmber)
        {
            string w = "";
            if (company_id.HasValue)
            {
                w = " where Invoice_title_id= "+company_id.Value;
            }
            if (!string.IsNullOrEmpty(_Invoice_nmber))
            {
                if (string.IsNullOrEmpty(w))
                {
                    w = " where Invoice_nmber= '" + _Invoice_nmber + "' ";
                }
                else
                {
                    w += " and Invoice_nmber= '" + _Invoice_nmber + "' ";
                }
            }
            Data.Invoice_master m = new Data.Invoice_master();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = m.GetSqlQuery(Basic.FormMode.browseMode, string.Empty);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql+w;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        m.Ainvoice_id = reader["Ainvoice_id"].ToString();
                        m.Client_id = reader["Client_id"].ToString();
                        m.Client_name = reader["Client_name"].ToString();
                        m.Invoice_date =DateTime.Parse( reader["Invoice_date"].ToString());
                        
                        m.Invoice_nmber = reader["Invoice_nmber"].ToString();
                        m.Invoice_title_id =int.Parse( reader["Invoice_title_id"].ToString());
                        //m.Last_update =DateTime.Parse( reader["Last_update"].ToString());
                        m.Remake = reader["Remake"].ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }

            }
            return m;
        }

        List<Data.Invoice_detail> getMasterDetail(string inm)
        {
            string w = " where Invoice_nmber= @Invoice_nmber ";
            
            List<Data.Invoice_detail> list_d = new List<Data.Invoice_detail>();
            if (string.IsNullOrEmpty(inm)) return list_d;
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                Data.Invoice_detail  m = new Data.Invoice_detail();
                string sql = m.GetSqlQuery(Basic.FormMode.browseMode, string.Empty);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql + w;
                cmd.Parameters.Add("@Invoice_nmber", System.Data.SqlDbType.VarChar).Value = inm;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        m = new Data.Invoice_detail();
                        m.AInvoice_id = reader["Ainvoice_id"].ToString();
                        float _pice = 0;
                        float.TryParse(reader["Rpice"].ToString(), out _pice);
                        m.Rpice = _pice;
                        float _qty = 0;
                        float.TryParse(reader["Qty"].ToString(), out _qty);
                        m.Qty = _qty;
                        m.Item_name = reader["Item_name"].ToString();
                        m.Item_code = reader["Item_code"].ToString();
                        m.Invoice_nmber = reader["Invoice_nmber"].ToString();
                        m.Detail_id = int.Parse(reader["Detail_id"].ToString());
                        m.Unit = reader["unit"].ToString();
                        m.Remake = reader["Remake"].ToString();
                        list_d.Add(m);
                    }
                }
                finally
                {
                    conn.Close();
                }

            }
            return list_d;
        }
    }
}
