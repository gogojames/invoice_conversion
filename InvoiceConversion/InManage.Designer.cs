namespace InvoiceConversion
{
    partial class InManage
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clientidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicenmberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicetitleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ainvoiceidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastupdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicemasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查詢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入關鍵詞";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientidDataGridViewTextBoxColumn,
            this.clientnameDataGridViewTextBoxColumn,
            this.invoicenmberDataGridViewTextBoxColumn,
            this.invoicetitleidDataGridViewTextBoxColumn,
            this.ainvoiceidDataGridViewTextBoxColumn,
            this.lastupdateDataGridViewTextBoxColumn,
            this.remakeDataGridViewTextBoxColumn,
            this.invoicedateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.invoicemasterBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(405, 258);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // clientidDataGridViewTextBoxColumn
            // 
            this.clientidDataGridViewTextBoxColumn.DataPropertyName = "Client_id";
            this.clientidDataGridViewTextBoxColumn.HeaderText = "Client_id";
            this.clientidDataGridViewTextBoxColumn.Name = "clientidDataGridViewTextBoxColumn";
            this.clientidDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientidDataGridViewTextBoxColumn.Visible = false;
            // 
            // clientnameDataGridViewTextBoxColumn
            // 
            this.clientnameDataGridViewTextBoxColumn.DataPropertyName = "Client_name";
            this.clientnameDataGridViewTextBoxColumn.HeaderText = "Client_name";
            this.clientnameDataGridViewTextBoxColumn.Name = "clientnameDataGridViewTextBoxColumn";
            this.clientnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientnameDataGridViewTextBoxColumn.Visible = false;
            // 
            // invoicenmberDataGridViewTextBoxColumn
            // 
            this.invoicenmberDataGridViewTextBoxColumn.DataPropertyName = "Invoice_nmber";
            this.invoicenmberDataGridViewTextBoxColumn.HeaderText = "發票編號";
            this.invoicenmberDataGridViewTextBoxColumn.Name = "invoicenmberDataGridViewTextBoxColumn";
            this.invoicenmberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoicetitleidDataGridViewTextBoxColumn
            // 
            this.invoicetitleidDataGridViewTextBoxColumn.DataPropertyName = "Invoice_title_id";
            this.invoicetitleidDataGridViewTextBoxColumn.HeaderText = "Invoice_title_id";
            this.invoicetitleidDataGridViewTextBoxColumn.Name = "invoicetitleidDataGridViewTextBoxColumn";
            this.invoicetitleidDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoicetitleidDataGridViewTextBoxColumn.Visible = false;
            // 
            // ainvoiceidDataGridViewTextBoxColumn
            // 
            this.ainvoiceidDataGridViewTextBoxColumn.DataPropertyName = "Ainvoice_id";
            this.ainvoiceidDataGridViewTextBoxColumn.HeaderText = "Ainvoice_id";
            this.ainvoiceidDataGridViewTextBoxColumn.Name = "ainvoiceidDataGridViewTextBoxColumn";
            this.ainvoiceidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ainvoiceidDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastupdateDataGridViewTextBoxColumn
            // 
            this.lastupdateDataGridViewTextBoxColumn.DataPropertyName = "Last_update";
            this.lastupdateDataGridViewTextBoxColumn.HeaderText = "發票日期";
            this.lastupdateDataGridViewTextBoxColumn.Name = "lastupdateDataGridViewTextBoxColumn";
            this.lastupdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remakeDataGridViewTextBoxColumn
            // 
            this.remakeDataGridViewTextBoxColumn.DataPropertyName = "Remake";
            this.remakeDataGridViewTextBoxColumn.HeaderText = "備註";
            this.remakeDataGridViewTextBoxColumn.Name = "remakeDataGridViewTextBoxColumn";
            this.remakeDataGridViewTextBoxColumn.ReadOnly = true;
            this.remakeDataGridViewTextBoxColumn.Width = 200;
            // 
            // invoicedateDataGridViewTextBoxColumn
            // 
            this.invoicedateDataGridViewTextBoxColumn.DataPropertyName = "Invoice_date";
            this.invoicedateDataGridViewTextBoxColumn.HeaderText = "Invoice_date";
            this.invoicedateDataGridViewTextBoxColumn.Name = "invoicedateDataGridViewTextBoxColumn";
            this.invoicedateDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoicedateDataGridViewTextBoxColumn.Visible = false;
            // 
            // invoicemasterBindingSource
            // 
            this.invoicemasterBindingSource.DataSource = typeof(InvoiceConversion.Data.Invoice_master);
            // 
            // InManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 353);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "InManage";
            this.Text = "發票列表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicemasterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource invoicemasterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicenmberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicetitleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ainvoiceidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastupdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remakeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicedateDataGridViewTextBoxColumn;
    }
}