
namespace QuoteSwift
{
    partial class FrmAddCustomer
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
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.gbxEmailRelated = new System.Windows.Forms.GroupBox();
            this.btnViewEmailAddresses = new System.Windows.Forms.Button();
            this.mtxtEmailAddress = new System.Windows.Forms.MaskedTextBox();
            this.BtnAddEmail = new System.Windows.Forms.Button();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.gbxPOBoxAddress = new System.Windows.Forms.GroupBox();
            this.lblBusinessPODescription = new System.Windows.Forms.Label();
            this.txtCustomerPODescription = new System.Windows.Forms.TextBox();
            this.btnViewAllPOBoxAddresses = new System.Windows.Forms.Button();
            this.lblPOBoxAreaCode = new System.Windows.Forms.Label();
            this.btnAddPOBoxAddress = new System.Windows.Forms.Button();
            this.mtxtPOBoxAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.txtPOBoxCity = new System.Windows.Forms.TextBox();
            this.lblPOBoxCity = new System.Windows.Forms.Label();
            this.txtPOBoxSuburb = new System.Windows.Forms.TextBox();
            this.lblPOBoxSuburb = new System.Windows.Forms.Label();
            this.mtxtPOBoxStreetNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblPOBoxStreetNumber = new System.Windows.Forms.Label();
            this.btnViewAddresses = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtWorkPlace = new System.Windows.Forms.TextBox();
            this.msCustomerControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatedCustomerInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxCustomerInformation = new System.Windows.Forms.GroupBox();
            this.mtxtVendorNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblVendorNumebr = new System.Windows.Forms.Label();
            this.cbBusinessSelection = new System.Windows.Forms.ComboBox();
            this.lblLinkCustomerTo = new System.Windows.Forms.Label();
            this.txtCustomerCompanyName = new System.Windows.Forms.TextBox();
            this.gbxLegalInformation = new System.Windows.Forms.GroupBox();
            this.mtxtRegistrationNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtVATNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.lblVATNumber = new System.Windows.Forms.Label();
            this.lblExtraInformation = new System.Windows.Forms.Label();
            this.gbxCustomerAddress = new System.Windows.Forms.GroupBox();
            this.lblBusinessAddressDescription = new System.Windows.Forms.Label();
            this.txtCustomerAddresssDescription = new System.Windows.Forms.TextBox();
            this.lblWorkPlace = new System.Windows.Forms.Label();
            this.txtWorkArea = new System.Windows.Forms.TextBox();
            this.lblWorkArea = new System.Windows.Forms.Label();
            this.lblAttention = new System.Windows.Forms.Label();
            this.txtAtt = new System.Windows.Forms.TextBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.mtxtCellphoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelephoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.lblCellphoneNumber = new System.Windows.Forms.Label();
            this.gbxPhoneRelated = new System.Windows.Forms.GroupBox();
            this.lblTelephoneNumber = new System.Windows.Forms.Label();
            this.gbxEmailRelated.SuspendLayout();
            this.gbxPOBoxAddress.SuspendLayout();
            this.msCustomerControls.SuspendLayout();
            this.gbxCustomerInformation.SuspendLayout();
            this.gbxLegalInformation.SuspendLayout();
            this.gbxCustomerAddress.SuspendLayout();
            this.gbxPhoneRelated.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(369, 208);
            this.btnAddAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(140, 32);
            this.btnAddAddress.TabIndex = 10;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.BtnAddAddress_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(909, 597);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(168, 32);
            this.btnAddCustomer.TabIndex = 26;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // gbxEmailRelated
            // 
            this.gbxEmailRelated.Controls.Add(this.btnViewEmailAddresses);
            this.gbxEmailRelated.Controls.Add(this.mtxtEmailAddress);
            this.gbxEmailRelated.Controls.Add(this.BtnAddEmail);
            this.gbxEmailRelated.Controls.Add(this.lblEmailAddress);
            this.gbxEmailRelated.Location = new System.Drawing.Point(549, 180);
            this.gbxEmailRelated.Margin = new System.Windows.Forms.Padding(4);
            this.gbxEmailRelated.Name = "gbxEmailRelated";
            this.gbxEmailRelated.Padding = new System.Windows.Forms.Padding(4);
            this.gbxEmailRelated.Size = new System.Drawing.Size(528, 116);
            this.gbxEmailRelated.TabIndex = 15;
            this.gbxEmailRelated.TabStop = false;
            this.gbxEmailRelated.Text = "Email Related:";
            // 
            // btnViewEmailAddresses
            // 
            this.btnViewEmailAddresses.Location = new System.Drawing.Point(17, 69);
            this.btnViewEmailAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewEmailAddresses.Name = "btnViewEmailAddresses";
            this.btnViewEmailAddresses.Size = new System.Drawing.Size(202, 32);
            this.btnViewEmailAddresses.TabIndex = 18;
            this.btnViewEmailAddresses.Text = "View All Email Addresses";
            this.btnViewEmailAddresses.UseVisualStyleBackColor = true;
            this.btnViewEmailAddresses.Click += new System.EventHandler(this.BtnViewEmailAddresses_Click);
            // 
            // mtxtEmailAddress
            // 
            this.mtxtEmailAddress.Location = new System.Drawing.Point(129, 25);
            this.mtxtEmailAddress.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtEmailAddress.Name = "mtxtEmailAddress";
            this.mtxtEmailAddress.Size = new System.Drawing.Size(384, 24);
            this.mtxtEmailAddress.TabIndex = 16;
            // 
            // BtnAddEmail
            // 
            this.BtnAddEmail.Location = new System.Drawing.Point(353, 69);
            this.BtnAddEmail.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddEmail.Name = "BtnAddEmail";
            this.BtnAddEmail.Size = new System.Drawing.Size(162, 32);
            this.BtnAddEmail.TabIndex = 17;
            this.BtnAddEmail.Text = "Add Email Address";
            this.BtnAddEmail.UseVisualStyleBackColor = true;
            this.BtnAddEmail.Click += new System.EventHandler(this.BtnAddEmail_Click);
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(14, 28);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(107, 18);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // gbxPOBoxAddress
            // 
            this.gbxPOBoxAddress.Controls.Add(this.lblBusinessPODescription);
            this.gbxPOBoxAddress.Controls.Add(this.txtCustomerPODescription);
            this.gbxPOBoxAddress.Controls.Add(this.btnViewAllPOBoxAddresses);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxAreaCode);
            this.gbxPOBoxAddress.Controls.Add(this.btnAddPOBoxAddress);
            this.gbxPOBoxAddress.Controls.Add(this.mtxtPOBoxAreaCode);
            this.gbxPOBoxAddress.Controls.Add(this.txtPOBoxCity);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxCity);
            this.gbxPOBoxAddress.Controls.Add(this.txtPOBoxSuburb);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxSuburb);
            this.gbxPOBoxAddress.Controls.Add(this.mtxtPOBoxStreetNumber);
            this.gbxPOBoxAddress.Controls.Add(this.lblPOBoxStreetNumber);
            this.gbxPOBoxAddress.Location = new System.Drawing.Point(549, 315);
            this.gbxPOBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPOBoxAddress.Name = "gbxPOBoxAddress";
            this.gbxPOBoxAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPOBoxAddress.Size = new System.Drawing.Size(526, 274);
            this.gbxPOBoxAddress.TabIndex = 18;
            this.gbxPOBoxAddress.TabStop = false;
            this.gbxPOBoxAddress.Text = "Customer P.O.Box Address:";
            // 
            // lblBusinessPODescription
            // 
            this.lblBusinessPODescription.AutoSize = true;
            this.lblBusinessPODescription.Location = new System.Drawing.Point(47, 29);
            this.lblBusinessPODescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPODescription.Name = "lblBusinessPODescription";
            this.lblBusinessPODescription.Size = new System.Drawing.Size(87, 18);
            this.lblBusinessPODescription.TabIndex = 15;
            this.lblBusinessPODescription.Text = "Description:";
            // 
            // txtCustomerPODescription
            // 
            this.txtCustomerPODescription.Location = new System.Drawing.Point(142, 26);
            this.txtCustomerPODescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerPODescription.Name = "txtCustomerPODescription";
            this.txtCustomerPODescription.Size = new System.Drawing.Size(372, 24);
            this.txtCustomerPODescription.TabIndex = 19;
            // 
            // btnViewAllPOBoxAddresses
            // 
            this.btnViewAllPOBoxAddresses.Location = new System.Drawing.Point(17, 228);
            this.btnViewAllPOBoxAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAllPOBoxAddresses.Name = "btnViewAllPOBoxAddresses";
            this.btnViewAllPOBoxAddresses.Size = new System.Drawing.Size(168, 32);
            this.btnViewAllPOBoxAddresses.TabIndex = 25;
            this.btnViewAllPOBoxAddresses.Text = "View All Addresses";
            this.btnViewAllPOBoxAddresses.UseVisualStyleBackColor = true;
            this.btnViewAllPOBoxAddresses.Click += new System.EventHandler(this.BtnViewAllPOBoxAddresses_Click);
            // 
            // lblPOBoxAreaCode
            // 
            this.lblPOBoxAreaCode.AutoSize = true;
            this.lblPOBoxAreaCode.Location = new System.Drawing.Point(52, 160);
            this.lblPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxAreaCode.Name = "lblPOBoxAreaCode";
            this.lblPOBoxAreaCode.Size = new System.Drawing.Size(82, 18);
            this.lblPOBoxAreaCode.TabIndex = 9;
            this.lblPOBoxAreaCode.Text = "Area Code:";
            // 
            // btnAddPOBoxAddress
            // 
            this.btnAddPOBoxAddress.Location = new System.Drawing.Point(375, 228);
            this.btnAddPOBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPOBoxAddress.Name = "btnAddPOBoxAddress";
            this.btnAddPOBoxAddress.Size = new System.Drawing.Size(140, 32);
            this.btnAddPOBoxAddress.TabIndex = 24;
            this.btnAddPOBoxAddress.Text = "Add Address";
            this.btnAddPOBoxAddress.UseVisualStyleBackColor = true;
            this.btnAddPOBoxAddress.Click += new System.EventHandler(this.BtnAddPOBoxAddress_Click);
            // 
            // mtxtPOBoxAreaCode
            // 
            this.mtxtPOBoxAreaCode.Location = new System.Drawing.Point(142, 157);
            this.mtxtPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtPOBoxAreaCode.Mask = "00000";
            this.mtxtPOBoxAreaCode.Name = "mtxtPOBoxAreaCode";
            this.mtxtPOBoxAreaCode.Size = new System.Drawing.Size(72, 24);
            this.mtxtPOBoxAreaCode.TabIndex = 23;
            this.mtxtPOBoxAreaCode.ValidatingType = typeof(int);
            // 
            // txtPOBoxCity
            // 
            this.txtPOBoxCity.Location = new System.Drawing.Point(142, 125);
            this.txtPOBoxCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtPOBoxCity.Name = "txtPOBoxCity";
            this.txtPOBoxCity.Size = new System.Drawing.Size(372, 24);
            this.txtPOBoxCity.TabIndex = 22;
            // 
            // lblPOBoxCity
            // 
            this.lblPOBoxCity.AutoSize = true;
            this.lblPOBoxCity.Location = new System.Drawing.Point(97, 128);
            this.lblPOBoxCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxCity.Name = "lblPOBoxCity";
            this.lblPOBoxCity.Size = new System.Drawing.Size(37, 18);
            this.lblPOBoxCity.TabIndex = 6;
            this.lblPOBoxCity.Text = "City:";
            // 
            // txtPOBoxSuburb
            // 
            this.txtPOBoxSuburb.Location = new System.Drawing.Point(142, 93);
            this.txtPOBoxSuburb.Margin = new System.Windows.Forms.Padding(4);
            this.txtPOBoxSuburb.Name = "txtPOBoxSuburb";
            this.txtPOBoxSuburb.Size = new System.Drawing.Size(372, 24);
            this.txtPOBoxSuburb.TabIndex = 21;
            // 
            // lblPOBoxSuburb
            // 
            this.lblPOBoxSuburb.AutoSize = true;
            this.lblPOBoxSuburb.Location = new System.Drawing.Point(75, 96);
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
            this.lblPOBoxStreetNumber.Location = new System.Drawing.Point(9, 61);
            this.lblPOBoxStreetNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPOBoxStreetNumber.Name = "lblPOBoxStreetNumber";
            this.lblPOBoxStreetNumber.Size = new System.Drawing.Size(125, 18);
            this.lblPOBoxStreetNumber.TabIndex = 0;
            this.lblPOBoxStreetNumber.Text = "P.O.Box Number:";
            // 
            // btnViewAddresses
            // 
            this.btnViewAddresses.Location = new System.Drawing.Point(16, 208);
            this.btnViewAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAddresses.Name = "btnViewAddresses";
            this.btnViewAddresses.Size = new System.Drawing.Size(168, 32);
            this.btnViewAddresses.TabIndex = 11;
            this.btnViewAddresses.Text = "View All Addresses";
            this.btnViewAddresses.UseVisualStyleBackColor = true;
            this.btnViewAddresses.Click += new System.EventHandler(this.BtnViewAddresses_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 597);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 32);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.Location = new System.Drawing.Point(138, 154);
            this.txtWorkPlace.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.Size = new System.Drawing.Size(371, 24);
            this.txtWorkPlace.TabIndex = 9;
            // 
            // msCustomerControls
            // 
            this.msCustomerControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msCustomerControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msCustomerControls.Location = new System.Drawing.Point(0, 0);
            this.msCustomerControls.Name = "msCustomerControls";
            this.msCustomerControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msCustomerControls.Size = new System.Drawing.Size(1089, 30);
            this.msCustomerControls.TabIndex = 12;
            this.msCustomerControls.Text = "msCustomerControls";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatedCustomerInformationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updatedCustomerInformationToolStripMenuItem
            // 
            this.updatedCustomerInformationToolStripMenuItem.Enabled = false;
            this.updatedCustomerInformationToolStripMenuItem.Name = "updatedCustomerInformationToolStripMenuItem";
            this.updatedCustomerInformationToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.updatedCustomerInformationToolStripMenuItem.Text = "Update Customer\'s Information";
            this.updatedCustomerInformationToolStripMenuItem.Click += new System.EventHandler(this.UpdatedCustomerInformationToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // gbxCustomerInformation
            // 
            this.gbxCustomerInformation.Controls.Add(this.mtxtVendorNumber);
            this.gbxCustomerInformation.Controls.Add(this.lblVendorNumebr);
            this.gbxCustomerInformation.Controls.Add(this.cbBusinessSelection);
            this.gbxCustomerInformation.Controls.Add(this.lblLinkCustomerTo);
            this.gbxCustomerInformation.Controls.Add(this.txtCustomerCompanyName);
            this.gbxCustomerInformation.Controls.Add(this.gbxLegalInformation);
            this.gbxCustomerInformation.Controls.Add(this.lblExtraInformation);
            this.gbxCustomerInformation.Location = new System.Drawing.Point(12, 37);
            this.gbxCustomerInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCustomerInformation.Name = "gbxCustomerInformation";
            this.gbxCustomerInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCustomerInformation.Size = new System.Drawing.Size(526, 259);
            this.gbxCustomerInformation.TabIndex = 13;
            this.gbxCustomerInformation.TabStop = false;
            this.gbxCustomerInformation.Text = "Customer Information:";
            // 
            // mtxtVendorNumber
            // 
            this.mtxtVendorNumber.Location = new System.Drawing.Point(224, 91);
            this.mtxtVendorNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtVendorNumber.Name = "mtxtVendorNumber";
            this.mtxtVendorNumber.Size = new System.Drawing.Size(294, 24);
            this.mtxtVendorNumber.TabIndex = 3;
            // 
            // lblVendorNumebr
            // 
            this.lblVendorNumebr.AutoSize = true;
            this.lblVendorNumebr.Location = new System.Drawing.Point(96, 94);
            this.lblVendorNumebr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorNumebr.Name = "lblVendorNumebr";
            this.lblVendorNumebr.Size = new System.Drawing.Size(116, 18);
            this.lblVendorNumebr.TabIndex = 8;
            this.lblVendorNumebr.Text = "Vendor Number:";
            // 
            // cbBusinessSelection
            // 
            this.cbBusinessSelection.FormattingEnabled = true;
            this.cbBusinessSelection.Location = new System.Drawing.Point(225, 57);
            this.cbBusinessSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbBusinessSelection.Name = "cbBusinessSelection";
            this.cbBusinessSelection.Size = new System.Drawing.Size(294, 26);
            this.cbBusinessSelection.TabIndex = 2;
            // 
            // lblLinkCustomerTo
            // 
            this.lblLinkCustomerTo.AutoSize = true;
            this.lblLinkCustomerTo.Location = new System.Drawing.Point(81, 60);
            this.lblLinkCustomerTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinkCustomerTo.Name = "lblLinkCustomerTo";
            this.lblLinkCustomerTo.Size = new System.Drawing.Size(131, 18);
            this.lblLinkCustomerTo.TabIndex = 6;
            this.lblLinkCustomerTo.Text = "Link Customer To:";
            // 
            // txtCustomerCompanyName
            // 
            this.txtCustomerCompanyName.Location = new System.Drawing.Point(224, 25);
            this.txtCustomerCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerCompanyName.Name = "txtCustomerCompanyName";
            this.txtCustomerCompanyName.Size = new System.Drawing.Size(294, 24);
            this.txtCustomerCompanyName.TabIndex = 1;
            // 
            // gbxLegalInformation
            // 
            this.gbxLegalInformation.Controls.Add(this.mtxtRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.mtxtVATNumber);
            this.gbxLegalInformation.Controls.Add(this.lblRegistrationNumber);
            this.gbxLegalInformation.Controls.Add(this.lblVATNumber);
            this.gbxLegalInformation.Location = new System.Drawing.Point(11, 143);
            this.gbxLegalInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxLegalInformation.Name = "gbxLegalInformation";
            this.gbxLegalInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxLegalInformation.Size = new System.Drawing.Size(508, 105);
            this.gbxLegalInformation.TabIndex = 4;
            this.gbxLegalInformation.TabStop = false;
            this.gbxLegalInformation.Text = "Legal Information:";
            // 
            // mtxtRegistrationNumber
            // 
            this.mtxtRegistrationNumber.Location = new System.Drawing.Point(180, 58);
            this.mtxtRegistrationNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtRegistrationNumber.Name = "mtxtRegistrationNumber";
            this.mtxtRegistrationNumber.Size = new System.Drawing.Size(320, 24);
            this.mtxtRegistrationNumber.TabIndex = 5;
            // 
            // mtxtVATNumber
            // 
            this.mtxtVATNumber.Location = new System.Drawing.Point(180, 25);
            this.mtxtVATNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtVATNumber.Name = "mtxtVATNumber";
            this.mtxtVATNumber.Size = new System.Drawing.Size(320, 24);
            this.mtxtVATNumber.TabIndex = 4;
            // 
            // lblRegistrationNumber
            // 
            this.lblRegistrationNumber.AutoSize = true;
            this.lblRegistrationNumber.Location = new System.Drawing.Point(18, 61);
            this.lblRegistrationNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrationNumber.Name = "lblRegistrationNumber";
            this.lblRegistrationNumber.Size = new System.Drawing.Size(148, 18);
            this.lblRegistrationNumber.TabIndex = 1;
            this.lblRegistrationNumber.Text = "Registration Number:";
            // 
            // lblVATNumber
            // 
            this.lblVATNumber.AutoSize = true;
            this.lblVATNumber.Location = new System.Drawing.Point(70, 28);
            this.lblVATNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVATNumber.Name = "lblVATNumber";
            this.lblVATNumber.Size = new System.Drawing.Size(96, 18);
            this.lblVATNumber.TabIndex = 0;
            this.lblVATNumber.Text = "VAT Number:";
            // 
            // lblExtraInformation
            // 
            this.lblExtraInformation.AutoSize = true;
            this.lblExtraInformation.Location = new System.Drawing.Point(22, 28);
            this.lblExtraInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraInformation.Name = "lblExtraInformation";
            this.lblExtraInformation.Size = new System.Drawing.Size(190, 18);
            this.lblExtraInformation.TabIndex = 1;
            this.lblExtraInformation.Text = "Customer Company Name:";
            // 
            // gbxCustomerAddress
            // 
            this.gbxCustomerAddress.Controls.Add(this.lblBusinessAddressDescription);
            this.gbxCustomerAddress.Controls.Add(this.txtCustomerAddresssDescription);
            this.gbxCustomerAddress.Controls.Add(this.btnViewAddresses);
            this.gbxCustomerAddress.Controls.Add(this.btnAddAddress);
            this.gbxCustomerAddress.Controls.Add(this.txtWorkPlace);
            this.gbxCustomerAddress.Controls.Add(this.lblWorkPlace);
            this.gbxCustomerAddress.Controls.Add(this.txtWorkArea);
            this.gbxCustomerAddress.Controls.Add(this.lblWorkArea);
            this.gbxCustomerAddress.Controls.Add(this.lblAttention);
            this.gbxCustomerAddress.Controls.Add(this.txtAtt);
            this.gbxCustomerAddress.Location = new System.Drawing.Point(12, 315);
            this.gbxCustomerAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCustomerAddress.Name = "gbxCustomerAddress";
            this.gbxCustomerAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCustomerAddress.Size = new System.Drawing.Size(526, 274);
            this.gbxCustomerAddress.TabIndex = 16;
            this.gbxCustomerAddress.TabStop = false;
            this.gbxCustomerAddress.Text = "Customer Delivery Address:";
            // 
            // lblBusinessAddressDescription
            // 
            this.lblBusinessAddressDescription.AutoSize = true;
            this.lblBusinessAddressDescription.Location = new System.Drawing.Point(42, 58);
            this.lblBusinessAddressDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessAddressDescription.Name = "lblBusinessAddressDescription";
            this.lblBusinessAddressDescription.Size = new System.Drawing.Size(87, 18);
            this.lblBusinessAddressDescription.TabIndex = 13;
            this.lblBusinessAddressDescription.Text = "Description:";
            // 
            // txtCustomerAddresssDescription
            // 
            this.txtCustomerAddresssDescription.Location = new System.Drawing.Point(137, 55);
            this.txtCustomerAddresssDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerAddresssDescription.Name = "txtCustomerAddresssDescription";
            this.txtCustomerAddresssDescription.Size = new System.Drawing.Size(372, 24);
            this.txtCustomerAddresssDescription.TabIndex = 6;
            // 
            // lblWorkPlace
            // 
            this.lblWorkPlace.AutoSize = true;
            this.lblWorkPlace.Location = new System.Drawing.Point(39, 157);
            this.lblWorkPlace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkPlace.Name = "lblWorkPlace";
            this.lblWorkPlace.Size = new System.Drawing.Size(90, 18);
            this.lblWorkPlace.TabIndex = 6;
            this.lblWorkPlace.Text = "Work Place:";
            // 
            // txtWorkArea
            // 
            this.txtWorkArea.Location = new System.Drawing.Point(137, 122);
            this.txtWorkArea.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkArea.Name = "txtWorkArea";
            this.txtWorkArea.Size = new System.Drawing.Size(372, 24);
            this.txtWorkArea.TabIndex = 8;
            // 
            // lblWorkArea
            // 
            this.lblWorkArea.AutoSize = true;
            this.lblWorkArea.Location = new System.Drawing.Point(46, 125);
            this.lblWorkArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkArea.Name = "lblWorkArea";
            this.lblWorkArea.Size = new System.Drawing.Size(83, 18);
            this.lblWorkArea.TabIndex = 4;
            this.lblWorkArea.Text = "Work Area:";
            // 
            // lblAttention
            // 
            this.lblAttention.AutoSize = true;
            this.lblAttention.Location = new System.Drawing.Point(60, 93);
            this.lblAttention.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(69, 18);
            this.lblAttention.TabIndex = 3;
            this.lblAttention.Text = "Attention:";
            // 
            // txtAtt
            // 
            this.txtAtt.Location = new System.Drawing.Point(137, 90);
            this.txtAtt.Margin = new System.Windows.Forms.Padding(4);
            this.txtAtt.Name = "txtAtt";
            this.txtAtt.Size = new System.Drawing.Size(372, 24);
            this.txtAtt.TabIndex = 7;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(9, 90);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(153, 32);
            this.btnViewAll.TabIndex = 15;
            this.btnViewAll.Text = "View All Numbers";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // mtxtCellphoneNumber
            // 
            this.mtxtCellphoneNumber.Location = new System.Drawing.Point(170, 57);
            this.mtxtCellphoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtCellphoneNumber.Mask = "000-000-0000";
            this.mtxtCellphoneNumber.Name = "mtxtCellphoneNumber";
            this.mtxtCellphoneNumber.Size = new System.Drawing.Size(154, 24);
            this.mtxtCellphoneNumber.TabIndex = 13;
            // 
            // mtxtTelephoneNumber
            // 
            this.mtxtTelephoneNumber.Location = new System.Drawing.Point(170, 25);
            this.mtxtTelephoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtTelephoneNumber.Mask = "(999) 000-0000";
            this.mtxtTelephoneNumber.Name = "mtxtTelephoneNumber";
            this.mtxtTelephoneNumber.Size = new System.Drawing.Size(154, 24);
            this.mtxtTelephoneNumber.TabIndex = 12;
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(378, 88);
            this.btnAddNumber.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(140, 32);
            this.btnAddNumber.TabIndex = 14;
            this.btnAddNumber.Text = "Add Number/s";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.BtnAddNumber_Click);
            // 
            // lblCellphoneNumber
            // 
            this.lblCellphoneNumber.AutoSize = true;
            this.lblCellphoneNumber.Location = new System.Drawing.Point(27, 60);
            this.lblCellphoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCellphoneNumber.Name = "lblCellphoneNumber";
            this.lblCellphoneNumber.Size = new System.Drawing.Size(135, 18);
            this.lblCellphoneNumber.TabIndex = 1;
            this.lblCellphoneNumber.Text = "Cellphone Number:";
            this.lblCellphoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxPhoneRelated
            // 
            this.gbxPhoneRelated.Controls.Add(this.btnViewAll);
            this.gbxPhoneRelated.Controls.Add(this.mtxtCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.mtxtTelephoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.btnAddNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblTelephoneNumber);
            this.gbxPhoneRelated.Location = new System.Drawing.Point(549, 37);
            this.gbxPhoneRelated.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPhoneRelated.Name = "gbxPhoneRelated";
            this.gbxPhoneRelated.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPhoneRelated.Size = new System.Drawing.Size(526, 132);
            this.gbxPhoneRelated.TabIndex = 14;
            this.gbxPhoneRelated.TabStop = false;
            this.gbxPhoneRelated.Text = "Phone Related:";
            // 
            // lblTelephoneNumber
            // 
            this.lblTelephoneNumber.AutoSize = true;
            this.lblTelephoneNumber.Location = new System.Drawing.Point(24, 28);
            this.lblTelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelephoneNumber.Name = "lblTelephoneNumber";
            this.lblTelephoneNumber.Size = new System.Drawing.Size(138, 18);
            this.lblTelephoneNumber.TabIndex = 0;
            this.lblTelephoneNumber.Text = "Telephone Number:";
            this.lblTelephoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 637);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.gbxEmailRelated);
            this.Controls.Add(this.gbxPOBoxAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.msCustomerControls);
            this.Controls.Add(this.gbxCustomerInformation);
            this.Controls.Add(this.gbxCustomerAddress);
            this.Controls.Add(this.gbxPhoneRelated);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Customer";
            this.Load += new System.EventHandler(this.FrmAddCustomer_Load);
            this.gbxEmailRelated.ResumeLayout(false);
            this.gbxEmailRelated.PerformLayout();
            this.gbxPOBoxAddress.ResumeLayout(false);
            this.gbxPOBoxAddress.PerformLayout();
            this.msCustomerControls.ResumeLayout(false);
            this.msCustomerControls.PerformLayout();
            this.gbxCustomerInformation.ResumeLayout(false);
            this.gbxCustomerInformation.PerformLayout();
            this.gbxLegalInformation.ResumeLayout(false);
            this.gbxLegalInformation.PerformLayout();
            this.gbxCustomerAddress.ResumeLayout(false);
            this.gbxCustomerAddress.PerformLayout();
            this.gbxPhoneRelated.ResumeLayout(false);
            this.gbxPhoneRelated.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.GroupBox gbxEmailRelated;
        private System.Windows.Forms.Button btnViewEmailAddresses;
        private System.Windows.Forms.MaskedTextBox mtxtEmailAddress;
        private System.Windows.Forms.Button BtnAddEmail;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.GroupBox gbxPOBoxAddress;
        private System.Windows.Forms.Button btnViewAllPOBoxAddresses;
        private System.Windows.Forms.Label lblPOBoxAreaCode;
        private System.Windows.Forms.Button btnAddPOBoxAddress;
        private System.Windows.Forms.MaskedTextBox mtxtPOBoxAreaCode;
        private System.Windows.Forms.TextBox txtPOBoxCity;
        private System.Windows.Forms.Label lblPOBoxCity;
        private System.Windows.Forms.TextBox txtPOBoxSuburb;
        private System.Windows.Forms.Label lblPOBoxSuburb;
        private System.Windows.Forms.MaskedTextBox mtxtPOBoxStreetNumber;
        private System.Windows.Forms.Label lblPOBoxStreetNumber;
        private System.Windows.Forms.Button btnViewAddresses;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtWorkPlace;
        private System.Windows.Forms.MenuStrip msCustomerControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxCustomerInformation;
        private System.Windows.Forms.GroupBox gbxLegalInformation;
        private System.Windows.Forms.MaskedTextBox mtxtRegistrationNumber;
        private System.Windows.Forms.MaskedTextBox mtxtVATNumber;
        private System.Windows.Forms.Label lblRegistrationNumber;
        private System.Windows.Forms.Label lblVATNumber;
        private System.Windows.Forms.Label lblExtraInformation;
        private System.Windows.Forms.GroupBox gbxCustomerAddress;
        private System.Windows.Forms.Label lblWorkPlace;
        private System.Windows.Forms.TextBox txtWorkArea;
        private System.Windows.Forms.Label lblWorkArea;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.TextBox txtAtt;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.MaskedTextBox mtxtCellphoneNumber;
        private System.Windows.Forms.MaskedTextBox mtxtTelephoneNumber;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.Label lblCellphoneNumber;
        private System.Windows.Forms.GroupBox gbxPhoneRelated;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.TextBox txtCustomerCompanyName;
        private System.Windows.Forms.ComboBox cbBusinessSelection;
        private System.Windows.Forms.Label lblLinkCustomerTo;
        private System.Windows.Forms.ToolStripMenuItem updatedCustomerInformationToolStripMenuItem;
        private System.Windows.Forms.Label lblBusinessAddressDescription;
        private System.Windows.Forms.TextBox txtCustomerAddresssDescription;
        private System.Windows.Forms.Label lblBusinessPODescription;
        private System.Windows.Forms.TextBox txtCustomerPODescription;
        private System.Windows.Forms.MaskedTextBox mtxtVendorNumber;
        private System.Windows.Forms.Label lblVendorNumebr;
    }
}