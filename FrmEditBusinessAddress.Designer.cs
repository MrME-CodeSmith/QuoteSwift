
namespace QuoteSwift
{
    partial class FrmEditBusinessAddress
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
            this.lblBusinessAddressDescription = new System.Windows.Forms.Label();
            this.txtBusinessAddresssDescription = new System.Windows.Forms.TextBox();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.mtxtAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.mtxtStreetnumber = new System.Windows.Forms.MaskedTextBox();
            this.lblBusinessStreetNumber = new System.Windows.Forms.Label();
            this.mssUpdateAddressControls = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.mssUpdateAddressControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBusinessAddressDescription
            // 
            this.lblBusinessAddressDescription.AutoSize = true;
            this.lblBusinessAddressDescription.Location = new System.Drawing.Point(25, 30);
            this.lblBusinessAddressDescription.Name = "lblBusinessAddressDescription";
            this.lblBusinessAddressDescription.Size = new System.Drawing.Size(63, 13);
            this.lblBusinessAddressDescription.TabIndex = 24;
            this.lblBusinessAddressDescription.Text = "Description:";
            // 
            // txtBusinessAddresssDescription
            // 
            this.txtBusinessAddresssDescription.Location = new System.Drawing.Point(94, 27);
            this.txtBusinessAddresssDescription.Name = "txtBusinessAddresssDescription";
            this.txtBusinessAddresssDescription.Size = new System.Drawing.Size(249, 20);
            this.txtBusinessAddresssDescription.TabIndex = 13;
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(28, 179);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(60, 13);
            this.lblAreaCode.TabIndex = 23;
            this.lblAreaCode.Text = "Area Code:";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(250, 210);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(93, 23);
            this.btnAddAddress.TabIndex = 22;
            this.btnAddAddress.Text = "Update Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.BtnAddAddress_Click);
            // 
            // mtxtAreaCode
            // 
            this.mtxtAreaCode.Location = new System.Drawing.Point(94, 176);
            this.mtxtAreaCode.Mask = "00000";
            this.mtxtAreaCode.Name = "mtxtAreaCode";
            this.mtxtAreaCode.Size = new System.Drawing.Size(49, 20);
            this.mtxtAreaCode.TabIndex = 20;
            this.mtxtAreaCode.ValidatingType = typeof(int);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(94, 146);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(249, 20);
            this.txtCity.TabIndex = 19;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(61, 149);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 21;
            this.lblCity.Text = "City:";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(94, 116);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(249, 20);
            this.txtSuburb.TabIndex = 17;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(44, 119);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblSuburb.TabIndex = 18;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(19, 89);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblStreetName.TabIndex = 15;
            this.lblStreetName.Text = "Street Name:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(94, 86);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(249, 20);
            this.txtStreetName.TabIndex = 16;
            // 
            // mtxtStreetnumber
            // 
            this.mtxtStreetnumber.Culture = new System.Globalization.CultureInfo("en-029");
            this.mtxtStreetnumber.Location = new System.Drawing.Point(94, 57);
            this.mtxtStreetnumber.Mask = "00000";
            this.mtxtStreetnumber.Name = "mtxtStreetnumber";
            this.mtxtStreetnumber.Size = new System.Drawing.Size(49, 20);
            this.mtxtStreetnumber.TabIndex = 14;
            this.mtxtStreetnumber.ValidatingType = typeof(int);
            // 
            // lblBusinessStreetNumber
            // 
            this.lblBusinessStreetNumber.AutoSize = true;
            this.lblBusinessStreetNumber.Location = new System.Drawing.Point(10, 59);
            this.lblBusinessStreetNumber.Name = "lblBusinessStreetNumber";
            this.lblBusinessStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblBusinessStreetNumber.TabIndex = 12;
            this.lblBusinessStreetNumber.Text = "Street Number:";
            // 
            // mssUpdateAddressControls
            // 
            this.mssUpdateAddressControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.mssUpdateAddressControls.Location = new System.Drawing.Point(0, 0);
            this.mssUpdateAddressControls.Name = "mssUpdateAddressControls";
            this.mssUpdateAddressControls.Size = new System.Drawing.Size(356, 24);
            this.mssUpdateAddressControls.TabIndex = 25;
            this.mssUpdateAddressControls.Text = "menuStrip1";
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
            this.BtnCancel.Location = new System.Drawing.Point(12, 210);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(76, 23);
            this.BtnCancel.TabIndex = 26;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmEditBusinessAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 244);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lblBusinessAddressDescription);
            this.Controls.Add(this.txtBusinessAddresssDescription);
            this.Controls.Add(this.lblAreaCode);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.mtxtAreaCode);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtSuburb);
            this.Controls.Add(this.lblSuburb);
            this.Controls.Add(this.lblStreetName);
            this.Controls.Add(this.txtStreetName);
            this.Controls.Add(this.mtxtStreetnumber);
            this.Controls.Add(this.lblBusinessStreetNumber);
            this.Controls.Add(this.mssUpdateAddressControls);
            this.MainMenuStrip = this.mssUpdateAddressControls;
            this.Name = "FrmEditBusinessAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Updating Address Details";
            this.Load += new System.EventHandler(this.FrmEditBusinessAddress_Load);
            this.mssUpdateAddressControls.ResumeLayout(false);
            this.mssUpdateAddressControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBusinessAddressDescription;
        private System.Windows.Forms.TextBox txtBusinessAddresssDescription;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.MaskedTextBox mtxtAreaCode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.MaskedTextBox mtxtStreetnumber;
        private System.Windows.Forms.Label lblBusinessStreetNumber;
        private System.Windows.Forms.MenuStrip mssUpdateAddressControls;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button BtnCancel;
    }
}