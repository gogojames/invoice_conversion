using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace InvoiceConversion
{
    public partial class Mdbfm : Form
    {
        public Mdbfm()
        {
            InitializeComponent();
        }

        private void Mdbfm_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string s = config.ConnectionStrings.ConnectionStrings["InvoiceConversion.Properties.Settings.ConnectionString"].ConnectionString;
            string[] str = s.Split(';');
            for (int i = 0; i < str.Length; i++)
            {
                string s_tmp = str[i];
                int j = s_tmp.IndexOf("=");
                string s_tmp_r = s_tmp.Substring(j + 1);
                string s_tmp_l = s_tmp.Substring(0, j);
                s_tmp_l = s_tmp_l.Trim();
                switch (s_tmp_l)
                {
                    case "Data Source":
                        this.serverEdt.Text = s_tmp_r;
                        break;
                    case "Initial Catalog":
                        this.databaseEdt.Text = s_tmp_r;
                        break;
                    case "User ID":
                        this.userNoEdt.Text = s_tmp_r;
                        break;
                    case "Password":
                        this.pswEdt.Text = s_tmp_r;
                        break;
                }
            }
        }

        private void testbut_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=" + this.serverEdt.Text
                            + ";Initial Catalog=" + this.databaseEdt.Text
                            + ";User ID=" + this.userNoEdt.Text
                            + ";Password=" + this.pswEdt.Text;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conStr);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select getdate()", con);
            try
            {
                con.Open();
                object obj = cmd.ExecuteScalar();
                MessageBox.Show("測試成功!\t\n服務器當前時間為: " + obj.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception em)
            {
                MessageBox.Show("測試失敗!\t\n" + em.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void sevBut_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=" + this.serverEdt.Text
                            + ";Initial Catalog=" + this.databaseEdt.Text
                            + ";User ID=" + this.userNoEdt.Text
                            + ";Password=" + this.pswEdt.Text;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["InvoiceConversion.Properties.Settings.ConnectionString"].ConnectionString = conStr;
            try
            {
                config.Save();
                MessageBox.Show("設置已改變,請重新啟動程序! ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message + "保存失敗!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
