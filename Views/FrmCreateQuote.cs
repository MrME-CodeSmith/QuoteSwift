using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmCreateQuote : BaseForm<CreateQuoteViewModel>
    {
        
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        readonly Button btnCancelOperation;
        Quote quoteToChange;
        bool changeSpecificObject;
        public Quote NewQuote;



        public FrmCreateQuote(CreateQuoteViewModel viewModel, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService)
        {
            InitializeComponent();
            ViewModel.CloseAction = Close;
            this.messageService = messageService;
            this.serializationService = serializationService;
            SetupBindings();
            BindIsBusy(ViewModel);

            btnCancelOperation = new Button
            {
                Text = "Cancel Operation",
                Size = new Size(130, 32),
                Location = new Point(btnCancel.Right + 10, btnCancel.Top)
            };
            btnCancelOperation.Click += BtnCancelOperation_Click;
            Controls.Add(btnCancelOperation);
        }

        public void Initialize(Quote quoteToChange = null, bool changeSpecificObject = false)
        {
            this.quoteToChange = quoteToChange;
            this.changeSpecificObject = changeSpecificObject;
        }



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ViewModel.CancelCommand.CanExecute(null))
                ViewModel.CancelCommand.Execute(null);
        }

        private void BtnCancelOperation_Click(object sender, EventArgs e)
        {
            ((AsyncRelayCommand)ViewModel.ExportQuoteCommand).Cancel();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewModel.ExitCommand.CanExecute(null))
                ViewModel.ExitCommand.Execute(null);
        }


        private void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            ViewModel.QuoteToChange = quoteToChange;
            ViewModel.ChangeSpecificObject = changeSpecificObject;
            if (ViewModel.IsViewing)
            {
                ViewModel.LoadPassedQuoteCommand.Execute(null);
            }
            else if (ViewModel.IsEditing && ViewModel.QuoteToChange != null)
            {
                ViewModel.LoadPassedQuoteCommand.Execute(null);

                ViewModel.QuoteCreationDate = DateTime.Today;
                ViewModel.QuoteExpiryDate = ViewModel.QuoteCreationDate.AddMonths(2);
                ViewModel.PaymentTerm = ViewModel.QuoteCreationDate.AddMonths(1);
                ViewModel.PaymentTerm = DateTime.Today;

                Text = Text.Replace("<< Business Name >>", ViewModel.SelectedBusiness.BusinessName);

                if (!string.IsNullOrEmpty(ViewModel.NextQuoteNumber))
                    ViewModel.QuoteNumber = ViewModel.NextQuoteNumber;
            }
            else //Create New
            {
                ViewModel.PrepareComboBoxLists();
                ViewModel.LoadPartlists();
                if (!string.IsNullOrEmpty(ViewModel.NextQuoteNumber))
                    ViewModel.QuoteNumber = ViewModel.NextQuoteNumber;

                ViewModel.QuoteCreationDate = DateTime.Today;
                ViewModel.QuoteExpiryDate = ViewModel.QuoteCreationDate.AddMonths(2);
                ViewModel.PaymentTerm = ViewModel.QuoteCreationDate.AddMonths(1);

                Text = Text.Replace("<< Business Name >>", ViewModel.SelectedBusiness.BusinessName);
                if (ViewModel.QuoteMap == null || ViewModel.QuoteMap.Count == 0)
                {
                    ViewModel.UseAutomaticNumberingScheme = false;
                    cbxUseAutomaticNumberingScheme.Enabled = false;
                    txtQuoteNumber.Enabled = true;
                }
            }

            dgvMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            DgvNonMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvNonMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
            BindingHelpers.BindDataGridView(dgvMandatoryPartReplacement, ViewModel, nameof(CreateQuoteViewModel.MandatoryParts));

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
            BindingHelpers.BindDataGridView(DgvNonMandatoryPartReplacement, ViewModel, nameof(CreateQuoteViewModel.NonMandatoryParts));

            BindingHelpers.BindComboBox(cbxBusinessSelection, ViewModel, nameof(CreateQuoteViewModel.Businesses), nameof(CreateQuoteViewModel.SelectedBusiness), "BusinessName", "BusinessName");

            BindingHelpers.BindComboBox(cbxPumpSelection, ViewModel, nameof(CreateQuoteViewModel.Pumps), nameof(CreateQuoteViewModel.SelectedPump), "PumpName", "PumpName");

            BindingHelpers.BindComboBox(cbxBusinessTelephoneNumberSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessTelephoneNumbers), null);
            BindingHelpers.BindComboBox(cbxBusinessCellphoneNumberSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessCellphoneNumbers), null);
            BindingHelpers.BindComboBox(cbxBusinessEmailAddressSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessEmailAddresses), null);

            BindingHelpers.BindComboBox(cbxCustomerSelection, ViewModel, nameof(CreateQuoteViewModel.Customers), nameof(CreateQuoteViewModel.SelectedCustomer), "CustomerCompanyName", "CustomerCompanyName");

            BindingHelpers.BindComboBox(cbxCustomerDeliveryAddress, ViewModel, nameof(CreateQuoteViewModel.CustomerDeliveryAddresses), nameof(CreateQuoteViewModel.SelectedCustomerDeliveryAddress), "AddressDescription", "AddressDescription");

            BindingHelpers.BindComboBox(CbxPOBoxSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessPOBoxes), nameof(CreateQuoteViewModel.SelectedBusinessPOBox), "AddressDescription", "AddressDescription");

            BindingHelpers.BindComboBox(CbxCustomerPOBoxSelection, ViewModel, nameof(CreateQuoteViewModel.CustomerPOBoxes), nameof(CreateQuoteViewModel.SelectedCustomerPOBox), "AddressDescription", "AddressDescription");

            BindingHelpers.BindText(txtCustomerVATNumber, ViewModel, nameof(CreateQuoteViewModel.CustomerVATNumber));
            BindingHelpers.BindText(txtJobNumber, ViewModel, nameof(CreateQuoteViewModel.JobNumber));
            BindingHelpers.BindText(txtReferenceNumber, ViewModel, nameof(CreateQuoteViewModel.ReferenceNumber));
            BindingHelpers.BindText(txtPRNumber, ViewModel, nameof(CreateQuoteViewModel.PRNumber));
            BindingHelpers.BindText(txtLineNumber, ViewModel, nameof(CreateQuoteViewModel.LineNumber));
            BindingHelpers.BindText(txtQuoteNumber, ViewModel, nameof(CreateQuoteViewModel.QuoteNumber));
            cbxUseAutomaticNumberingScheme.DataBindings.Add("Checked", ViewModel, nameof(CreateQuoteViewModel.UseAutomaticNumberingScheme));
            BindingHelpers.BindReadOnly(txtQuoteNumber, ViewModel, nameof(CreateQuoteViewModel.IsQuoteNumberReadOnly));

            BindingHelpers.BindText(rtxCustomerDeliveryDescripton, ViewModel, nameof(CreateQuoteViewModel.CustomerDeliveryDescription));
            BindingHelpers.BindValue(dtpQuoteCreationDate, ViewModel, nameof(CreateQuoteViewModel.QuoteCreationDate));
            BindingHelpers.BindValue(dtpQuoteExpiryDate, ViewModel, nameof(CreateQuoteViewModel.QuoteExpiryDate));
            BindingHelpers.BindValue(dtpPaymentTerm, ViewModel, nameof(CreateQuoteViewModel.PaymentTerm));
            mtxtRebate.DataBindings.Add("Value", ViewModel, nameof(CreateQuoteViewModel.RebateInput), false, DataSourceUpdateMode.OnPropertyChanged);

            BindingHelpers.BindText(cbxBusinessTelephoneNumberSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessTelephone));
            BindingHelpers.BindText(cbxBusinessCellphoneNumberSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessCellphone));
            BindingHelpers.BindText(cbxBusinessEmailAddressSelection, ViewModel, nameof(CreateQuoteViewModel.BusinessEmail));

            BindingHelpers.BindText(lblBusinessPOBoxNumber, ViewModel, nameof(CreateQuoteViewModel.BusinessPOBoxNumberDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxSuburb, ViewModel, nameof(CreateQuoteViewModel.BusinessPOBoxSuburbDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxCity, ViewModel, nameof(CreateQuoteViewModel.BusinessPOBoxCityDisplay));
            BindingHelpers.BindText(lblBusinessPOBoxAreaCode, ViewModel, nameof(CreateQuoteViewModel.BusinessPOBoxAreaCodeDisplay));
            BindingHelpers.BindText(lblBusinessRegistrationNumber, ViewModel, nameof(CreateQuoteViewModel.BusinessRegistrationNumberDisplay));
            BindingHelpers.BindText(lblBusinessVATNumber, ViewModel, nameof(CreateQuoteViewModel.BusinessVATNumberDisplay));

            BindingHelpers.BindText(lblCustomerPOBoxStreetName, ViewModel, nameof(CreateQuoteViewModel.CustomerPOBoxStreetNameDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxSuburb, ViewModel, nameof(CreateQuoteViewModel.CustomerPOBoxSuburbDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxCity, ViewModel, nameof(CreateQuoteViewModel.CustomerPOBoxCityDisplay));
            BindingHelpers.BindText(lblCustomerPOBoxAreaCode, ViewModel, nameof(CreateQuoteViewModel.CustomerPOBoxAreaCodeDisplay));
            BindingHelpers.BindText(lblCustomerVendorNumber, ViewModel, nameof(CreateQuoteViewModel.CustomerVendorNumberDisplay));

            BindingHelpers.BindText(lblNewPumpUnitPrice, ViewModel, nameof(CreateQuoteViewModel.PumpPriceDisplay));
            BindingHelpers.BindText(lblRebateValue, ViewModel, nameof(CreateQuoteViewModel.RebateDisplay));
            BindingHelpers.BindText(lblSubTotalValue, ViewModel, nameof(CreateQuoteViewModel.SubTotalDisplay));
            BindingHelpers.BindText(lblVATValue, ViewModel, nameof(CreateQuoteViewModel.VATDisplay));
            BindingHelpers.BindText(lblTotalDueValue, ViewModel, nameof(CreateQuoteViewModel.TotalDueDisplay));
            BindingHelpers.BindText(lblRepairPercentage, ViewModel, nameof(CreateQuoteViewModel.RepairPercentageDisplay));

            gbxBusinessInformation.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxBusinessPOBoxDetails.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxQuoteNumberManagement.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxCustomerDeliveryAddressInformation.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxPumpRestorationDetails.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            BindingHelpers.BindReadOnly(dgvMandatoryPartReplacement, ViewModel, nameof(CreateQuoteViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(DgvNonMandatoryPartReplacement, ViewModel, nameof(CreateQuoteViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(cbxPumpSelection, ViewModel, nameof(CreateQuoteViewModel.IsEditing));
            BindingHelpers.BindVisible(btnComplete, ViewModel, nameof(CreateQuoteViewModel.ShowSaveButton));
            btnComplete.DataBindings.Add("Text", ViewModel, nameof(CreateQuoteViewModel.SaveButtonText));
            CommandBindings.Bind(btnComplete, ViewModel.CompleteQuoteCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            CommandBindings.Bind(BtnCalculateRebate, ViewModel.CalculateRebateCommand);
            CommandBindings.Bind(dtpQuoteCreationDate, ViewModel.UpdateDatesCommand);
            CommandBindings.Bind(dtpQuoteExpiryDate, ViewModel.UpdateDatesCommand);

            createNewQuoteUsingThisQuoteToolStripMenuItem.DataBindings.Add("Enabled", ViewModel, nameof(CreateQuoteViewModel.IsViewing));
        }

        private async System.Threading.Tasks.Task ExportQuoteToTemplateAsync(Quote q)
        {
            await ((AsyncRelayCommand)ViewModel.ExportQuoteCommand).ExecuteAsync(q);
        }

        // View-model bindings manage read-only state


        private void CreateNewQuoteUsingThisQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quoteToChange == null) quoteToChange = NewQuote;
            ViewModel.QuoteToChange = quoteToChange;
            ViewModel.ChangeSpecificObject = true;
            if (!string.IsNullOrEmpty(ViewModel.NextQuoteNumber))
                ViewModel.QuoteNumber = ViewModel.NextQuoteNumber;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            if (ViewModel.ExitCommand.CanExecute(null))
                ViewModel.ExitCommand.Execute(null);
        }

    }
}
