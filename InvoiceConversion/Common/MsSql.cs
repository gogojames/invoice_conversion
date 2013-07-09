﻿using System;
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

        public static List<Data.Invoice_master> getInvoice(string client_name,DateTime start_date,DateTime end_date)
        {
            List<Data.Invoice_master> li = new List<Data.Invoice_master>();
            string sql = @"SELECT   Custmer.Client_ID, Custmer.Client_N, "+
                "Invoice.Invoice_Date, Invoice.AInvoice_ID, Invoice.Invoice_ID,Invoice.Meno " +
                        "FROM      Custmer INNER JOIN "+
                  " Invoice ON Custmer.Client_ID = Invoice.Client_ID "+
                  "WHERE   (Invoice.Invoice_Date BETWEEN @start_date AND @end_date) AND (Custmer.Client_N = @client_name) ";
            using(System.Data.SqlClient.SqlConnection conn=MsSql.connection){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = client_name;
                cmd.Parameters.Add("@start_date", System.Data.SqlDbType.DateTime).Value = start_date;
                cmd.Parameters.Add("@end_date", System.Data.SqlDbType.DateTime).Value = end_date;

                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Invoice_master idetail = new Data.Invoice_master();
                        idetail.Ainvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                        idetail.Client_id = reader["Client_ID"].ToString();
                        idetail.Client_name = reader["Client_N"].ToString();
                        idetail.Invoice_date = DateTime.Parse(reader["Invoice_Date"].ToString());
                        idetail.Invoice_nmber = Guid.NewGuid().ToString();
                        idetail.Invoice_title_id = 0;
                        idetail.Remake = reader["Meno"].ToString();
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

        public static List<Data.Invoice_detail> getInvoiceDetail(string client_name, DateTime start_date, DateTime end_date)
        {
            List<Data.Invoice_detail> dids = new List<Data.Invoice_detail>();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection) 
            {
            string sql="SELECT Custmer.Client_N, Custmer.Client_ID, Custmer.Address, Invoice.AInvoice_ID, "+
  "              Invoice.Invoice_ID, Invoice.Contact_Per, Invoice.Invoice_Date, Invoice_item.Unit, "+
 "               Invoice_item.Price, Invoice_item.Qty,Invoice_item.Item_ID,Invoice_item.Metrial_N " +
"FROM      Custmer INNER JOIN "+
  "              Invoice ON Custmer.Client_ID = Invoice.Client_ID INNER JOIN "+
 "               Invoice_item ON Invoice.AInvoice_ID = Invoice_item.AInvoice_ID "+
"WHERE   (Custmer.Client_N = @client_name ) and (Invoice.Invoice_Date BETWEEN @start_date AND @end_date) " +
"ORDER BY Invoice.Invoice_Date DESC";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = client_name;
            cmd.Parameters.Add("@start_date", System.Data.SqlDbType.DateTime).Value = start_date;
            cmd.Parameters.Add("@end_date", System.Data.SqlDbType.DateTime).Value = end_date;
            cmd.Connection = conn;
            try
            {
                conn.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data.Invoice_detail idetail = new Data.Invoice_detail();
                    idetail.AInvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                    float item_id;
                    float.TryParse(reader["Item_ID"].ToString(), out item_id);
                    idetail.Item_id = item_id;
                    double _qty = 0.00;
                    double.TryParse(reader["Qty"].ToString(), out _qty);
                    idetail.Qty = _qty;
                    double _rpice = 0.00;
                    double.TryParse(reader["Price"].ToString(), out _rpice);
                    idetail.Item_name = reader["Metrial_N"].ToString();
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

        public static List<Data.InvoiceTitel> getTitle()
        {
            List<Data.InvoiceTitel> lc = new List<Data.InvoiceTitel>();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = "SELECT   * FROM      invoiceTitel";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.InvoiceTitel c = new Data.InvoiceTitel();
                        c.Address = reader["Address"].ToString();
                        c.Company_name = reader["company_name"].ToString();
                        c.Company_id = int.Parse(reader["company_id"].ToString());
                        c.Phone = reader["Phone"].ToString();
                        c.Fax = reader["FAX"].ToString();
                        c.E_mail = reader["E_Mail"].ToString();
                        lc.Add(c);
                    }
                }
                finally
                {
                    conn.Close();
                }

            }
            return lc;
        }

        public static int ExSql(string sql,object[] objs)
        {
            int r = 0;
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                for (int i = 0; i < objs.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        int m = i + 1;
                        System.Data.SqlClient.SqlParameter par = new System.Data.SqlClient.SqlParameter(objs[i].ToString(), objs[m]);
                        cmd.Parameters.Add(par);
                    }
                }
                try
                {
                    conn.Open();
                   r= cmd.ExecuteNonQuery();
                   
                }
                finally
                {
                    conn.Close();
                }

            }
            return r;
        }

        public static List<Data.Customer> getCustmer()
        {
            List<Data.Customer> lc = new List<Data.Customer>();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = "SELECT   * FROM      Custmer";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Customer c = new Data.Customer();
                        c.Address = reader["Address"].ToString();
                        c.Clent_n = reader["Client_N"].ToString();
                        c.Client_id = reader["Client_ID"].ToString();
                        c.Phone = reader["Phone"].ToString();
                        c.Fax = reader["FAX"].ToString();
                        c.E_mail = reader["E_Mail"].ToString();
                        lc.Add(c);
                    }
                }
                finally
                {
                    conn.Close();
                }

            }
            return lc;
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
