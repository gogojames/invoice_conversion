namespace InvoiceConversion
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SaveBut = new System.Windows.Forms.Button();
            this.invoicemasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aInvoiceidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rpiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicedetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceTitelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicedetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            // custmer_text
            // 
            this.custmer_text.DataSource = this.customerBindingSource;
            this.custmer_text.DisplayMember = "Clent_n";
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
            this.invoiceNmber_text.Location = new System.Drawing.Point(446, 86);
            this.invoiceNmber_text.Name = "invoiceNmber_text";
            this.invoiceNmber_text.Size = new System.Drawing.Size(90, 21);
            this.invoiceNmber_text.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "發票編號";
            // 
            // manageBut
            // 
            this.manageBut.Location = new System.Drawing.Point(689, 13);
            this.manageBut.Name = "manageBut";
            this.manageBut.Size = new System.Drawing.Size(35, 23);
            this.manageBut.TabIndex = 11;
            this.manageBut.Text = "...";
            this.manageBut.UseVisualStyleBackColor = true;
            this.manageBut.Click += new System.EventHandler(this.manageBut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "發票標題";
            // 
            // title_combox
            // 
            this.title_combox.DataSource = this.invoiceTitelBindingSource;
            this.title_combox.DisplayMember = "Company_name";
            this.title_combox.FormattingEnabled = true;
            this.title_combox.Location = new System.Drawing.Point(469, 16);
            this.title_combox.Name = "title_combox";
            this.title_combox.Size = new System.Drawing.Size(214, 20);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(244, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 21);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 21);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
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
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期";
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(47, 287);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 53);
            this.textBox1.TabIndex = 16;
            // 
            // SaveBut
            // 
            this.SaveBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBut.Location = new System.Drawing.Point(656, 290);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(71, 50);
            this.SaveBut.TabIndex = 12;
            this.SaveBut.Text = "生成發票";
            this.SaveBut.UseVisualStyleBackColor = true;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // invoicemasterBindingSource
            // 
            this.invoicemasterBindingSource.DataSource = typeof(InvoiceConversion.Data.Invoice_master);
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
            this.aInvoiceidDataGridViewTextBoxColumn,
            this.Item_name,
            this.itemidDataGridViewTextBoxColumn,
            this.rpiceDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.Remake});
            this.dataGridView1.DataSource = this.invoicedetailBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(734, 142);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // invoicedetailBindingSource
            // 
            this.invoicedetailBindingSource.DataSource = typeof(InvoiceConversion.Data.Invoice_detail);
            // 
            // InCoFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 357);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.groupBox1);
            this.Name = "InCoFm";
            this.ShowIcon = false;
            this.Text = "發票";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceTitelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource invoicemasterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn aInvoiceidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rpiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remake;
    }
}