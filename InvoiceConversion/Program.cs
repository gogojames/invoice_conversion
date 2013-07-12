using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InvoiceConversion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoginFm login = new LoginFm();
            DialogResult dr = login.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Application.Run(new MainFm());
                }
                catch {
                    MessageBox.Show("抱歉，系統發生意外退出重啟！","錯誤",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Run(new MainFm());
                }
                
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
