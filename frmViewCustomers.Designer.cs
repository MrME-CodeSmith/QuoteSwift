
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvCustomerList = new System.Windows.Forms.DataGridView();
            this.btnUpdateSelectedCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnRemoveSelectedCustomer = new System.Windows.Forms.Button();
            this.cbBusinessSelection = new System.Windows.Forms.ComboBox();
            this.lblBusinessSelection = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.clmCustomerCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreviousQuoteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msViewCustomersControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewCustomersControls
            // 
            this.msViewCustomersControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msViewCustomersControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msViewCustomersControls.Location = new System.Drawing.Point(0, 0);
            this.msViewCustomersControls.Name = "msViewCustomersControls";
            this.msViewCustomersControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msViewCustomersControls.Size = new System.Drawing.Size(684, 30);
            this.msViewCustomersControls.TabIndex = 0;
            this.msViewCustomersControls.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
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
            this.clmCustomerCompanyName,
            this.clmPreviousQuoteDate});
            this.DgvCustomerList.Location = new System.Drawing.Point(18, 141);
            this.DgvCustomerList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvCustomerList.Name = "DgvCustomerList";
            this.DgvCustomerList.Size = new System.Drawing.Size(650, 310);
            this.DgvCustomerList.TabIndex = 1;
            // 
            // btnUpdateSelectedCustomer
            // 
            this.btnUpdateSelectedCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSelectedCustomer.Location = new System.Drawing.Point(436, 101);
            this.btnUpdateSelectedCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSelectedCustomer.Name = "btnUpdateSelectedCustomer";
            this.btnUpdateSelectedCustomer.Size = new System.Drawing.Size(232, 32);
            this.btnUpdateSelectedCustomer.TabIndex = 3;
            this.btnUpdateSelectedCustomer.Text = "View Selected Customer";
            this.btnUpdateSelectedCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedCustomer.Click += new System.EventHandler(this.BtnUpdateSelectedCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(18, 101);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(123, 32);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // btnRemoveSelectedCustomer
            // 
            this.btnRemoveSelectedCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelectedCustomer.Location = new System.Drawing.Point(436, 457);
            this.btnRemoveSelectedCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSelectedCustomer.Name = "btnRemoveSelectedCustomer";
            this.btnRemoveSelectedCustomer.Size = new System.Drawing.Size(230, 32);
            this.btnRemoveSelectedCustomer.TabIndex = 2;
            this.btnRemoveSelectedCustomer.Text = "Remove Selected Customer";
            this.btnRemoveSelectedCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedCustomer.Click += new System.EventHandler(this.BtnRemoveSelectedCustomer_Click);
            // 
            // cbBusinessSelection
            // 
            this.cbBusinessSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBusinessSelection.FormattingEnabled = true;
            this.cbBusinessSelection.Location = new System.Drawing.Point(197, 55);
            this.cbBusinessSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbBusinessSelection.Name = "cbBusinessSelection";
            this.cbBusinessSelection.Size = new System.Drawing.Size(258, 26);
            this.cbBusinessSelection.TabIndex = 4;
            this.cbBusinessSelection.SelectedIndexChanged += new System.EventHandler(this.CbBusinessSelection_SelectedIndexChanged);
            // 
            // lblBusinessSelection
            // 
            this.lblBusinessSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBusinessSelection.AutoSize = true;
            this.lblBusinessSelection.Location = new System.Drawing.Point(193, 33);
            this.lblBusinessSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessSelection.Name = "lblBusinessSelection";
            this.lblBusinessSelection.Size = new System.Drawing.Size(127, 18);
            this.lblBusinessSelection.TabIndex = 5;
            this.lblBusinessSelection.Text = "Customer List for:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 457);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // clmCustomerCompanyName
            // 
            this.clmCustomerCompanyName.DataPropertyName = "CustomerCompanyName";
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
            // FrmViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 505);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lblBusinessSelection);
            this.Controls.Add(this.cbBusinessSelection);
            this.Controls.Add(this.btnRemoveSelectedCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnUpdateSelectedCustomer);
            this.Controls.Add(this.DgvCustomerList);
            this.Controls.Add(this.msViewCustomersControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msViewCustomersControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvCustomerList;
        private System.Windows.Forms.Button btnUpdateSelectedCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnRemoveSelectedCustomer;
        private System.Windows.Forms.ComboBox cbBusinessSelection;
        private System.Windows.Forms.Label lblBusinessSelection;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPreviousQuoteDate;
    }
}