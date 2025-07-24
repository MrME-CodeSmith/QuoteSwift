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
    public partial class FrmCreateQuote : BaseForm
    {
        readonly CreateQuoteViewModel viewModel;
        public CreateQuoteViewModel ViewModel => viewModel;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        readonly Button btnCancelOperation;
        Quote quoteToChange;
        bool changeSpecificObject;
        public Quote NewQuote;



        public FrmCreateQuote(CreateQuoteViewModel viewModel, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            viewModel.CloseAction = Close;
            this.messageService = messageService;
            this.serializationService = serializationService;
            SetupBindings();
            BindIsBusy(viewModel);

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
            if (viewModel.CancelCommand.CanExecute(null))
                viewModel.CancelCommand.Execute(null);
        }

        private void BtnCancelOperation_Click(object sender, EventArgs e)
        {
            ((AsyncRelayCommand)viewModel.ExportQuoteCommand).Cancel();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }


        private async void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)viewModel.LoadDataCommand).ExecuteAsync(null);
            viewModel.QuoteToChange = quoteToChange;
            viewModel.ChangeSpecificObject = changeSpecificObject;
            if (viewModel.IsViewing)
            {
                viewModel.LoadPassedQuoteCommand.Execute(null);
            }
            else if (viewModel.IsEditing && viewModel.QuoteToChange != null)
            {
                viewModel.LoadPassedQuoteCommand.Execute(null);

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
        private void DgvMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            viewModel.Calculate();
        }

        private void DgvNonMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            viewModel.Calculate();
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
            BindingHelpers.BindDataGridView(dgvMandatoryPartReplacement, viewModel, nameof(CreateQuoteViewModel.MandatoryParts));

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
            BindingHelpers.BindDataGridView(DgvNonMandatoryPartReplacement, viewModel, nameof(CreateQuoteViewModel.NonMandatoryParts));

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
            mtxtRebate.DataBindings.Add("Value", viewModel, nameof(CreateQuoteViewModel.RebateInput), false, DataSourceUpdateMode.OnPropertyChanged);

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

            BindingHelpers.BindText(lblNewPumpUnitPrice, viewModel, nameof(CreateQuoteViewModel.PumpPriceDisplay));
            BindingHelpers.BindText(lblRebateValue, viewModel, nameof(CreateQuoteViewModel.RebateDisplay));
            BindingHelpers.BindText(lblSubTotalValue, viewModel, nameof(CreateQuoteViewModel.SubTotalDisplay));
            BindingHelpers.BindText(lblVATValue, viewModel, nameof(CreateQuoteViewModel.VATDisplay));
            BindingHelpers.BindText(lblTotalDueValue, viewModel, nameof(CreateQuoteViewModel.TotalDueDisplay));
            BindingHelpers.BindText(lblRepairPercentage, viewModel, nameof(CreateQuoteViewModel.RepairPercentageDisplay));

            gbxBusinessInformation.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxBusinessPOBoxDetails.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxQuoteNumberManagement.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxCustomerDeliveryAddressInformation.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsEditing));
            gbxPumpRestorationDetails.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsEditing));
            BindingHelpers.BindReadOnly(dgvMandatoryPartReplacement, viewModel, nameof(CreateQuoteViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(DgvNonMandatoryPartReplacement, viewModel, nameof(CreateQuoteViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(cbxPumpSelection, viewModel, nameof(CreateQuoteViewModel.IsEditing));
            BindingHelpers.BindVisible(btnComplete, viewModel, nameof(CreateQuoteViewModel.ShowSaveButton));
            btnComplete.DataBindings.Add("Text", viewModel, nameof(CreateQuoteViewModel.SaveButtonText));
            CommandBindings.Bind(btnComplete, viewModel.CompleteQuoteCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
            CommandBindings.Bind(BtnCalculateRebate, viewModel.CalculateRebateCommand);
            CommandBindings.Bind(dtpQuoteCreationDate, viewModel.UpdateDatesCommand);
            CommandBindings.Bind(dtpQuoteExpiryDate, viewModel.UpdateDatesCommand);

            createNewQuoteUsingThisQuoteToolStripMenuItem.DataBindings.Add("Enabled", viewModel, nameof(CreateQuoteViewModel.IsViewing));
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

        // View-model bindings manage read-only state


        private void CreateNewQuoteUsingThisQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quoteToChange == null) quoteToChange = NewQuote;
            viewModel.QuoteToChange = quoteToChange;
            viewModel.ChangeSpecificObject = true;
            if (!string.IsNullOrEmpty(viewModel.NextQuoteNumber))
                viewModel.QuoteNumber = viewModel.NextQuoteNumber;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }

}
