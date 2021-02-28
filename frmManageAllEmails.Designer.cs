
namespace QuoteSwift
{
    partial class FrmManageAllEmails
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
            this.msManageEmailAddressesControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvEmails = new System.Windows.Forms.DataGridView();
            this.clmEmailAddresses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.BtnChangeAddressInfo = new System.Windows.Forms.Button();
            this.msManageEmailAddressesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // msManageEmailAddressesControls
            // 
            this.msManageEmailAddressesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msManageEmailAddressesControls.Location = new System.Drawing.Point(0, 0);
            this.msManageEmailAddressesControls.Name = "msManageEmailAddressesControls";
            this.msManageEmailAddressesControls.Size = new System.Drawing.Size(415, 24);
            this.msManageEmailAddressesControls.TabIndex = 0;
            this.msManageEmailAddressesControls.Text = "msManageEmailAddressesControls";
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
            // DgvEmails
            // 
            this.DgvEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmailAddresses});
            this.DgvEmails.Location = new System.Drawing.Point(12, 56);
            this.DgvEmails.Name = "DgvEmails";
            this.DgvEmails.Size = new System.Drawing.Size(391, 168);
            this.DgvEmails.TabIndex = 1;
            // 
            // clmEmailAddresses
            // 
            this.clmEmailAddresses.HeaderText = "Email Address";
            this.clmEmailAddresses.Name = "clmEmailAddresses";
            this.clmEmailAddresses.ReadOnly = true;
            this.clmEmailAddresses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEmailAddresses.Width = 300;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(12, 230);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAddress.Location = new System.Drawing.Point(247, 230);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(156, 23);
            this.btnRemoveAddress.TabIndex = 5;
            this.btnRemoveAddress.Text = "Remove Selected Email";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.BtnRemoveAddress_Click);
            // 
            // BtnChangeAddressInfo
            // 
            this.BtnChangeAddressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChangeAddressInfo.Location = new System.Drawing.Point(247, 27);
            this.BtnChangeAddressInfo.Name = "BtnChangeAddressInfo";
            this.BtnChangeAddressInfo.Size = new System.Drawing.Size(156, 23);
            this.BtnChangeAddressInfo.TabIndex = 6;
            this.BtnChangeAddressInfo.Text = "Update Selected Email";
            this.BtnChangeAddressInfo.UseVisualStyleBackColor = true;
            this.BtnChangeAddressInfo.Click += new System.EventHandler(this.BtnChangeAddressInfo_Click);
            // 
            // FrmManageAllEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 259);
            this.Controls.Add(this.BtnChangeAddressInfo);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DgvEmails);
            this.Controls.Add(this.msManageEmailAddressesControls);
            this.MainMenuStrip = this.msManageEmailAddressesControls;
            this.Name = "FrmManageAllEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Managing < Business Name > Email Addresses";
            this.Load += new System.EventHandler(this.FrmManageAllEmails_Load);
            this.msManageEmailAddressesControls.ResumeLayout(false);
            this.msManageEmailAddressesControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msManageEmailAddressesControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvEmails;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.Button BtnChangeAddressInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmailAddresses;
    }
}