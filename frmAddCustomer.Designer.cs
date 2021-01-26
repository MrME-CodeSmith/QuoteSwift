
namespace QuoteSwift
{
    partial class frmAddCustomer
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
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.mtxtAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.gbxEmailRelated = new System.Windows.Forms.GroupBox();
            this.btnViewEmailAddresses = new System.Windows.Forms.Button();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.gbxPOBoxAddress = new System.Windows.Forms.GroupBox();
            this.btnViewAllPOBoxAddresses = new System.Windows.Forms.Button();
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
            this.btnViewAddresses = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.msCustomerControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxCustomerInformation = new System.Windows.Forms.GroupBox();
            this.cbBusinessSelection = new System.Windows.Forms.ComboBox();
            this.lblLinkCustomerTo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbxLegalInformation = new System.Windows.Forms.GroupBox();
            this.mtxtRegistrationNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtVATNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblRegistrationNumber = new System.Windows.Forms.Label();
            this.lblVATNumber = new System.Windows.Forms.Label();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.lblExtraInformation = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.gbxCustomerAddress = new System.Windows.Forms.GroupBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.mtxtStreetnumber = new System.Windows.Forms.MaskedTextBox();
            this.lblBusinessStreetNumber = new System.Windows.Forms.Label();
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
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(24, 145);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(60, 13);
            this.lblAreaCode.TabIndex = 9;
            this.lblAreaCode.Text = "Area Code:";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(246, 173);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(93, 23);
            this.btnAddAddress.TabIndex = 6;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            // 
            // mtxtAreaCode
            // 
            this.mtxtAreaCode.Location = new System.Drawing.Point(90, 142);
            this.mtxtAreaCode.Mask = "00000";
            this.mtxtAreaCode.Name = "mtxtAreaCode";
            this.mtxtAreaCode.Size = new System.Drawing.Size(49, 20);
            this.mtxtAreaCode.TabIndex = 8;
            this.mtxtAreaCode.ValidatingType = typeof(int);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(623, 443);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(93, 23);
            this.btnAddCustomer.TabIndex = 17;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // gbxEmailRelated
            // 
            this.gbxEmailRelated.Controls.Add(this.btnViewEmailAddresses);
            this.gbxEmailRelated.Controls.Add(this.maskedTextBox2);
            this.gbxEmailRelated.Controls.Add(this.button2);
            this.gbxEmailRelated.Controls.Add(this.lblEmailAddress);
            this.gbxEmailRelated.Location = new System.Drawing.Point(365, 140);
            this.gbxEmailRelated.Name = "gbxEmailRelated";
            this.gbxEmailRelated.Size = new System.Drawing.Size(352, 89);
            this.gbxEmailRelated.TabIndex = 15;
            this.gbxEmailRelated.TabStop = false;
            this.gbxEmailRelated.Text = "Email Related:";
            // 
            // btnViewEmailAddresses
            // 
            this.btnViewEmailAddresses.Location = new System.Drawing.Point(9, 58);
            this.btnViewEmailAddresses.Name = "btnViewEmailAddresses";
            this.btnViewEmailAddresses.Size = new System.Drawing.Size(135, 23);
            this.btnViewEmailAddresses.TabIndex = 7;
            this.btnViewEmailAddresses.Text = "View All Email Addresses";
            this.btnViewEmailAddresses.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(88, 26);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(257, 20);
            this.maskedTextBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add Email Address";
            this.button2.UseVisualStyleBackColor = true;
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
            this.gbxPOBoxAddress.Controls.Add(this.btnViewAllPOBoxAddresses);
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
            this.gbxPOBoxAddress.Location = new System.Drawing.Point(365, 235);
            this.gbxPOBoxAddress.Name = "gbxPOBoxAddress";
            this.gbxPOBoxAddress.Size = new System.Drawing.Size(351, 202);
            this.gbxPOBoxAddress.TabIndex = 18;
            this.gbxPOBoxAddress.TabStop = false;
            this.gbxPOBoxAddress.Text = "Customer P.O.Box Address:";
            // 
            // btnViewAllPOBoxAddresses
            // 
            this.btnViewAllPOBoxAddresses.Location = new System.Drawing.Point(6, 173);
            this.btnViewAllPOBoxAddresses.Name = "btnViewAllPOBoxAddresses";
            this.btnViewAllPOBoxAddresses.Size = new System.Drawing.Size(112, 23);
            this.btnViewAllPOBoxAddresses.TabIndex = 7;
            this.btnViewAllPOBoxAddresses.Text = "View All Addresses";
            this.btnViewAllPOBoxAddresses.UseVisualStyleBackColor = true;
            // 
            // lblPOBoxAreaCode
            // 
            this.lblPOBoxAreaCode.AutoSize = true;
            this.lblPOBoxAreaCode.Location = new System.Drawing.Point(24, 145);
            this.lblPOBoxAreaCode.Name = "lblPOBoxAreaCode";
            this.lblPOBoxAreaCode.Size = new System.Drawing.Size(60, 13);
            this.lblPOBoxAreaCode.TabIndex = 9;
            this.lblPOBoxAreaCode.Text = "Area Code:";
            // 
            // btnAddPOBoxAddress
            // 
            this.btnAddPOBoxAddress.Location = new System.Drawing.Point(246, 173);
            this.btnAddPOBoxAddress.Name = "btnAddPOBoxAddress";
            this.btnAddPOBoxAddress.Size = new System.Drawing.Size(93, 23);
            this.btnAddPOBoxAddress.TabIndex = 6;
            this.btnAddPOBoxAddress.Text = "Add Address";
            this.btnAddPOBoxAddress.UseVisualStyleBackColor = true;
            // 
            // mtxtPOBoxAreaCode
            // 
            this.mtxtPOBoxAreaCode.Location = new System.Drawing.Point(90, 142);
            this.mtxtPOBoxAreaCode.Mask = "00000";
            this.mtxtPOBoxAreaCode.Name = "mtxtPOBoxAreaCode";
            this.mtxtPOBoxAreaCode.Size = new System.Drawing.Size(49, 20);
            this.mtxtPOBoxAreaCode.TabIndex = 8;
            this.mtxtPOBoxAreaCode.ValidatingType = typeof(int);
            // 
            // txtPOBoxCity
            // 
            this.txtPOBoxCity.Location = new System.Drawing.Point(90, 112);
            this.txtPOBoxCity.Name = "txtPOBoxCity";
            this.txtPOBoxCity.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxCity.TabIndex = 7;
            // 
            // lblPOBoxCity
            // 
            this.lblPOBoxCity.AutoSize = true;
            this.lblPOBoxCity.Location = new System.Drawing.Point(57, 115);
            this.lblPOBoxCity.Name = "lblPOBoxCity";
            this.lblPOBoxCity.Size = new System.Drawing.Size(27, 13);
            this.lblPOBoxCity.TabIndex = 6;
            this.lblPOBoxCity.Text = "City:";
            // 
            // txtPOBoxSuburb
            // 
            this.txtPOBoxSuburb.Location = new System.Drawing.Point(90, 82);
            this.txtPOBoxSuburb.Name = "txtPOBoxSuburb";
            this.txtPOBoxSuburb.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxSuburb.TabIndex = 5;
            // 
            // lblPOBoxSuburb
            // 
            this.lblPOBoxSuburb.AutoSize = true;
            this.lblPOBoxSuburb.Location = new System.Drawing.Point(40, 85);
            this.lblPOBoxSuburb.Name = "lblPOBoxSuburb";
            this.lblPOBoxSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblPOBoxSuburb.TabIndex = 4;
            this.lblPOBoxSuburb.Text = "Suburb:";
            // 
            // lblPOBoxStreetName
            // 
            this.lblPOBoxStreetName.AutoSize = true;
            this.lblPOBoxStreetName.Location = new System.Drawing.Point(15, 55);
            this.lblPOBoxStreetName.Name = "lblPOBoxStreetName";
            this.lblPOBoxStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblPOBoxStreetName.TabIndex = 3;
            this.lblPOBoxStreetName.Text = "Street Name:";
            // 
            // txtPOBoxStreetName
            // 
            this.txtPOBoxStreetName.Location = new System.Drawing.Point(90, 52);
            this.txtPOBoxStreetName.Name = "txtPOBoxStreetName";
            this.txtPOBoxStreetName.Size = new System.Drawing.Size(249, 20);
            this.txtPOBoxStreetName.TabIndex = 2;
            // 
            // mtxtPOBoxStreetNumber
            // 
            this.mtxtPOBoxStreetNumber.Location = new System.Drawing.Point(90, 23);
            this.mtxtPOBoxStreetNumber.Mask = "00000";
            this.mtxtPOBoxStreetNumber.Name = "mtxtPOBoxStreetNumber";
            this.mtxtPOBoxStreetNumber.Size = new System.Drawing.Size(49, 20);
            this.mtxtPOBoxStreetNumber.TabIndex = 1;
            this.mtxtPOBoxStreetNumber.ValidatingType = typeof(int);
            // 
            // lblPOBoxStreetNumber
            // 
            this.lblPOBoxStreetNumber.AutoSize = true;
            this.lblPOBoxStreetNumber.Location = new System.Drawing.Point(6, 25);
            this.lblPOBoxStreetNumber.Name = "lblPOBoxStreetNumber";
            this.lblPOBoxStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPOBoxStreetNumber.TabIndex = 0;
            this.lblPOBoxStreetNumber.Text = "Street Number:";
            // 
            // btnViewAddresses
            // 
            this.btnViewAddresses.Location = new System.Drawing.Point(6, 173);
            this.btnViewAddresses.Name = "btnViewAddresses";
            this.btnViewAddresses.Size = new System.Drawing.Size(112, 23);
            this.btnViewAddresses.TabIndex = 7;
            this.btnViewAddresses.Text = "View All Addresses";
            this.btnViewAddresses.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(90, 112);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(249, 20);
            this.txtCity.TabIndex = 7;
            // 
            // msCustomerControls
            // 
            this.msCustomerControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msCustomerControls.Location = new System.Drawing.Point(0, 0);
            this.msCustomerControls.Name = "msCustomerControls";
            this.msCustomerControls.Size = new System.Drawing.Size(726, 24);
            this.msCustomerControls.TabIndex = 12;
            this.msCustomerControls.Text = "msCustomerControls";
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
            // gbxCustomerInformation
            // 
            this.gbxCustomerInformation.Controls.Add(this.cbBusinessSelection);
            this.gbxCustomerInformation.Controls.Add(this.lblLinkCustomerTo);
            this.gbxCustomerInformation.Controls.Add(this.textBox1);
            this.gbxCustomerInformation.Controls.Add(this.gbxLegalInformation);
            this.gbxCustomerInformation.Controls.Add(this.txtBusinessName);
            this.gbxCustomerInformation.Controls.Add(this.lblExtraInformation);
            this.gbxCustomerInformation.Controls.Add(this.lblCustomerName);
            this.gbxCustomerInformation.Location = new System.Drawing.Point(8, 27);
            this.gbxCustomerInformation.Name = "gbxCustomerInformation";
            this.gbxCustomerInformation.Size = new System.Drawing.Size(351, 202);
            this.gbxCustomerInformation.TabIndex = 13;
            this.gbxCustomerInformation.TabStop = false;
            this.gbxCustomerInformation.Text = "Customer Information:";
            // 
            // cbBusinessSelection
            // 
            this.cbBusinessSelection.FormattingEnabled = true;
            this.cbBusinessSelection.Location = new System.Drawing.Point(148, 82);
            this.cbBusinessSelection.Name = "cbBusinessSelection";
            this.cbBusinessSelection.Size = new System.Drawing.Size(197, 21);
            this.cbBusinessSelection.TabIndex = 7;
            // 
            // lblLinkCustomerTo
            // 
            this.lblLinkCustomerTo.AutoSize = true;
            this.lblLinkCustomerTo.Location = new System.Drawing.Point(49, 85);
            this.lblLinkCustomerTo.Name = "lblLinkCustomerTo";
            this.lblLinkCustomerTo.Size = new System.Drawing.Size(93, 13);
            this.lblLinkCustomerTo.TabIndex = 6;
            this.lblLinkCustomerTo.Text = "Link Customer To:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 5;
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
            this.mtxtRegistrationNumber.TabIndex = 3;
            // 
            // mtxtVATNumber
            // 
            this.mtxtVATNumber.Location = new System.Drawing.Point(118, 32);
            this.mtxtVATNumber.Name = "mtxtVATNumber";
            this.mtxtVATNumber.Size = new System.Drawing.Size(215, 20);
            this.mtxtVATNumber.TabIndex = 2;
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
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(148, 22);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(197, 20);
            this.txtBusinessName.TabIndex = 2;
            // 
            // lblExtraInformation
            // 
            this.lblExtraInformation.AutoSize = true;
            this.lblExtraInformation.Location = new System.Drawing.Point(10, 55);
            this.lblExtraInformation.Name = "lblExtraInformation";
            this.lblExtraInformation.Size = new System.Drawing.Size(132, 13);
            this.lblExtraInformation.TabIndex = 1;
            this.lblExtraInformation.Text = "Customer Company Name:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(59, 25);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(83, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Business Name:";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxCustomerAddress
            // 
            this.gbxCustomerAddress.Controls.Add(this.btnViewAddresses);
            this.gbxCustomerAddress.Controls.Add(this.lblAreaCode);
            this.gbxCustomerAddress.Controls.Add(this.btnAddAddress);
            this.gbxCustomerAddress.Controls.Add(this.mtxtAreaCode);
            this.gbxCustomerAddress.Controls.Add(this.txtCity);
            this.gbxCustomerAddress.Controls.Add(this.lblCity);
            this.gbxCustomerAddress.Controls.Add(this.txtSuburb);
            this.gbxCustomerAddress.Controls.Add(this.lblSuburb);
            this.gbxCustomerAddress.Controls.Add(this.lblStreetName);
            this.gbxCustomerAddress.Controls.Add(this.txtStreetName);
            this.gbxCustomerAddress.Controls.Add(this.mtxtStreetnumber);
            this.gbxCustomerAddress.Controls.Add(this.lblBusinessStreetNumber);
            this.gbxCustomerAddress.Location = new System.Drawing.Point(8, 235);
            this.gbxCustomerAddress.Name = "gbxCustomerAddress";
            this.gbxCustomerAddress.Size = new System.Drawing.Size(351, 202);
            this.gbxCustomerAddress.TabIndex = 16;
            this.gbxCustomerAddress.TabStop = false;
            this.gbxCustomerAddress.Text = "Customer Address:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(57, 115);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "City:";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(90, 82);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(249, 20);
            this.txtSuburb.TabIndex = 5;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(40, 85);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(44, 13);
            this.lblSuburb.TabIndex = 4;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Location = new System.Drawing.Point(15, 55);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(69, 13);
            this.lblStreetName.TabIndex = 3;
            this.lblStreetName.Text = "Street Name:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(90, 52);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(249, 20);
            this.txtStreetName.TabIndex = 2;
            // 
            // mtxtStreetnumber
            // 
            this.mtxtStreetnumber.Location = new System.Drawing.Point(90, 23);
            this.mtxtStreetnumber.Mask = "00000";
            this.mtxtStreetnumber.Name = "mtxtStreetnumber";
            this.mtxtStreetnumber.Size = new System.Drawing.Size(49, 20);
            this.mtxtStreetnumber.TabIndex = 1;
            this.mtxtStreetnumber.ValidatingType = typeof(int);
            // 
            // lblBusinessStreetNumber
            // 
            this.lblBusinessStreetNumber.AutoSize = true;
            this.lblBusinessStreetNumber.Location = new System.Drawing.Point(6, 25);
            this.lblBusinessStreetNumber.Name = "lblBusinessStreetNumber";
            this.lblBusinessStreetNumber.Size = new System.Drawing.Size(78, 13);
            this.lblBusinessStreetNumber.TabIndex = 0;
            this.lblBusinessStreetNumber.Text = "Street Number:";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(6, 78);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(102, 23);
            this.btnViewAll.TabIndex = 5;
            this.btnViewAll.Text = "View All Numbers";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // mtxtCellphoneNumber
            // 
            this.mtxtCellphoneNumber.Location = new System.Drawing.Point(114, 52);
            this.mtxtCellphoneNumber.Mask = "000-000-0000";
            this.mtxtCellphoneNumber.Name = "mtxtCellphoneNumber";
            this.mtxtCellphoneNumber.Size = new System.Drawing.Size(104, 20);
            this.mtxtCellphoneNumber.TabIndex = 4;
            // 
            // mtxtTelephoneNumber
            // 
            this.mtxtTelephoneNumber.Location = new System.Drawing.Point(114, 22);
            this.mtxtTelephoneNumber.Mask = "(999) 000-0000";
            this.mtxtTelephoneNumber.Name = "mtxtTelephoneNumber";
            this.mtxtTelephoneNumber.Size = new System.Drawing.Size(104, 20);
            this.mtxtTelephoneNumber.TabIndex = 3;
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Location = new System.Drawing.Point(252, 78);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(93, 23);
            this.btnAddNumber.TabIndex = 2;
            this.btnAddNumber.Text = "Add Number/s";
            this.btnAddNumber.UseVisualStyleBackColor = true;
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
            // gbxPhoneRelated
            // 
            this.gbxPhoneRelated.Controls.Add(this.btnViewAll);
            this.gbxPhoneRelated.Controls.Add(this.mtxtCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.mtxtTelephoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.btnAddNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblCellphoneNumber);
            this.gbxPhoneRelated.Controls.Add(this.lblTelephoneNumber);
            this.gbxPhoneRelated.Location = new System.Drawing.Point(365, 27);
            this.gbxPhoneRelated.Name = "gbxPhoneRelated";
            this.gbxPhoneRelated.Size = new System.Drawing.Size(351, 108);
            this.gbxPhoneRelated.TabIndex = 14;
            this.gbxPhoneRelated.TabStop = false;
            this.gbxPhoneRelated.Text = "Phone Related:";
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
            // frmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 471);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.gbxEmailRelated);
            this.Controls.Add(this.gbxPOBoxAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.msCustomerControls);
            this.Controls.Add(this.gbxCustomerInformation);
            this.Controls.Add(this.gbxCustomerAddress);
            this.Controls.Add(this.gbxPhoneRelated);
            this.Name = "frmAddCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddCustomer";
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

        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.MaskedTextBox mtxtAreaCode;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.GroupBox gbxEmailRelated;
        private System.Windows.Forms.Button btnViewEmailAddresses;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Label lblPOBoxStreetName;
        private System.Windows.Forms.TextBox txtPOBoxStreetName;
        private System.Windows.Forms.MaskedTextBox mtxtPOBoxStreetNumber;
        private System.Windows.Forms.Label lblPOBoxStreetNumber;
        private System.Windows.Forms.Button btnViewAddresses;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.MenuStrip msCustomerControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxCustomerInformation;
        private System.Windows.Forms.GroupBox gbxLegalInformation;
        private System.Windows.Forms.MaskedTextBox mtxtRegistrationNumber;
        private System.Windows.Forms.MaskedTextBox mtxtVATNumber;
        private System.Windows.Forms.Label lblRegistrationNumber;
        private System.Windows.Forms.Label lblVATNumber;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.Label lblExtraInformation;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox gbxCustomerAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.MaskedTextBox mtxtStreetnumber;
        private System.Windows.Forms.Label lblBusinessStreetNumber;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.MaskedTextBox mtxtCellphoneNumber;
        private System.Windows.Forms.MaskedTextBox mtxtTelephoneNumber;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.Label lblCellphoneNumber;
        private System.Windows.Forms.GroupBox gbxPhoneRelated;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbBusinessSelection;
        private System.Windows.Forms.Label lblLinkCustomerTo;
    }
}