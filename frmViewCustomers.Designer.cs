
namespace QuoteSwift
{
    partial class frmViewCustomers
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
            this.msViewCustomersControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreviousQuoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateSelectedCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnRemoveSelectedCustomer = new System.Windows.Forms.Button();
            this.msViewCustomersControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewCustomersControls
            // 
            this.msViewCustomersControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewCustomersControls.Location = new System.Drawing.Point(0, 0);
            this.msViewCustomersControls.Name = "msViewCustomersControls";
            this.msViewCustomersControls.Size = new System.Drawing.Size(665, 24);
            this.msViewCustomersControls.TabIndex = 0;
            this.msViewCustomersControls.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "Help!";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCustomerName,
            this.clmCustomerCompanyName,
            this.clmPreviousQuoteDate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 213);
            this.dataGridView1.TabIndex = 1;
            // 
            // clmCustomerName
            // 
            this.clmCustomerName.HeaderText = "Customer Name";
            this.clmCustomerName.Name = "clmCustomerName";
            this.clmCustomerName.ReadOnly = true;
            this.clmCustomerName.Width = 200;
            // 
            // clmCustomerCompanyName
            // 
            this.clmCustomerCompanyName.HeaderText = "Customer Company Name";
            this.clmCustomerCompanyName.Name = "clmCustomerCompanyName";
            this.clmCustomerCompanyName.ReadOnly = true;
            this.clmCustomerCompanyName.Width = 200;
            // 
            // clmPreviousQuoteDate
            // 
            this.clmPreviousQuoteDate.HeaderText = "Previous Quote Date";
            this.clmPreviousQuoteDate.Name = "clmPreviousQuoteDate";
            this.clmPreviousQuoteDate.ReadOnly = true;
            this.clmPreviousQuoteDate.Width = 200;
            // 
            // btnUpdateSelectedCustomer
            // 
            this.btnUpdateSelectedCustomer.Location = new System.Drawing.Point(502, 277);
            this.btnUpdateSelectedCustomer.Name = "btnUpdateSelectedCustomer";
            this.btnUpdateSelectedCustomer.Size = new System.Drawing.Size(153, 23);
            this.btnUpdateSelectedCustomer.TabIndex = 3;
            this.btnUpdateSelectedCustomer.Text = "Update Selected Customer";
            this.btnUpdateSelectedCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedCustomer.Click += new System.EventHandler(this.btnUpdateSelectedCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(12, 27);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(82, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSelectedCustomer
            // 
            this.btnRemoveSelectedCustomer.Location = new System.Drawing.Point(502, 27);
            this.btnRemoveSelectedCustomer.Name = "btnRemoveSelectedCustomer";
            this.btnRemoveSelectedCustomer.Size = new System.Drawing.Size(153, 23);
            this.btnRemoveSelectedCustomer.TabIndex = 2;
            this.btnRemoveSelectedCustomer.Text = "Remove Selected Customer";
            this.btnRemoveSelectedCustomer.UseVisualStyleBackColor = true;
            // 
            // frmViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 308);
            this.Controls.Add(this.btnRemoveSelectedCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnUpdateSelectedCustomer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.msViewCustomersControls);
            this.MainMenuStrip = this.msViewCustomersControls;
            this.Name = "frmViewCustomers";
            this.Text = "111111111";
            this.msViewCustomersControls.ResumeLayout(false);
            this.msViewCustomersControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewCustomersControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPreviousQuoteDate;
        private System.Windows.Forms.Button btnUpdateSelectedCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnRemoveSelectedCustomer;
    }
}