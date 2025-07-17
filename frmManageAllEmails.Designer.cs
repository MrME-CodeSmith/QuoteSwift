
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvEmails = new System.Windows.Forms.DataGridView();
            this.clmEmailAddresses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.BtnChangeAddressInfo = new System.Windows.Forms.Button();
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.msManageEmailAddressesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // msManageEmailAddressesControls
            // 
            this.msManageEmailAddressesControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msManageEmailAddressesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msManageEmailAddressesControls.Location = new System.Drawing.Point(0, 0);
            this.msManageEmailAddressesControls.Name = "msManageEmailAddressesControls";
            this.msManageEmailAddressesControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msManageEmailAddressesControls.Size = new System.Drawing.Size(622, 30);
            this.msManageEmailAddressesControls.TabIndex = 0;
            this.msManageEmailAddressesControls.Text = "msManageEmailAddressesControls";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
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
            this.DgvEmails.Location = new System.Drawing.Point(18, 78);
            this.DgvEmails.Margin = new System.Windows.Forms.Padding(4);
            this.DgvEmails.Name = "DgvEmails";
            this.DgvEmails.Size = new System.Drawing.Size(586, 233);
            this.DgvEmails.TabIndex = 1;
            // 
            // clmEmailAddresses
            // 
            this.clmEmailAddresses.DataPropertyName = "Address";
            this.clmEmailAddresses.HeaderText = "Email Address";
            this.clmEmailAddresses.Name = "clmEmailAddresses";
            this.clmEmailAddresses.ReadOnly = true;
            this.clmEmailAddresses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmEmailAddresses.Width = 300;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 318);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAddress.Location = new System.Drawing.Point(370, 318);
            this.btnRemoveAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(234, 32);
            this.btnRemoveAddress.TabIndex = 5;
            this.btnRemoveAddress.Text = "Remove Selected Email";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.BtnRemoveAddress_Click);
            // 
            // BtnChangeAddressInfo
            //
            this.BtnChangeAddressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChangeAddressInfo.Location = new System.Drawing.Point(370, 37);
            this.BtnChangeAddressInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnChangeAddressInfo.Name = "BtnChangeAddressInfo";
            this.BtnChangeAddressInfo.Size = new System.Drawing.Size(234, 32);
            this.BtnChangeAddressInfo.TabIndex = 8;
            this.BtnChangeAddressInfo.Text = "Update Selected Email";
            this.BtnChangeAddressInfo.UseVisualStyleBackColor = true;
            this.BtnChangeAddressInfo.Click += new System.EventHandler(this.BtnChangeAddressInfo_Click);
            //
            // txtNewEmail
            //
            this.txtNewEmail.Location = new System.Drawing.Point(18, 37);
            this.txtNewEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(344, 24);
            this.txtNewEmail.TabIndex = 6;
            //
            // btnAddEmail
            //
            this.btnAddEmail.Location = new System.Drawing.Point(370, 75);
            this.btnAddEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(234, 32);
            this.btnAddEmail.TabIndex = 7;
            this.btnAddEmail.Text = "Add Email";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            this.btnAddEmail.Click += new System.EventHandler(this.BtnAddEmail_Click);
            // 
            // FrmManageAllEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 359);
            this.Controls.Add(this.btnAddEmail);
            this.Controls.Add(this.txtNewEmail);
            this.Controls.Add(this.BtnChangeAddressInfo);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DgvEmails);
            this.Controls.Add(this.msManageEmailAddressesControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msManageEmailAddressesControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView DgvEmails;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.Button BtnChangeAddressInfo;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Button btnAddEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmailAddresses;
    }
}