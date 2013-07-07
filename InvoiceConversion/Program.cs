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
                Application.Run(new MainFm());
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
