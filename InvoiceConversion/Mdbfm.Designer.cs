namespace InvoiceConversion
{
    partial class Mdbfm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverEdt = new System.Windows.Forms.TextBox();
            this.databaseEdt = new System.Windows.Forms.TextBox();
            this.userNoEdt = new System.Windows.Forms.TextBox();
            this.pswEdt = new System.Windows.Forms.TextBox();
            this.sevBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.testbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverEdt
            // 
            this.serverEdt.Location = new System.Drawing.Point(123, 53);
            this.serverEdt.Name = "serverEdt";
            this.serverEdt.Size = new System.Drawing.Size(122, 21);
            this.serverEdt.TabIndex = 0;
            // 
            // databaseEdt
            // 
            this.databaseEdt.Location = new System.Drawing.Point(123, 89);
            this.databaseEdt.Name = "databaseEdt";
            this.databaseEdt.Size = new System.Drawing.Size(122, 21);
            this.databaseEdt.TabIndex = 1;
            // 
            // userNoEdt
            // 
            this.userNoEdt.Location = new System.Drawing.Point(123, 121);
            this.userNoEdt.Name = "userNoEdt";
            this.userNoEdt.Size = new System.Drawing.Size(122, 21);
            this.userNoEdt.TabIndex = 2;
            // 
            // pswEdt
            // 
            this.pswEdt.Location = new System.Drawing.Point(123, 157);
            this.pswEdt.Name = "pswEdt";
            this.pswEdt.Size = new System.Drawing.Size(122, 21);
            this.pswEdt.TabIndex = 3;
            this.pswEdt.UseSystemPasswordChar = true;
            // 
            // sevBut
            // 
            this.sevBut.Location = new System.Drawing.Point(158, 222);
            this.sevBut.Name = "sevBut";
            this.sevBut.Size = new System.Drawing.Size(75, 23);
            this.sevBut.TabIndex = 4;
            this.sevBut.Text = "应用设置";
            this.sevBut.UseVisualStyleBackColor = true;
            this.sevBut.Click += new System.EventHandler(this.sevBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "数据库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "账号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "密码";
            // 
            // testbut
            // 
            this.testbut.Location = new System.Drawing.Point(56, 222);
            this.testbut.Name = "testbut";
            this.testbut.Size = new System.Drawing.Size(75, 23);
            this.testbut.TabIndex = 9;
            this.testbut.Text = "测试";
            this.testbut.UseVisualStyleBackColor = true;
            this.testbut.Click += new System.EventHandler(this.testbut_Click);
            // 
            // Mdbfm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 294);
            this.Controls.Add(this.testbut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sevBut);
            this.Controls.Add(this.pswEdt);
            this.Controls.Add(this.userNoEdt);
            this.Controls.Add(this.databaseEdt);
            this.Controls.Add(this.serverEdt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mdbfm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置数据源";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Mdbfm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverEdt;
        private System.Windows.Forms.TextBox databaseEdt;
        private System.Windows.Forms.TextBox userNoEdt;
        private System.Windows.Forms.TextBox pswEdt;
        private System.Windows.Forms.Button sevBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button testbut;
    }
}