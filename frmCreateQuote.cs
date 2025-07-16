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
                NewQuote = CreateQuote();


                if (NewQuote != null)
                {
                    if (!viewModel.AddQuote(NewQuote))
                    {
                        messageService.ShowError("The provided quote number or Job number has been used in a previous quote.\nPlease ensure that the provided details are indeed correct.", "ERROR - Quote Number or Job Number Already Exists.");
                        return;
                    }

                    if (messageService.RequestConfirmation("The quote was successfully created. Would you like to export the quote an Excel document?", "REQUEST - Export Quote to Excel"))
                    {
                        ExportQuoteToTemplate(NewQuote);
                    }
                    else messageService.ShowInformation("The quote was successfully added to the list of quotes.", "INFORMATION - Quote Added To List");

                    quoteToChange = NewQuote;
                    ConvertToReadOnly();
                    createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = true;
                }
                else messageService.ShowError("The Quote could not be created successfully.", "ERROR - Quote Creation Unsuccessful");
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

                dtpQuoteCreationDate.Value = DateTime.Today;
                dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
                dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);
                dtpPaymentTerm.Value = DateTime.Today;

                Text = Text.Replace("<< Business Name >>", viewModel.SelectedBusiness.BusinessName);

                GetNewQuotenumber();
            }
            else //Create New
            {
                LoadComboBoxes();
                viewModel.LoadPartlists();
                mandatorySource.DataSource = viewModel.MandatoryParts;
                nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
                UpdatePricingDisplay();
                LoadBusinessPOBoxAddress();
                LoadBusinessLegalDatails();
                LoadCustomerDeliveryAddress();
                LoadCustomerPOBoxAddress();
                GetNewQuotenumber();

                dtpQuoteCreationDate.Value = DateTime.Today;
                dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
                dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);

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
            LoadCustomerDetails();
            LoadCustomerPOBoxAddress();
        }

        private void CbxBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedBusinessInformation();
            LoadBusinessPOBoxAddress();
            LoadBusinessLegalDatails();
            LoadCustomerPOBoxAddress();
        }

        private void CbxPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBusinessPOBoxAddress();
        }

        private void CbxCustomerDeliveryAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerDeliveryAddress();
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


        private Address GetBusinesssPOBoxAddressSelection(Business b)
        {
            string SearchName = CbxPOBoxSelection.Text;

            if (b.BusinessPOBoxAddressList != null) return b.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);

            return null;
        }

        private Address GetCustomerPOBoxAddressSelection(Customer c)
        {
            if (c != null)
            {
                string SearchName = CbxCustomerPOBoxSelection.Text;

                if (c.CustomerPOBoxAddress != null) return c.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
            }
            return null;
        }

        private Address GetCustomerDeliveryAddress()
        {
            string SearchName = cbxCustomerDeliveryAddress.Text;

            if (viewModel.SelectedCustomer != null && viewModel.SelectedCustomer.CustomerDeliveryAddressList != null) return viewModel.SelectedCustomer.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);

            return null;
        }

        private void LinkBusinessTelephone(Business b, ref ComboBox cb)
        {
            if (viewModel.Businesses != null && b != null)
            {
                //Created a Binding Source for the Business' Telephone list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessTelephoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessCellphone(Business b, ref ComboBox cb)
        {
            if (viewModel.Businesses != null && b != null)
            {
                //Created a Binding Source for the Business' Cellphone list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessCellphoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessEmail(Business b, ref ComboBox cb)
        {
            if (viewModel.Businesses != null && b != null)
            {
                //Created a Binding Source for the Business' Email list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessEmailAddressList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinesssPOBox(Business b, ref ComboBox cb)
        {
            if (b != null && b.BusinessPOBoxAddressList != null)
            {
                //Created a Binding Source for the Business' P.O.Box list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessPOBoxAddressList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "AddressDescription";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkCustomers(Business b, ref ComboBox cb)
        {
            if (b != null && b.BusinessCustomerList != null)
            {
                //Created a Binding Source for the Business' Customers list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessCustomerList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                //Linking the specific item from the Business class to display in the combo-box:

                cb.DisplayMember = "CustomerCompanyName";
                cb.ValueMember = "CustomerCompanyName";
            }
        }

        private void LinkCustomerDeliveryAddress(Customer c, ref ComboBox cb)
        {
            if (c != null && c.CustomerDeliveryAddressList != null)
            {
                //Created a Binding Source for the Customer's Delivery Address list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxSource = new BindingSource { DataSource = c.CustomerDeliveryAddressList };

                cb.DataSource = ComboBoxSource.DataSource;

                cb.DisplayMember = "AddressDescription";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkPumpList(ref ComboBox cb)
        {
            if (viewModel.Pumps != null)
            {
                //Created a Binding Source for the Pumps list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxSource = new BindingSource { DataSource = viewModel.Pumps };

                cb.DataSource = ComboBoxSource.DataSource;

                cb.DisplayMember = "PumpName";
                cb.ValueMember = "PumpName";
            }
        }

        private void LinkCustomerPOBox(Customer c, ref ComboBox cb)
        {
            if (c != null && c.CustomerPOBoxAddress != null)
            {
                //Created a Binding Source for the Customer's P.O.Box list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = c.CustomerPOBoxAddress };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "AddressDescription";
                cb.ValueMember = "AddressDescription";
            }
        }

        void LoadSelectedBusinessInformation()
        {
            LoadBusinessPOBoxAddress();
            LoadBusinessLegalDatails();
        }

        private void LoadComboBoxes()
        {
            if (viewModel.Businesses != null)
            {
                BindingSource bs = new BindingSource { DataSource = viewModel.Businesses };
                cbxBusinessSelection.DataSource = bs.DataSource;
                cbxBusinessSelection.DisplayMember = "BusinessName";
                cbxBusinessSelection.ValueMember = "BusinessName";
                cbxBusinessSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedBusiness), false, DataSourceUpdateMode.OnPropertyChanged);
            }

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

            cbxPumpSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.Pumps), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxPumpSelection.DisplayMember = "PumpName";
            cbxPumpSelection.ValueMember = "PumpName";
            cbxPumpSelection.DataBindings.Add("SelectedItem", viewModel, nameof(CreateQuoteViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);

            CbxPOBoxSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.BusinessPOBoxes), false, DataSourceUpdateMode.OnPropertyChanged);
            CbxPOBoxSelection.DisplayMember = "AddressDescription";
            CbxPOBoxSelection.ValueMember = "AddressDescription";

            CbxCustomerPOBoxSelection.DataBindings.Add("DataSource", viewModel, nameof(CreateQuoteViewModel.CustomerPOBoxes), false, DataSourceUpdateMode.OnPropertyChanged);
            CbxCustomerPOBoxSelection.DisplayMember = "AddressDescription";
            CbxCustomerPOBoxSelection.ValueMember = "AddressDescription";
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

        private void LoadBusinessPOBoxAddress()
        {
            Address Selection = GetBusinesssPOBoxAddressSelection(viewModel.SelectedBusiness);
            if (Selection != null)
            {
                lblBusinessPOBoxNumber.Text = "Street Name: " + Selection.AddressStreetName;
                lblBusinessPOBoxNumber.Text = "P.O.Box Number " + Selection.AddressStreetNumber.ToString();
                lblBusinessPOBoxSuburb.Text = "Suburb: " + Selection.AddressSuburb;
                lblBusinessPOBoxCity.Text = "City: " + Selection.AddressCity;
                lblBusinessPOBoxAreaCode.Text = "Area Code: " + Selection.AddressAreaCode.ToString();
            }
        }
        private void LoadCustomerPOBoxAddress()
        {
            Address Selection = GetCustomerPOBoxAddressSelection(viewModel.SelectedCustomer);
            if (Selection != null)
            {
                lblCustomerPOBoxStreetName.Text = "P.O.Box Number " + Selection.AddressStreetNumber.ToString();
                lblCustomerPOBoxSuburb.Text = "Suburb: " + Selection.AddressSuburb;
                lblCustomerPOBoxCity.Text = "City: " + Selection.AddressCity;
                lblCustomerPOBoxAreaCode.Text = "Area Code: " + Selection.AddressAreaCode.ToString();
            }
        }

        private void LoadBusinessLegalDatails()
        {
            Business Selection = viewModel.SelectedBusiness;
            lblBusinessRegistrationNumber.Text = "Registration Number: " + Selection.BusinessLegalDetails.RegistrationNumber;
            lblBusinessVATNumber.Text = "VAT Number: " + Selection.BusinessLegalDetails.VatNumber;
        }

        private void LoadCustomerDeliveryAddress()
        {
            Address Selection = GetCustomerDeliveryAddress();
            if (Selection != null)
            {
                rtxCustomerDeliveryDescripton.Clear();
                rtxCustomerDeliveryDescripton.Text = "ATT: " + Selection.AddressStreetName.ToString() +
                                                     "\n" + Selection.AddressSuburb +
                                                     "\n" + Selection.AddressCity;
            }
        }

        private void LoadCustomerDetails()
        {
            LoadCustomerDeliveryAddress();
            lblCustomerVendorNumber.Text = "Vendor Number: " + viewModel.SelectedCustomer.VendorNumber;
            txtCustomerVATNumber.Text = viewModel.SelectedCustomer.CustomerLegalDetails.VatNumber;
        }

        private void CbxCustomerPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerPOBoxAddress();
        }

        private bool ValidInput()
        {
            if (txtCustomerVATNumber.Text.Length < 3)
            {
                messageService.ShowError("Please provide a valid Customer VAT Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtJobNumber.Text.Length < 3)
            {
                messageService.ShowError("Please provide a valid Job Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtReferenceNumber.Text.Length < 3)
            {
                messageService.ShowError("Please provide a valid Reference Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtPRNumber.Text.Length < 3)
            {
                messageService.ShowError("Please provide a valid PR Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtLineNumber.Text.Length == 0)
            {
                messageService.ShowError("Please provide a valid Line Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtQuoteNumber.Text.Length < 8)
            {
                messageService.ShowError("Please provide a valid Quote Number", "ERROR - Invalid Quote Input");
                return false;
            }

            return true;
        }

        private void CbxUseAutomaticNumberingScheme_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUseAutomaticNumberingScheme.Checked)
            {
                txtQuoteNumber.ReadOnly = true;
                GetNewQuotenumber();
            }
            else
            {
                txtQuoteNumber.ReadOnly = false;
            }
        }

        Quote CreateQuote()
        {
            if (!ValidInput()) return null;

            viewModel.Pricing.Rebate = ParsingService.ParseDecimal(mtxtRebate.Text);
            viewModel.Calculate();

            var quote = viewModel.CreateQuote(txtQuoteNumber.Text,
                                               dtpQuoteCreationDate.Value,
                                               dtpQuoteExpiryDate.Value,
                                               txtReferenceNumber.Text,
                                               txtJobNumber.Text,
                                               txtPRNumber.Text,
                                               dtpPaymentTerm.Value,
                                               GetBusinesssPOBoxAddressSelection(viewModel.SelectedBusiness),
                                               GetCustomerPOBoxAddressSelection(viewModel.SelectedCustomer),
                                               txtLineNumber.Text,
                                               cbxBusinessTelephoneNumberSelection.Text,
                                               cbxBusinessCellphoneNumberSelection.Text,
                                               cbxBusinessEmailAddressSelection.Text,
                                               (int)(dtpPaymentTerm.Value.Subtract(dtpQuoteCreationDate.Value)).TotalDays,
                                               viewModel.Pricing);

            return quote;
        }

        private void ExportQuoteToTemplate(Quote q)
        {
            UseWaitCursor = true;
            viewModel.ExportQuoteToTemplate(q);
            UseWaitCursor = false;
        }

        private void GetNewQuotenumber()
        {
            if (viewModel.QuoteMap != null && viewModel.QuoteMap.Count > 0)
            {
                Quote temp = viewModel.QuoteMap.First().Value;
                int LastQuoteNumber = GetQuoteNumber(ref temp);
                foreach (var q in viewModel.QuoteMap.Values.Skip(1))
                {
                    temp = q;
                    if (LastQuoteNumber < GetQuoteNumber(ref temp)) LastQuoteNumber = GetQuoteNumber(ref temp);
                }
                LastQuoteNumber++;
                txtQuoteNumber.Text = "TRR" + LastQuoteNumber.ToString();
            }
        }

        int GetQuoteNumber(ref Quote q)
        {
            if (q != null)
            {
                string QuoteNumber = q.QuoteNumber;
                if (QuoteNumber.Contains("_"))
                {
                    if (QuoteNumber.Contains("TRR")) //23612
                    {
                        int pos = QuoteNumber.IndexOf("TRR") + 3;
                        string Number = QuoteNumber.Substring(pos, QuoteNumber.Length - pos);
                        pos = Number.IndexOf("_");
                        Number = Number.Remove(pos, Number.Length - pos);
                        return ParsingService.ParseInt(Number);
                    }
                }
                else
                {
                    if (QuoteNumber.Contains("TRR"))
                    {
                        int pos = QuoteNumber.IndexOf("TRR") + 3;
                        string Number = QuoteNumber.Substring(pos, QuoteNumber.Length - pos);
                        return ParsingService.ParseInt(Number);
                    }
                }
            }
            return 0;
        }

        private void LoadFromPassedObject()
        {
            cbxPumpSelection.Text = quoteToChange.PumpName;

            viewModel.MandatoryParts = new BindingList<Quote_Part>(quoteToChange.QuoteMandatoryPartList.ToList());
            viewModel.NonMandatoryParts = new BindingList<Quote_Part>(quoteToChange.QuoteNewList.ToList());
            viewModel.NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6MACH", PartDescription = "MACHINING", PartPrice = quoteToChange.QuoteCost.Machining }, 1), 0, 0, 1, quoteToChange.QuoteCost.Machining, quoteToChange.QuoteCost.Machining, 1));
            viewModel.NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6LAB", PartDescription = "LABOUR", PartPrice = quoteToChange.QuoteCost.Labour }, 1), 0, 0, 1, quoteToChange.QuoteCost.Labour, quoteToChange.QuoteCost.Labour, 1));
            viewModel.NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "CON TS6", PartDescription = "CONSUMABLES incl COLLECTION & DELIVERY", PartPrice = quoteToChange.QuoteCost.Consumables }, 1), 0, 0, 1, quoteToChange.QuoteCost.Consumables, quoteToChange.QuoteCost.Consumables, 1));
            mandatorySource.DataSource = viewModel.MandatoryParts;
            nonMandatorySource.DataSource = viewModel.NonMandatoryParts;
            UpdatePricingDisplay();

            //Loading Business Information:
            Address add = quoteToChange.QuoteBusinessPOBox;
            cbxBusinessSelection.Text = quoteToChange.QuoteCompany.BusinessName;
            CbxPOBoxSelection.Text = add.AddressDescription;
            lblBusinessPOBoxNumber.Text = "P.O.Box " + add.AddressStreetNumber;
            lblBusinessPOBoxSuburb.Text = add.AddressSuburb;
            lblBusinessPOBoxCity.Text = add.AddressCity;
            lblBusinessPOBoxAreaCode.Text = add.AddressAreaCode.ToString();

            lblBusinessRegistrationNumber.Text = quoteToChange.QuoteCompany.BusinessLegalDetails.RegistrationNumber;
            lblBusinessVATNumber.Text = quoteToChange.QuoteCompany.BusinessLegalDetails.VatNumber;
            cbxBusinessTelephoneNumberSelection.Text = quoteToChange.Telefone;
            cbxBusinessCellphoneNumberSelection.Text = quoteToChange.Cellphone;
            cbxBusinessEmailAddressSelection.Text = quoteToChange.Email;

            //Loading Customer Section:
            add = quoteToChange.QuoteCustomerPOBox;
            cbxCustomerSelection.Text = quoteToChange.QuoteCustomer.CustomerCompanyName;
            CbxCustomerPOBoxSelection.Text = add.AddressDescription;
            lblCustomerPOBoxStreetName.Text = "Private Bag X" + add.AddressStreetNumber;
            lblCustomerPOBoxSuburb.Text = add.AddressSuburb;
            lblCustomerPOBoxCity.Text = add.AddressCity;
            lblCustomerPOBoxAreaCode.Text = add.AddressAreaCode.ToString();

            cbxCustomerDeliveryAddress.Text = quoteToChange.QuoteCustomer.CustomerName;
            rtxCustomerDeliveryDescripton.Text = quoteToChange.QuoteDeliveryAddress;
            txtCustomerVATNumber.Text = quoteToChange.QuoteCustomer.CustomerLegalDetails.VatNumber;

            //Loading other Quote Details:
            txtJobNumber.Text = quoteToChange.QuoteJobNumber;
            txtReferenceNumber.Text = quoteToChange.QuoteReference;
            txtPRNumber.Text = quoteToChange.QuotePRNumber;
            txtLineNumber.Text = quoteToChange.QuoteLineNumber;
            dtpPaymentTerm.Value = quoteToChange.QuotePaymentTerm;

            txtQuoteNumber.Text = quoteToChange.QuoteNumber;

            dtpQuoteCreationDate.Value = quoteToChange.QuoteCreationDate;
            dtpQuoteExpiryDate.Value = quoteToChange.QuoteExpireyDate;

            lblNewPumpUnitPrice.Text = "New Pump Price: R " + quoteToChange.QuoteCost.PumpPrice.ToString();
            lblRepairPercentage.Text = quoteToChange.QuoteRepairPercentage + "%";
            lblRebateValue.Text = "R" + quoteToChange.QuoteCost.Rebate.ToString();
            lblSubTotalValue.Text = "R" + quoteToChange.QuoteCost.SubTotal.ToString();
            lblVATValue.Text = "R" + quoteToChange.QuoteCost.VAT.ToString();
            lblTotalDueValue.Text = "R" + quoteToChange.QuoteCost.TotalDue.ToString();

            mtxtRebate.Text = quoteToChange.QuoteCost.Rebate.ToString();
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
            GetNewQuotenumber();
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
