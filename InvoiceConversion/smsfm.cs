using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace InvoiceConversion
{
    public partial class smsfm : Form
    {
        public smsfm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contents = textBox2.Text + textBox1.Text;
            if (string.IsNullOrEmpty(contents))
            {
                MessageBox.Show("請輸入回饋的內容");
                return;
            }
            
            try
            {
                System.Net.Mail.SmtpClient client = new SmtpClient("smtp.hk-tl.com");
                //client.EnableSsl = true;
                //client.Port = 465;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("james@hk-tl.com", "cct33940");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailAddress addressFrom = new MailAddress("james@hk-tl.com", Access.Login.Table.Rows[0]["userName"].ToString());
                MailAddress addressTo = new MailAddress("james@hk-tl.com", "InvoiceConversion");

                System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
                message.Sender = new MailAddress("james@hk-tl.com");
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Body = buildMsg(contents);
                message.Subject = "利新厂发票工具软件反馈";
                client.Send(message);
                MessageBox.Show("感謝您的回饋,期待您更多的回饋.");
                this.DialogResult = DialogResult.OK;
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        string buildMsg(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message);
            sb.Append("<br><b>OS version</b>");
            string lan=System.Globalization.CultureInfo.InstalledUICulture.Name;
            var ver = Environment.OSVersion;
           var dir= Environment.CurrentDirectory;
           sb.Append(ver.VersionString);
           sb.Append("<br><b>Language</b>");
           sb.Append(lan);
           sb.Append("<br><b>Current Directory</b>");
           sb.Append(dir);
           sb.Append("<br><b>Run .net version</b>");
           sb.Append(Environment.Version.ToString());
           return sb.ToString();
        }
    }
}
