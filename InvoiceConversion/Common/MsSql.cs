﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
                  "WHERE   (Invoice.Invoice_Date BETWEEN @start_date AND @end_date)  ";
            if (!string.IsNullOrEmpty(client_name))
            {
                sql += " AND (Custmer.Client_ID = @client_name)";
            }
            using(System.Data.SqlClient.SqlConnection conn=MsSql.connection){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                if (!string.IsNullOrEmpty(client_name))
                {
                    cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = client_name;
                }
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
                        idetail.BeginEdit();
                        idetail.Last_update = DateTime.Now;
                        idetail.Ainvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                        idetail.Client_id = reader["Client_ID"].ToString();
                        idetail.Client_name = reader["Client_N"].ToString();
                        idetail.Invoice_date = DateTime.Parse(reader["Invoice_Date"].ToString());
                        idetail.Invoice_nmber = string.Empty;
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

        public static List<Data.Invoice_master> InvoiceMasterBy(string Invoice_nmber, int? titid)
        {
            List<Data.Invoice_master> li = new List<Data.Invoice_master>();
            string _and = "";
            if ( !string.IsNullOrEmpty(Invoice_nmber) && titid.HasValue)
            {
                _and = "(Invoice_nmber = @Invoice_nmber) and  invoice_title_id=@invoice_title_id ";
            }
            if (!string.IsNullOrEmpty(Invoice_nmber))
            {
                _and = " (Invoice_nmber like @Invoice_nmber) ";
            }
            if (titid.HasValue)
            {
                _and = "  invoice_title_id=@invoice_title_id ";
            }
            string sql = @"SELECT  * " +
                        "FROM   Invoice_master " +
                  "WHERE  "+_and+"  ORDER BY Last_update DESC ";
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                if (!string.IsNullOrEmpty(Invoice_nmber))
                {
                    cmd.Parameters.Add("@Invoice_nmber", System.Data.SqlDbType.NVarChar).Value = Invoice_nmber;
                }
                if (titid.HasValue)
                {
                    cmd.Parameters.Add("@invoice_title_id", System.Data.SqlDbType.Int).Value = titid;
                }

                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Invoice_master idetail = new Data.Invoice_master();
                        idetail.BeginEdit();
                        idetail.Last_update = DateTime.Parse(reader["Last_update"].ToString()); ;
                        idetail.Ainvoice_id = MsSql.ToString(reader["Ainvoice_id"]);
                        idetail.Client_id = reader["Client_id"].ToString();
                        idetail.Client_name = reader["Client_name"].ToString();
                        idetail.Invoice_date = DateTime.Parse(reader["Invoice_date"].ToString());
                        idetail.Invoice_nmber = reader["Invoice_nmber"].ToString();
                        int tid = 0;
                        int.TryParse(reader["Invoice_title_id"].ToString(), out tid);
                        idetail.Invoice_title_id = tid;
                        idetail.Remake = reader["Remake"].ToString();
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
            // (Custmer.Client_N = "") AND (Invoice.Invoice_Date BETWEEN '18/09/2013 0:00:00 AM' AND '20/09/2013 0:00:00 AM')
            string wn = "(Custmer.Client_N = @client_name ) and ";
            if (string.IsNullOrEmpty(client_name))
            {
                wn = "";
            }
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection) 
            {
                string sql = "SELECT Custmer.Client_N, Custmer.Client_ID, Custmer.Address, Invoice.AInvoice_ID, " +
  "              Invoice.Invoice_ID, Invoice.Contact_Per, Invoice.Invoice_Date, Invoice_item.Unit, "+
 "               Invoice_item.Price, Invoice_item.Qty,Invoice_item.Item_ID,Invoice_item.Metrial_ID,Invoice_item.Metrial_N " +
"FROM      Custmer INNER JOIN "+
  "              Invoice ON Custmer.Client_ID = Invoice.Client_ID INNER JOIN "+
 "               Invoice_item ON Invoice.AInvoice_ID = Invoice_item.AInvoice_ID "+
"WHERE   "+wn+"  (Invoice.Invoice_Date BETWEEN @start_date AND @end_date) " +
"ORDER BY Invoice.Invoice_Date DESC";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            //Debug.WriteLine(sql);
            if (!string.IsNullOrEmpty(wn))
            {
                cmd.Parameters.Add("@client_name", System.Data.SqlDbType.NVarChar).Value = client_name;
            }
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
                    idetail.BeginEdit();
                    idetail.AInvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                    idetail.Isdelete = true;
                    float item_id;
                    float.TryParse(reader["Item_ID"].ToString(), out item_id);
                    idetail.Item_id = item_id;
                    float _qty = 0;
                    float.TryParse(reader["Qty"].ToString(), out _qty);
                    idetail.Qty = _qty;
                    float _rpice = 0;
                    float.TryParse(reader["Price"].ToString(), out _rpice);
                    idetail.Item_name = reader["Metrial_N"].ToString();
                    idetail.Item_code = reader["Metrial_ID"].ToString();
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

        public static List<Data.Invoice_detail> InvoiceDetailByNmber(string nmber)
        {
            List<Data.Invoice_detail> dids = new List<Data.Invoice_detail>();
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = "SELECT *  " +
                            "FROM      Invoice_detail " +
                            "WHERE   (Invoice_nmber = @Invoice_nmber ) " +
                            "ORDER BY Detail_id DESC";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Invoice_nmber", System.Data.SqlDbType.NVarChar).Value = nmber;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Invoice_detail idetail = new Data.Invoice_detail();
                        idetail.BeginEdit();
                        idetail.AInvoice_id = MsSql.ToString(reader["AInvoice_ID"]);
                        float item_id;
                        float.TryParse(reader["Item_ID"].ToString(), out item_id);
                        idetail.Item_id = item_id;
                        float _qty = 0;
                        float.TryParse(reader["Qty"].ToString(), out _qty);
                        idetail.Qty = _qty;
                        float _rpice = 0;
                        float.TryParse(reader["Rpice"].ToString(), out _rpice);
                        idetail.Item_name = reader["Item_name"].ToString();
                        idetail.Item_code = reader["Item_code"].ToString();
                        idetail.Rpice = _rpice;
                        idetail.Unit = reader["Unit"].ToString();
                        idetail.Invoice_nmber = reader["invoice_nmber"].ToString();
                        int _id;
                        int.TryParse(reader["Detail_id"].ToString(), out _id);
                        idetail.Detail_id = _id;
                        idetail.Remake = reader["Remake"].ToString();
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

        public static List<Data.Invoice_master> SearchInvoice()
        {
            List<Data.Invoice_master> invoice = new List<Data.Invoice_master>();
            
            return invoice;
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
                        c.BeginEdit();
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

        public static bool ExcMulSql(string[] sqls,object[] objs)
        {
            bool r = false;
            System.Data.SqlClient.SqlCommand[] cmds = new System.Data.SqlClient.SqlCommand[sqls.Length];
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                conn.Open();
                using (System.Data.SqlClient.SqlTransaction tarn = conn.BeginTransaction())
                {
                    for (int i = 0; i < sqls.Length; i++)
                    {
                        string sql = sqls[i];
                        System.Diagnostics.Debug.WriteLine(sql);
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                        cmd.CommandText = sql;
                        cmd.Connection = conn;
                        cmd.Transaction = tarn;
                        object[] _pars = objs[i] as object[];
                        for (int n = 0; n < _pars.Length; n++)
                        {
                            if (n % 2 == 0)
                            {
                                int m = n + 1;
                                System.Data.SqlClient.SqlParameter par = new System.Data.SqlClient.SqlParameter(_pars[n].ToString(), _pars[m]);
                                cmd.Parameters.Add(par);
                            }
                        }
                        cmds[i] = cmd;
                    }
                    try
                    {
                        foreach (System.Data.SqlClient.SqlCommand cmd in cmds)
                        {
                            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
                            r = cmd.ExecuteNonQuery() > 0;
                        }
                        tarn.Commit();
                        r = true;
                    }
                    catch(Exception e) {
                        tarn.Rollback();
                        r = false;
                        throw e;
                    }
                    finally
                    {                        
                        conn.Close();
                    }
                }
            }
            return r;
        }

        public static List<Data.Customer> getCustmer()
        {
            return MsSql.getCustmer(string.Empty);
        }

        public static List<Data.Customer> getCustmer(string clientName)
        {
            List<Data.Customer> lc = new List<Data.Customer>();
            lc.Add(new Data.Customer() { Clent_n = "全部", Client_id = "" });
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = "SELECT   * FROM      Custmer ";
                string where = "where (Client_N LIKE @clientid)";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                if (!string.IsNullOrEmpty(clientName))
                {
                    cmd.CommandText += where;
                    cmd.Parameters.Add("@clientid", System.Data.SqlDbType.NVarChar).Value = "%" + clientName+"%";
                }
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
        //new_invoice
        /*SELECT doc_next_no
        FROM dbo.doc_no
        WHERE (doc_no = 'new_invoice')*/
        public static string Next_No()
        {
            string no = string.Empty;
            using (System.Data.SqlClient.SqlConnection conn = MsSql.connection)
            {
                string sql = "SELECT doc_next_no      FROM doc_no        WHERE (doc_no = 'new_invoice')";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        no = reader["doc_next_no"].ToString();
                    }
                    StringBuilder new_no = new StringBuilder();
                    new_no.Append(next(no));
                    MsSql.ExSql("UPDATE doc_no SET doc_next_no =@doc_next_no WHERE (doc_no = 'new_invoice') ", new object[] { "@doc_next_no", new_no.ToString() });
                }
                finally
                {
                    conn.Close();
                }

            }
            return no;
        }

        static string next(string no)
        {
            System.Text.StringBuilder new_no = new System.Text.StringBuilder();
            var tmp = new System.Text.StringBuilder();
            var _int = no.TrimStart(new char[] { 'N' });
            int n_int = 0;
            int.TryParse(_int, out n_int);
            n_int++;
            foreach (char c in no.ToCharArray())
            {
                if (c == 78 || c == 48)
                {
                    new_no.Append(c.ToString());
                    tmp.Append(c.ToString());
                }
            }
            tmp.Append(n_int.ToString());
            int di = tmp.Length - no.Length;
            if (di > 0)
            {
                new_no = new_no.Remove(new_no.Length - di, di);
            }
            new_no.Append(n_int.ToString());
            return new_no.ToString();
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
