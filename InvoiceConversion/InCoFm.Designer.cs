﻿namespace InvoiceConversion
{
    partial class InCoFm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selcu = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.invoicemasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.edit_but = new System.Windows.Forms.Button();
            this.printBut = new System.Windows.Forms.Button();
            this.custmer_text = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceNmber_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.manageBut = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.title_combox = new System.Windows.Forms.ComboBox();
            this.invoiceTitelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.msleBut = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.reme = new System.Windows.Forms.TextBox();
            this.SaveBut = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.isdelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aInvoiceidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rpiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice_nmber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicedetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceTitelBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicedetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.selcu);
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.edit_but);
            this.groupBox1.Controls.Add(this.printBut);
            this.groupBox1.Controls.Add(this.custmer_text);
            this.groupBox1.Controls.Add(this.invoiceNmber_text);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.manageBut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.title_combox);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.msleBut);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // selcu
            // 
            this.selcu.Location = new System.Drawing.Point(391, 14);
            this.selcu.Name = "selcu";
            this.selcu.Size = new System.Drawing.Size(40, 23);
            this.selcu.TabIndex = 20;
            this.selcu.Text = "...";
            this.toolTip1.SetToolTip(this.selcu, "按客戶名查找");
            this.selcu.UseVisualStyleBackColor = true;
            this.selcu.Click += new System.EventHandler(this.selcu_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker3.CustomFormat = "dd/M/yyyy";
            this.dateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.invoicemasterBindingSource, "Last_update", true));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(398, 85);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(146, 21);
            this.dateTimePicker3.TabIndex = 19;
            // 
            // invoicemasterBindingSource
            // 
            this.invoicemasterBindingSource.DataSource = typeof(InvoiceConversion.Data.Invoice_master);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "開單日期";
            // 
            // edit_but
            // 
            this.edit_but.Location = new System.Drawing.Point(559, 14);
            this.edit_but.Name = "edit_but";
            this.edit_but.Size = new System.Drawing.Size(75, 23);
            this.edit_but.TabIndex = 17;
            this.edit_but.Text = "修改(&E)";
            this.edit_but.UseVisualStyleBackColor = true;
            this.edit_but.Visible = false;
            // 
            // printBut
            // 
            this.printBut.Location = new System.Drawing.Point(649, 15);
            this.printBut.Name = "printBut";
            this.printBut.Size = new System.Drawing.Size(75, 23);
            this.printBut.TabIndex = 16;
            this.printBut.Text = "列印(&P)";
            this.printBut.UseVisualStyleBackColor = true;
            this.printBut.Click += new System.EventHandler(this.printBut_Click);
            // 
            // custmer_text
            // 
            this.custmer_text.DataSource = this.customerBindingSource;
            this.custmer_text.DisplayMember = "Clent_n";
            this.custmer_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.custmer_text.FormattingEnabled = true;
            this.custmer_text.Location = new System.Drawing.Point(72, 15);
            this.custmer_text.Name = "custmer_text";
            this.custmer_text.Size = new System.Drawing.Size(318, 20);
            this.custmer_text.TabIndex = 15;
            this.custmer_text.ValueMember = "Clent_n";
            this.custmer_text.SelectedIndexChanged += new System.EventHandler(this.custmer_text_TextChanged);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(InvoiceConversion.Data.Customer);
            // 
            // invoiceNmber_text
            // 
            this.invoiceNmber_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceNmber_text.Location = new System.Drawing.Point(72, 86);
            this.invoiceNmber_text.Name = "invoiceNmber_text";
            this.invoiceNmber_text.Size = new System.Drawing.Size(137, 21);
            this.invoiceNmber_text.TabIndex = 14;
            this.invoiceNmber_text.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "發票編號";
            this.label6.Visible = false;
            // 
            // manageBut
            // 
            this.manageBut.Location = new System.Drawing.Point(649, 45);
            this.manageBut.Name = "manageBut";
            this.manageBut.Size = new System.Drawing.Size(75, 23);
            this.manageBut.TabIndex = 11;
            this.manageBut.Text = "管理標題";
            this.manageBut.UseVisualStyleBackColor = true;
            this.manageBut.Click += new System.EventHandler(this.manageBut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "發票標題";
            // 
            // title_combox
            // 
            this.title_combox.DataSource = this.invoiceTitelBindingSource;
            this.title_combox.DisplayMember = "Company_name";
            this.title_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.title_combox.FormattingEnabled = true;
            this.title_combox.Location = new System.Drawing.Point(451, 46);
            this.title_combox.Name = "title_combox";
            this.title_combox.Size = new System.Drawing.Size(192, 20);
            this.title_combox.TabIndex = 9;
            this.title_combox.ValueMember = "Company_id";
            // 
            // invoiceTitelBindingSource
            // 
            this.invoiceTitelBindingSource.DataSource = typeof(InvoiceConversion.Data.InvoiceTitel);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(590, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 21);
            this.textBox2.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textBox2, "折扣輸入提示\r\n例如：9.5折輸入95");
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // msleBut
            // 
            this.msleBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msleBut.Location = new System.Drawing.Point(675, 84);
            this.msleBut.Name = "msleBut";
            this.msleBut.Size = new System.Drawing.Size(49, 23);
            this.msleBut.TabIndex = 7;
            this.msleBut.Text = "修改";
            this.msleBut.UseVisualStyleBackColor = true;
            this.msleBut.Click += new System.EventHandler(this.msleBut_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/M/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(244, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 21);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd/M/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 21);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "折扣";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期範圍";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客戶名稱";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "備註";
            // 
            // reme
            // 
            this.reme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reme.Location = new System.Drawing.Point(47, 287);
            this.reme.Multiline = true;
            this.reme.Name = "reme";
            this.reme.Size = new System.Drawing.Size(561, 53);
            this.reme.TabIndex = 16;
            // 
            // SaveBut
            // 
            this.SaveBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBut.Location = new System.Drawing.Point(643, 290);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(84, 50);
            this.SaveBut.TabIndex = 12;
            this.SaveBut.Text = "生成發票(&N)";
            this.SaveBut.UseVisualStyleBackColor = true;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(0, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isdelete,
            this.aInvoiceidDataGridViewTextBoxColumn,
            this.Item_name,
            this.itemidDataGridViewTextBoxColumn,
            this.rpiceDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.Remake,
            this.Invoice_nmber});
            this.dataGridView1.DataSource = this.invoicedetailBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(734, 142);
            this.dataGridView1.TabIndex = 0;
            // 
            // isdelete
            // 
            this.isdelete.DataPropertyName = "Isdelete";
            this.isdelete.HeaderText = "選擇";
            this.isdelete.Name = "isdelete";
            // 
            // aInvoiceidDataGridViewTextBoxColumn
            // 
            this.aInvoiceidDataGridViewTextBoxColumn.DataPropertyName = "Item_id";
            this.aInvoiceidDataGridViewTextBoxColumn.HeaderText = "物品編號";
            this.aInvoiceidDataGridViewTextBoxColumn.Name = "aInvoiceidDataGridViewTextBoxColumn";
            this.aInvoiceidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Item_name
            // 
            this.Item_name.DataPropertyName = "Item_name";
            this.Item_name.HeaderText = "物品名稱";
            this.Item_name.Name = "Item_name";
            this.Item_name.ReadOnly = true;
            this.Item_name.Width = 300;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "AInvoice_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "订单号";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Visible = false;
            // 
            // rpiceDataGridViewTextBoxColumn
            // 
            this.rpiceDataGridViewTextBoxColumn.DataPropertyName = "Rpice";
            this.rpiceDataGridViewTextBoxColumn.HeaderText = "單價";
            this.rpiceDataGridViewTextBoxColumn.Name = "rpiceDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "單位";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "數量";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Remake
            // 
            this.Remake.DataPropertyName = "Remake";
            this.Remake.HeaderText = "備註";
            this.Remake.Name = "Remake";
            // 
            // Invoice_nmber
            // 
            this.Invoice_nmber.DataPropertyName = "Invoice_nmber";
            this.Invoice_nmber.HeaderText = "Invoice_nmber";
            this.Invoice_nmber.Name = "Invoice_nmber";
            this.Invoice_nmber.ReadOnly = true;
            this.Invoice_nmber.Visible = false;
            // 
            // invoicedetailBindingSource
            // 
            this.invoicedetailBindingSource.DataSource = typeof(InvoiceConversion.Data.Invoice_detail);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // InCoFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 357);
            this.Controls.Add(this.reme);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.groupBox1);
            this.Name = "InCoFm";
            this.ShowIcon = false;
            this.Text = "創建發票";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InCoFm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceTitelBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicedetailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button msleBut;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox title_combox;
        private System.Windows.Forms.Button manageBut;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.BindingSource invoicedetailBindingSource;
        private System.Windows.Forms.TextBox invoiceNmber_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox custmer_text;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource invoiceTitelBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox reme;
        private System.Windows.Forms.BindingSource invoicemasterBindingSource;
        private System.Windows.Forms.Button printBut;
        private System.Windows.Forms.Button edit_but;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn aInvoiceidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remake;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_nmber;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selcu;
    }
}