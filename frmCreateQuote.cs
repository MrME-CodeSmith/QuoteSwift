using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmCreateQuote : Form
    {
        readonly CreateQuoteViewModel viewModel;
        readonly ApplicationData appData;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        Quote quoteToChange;
        bool changeSpecificObject;
        public Quote NewQuote;

        readonly BindingSource mandatorySource = new BindingSource();
        readonly BindingSource nonMandatorySource = new BindingSource();


        public FrmCreateQuote(CreateQuoteViewModel viewModel, ApplicationData data, Quote quoteToChange = null, bool changeSpecificObject = false, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            appData = data;
            this.messageService = messageService;
            this.serializationService = serializationService;
            this.quoteToChange = quoteToChange;
            this.changeSpecificObject = changeSpecificObject;
            this.viewModel.LoadData();
            SetupBindings();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (!changeSpecificObject && quoteToChange != null)
            {
                NewQuote = quoteToChange;
                ExportQuoteToTemplate(NewQuote);
                NewQuote = null;
            }
            else
            {
                viewModel.Pricing.Rebate = ParsingService.ParseDecimal(mtxtRebate.Text);
                NewQuote = viewModel.CreateAndSaveQuote();

                if (NewQuote != null)
                {
                    if (messageService.RequestConfirmation("The quote was successfully created. Would you like to export the quote an Excel document?", "REQUEST - Export Quote to Excel"))
                    {
                        ExportQuoteToTemplate(NewQuote);
                    }
                    else
                    {
                        messageService.ShowInformation("The quote was successfully added to the list of quotes.", "INFORMATION - Quote Added To List");
                    }

                    quoteToChange = NewQuote;
                    ConvertToReadOnly();
                    createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = true;
                }
                else
                {
                    messageService.ShowError("The Quote could not be created successfully.", "ERROR - Quote Creation Unsuccessful");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);

        private void CbxPumpSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            mandatorySource.DataSource = viewModel.MandatoryParts;
            nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
            UpdatePricingDisplay();
        }

        private void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            if (!changeSpecificObject && quoteToChange != null) // View Quote
            {
                LoadFromPassedObject();
                ConvertToReadOnly();
                createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = true;
            }
            else if (changeSpecificObject && quoteToChange != null)//Create New Quote Using Passed Quote
            {
                LoadFromPassedObject();

                viewModel.QuoteCreationDate = DateTime.Today;
                viewModel.QuoteExpiryDate = viewModel.QuoteCreationDate.AddMonths(2);
                viewModel.PaymentTerm = viewModel.QuoteCreationDate.AddMonths(1);
                viewModel.PaymentTerm = DateTime.Today;

                Text = Text.Replace("<< Business Name >>", viewModel.SelectedBusiness.BusinessName);

                if (!string.IsNullOrEmpty(viewModel.NextQuoteNumber))
                    viewModel.QuoteNumber = viewModel.NextQuoteNumber;
            }
            else //Create New
            {
                viewModel.PrepareComboBoxLists();
                viewModel.LoadPartlists();
                mandatorySource.DataSource = viewModel.MandatoryParts;
                nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
                UpdatePricingDisplay();
                if (!string.IsNullOrEmpty(viewModel.NextQuoteNumber))
                    viewModel.QuoteNumber = viewModel.NextQuoteNumber;

                viewModel.QuoteCreationDate = DateTime.Today;
                viewModel.QuoteExpiryDate = viewModel.QuoteCreationDate.AddMonths(2);
                viewModel.PaymentTerm = viewModel.QuoteCreationDate.AddMonths(1);

                Text = Text.Replace("<< Business Name >>", viewModel.SelectedBusiness.BusinessName);
                if (viewModel.QuoteMap == null || viewModel.QuoteMap.Count == 0)
                {
                    cbxUseAutomaticNumberingScheme.Checked = false;
                    cbxUseAutomaticNumberingScheme.Enabled = false;
                    txtQuoteNumber.Enabled = true;
                    txtQuoteNumber.ReadOnly = false;
                }
            }

            dgvMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            DgvNonMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvNonMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void CbxCustomerSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CbxBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CbxPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CbxCustomerDeliveryAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void DgvMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            viewModel.Calculate();
            UpdatePricingDisplay();
        }

        private void DgvNonMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            viewModel.Calculate();
            UpdatePricingDisplay();
        }







        private void SetupBindings()
        {
            dgvMandatoryPartReplacement.AutoGenerateColumns = false;
            clmPartNumber.DataPropertyName = "PumpPart.PumpPart.NewPartNumber";
            clmDescription.DataPropertyName = "PumpPart.PumpPart.PartDescription";
            clmQuantity.DataPropertyName = "PumpPart.PumpPartQuantity";
            clmMMissing_Scrap.DataPropertyName = nameof(Quote_Part.MissingorScrap);
            clmMRepaired.DataPropertyName = nameof(Quote_Part.Repaired);
            clmNew.DataPropertyName = nameof(Quote_Part.New);
            clmPrice.DataPropertyName = nameof(Quote_Part.Price);
            clmUnitPrice.DataPropertyName = nameof(Quote_Part.UnitPrice);
            clmTotal.DataPropertyName = nameof(Quote_Part.Price);
            ClmRepairDevider.DataPropertyName = nameof(Quote_Part.RepairDevider);
            mandatorySource.DataSource = viewModel.MandatoryParts;
            dgvMandatoryPartReplacement.DataSource = mandatorySource;

            DgvNonMandatoryPartReplacement.AutoGenerateColumns = false;
            dataGridViewTextBoxColumn1.DataPropertyName = "PumpPart.PumpPart.NewPartNumber";
            dataGridViewTextBoxColumn2.DataPropertyName = "PumpPart.PumpPart.PartDescription";
            ClmNMQuantity.DataPropertyName = "PumpPart.PumpPartQuantity";
            ClmNMMissing_Scrap.DataPropertyName = nameof(Quote_Part.MissingorScrap);
            ClmNMRepaired.DataPropertyName = nameof(Quote_Part.Repaired);
            ClmNMNewPartQuantity.DataPropertyName = nameof(Quote_Part.New);
            ClmNMPrice.DataPropertyName = nameof(Quote_Part.Price);
            ClmNMUnitPrice.DataPropertyName = nameof(Quote_Part.UnitPrice);
            dataGridViewTextBoxColumn9.DataPropertyName = nameof(Quote_Part.Price);
            ClmNMRepairDevider.DataPropertyName = nameof(Quote_Part.RepairDevider);
            nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
            DgvNonMandatoryPartReplacement.DataSource = nonMandatorySource;

            cbxBusinessSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.Businesses), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxBusinessSelection.DisplayMember = "BusinessName";
            cbxBusinessSelection.ValueMember = "BusinessName";
            cbxBusinessSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedBusiness), false, DataSourceUpdateMode.OnPropertyChanged);

            cbxPumpSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.Pumps), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxPumpSelection.DisplayMember = "PumpName";
            cbxPumpSelection.ValueMember = "PumpName";
            cbxPumpSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);

            cbxBusinessTelephoneNumberSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.BusinessTelephoneNumbers), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxBusinessCellphoneNumberSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.BusinessCellphoneNumbers), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxBusinessEmailAddressSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.BusinessEmailAddresses), false, DataSourceUpdateMode.OnPropertyChanged);

            cbxCustomerSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.Customers), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxCustomerSelection.DisplayMember = "CustomerCompanyName";
            cbxCustomerSelection.ValueMember = "CustomerCompanyName";
            cbxCustomerSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedCustomer), false, DataSourceUpdateMode.OnPropertyChanged);

            cbxCustomerDeliveryAddress.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.CustomerDeliveryAddresses), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxCustomerDeliveryAddress.DisplayMember = "AddressDescription";
            cbxCustomerDeliveryAddress.ValueMember = "AddressDescription";

            CbxPOBoxSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxes), false, DataSourceUpdateMode.OnPropertyChanged);
            CbxPOBoxSelection.DisplayMember = "AddressDescription";
            CbxPOBoxSelection.ValueMember = "AddressDescription";

            CbxCustomerPOBoxSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxes), false, DataSourceUpdateMode.OnPropertyChanged);
            CbxCustomerPOBoxSelection.DisplayMember = "AddressDescription";
            CbxCustomerPOBoxSelection.ValueMember = "AddressDescription";

            txtCustomerVATNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerVATNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtJobNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.JobNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtReferenceNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.ReferenceNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtPRNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.PRNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtLineNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.LineNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtQuoteNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.QuoteNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            rtxCustomerDeliveryDescripton.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerDeliveryDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            dtpQuoteCreationDate.DataBindings.Add("Value", viewModel, nameof(CreateQuoteViewModel.QuoteCreationDate), false, DataSourceUpdateMode.OnPropertyChanged);
            dtpQuoteExpiryDate.DataBindings.Add("Value", viewModel, nameof(CreateQuoteViewModel.QuoteExpiryDate), false, DataSourceUpdateMode.OnPropertyChanged);
            dtpPaymentTerm.DataBindings.Add("Value", viewModel, nameof(CreateQuoteViewModel.PaymentTerm), false, DataSourceUpdateMode.OnPropertyChanged);

            cbxBusinessTelephoneNumberSelection.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessTelephone), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxBusinessCellphoneNumberSelection.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessCellphone), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxBusinessEmailAddressSelection.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessEmail), false, DataSourceUpdateMode.OnPropertyChanged);

            lblBusinessPOBoxNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxNumberDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBusinessPOBoxSuburb.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxSuburbDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBusinessPOBoxCity.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxCityDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBusinessPOBoxAreaCode.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxAreaCodeDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBusinessRegistrationNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessRegistrationNumberDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBusinessVATNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.BusinessVATNumberDisplay), false, DataSourceUpdateMode.OnPropertyChanged);

            lblCustomerPOBoxStreetName.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxStreetNameDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblCustomerPOBoxSuburb.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxSuburbDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblCustomerPOBoxCity.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxCityDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblCustomerPOBoxAreaCode.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxAreaCodeDisplay), false, DataSourceUpdateMode.OnPropertyChanged);
            lblCustomerVendorNumber.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.CustomerVendorNumberDisplay), false, DataSourceUpdateMode.OnPropertyChanged);

            CbxPOBoxSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedBusinessPOBox), false, DataSourceUpdateMode.OnPropertyChanged);
            CbxCustomerPOBoxSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedCustomerPOBox), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxCustomerDeliveryAddress.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedCustomerDeliveryAddress), false, DataSourceUpdateMode.OnPropertyChanged);

            UpdatePricingDisplay();
        }

        void UpdatePricingDisplay()
        {
            lblNewPumpUnitPrice.Text = "New Pump Price: R " + viewModel.Pricing.PumpPrice.ToString();
            lblRebateValue.Text = "R" + viewModel.Pricing.Rebate.ToString();
            lblSubTotalValue.Text = "R" + viewModel.Pricing.SubTotal.ToString();
            lblVATValue.Text = "R" + viewModel.Pricing.VAT.ToString();
            lblTotalDueValue.Text = "R" + viewModel.Pricing.TotalDue.ToString();
            lblRepairPercentage.Text = "Repair Percentage: " + viewModel.RepairPercentage + "%";
        }

        private void BtnCalculateRebate_Click(object sender, EventArgs e)
        {
            viewModel.Pricing.Rebate = ParsingService.ParseDecimal(mtxtRebate.Text);
            viewModel.Calculate();
            UpdatePricingDisplay();
        }

        private void DtpQuoteCreationDate_ValueChanged(object sender, EventArgs e)
        {
            dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
            dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);
        }

        private void DtpQuoteExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            dtpQuoteCreationDate.Value = dtpQuoteExpiryDate.Value.AddMonths(-2);
            dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);
        }

        private void CbxCustomerPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void CbxUseAutomaticNumberingScheme_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUseAutomaticNumberingScheme.Checked)
            {
                txtQuoteNumber.ReadOnly = true;
                if (!string.IsNullOrEmpty(viewModel.NextQuoteNumber))
                    viewModel.QuoteNumber = viewModel.NextQuoteNumber;
            }
            else
            {
                txtQuoteNumber.ReadOnly = false;
            }
        }


        private void ExportQuoteToTemplate(Quote q)
        {
            UseWaitCursor = true;
            viewModel.ExportQuoteToTemplate(q);
            UseWaitCursor = false;
        }


        private void LoadFromPassedObject()
        {
            viewModel.LoadFromQuote(quoteToChange);
            mandatorySource.DataSource = viewModel.MandatoryParts;
            nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
            UpdatePricingDisplay();
        }

        private void ConvertToReadOnly()
        {
            ApplyControlState(true);

            dgvMandatoryPartReplacement.ReadOnly = true;
            DgvNonMandatoryPartReplacement.ReadOnly = true;

            dgvMandatoryPartReplacement.Enabled = true;
            DgvNonMandatoryPartReplacement.Enabled = true;

            pnlPumpDetails.Enabled = true;
            cbxPumpSelection.Enabled = false;

            btnComplete.Text = "Export";
            btnComplete.Enabled = true;
            btnCancel.Enabled = true;

            Text = Text.Replace("<< Business Name >>", quoteToChange.QuoteCompany.BusinessName);
            Text = Text.Replace("Creating New", "Viewing");
        }

        private void ConvertToReadWrite()
        {
            ApplyControlState(false);

            Text = Text.Replace(quoteToChange.QuoteCompany.BusinessName, quoteToChange.QuoteCompany.BusinessName);
            Text = Text.Replace("Viewing", "Creating New");

        }

        void ApplyControlState(bool readOnly)
        {
            ControlStateHelper.ApplyReadOnly(Controls, readOnly);
            cbxPumpSelection.Enabled = !readOnly;
        }

        private void CreateNewQuoteUsingThisQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quoteToChange == null) quoteToChange = NewQuote;
            changeSpecificObject = true;
            ConvertToReadWrite();
            if (!string.IsNullOrEmpty(viewModel.NextQuoteNumber))
                viewModel.QuoteNumber = viewModel.NextQuoteNumber;
            btnComplete.Text = "Complete";
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmCreateQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
    }

}
