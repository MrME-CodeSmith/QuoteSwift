
namespace QuoteSwift
{
    partial class FrmViewQuotes
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
            this.msQuoteControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBusinessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBusinessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewAllBusinessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePumpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewPumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllPumpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePumpPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateNewQuote = new System.Windows.Forms.Button();
            this.dgvPreviousQuotes = new System.Windows.Forms.DataGridView();
            this.clmQuoteNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJobNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewSelectedQuote = new System.Windows.Forms.Button();
            this.btnCreateNewQuoteOnSelection = new System.Windows.Forms.Button();
            this.msQuoteControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviousQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // msQuoteControls
            // 
            this.msQuoteControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msQuoteControls.Location = new System.Drawing.Point(0, 0);
            this.msQuoteControls.Name = "msQuoteControls";
            this.msQuoteControls.Size = new System.Drawing.Size(568, 24);
            this.msQuoteControls.TabIndex = 1;
            this.msQuoteControls.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageBusinessesToolStripMenuItem,
            this.manageCustomersToolStripMenuItem,
            this.managePumpsToolStripMenuItem,
            this.managePumpPartsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageBusinessesToolStripMenuItem
            // 
            this.manageBusinessesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBusinessToolStripMenuItem,
            this.ViewAllBusinessesToolStripMenuItem});
            this.manageBusinessesToolStripMenuItem.Name = "manageBusinessesToolStripMenuItem";
            this.manageBusinessesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageBusinessesToolStripMenuItem.Text = "Manage Businesses";
            this.manageBusinessesToolStripMenuItem.Click += new System.EventHandler(this.ManageBusinessesToolStripMenuItem_Click);
            // 
            // addNewBusinessToolStripMenuItem
            // 
            this.addNewBusinessToolStripMenuItem.Name = "addNewBusinessToolStripMenuItem";
            this.addNewBusinessToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addNewBusinessToolStripMenuItem.Text = "Add New Business";
            this.addNewBusinessToolStripMenuItem.Click += new System.EventHandler(this.AddNewBusinessToolStripMenuItem_Click);
            // 
            // ViewAllBusinessesToolStripMenuItem
            // 
            this.ViewAllBusinessesToolStripMenuItem.Name = "ViewAllBusinessesToolStripMenuItem";
            this.ViewAllBusinessesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ViewAllBusinessesToolStripMenuItem.Text = "View All Businesses";
            this.ViewAllBusinessesToolStripMenuItem.Click += new System.EventHandler(this.ViewAllBusinessesToolStripMenuItem_Click);
            // 
            // manageCustomersToolStripMenuItem
            // 
            this.manageCustomersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCustomerToolStripMenuItem,
            this.viewAllCustomersToolStripMenuItem});
            this.manageCustomersToolStripMenuItem.Name = "manageCustomersToolStripMenuItem";
            this.manageCustomersToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageCustomersToolStripMenuItem.Text = "Manage Customers";
            this.manageCustomersToolStripMenuItem.Click += new System.EventHandler(this.ManageCustomersToolStripMenuItem_Click);
            // 
            // addNewCustomerToolStripMenuItem
            // 
            this.addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            this.addNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addNewCustomerToolStripMenuItem.Text = "Add New Customer";
            this.addNewCustomerToolStripMenuItem.Click += new System.EventHandler(this.AddNewCustomerToolStripMenuItem_Click);
            // 
            // viewAllCustomersToolStripMenuItem
            // 
            this.viewAllCustomersToolStripMenuItem.Name = "viewAllCustomersToolStripMenuItem";
            this.viewAllCustomersToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.viewAllCustomersToolStripMenuItem.Text = "View All Customers";
            this.viewAllCustomersToolStripMenuItem.Click += new System.EventHandler(this.ViewAllCustomersToolStripMenuItem_Click);
            // 
            // managePumpsToolStripMenuItem
            // 
            this.managePumpsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPumpToolStripMenuItem,
            this.viewAllPumpsToolStripMenuItem});
            this.managePumpsToolStripMenuItem.Name = "managePumpsToolStripMenuItem";
            this.managePumpsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.managePumpsToolStripMenuItem.Text = "Manage Pumps";
            this.managePumpsToolStripMenuItem.Click += new System.EventHandler(this.ManagePumpsToolStripMenuItem_Click);
            // 
            // createNewPumpToolStripMenuItem
            // 
            this.createNewPumpToolStripMenuItem.Name = "createNewPumpToolStripMenuItem";
            this.createNewPumpToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.createNewPumpToolStripMenuItem.Text = "Create New Pump";
            this.createNewPumpToolStripMenuItem.Click += new System.EventHandler(this.CreateNewPumpToolStripMenuItem_Click);
            // 
            // viewAllPumpsToolStripMenuItem
            // 
            this.viewAllPumpsToolStripMenuItem.Name = "viewAllPumpsToolStripMenuItem";
            this.viewAllPumpsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.viewAllPumpsToolStripMenuItem.Text = "View All Pumps";
            this.viewAllPumpsToolStripMenuItem.Click += new System.EventHandler(this.ViewAllPumpsToolStripMenuItem_Click);
            // 
            // managePumpPartsToolStripMenuItem
            // 
            this.managePumpPartsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPartToolStripMenuItem,
            this.viewAllPartsToolStripMenuItem});
            this.managePumpPartsToolStripMenuItem.Name = "managePumpPartsToolStripMenuItem";
            this.managePumpPartsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.managePumpPartsToolStripMenuItem.Text = "Manage Pump Parts";
            this.managePumpPartsToolStripMenuItem.Click += new System.EventHandler(this.ManagePumpPartsToolStripMenuItem_Click);
            // 
            // addNewPartToolStripMenuItem
            // 
            this.addNewPartToolStripMenuItem.Name = "addNewPartToolStripMenuItem";
            this.addNewPartToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addNewPartToolStripMenuItem.Text = "Add New Part";
            this.addNewPartToolStripMenuItem.Click += new System.EventHandler(this.AddNewPartToolStripMenuItem_Click);
            // 
            // viewAllPartsToolStripMenuItem
            // 
            this.viewAllPartsToolStripMenuItem.Name = "viewAllPartsToolStripMenuItem";
            this.viewAllPartsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.viewAllPartsToolStripMenuItem.Text = "View All Parts";
            this.viewAllPartsToolStripMenuItem.Click += new System.EventHandler(this.ViewAllPartsToolStripMenuItem_Click);
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
            // btnCreateNewQuote
            // 
            this.btnCreateNewQuote.Location = new System.Drawing.Point(12, 27);
            this.btnCreateNewQuote.Name = "btnCreateNewQuote";
            this.btnCreateNewQuote.Size = new System.Drawing.Size(120, 23);
            this.btnCreateNewQuote.TabIndex = 2;
            this.btnCreateNewQuote.Text = "Create New Quote";
            this.btnCreateNewQuote.UseVisualStyleBackColor = true;
            this.btnCreateNewQuote.Click += new System.EventHandler(this.BtnCreateNewQuote_Click);
            // 
            // dgvPreviousQuotes
            // 
            this.dgvPreviousQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreviousQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviousQuotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmQuoteNumber,
            this.clmCreationDate,
            this.clmExpiryDate,
            this.clmCustomer,
            this.clmJobNumber});
            this.dgvPreviousQuotes.Location = new System.Drawing.Point(12, 56);
            this.dgvPreviousQuotes.Name = "dgvPreviousQuotes";
            this.dgvPreviousQuotes.Size = new System.Drawing.Size(543, 293);
            this.dgvPreviousQuotes.TabIndex = 3;
            // 
            // clmQuoteNumber
            // 
            this.clmQuoteNumber.HeaderText = "Quote Number";
            this.clmQuoteNumber.Name = "clmQuoteNumber";
            this.clmQuoteNumber.ReadOnly = true;
            // 
            // clmCreationDate
            // 
            this.clmCreationDate.HeaderText = "Creation Date";
            this.clmCreationDate.Name = "clmCreationDate";
            this.clmCreationDate.ReadOnly = true;
            // 
            // clmExpiryDate
            // 
            this.clmExpiryDate.HeaderText = "Expiry Date";
            this.clmExpiryDate.Name = "clmExpiryDate";
            this.clmExpiryDate.ReadOnly = true;
            // 
            // clmCustomer
            // 
            this.clmCustomer.HeaderText = "Customer";
            this.clmCustomer.Name = "clmCustomer";
            this.clmCustomer.ReadOnly = true;
            // 
            // clmJobNumber
            // 
            this.clmJobNumber.HeaderText = "Job Number";
            this.clmJobNumber.Name = "clmJobNumber";
            this.clmJobNumber.ReadOnly = true;
            // 
            // btnViewSelectedQuote
            // 
            this.btnViewSelectedQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedQuote.Location = new System.Drawing.Point(435, 27);
            this.btnViewSelectedQuote.Name = "btnViewSelectedQuote";
            this.btnViewSelectedQuote.Size = new System.Drawing.Size(120, 23);
            this.btnViewSelectedQuote.TabIndex = 4;
            this.btnViewSelectedQuote.Text = "View Selected Quote";
            this.btnViewSelectedQuote.UseVisualStyleBackColor = true;
            this.btnViewSelectedQuote.Click += new System.EventHandler(this.BtnViewSelectedQuote_Click);
            // 
            // btnCreateNewQuoteOnSelection
            // 
            this.btnCreateNewQuoteOnSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewQuoteOnSelection.Location = new System.Drawing.Point(383, 355);
            this.btnCreateNewQuoteOnSelection.Name = "btnCreateNewQuoteOnSelection";
            this.btnCreateNewQuoteOnSelection.Size = new System.Drawing.Size(172, 23);
            this.btnCreateNewQuoteOnSelection.TabIndex = 5;
            this.btnCreateNewQuoteOnSelection.Text = "Create New Quote On Selection";
            this.btnCreateNewQuoteOnSelection.UseVisualStyleBackColor = true;
            this.btnCreateNewQuoteOnSelection.Click += new System.EventHandler(this.BtnCreateNewQuoteOnSelection_Click);
            // 
            // FrmViewQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 388);
            this.Controls.Add(this.btnCreateNewQuoteOnSelection);
            this.Controls.Add(this.btnViewSelectedQuote);
            this.Controls.Add(this.dgvPreviousQuotes);
            this.Controls.Add(this.btnCreateNewQuote);
            this.Controls.Add(this.msQuoteControls);
            this.MainMenuStrip = this.msQuoteControls;
            this.Name = "FrmViewQuotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewing All Previous Quotes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewQuotes_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewQuotes_Load);
            this.msQuoteControls.ResumeLayout(false);
            this.msQuoteControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviousQuotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msQuoteControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnCreateNewQuote;
        private System.Windows.Forms.DataGridView dgvPreviousQuotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuoteNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJobNumber;
        private System.Windows.Forms.Button btnViewSelectedQuote;
        private System.Windows.Forms.Button btnCreateNewQuoteOnSelection;
        private System.Windows.Forms.ToolStripMenuItem managePumpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewPumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllPumpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBusinessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewBusinessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewAllBusinessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePumpPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllPartsToolStripMenuItem;
    }
}

