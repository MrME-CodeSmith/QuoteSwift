
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateNewQuote = new System.Windows.Forms.Button();
            this.btnViewSelectedQuote = new System.Windows.Forms.Button();
            this.btnCreateNewQuoteOnSelection = new System.Windows.Forms.Button();
            this.dgvPreviousQuotes = new System.Windows.Forms.DataGridView();
            this.msQuoteControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviousQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // msQuoteControls
            // 
            this.msQuoteControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msQuoteControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msQuoteControls.Location = new System.Drawing.Point(0, 0);
            this.msQuoteControls.Name = "msQuoteControls";
            this.msQuoteControls.Size = new System.Drawing.Size(684, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageBusinessesToolStripMenuItem
            // 
            this.manageBusinessesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBusinessToolStripMenuItem,
            this.ViewAllBusinessesToolStripMenuItem});
            this.manageBusinessesToolStripMenuItem.Name = "manageBusinessesToolStripMenuItem";
            this.manageBusinessesToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.manageBusinessesToolStripMenuItem.Text = "Manage Businesses";
            // 
            // addNewBusinessToolStripMenuItem
            // 
            this.addNewBusinessToolStripMenuItem.Name = "addNewBusinessToolStripMenuItem";
            this.addNewBusinessToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.addNewBusinessToolStripMenuItem.Text = "Add New Business";
            // 
            // ViewAllBusinessesToolStripMenuItem
            // 
            this.ViewAllBusinessesToolStripMenuItem.Name = "ViewAllBusinessesToolStripMenuItem";
            this.ViewAllBusinessesToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.ViewAllBusinessesToolStripMenuItem.Text = "View All Businesses";
            // 
            // manageCustomersToolStripMenuItem
            // 
            this.manageCustomersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCustomerToolStripMenuItem,
            this.viewAllCustomersToolStripMenuItem});
            this.manageCustomersToolStripMenuItem.Name = "manageCustomersToolStripMenuItem";
            this.manageCustomersToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.manageCustomersToolStripMenuItem.Text = "Manage Customers";
            // 
            // addNewCustomerToolStripMenuItem
            // 
            this.addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            this.addNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.addNewCustomerToolStripMenuItem.Text = "Add New Customer";
            // 
            // viewAllCustomersToolStripMenuItem
            // 
            this.viewAllCustomersToolStripMenuItem.Name = "viewAllCustomersToolStripMenuItem";
            this.viewAllCustomersToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.viewAllCustomersToolStripMenuItem.Text = "View All Customers";
            // 
            // managePumpsToolStripMenuItem
            // 
            this.managePumpsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPumpToolStripMenuItem,
            this.viewAllPumpsToolStripMenuItem});
            this.managePumpsToolStripMenuItem.Name = "managePumpsToolStripMenuItem";
            this.managePumpsToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.managePumpsToolStripMenuItem.Text = "Manage Pumps";
            // 
            // createNewPumpToolStripMenuItem
            // 
            this.createNewPumpToolStripMenuItem.Name = "createNewPumpToolStripMenuItem";
            this.createNewPumpToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.createNewPumpToolStripMenuItem.Text = "Create New Pump";
            // 
            // viewAllPumpsToolStripMenuItem
            // 
            this.viewAllPumpsToolStripMenuItem.Name = "viewAllPumpsToolStripMenuItem";
            this.viewAllPumpsToolStripMenuItem.Size = new System.Drawing.Size(197, 24);
            this.viewAllPumpsToolStripMenuItem.Text = "View All Pumps";
            // 
            // managePumpPartsToolStripMenuItem
            // 
            this.managePumpPartsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPartToolStripMenuItem,
            this.viewAllPartsToolStripMenuItem});
            this.managePumpPartsToolStripMenuItem.Name = "managePumpPartsToolStripMenuItem";
            this.managePumpPartsToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.managePumpPartsToolStripMenuItem.Text = "Manage Pump Parts";
            // 
            // addNewPartToolStripMenuItem
            // 
            this.addNewPartToolStripMenuItem.Name = "addNewPartToolStripMenuItem";
            this.addNewPartToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.addNewPartToolStripMenuItem.Text = "Add New Part";
            // 
            // viewAllPartsToolStripMenuItem
            // 
            this.viewAllPartsToolStripMenuItem.Name = "viewAllPartsToolStripMenuItem";
            this.viewAllPartsToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.viewAllPartsToolStripMenuItem.Text = "View All Parts";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // btnCreateNewQuote
            // 
            this.btnCreateNewQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewQuote.Location = new System.Drawing.Point(12, 43);
            this.btnCreateNewQuote.Name = "btnCreateNewQuote";
            this.btnCreateNewQuote.Size = new System.Drawing.Size(160, 35);
            this.btnCreateNewQuote.TabIndex = 2;
            this.btnCreateNewQuote.Text = "Create New Quote";
            this.btnCreateNewQuote.UseVisualStyleBackColor = true;
            // 
            // btnViewSelectedQuote
            // 
            this.btnViewSelectedQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSelectedQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSelectedQuote.Location = new System.Drawing.Point(512, 43);
            this.btnViewSelectedQuote.Name = "btnViewSelectedQuote";
            this.btnViewSelectedQuote.Size = new System.Drawing.Size(160, 35);
            this.btnViewSelectedQuote.TabIndex = 4;
            this.btnViewSelectedQuote.Text = "View Selected Quote";
            this.btnViewSelectedQuote.UseVisualStyleBackColor = true;
            // 
            // btnCreateNewQuoteOnSelection
            // 
            this.btnCreateNewQuoteOnSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewQuoteOnSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewQuoteOnSelection.Location = new System.Drawing.Point(431, 458);
            this.btnCreateNewQuoteOnSelection.Name = "btnCreateNewQuoteOnSelection";
            this.btnCreateNewQuoteOnSelection.Size = new System.Drawing.Size(241, 35);
            this.btnCreateNewQuoteOnSelection.TabIndex = 5;
            this.btnCreateNewQuoteOnSelection.Text = "Create New Quote On Selection";
            this.btnCreateNewQuoteOnSelection.UseVisualStyleBackColor = true;
            // 
            // dgvPreviousQuotes
            // 
            this.dgvPreviousQuotes.AccessibleName = "Table";
            this.dgvPreviousQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreviousQuotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPreviousQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dgvPreviousQuotes.Location = new System.Drawing.Point(12, 84);
            this.dgvPreviousQuotes.Name = "dgvPreviousQuotes";
            this.dgvPreviousQuotes.Size = new System.Drawing.Size(659, 368);
            this.dgvPreviousQuotes.AllowUserToAddRows = false;
            this.dgvPreviousQuotes.AllowUserToDeleteRows = false;
            this.dgvPreviousQuotes.ReadOnly = true;
            this.dgvPreviousQuotes.TabIndex = 6;
            this.dgvPreviousQuotes.Text = "Previous Quotes";
            // 
            // FrmViewQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 505);
            this.Controls.Add(this.dgvPreviousQuotes);
            this.Controls.Add(this.btnCreateNewQuoteOnSelection);
            this.Controls.Add(this.btnViewSelectedQuote);
            this.Controls.Add(this.btnCreateNewQuote);
            this.Controls.Add(this.msQuoteControls);
            this.MainMenuStrip = this.msQuoteControls;
            this.Name = "FrmViewQuotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewing All Previous Quotes";
            this.Activated += new System.EventHandler(this.FrmViewQuotes_Activated);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnCreateNewQuote;
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
        private System.Windows.Forms.DataGridView dgvPreviousQuotes;
    }
}

