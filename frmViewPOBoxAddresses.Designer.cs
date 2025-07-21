
namespace QuoteSwift
{
    partial class FrmViewPOBoxAddresses
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPOBoxAddresses = new System.Windows.Forms.DataGridView();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnChangeAddressInfo = new System.Windows.Forms.Button();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSuburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msViewPOBoxAddressesControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOBoxAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // msViewPOBoxAddressesControles
            // 
            this.msViewPOBoxAddressesControles.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msViewPOBoxAddressesControles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.msViewPOBoxAddressesControles.Location = new System.Drawing.Point(0, 0);
            this.msViewPOBoxAddressesControles.Name = "msViewPOBoxAddressesControles";
            this.msViewPOBoxAddressesControles.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msViewPOBoxAddressesControles.Size = new System.Drawing.Size(826, 30);
            this.msViewPOBoxAddressesControles.TabIndex = 0;
            this.msViewPOBoxAddressesControles.Text = "msViewPOBoxAddressesControles";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // dgvPOBoxAddresses
            // 
            this.dgvPOBoxAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPOBoxAddresses.AutoGenerateColumns = false;
            this.dgvPOBoxAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPOBoxAddresses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPOBoxAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOBoxAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDescription,
            this.clmNumber,
            this.clmSuburb,
            this.clmCity,
            this.clmAreaCode});
            this.dgvPOBoxAddresses.Location = new System.Drawing.Point(18, 78);
            this.dgvPOBoxAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPOBoxAddresses.Name = "dgvPOBoxAddresses";
            this.dgvPOBoxAddresses.Size = new System.Drawing.Size(790, 230);
            this.dgvPOBoxAddresses.TabIndex = 1;
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAddress.Location = new System.Drawing.Point(574, 316);
            this.btnRemoveAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(234, 32);
            this.btnRemoveAddress.TabIndex = 2;
            this.btnRemoveAddress.Text = "Remove Selected Address";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.BtnRemoveAddress_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(18, 316);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnChangeAddressInfo
            // 
            this.BtnChangeAddressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChangeAddressInfo.Location = new System.Drawing.Point(574, 34);
            this.BtnChangeAddressInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnChangeAddressInfo.Name = "BtnChangeAddressInfo";
            this.BtnChangeAddressInfo.Size = new System.Drawing.Size(234, 32);
            this.BtnChangeAddressInfo.TabIndex = 5;
            this.BtnChangeAddressInfo.Text = "View Selected Address";
            this.BtnChangeAddressInfo.UseVisualStyleBackColor = true;
            this.BtnChangeAddressInfo.Click += new System.EventHandler(this.BtnChangeAddressInfo_Click);
            // 
            // clmDescription
            // 
            this.clmDescription.DataPropertyName = "AddressDescription";
            this.clmDescription.HeaderText = "Address Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.Width = 151;
            // 
            // clmNumber
            // 
            this.clmNumber.DataPropertyName = "AddressStreetNumber";
            this.clmNumber.HeaderText = "Street Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 118;
            // 
            // clmSuburb
            // 
            this.clmSuburb.DataPropertyName = "AddressSuburb";
            this.clmSuburb.HeaderText = "Suburb";
            this.clmSuburb.Name = "clmSuburb";
            this.clmSuburb.ReadOnly = true;
            this.clmSuburb.Width = 80;
            // 
            // clmCity
            // 
            this.clmCity.DataPropertyName = "AddressCity";
            this.clmCity.HeaderText = "City";
            this.clmCity.Name = "clmCity";
            this.clmCity.ReadOnly = true;
            this.clmCity.Width = 58;
            // 
            // clmAreaCode
            // 
            this.clmAreaCode.DataPropertyName = "AddressAreaCode";
            this.clmAreaCode.HeaderText = "Area Code";
            this.clmAreaCode.Name = "clmAreaCode";
            this.clmAreaCode.ReadOnly = true;
            this.clmAreaCode.Width = 95;
            // 
            // FrmViewPOBoxAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 363);
            this.Controls.Add(this.BtnChangeAddressInfo);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.dgvPOBoxAddresses);
            this.Controls.Add(this.msViewPOBoxAddressesControles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msViewPOBoxAddressesControles;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmViewPOBoxAddresses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing <<Business name>> P.O.Box Addresses";
            this.Load += new System.EventHandler(this.FrmViewPOBoxAddresses_Load);
            this.msViewPOBoxAddressesControles.ResumeLayout(false);
            this.msViewPOBoxAddressesControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOBoxAddresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msViewPOBoxAddressesControles;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvPOBoxAddresses;
        private System.Windows.Forms.Button btnRemoveAddress;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnChangeAddressInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSuburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaCode;
    }
}