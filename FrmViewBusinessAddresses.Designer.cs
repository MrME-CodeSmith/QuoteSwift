
namespace QuoteSwift
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.DgvViewAllBusinessAddresses.Location = new System.Drawing.Point(14, 56);
            this.DgvViewAllBusinessAddresses.Name = "DgvViewAllBusinessAddresses";
            this.DgvViewAllBusinessAddresses.Size = new System.Drawing.Size(525, 150);
            this.DgvViewAllBusinessAddresses.TabIndex = 0;
            // 
            // ClmAddressDescription
            // 
            this.ClmAddressDescription.HeaderText = "Address Description";
            this.ClmAddressDescription.Name = "ClmAddressDescription";
            this.ClmAddressDescription.ReadOnly = true;
            this.ClmAddressDescription.Width = 115;
            // 
            // ClmStreetNumber
            // 
            this.ClmStreetNumber.HeaderText = "Street Number";
            this.ClmStreetNumber.Name = "ClmStreetNumber";
            this.ClmStreetNumber.ReadOnly = true;
            this.ClmStreetNumber.Width = 92;
            // 
            // ClmStreetName
            // 
            this.ClmStreetName.HeaderText = "Street Name";
            this.ClmStreetName.Name = "ClmStreetName";
            this.ClmStreetName.ReadOnly = true;
            this.ClmStreetName.Width = 84;
            // 
            // ClmSuburb
            // 
            this.ClmSuburb.HeaderText = "Suburb";
            this.ClmSuburb.Name = "ClmSuburb";
            this.ClmSuburb.ReadOnly = true;
            this.ClmSuburb.Width = 66;
            // 
            // ClmCity
            // 
            this.ClmCity.HeaderText = "City";
            this.ClmCity.Name = "ClmCity";
            this.ClmCity.ReadOnly = true;
            this.ClmCity.Width = 49;
            // 
            // ClmAreaCode
            // 
            this.ClmAreaCode.HeaderText = "Area Code";
            this.ClmAreaCode.Name = "ClmAreaCode";
            this.ClmAreaCode.ReadOnly = true;
            this.ClmAreaCode.Width = 76;
            // 
            // MsViewAddressesControls
            // 
            this.MsViewAddressesControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.MsViewAddressesControls.Location = new System.Drawing.Point(0, 0);
            this.MsViewAddressesControls.Name = "MsViewAddressesControls";
            this.MsViewAddressesControls.Size = new System.Drawing.Size(551, 24);
            this.MsViewAddressesControls.TabIndex = 1;
            this.MsViewAddressesControls.Text = "menuStrip1";
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
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(14, 212);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnRemoveSelected
            // 
            this.BtnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveSelected.Location = new System.Drawing.Point(383, 212);
            this.BtnRemoveSelected.Name = "BtnRemoveSelected";
            this.BtnRemoveSelected.Size = new System.Drawing.Size(156, 23);
            this.BtnRemoveSelected.TabIndex = 3;
            this.BtnRemoveSelected.Text = "Remove Selected Address";
            this.BtnRemoveSelected.UseVisualStyleBackColor = true;
            this.BtnRemoveSelected.Click += new System.EventHandler(this.BtnRemoveSelected_Click);
            // 
            // BtnChangeAddressInfo
            // 
            this.BtnChangeAddressInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChangeAddressInfo.Location = new System.Drawing.Point(383, 27);
            this.BtnChangeAddressInfo.Name = "BtnChangeAddressInfo";
            this.BtnChangeAddressInfo.Size = new System.Drawing.Size(156, 23);
            this.BtnChangeAddressInfo.TabIndex = 4;
            this.BtnChangeAddressInfo.Text = "Update Selected Address";
            this.BtnChangeAddressInfo.UseVisualStyleBackColor = true;
            this.BtnChangeAddressInfo.Click += new System.EventHandler(this.BtnChangeAddressInfo_Click);
            // 
            // FrmViewBusinessAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 241);
            this.Controls.Add(this.BtnChangeAddressInfo);
            this.Controls.Add(this.BtnRemoveSelected);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.DgvViewAllBusinessAddresses);
            this.Controls.Add(this.MsViewAddressesControls);
            this.MainMenuStrip = this.MsViewAddressesControls;
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnRemoveSelected;
        private System.Windows.Forms.Button BtnChangeAddressInfo;
    }
}