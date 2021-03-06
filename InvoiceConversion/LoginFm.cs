﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceConversion
{
    public partial class LoginFm : Form
    {
        public LoginFm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("輸入用戶名！");
                this.textBox1.Focus();
                return;
            }
            if (this.textBox2.Text == string.Empty)
            {
                MessageBox.Show("輸入密碼！");
                this.textBox2.Focus();
                return;
            }

            Access.Login loging = new Access.Login(this.textBox1.Text, this.textBox2.Text);
            if (loging.Validation())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("登錄失敗\n\r原因：" + loging.Error);
            }
        }

        private void setDS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Mdbfm f = new Mdbfm();
            try
            {
                this.Hide();
                if (f.ShowDialog(this) == DialogResult.OK)
                    this.Close();
            }
            finally
            {
                this.Show();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                login();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                login();
        }

    }
}
