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
            this.invoiceTitelBindingSource.DataSource = Common.MsSql.getTitle();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InvoiceConversion.RePort.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            var title = this.comboBox1.SelectedItem as Data.InvoiceTitel;
            Preview(title);
        }

        public void Preview(Data.InvoiceTitel title)
        {
            var data = new List<Data.Invoice_master>();

            var intitel = new List<Data.InvoiceTitel>();
            
            var m = getMaster(title.Company_id);
            data.Add(m);
            var indetail = getMasterDetail(m.Invoice_nmber);
            intitel.Add(title);
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("inmaster", data));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("indetail", indetail));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("intitel", intitel));
            // this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("customerName", dr.customer.Cname));
            this.reportViewer1.RefreshReport();
        }

        Data.Invoice_master getMaster(int? company_id)
        {
            string w = "";
            if (company_id.HasValue)
            {
                w = " where Invoice_title_id= "+company_id.Value;
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
            string w  = " where Invoice_nmber= @Invoice_nmber ";
            
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
                        double _pice = 0.00;
                        double.TryParse(reader["Rpice"].ToString(), out _pice);
                        m.Rpice = _pice;
                        double _qty = 0.00;
                        double.TryParse(reader["Qty"].ToString(), out _qty);
                        m.Qty = _qty;
                        m.Item_name = reader["Item_name"].ToString();

                        m.Invoice_nmber = reader["Invoice_nmber"].ToString();
                        m.Detail_id = int.Parse(reader["Detail_id"].ToString());
                        //m.Last_update =DateTime.Parse( reader["Last_update"].ToString());
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
