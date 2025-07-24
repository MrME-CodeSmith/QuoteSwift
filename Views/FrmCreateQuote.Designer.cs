
namespace QuoteSwift.Views
{
    partial class FrmCreateQuote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msCreateNewQuoteControls = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewQuoteUsingThisQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBusinessDetails = new System.Windows.Forms.Panel();
            this.gbxBusinessInformation = new System.Windows.Forms.GroupBox();
            this.cbxBusinessEmailAddressSelection = new System.Windows.Forms.ComboBox();
            this.cbxBusinessCellphoneNumberSelection = new System.Windows.Forms.ComboBox();
            this.cbxBusinessTelephoneNumberSelection = new System.Windows.Forms.ComboBox();
            this.lblBusinessVATNumber = new System.Windows.Forms.Label();
            this.lblBusinessRegistrationNumber = new System.Windows.Forms.Label();
            this.gbxBusinessPOBoxDetails = new System.Windows.Forms.GroupBox();
            this.CbxPOBoxSelection = new System.Windows.Forms.ComboBox();
            this.lblBusinessPOBoxAreaCode = new System.Windows.Forms.Label();
            this.lblBusinessPOBoxCity = new System.Windows.Forms.Label();
            this.lblBusinessPOBoxSuburb = new System.Windows.Forms.Label();
            this.lblBusinessPOBoxNumber = new System.Windows.Forms.Label();
            this.cbxBusinessSelection = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpQuoteExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpQuoteCreationDate = new System.Windows.Forms.DateTimePicker();
            this.lblQuoteExpiryDate = new System.Windows.Forms.Label();
            this.lblQuoteCreationDate = new System.Windows.Forms.Label();
            this.gbxQuoteNumberManagement = new System.Windows.Forms.GroupBox();
            this.cbxUseAutomaticNumberingScheme = new System.Windows.Forms.CheckBox();
            this.lblQuoteNumberText = new System.Windows.Forms.Label();
            this.txtQuoteNumber = new System.Windows.Forms.TextBox();
            this.lblQuoteNumber = new System.Windows.Forms.Label();
            this.lblQuote = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCustomerSelection = new System.Windows.Forms.Label();
            this.lblCustomerVendorNumber = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CbxCustomerPOBoxSelection = new System.Windows.Forms.ComboBox();
            this.lblCustomerPOBoxStreetName = new System.Windows.Forms.Label();
            this.lblCustomerPOBoxAreaCode = new System.Windows.Forms.Label();
            this.lblCustomerPOBoxCity = new System.Windows.Forms.Label();
            this.lblCustomerPOBoxSuburb = new System.Windows.Forms.Label();
            this.cbxCustomerSelection = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCustomerDeliveryAddress = new System.Windows.Forms.Label();
            this.gbxCustomerDeliveryAddressInformation = new System.Windows.Forms.GroupBox();
            this.rtxCustomerDeliveryDescripton = new System.Windows.Forms.RichTextBox();
            this.cbxCustomerDeliveryAddress = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpPaymentTerm = new System.Windows.Forms.DateTimePicker();
            this.txtLineNumber = new System.Windows.Forms.TextBox();
            this.txtPRNumber = new System.Windows.Forms.TextBox();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerVATNumber = new System.Windows.Forms.TextBox();
            this.lblTerms = new System.Windows.Forms.Label();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.lblPRNumber = new System.Windows.Forms.Label();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.lblCustomerVATNumber = new System.Windows.Forms.Label();
            this.pnlPumpDetails = new System.Windows.Forms.Panel();
            this.gbxPumpRestorationDetails = new System.Windows.Forms.GroupBox();
            this.lblNewParts = new System.Windows.Forms.Label();
            this.DgvNonMandatoryPartReplacement = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMMissing_Scrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMRepaired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMNewPartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNMRepairDevider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMandatoryParts = new System.Windows.Forms.Label();
            this.dgvMandatoryPartReplacement = new System.Windows.Forms.DataGridView();
            this.clmPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMMissing_Scrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMRepaired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmRepairDevider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxPumpSelection = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.mtxtRebate = new QuoteSwift.Controls.NumericTextBox();
            this.BtnCalculateRebate = new System.Windows.Forms.Button();
            this.lblRebateTestInput = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblTotalDueValue = new System.Windows.Forms.Label();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblVATValue = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRebateValue = new System.Windows.Forms.Label();
            this.lblRebate = new System.Windows.Forms.Label();
            this.lblRepairPercentage = new System.Windows.Forms.Label();
            this.lblNewPumpUnitPrice = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sfdSaveExport = new System.Windows.Forms.SaveFileDialog();
            this.msCreateNewQuoteControls.SuspendLayout();
            this.pnlBusinessDetails.SuspendLayout();
            this.gbxBusinessInformation.SuspendLayout();
            this.gbxBusinessPOBoxDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxQuoteNumberManagement.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbxCustomerDeliveryAddressInformation.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlPumpDetails.SuspendLayout();
            this.gbxPumpRestorationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNonMandatoryPartReplacement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartReplacement)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // msCreateNewQuoteControls
            // 
            this.msCreateNewQuoteControls.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.msCreateNewQuoteControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msCreateNewQuoteControls.Location = new System.Drawing.Point(0, 0);
            this.msCreateNewQuoteControls.Name = "msCreateNewQuoteControls";
            this.msCreateNewQuoteControls.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msCreateNewQuoteControls.Size = new System.Drawing.Size(1700, 30);
            this.msCreateNewQuoteControls.TabIndex = 0;
            this.msCreateNewQuoteControls.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewQuoteUsingThisQuoteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewQuoteUsingThisQuoteToolStripMenuItem
            // 
            this.createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = false;
            this.createNewQuoteUsingThisQuoteToolStripMenuItem.Name = "createNewQuoteUsingThisQuoteToolStripMenuItem";
            this.createNewQuoteUsingThisQuoteToolStripMenuItem.Size = new System.Drawing.Size(316, 24);
            this.createNewQuoteUsingThisQuoteToolStripMenuItem.Text = "Create New Quote Using This Quote";
            this.createNewQuoteUsingThisQuoteToolStripMenuItem.Click += new System.EventHandler(this.CreateNewQuoteUsingThisQuoteToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // pnlBusinessDetails
            // 
            this.pnlBusinessDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusinessDetails.Controls.Add(this.gbxBusinessInformation);
            this.pnlBusinessDetails.Controls.Add(this.gbxBusinessPOBoxDetails);
            this.pnlBusinessDetails.Controls.Add(this.cbxBusinessSelection);
            this.pnlBusinessDetails.Location = new System.Drawing.Point(15, 37);
            this.pnlBusinessDetails.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBusinessDetails.Name = "pnlBusinessDetails";
            this.pnlBusinessDetails.Size = new System.Drawing.Size(410, 462);
            this.pnlBusinessDetails.TabIndex = 1;
            // 
            // gbxBusinessInformation
            // 
            this.gbxBusinessInformation.Controls.Add(this.cbxBusinessEmailAddressSelection);
            this.gbxBusinessInformation.Controls.Add(this.cbxBusinessCellphoneNumberSelection);
            this.gbxBusinessInformation.Controls.Add(this.cbxBusinessTelephoneNumberSelection);
            this.gbxBusinessInformation.Controls.Add(this.lblBusinessVATNumber);
            this.gbxBusinessInformation.Controls.Add(this.lblBusinessRegistrationNumber);
            this.gbxBusinessInformation.Location = new System.Drawing.Point(8, 255);
            this.gbxBusinessInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxBusinessInformation.Name = "gbxBusinessInformation";
            this.gbxBusinessInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxBusinessInformation.Size = new System.Drawing.Size(389, 195);
            this.gbxBusinessInformation.TabIndex = 3;
            this.gbxBusinessInformation.TabStop = false;
            this.gbxBusinessInformation.Text = "Business Information:";
            // 
            // cbxBusinessEmailAddressSelection
            // 
            this.cbxBusinessEmailAddressSelection.FormattingEnabled = true;
            this.cbxBusinessEmailAddressSelection.Location = new System.Drawing.Point(11, 153);
            this.cbxBusinessEmailAddressSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBusinessEmailAddressSelection.Name = "cbxBusinessEmailAddressSelection";
            this.cbxBusinessEmailAddressSelection.Size = new System.Drawing.Size(320, 26);
            this.cbxBusinessEmailAddressSelection.TabIndex = 5;
            this.cbxBusinessEmailAddressSelection.Text = "cbxBusinessEmailAddressSelection";
            // 
            // cbxBusinessCellphoneNumberSelection
            // 
            this.cbxBusinessCellphoneNumberSelection.FormattingEnabled = true;
            this.cbxBusinessCellphoneNumberSelection.Location = new System.Drawing.Point(11, 119);
            this.cbxBusinessCellphoneNumberSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBusinessCellphoneNumberSelection.Name = "cbxBusinessCellphoneNumberSelection";
            this.cbxBusinessCellphoneNumberSelection.Size = new System.Drawing.Size(320, 26);
            this.cbxBusinessCellphoneNumberSelection.TabIndex = 4;
            this.cbxBusinessCellphoneNumberSelection.Text = "cbxBusinessCellphoneNumberSelection";
            // 
            // cbxBusinessTelephoneNumberSelection
            // 
            this.cbxBusinessTelephoneNumberSelection.FormattingEnabled = true;
            this.cbxBusinessTelephoneNumberSelection.Location = new System.Drawing.Point(11, 85);
            this.cbxBusinessTelephoneNumberSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBusinessTelephoneNumberSelection.Name = "cbxBusinessTelephoneNumberSelection";
            this.cbxBusinessTelephoneNumberSelection.Size = new System.Drawing.Size(320, 26);
            this.cbxBusinessTelephoneNumberSelection.TabIndex = 3;
            this.cbxBusinessTelephoneNumberSelection.Text = "cbxBusinessTelephoneNumberSelection";
            // 
            // lblBusinessVATNumber
            // 
            this.lblBusinessVATNumber.AutoSize = true;
            this.lblBusinessVATNumber.Location = new System.Drawing.Point(8, 60);
            this.lblBusinessVATNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessVATNumber.Name = "lblBusinessVATNumber";
            this.lblBusinessVATNumber.Size = new System.Drawing.Size(163, 18);
            this.lblBusinessVATNumber.TabIndex = 1;
            this.lblBusinessVATNumber.Text = "lblBusinessVATNumber";
            // 
            // lblBusinessRegistrationNumber
            // 
            this.lblBusinessRegistrationNumber.AutoSize = true;
            this.lblBusinessRegistrationNumber.Location = new System.Drawing.Point(8, 35);
            this.lblBusinessRegistrationNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessRegistrationNumber.Name = "lblBusinessRegistrationNumber";
            this.lblBusinessRegistrationNumber.Size = new System.Drawing.Size(215, 18);
            this.lblBusinessRegistrationNumber.TabIndex = 0;
            this.lblBusinessRegistrationNumber.Text = "lblBusinessRegistrationNumber";
            // 
            // gbxBusinessPOBoxDetails
            // 
            this.gbxBusinessPOBoxDetails.Controls.Add(this.CbxPOBoxSelection);
            this.gbxBusinessPOBoxDetails.Controls.Add(this.lblBusinessPOBoxAreaCode);
            this.gbxBusinessPOBoxDetails.Controls.Add(this.lblBusinessPOBoxCity);
            this.gbxBusinessPOBoxDetails.Controls.Add(this.lblBusinessPOBoxSuburb);
            this.gbxBusinessPOBoxDetails.Controls.Add(this.lblBusinessPOBoxNumber);
            this.gbxBusinessPOBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxBusinessPOBoxDetails.Location = new System.Drawing.Point(8, 46);
            this.gbxBusinessPOBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbxBusinessPOBoxDetails.Name = "gbxBusinessPOBoxDetails";
            this.gbxBusinessPOBoxDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbxBusinessPOBoxDetails.Size = new System.Drawing.Size(385, 193);
            this.gbxBusinessPOBoxDetails.TabIndex = 2;
            this.gbxBusinessPOBoxDetails.TabStop = false;
            this.gbxBusinessPOBoxDetails.Text = "Business P.O. Box Address:";
            // 
            // CbxPOBoxSelection
            // 
            this.CbxPOBoxSelection.FormattingEnabled = true;
            this.CbxPOBoxSelection.Location = new System.Drawing.Point(9, 25);
            this.CbxPOBoxSelection.Margin = new System.Windows.Forms.Padding(4);
            this.CbxPOBoxSelection.Name = "CbxPOBoxSelection";
            this.CbxPOBoxSelection.Size = new System.Drawing.Size(315, 26);
            this.CbxPOBoxSelection.TabIndex = 2;
            this.CbxPOBoxSelection.Text = "Business Selection";
            // 
            // lblBusinessPOBoxAreaCode
            // 
            this.lblBusinessPOBoxAreaCode.AutoSize = true;
            this.lblBusinessPOBoxAreaCode.Location = new System.Drawing.Point(6, 147);
            this.lblBusinessPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPOBoxAreaCode.Name = "lblBusinessPOBoxAreaCode";
            this.lblBusinessPOBoxAreaCode.Size = new System.Drawing.Size(197, 18);
            this.lblBusinessPOBoxAreaCode.TabIndex = 4;
            this.lblBusinessPOBoxAreaCode.Text = "lblBusinessPOBoxAreaCode";
            // 
            // lblBusinessPOBoxCity
            // 
            this.lblBusinessPOBoxCity.AutoSize = true;
            this.lblBusinessPOBoxCity.Location = new System.Drawing.Point(6, 122);
            this.lblBusinessPOBoxCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPOBoxCity.Name = "lblBusinessPOBoxCity";
            this.lblBusinessPOBoxCity.Size = new System.Drawing.Size(156, 18);
            this.lblBusinessPOBoxCity.TabIndex = 2;
            this.lblBusinessPOBoxCity.Text = "lblBusinessPOBoxCity";
            // 
            // lblBusinessPOBoxSuburb
            // 
            this.lblBusinessPOBoxSuburb.AutoSize = true;
            this.lblBusinessPOBoxSuburb.Location = new System.Drawing.Point(6, 97);
            this.lblBusinessPOBoxSuburb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPOBoxSuburb.Name = "lblBusinessPOBoxSuburb";
            this.lblBusinessPOBoxSuburb.Size = new System.Drawing.Size(178, 18);
            this.lblBusinessPOBoxSuburb.TabIndex = 1;
            this.lblBusinessPOBoxSuburb.Text = "lblBusinessPOBoxSuburb";
            // 
            // lblBusinessPOBoxNumber
            // 
            this.lblBusinessPOBoxNumber.AutoSize = true;
            this.lblBusinessPOBoxNumber.Location = new System.Drawing.Point(6, 72);
            this.lblBusinessPOBoxNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusinessPOBoxNumber.Name = "lblBusinessPOBoxNumber";
            this.lblBusinessPOBoxNumber.Size = new System.Drawing.Size(184, 18);
            this.lblBusinessPOBoxNumber.TabIndex = 0;
            this.lblBusinessPOBoxNumber.Text = "lblBusinessPOBoxNumber";
            // 
            // cbxBusinessSelection
            // 
            this.cbxBusinessSelection.FormattingEnabled = true;
            this.cbxBusinessSelection.Location = new System.Drawing.Point(4, 4);
            this.cbxBusinessSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBusinessSelection.Name = "cbxBusinessSelection";
            this.cbxBusinessSelection.Size = new System.Drawing.Size(389, 26);
            this.cbxBusinessSelection.TabIndex = 1;
            this.cbxBusinessSelection.Text = "Business Selection";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpQuoteExpiryDate);
            this.panel1.Controls.Add(this.dtpQuoteCreationDate);
            this.panel1.Controls.Add(this.lblQuoteExpiryDate);
            this.panel1.Controls.Add(this.lblQuoteCreationDate);
            this.panel1.Controls.Add(this.gbxQuoteNumberManagement);
            this.panel1.Controls.Add(this.lblQuote);
            this.panel1.Location = new System.Drawing.Point(433, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 462);
            this.panel1.TabIndex = 4;
            // 
            // dtpQuoteExpiryDate
            // 
            this.dtpQuoteExpiryDate.Location = new System.Drawing.Point(8, 354);
            this.dtpQuoteExpiryDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpQuoteExpiryDate.Name = "dtpQuoteExpiryDate";
            this.dtpQuoteExpiryDate.Size = new System.Drawing.Size(326, 24);
            this.dtpQuoteExpiryDate.TabIndex = 11;
            // 
            // dtpQuoteCreationDate
            // 
            this.dtpQuoteCreationDate.Location = new System.Drawing.Point(8, 281);
            this.dtpQuoteCreationDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpQuoteCreationDate.Name = "dtpQuoteCreationDate";
            this.dtpQuoteCreationDate.Size = new System.Drawing.Size(326, 24);
            this.dtpQuoteCreationDate.TabIndex = 10;
            // 
            // lblQuoteExpiryDate
            // 
            this.lblQuoteExpiryDate.AutoSize = true;
            this.lblQuoteExpiryDate.Location = new System.Drawing.Point(8, 324);
            this.lblQuoteExpiryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuoteExpiryDate.Name = "lblQuoteExpiryDate";
            this.lblQuoteExpiryDate.Size = new System.Drawing.Size(132, 18);
            this.lblQuoteExpiryDate.TabIndex = 3;
            this.lblQuoteExpiryDate.Text = "Quote Expiry Date:";
            // 
            // lblQuoteCreationDate
            // 
            this.lblQuoteCreationDate.AutoSize = true;
            this.lblQuoteCreationDate.Location = new System.Drawing.Point(8, 255);
            this.lblQuoteCreationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuoteCreationDate.Name = "lblQuoteCreationDate";
            this.lblQuoteCreationDate.Size = new System.Drawing.Size(148, 18);
            this.lblQuoteCreationDate.TabIndex = 2;
            this.lblQuoteCreationDate.Text = "Quote Creation Date:";
            // 
            // gbxQuoteNumberManagement
            // 
            this.gbxQuoteNumberManagement.Controls.Add(this.cbxUseAutomaticNumberingScheme);
            this.gbxQuoteNumberManagement.Controls.Add(this.lblQuoteNumberText);
            this.gbxQuoteNumberManagement.Controls.Add(this.txtQuoteNumber);
            this.gbxQuoteNumberManagement.Controls.Add(this.lblQuoteNumber);
            this.gbxQuoteNumberManagement.Location = new System.Drawing.Point(4, 42);
            this.gbxQuoteNumberManagement.Margin = new System.Windows.Forms.Padding(4);
            this.gbxQuoteNumberManagement.Name = "gbxQuoteNumberManagement";
            this.gbxQuoteNumberManagement.Padding = new System.Windows.Forms.Padding(4);
            this.gbxQuoteNumberManagement.Size = new System.Drawing.Size(400, 170);
            this.gbxQuoteNumberManagement.TabIndex = 1;
            this.gbxQuoteNumberManagement.TabStop = false;
            this.gbxQuoteNumberManagement.Text = "Quote Number Management:";
            // 
            // cbxUseAutomaticNumberingScheme
            // 
            this.cbxUseAutomaticNumberingScheme.AutoSize = true;
            this.cbxUseAutomaticNumberingScheme.Checked = true;
            this.cbxUseAutomaticNumberingScheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUseAutomaticNumberingScheme.Location = new System.Drawing.Point(10, 125);
            this.cbxUseAutomaticNumberingScheme.Margin = new System.Windows.Forms.Padding(4);
            this.cbxUseAutomaticNumberingScheme.Name = "cbxUseAutomaticNumberingScheme";
            this.cbxUseAutomaticNumberingScheme.Size = new System.Drawing.Size(291, 22);
            this.cbxUseAutomaticNumberingScheme.TabIndex = 9;
            this.cbxUseAutomaticNumberingScheme.Text = "Continue Automatic Numbering Scheme";
            this.cbxUseAutomaticNumberingScheme.UseVisualStyleBackColor = true;
            // 
            // lblQuoteNumberText
            // 
            this.lblQuoteNumberText.AutoSize = true;
            this.lblQuoteNumberText.Location = new System.Drawing.Point(9, 66);
            this.lblQuoteNumberText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuoteNumberText.Name = "lblQuoteNumberText";
            this.lblQuoteNumberText.Size = new System.Drawing.Size(110, 18);
            this.lblQuoteNumberText.TabIndex = 3;
            this.lblQuoteNumberText.Text = "Quote Number:";
            // 
            // txtQuoteNumber
            // 
            this.txtQuoteNumber.Location = new System.Drawing.Point(10, 89);
            this.txtQuoteNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuoteNumber.Name = "txtQuoteNumber";
            this.txtQuoteNumber.ReadOnly = true;
            this.txtQuoteNumber.Size = new System.Drawing.Size(217, 24);
            this.txtQuoteNumber.TabIndex = 8;
            // 
            // lblQuoteNumber
            // 
            this.lblQuoteNumber.AutoSize = true;
            this.lblQuoteNumber.Location = new System.Drawing.Point(138, 42);
            this.lblQuoteNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuoteNumber.Name = "lblQuoteNumber";
            this.lblQuoteNumber.Size = new System.Drawing.Size(116, 18);
            this.lblQuoteNumber.TabIndex = 0;
            this.lblQuoteNumber.Text = "lblQuoteNumber";
            // 
            // lblQuote
            // 
            this.lblQuote.AutoSize = true;
            this.lblQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuote.Location = new System.Drawing.Point(171, 1);
            this.lblQuote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(64, 22);
            this.lblQuote.TabIndex = 0;
            this.lblQuote.Text = "Quote";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCustomerSelection);
            this.panel2.Controls.Add(this.lblCustomerVendorNumber);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.cbxCustomerSelection);
            this.panel2.Location = new System.Drawing.Point(15, 507);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 301);
            this.panel2.TabIndex = 5;
            // 
            // lblCustomerSelection
            // 
            this.lblCustomerSelection.AutoSize = true;
            this.lblCustomerSelection.Location = new System.Drawing.Point(4, 11);
            this.lblCustomerSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerSelection.Name = "lblCustomerSelection";
            this.lblCustomerSelection.Size = new System.Drawing.Size(143, 18);
            this.lblCustomerSelection.TabIndex = 4;
            this.lblCustomerSelection.Text = "Customer Selection:";
            // 
            // lblCustomerVendorNumber
            // 
            this.lblCustomerVendorNumber.AutoSize = true;
            this.lblCustomerVendorNumber.Location = new System.Drawing.Point(14, 272);
            this.lblCustomerVendorNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerVendorNumber.Name = "lblCustomerVendorNumber";
            this.lblCustomerVendorNumber.Size = new System.Drawing.Size(188, 18);
            this.lblCustomerVendorNumber.TabIndex = 3;
            this.lblCustomerVendorNumber.Text = "lblCustomerVendorNumber";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CbxCustomerPOBoxSelection);
            this.groupBox2.Controls.Add(this.lblCustomerPOBoxStreetName);
            this.groupBox2.Controls.Add(this.lblCustomerPOBoxAreaCode);
            this.groupBox2.Controls.Add(this.lblCustomerPOBoxCity);
            this.groupBox2.Controls.Add(this.lblCustomerPOBoxSuburb);
            this.groupBox2.Location = new System.Drawing.Point(5, 71);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(388, 197);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer P.O. Box Address:";
            // 
            // CbxCustomerPOBoxSelection
            // 
            this.CbxCustomerPOBoxSelection.FormattingEnabled = true;
            this.CbxCustomerPOBoxSelection.Location = new System.Drawing.Point(15, 26);
            this.CbxCustomerPOBoxSelection.Margin = new System.Windows.Forms.Padding(4);
            this.CbxCustomerPOBoxSelection.Name = "CbxCustomerPOBoxSelection";
            this.CbxCustomerPOBoxSelection.Size = new System.Drawing.Size(312, 26);
            this.CbxCustomerPOBoxSelection.TabIndex = 7;
            this.CbxCustomerPOBoxSelection.Text = "Customer P.O.Box Selection";
            // 
            // lblCustomerPOBoxStreetName
            // 
            this.lblCustomerPOBoxStreetName.AutoSize = true;
            this.lblCustomerPOBoxStreetName.Location = new System.Drawing.Point(14, 73);
            this.lblCustomerPOBoxStreetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPOBoxStreetName.Name = "lblCustomerPOBoxStreetName";
            this.lblCustomerPOBoxStreetName.Size = new System.Drawing.Size(215, 18);
            this.lblCustomerPOBoxStreetName.TabIndex = 4;
            this.lblCustomerPOBoxStreetName.Text = "lblCustomerPOBoxStreetName";
            // 
            // lblCustomerPOBoxAreaCode
            // 
            this.lblCustomerPOBoxAreaCode.AutoSize = true;
            this.lblCustomerPOBoxAreaCode.Location = new System.Drawing.Point(14, 148);
            this.lblCustomerPOBoxAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPOBoxAreaCode.Name = "lblCustomerPOBoxAreaCode";
            this.lblCustomerPOBoxAreaCode.Size = new System.Drawing.Size(202, 18);
            this.lblCustomerPOBoxAreaCode.TabIndex = 3;
            this.lblCustomerPOBoxAreaCode.Text = "lblCustomerPOBoxAreaCode";
            // 
            // lblCustomerPOBoxCity
            // 
            this.lblCustomerPOBoxCity.AutoSize = true;
            this.lblCustomerPOBoxCity.Location = new System.Drawing.Point(14, 123);
            this.lblCustomerPOBoxCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPOBoxCity.Name = "lblCustomerPOBoxCity";
            this.lblCustomerPOBoxCity.Size = new System.Drawing.Size(161, 18);
            this.lblCustomerPOBoxCity.TabIndex = 2;
            this.lblCustomerPOBoxCity.Text = "lblCustomerPOBoxCity";
            // 
            // lblCustomerPOBoxSuburb
            // 
            this.lblCustomerPOBoxSuburb.AutoSize = true;
            this.lblCustomerPOBoxSuburb.Location = new System.Drawing.Point(14, 98);
            this.lblCustomerPOBoxSuburb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPOBoxSuburb.Name = "lblCustomerPOBoxSuburb";
            this.lblCustomerPOBoxSuburb.Size = new System.Drawing.Size(183, 18);
            this.lblCustomerPOBoxSuburb.TabIndex = 1;
            this.lblCustomerPOBoxSuburb.Text = "lblCustomerPOBoxSuburb";
            // 
            // cbxCustomerSelection
            // 
            this.cbxCustomerSelection.FormattingEnabled = true;
            this.cbxCustomerSelection.Location = new System.Drawing.Point(4, 33);
            this.cbxCustomerSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCustomerSelection.Name = "cbxCustomerSelection";
            this.cbxCustomerSelection.Size = new System.Drawing.Size(400, 26);
            this.cbxCustomerSelection.TabIndex = 6;
            this.cbxCustomerSelection.Text = "Customer Selection";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblCustomerDeliveryAddress);
            this.panel3.Controls.Add(this.gbxCustomerDeliveryAddressInformation);
            this.panel3.Controls.Add(this.cbxCustomerDeliveryAddress);
            this.panel3.Location = new System.Drawing.Point(433, 507);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 301);
            this.panel3.TabIndex = 6;
            // 
            // lblCustomerDeliveryAddress
            // 
            this.lblCustomerDeliveryAddress.AutoSize = true;
            this.lblCustomerDeliveryAddress.Location = new System.Drawing.Point(4, 11);
            this.lblCustomerDeliveryAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerDeliveryAddress.Name = "lblCustomerDeliveryAddress";
            this.lblCustomerDeliveryAddress.Size = new System.Drawing.Size(192, 18);
            this.lblCustomerDeliveryAddress.TabIndex = 5;
            this.lblCustomerDeliveryAddress.Text = "Customer Delivery Address:";
            // 
            // gbxCustomerDeliveryAddressInformation
            // 
            this.gbxCustomerDeliveryAddressInformation.Controls.Add(this.rtxCustomerDeliveryDescripton);
            this.gbxCustomerDeliveryAddressInformation.Location = new System.Drawing.Point(4, 71);
            this.gbxCustomerDeliveryAddressInformation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCustomerDeliveryAddressInformation.Name = "gbxCustomerDeliveryAddressInformation";
            this.gbxCustomerDeliveryAddressInformation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCustomerDeliveryAddressInformation.Size = new System.Drawing.Size(400, 197);
            this.gbxCustomerDeliveryAddressInformation.TabIndex = 2;
            this.gbxCustomerDeliveryAddressInformation.TabStop = false;
            this.gbxCustomerDeliveryAddressInformation.Text = "Customer Delivery Address Information:";
            // 
            // rtxCustomerDeliveryDescripton
            // 
            this.rtxCustomerDeliveryDescripton.Location = new System.Drawing.Point(8, 25);
            this.rtxCustomerDeliveryDescripton.Margin = new System.Windows.Forms.Padding(4);
            this.rtxCustomerDeliveryDescripton.Name = "rtxCustomerDeliveryDescripton";
            this.rtxCustomerDeliveryDescripton.Size = new System.Drawing.Size(384, 158);
            this.rtxCustomerDeliveryDescripton.TabIndex = 13;
            this.rtxCustomerDeliveryDescripton.Text = "rtxCustomerDeliveryDescripton";
            // 
            // cbxCustomerDeliveryAddress
            // 
            this.cbxCustomerDeliveryAddress.FormattingEnabled = true;
            this.cbxCustomerDeliveryAddress.Location = new System.Drawing.Point(4, 33);
            this.cbxCustomerDeliveryAddress.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCustomerDeliveryAddress.Name = "cbxCustomerDeliveryAddress";
            this.cbxCustomerDeliveryAddress.Size = new System.Drawing.Size(400, 26);
            this.cbxCustomerDeliveryAddress.TabIndex = 12;
            this.cbxCustomerDeliveryAddress.Text = "Customer Delivery Address Selection";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dtpPaymentTerm);
            this.panel4.Controls.Add(this.txtLineNumber);
            this.panel4.Controls.Add(this.txtPRNumber);
            this.panel4.Controls.Add(this.txtReferenceNumber);
            this.panel4.Controls.Add(this.txtJobNumber);
            this.panel4.Controls.Add(this.txtCustomerVATNumber);
            this.panel4.Controls.Add(this.lblTerms);
            this.panel4.Controls.Add(this.lblLineNumber);
            this.panel4.Controls.Add(this.lblPRNumber);
            this.panel4.Controls.Add(this.lblReferenceNumber);
            this.panel4.Controls.Add(this.lblJobNumber);
            this.panel4.Controls.Add(this.lblCustomerVATNumber);
            this.panel4.Location = new System.Drawing.Point(15, 830);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(828, 113);
            this.panel4.TabIndex = 7;
            // 
            // dtpPaymentTerm
            // 
            this.dtpPaymentTerm.Location = new System.Drawing.Point(557, 69);
            this.dtpPaymentTerm.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPaymentTerm.Name = "dtpPaymentTerm";
            this.dtpPaymentTerm.Size = new System.Drawing.Size(265, 24);
            this.dtpPaymentTerm.TabIndex = 19;
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Location = new System.Drawing.Point(557, 37);
            this.txtLineNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(265, 24);
            this.txtLineNumber.TabIndex = 18;
            // 
            // txtPRNumber
            // 
            this.txtPRNumber.Location = new System.Drawing.Point(557, 5);
            this.txtPRNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPRNumber.Name = "txtPRNumber";
            this.txtPRNumber.Size = new System.Drawing.Size(265, 24);
            this.txtPRNumber.TabIndex = 17;
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(181, 69);
            this.txtReferenceNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(265, 24);
            this.txtReferenceNumber.TabIndex = 16;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(181, 37);
            this.txtJobNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(265, 24);
            this.txtJobNumber.TabIndex = 15;
            // 
            // txtCustomerVATNumber
            // 
            this.txtCustomerVATNumber.Location = new System.Drawing.Point(181, 5);
            this.txtCustomerVATNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerVATNumber.Name = "txtCustomerVATNumber";
            this.txtCustomerVATNumber.Size = new System.Drawing.Size(265, 24);
            this.txtCustomerVATNumber.TabIndex = 14;
            // 
            // lblTerms
            // 
            this.lblTerms.AutoSize = true;
            this.lblTerms.Location = new System.Drawing.Point(494, 74);
            this.lblTerms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerms.Name = "lblTerms";
            this.lblTerms.Size = new System.Drawing.Size(55, 18);
            this.lblTerms.TabIndex = 5;
            this.lblTerms.Text = "Terms:";
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.Location = new System.Drawing.Point(453, 38);
            this.lblLineNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(96, 18);
            this.lblLineNumber.TabIndex = 4;
            this.lblLineNumber.Text = "Line Number:";
            // 
            // lblPRNumber
            // 
            this.lblPRNumber.AutoSize = true;
            this.lblPRNumber.Location = new System.Drawing.Point(459, 8);
            this.lblPRNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPRNumber.Name = "lblPRNumber";
            this.lblPRNumber.Size = new System.Drawing.Size(90, 18);
            this.lblPRNumber.TabIndex = 3;
            this.lblPRNumber.Text = "PR Number:";
            // 
            // lblReferenceNumber
            // 
            this.lblReferenceNumber.AutoSize = true;
            this.lblReferenceNumber.Location = new System.Drawing.Point(36, 72);
            this.lblReferenceNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(137, 18);
            this.lblReferenceNumber.TabIndex = 2;
            this.lblReferenceNumber.Text = "Reference Number:";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Location = new System.Drawing.Point(79, 40);
            this.lblJobNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(94, 18);
            this.lblJobNumber.TabIndex = 1;
            this.lblJobNumber.Text = "Job Number:";
            // 
            // lblCustomerVATNumber
            // 
            this.lblCustomerVATNumber.AutoSize = true;
            this.lblCustomerVATNumber.Location = new System.Drawing.Point(7, 8);
            this.lblCustomerVATNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerVATNumber.Name = "lblCustomerVATNumber";
            this.lblCustomerVATNumber.Size = new System.Drawing.Size(166, 18);
            this.lblCustomerVATNumber.TabIndex = 0;
            this.lblCustomerVATNumber.Text = "Customer VAT Number:";
            // 
            // pnlPumpDetails
            // 
            this.pnlPumpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPumpDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPumpDetails.Controls.Add(this.gbxPumpRestorationDetails);
            this.pnlPumpDetails.Location = new System.Drawing.Point(860, 37);
            this.pnlPumpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPumpDetails.Name = "pnlPumpDetails";
            this.pnlPumpDetails.Size = new System.Drawing.Size(828, 771);
            this.pnlPumpDetails.TabIndex = 6;
            // 
            // gbxPumpRestorationDetails
            // 
            this.gbxPumpRestorationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPumpRestorationDetails.Controls.Add(this.lblNewParts);
            this.gbxPumpRestorationDetails.Controls.Add(this.DgvNonMandatoryPartReplacement);
            this.gbxPumpRestorationDetails.Controls.Add(this.lblMandatoryParts);
            this.gbxPumpRestorationDetails.Controls.Add(this.dgvMandatoryPartReplacement);
            this.gbxPumpRestorationDetails.Controls.Add(this.cbxPumpSelection);
            this.gbxPumpRestorationDetails.Location = new System.Drawing.Point(4, 4);
            this.gbxPumpRestorationDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPumpRestorationDetails.Name = "gbxPumpRestorationDetails";
            this.gbxPumpRestorationDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPumpRestorationDetails.Size = new System.Drawing.Size(816, 761);
            this.gbxPumpRestorationDetails.TabIndex = 9;
            this.gbxPumpRestorationDetails.TabStop = false;
            this.gbxPumpRestorationDetails.Text = "Pump Restoration Details";
            // 
            // lblNewParts
            // 
            this.lblNewParts.AutoSize = true;
            this.lblNewParts.Location = new System.Drawing.Point(14, 406);
            this.lblNewParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewParts.Name = "lblNewParts";
            this.lblNewParts.Size = new System.Drawing.Size(164, 18);
            this.lblNewParts.TabIndex = 4;
            this.lblNewParts.Text = "New Part Replacement:";
            // 
            // DgvNonMandatoryPartReplacement
            // 
            this.DgvNonMandatoryPartReplacement.AllowUserToAddRows = false;
            this.DgvNonMandatoryPartReplacement.AllowUserToDeleteRows = false;
            this.DgvNonMandatoryPartReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvNonMandatoryPartReplacement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvNonMandatoryPartReplacement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvNonMandatoryPartReplacement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNonMandatoryPartReplacement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ClmNMQuantity,
            this.ClmNMMissing_Scrap,
            this.ClmNMRepaired,
            this.ClmNMNewPartQuantity,
            this.ClmNMPrice,
            this.ClmNMUnitPrice,
            this.dataGridViewTextBoxColumn9,
            this.ClmNMRepairDevider});
            this.DgvNonMandatoryPartReplacement.Location = new System.Drawing.Point(14, 428);
            this.DgvNonMandatoryPartReplacement.Margin = new System.Windows.Forms.Padding(4);
            this.DgvNonMandatoryPartReplacement.Name = "DgvNonMandatoryPartReplacement";
            this.DgvNonMandatoryPartReplacement.Size = new System.Drawing.Size(791, 325);
            this.DgvNonMandatoryPartReplacement.TabIndex = 3;
            this.DgvNonMandatoryPartReplacement.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNonMandatoryPartReplacement_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Part No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 41;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 89;
            // 
            // ClmNMQuantity
            // 
            this.ClmNMQuantity.HeaderText = "QTY";
            this.ClmNMQuantity.Name = "ClmNMQuantity";
            this.ClmNMQuantity.ReadOnly = true;
            this.ClmNMQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMQuantity.Width = 44;
            // 
            // ClmNMMissing_Scrap
            // 
            this.ClmNMMissing_Scrap.HeaderText = "Missing / Scrap";
            this.ClmNMMissing_Scrap.Name = "ClmNMMissing_Scrap";
            this.ClmNMMissing_Scrap.ReadOnly = true;
            this.ClmNMMissing_Scrap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMMissing_Scrap.Width = 69;
            // 
            // ClmNMRepaired
            // 
            this.ClmNMRepaired.HeaderText = "Repaired";
            this.ClmNMRepaired.Name = "ClmNMRepaired";
            this.ClmNMRepaired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMRepaired.Width = 73;
            // 
            // ClmNMNewPartQuantity
            // 
            this.ClmNMNewPartQuantity.HeaderText = "New";
            this.ClmNMNewPartQuantity.Name = "ClmNMNewPartQuantity";
            this.ClmNMNewPartQuantity.ReadOnly = true;
            this.ClmNMNewPartQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMNewPartQuantity.Width = 44;
            // 
            // ClmNMPrice
            // 
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.ClmNMPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.ClmNMPrice.HeaderText = "Price";
            this.ClmNMPrice.Name = "ClmNMPrice";
            this.ClmNMPrice.ReadOnly = true;
            this.ClmNMPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMPrice.Width = 48;
            // 
            // ClmNMUnitPrice
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.ClmNMUnitPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.ClmNMUnitPrice.HeaderText = "Unit Price";
            this.ClmNMUnitPrice.Name = "ClmNMUnitPrice";
            this.ClmNMUnitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClmNMUnitPrice.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = "0";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn9.HeaderText = "Total";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 47;
            // 
            // ClmNMRepairDevider
            // 
            this.ClmNMRepairDevider.HeaderText = "Repair Devider";
            this.ClmNMRepairDevider.Name = "ClmNMRepairDevider";
            this.ClmNMRepairDevider.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblMandatoryParts
            // 
            this.lblMandatoryParts.AutoSize = true;
            this.lblMandatoryParts.Location = new System.Drawing.Point(14, 55);
            this.lblMandatoryParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMandatoryParts.Name = "lblMandatoryParts";
            this.lblMandatoryParts.Size = new System.Drawing.Size(204, 18);
            this.lblMandatoryParts.TabIndex = 2;
            this.lblMandatoryParts.Text = "Mandatory Part Replacement:";
            // 
            // dgvMandatoryPartReplacement
            // 
            this.dgvMandatoryPartReplacement.AllowUserToAddRows = false;
            this.dgvMandatoryPartReplacement.AllowUserToDeleteRows = false;
            this.dgvMandatoryPartReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMandatoryPartReplacement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMandatoryPartReplacement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMandatoryPartReplacement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMandatoryPartReplacement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPartNumber,
            this.clmDescription,
            this.clmQuantity,
            this.clmMMissing_Scrap,
            this.clmMRepaired,
            this.clmNew,
            this.clmPrice,
            this.clmUnitPrice,
            this.clmTotal,
            this.ClmRepairDevider});
            this.dgvMandatoryPartReplacement.Location = new System.Drawing.Point(17, 77);
            this.dgvMandatoryPartReplacement.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMandatoryPartReplacement.Name = "dgvMandatoryPartReplacement";
            this.dgvMandatoryPartReplacement.Size = new System.Drawing.Size(791, 325);
            this.dgvMandatoryPartReplacement.TabIndex = 1;
            this.dgvMandatoryPartReplacement.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMandatoryPartReplacement_CellEndEdit);
            // 
            // clmPartNumber
            // 
            this.clmPartNumber.HeaderText = "Part No.";
            this.clmPartNumber.Name = "clmPartNumber";
            this.clmPartNumber.ReadOnly = true;
            this.clmPartNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPartNumber.Width = 41;
            // 
            // clmDescription
            // 
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.ReadOnly = true;
            this.clmDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDescription.Width = 89;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "QTY";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            this.clmQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmQuantity.Width = 44;
            // 
            // clmMMissing_Scrap
            // 
            this.clmMMissing_Scrap.HeaderText = "Missing / Scrap";
            this.clmMMissing_Scrap.Name = "clmMMissing_Scrap";
            this.clmMMissing_Scrap.ReadOnly = true;
            this.clmMMissing_Scrap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMMissing_Scrap.Width = 69;
            // 
            // clmMRepaired
            // 
            this.clmMRepaired.HeaderText = "Repaired";
            this.clmMRepaired.Name = "clmMRepaired";
            this.clmMRepaired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMRepaired.Width = 73;
            // 
            // clmNew
            // 
            this.clmNew.HeaderText = "New";
            this.clmNew.Name = "clmNew";
            this.clmNew.ReadOnly = true;
            this.clmNew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmNew.Width = 44;
            // 
            // clmPrice
            // 
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.clmPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmPrice.HeaderText = "Price";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            this.clmPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPrice.Width = 48;
            // 
            // clmUnitPrice
            // 
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = null;
            this.clmUnitPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmUnitPrice.HeaderText = "Unit Price";
            this.clmUnitPrice.Name = "clmUnitPrice";
            this.clmUnitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUnitPrice.Width = 70;
            // 
            // clmTotal
            // 
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = "0";
            this.clmTotal.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            this.clmTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTotal.Width = 47;
            // 
            // ClmRepairDevider
            // 
            this.ClmRepairDevider.HeaderText = "Repair Devider";
            this.ClmRepairDevider.Name = "ClmRepairDevider";
            this.ClmRepairDevider.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cbxPumpSelection
            // 
            this.cbxPumpSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxPumpSelection.FormattingEnabled = true;
            this.cbxPumpSelection.Location = new System.Drawing.Point(263, 25);
            this.cbxPumpSelection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPumpSelection.Name = "cbxPumpSelection";
            this.cbxPumpSelection.Size = new System.Drawing.Size(343, 26);
            this.cbxPumpSelection.TabIndex = 20;
            this.cbxPumpSelection.Text = "Pump Selection";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.mtxtRebate);
            this.panel6.Controls.Add(this.BtnCalculateRebate);
            this.panel6.Controls.Add(this.lblRebateTestInput);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.lblRepairPercentage);
            this.panel6.Controls.Add(this.lblNewPumpUnitPrice);
            this.panel6.Location = new System.Drawing.Point(860, 830);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(828, 113);
            this.panel6.TabIndex = 11;
            // 
            // mtxtRebate
            // 
            this.mtxtRebate.Value = 1M;
            this.mtxtRebate.Location = new System.Drawing.Point(71, 8);
            this.mtxtRebate.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtRebate.MaxValue = 5000000M;
            this.mtxtRebate.MinValue = 0M;
            this.mtxtRebate.Name = "mtxtRebate";
            this.mtxtRebate.Size = new System.Drawing.Size(148, 24);
            this.mtxtRebate.TabIndex = 21;
            this.mtxtRebate.Text = "1.00";
            // 
            // BtnCalculateRebate
            // 
            this.BtnCalculateRebate.Location = new System.Drawing.Point(107, 40);
            this.BtnCalculateRebate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCalculateRebate.Name = "BtnCalculateRebate";
            this.BtnCalculateRebate.Size = new System.Drawing.Size(112, 32);
            this.BtnCalculateRebate.TabIndex = 22;
            this.BtnCalculateRebate.Text = "Recalculate";
            this.BtnCalculateRebate.UseVisualStyleBackColor = true;
            // 
            // lblRebateTestInput
            // 
            this.lblRebateTestInput.AutoSize = true;
            this.lblRebateTestInput.Location = new System.Drawing.Point(4, 11);
            this.lblRebateTestInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRebateTestInput.Name = "lblRebateTestInput";
            this.lblRebateTestInput.Size = new System.Drawing.Size(59, 18);
            this.lblRebateTestInput.TabIndex = 15;
            this.lblRebateTestInput.Text = "Rebate:";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.lblTotalDueValue);
            this.panel10.Controls.Add(this.lblTotalDue);
            this.panel10.Location = new System.Drawing.Point(545, 83);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(255, 28);
            this.panel10.TabIndex = 14;
            // 
            // lblTotalDueValue
            // 
            this.lblTotalDueValue.AutoSize = true;
            this.lblTotalDueValue.Location = new System.Drawing.Point(113, 3);
            this.lblTotalDueValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDueValue.Name = "lblTotalDueValue";
            this.lblTotalDueValue.Size = new System.Drawing.Size(118, 18);
            this.lblTotalDueValue.TabIndex = 1;
            this.lblTotalDueValue.Text = "lblTotalDueValue";
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.AutoSize = true;
            this.lblTotalDue.Location = new System.Drawing.Point(19, 3);
            this.lblTotalDue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(76, 18);
            this.lblTotalDue.TabIndex = 0;
            this.lblTotalDue.Text = "Total Due:";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblVATValue);
            this.panel9.Controls.Add(this.lblVAT);
            this.panel9.Location = new System.Drawing.Point(545, 55);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(255, 28);
            this.panel9.TabIndex = 13;
            // 
            // lblVATValue
            // 
            this.lblVATValue.AutoSize = true;
            this.lblVATValue.Location = new System.Drawing.Point(113, 4);
            this.lblVATValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVATValue.Name = "lblVATValue";
            this.lblVATValue.Size = new System.Drawing.Size(85, 18);
            this.lblVATValue.TabIndex = 3;
            this.lblVATValue.Text = "lblVATValue";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(4, 4);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(91, 18);
            this.lblVAT.TabIndex = 0;
            this.lblVAT.Text = "VAT @ 15%:";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblSubTotalValue);
            this.panel8.Controls.Add(this.lblSubTotal);
            this.panel8.Location = new System.Drawing.Point(545, 28);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(255, 28);
            this.panel8.TabIndex = 13;
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.AutoSize = true;
            this.lblSubTotalValue.Location = new System.Drawing.Point(113, 3);
            this.lblSubTotalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(117, 18);
            this.lblSubTotalValue.TabIndex = 2;
            this.lblSubTotalValue.Text = "lblSubTotalValue";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(20, 4);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(75, 18);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "Sub Total:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblRebateValue);
            this.panel7.Controls.Add(this.lblRebate);
            this.panel7.Location = new System.Drawing.Point(545, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(255, 28);
            this.panel7.TabIndex = 12;
            // 
            // lblRebateValue
            // 
            this.lblRebateValue.AutoSize = true;
            this.lblRebateValue.Location = new System.Drawing.Point(113, 4);
            this.lblRebateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRebateValue.Name = "lblRebateValue";
            this.lblRebateValue.Size = new System.Drawing.Size(105, 18);
            this.lblRebateValue.TabIndex = 1;
            this.lblRebateValue.Text = "lblRebateValue";
            // 
            // lblRebate
            // 
            this.lblRebate.AutoSize = true;
            this.lblRebate.Location = new System.Drawing.Point(36, 4);
            this.lblRebate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRebate.Name = "lblRebate";
            this.lblRebate.Size = new System.Drawing.Size(59, 18);
            this.lblRebate.TabIndex = 0;
            this.lblRebate.Text = "Rebate:";
            // 
            // lblRepairPercentage
            // 
            this.lblRepairPercentage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRepairPercentage.AutoSize = true;
            this.lblRepairPercentage.Location = new System.Drawing.Point(296, 47);
            this.lblRepairPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRepairPercentage.Name = "lblRepairPercentage";
            this.lblRepairPercentage.Size = new System.Drawing.Size(140, 18);
            this.lblRepairPercentage.TabIndex = 1;
            this.lblRepairPercentage.Text = "lblRepairPercentage";
            // 
            // lblNewPumpUnitPrice
            // 
            this.lblNewPumpUnitPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNewPumpUnitPrice.AutoSize = true;
            this.lblNewPumpUnitPrice.Location = new System.Drawing.Point(296, 14);
            this.lblNewPumpUnitPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPumpUnitPrice.Name = "lblNewPumpUnitPrice";
            this.lblNewPumpUnitPrice.Size = new System.Drawing.Size(151, 18);
            this.lblNewPumpUnitPrice.TabIndex = 0;
            this.lblNewPumpUnitPrice.Text = "lblNewPumpUnitPrice";
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.Location = new System.Drawing.Point(1576, 948);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(4);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(112, 32);
            this.btnComplete.TabIndex = 23;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(13, 948);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmCreateQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 993);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnlPumpDetails);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBusinessDetails);
            this.Controls.Add(this.msCreateNewQuoteControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msCreateNewQuoteControls;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCreateQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creating New Quote For << Business Name >>";
            this.Load += new System.EventHandler(this.FrmCreateQuote_Load);
            this.msCreateNewQuoteControls.ResumeLayout(false);
            this.msCreateNewQuoteControls.PerformLayout();
            this.pnlBusinessDetails.ResumeLayout(false);
            this.gbxBusinessInformation.ResumeLayout(false);
            this.gbxBusinessInformation.PerformLayout();
            this.gbxBusinessPOBoxDetails.ResumeLayout(false);
            this.gbxBusinessPOBoxDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxQuoteNumberManagement.ResumeLayout(false);
            this.gbxQuoteNumberManagement.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbxCustomerDeliveryAddressInformation.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlPumpDetails.ResumeLayout(false);
            this.gbxPumpRestorationDetails.ResumeLayout(false);
            this.gbxPumpRestorationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNonMandatoryPartReplacement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMandatoryPartReplacement)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msCreateNewQuoteControls;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBusinessDetails;
        private System.Windows.Forms.ComboBox cbxBusinessSelection;
        private System.Windows.Forms.Label lblBusinessPOBoxNumber;
        private System.Windows.Forms.GroupBox gbxBusinessPOBoxDetails;
        private System.Windows.Forms.Label lblBusinessPOBoxSuburb;
        private System.Windows.Forms.Label lblBusinessPOBoxCity;
        private System.Windows.Forms.GroupBox gbxBusinessInformation;
        private System.Windows.Forms.Label lblBusinessRegistrationNumber;
        private System.Windows.Forms.Label lblBusinessVATNumber;
        private System.Windows.Forms.ComboBox cbxBusinessEmailAddressSelection;
        private System.Windows.Forms.ComboBox cbxBusinessCellphoneNumberSelection;
        private System.Windows.Forms.ComboBox cbxBusinessTelephoneNumberSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuote;
        private System.Windows.Forms.GroupBox gbxQuoteNumberManagement;
        private System.Windows.Forms.TextBox txtQuoteNumber;
        private System.Windows.Forms.Label lblQuoteNumber;
        private System.Windows.Forms.Label lblQuoteNumberText;
        private System.Windows.Forms.CheckBox cbxUseAutomaticNumberingScheme;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCustomerPOBoxCity;
        private System.Windows.Forms.Label lblCustomerPOBoxSuburb;
        private System.Windows.Forms.ComboBox cbxCustomerSelection;
        private System.Windows.Forms.Label lblCustomerPOBoxAreaCode;
        private System.Windows.Forms.Label lblBusinessPOBoxAreaCode;
        private System.Windows.Forms.Label lblCustomerVendorNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbxCustomerDeliveryAddressInformation;
        private System.Windows.Forms.ComboBox cbxCustomerDeliveryAddress;
        private System.Windows.Forms.RichTextBox rtxCustomerDeliveryDescripton;
        private System.Windows.Forms.Label lblQuoteExpiryDate;
        private System.Windows.Forms.Label lblQuoteCreationDate;
        private System.Windows.Forms.DateTimePicker dtpQuoteExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpQuoteCreationDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblJobNumber;
        private System.Windows.Forms.Label lblCustomerVATNumber;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.Label lblPRNumber;
        private System.Windows.Forms.Label lblLineNumber;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.TextBox txtCustomerVATNumber;
        private System.Windows.Forms.DateTimePicker dtpPaymentTerm;
        private System.Windows.Forms.TextBox txtLineNumber;
        private System.Windows.Forms.TextBox txtPRNumber;
        private System.Windows.Forms.Panel pnlPumpDetails;
        private System.Windows.Forms.GroupBox gbxPumpRestorationDetails;
        private System.Windows.Forms.Label lblNewParts;
        private System.Windows.Forms.Label lblMandatoryParts;
        private System.Windows.Forms.DataGridView dgvMandatoryPartReplacement;
        private System.Windows.Forms.ComboBox cbxPumpSelection;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblRepairPercentage;
        private System.Windows.Forms.Label lblNewPumpUnitPrice;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblRebate;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblRebateValue;
        private System.Windows.Forms.Label lblVATValue;
        private System.Windows.Forms.Label lblTotalDueValue;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox CbxPOBoxSelection;
        private System.Windows.Forms.Label lblCustomerPOBoxStreetName;
        private System.Windows.Forms.DataGridView DgvNonMandatoryPartReplacement;
        private System.Windows.Forms.ComboBox CbxCustomerPOBoxSelection;
        private System.Windows.Forms.Label lblRebateTestInput;
        private System.Windows.Forms.Button BtnCalculateRebate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMMissing_Scrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMRepaired;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMNewPartQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNMRepairDevider;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMMissing_Scrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMRepaired;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmRepairDevider;
        private QuoteSwift.Controls.NumericTextBox mtxtRebate;
        private System.Windows.Forms.Label lblCustomerSelection;
        private System.Windows.Forms.Label lblCustomerDeliveryAddress;
        private System.Windows.Forms.SaveFileDialog sfdSaveExport;
        private System.Windows.Forms.ToolStripMenuItem createNewQuoteUsingThisQuoteToolStripMenuItem;
    }
}