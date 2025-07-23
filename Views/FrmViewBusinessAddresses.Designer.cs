
namespace QuoteSwift.Views
{
    partial class FrmViewBusinessAddresses
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
            this.DgvViewAllBusinessAddresses = new System.Windows.Forms.DataGridView();
            this.ClmAddressDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStreetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStreetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSuburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsViewAddressesControls = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRemoveSelected = new System.Windows.Forms.Button();
            this.BtnChangeAddressInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewAllBusinessAddresses)).BeginInit();
            this.MsViewAddressesControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvViewAllBusinessAddresses
            // 
            this.DgvViewAllBusinessAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvViewAllBusinessAddresses.AutoGenerateColumns = false;
            this.DgvViewAllBusinessAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvViewAllBusinessAddresses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvViewAllBusinessAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvViewAllBusinessAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmAddressDescription,
            this.ClmStreetNumber,
            this.ClmStreetName,
            this.ClmSuburb,
            this.ClmCity,
            this.ClmAreaCode});
            this.DgvViewAllBusinessAddresses.Location = new System.Drawing.Point(21, 78);
            this.DgvViewAllBusinessAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.DgvViewAllBusinessAddresses.Name = "DgvViewAllBusinessAddresses";
            this.DgvViewAllBusinessAddresses.Size = new System.Drawing.Size(788, 208);
            this.DgvViewAllBusinessAddresses.TabIndex = 0;
            // 
            // ClmAddressDescription
            // 
            this.ClmAddressDescription.DataPropertyName = "AddressDescription";
            this.ClmAddressDescription.HeaderText = "Address Description";
            this.ClmAddressDescription.Name = "ClmAddressDescription";
            this.ClmAddressDescription.ReadOnly = true;
            this.ClmAddressDescription.Width = 151;
            // 
            // ClmStreetNumber
            // 
            this.ClmStreetNumber.DataPropertyName = "AddressStreetNumber";
            this.ClmStreetNumber.HeaderText = "Street Number";
            this.ClmStreetNumber.Name = "ClmStreetNumber";
            this.ClmStreetNumber.ReadOnly = true;
            this.ClmStreetNumber.Width = 118;
            // 
            // ClmStreetName
            // 
            this.ClmStreetName.DataPropertyName = "AddressStreetName";
            this.ClmStreetName.HeaderText = "Street Name";
            this.ClmStreetName.Name = "ClmStreetName";
            this.ClmStreetName.ReadOnly = true;
            this.ClmStreetName.Width = 106;
            // 
            // ClmSuburb
            // 
            this.ClmSuburb.DataPropertyName = "AddressSuburb";
            this.ClmSuburb.HeaderText = "Suburb";
            this.ClmSuburb.Name = "ClmSuburb";
            this.ClmSuburb.ReadOnly = true;
            this.ClmSuburb.Width = 80;
            // 
            // ClmCity
            // 
            this.ClmCity.DataPropertyName = "AddressCity";
            this.ClmCity.HeaderText = "City";
            this.ClmCity.Name = "ClmCity";
            this.ClmCity.ReadOnly = true;
            this.ClmCity.Width = 58;
            // 
            // ClmAreaCode
            // 
            this.ClmAreaCode.DataPropertyName = "AddressAreaCode";
            this.ClmAreaCode.HeaderText = "Area Code";
            this.ClmAreaCode.Name = "ClmAreaCode";
            this.ClmAreaCode.ReadOnly = true;
            this.ClmAreaCode.Width = 95;
            // 
            // MsViewAddressesControls
            // 
            this.MsViewAddressesControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.MsViewAddressesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.MsViewAddressesControls.Location = new System.Drawing.Point(0, 0);
            this.MsViewAddressesControls.Name = "MsViewAddressesControls";
            this.MsViewAddressesControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MsViewAddressesControls.Size = new System.Drawing.Size(826, 30);
            this.MsViewAddressesControls.TabIndex = 1;
            this.MsViewAddressesControls.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(21, 294);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 32);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnRemoveSelected
            // 
            this.BtnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveSelected.Location = new System.Drawing.Point(574, 294);
            this.BtnRemoveSelected.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRemoveSelected.Name = "BtnRemoveSelected";
            this.BtnRemoveSelected.Size = new System.Drawing.Size(234, 32);
            this.BtnRemoveSelected.TabIndex = 3;
            this.BtnRemoveSelected.Text = "Remove Selected Address";
            this.BtnRemoveSelected.UseVisualStyleBackColor = true;
            // 
            // BtnChangeAddressInfo
            // 
            this.BtnChangeAddressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChangeAddressInfo.Location = new System.Drawing.Point(574, 37);
            this.BtnChangeAddressInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnChangeAddressInfo.Name = "BtnChangeAddressInfo";
            this.BtnChangeAddressInfo.Size = new System.Drawing.Size(234, 32);
            this.BtnChangeAddressInfo.TabIndex = 4;
            this.BtnChangeAddressInfo.Text = "Update Selected Address";
            this.BtnChangeAddressInfo.UseVisualStyleBackColor = true;
            this.BtnChangeAddressInfo.Click += new System.EventHandler(this.BtnChangeAddressInfo_Click);
            // 
            // FrmViewBusinessAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 334);
            this.Controls.Add(this.BtnChangeAddressInfo);
            this.Controls.Add(this.BtnRemoveSelected);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DgvViewAllBusinessAddresses);
            this.Controls.Add(this.MsViewAddressesControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MsViewAddressesControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmViewBusinessAddresses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Viewing <<Business name>> Addresses";
            this.Load += new System.EventHandler(this.FrmViewBusinessAddresses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewAllBusinessAddresses)).EndInit();
            this.MsViewAddressesControls.ResumeLayout(false);
            this.MsViewAddressesControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvViewAllBusinessAddresses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAddressDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStreetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStreetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSuburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAreaCode;
        private System.Windows.Forms.MenuStrip MsViewAddressesControls;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnRemoveSelected;
        private System.Windows.Forms.Button BtnChangeAddressInfo;
    }
}