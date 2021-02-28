
namespace QuoteSwift
{
    partial class FrmViewCustomers
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
            this.DgvCustomerList = new System.Windows.Forms.DataGridView();
            this.clmCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreviousQuoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateSelectedCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnRemoveSelectedCustomer = new System.Windows.Forms.Button();
            this.cbBusinessSelection = new System.Windows.Forms.ComboBox();
            this.lblBusinessSelection = new System.Windows.Forms.Label();
            this.msViewCustomersControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomerList)).BeginInit();
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
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // DgvCustomerList
            // 
            this.DgvCustomerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCustomerName,
            this.clmCustomerCompanyName,
            this.clmPreviousQuoteDate});
            this.DgvCustomerList.Location = new System.Drawing.Point(12, 102);
            this.DgvCustomerList.Name = "DgvCustomerList";
            this.DgvCustomerList.Size = new System.Drawing.Size(643, 224);
            this.DgvCustomerList.TabIndex = 1;
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
            this.btnUpdateSelectedCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSelectedCustomer.Location = new System.Drawing.Point(500, 73);
            this.btnUpdateSelectedCustomer.Name = "btnUpdateSelectedCustomer";
            this.btnUpdateSelectedCustomer.Size = new System.Drawing.Size(155, 23);
            this.btnUpdateSelectedCustomer.TabIndex = 3;
            this.btnUpdateSelectedCustomer.Text = "View Selected Customer";
            this.btnUpdateSelectedCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedCustomer.Click += new System.EventHandler(this.BtnUpdateSelectedCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(12, 73);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(82, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // btnRemoveSelectedCustomer
            // 
            this.btnRemoveSelectedCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelectedCustomer.Location = new System.Drawing.Point(500, 330);
            this.btnRemoveSelectedCustomer.Name = "btnRemoveSelectedCustomer";
            this.btnRemoveSelectedCustomer.Size = new System.Drawing.Size(153, 23);
            this.btnRemoveSelectedCustomer.TabIndex = 2;
            this.btnRemoveSelectedCustomer.Text = "Remove Selected Customer";
            this.btnRemoveSelectedCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedCustomer.Click += new System.EventHandler(this.BtnRemoveSelectedCustomer_Click);
            // 
            // cbBusinessSelection
            // 
            this.cbBusinessSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBusinessSelection.FormattingEnabled = true;
            this.cbBusinessSelection.Location = new System.Drawing.Point(236, 40);
            this.cbBusinessSelection.Name = "cbBusinessSelection";
            this.cbBusinessSelection.Size = new System.Drawing.Size(173, 21);
            this.cbBusinessSelection.TabIndex = 4;
            // 
            // lblBusinessSelection
            // 
            this.lblBusinessSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBusinessSelection.AutoSize = true;
            this.lblBusinessSelection.Location = new System.Drawing.Point(233, 24);
            this.lblBusinessSelection.Name = "lblBusinessSelection";
            this.lblBusinessSelection.Size = new System.Drawing.Size(88, 13);
            this.lblBusinessSelection.TabIndex = 5;
            this.lblBusinessSelection.Text = "Customer List for:";
            // 
            // FrmViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 365);
            this.Controls.Add(this.lblBusinessSelection);
            this.Controls.Add(this.cbBusinessSelection);
            this.Controls.Add(this.btnRemoveSelectedCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnUpdateSelectedCustomer);
            this.Controls.Add(this.DgvCustomerList);
            this.Controls.Add(this.msViewCustomersControls);
            this.MainMenuStrip = this.msViewCustomersControls;
            this.Name = "FrmViewCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing All Customers";
            this.Load += new System.EventHandler(this.FrmViewCustomers_Load);
            this.msViewCustomersControls.ResumeLayout(false);
            this.msViewCustomersControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewCustomersControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvCustomerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPreviousQuoteDate;
        private System.Windows.Forms.Button btnUpdateSelectedCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnRemoveSelectedCustomer;
        private System.Windows.Forms.ComboBox cbBusinessSelection;
        private System.Windows.Forms.Label lblBusinessSelection;
    }
}