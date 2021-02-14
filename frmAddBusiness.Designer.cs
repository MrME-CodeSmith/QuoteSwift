
namespace QuoteSwift
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lblPOBoxStreetName = new System.Windows.Forms.Label();
            this.txtPOBoxStreetName = new System.Windows.Forms.TextBox();
            this.mtxtPOBoxStreetNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPOBoxStreetNumber = new System.Windows.Forms.Label();
            this.btnAddBusiness = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBusinessInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msBusinessControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msBusinessControls.Location = new System.Drawing.Point(0, 0);
            this.msBusinessControls.Name = "msBusinessControls";
            this.msBusinessControls.Size = new System.Drawing.Size(734, 24);
            this.msBusinessControls.TabIndex = 0;
            this.msBusinessControls.Text = "msBusinessControls";
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
            // gbxBusinessInformation
            // 
            this.gbxBusinessInformation.Controls.Add(this.gbxLegalInformation);
            this.gbxBusinessInformation.Controls.Add(this.rtxtExtraInformation);
            this.gbxBusinessInformation.Controls.Add(this.txtBusinessName);
            this.gbxBusinessInformation.Controls.Add(this.lblExtraInformation);
            this.gbxBusinessInformation.Controls.Add(this.lblBusinessName);
            this.gbxBusinessInformation.Location = new System.Drawing.Point(13, 28);
            this.gbxBusinessInformation.Name = "gbxBusinessInformation";
            this.gbxBusinessInformation.Size = new System.Drawing.Size(351, 202);
            this.gbxBusinessInformation.TabIndex = 1;
            this.gbxBusinessInformation.TabStop = false;
            this.gbxBusinessInformation.Text = "Business Information:";
            // 
            // gbxLegalInformation
            // 
            this.gbxLegalInformation.Controls.Add(this.mtxtRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.mtxtVATNumber);
            this.gbxLegalInformation.Controls.Add(this.lblRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.lblVATNumber);
            this.gbxLegalInformation.Location = new System.Drawing.Point(6, 107);
            this.gbxLegalInformation.Name = "gbxLegalInformation";
            this.gbxLegalInformation.Size = new System.Drawing.Size(339, 89);
            this.gbxLegalInformation.TabIndex = 4;
            this.gbxLegalInformation.TabStop = false;
            this.gbxLegalInformation.Text = "Legal Information:";
            // 
            // mtxtRegistrationNumber
            // 
            this.mtxtRegistrationNumber.Location = new System.Drawing.Point(118, 61);
            this.mtxtRegistrationNumber.Name = "mtxtRegistrationNumber";
            this.mtxtRegistrationNumber.Size = new System.Drawing.Size(215, 20);
            this.mtxtRegistrationNumber.TabIndex = 2;
            // 
            // mtxtVATNumber
            // 
            this.mtxtVATNumber.Location = new System.Drawing.Point(118, 32);
            this.mtxtVATNumber.Name = "mtxtVATNumber";
            this.mtxtVATNumber.Size = new System.Drawing.Size(215, 20);
            this.mtxtVATNumber.TabIndex = 1;
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.AutoSize = true;
            this.lblRegistrationNumber.Location = new System.Drawing.Point(6, 64);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(106, 13);
            this.lblRegistrationNumber.TabIndex = 1;
            this.lblRegistrationNumber.Text = "Registration Number:";
            // 
            // lblVATNumber
            // 
            this.lblVATNumber.AutoSize = true;
            this.lblVATNumber.Location = new System.Drawing.Point(41, 35);
            this.lblVATNumber.Name = "lblVATNumber";
            this.lblVATNumber.Size = new System.Drawing.Size(71, 13);
            this.lblVATNumber.TabIndex = 0;
            this.lblVATNumber.Text = "VAT Number:";
            // 
            // rtxtExtraInformation
            // 
            this.rtxtExtraInformation.Location = new System.Drawing.Point(105, 55);
            this.rtxtExtraInformation.Name = "rtxtExtraInformation";
            this.rtxtExtraInformation.Size = new System.Drawing.Size(240, 46);
            this.rtxtExtraInformation.TabIndex = 2;
            this.rtxtExtraInformation.Text = "";
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(105, 22);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(240, 20);
            this.txtBusinessName.TabIndex = 1;
            // 
            // lblExtraInformation
            // 
            this.lblExtraInformation.AutoSize = true;
            this.lblExtraInformation.Location = new System.Drawing.Point(10, 55);
            this.lblExtraInformation.Name = "lblExtraInformation";
            this.lblExtraInformation.Size = new System.Drawing.Size(89, 13);
            this.lblExtraInformation.TabIndex = 1;
            this.lblExtraInformation.Text = "Extra Information:";
            // 
            // lblBusinessName
            // 
            this.lblBusinessName.AutoSize = true;
            this.lblBusinessName.Location = new System.Drawing.Point(16, 25);
            this.lblBusinessName.Name = "lblBusinessName";
            this.lblBusinessName.Size = new System.Drawing.Size(83, 13);
            this.lblBusinessName.TabIndex = 0;
            this.lblBusinessName.Text = "Business Name:";
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
            this.gbxPhoneRelated.Location = new System.Drawing.Point(370, 28);
            this.gbxPhoneRelated.Name = "gbxPhoneRelated";
            this.gbxPhoneRelated.Size = new System.Drawing.Size(351, 108);
            this.gbxPhoneRelated.TabIndex = 4;
            this.gbxPhoneRelated.TabStop = false;
            this.gbxPhoneRelated.Text = "Phone Related:";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(6, 78);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(102, 23);
            this.btnViewAll.TabIndex = 4;
            this.btnViewAll.Text = "View All Numbers";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // mtxtCellphoneNumber
            // 
            this.mtxtCellphoneNumber.Location = new System.Drawing.Point(114, 52);
            this.mtxtCellphoneNumber.Mask = "000-000-0000";
            this.mtxtCellphoneNumber.Name = "mtxtCellphoneNumber";
            this.mtxtCellphoneNumber.Size = new System.Drawing.Size(104, 20);
            this.mtxtCellphoneNumber.TabIndex = 2;
            // 
            // mtxtTelephoneNumber
            // 
            this.mtxtTelephoneNumber.Location = new System.Drawing.Point(114, 22);
            this.mtxtTelephoneNumber.Mask = "(999) 000-0000";
            this.mtxtTelephoneNumber.Name = "mtxtTelephoneNumber";
            this.mtxtTelephoneNumber.Size = new System.Drawing.Size(104, 20);
            this.mtxtTelephoneNumber.TabIndex = 1;
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(252, 78);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(93, 23);
            this.btnAddNumber.TabIndex = 3;
            this.btnAddNumber.Text = "Add Number/s";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.BtnAddNumber_Click);
            // 
            // lblCellphoneNumber
            // 
            this.lblCellphoneNumber.AutoSize = true;
            this.lblCellphoneNumber.Location = new System.Drawing.Point(11, 55);
            this.lblCellphoneNumber.Name = "lblCellphoneNumber";
            this.lblCellphoneNumber.Size = new System.Drawing.Size(97, 13);
            this.lblCellphoneNumber.TabIndex = 1;
            this.lblCellphoneNumber.Text = "Cellphone Number:";
            this.lblCellphoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Location = new System.Drawing.Point(7, 25);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(101, 13);
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
            this.gbxBusinessAddress.Location = new System.Drawing.Point(13, 236);
            this.gbxBusinessAddress.Name = "gbxBusinessAddress";
            this.gbxBusinessAddress.Size = new System.Drawing.Size(351, 236);
            this.gbxBusinessAddress.TabIndex = 5;
            this.gbxBusinessAddress.TabStop = false;
            this.gbxBusinessAddress.Text = "Business Address:";
            // 
            // lblBusinessAddressDescription
            // 
            this.lblBusinessAddressDescription.AutoSize = true;
            this.lblBusinessAddressDescription.Location = new System.Drawing.Point(27, 22);
            this.lblBusinessAddressDescription.Name = "lblBusinessAddressDescription";
            this.lblBusinessAddressDescription.Size = new System.Drawing.Size(63, 13);
            this.lblBusinessAddressDescription.TabIndex = 11;
            this.lblBusinessAddressDescription.Text = "Description:";
            // 
            // txtBusinessAddresssDescription
            // 
            this.txtBusinessAddresssDescription.Location = new System.Drawing.Point(96, 19);
            this.txtBusinessAddresssDescription.Name = "txtBusinessAddresssDescription";
            this.txtBusinessAddresssDescription.Size = new System.Drawing.Size(249, 20);
            this.txtBusinessAddresssDescription.TabIndex = 1;
            // 
            // btnViewAddresses
            // 
            this.btnViewAddresses.Location = new System.Drawing.Point(12, 199);
            this.btnViewAddresses.Name = "btnViewAddresses";
            this.btnViewAddresses.Size = new System.Drawing.Size(112, 23);
            this.btnViewAddresses.TabIndex = 8;
            this.btnViewAddresses.Text = "View All Addresses";
            this.btnViewAddresses.UseVisualStyleBackColor = true;
            this.btnViewAddresses.Click += new System.EventHandler(this.BtnViewAddresses_Click);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(30, 171);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(60, 13);
            this.lblAreaCode.TabIndex = 9;
            this.lblAreaCode.Text = "Area Code:";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(252, 199);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(93, 23);
            this.btnAddAddress.TabIndex = 7;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.BtnAddAddress_Click);
            // 
            // mtxtAreaCode
            // 
            this.mtxtAreaCode.Location = new System.Drawing.Point(96, 168);
            this.mtxtAreaCode.Mask = "00000";
            this.mtxtAreaCode.Name = "mtxtAreaCode";
            this.mtxtAreaCode.Size = new System.Drawing.Size(49, 20);
            this.mtxtAreaCode.TabIndex = 6;
            this.mtxtAreaCode.ValidatingType = typeof(int);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(96, 138);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(249, 20);
            this.txtCity.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(63, 141);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "City:";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(96, 108);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(249, 20);
            this.txtSuburb.TabIndex = 4;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(46, 111);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblSuburb.TabIndex = 4;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(21, 81);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblStreetName.TabIndex = 3;
            this.lblStreetName.Text = "Street Name:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(96, 78);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(249, 20);
            this.txtStreetName.TabIndex = 3;
            // 
            // mtxtStreetnumber
            // 
            this.mtxtStreetnumber.Culture = new System.Globalization.CultureInfo("en-029");
            this.mtxtStreetnumber.Location = new System.Drawing.Point(96, 49);
            this.mtxtStreetnumber.Mask = "00000";
            this.mtxtStreetnumber.Name = "mtxtStreetnumber";
            this.mtxtStreetnumber.Size = new System.Drawing.Size(49, 20);
            this.mtxtStreetnumber.TabIndex = 2;
            this.mtxtStreetnumber.ValidatingType = typeof(int);
            // 
            // lblBusinessStreetNumber
            // 
            this.lblBusinessStreetNumber.AutoSize = true;
            this.lblBusinessStreetNumber.Location = new System.Drawing.Point(12, 51);
            this.lblBusinessStreetNumber.Name = "lblBusinessStreetNumber";
            this.lblBusinessStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblBusinessStreetNumber.TabIndex = 0;
            this.lblBusinessStreetNumber.Text = "Street Number:";
            // 
            // gbxEmailRelated
            // 
            this.gbxEmailRelated.Controls.Add(this.btnViewEmailAddresses);
            this.gbxEmailRelated.Controls.Add(this.mtxtEmail);
            this.gbxEmailRelated.Controls.Add(this.btnAddBusinessEmail);
            this.gbxEmailRelated.Controls.Add(this.lblEmailAddress);
            this.gbxEmailRelated.Location = new System.Drawing.Point(370, 141);
            this.gbxEmailRelated.Name = "gbxEmailRelated";
            this.gbxEmailRelated.Size = new System.Drawing.Size(352, 89);
            this.gbxEmailRelated.TabIndex = 5;
            this.gbxEmailRelated.TabStop = false;
            this.gbxEmailRelated.Text = "Email Related:";
            // 
            // btnViewEmailAddresses
            // 
            this.btnViewEmailAddresses.Location = new System.Drawing.Point(9, 58);
            this.btnViewEmailAddresses.Name = "btnViewEmailAddresses";
            this.btnViewEmailAddresses.Size = new System.Drawing.Size(135, 23);
            this.btnViewEmailAddresses.TabIndex = 3;
            this.btnViewEmailAddresses.Text = "View All Email Addresses";
            this.btnViewEmailAddresses.UseVisualStyleBackColor = true;
            this.btnViewEmailAddresses.Click += new System.EventHandler(this.BtnViewEmailAddresses_Click);
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Location = new System.Drawing.Point(88, 26);
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(257, 20);
            this.mtxtEmail.TabIndex = 1;
            // 
            // btnAddBusinessEmail
            // 
            this.btnAddBusinessEmail.Location = new System.Drawing.Point(237, 58);
            this.btnAddBusinessEmail.Name = "btnAddBusinessEmail";
            this.btnAddBusinessEmail.Size = new System.Drawing.Size(108, 23);
            this.btnAddBusinessEmail.TabIndex = 2;
            this.btnAddBusinessEmail.Text = "Add Email Address";
            this.btnAddBusinessEmail.UseVisualStyleBackColor = true;
            this.btnAddBusinessEmail.Click += new System.EventHandler(this.BtnAddBusinessEmail_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(6, 29);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(76, 13);
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
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxStreetName);
            this.gbxPOBoxAddress.Controls.Add(this.txtPOBoxStreetName);
            this.gbxPOBoxAddress.Controls.Add(this.mtxtPOBoxStreetNumber);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxStreetNumber);
            this.gbxPOBoxAddress.Location = new System.Drawing.Point(370, 236);
            this.gbxPOBoxAddress.Name = "gbxPOBoxAddress";
            this.gbxPOBoxAddress.Size = new System.Drawing.Size(351, 236);
            this.gbxPOBoxAddress.TabIndex = 10;
            this.gbxPOBoxAddress.TabStop = false;
            this.gbxPOBoxAddress.Text = "Business P.O.Box Address:";
            // 
            // lblBusinessPODescription
            // 
            this.lblBusinessPODescription.AutoSize = true;
            this.lblBusinessPODescription.Location = new System.Drawing.Point(26, 22);
            this.lblBusinessPODescription.Name = "lblBusinessPODescription";
            this.lblBusinessPODescription.Size = new System.Drawing.Size(63, 13);
            this.lblBusinessPODescription.TabIndex = 13;
            this.lblBusinessPODescription.Text = "Description:";
            // 
            // btnViewAllPOBoxAddresses
            // 
            this.btnViewAllPOBoxAddresses.Location = new System.Drawing.Point(11, 198);
            this.btnViewAllPOBoxAddresses.Name = "btnViewAllPOBoxAddresses";
            this.btnViewAllPOBoxAddresses.Size = new System.Drawing.Size(112, 23);
            this.btnViewAllPOBoxAddresses.TabIndex = 8;
            this.btnViewAllPOBoxAddresses.Text = "View All Addresses";
            this.btnViewAllPOBoxAddresses.UseVisualStyleBackColor = true;
            this.btnViewAllPOBoxAddresses.Click += new System.EventHandler(this.BtnViewAllPOBoxAddresses_Click);
            // 
            // txtBusinessPODescription
            // 
            this.txtBusinessPODescription.Location = new System.Drawing.Point(95, 19);
            this.txtBusinessPODescription.Name = "txtBusinessPODescription";
            this.txtBusinessPODescription.Size = new System.Drawing.Size(249, 20);
            this.txtBusinessPODescription.TabIndex = 1;
            // 
            // lblPOBoxAreaCode
            // 
            this.lblPOBoxAreaCode.AutoSize = true;
            this.lblPOBoxAreaCode.Location = new System.Drawing.Point(29, 170);
            this.lblPOBoxAreaCode.Name = "lblPOBoxAreaCode";
            this.lblPOBoxAreaCode.Size = new System.Drawing.Size(60, 13);
            this.lblPOBoxAreaCode.TabIndex = 9;
            this.lblPOBoxAreaCode.Text = "Area Code:";
            // 
            // btnAddPOBoxAddress
            // 
            this.btnAddPOBoxAddress.Location = new System.Drawing.Point(251, 198);
            this.btnAddPOBoxAddress.Name = "btnAddPOBoxAddress";
            this.btnAddPOBoxAddress.Size = new System.Drawing.Size(93, 23);
            this.btnAddPOBoxAddress.TabIndex = 7;
            this.btnAddPOBoxAddress.Text = "Add Address";
            this.btnAddPOBoxAddress.UseVisualStyleBackColor = true;
            this.btnAddPOBoxAddress.Click += new System.EventHandler(this.BtnAddPOBoxAddress_Click);
            // 
            // mtxtPOBoxAreaCode
            // 
            this.mtxtPOBoxAreaCode.Location = new System.Drawing.Point(95, 167);
            this.mtxtPOBoxAreaCode.Mask = "00000";
            this.mtxtPOBoxAreaCode.Name = "mtxtPOBoxAreaCode";
            this.mtxtPOBoxAreaCode.Size = new System.Drawing.Size(49, 20);
            this.mtxtPOBoxAreaCode.TabIndex = 6;
            this.mtxtPOBoxAreaCode.ValidatingType = typeof(int);
            // 
            // txtPOBoxCity
            // 
            this.txtPOBoxCity.Location = new System.Drawing.Point(95, 137);
            this.txtPOBoxCity.Name = "txtPOBoxCity";
            this.txtPOBoxCity.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxCity.TabIndex = 5;
            // 
            // lblPOBoxCity
            // 
            this.lblPOBoxCity.AutoSize = true;
            this.lblPOBoxCity.Location = new System.Drawing.Point(62, 140);
            this.lblPOBoxCity.Name = "lblPOBoxCity";
            this.lblPOBoxCity.Size = new System.Drawing.Size(27, 13);
            this.lblPOBoxCity.TabIndex = 6;
            this.lblPOBoxCity.Text = "City:";
            // 
            // txtPOBoxSuburb
            // 
            this.txtPOBoxSuburb.Location = new System.Drawing.Point(95, 107);
            this.txtPOBoxSuburb.Name = "txtPOBoxSuburb";
            this.txtPOBoxSuburb.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxSuburb.TabIndex = 4;
            // 
            // lblPOBoxSuburb
            // 
            this.lblPOBoxSuburb.AutoSize = true;
            this.lblPOBoxSuburb.Location = new System.Drawing.Point(45, 110);
            this.lblPOBoxSuburb.Name = "lblPOBoxSuburb";
            this.lblPOBoxSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblPOBoxSuburb.TabIndex = 4;
            this.lblPOBoxSuburb.Text = "Suburb:";
            // 
            // lblPOBoxStreetName
            // 
            this.lblPOBoxStreetName.AutoSize = true;
            this.lblPOBoxStreetName.Location = new System.Drawing.Point(20, 80);
            this.lblPOBoxStreetName.Name = "lblPOBoxStreetName";
            this.lblPOBoxStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblPOBoxStreetName.TabIndex = 3;
            this.lblPOBoxStreetName.Text = "Street Name:";
            // 
            // txtPOBoxStreetName
            // 
            this.txtPOBoxStreetName.Location = new System.Drawing.Point(95, 77);
            this.txtPOBoxStreetName.Name = "txtPOBoxStreetName";
            this.txtPOBoxStreetName.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxStreetName.TabIndex = 3;
            // 
            // mtxtPOBoxStreetNumber
            // 
            this.mtxtPOBoxStreetNumber.Location = new System.Drawing.Point(95, 48);
            this.mtxtPOBoxStreetNumber.Mask = "00000";
            this.mtxtPOBoxStreetNumber.Name = "mtxtPOBoxStreetNumber";
            this.mtxtPOBoxStreetNumber.Size = new System.Drawing.Size(49, 20);
            this.mtxtPOBoxStreetNumber.TabIndex = 2;
            this.mtxtPOBoxStreetNumber.ValidatingType = typeof(int);
            // 
            // lblPOBoxStreetNumber
            // 
            this.lblPOBoxStreetNumber.AutoSize = true;
            this.lblPOBoxStreetNumber.Location = new System.Drawing.Point(11, 50);
            this.lblPOBoxStreetNumber.Name = "lblPOBoxStreetNumber";
            this.lblPOBoxStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPOBoxStreetNumber.TabIndex = 0;
            this.lblPOBoxStreetNumber.Text = "Street Number:";
            // 
            // btnAddBusiness
            // 
            this.btnAddBusiness.Location = new System.Drawing.Point(607, 478);
            this.btnAddBusiness.Name = "btnAddBusiness";
            this.btnAddBusiness.Size = new System.Drawing.Size(114, 23);
            this.btnAddBusiness.TabIndex = 51;
            this.btnAddBusiness.Text = "Add Business";
            this.btnAddBusiness.UseVisualStyleBackColor = true;
            this.btnAddBusiness.Click += new System.EventHandler(this.BtnAddBusiness_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateBusinessInformationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updateBusinessInformationToolStripMenuItem
            // 
            this.updateBusinessInformationToolStripMenuItem.Name = "updateBusinessInformationToolStripMenuItem";
            this.updateBusinessInformationToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.updateBusinessInformationToolStripMenuItem.Text = "Update Business Information";
            this.updateBusinessInformationToolStripMenuItem.Click += new System.EventHandler(this.UpdateBusinessInformationToolStripMenuItem_Click);
            // 
            // FrmAddBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 510);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddBusiness);
            this.Controls.Add(this.gbxPOBoxAddress);
            this.Controls.Add(this.gbxEmailRelated);
            this.Controls.Add(this.gbxBusinessAddress);
            this.Controls.Add(this.gbxPhoneRelated);
            this.Controls.Add(this.gbxBusinessInformation);
            this.Controls.Add(this.msBusinessControls);
            this.MainMenuStrip = this.msBusinessControls;
            this.Name = "FrmAddBusiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Business";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddBusiness_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
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
        private System.Windows.Forms.Label lblPOBoxSuburb;
        private System.Windows.Forms.Label lblPOBoxStreetName;
        private System.Windows.Forms.TextBox txtPOBoxStreetName;
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
    }
}