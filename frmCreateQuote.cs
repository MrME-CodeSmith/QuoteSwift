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
    public partial class FrmCreateQuote : BaseForm
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
            : base(messageService)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            appData = data;
            this.messageService = messageService;
            this.serializationService = serializationService;
            this.quoteToChange = quoteToChange;
            this.changeSpecificObject = changeSpecificObject;
            SetupBindings();
            BindIsBusy(viewModel);
        }

        private async void BtnComplete_Click(object sender, EventArgs e)
        {
            if (!changeSpecificObject && quoteToChange != null)
            {
                NewQuote = quoteToChange;
                await ExportQuoteToTemplateAsync(NewQuote);
                NewQuote = null;
            }
            else
            {
                viewModel.Pricing.Rebate = ParsingService.ParseDecimal(mtxtRebate.Text);
                viewModel.SaveQuoteCommand.Execute(null);
                NewQuote = viewModel.LastCreatedQuote;

                if (NewQuote != null)
                {
                    if (messageService.RequestConfirmation("The quote was successfully created. Would you like to export the quote an Excel document?", "REQUEST - Export Quote to Excel"))
                    {
                        await ExportQuoteToTemplateAsync(NewQuote);
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

        private async void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            await viewModel.LoadDataAsync();
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
            BindingHelpers.BindDataGridView(dgvMandatoryPartReplacement, mandatorySource, nameof(BindingSource.DataSource));

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
            BindingHelpers.BindDataGridView(DgvNonMandatoryPartReplacement, nonMandatorySource, nameof(BindingSource.DataSource));

            BindingHelpers.BindComboBox(cbxBusinessSelection, viewModel, nameof(CreateQuoteViewModel.Businesses), nameof(CreateQuoteViewModel.SelectedBusiness), "BusinessName", "BusinessName");

            BindingHelpers.BindComboBox(cbxPumpSelection, viewModel, nameof(CreateQuoteViewModel.Pumps), nameof(CreateQuoteViewModel.SelectedPump), "PumpName", "PumpName");

            BindingHelpers.BindComboBox(cbxBusinessTelephoneNumberSelection, viewModel, nameof(CreateQuoteViewModel.BusinessTelephoneNumbers), null);
            BindingHelpers.BindComboBox(cbxBusinessCellphoneNumberSelection, viewModel, nameof(CreateQuoteViewModel.BusinessCellphoneNumbers), null);
            BindingHelpers.BindComboBox(cbxBusinessEmailAddressSelection, viewModel, nameof(CreateQuoteViewModel.BusinessEmailAddresses), null);

            BindingHelpers.BindComboBox(cbxCustomerSelection, viewModel, nameof(CreateQuoteViewModel.Customers), nameof(CreateQuoteViewModel.SelectedCustomer), "CustomerCompanyName", "CustomerCompanyName");

            BindingHelpers.BindComboBox(cbxCustomerDeliveryAddress, viewModel, nameof(CreateQuoteViewModel.CustomerDeliveryAddresses), nameof(CreateQuoteViewModel.SelectedCustomerDeliveryAddress), "AddressDescription", "AddressDescription");

            BindingHelpers.BindComboBox(CbxPOBoxSelection, viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxes), nameof(CreateQuoteViewModel.SelectedBusinessPOBox), "AddressDescription", "AddressDescription");

            BindingHelpers.BindComboBox(CbxCustomerPOBoxSelection, viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxes), nameof(CreateQuoteViewModel.SelectedCustomerPOBox), "AddressDescription", "AddressDescription");

            BindingHelpers.BindText(txtCustomerVATNumber, viewModel, nameof(CreateQuoteViewModel.CustomerVATNumber));
            BindingHelpers.BindText(txtJobNumber, viewModel, nameof(CreateQuoteViewModel.JobNumber));
            BindingHelpers.BindText(txtReferenceNumber, viewModel, nameof(CreateQuoteViewModel.ReferenceNumber));
            BindingHelpers.BindText(txtPRNumber, viewModel, nameof(CreateQuoteViewModel.PRNumber));
            BindingHelpers.BindText(txtLineNumber, viewModel, nameof(CreateQuoteViewModel.LineNumber));
            BindingHelpers.BindText(txtQuoteNumber, viewModel, nameof(CreateQuoteViewModel.QuoteNumber));

            BindingHelpers.BindText(rtxCustomerDeliveryDescripton, viewModel, nameof(CreateQuoteViewModel.CustomerDeliveryDescription));
            BindingHelpers.BindValue(dtpQuoteCreationDate, viewModel, nameof(CreateQuoteViewModel.QuoteCreationDate));
            BindingHelpers.BindValue(dtpQuoteExpiryDate, viewModel, nameof(CreateQuoteViewModel.QuoteExpiryDate));
            BindingHelpers.BindValue(dtpPaymentTerm, viewModel, nameof(CreateQuoteViewModel.PaymentTerm));

            BindingHelpers.BindText(cbxBusinessTelephoneNumberSelection, viewModel, nameof(CreateQuoteViewModel.BusinessTelephone));
            BindingHelpers.BindText(cbxBusinessCellphoneNumberSelection, viewModel, nameof(CreateQuoteViewModel.BusinessCellphone));
            BindingHelpers.BindText(cbxBusinessEmailAddressSelection, viewModel, nameof(CreateQuoteViewModel.BusinessEmail));

            BindingHelpers.BindText(lblBusinessPOBoxNumber, viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxNumberDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxSuburb, viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxSuburbDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxCity, viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxCityDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxAreaCode, viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxAreaCodeDisplay));
            BindingHelpers.BindText(lblBusinessRegistrationNumber, viewModel, nameof(CreateQuoteViewModel.BusinessRegistrationNumberDisplay));
            BindingHelpers.BindText(lblBusinessVATNumber, viewModel, nameof(CreateQuoteViewModel.BusinessVATNumberDisplay));

            BindingHelpers.BindText(lblCustomerPOBoxStreetName, viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxStreetNameDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxSuburb, viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxSuburbDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxCity, viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxCityDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxAreaCode, viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxAreaCodeDisplay));
            BindingHelpers.BindText(lblCustomerVendorNumber, viewModel, nameof(CreateQuoteViewModel.CustomerVendorNumberDisplay));

            UpdatePricingDisplay();
            CommandBindings.Bind(btnComplete, viewModel.SaveQuoteCommand);
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


        private async System.Threading.Tasks.Task ExportQuoteToTemplateAsync(Quote q)
        {
            await ((AsyncRelayCommand)viewModel.ExportQuoteCommand).ExecuteAsync(q);
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
            ControlStateHelper.ApplyReadOnly(Controls, true);
            cbxPumpSelection.Enabled = false;

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
            ControlStateHelper.ApplyReadOnly(Controls, false);
            cbxPumpSelection.Enabled = true;

            Text = Text.Replace(quoteToChange.QuoteCompany.BusinessName, quoteToChange.QuoteCompany.BusinessName);
            Text = Text.Replace("Viewing", "Creating New");

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

        protected override void OnClose()
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }

}
