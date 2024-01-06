
namespace QuoteSwift.Forms
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
            this.BtnUpdateAddress = new System.Windows.Forms.Button();
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
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.mssUpdateAddressControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBusinessAddressDescription
            // 
            this.lblBusinessAddressDescription.AutoSize = true;
            this.lblBusinessAddressDescription.Location = new System.Drawing.Point(38, 42);
            this.lblBusinessAddressDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessAddressDescription.Name = "lblBusinessAddressDescription";
            this.lblBusinessAddressDescription.Size = new System.Drawing.Size(87, 18);
            this.lblBusinessAddressDescription.TabIndex = 24;
            this.lblBusinessAddressDescription.Text = "Description:";
            // 
            // txtBusinessAddresssDescription
            // 
            this.txtBusinessAddresssDescription.Location = new System.Drawing.Point(133, 39);
            this.txtBusinessAddresssDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusinessAddresssDescription.Name = "txtBusinessAddresssDescription";
            this.txtBusinessAddresssDescription.Size = new System.Drawing.Size(372, 24);
            this.txtBusinessAddresssDescription.TabIndex = 0;
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(43, 200);
            this.lblAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(82, 18);
            this.lblAreaCode.TabIndex = 23;
            this.lblAreaCode.Text = "Area Code:";
            // 
            // BtnUpdateAddress
            // 
            this.BtnUpdateAddress.Location = new System.Drawing.Point(365, 248);
            this.BtnUpdateAddress.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpdateAddress.Name = "BtnUpdateAddress";
            this.BtnUpdateAddress.Size = new System.Drawing.Size(140, 32);
            this.BtnUpdateAddress.TabIndex = 6;
            this.BtnUpdateAddress.Text = "Update Address";
            this.BtnUpdateAddress.UseVisualStyleBackColor = true;
            this.BtnUpdateAddress.Click += new System.EventHandler(this.BtnUpdateAddress_Click);
            // 
            // mtxtAreaCode
            // 
            this.mtxtAreaCode.Location = new System.Drawing.Point(133, 199);
            this.mtxtAreaCode.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtAreaCode.Mask = "00000";
            this.mtxtAreaCode.Name = "mtxtAreaCode";
            this.mtxtAreaCode.Size = new System.Drawing.Size(72, 24);
            this.mtxtAreaCode.TabIndex = 5;
            this.mtxtAreaCode.ValidatingType = typeof(int);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(133, 167);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(372, 24);
            this.txtCity.TabIndex = 4;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(88, 168);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(37, 18);
            this.lblCity.TabIndex = 21;
            this.lblCity.Text = "City:";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(133, 135);
            this.txtSuburb.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(372, 24);
            this.txtSuburb.TabIndex = 3;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(66, 136);
            this.lblSuburb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(59, 18);
            this.lblSuburb.TabIndex = 18;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(30, 104);
            this.lblStreetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(95, 18);
            this.lblStreetName.TabIndex = 15;
            this.lblStreetName.Text = "Street Name:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(133, 103);
            this.txtStreetName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(372, 24);
            this.txtStreetName.TabIndex = 2;
            // 
            // mtxtStreetnumber
            // 
            this.mtxtStreetnumber.Culture = new System.Globalization.CultureInfo("en-029");
            this.mtxtStreetnumber.Location = new System.Drawing.Point(133, 71);
            this.mtxtStreetnumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtStreetnumber.Mask = "00000";
            this.mtxtStreetnumber.Name = "mtxtStreetnumber";
            this.mtxtStreetnumber.Size = new System.Drawing.Size(72, 24);
            this.mtxtStreetnumber.TabIndex = 1;
            this.mtxtStreetnumber.ValidatingType = typeof(int);
            // 
            // lblBusinessStreetNumber
            // 
            this.lblBusinessStreetNumber.AutoSize = true;
            this.lblBusinessStreetNumber.Location = new System.Drawing.Point(17, 72);
            this.lblBusinessStreetNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessStreetNumber.Name = "lblBusinessStreetNumber";
            this.lblBusinessStreetNumber.Size = new System.Drawing.Size(108, 18);
            this.lblBusinessStreetNumber.TabIndex = 12;
            this.lblBusinessStreetNumber.Text = "Street Number:";
            // 
            // mssUpdateAddressControls
            // 
            this.mssUpdateAddressControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.mssUpdateAddressControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.mssUpdateAddressControls.Location = new System.Drawing.Point(0, 0);
            this.mssUpdateAddressControls.Name = "mssUpdateAddressControls";
            this.mssUpdateAddressControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mssUpdateAddressControls.Size = new System.Drawing.Size(526, 30);
            this.mssUpdateAddressControls.TabIndex = 25;
            this.mssUpdateAddressControls.Text = "menuStrip1";
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
            this.BtnCancel.Location = new System.Drawing.Point(16, 246);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(114, 32);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmEditBusinessAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 292);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lblBusinessAddressDescription);
            this.Controls.Add(this.txtBusinessAddresssDescription);
            this.Controls.Add(this.lblAreaCode);
            this.Controls.Add(this.BtnUpdateAddress);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mssUpdateAddressControls;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button BtnUpdateAddress;
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
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button BtnCancel;
    }
}