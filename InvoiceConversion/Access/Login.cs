using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace InvoiceConversion.Access
{
   public class Login
    {
       private string user;
       private string password;
       public string User { get { return user; } private set { user = value; } }
       public string Password { get { return password; } private set { password = value; } }
       private string _error;
       public string Error { get { return _error; } private set { _error = value; } }
       private static System.Data.DataTable _table;
       public static System.Data.DataTable Table { get { return _table; } }
       public Login(string user,string pwd) 
       {
           this.Password = pwd;
           this.user = user;
       }

       public bool Validation()
       {
           bool b = true;
           using (SqlConnection conn = InvoiceConversion.Common.MsSql.connection)
           {
               System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
               cmd.CommandText = "select userID,userName from users where userName=@username and userPSW=@password ";
               cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 20).Value = this.User;
               cmd.Parameters.Add("@password", SqlDbType.NVarChar, 20).Value = this.Password;
               
               System.Data.DataSet ds = new System.Data.DataSet();
               System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter();
               adp.SelectCommand = cmd;
               cmd.Connection = conn;
               try
               {
                   conn.Open();
                   adp.Fill(ds, "users");
                   if (ds.Tables["users"].Rows.Count == 0)
                   {
                       b = false;
                   }
                   Login._table = ds.Tables["users"];
               }
               catch (Exception e)
               {
                   this.Error = e.Message;
                   b = false;
               }
               finally
               {
                   conn.Close();
               }
           }
           return b;
       }
 
    }
}
