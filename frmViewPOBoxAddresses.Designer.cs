
namespace QuoteSwift
{
    partial class frmViewPOBoxAddresses
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
            this.msViewPOBoxAddressesControles = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPOBoxAddresses = new System.Windows.Forms.DataGridView();
            this.clmNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStreetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSuburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.msViewPOBoxAddressesControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOBoxAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewPOBoxAddressesControles
            // 
            this.msViewPOBoxAddressesControles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msViewPOBoxAddressesControles.Location = new System.Drawing.Point(0, 0);
            this.msViewPOBoxAddressesControles.Name = "msViewPOBoxAddressesControles";
            this.msViewPOBoxAddressesControles.Size = new System.Drawing.Size(967, 24);
            this.msViewPOBoxAddressesControles.TabIndex = 0;
            this.msViewPOBoxAddressesControles.Text = "msViewPOBoxAddressesControles";
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
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // dgvPOBoxAddresses
            // 
            this.dgvPOBoxAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPOBoxAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOBoxAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNumber,
            this.clmStreetName,
            this.clmSuburb,
            this.clmCity,
            this.clmAreaCode,
            this.clmDescription});
            this.dgvPOBoxAddresses.Location = new System.Drawing.Point(12, 27);
            this.dgvPOBoxAddresses.Name = "dgvPOBoxAddresses";
            this.dgvPOBoxAddresses.Size = new System.Drawing.Size(943, 150);
            this.dgvPOBoxAddresses.TabIndex = 1;
            // 
            // clmNumber
            // 
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            // 
            // clmStreetName
            // 
            this.clmStreetName.HeaderText = "Street Name";
            this.clmStreetName.Name = "clmStreetName";
            this.clmStreetName.ReadOnly = true;
            this.clmStreetName.Width = 150;
            // 
            // clmSuburb
            // 
            this.clmSuburb.HeaderText = "Suburb";
            this.clmSuburb.Name = "clmSuburb";
            this.clmSuburb.ReadOnly = true;
            this.clmSuburb.Width = 150;
            // 
            // clmCity
            // 
            this.clmCity.HeaderText = "City";
            this.clmCity.Name = "clmCity";
            this.clmCity.ReadOnly = true;
            this.clmCity.Width = 150;
            // 
            // clmAreaCode
            // 
            this.clmAreaCode.HeaderText = "Area Code";
            this.clmAreaCode.Name = "clmAreaCode";
            this.clmAreaCode.ReadOnly = true;
            // 
            // clmDescription
            // 
            this.clmDescription.HeaderText = "Address Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.Width = 250;
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAddress.Location = new System.Drawing.Point(849, 183);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveAddress.TabIndex = 2;
            this.btnRemoveAddress.Text = "Remove Address";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            // 
            // frmViewPOBoxAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 217);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.dgvPOBoxAddresses);
            this.Controls.Add(this.msViewPOBoxAddressesControles);
            this.MainMenuStrip = this.msViewPOBoxAddressesControles;
            this.Name = "frmViewPOBoxAddresses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmViewPOBoxAddresses";
            this.msViewPOBoxAddressesControles.ResumeLayout(false);
            this.msViewPOBoxAddressesControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOBoxAddresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewPOBoxAddressesControles;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvPOBoxAddresses;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStreetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSuburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.Button btnRemoveAddress;
    }
}