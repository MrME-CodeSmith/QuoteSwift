
namespace QuoteSwift.Forms
{
    partial class FrmAddBusiness
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
            this.msBusinessControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBusinessInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxBusinessInformation = new System.Windows.Forms.GroupBox();
            this.gbxLegalInformation = new System.Windows.Forms.GroupBox();
            this.mtxtRegistrationNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtVATNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.lblVATNumber = new System.Windows.Forms.Label();
            this.rtxtExtraInformation = new System.Windows.Forms.RichTextBox();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.lblExtraInformation = new System.Windows.Forms.Label();
            this.lblBusinessName = new System.Windows.Forms.Label();
            this.gbxPhoneRelated = new System.Windows.Forms.GroupBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.mtxtCellphoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelephoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.lblCellphoneNumber = new System.Windows.Forms.Label();
            this.lblTelephoneNumber = new System.Windows.Forms.Label();
            this.gbxBusinessAddress = new System.Windows.Forms.GroupBox();
            this.lblBusinessAddressDescription = new System.Windows.Forms.Label();
            this.txtBusinessAddresssDescription = new System.Windows.Forms.TextBox();
            this.btnViewAddresses = new System.Windows.Forms.Button();
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
            this.gbxEmailRelated = new System.Windows.Forms.GroupBox();
            this.btnViewEmailAddresses = new System.Windows.Forms.Button();
            this.mtxtEmail = new System.Windows.Forms.MaskedTextBox();
            this.btnAddBusinessEmail = new System.Windows.Forms.Button();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.gbxPOBoxAddress = new System.Windows.Forms.GroupBox();
            this.lblBusinessPODescription = new System.Windows.Forms.Label();
            this.btnViewAllPOBoxAddresses = new System.Windows.Forms.Button();
            this.txtBusinessPODescription = new System.Windows.Forms.TextBox();
            this.lblPOBoxAreaCode = new System.Windows.Forms.Label();
            this.btnAddPOBoxAddress = new System.Windows.Forms.Button();
            this.mtxtPOBoxAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.txtPOBoxCity = new System.Windows.Forms.TextBox();
            this.lblPOBoxCity = new System.Windows.Forms.Label();
            this.txtPOBoxSuburb = new System.Windows.Forms.TextBox();
            this.lblPOBoxSuburb = new System.Windows.Forms.Label();
            this.mtxtPOBoxStreetNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPOBoxStreetNumber = new System.Windows.Forms.Label();
            this.btnAddBusiness = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.msBusinessControls.SuspendLayout();
            this.gbxBusinessInformation.SuspendLayout();
            this.gbxLegalInformation.SuspendLayout();
            this.gbxPhoneRelated.SuspendLayout();
            this.gbxBusinessAddress.SuspendLayout();
            this.gbxEmailRelated.SuspendLayout();
            this.gbxPOBoxAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // msBusinessControls
            // 
            this.msBusinessControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msBusinessControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msBusinessControls.Location = new System.Drawing.Point(0, 0);
            this.msBusinessControls.Name = "msBusinessControls";
            this.msBusinessControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msBusinessControls.Size = new System.Drawing.Size(1101, 30);
            this.msBusinessControls.TabIndex = 0;
            this.msBusinessControls.Text = "msBusinessControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateBusinessInformationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updateBusinessInformationToolStripMenuItem
            // 
            this.updateBusinessInformationToolStripMenuItem.Enabled = false;
            this.updateBusinessInformationToolStripMenuItem.Name = "updateBusinessInformationToolStripMenuItem";
            this.updateBusinessInformationToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.updateBusinessInformationToolStripMenuItem.Text = "Update mBusiness Information";
            this.updateBusinessInformationToolStripMenuItem.Click += new System.EventHandler(this.UpdateBusinessInformationToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // gbxBusinessInformation
            // 
            this.gbxBusinessInformation.Controls.Add(this.gbxLegalInformation);
            this.gbxBusinessInformation.Controls.Add(this.rtxtExtraInformation);
            this.gbxBusinessInformation.Controls.Add(this.txtBusinessName);
            this.gbxBusinessInformation.Controls.Add(this.lblExtraInformation);
            this.gbxBusinessInformation.Controls.Add(this.lblBusinessName);
            this.gbxBusinessInformation.Location = new System.Drawing.Point(20, 39);
            this.gbxBusinessInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxBusinessInformation.Name = "gbxBusinessInformation";
            this.gbxBusinessInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxBusinessInformation.Size = new System.Drawing.Size(526, 252);
            this.gbxBusinessInformation.TabIndex = 1;
            this.gbxBusinessInformation.TabStop = false;
            this.gbxBusinessInformation.Text = "mBusiness Information:";
            // 
            // gbxLegalInformation
            // 
            this.gbxLegalInformation.Controls.Add(this.mtxtRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.mtxtVATNumber);
            this.gbxLegalInformation.Controls.Add(this.lblRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.lblVATNumber);
            this.gbxLegalInformation.Location = new System.Drawing.Point(10, 132);
            this.gbxLegalInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxLegalInformation.Name = "gbxLegalInformation";
            this.gbxLegalInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxLegalInformation.Size = new System.Drawing.Size(508, 104);
            this.gbxLegalInformation.TabIndex = 4;
            this.gbxLegalInformation.TabStop = false;
            this.gbxLegalInformation.Text = "Legal Information:";
            // 
            // mtxtRegistrationNumber
            // 
            this.mtxtRegistrationNumber.Location = new System.Drawing.Point(180, 67);
            this.mtxtRegistrationNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtRegistrationNumber.Name = "mtxtRegistrationNumber";
            this.mtxtRegistrationNumber.Size = new System.Drawing.Size(320, 24);
            this.mtxtRegistrationNumber.TabIndex = 3;
            // 
            // mtxtVATNumber
            // 
            this.mtxtVATNumber.Location = new System.Drawing.Point(180, 35);
            this.mtxtVATNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtVATNumber.Name = "mtxtVATNumber";
            this.mtxtVATNumber.Size = new System.Drawing.Size(320, 24);
            this.mtxtVATNumber.TabIndex = 2;
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.AutoSize = true;
            this.lblRegistrationNumber.Location = new System.Drawing.Point(24, 70);
            this.lblRegistrationNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(148, 18);
            this.lblRegistrationNumber.TabIndex = 1;
            this.lblRegistrationNumber.Text = "Registration Number:";
            // 
            // lblVATNumber
            // 
            this.lblVATNumber.AutoSize = true;
            this.lblVATNumber.Location = new System.Drawing.Point(76, 38);
            this.lblVATNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVATNumber.Name = "lblVATNumber";
            this.lblVATNumber.Size = new System.Drawing.Size(96, 18);
            this.lblVATNumber.TabIndex = 0;
            this.lblVATNumber.Text = "VAT Number:";
            // 
            // rtxtExtraInformation
            // 
            this.rtxtExtraInformation.Location = new System.Drawing.Point(160, 62);
            this.rtxtExtraInformation.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtExtraInformation.Name = "rtxtExtraInformation";
            this.rtxtExtraInformation.Size = new System.Drawing.Size(358, 62);
            this.rtxtExtraInformation.TabIndex = 1;
            this.rtxtExtraInformation.Text = "";
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(158, 30);
            this.txtBusinessName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(358, 24);
            this.txtBusinessName.TabIndex = 0;
            // 
            // lblExtraInformation
            // 
            this.lblExtraInformation.AutoSize = true;
            this.lblExtraInformation.Location = new System.Drawing.Point(28, 65);
            this.lblExtraInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraInformation.Name = "lblExtraInformation";
            this.lblExtraInformation.Size = new System.Drawing.Size(124, 18);
            this.lblExtraInformation.TabIndex = 1;
            this.lblExtraInformation.Text = "Extra Information:";
            // 
            // lblBusinessName
            // 
            this.lblBusinessName.AutoSize = true;
            this.lblBusinessName.Location = new System.Drawing.Point(35, 33);
            this.lblBusinessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessName.Name = "lblBusinessName";
            this.lblBusinessName.Size = new System.Drawing.Size(117, 18);
            this.lblBusinessName.TabIndex = 0;
            this.lblBusinessName.Text = "mBusiness Name:";
            this.lblBusinessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxPhoneRelated
            // 
            this.gbxPhoneRelated.Controls.Add(this.btnViewAll);
            this.gbxPhoneRelated.Controls.Add(this.mtxtCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.mtxtTelephoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.btnAddNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblTelephoneNumber);
            this.gbxPhoneRelated.Location = new System.Drawing.Point(555, 39);
            this.gbxPhoneRelated.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPhoneRelated.Name = "gbxPhoneRelated";
            this.gbxPhoneRelated.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPhoneRelated.Size = new System.Drawing.Size(526, 133);
            this.gbxPhoneRelated.TabIndex = 4;
            this.gbxPhoneRelated.TabStop = false;
            this.gbxPhoneRelated.Text = "Phone Related:";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(8, 94);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(153, 32);
            this.btnViewAll.TabIndex = 14;
            this.btnViewAll.Text = "View All Numbers";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // mtxtCellphoneNumber
            // 
            this.mtxtCellphoneNumber.Location = new System.Drawing.Point(162, 62);
            this.mtxtCellphoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtCellphoneNumber.Mask = "000-000-0000";
            this.mtxtCellphoneNumber.Name = "mtxtCellphoneNumber";
            this.mtxtCellphoneNumber.Size = new System.Drawing.Size(154, 24);
            this.mtxtCellphoneNumber.TabIndex = 13;
            // 
            // mtxtTelephoneNumber
            // 
            this.mtxtTelephoneNumber.Location = new System.Drawing.Point(162, 30);
            this.mtxtTelephoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtTelephoneNumber.Mask = "(999) 000-0000";
            this.mtxtTelephoneNumber.Name = "mtxtTelephoneNumber";
            this.mtxtTelephoneNumber.Size = new System.Drawing.Size(154, 24);
            this.mtxtTelephoneNumber.TabIndex = 12;
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(376, 94);
            this.btnAddNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(140, 32);
            this.btnAddNumber.TabIndex = 15;
            this.btnAddNumber.Text = "Add Number/s";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.BtnAddNumber_Click);
            // 
            // lblCellphoneNumber
            // 
            this.lblCellphoneNumber.AutoSize = true;
            this.lblCellphoneNumber.Location = new System.Drawing.Point(19, 65);
            this.lblCellphoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCellphoneNumber.Name = "lblCellphoneNumber";
            this.lblCellphoneNumber.Size = new System.Drawing.Size(135, 18);
            this.lblCellphoneNumber.TabIndex = 1;
            this.lblCellphoneNumber.Text = "Cellphone Number:";
            this.lblCellphoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Location = new System.Drawing.Point(16, 33);
            this.lblTelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(138, 18);
            this.lblTelephoneNumber.TabIndex = 0;
            this.lblTelephoneNumber.Text = "Telephone Number:";
            this.lblTelephoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxBusinessAddress
            // 
            this.gbxBusinessAddress.Controls.Add(this.lblBusinessAddressDescription);
            this.gbxBusinessAddress.Controls.Add(this.txtBusinessAddresssDescription);
            this.gbxBusinessAddress.Controls.Add(this.btnViewAddresses);
            this.gbxBusinessAddress.Controls.Add(this.lblAreaCode);
            this.gbxBusinessAddress.Controls.Add(this.btnAddAddress);
            this.gbxBusinessAddress.Controls.Add(this.mtxtAreaCode);
            this.gbxBusinessAddress.Controls.Add(this.txtCity);
            this.gbxBusinessAddress.Controls.Add(this.lblCity);
            this.gbxBusinessAddress.Controls.Add(this.txtSuburb);
            this.gbxBusinessAddress.Controls.Add(this.lblSuburb);
            this.gbxBusinessAddress.Controls.Add(this.lblStreetName);
            this.gbxBusinessAddress.Controls.Add(this.txtStreetName);
            this.gbxBusinessAddress.Controls.Add(this.mtxtStreetnumber);
            this.gbxBusinessAddress.Controls.Add(this.lblBusinessStreetNumber);
            this.gbxBusinessAddress.Location = new System.Drawing.Point(20, 299);
            this.gbxBusinessAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbxBusinessAddress.Name = "gbxBusinessAddress";
            this.gbxBusinessAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbxBusinessAddress.Size = new System.Drawing.Size(526, 283);
            this.gbxBusinessAddress.TabIndex = 5;
            this.gbxBusinessAddress.TabStop = false;
            this.gbxBusinessAddress.Text = "mBusiness Address:";
            // 
            // lblBusinessAddressDescription
            // 
            this.lblBusinessAddressDescription.AutoSize = true;
            this.lblBusinessAddressDescription.Location = new System.Drawing.Point(49, 29);
            this.lblBusinessAddressDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessAddressDescription.Name = "lblBusinessAddressDescription";
            this.lblBusinessAddressDescription.Size = new System.Drawing.Size(87, 18);
            this.lblBusinessAddressDescription.TabIndex = 11;
            this.lblBusinessAddressDescription.Text = "Description:";
            // 
            // txtBusinessAddresssDescription
            // 
            this.txtBusinessAddresssDescription.Location = new System.Drawing.Point(144, 26);
            this.txtBusinessAddresssDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusinessAddresssDescription.Name = "txtBusinessAddresssDescription";
            this.txtBusinessAddresssDescription.Size = new System.Drawing.Size(372, 24);
            this.txtBusinessAddresssDescription.TabIndex = 4;
            // 
            // btnViewAddresses
            // 
            this.btnViewAddresses.Location = new System.Drawing.Point(16, 231);
            this.btnViewAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAddresses.Name = "btnViewAddresses";
            this.btnViewAddresses.Size = new System.Drawing.Size(168, 32);
            this.btnViewAddresses.TabIndex = 10;
            this.btnViewAddresses.Text = "View All Addresses";
            this.btnViewAddresses.UseVisualStyleBackColor = true;
            this.btnViewAddresses.Click += new System.EventHandler(this.BtnViewAddresses_Click);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(54, 189);
            this.lblAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(82, 18);
            this.lblAreaCode.TabIndex = 9;
            this.lblAreaCode.Text = "Area Code:";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(376, 231);
            this.btnAddAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(140, 32);
            this.btnAddAddress.TabIndex = 11;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.BtnAddAddress_Click);
            // 
            // mtxtAreaCode
            // 
            this.mtxtAreaCode.Location = new System.Drawing.Point(144, 186);
            this.mtxtAreaCode.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtAreaCode.Mask = "00000";
            this.mtxtAreaCode.Name = "mtxtAreaCode";
            this.mtxtAreaCode.Size = new System.Drawing.Size(72, 24);
            this.mtxtAreaCode.TabIndex = 9;
            this.mtxtAreaCode.ValidatingType = typeof(int);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(144, 154);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(372, 24);
            this.txtCity.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(99, 157);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(37, 18);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "City:";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(144, 122);
            this.txtSuburb.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(372, 24);
            this.txtSuburb.TabIndex = 7;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(77, 125);
            this.lblSuburb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(59, 18);
            this.lblSuburb.TabIndex = 4;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(41, 93);
            this.lblStreetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(95, 18);
            this.lblStreetName.TabIndex = 3;
            this.lblStreetName.Text = "Street Name:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(144, 90);
            this.txtStreetName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(372, 24);
            this.txtStreetName.TabIndex = 6;
            // 
            // mtxtStreetnumber
            // 
            this.mtxtStreetnumber.Culture = new System.Globalization.CultureInfo("en-029");
            this.mtxtStreetnumber.Location = new System.Drawing.Point(144, 58);
            this.mtxtStreetnumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtStreetnumber.Mask = "00000";
            this.mtxtStreetnumber.Name = "mtxtStreetnumber";
            this.mtxtStreetnumber.Size = new System.Drawing.Size(72, 24);
            this.mtxtStreetnumber.TabIndex = 5;
            this.mtxtStreetnumber.ValidatingType = typeof(int);
            // 
            // lblBusinessStreetNumber
            // 
            this.lblBusinessStreetNumber.AutoSize = true;
            this.lblBusinessStreetNumber.Location = new System.Drawing.Point(28, 61);
            this.lblBusinessStreetNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessStreetNumber.Name = "lblBusinessStreetNumber";
            this.lblBusinessStreetNumber.Size = new System.Drawing.Size(108, 18);
            this.lblBusinessStreetNumber.TabIndex = 0;
            this.lblBusinessStreetNumber.Text = "Street Number:";
            // 
            // gbxEmailRelated
            // 
            this.gbxEmailRelated.Controls.Add(this.btnViewEmailAddresses);
            this.gbxEmailRelated.Controls.Add(this.mtxtEmail);
            this.gbxEmailRelated.Controls.Add(this.btnAddBusinessEmail);
            this.gbxEmailRelated.Controls.Add(this.lblEmailAddress);
            this.gbxEmailRelated.Location = new System.Drawing.Point(555, 180);
            this.gbxEmailRelated.Margin = new System.Windows.Forms.Padding(4);
            this.gbxEmailRelated.Name = "gbxEmailRelated";
            this.gbxEmailRelated.Padding = new System.Windows.Forms.Padding(4);
            this.gbxEmailRelated.Size = new System.Drawing.Size(528, 111);
            this.gbxEmailRelated.TabIndex = 5;
            this.gbxEmailRelated.TabStop = false;
            this.gbxEmailRelated.Text = "Email Related:";
            // 
            // btnViewEmailAddresses
            // 
            this.btnViewEmailAddresses.Location = new System.Drawing.Point(12, 63);
            this.btnViewEmailAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewEmailAddresses.Name = "btnViewEmailAddresses";
            this.btnViewEmailAddresses.Size = new System.Drawing.Size(202, 32);
            this.btnViewEmailAddresses.TabIndex = 17;
            this.btnViewEmailAddresses.Text = "View All Email Addresses";
            this.btnViewEmailAddresses.UseVisualStyleBackColor = true;
            this.btnViewEmailAddresses.Click += new System.EventHandler(this.BtnViewEmailAddresses_Click);
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Location = new System.Drawing.Point(124, 26);
            this.mtxtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(384, 24);
            this.mtxtEmail.TabIndex = 16;
            // 
            // btnAddBusinessEmail
            // 
            this.btnAddBusinessEmail.Location = new System.Drawing.Point(346, 63);
            this.btnAddBusinessEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBusinessEmail.Name = "btnAddBusinessEmail";
            this.btnAddBusinessEmail.Size = new System.Drawing.Size(162, 32);
            this.btnAddBusinessEmail.TabIndex = 18;
            this.btnAddBusinessEmail.Text = "Add Email Address";
            this.btnAddBusinessEmail.UseVisualStyleBackColor = true;
            this.btnAddBusinessEmail.Click += new System.EventHandler(this.BtnAddBusinessEmail_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(9, 29);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(107, 18);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // gbxPOBoxAddress
            // 
            this.gbxPOBoxAddress.Controls.Add(this.lblBusinessPODescription);
            this.gbxPOBoxAddress.Controls.Add(this.btnViewAllPOBoxAddresses);
            this.gbxPOBoxAddress.Controls.Add(this.txtBusinessPODescription);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxAreaCode);
            this.gbxPOBoxAddress.Controls.Add(this.btnAddPOBoxAddress);
            this.gbxPOBoxAddress.Controls.Add(this.mtxtPOBoxAreaCode);
            this.gbxPOBoxAddress.Controls.Add(this.txtPOBoxCity);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxCity);
            this.gbxPOBoxAddress.Controls.Add(this.txtPOBoxSuburb);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxSuburb);
            this.gbxPOBoxAddress.Controls.Add(this.mtxtPOBoxStreetNumber);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxStreetNumber);
            this.gbxPOBoxAddress.Location = new System.Drawing.Point(555, 299);
            this.gbxPOBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPOBoxAddress.Name = "gbxPOBoxAddress";
            this.gbxPOBoxAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPOBoxAddress.Size = new System.Drawing.Size(526, 283);
            this.gbxPOBoxAddress.TabIndex = 10;
            this.gbxPOBoxAddress.TabStop = false;
            this.gbxPOBoxAddress.Text = "mBusiness P.O.Box Address:";
            // 
            // lblBusinessPODescription
            // 
            this.lblBusinessPODescription.AutoSize = true;
            this.lblBusinessPODescription.Location = new System.Drawing.Point(49, 29);
            this.lblBusinessPODescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPODescription.Name = "lblBusinessPODescription";
            this.lblBusinessPODescription.Size = new System.Drawing.Size(87, 18);
            this.lblBusinessPODescription.TabIndex = 13;
            this.lblBusinessPODescription.Text = "Description:";
            // 
            // btnViewAllPOBoxAddresses
            // 
            this.btnViewAllPOBoxAddresses.Location = new System.Drawing.Point(12, 231);
            this.btnViewAllPOBoxAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAllPOBoxAddresses.Name = "btnViewAllPOBoxAddresses";
            this.btnViewAllPOBoxAddresses.Size = new System.Drawing.Size(168, 32);
            this.btnViewAllPOBoxAddresses.TabIndex = 24;
            this.btnViewAllPOBoxAddresses.Text = "View All Addresses";
            this.btnViewAllPOBoxAddresses.UseVisualStyleBackColor = true;
            this.btnViewAllPOBoxAddresses.Click += new System.EventHandler(this.BtnViewAllPOBoxAddresses_Click);
            // 
            // txtBusinessPODescription
            // 
            this.txtBusinessPODescription.Location = new System.Drawing.Point(142, 26);
            this.txtBusinessPODescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusinessPODescription.Name = "txtBusinessPODescription";
            this.txtBusinessPODescription.Size = new System.Drawing.Size(372, 24);
            this.txtBusinessPODescription.TabIndex = 19;
            // 
            // lblPOBoxAreaCode
            // 
            this.lblPOBoxAreaCode.AutoSize = true;
            this.lblPOBoxAreaCode.Location = new System.Drawing.Point(54, 157);
            this.lblPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxAreaCode.Name = "lblPOBoxAreaCode";
            this.lblPOBoxAreaCode.Size = new System.Drawing.Size(82, 18);
            this.lblPOBoxAreaCode.TabIndex = 9;
            this.lblPOBoxAreaCode.Text = "Area Code:";
            // 
            // btnAddPOBoxAddress
            // 
            this.btnAddPOBoxAddress.Location = new System.Drawing.Point(376, 231);
            this.btnAddPOBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPOBoxAddress.Name = "btnAddPOBoxAddress";
            this.btnAddPOBoxAddress.Size = new System.Drawing.Size(140, 32);
            this.btnAddPOBoxAddress.TabIndex = 25;
            this.btnAddPOBoxAddress.Text = "Add Address";
            this.btnAddPOBoxAddress.UseVisualStyleBackColor = true;
            this.btnAddPOBoxAddress.Click += new System.EventHandler(this.BtnAddPOBoxAddress_Click);
            // 
            // mtxtPOBoxAreaCode
            // 
            this.mtxtPOBoxAreaCode.Location = new System.Drawing.Point(142, 154);
            this.mtxtPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPOBoxAreaCode.Mask = "00000";
            this.mtxtPOBoxAreaCode.Name = "mtxtPOBoxAreaCode";
            this.mtxtPOBoxAreaCode.Size = new System.Drawing.Size(72, 24);
            this.mtxtPOBoxAreaCode.TabIndex = 23;
            this.mtxtPOBoxAreaCode.ValidatingType = typeof(int);
            // 
            // txtPOBoxCity
            // 
            this.txtPOBoxCity.Location = new System.Drawing.Point(142, 122);
            this.txtPOBoxCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtPOBoxCity.Name = "txtPOBoxCity";
            this.txtPOBoxCity.Size = new System.Drawing.Size(372, 24);
            this.txtPOBoxCity.TabIndex = 22;
            // 
            // lblPOBoxCity
            // 
            this.lblPOBoxCity.AutoSize = true;
            this.lblPOBoxCity.Location = new System.Drawing.Point(97, 125);
            this.lblPOBoxCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxCity.Name = "lblPOBoxCity";
            this.lblPOBoxCity.Size = new System.Drawing.Size(37, 18);
            this.lblPOBoxCity.TabIndex = 6;
            this.lblPOBoxCity.Text = "City:";
            // 
            // txtPOBoxSuburb
            // 
            this.txtPOBoxSuburb.Location = new System.Drawing.Point(142, 90);
            this.txtPOBoxSuburb.Margin = new System.Windows.Forms.Padding(4);
            this.txtPOBoxSuburb.Name = "txtPOBoxSuburb";
            this.txtPOBoxSuburb.Size = new System.Drawing.Size(372, 24);
            this.txtPOBoxSuburb.TabIndex = 21;
            // 
            // lblPOBoxSuburb
            // 
            this.lblPOBoxSuburb.AutoSize = true;
            this.lblPOBoxSuburb.Location = new System.Drawing.Point(75, 93);
            this.lblPOBoxSuburb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxSuburb.Name = "lblPOBoxSuburb";
            this.lblPOBoxSuburb.Size = new System.Drawing.Size(59, 18);
            this.lblPOBoxSuburb.TabIndex = 4;
            this.lblPOBoxSuburb.Text = "Suburb:";
            // 
            // mtxtPOBoxStreetNumber
            // 
            this.mtxtPOBoxStreetNumber.Location = new System.Drawing.Point(142, 58);
            this.mtxtPOBoxStreetNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPOBoxStreetNumber.Mask = "00000";
            this.mtxtPOBoxStreetNumber.Name = "mtxtPOBoxStreetNumber";
            this.mtxtPOBoxStreetNumber.Size = new System.Drawing.Size(72, 24);
            this.mtxtPOBoxStreetNumber.TabIndex = 20;
            this.mtxtPOBoxStreetNumber.ValidatingType = typeof(int);
            // 
            // lblPOBoxStreetNumber
            // 
            this.lblPOBoxStreetNumber.AutoSize = true;
            this.lblPOBoxStreetNumber.Location = new System.Drawing.Point(11, 61);
            this.lblPOBoxStreetNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxStreetNumber.Name = "lblPOBoxStreetNumber";
            this.lblPOBoxStreetNumber.Size = new System.Drawing.Size(125, 18);
            this.lblPOBoxStreetNumber.TabIndex = 0;
            this.lblPOBoxStreetNumber.Text = "P.O.Box Number:";
            // 
            // btnAddBusiness
            // 
            this.btnAddBusiness.Location = new System.Drawing.Point(910, 590);
            this.btnAddBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBusiness.Name = "btnAddBusiness";
            this.btnAddBusiness.Size = new System.Drawing.Size(171, 32);
            this.btnAddBusiness.TabIndex = 26;
            this.btnAddBusiness.Text = "Add mBusiness";
            this.btnAddBusiness.UseVisualStyleBackColor = true;
            this.btnAddBusiness.Click += new System.EventHandler(this.BtnAddBusiness_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(20, 590);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 32);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAddBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 629);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddBusiness);
            this.Controls.Add(this.gbxPOBoxAddress);
            this.Controls.Add(this.gbxEmailRelated);
            this.Controls.Add(this.gbxBusinessAddress);
            this.Controls.Add(this.gbxPhoneRelated);
            this.Controls.Add(this.gbxBusinessInformation);
            this.Controls.Add(this.msBusinessControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msBusinessControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddBusiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add mBusiness";
            this.Load += new System.EventHandler(this.FrmAddBusiness_Load);
            this.msBusinessControls.ResumeLayout(false);
            this.msBusinessControls.PerformLayout();
            this.gbxBusinessInformation.ResumeLayout(false);
            this.gbxBusinessInformation.PerformLayout();
            this.gbxLegalInformation.ResumeLayout(false);
            this.gbxLegalInformation.PerformLayout();
            this.gbxPhoneRelated.ResumeLayout(false);
            this.gbxPhoneRelated.PerformLayout();
            this.gbxBusinessAddress.ResumeLayout(false);
            this.gbxBusinessAddress.PerformLayout();
            this.gbxEmailRelated.ResumeLayout(false);
            this.gbxEmailRelated.PerformLayout();
            this.gbxPOBoxAddress.ResumeLayout(false);
            this.gbxPOBoxAddress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msBusinessControls;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxBusinessInformation;
        private System.Windows.Forms.Label lblBusinessName;
        private System.Windows.Forms.Label lblExtraInformation;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.RichTextBox rtxtExtraInformation;
        private System.Windows.Forms.GroupBox gbxPhoneRelated;
        private System.Windows.Forms.Label lblCellphoneNumber;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.MaskedTextBox mtxtTelephoneNumber;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.MaskedTextBox mtxtCellphoneNumber;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.GroupBox gbxBusinessAddress;
        private System.Windows.Forms.Label lblBusinessStreetNumber;
        private System.Windows.Forms.MaskedTextBox mtxtStreetnumber;
        private System.Windows.Forms.GroupBox gbxLegalInformation;
        private System.Windows.Forms.Label lblVATNumber;
        private System.Windows.Forms.Label lblRegistrationNumber;
        private System.Windows.Forms.MaskedTextBox mtxtRegistrationNumber;
        private System.Windows.Forms.MaskedTextBox mtxtVATNumber;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.MaskedTextBox mtxtAreaCode;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Button btnViewAddresses;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.GroupBox gbxEmailRelated;
        private System.Windows.Forms.MaskedTextBox mtxtEmail;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Button btnViewEmailAddresses;
        private System.Windows.Forms.Button btnAddBusinessEmail;
        private System.Windows.Forms.GroupBox gbxPOBoxAddress;
        private System.Windows.Forms.Button btnViewAllPOBoxAddresses;
        private System.Windows.Forms.Label lblPOBoxAreaCode;
        private System.Windows.Forms.Button btnAddPOBoxAddress;
        private System.Windows.Forms.MaskedTextBox mtxtPOBoxAreaCode;
        private System.Windows.Forms.TextBox txtPOBoxCity;
        private System.Windows.Forms.Label lblPOBoxCity;
        private System.Windows.Forms.TextBox txtPOBoxSuburb;
        private System.Windows.Forms.MaskedTextBox mtxtPOBoxStreetNumber;
        private System.Windows.Forms.Label lblPOBoxStreetNumber;
        private System.Windows.Forms.Button btnAddBusiness;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBusinessAddressDescription;
        private System.Windows.Forms.TextBox txtBusinessAddresssDescription;
        private System.Windows.Forms.Label lblBusinessPODescription;
        private System.Windows.Forms.TextBox txtBusinessPODescription;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBusinessInformationToolStripMenuItem;
        private System.Windows.Forms.Label lblPOBoxSuburb;
    }
}