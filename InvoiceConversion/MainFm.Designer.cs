namespace InvoiceConversion
{
    partial class MainFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.invoiceMe = new System.Windows.Forms.ToolStripMenuItem();
            this.colseMe = new System.Windows.Forms.ToolStripMenuItem();
            this.printMe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(531, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceMe,
            this.printMe,
            this.colseMe});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Text = "主菜單";
            // 
            // invoiceMe
            // 
            this.invoiceMe.Name = "invoiceMe";
            this.invoiceMe.Size = new System.Drawing.Size(152, 22);
            this.invoiceMe.Text = "報表";
            this.invoiceMe.Click += new System.EventHandler(this.invoiceMe_Click);
            // 
            // colseMe
            // 
            this.colseMe.Name = "colseMe";
            this.colseMe.Size = new System.Drawing.Size(152, 22);
            this.colseMe.Text = "退出";
            this.colseMe.Click += new System.EventHandler(this.colseMe_Click);
            // 
            // printMe
            // 
            this.printMe.Name = "printMe";
            this.printMe.Size = new System.Drawing.Size(152, 22);
            this.printMe.Text = "列印";
            this.printMe.Click += new System.EventHandler(this.printMe_Click);
            // 
            // MainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 347);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainFm";
            this.ShowIcon = false;
            this.Text = "报表工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem invoiceMe;
        private System.Windows.Forms.ToolStripMenuItem colseMe;
        private System.Windows.Forms.ToolStripMenuItem printMe;
    }
}

