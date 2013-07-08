using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Common
{
    public class MsSql
    {
      public static System.Data.SqlClient.SqlConnection connection
        {
            get
            {
                return new System.Data.SqlClient.SqlConnection(MsSql.connectionString);
            }
        }

        public static string connectionString
        {
            get
            {
                return global::InvoiceConversion.Properties.Settings.Default.ConnectionString;
            }
        }

        public static DateTime DBdatetime
        {
            get
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = "select getdate() ";
                cmd.Connection = MsSql.connection;
                try
                {
                    cmd.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    return (DateTime)obj;
                }
                catch 
                {
                    return DateTime.Now;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        

        public static string getNearbyNo(string currentNo,string fieldname,string tablename,string orderDirection)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = "getNearbyNo";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@currentNo", System.Data.SqlDbType.NVarChar, 36).Value = currentNo;
            cmd.Parameters.Add("@fieldname", System.Data.SqlDbType.NVarChar, 100).Value = fieldname;
            cmd.Parameters.Add("@tablename", System.Data.SqlDbType.NVarChar, 100).Value = tablename;
            cmd.Parameters.Add("@orderDirection", System.Data.SqlDbType.NVarChar, 5).Value = orderDirection;
            cmd.Connection = MsSql.connection;
            try
            {
                cmd.Connection.Open();
                object obj = cmd.ExecuteScalar();
                return obj.ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static List<Data.Invoice> getInvoice(string client_name,DateTime start_date,DateTime end_date)
        {
            List<Data.Invoice> li = new List<Data.Invoice>();
            string sql = @"SELECT   dbo.Custmer.Client_ID, dbo.Custmer.Client_N, dbo.Invoice.Invoice_Date, dbo.Invoice.AInvoice_ID, dbo.Invoice.Invoice_ID
" +
                        "FROM      dbo.Custmer INNER JOIN"+
                  " dbo.Invoice ON dbo.Custmer.Client_ID = dbo.Invoice.Client_ID"+
                  "WHERE   (dbo.Invoice.Invoice_Date BETWEEN @start_date AND @end_date) AND (dbo.Custmer.Client_N LIKE @client_name)";
            using(System.Data.SqlClient.SqlConnection conn=MsSql.connection){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = client_name;
                cmd.Parameters.Add("@start_date", System.Data.SqlDbType.Date).Value = start_date;
                cmd.Parameters.Add("@end_date", System.Data.SqlDbType.Date).Value = end_date;

                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Invoice idetail = new Data.Invoice();
                        idetail.Ainvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                        idetail.Client_id = reader["Client_ID"].ToString();
                        idetail.Client_name = reader["Client_N"].ToString();
                        idetail.Invoice_date = DateTime.Parse(reader["Invoice_Date"].ToString());
                        idetail.Invoice_nmber = "";
                        idetail.Invoice_title_id = 0;
                        li.Add(idetail);
                    }
                }
                finally
                {
                    conn.Close();
                }

            }

            return li;
        }

        public static List<Data.Invoice_detail> getInvoiceDetail(string client_name,string invoice_id)
        {
            List<Data.Invoice_detail> dids = new List<Data.Invoice_detail>();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection) 
            {
            string sql="SELECT dbo.Custmer.Client_N, dbo.Custmer.Client_ID, dbo.Custmer.Address, dbo.Invoice.AInvoice_ID, "+
  "              dbo.Invoice.Invoice_ID, dbo.Invoice.Contact_Per, dbo.Invoice.Invoice_Date, dbo.Invoice_item.Unit, "+
 "               dbo.Invoice_item.Price, dbo.Invoice_item.Qty,dbo.Invoice_item.Item_ID "+
"FROM      dbo.Custmer INNER JOIN "+
  "              dbo.Invoice ON dbo.Custmer.Client_ID = dbo.Invoice.Client_ID INNER JOIN "+
 "               dbo.Invoice_item ON dbo.Invoice.AInvoice_ID = dbo.Invoice_item.AInvoice_ID "+
"WHERE   (dbo.Custmer.Client_N LIKE @client_name ) AND (dbo.Invoice.Invoice_ID = @invoice_id ) "+
"ORDER BY dbo.Invoice.Invoice_Date DESC";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = "%"+client_name;
            cmd.Parameters.Add("@invoice_id", System.Data.SqlDbType.NVarChar).Value = invoice_id;
            cmd.Connection = conn;
            try
            {
                conn.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data.Invoice_detail idetail = new Data.Invoice_detail();
                    idetail.AInvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                    idetail.Item_id = MsSql.ToInt(reader["Item_ID"]).Value;
                    double _qty = 0.00;
                    double.TryParse(reader["Qty"].ToString(), out _qty);
                    idetail.Qty = _qty;
                    double _rpice = 0.00;
                    double.TryParse(reader["Price"].ToString(), out _rpice);

                    idetail.Rpice = _rpice;
                    idetail.Unit = reader["Unit"].ToString();
                    dids.Add(idetail);
                }
            }
            finally
            {
                conn.Close();
            }

            }
            return dids; 
        }

        public static string ToString(object obj)
        {
            if (System.Convert.IsDBNull(obj))
                return null;
            else
                return obj.ToString();
        }

        public static int? ToInt(object obj)
        {
            if (System.Convert.IsDBNull(obj))
                return null;
            else
                return (int)obj;
        }
        
        public static DateTime? ToDateTime(object obj)
        {
            if (System.Convert.IsDBNull(obj))
                return null;
            else
                return (DateTime)obj;
        }

        public static decimal? ToDecimal(object obj)
        {
            if (System.Convert.IsDBNull(obj))
                return null;
            else
                return (decimal)obj;
        }

        public static bool? ToBool(object obj)
        {
            if (System.Convert.IsDBNull(obj))
                return null;
            else
                return (bool)obj;
        }

        public static string replaceChrToPercent(string objString)
        {
            return objString.Replace('\\', '%');
        }
    }
    }
