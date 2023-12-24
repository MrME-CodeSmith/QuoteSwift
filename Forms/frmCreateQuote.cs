using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmCreateQuote : Form
    {
        AppContext mPassed;

        public Quote NewQuote;

        readonly Pricing mP = new Pricing();

        public FrmCreateQuote()
        {
            InitializeComponent();
        }

        public ref AppContext Passed { get => ref mPassed; }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (mPassed != null && !mPassed.ChangeSpecificObject && mPassed.QuoteToChange != null)
            {
                NewQuote = mPassed.QuoteToChange;
                ExportQuoteToTemplate();
                NewQuote = null;
            }
            else
            {
                NewQuote = CreateQuote();


                if (NewQuote != null)
                {
                    if (!DistinctQuote(ref NewQuote))
                    {
                        MainProgramCode.ShowError("The provided quote number or Job number has been used in a previous quote.\nPlease ensure that the provided details are indeed correct.", "ERROR - Quote Number or Job Number Already Exists.");
                        return;
                    }


                    if (mPassed.QuoteMap != null)
                    {
                        mPassed.QuoteMap.Add(NewQuote.QuoteNumber, NewQuote);
                    }
                    else mPassed.QuoteMap = new Dictionary<string, Quote>() { { NewQuote.QuoteNumber ,NewQuote } };

                    if (MainProgramCode.RequestConfirmation("The quote was successfully created. Would you like to export the quote an Excel document?", "REQUEST - Export Quote to Excel"))
                    {
                        ExportQuoteToTemplate();
                    }
                    else MainProgramCode.ShowInformation("The quote was successfully added to the list of quotes.", "INFORMATION - Quote Added To List");

                    mPassed.QuoteToChange = NewQuote;
                    ConvertToReadOnly();
                    createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = true;
                    mPassed.QuoteToChange = null;
                }
                else MainProgramCode.ShowError("The Quote could not be created successfully.", "ERROR - Quote Creation Unsuccessful");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void CbxPumpSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPartlists();
        }

        private void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            if (mPassed != null && !mPassed.ChangeSpecificObject && mPassed.QuoteToChange != null) // View Quote
            {
                LoadFromPassedObject();
                ConvertToReadOnly();
                createNewQuoteUsingThisQuoteToolStripMenuItem.Enabled = true;
            }
            else if (mPassed != null && mPassed.ChangeSpecificObject && mPassed.QuoteToChange != null)//Create New Quote Using Passed Quote
            {
                LoadFromPassedObject();

                dtpQuoteCreationDate.Value = DateTime.Today;
                dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
                dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);
                dtpPaymentTerm.Value = DateTime.Today;

                Text = Text.Replace("<< Business Name >>", GetBusinessSelection().BusinessName);

                GetNewQuotenumber();
            }
            else //Create New
            {
                LoadComboBoxes();
                LoadPartlists();
                LoadBusinessPoBoxAddress();
                LoadBusinessLegalDatails();
                LoadCustomerDeliveryAddress();
                LoadCustomerPoBoxAddress();
                GetNewQuotenumber();

                dtpQuoteCreationDate.Value = DateTime.Today;
                dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
                dtpPaymentTerm.Value = dtpQuoteCreationDate.Value.AddMonths(1);

                Text = Text.Replace("<< Business Name >>", GetBusinessSelection().BusinessName);
                if (mPassed.QuoteMap == null || mPassed.QuoteMap.Count == 0)
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
            LinkCustomerDeliveryAddress(GetCustomerSelection(), ref cbxCustomerDeliveryAddress);
            LoadCustomerDetails();
            LinkCustomerPoBox(GetCustomerSelection(), ref CbxCustomerPOBoxSelection);
            LoadCustomerPoBoxAddress();
        }

        private void CbxBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkBusinessTelephone(GetBusinessSelection(), ref cbxBusinessTelephoneNumberSelection);
            LinkBusinessCellphone(GetBusinessSelection(), ref cbxBusinessCellphoneNumberSelection);
            LinkBusinessEmail(GetBusinessSelection(), ref cbxBusinessEmailAddressSelection);
            LinkCustomers(GetBusinessSelection(), ref cbxCustomerSelection);
            LinkBusinesssPoBox(GetBusinessSelection(), ref CbxPOBoxSelection);

            LoadSelectedBusinessInformation();
            LoadBusinessPoBoxAddress();
            LoadBusinessLegalDatails();
            LoadCustomerPoBoxAddress();
        }

        private void CbxPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBusinessPoBoxAddress();
        }

        private void CbxCustomerDeliveryAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerDeliveryAddress();
        }

        private void DgvMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate(true);
        }

        private void DgvNonMandatoryPartReplacement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate(true);
        }

        private Business GetBusinessSelection()
        {
            Business business;
            string SearchName = cbxBusinessSelection.Text;

            if (mPassed.BusinessMap != null && SearchName.Length > 1)
            {
                business = mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessName == SearchName).Value;
                return business;
            }

            return null;
        }

        private Customer GetCustomerSelection()
        {
            string SearchName = cbxCustomerSelection.Text;
            if (SearchName.Length > 1)
                if (mPassed.BusinessMap != null)
                    if (GetBusinessSelection().CustomerList != null)
                    {
                        return GetBusinessSelection().CustomerList.SingleOrDefault(p => p.CustomerCompanyName == SearchName);
                    }

            return null;
        }

        private Product GetPumpSelection()
        {
            string SearchName = cbxPumpSelection.Text;

            if (mPassed.ProductMap != null) return mPassed.ProductMap.SingleOrDefault(p => p.Value.ProductName == SearchName).Value;

            return null;
        }

        private Address GetBusinesssPoBoxAddressSelection(Business b)
        {
            string SearchName = CbxPOBoxSelection.Text;

            if (b.BusinessPoBoxAddressList != null) return b.BusinessPoBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);

            return null;
        }

        private Address GetCustomerPoBoxAddressSelection(Customer c)
        {
            if (c != null)
            {
                string SearchName = CbxCustomerPOBoxSelection.Text;

                if (c.CustomerPoBoxAddress != null) return c.CustomerPoBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
            }
            return null;
        }

        private Address GetCustomerDeliveryAddress()
        {
            string SearchName = cbxCustomerDeliveryAddress.Text;

            if (GetCustomerSelection() != null && GetCustomerSelection().CustomerDeliveryAddressList != null) return GetCustomerSelection().CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);

            return null;
        }

        private void LinkBusinessTelephone(Business b, ref ComboBox cb)
        {
            if (mPassed != null && mPassed.BusinessMap != null && b != null)
            {
                //Created a Binding Source for the Business' Telephone list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessTelephoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessCellphone(Business b, ref ComboBox cb)
        {
            if (mPassed != null && mPassed.BusinessMap != null && b != null)
            {
                //Created a Binding Source for the Business' Cellphone list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessCellphoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessEmail(Business b, ref ComboBox cb)
        {
            if (mPassed != null && mPassed.BusinessMap != null && b != null)
            {
                //Created a Binding Source for the Business' Email list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessEmailAddressList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinesssPoBox(Business b, ref ComboBox cb)
        {
            if (b != null && b.BusinessPoBoxAddressList != null)
            {
                //Created a Binding Source for the Business' P.O.Box list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessPoBoxAddressList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "BusinessName";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkCustomers(Business b, ref ComboBox cb)
        {
            if (b != null && b.CustomerList != null)
            {
                //Created a Binding Source for the Business' Customers list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = b.CustomerList };

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

                cb.DisplayMember = "CustomerName";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkPumpList(ref ComboBox cb)
        {
            if (mPassed != null && mPassed.ProductMap != null)
            {
                //Created a Binding Source for the Pumps list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxSource = new BindingSource { DataSource = mPassed.ProductMap };

                cb.DataSource = ComboBoxSource.DataSource;

                cb.DisplayMember = "PumpName";
                cb.ValueMember = "PumpName";
            }
        }

        private void LinkCustomerPoBox(Customer c, ref ComboBox cb)
        {
            if (c != null && c.CustomerPoBoxAddress != null)
            {
                //Created a Binding Source for the Customer's P.O.Box list to link the source
                //directly to the combo-box's data-source:

                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = c.CustomerPoBoxAddress };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "CustomerName";
                cb.ValueMember = "AddressDescription";
            }
        }

        void LoadSelectedBusinessInformation()
        {
            LoadBusinessPoBoxAddress();
            LoadBusinessLegalDatails();
        }

        private void LoadComboBoxes()
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers();
            frmViewCustomers.LinkBusinessToSource(ref cbxBusinessSelection);

            LinkBusinessTelephone(GetBusinessSelection(), ref cbxBusinessTelephoneNumberSelection);
            LinkBusinessCellphone(GetBusinessSelection(), ref cbxBusinessCellphoneNumberSelection);
            LinkBusinessEmail(GetBusinessSelection(), ref cbxBusinessEmailAddressSelection);
            LinkCustomers(GetBusinessSelection(), ref cbxCustomerSelection);
            LinkCustomerDeliveryAddress(GetCustomerSelection(), ref cbxCustomerDeliveryAddress);
            LinkPumpList(ref cbxPumpSelection);
            LinkBusinesssPoBox(GetBusinessSelection(), ref CbxPOBoxSelection);
            LinkCustomerPoBox(GetCustomerSelection(), ref CbxCustomerPOBoxSelection);
        }

        private void LoadPartlists()
        {
            dgvMandatoryPartReplacement.Rows.Clear();
            DgvNonMandatoryPartReplacement.Rows.Clear();

            if (mPassed != null && mPassed.ProductMap != null && cbxPumpSelection.SelectedIndex > -1)
            {
                Product display = GetPumpSelection();

                if (display != null) LoadParts(display);
            }
            Calculate();
        }

        void LoadParts(Product p)
        {
            if (p.PartList != null)
            {
                dgvMandatoryPartReplacement.Rows.Clear();
                DgvNonMandatoryPartReplacement.Rows.Clear();

                for (int i = 0; i < p.PartList.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    if (p.PartList[i].Part.MandatoryPart)
                        dgvMandatoryPartReplacement.Rows.Add(p.PartList[i].Part.NewPartNumber,
                                                             p.PartList[i].Part.PartDescription,
                                                             p.PartList[i].PumpPartQuantity,
                                                             p.PartList[i].PumpPartQuantity,
                                                             0,
                                                             p.PartList[i].PumpPartQuantity,
                                                             (p.PartList[i].PumpPartQuantity * p.PartList[i].Part.PartPrice),
                                                             p.PartList[i].Part.PartPrice,
                                                             0, 1);
                    else DgvNonMandatoryPartReplacement.Rows.Add(p.PartList[i].Part.NewPartNumber,
                                                                 p.PartList[i].Part.PartDescription,
                                                                 p.PartList[i].PumpPartQuantity,
                                                                 p.PartList[i].PumpPartQuantity,
                                                                 0,
                                                                 p.PartList[i].PumpPartQuantity,
                                                                 0,
                                                                 p.PartList[i].Part.PartPrice,
                                                                 0, 1);

                }
                DgvNonMandatoryPartReplacement.Rows.Add("TS6MACH", "MACHINING", 1, 0, 0, 1, 0, 1000, 0, 1);
                DgvNonMandatoryPartReplacement.Rows.Add("TS6LAB", "LABOUR", 1, 0, 0, 1, 0, 1000, 0, 1);
                DgvNonMandatoryPartReplacement.Rows.Add("CON TS6", "CONSUMABLES incl COLLECTION & DELIVERY", 1, 0, 0, 1, 0, 1000, 0, 1);

                lblNewPumpUnitPrice.Text = "New Pump Price: R " + p.NewProductPrice.ToString();
            }
        }

        private void LoadBusinessPoBoxAddress()
        {
            Address Selection = GetBusinesssPoBoxAddressSelection(GetBusinessSelection());
            if (Selection != null)
            {
                lblBusinessPOBoxNumber.Text = "Street Name: " + Selection.AddressStreetName;
                lblBusinessPOBoxNumber.Text = "P.O.Box Number " + Selection.AddressStreetNumber.ToString();
                lblBusinessPOBoxSuburb.Text = "Suburb: " + Selection.AddressSuburb;
                lblBusinessPOBoxCity.Text = "City: " + Selection.AddressCity;
                lblBusinessPOBoxAreaCode.Text = "Area Code: " + Selection.AddressAreaCode.ToString();
            }
        }
        private void LoadCustomerPoBoxAddress()
        {
            Address Selection = GetCustomerPoBoxAddressSelection(GetCustomerSelection());
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
            Business Selection = GetBusinessSelection();
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
            lblCustomerVendorNumber.Text = "Vendor Number: " + GetCustomerSelection().VendorNumber;
            txtCustomerVATNumber.Text = GetCustomerSelection().CustomerLegalDetails.VatNumber;
        }

        private void CbxCustomerPOBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomerPoBoxAddress();
        }

        void Calculate(bool b = false)
        {
            // Calculate datagridviews' Price and Total columns

            if (b)
            {
                dgvMandatoryPartReplacement.Rows.RemoveAt(dgvMandatoryPartReplacement.Rows.Count - 1);
                DgvNonMandatoryPartReplacement.Rows.RemoveAt(DgvNonMandatoryPartReplacement.Rows.Count - 1);
            }

            float Sum = 0;
            int size = dgvMandatoryPartReplacement.Rows.Count;

            for (int i = 0; i < size; i++)
            {
                if (b)
                {
                    dgvMandatoryPartReplacement.Rows[i].Cells["clmMMissing_Scrap"].Value = QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmQuantity"].Value.ToString()) -
                                                                                               QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmMRepaired"].Value.ToString());

                    dgvMandatoryPartReplacement.Rows[i].Cells["clmNew"].Value = dgvMandatoryPartReplacement.Rows[i].Cells["clmMMissing_Scrap"].Value;
                }
                dgvMandatoryPartReplacement.Rows[i].Cells["clmPrice"].Value = (QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmUnitPrice"].Value.ToString()) *
                                                                               QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmNew"].Value.ToString())) +
                                                                              (QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmMRepaired"].Value.ToString()) *
                                                                              (QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmUnitPrice"].Value.ToString()) /
                                                                               QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["ClmRepairDevider"].Value.ToString())));

                Sum += QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmPrice"].Value.ToString());

                if (i == dgvMandatoryPartReplacement.Rows.Count - 1) dgvMandatoryPartReplacement.Rows.Add("-", "-", "-", "-", "-", "-", "-", "-", Sum, "-");
            }

            size = DgvNonMandatoryPartReplacement.Rows.Count;
            for (int i = 0; i < size; i++)
            {
                if (b)
                {
                    DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMMissing_Scrap"].Value = QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[2].Value.ToString()) -
                                                                                               QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepaired"].Value.ToString());

                    DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMNewPartQuantity"].Value = DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMMissing_Scrap"].Value;
                }
                DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMPrice"].Value = (QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMUnitPrice"].Value.ToString()) *
                                                                                  QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMNewPartQuantity"].Value.ToString())) +
                                                                                 (QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepaired"].Value.ToString()) *
                                                                                 (QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMUnitPrice"].Value.ToString()) /
                                                                                  QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepairDevider"].Value.ToString())));

                Sum += QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMPrice"].Value.ToString());

                if (i == DgvNonMandatoryPartReplacement.Rows.Count - 1)
                    DgvNonMandatoryPartReplacement.Rows.Add("-", "-", "-", "-", "-", "-", "-", "-", Sum - QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[DgvNonMandatoryPartReplacement.Rows.Count - 1].Cells[8].Value.ToString()), "-");
            }

            // Display Sum of all totals:

            mP.Rebate = QuoteSwiftMainCode.ParseFloat(mtxtRebate.Text);
            mP.SubTotal = (Sum -= QuoteSwiftMainCode.ParseFloat(mtxtRebate.Text));
            mP.Vat = (Sum * 0.15f);
            mP.TotalDue = (Sum *= 1.15f);

            mP.Machining = GetPriceForNmItem("MACHINING");
            mP.Labour = GetPriceForNmItem("LABOUR");
            mP.Consumables = GetPriceForNmItem("CONSUMABLES incl COLLECTION & DELIVERY");

            lblRebateValue.Text = "R" + mP.Rebate.ToString();
            lblSubTotalValue.Text = "R" + mP.SubTotal.ToString();
            lblVATValue.Text = "R" + mP.Vat.ToString();
            lblTotalDueValue.Text = "R" + mP.TotalDue.ToString();

            lblRebateValue.Left = 107;
            lblSubTotalValue.Left = 107;
            lblVATValue.Left = 107;
            lblTotalDueValue.Left = 107;



            lblRepairPercentage.Text = "Repair Percentage: " + Convert.ToString((mP.SubTotal / GetPumpSelection().NewProductPrice) * 100) + "%";
        }

        private void BtnCalculateRebate_Click(object sender, EventArgs e)
        {
            Calculate(true);
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

        private bool ValidInput()
        {
            if (txtCustomerVATNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please provide a valid Customer VAT Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtJobNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please provide a valid Job Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtReferenceNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please provide a valid Reference Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtPRNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please provide a valid PR Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtLineNumber.Text.Length == 0)
            {
                MainProgramCode.ShowError("Please provide a valid Line Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (txtQuoteNumber.Text.Length < 8)
            {
                MainProgramCode.ShowError("Please provide a valid Quote Number", "ERROR - Invalid Quote Input");
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

        ProductPart GetPart(string s, BindingList<ProductPart> bl)
        {

            if (bl != null && s != "")
            {
                for (int i = 0; i < bl.Count; i++)
                {
                    if (bl[i].Part.NewPartNumber == s)
                    {
                        return bl[i];
                    }
                }
            }

            return null;
        }

        Quote CreateQuote()
        {
            if (!ValidInput()) return null;



            BindingList<QuotePart> MandatoryPartList = new BindingList<QuotePart>();
            for (int i = 0; i < dgvMandatoryPartReplacement.Rows.Count; i++)
            {
                if (dgvMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString() != "-")
                {
                    QuotePart quotePart = new QuotePart(GetPart(dgvMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString(),
                                                                   GetPumpSelection().PartList),
                                                           QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[3].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[4].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[5].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[6].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[9].Value.ToString()));

                    MandatoryPartList.Add(quotePart);
                }
            }


            BindingList<QuotePart> NonMandatoryPartList = new BindingList<QuotePart>();
            for (int i = 0; i < DgvNonMandatoryPartReplacement.Rows.Count - 4; i++)
            {
                if (DgvNonMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString() != "-")
                {
                    QuotePart quotePart = new QuotePart(GetPart(DgvNonMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString(), GetPumpSelection().PartList),
                                                           QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[3].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[4].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[5].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[6].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString()),
                                                           QuoteSwiftMainCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[9].Value.ToString()));

                    NonMandatoryPartList.Add(quotePart);
                }
            }

            Quote CreateQuote = new Quote(txtQuoteNumber.Text,
                                         dtpQuoteCreationDate.Value,
                                         dtpQuoteExpiryDate.Value,
                                         txtReferenceNumber.Text,
                                         txtJobNumber.Text,
                                         txtPRNumber.Text,
                                         dtpPaymentTerm.Value,
                                         new Address(GetBusinesssPoBoxAddressSelection(GetBusinessSelection())),
                                         new Address(GetCustomerPoBoxAddressSelection(GetCustomerSelection())),
                                         txtLineNumber.Text,
                                         GetPumpSelection().NewProductPrice,
                                         ((QuoteSwiftMainCode.ParseFloat(lblTotalDue.Text) / GetPumpSelection().NewProductPrice) * 100),
                                         rtxCustomerDeliveryDescripton.Text,
                                         new Customer(GetCustomerSelection()),
                                         new Business(GetBusinessSelection()),
                                         MandatoryPartList,
                                         NonMandatoryPartList,
                                         cbxBusinessTelephoneNumberSelection.Text,
                                         cbxBusinessCellphoneNumberSelection.Text,
                                         cbxBusinessEmailAddressSelection.Text,
                                         (int)(dtpPaymentTerm.Value.Subtract(dtpQuoteCreationDate.Value)).TotalDays,
                                         mP,
                                         cbxPumpSelection.Text);

            CreateQuote.QuoteRepairPercentage = ((float)(mP.SubTotal / GetPumpSelection().NewProductPrice * 100));
            return CreateQuote;
        }

        public void ExportQuoteToTemplate()
        {
            MainProgramCode.ExportQuote(ref NewQuote);

            try
            {
                Process ExportHandler = new Process();
                ExportHandler.StartInfo.FileName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ExportToExcel\\ExportToExcel.exe";
                ExportHandler.StartInfo.Verb = "runas";
                ExportHandler.StartInfo.Arguments = "-n";
                ExportHandler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                UseWaitCursor = true;

                ExportHandler.Start();
                ExportHandler.WaitForExit();
            }
            catch 
            {
                //Do Nothing...
            }
            finally
            {
                UseWaitCursor = false;
                string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ExportToExcel\\ExportQuote.pbf";
                if (File.Exists(StorePath))
                {
                    MainProgramCode.ShowError("The quote did not export as intended.", "ERROR - Export Failed Complete Successfully");
                    File.Delete(StorePath);
                }
            }
            

        }

        private float GetPriceForNmItem(string s)
        {
            if (s != "")
            {
                for (int i = 0; i < DgvNonMandatoryPartReplacement.Rows.Count; i++)
                {
                    if (DgvNonMandatoryPartReplacement.Rows[i].Cells[1].Value.ToString() == s)
                    {
                        return (float)double.Parse(DgvNonMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                    }
                }
            }
            return 0;
        }

        private bool DistinctQuote(ref Quote q)
        {
            Quote Provided = q;

            if (mPassed.QuoteMap != null)
            {
                Quote Search = mPassed.QuoteMap.SingleOrDefault(p => p.Value.QuoteJobNumber == Provided.QuoteJobNumber || p.Value.QuoteNumber == Provided.QuoteNumber).Value;
                if (Search != null) return false;
            }

            return true;
        }

        private void GetNewQuotenumber()
        {
            if (mPassed != null && mPassed.QuoteMap != null)
            {
                Quote temp = mPassed.QuoteMap.Values.ToArray()[0];
                int LastQuoteNumber = GetQuoteNumber(ref temp);
                for (int i = 1; i < mPassed.QuoteMap.Count; i++)
                {
                    temp = mPassed.QuoteMap.Values.ToArray()[i];
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
                        return QuoteSwiftMainCode.ParseInt(Number);
                    }
                }
                else
                {
                    if (QuoteNumber.Contains("TRR"))
                    {
                        int pos = QuoteNumber.IndexOf("TRR") + 3;
                        string Number = QuoteNumber.Substring(pos, QuoteNumber.Length - pos);
                        return QuoteSwiftMainCode.ParseInt(Number);
                    }
                }
            }
            return 0;
        }

        private void LoadFromPassedObject()
        {
            dgvMandatoryPartReplacement.Rows.Clear();
            DgvNonMandatoryPartReplacement.Rows.Clear();
            //Manually setting the data grid's mandatory rows' values:
            cbxPumpSelection.Text = mPassed.QuoteToChange.PumpName;

            for (int i = 0; i < mPassed.QuoteToChange.QuoteMandatoryPartList.Count; i++)
            {
                QuotePart data = mPassed.QuoteToChange.QuoteMandatoryPartList[i];
                if (data != null)
                    dgvMandatoryPartReplacement.Rows.Add(data.PumpPart.Part.NewPartNumber,
                                                         data.PumpPart.Part.PartDescription,
                                                         data.PumpPart.PumpPartQuantity,
                                                         data.MissingorScrap,
                                                         data.Repaired,
                                                         data.New,
                                                         data.Price,
                                                         data.UnitPrice,
                                                         ((data.UnitPrice * data.New) + (data.Repaired * (data.UnitPrice / data.RepairDevider))),
                                                         data.RepairDevider);
            }
            for (int i = 0; i < mPassed.QuoteToChange.QuoteNewList.Count; i++)
            {
                QuotePart data = mPassed.QuoteToChange.QuoteNewList[i];
                if (data != null)
                    DgvNonMandatoryPartReplacement.Rows.Add(data.PumpPart.Part.NewPartNumber,
                                                         data.PumpPart.Part.PartDescription,
                                                         data.PumpPart.PumpPartQuantity,
                                                         data.MissingorScrap,
                                                         data.Repaired,
                                                         data.New,
                                                         data.Price,
                                                         data.UnitPrice,
                                                         ((data.UnitPrice * data.New) + (data.Repaired * (data.UnitPrice / data.RepairDevider))),
                                                         data.RepairDevider);
            }
            DgvNonMandatoryPartReplacement.Rows.Add("TS6MACH", "MACHINING", 1, 0, 0, 1, 0, mPassed.QuoteToChange.QuoteCost.Machining, 0, 1);
            DgvNonMandatoryPartReplacement.Rows.Add("TS6LAB", "LABOUR", 1, 0, 0, 1, 0, mPassed.QuoteToChange.QuoteCost.Labour, 0, 1);
            DgvNonMandatoryPartReplacement.Rows.Add("CON TS6", "CONSUMABLES incl COLLECTION & DELIVERY", 1, 0, 0, 1, 0, mPassed.QuoteToChange.QuoteCost.Consumables, 0, 1);

            //Loading Business Information:
            Address add = mPassed.QuoteToChange.QuoteBusinessPoBox;
            cbxBusinessSelection.Text = mPassed.QuoteToChange.QuoteCompany.BusinessName;
            CbxPOBoxSelection.Text = add.AddressDescription;
            lblBusinessPOBoxNumber.Text = "P.O.Box " + add.AddressStreetNumber;
            lblBusinessPOBoxSuburb.Text = add.AddressSuburb;
            lblBusinessPOBoxCity.Text = add.AddressCity;
            lblBusinessPOBoxAreaCode.Text = add.AddressAreaCode.ToString();

            lblBusinessRegistrationNumber.Text = mPassed.QuoteToChange.QuoteCompany.BusinessLegalDetails.RegistrationNumber;
            lblBusinessVATNumber.Text = mPassed.QuoteToChange.QuoteCompany.BusinessLegalDetails.VatNumber;
            cbxBusinessTelephoneNumberSelection.Text = mPassed.QuoteToChange.Telefone;
            cbxBusinessCellphoneNumberSelection.Text = mPassed.QuoteToChange.Cellphone;
            cbxBusinessEmailAddressSelection.Text = mPassed.QuoteToChange.Email;

            //Loading Customer Section:
            add = mPassed.QuoteToChange.QuoteCustomerPoBox;
            cbxCustomerSelection.Text = mPassed.QuoteToChange.QuoteCustomer.CustomerCompanyName;
            CbxCustomerPOBoxSelection.Text = add.AddressDescription;
            lblCustomerPOBoxStreetName.Text = "Private Bag X" + add.AddressStreetNumber;
            lblCustomerPOBoxSuburb.Text = add.AddressSuburb;
            lblCustomerPOBoxCity.Text = add.AddressCity;
            lblCustomerPOBoxAreaCode.Text = add.AddressAreaCode.ToString();

            cbxCustomerDeliveryAddress.Text = mPassed.QuoteToChange.QuoteCustomer.CustomerName;
            rtxCustomerDeliveryDescripton.Text = mPassed.QuoteToChange.QuoteDeliveryAddress;
            txtCustomerVATNumber.Text = mPassed.QuoteToChange.QuoteCustomer.CustomerLegalDetails.VatNumber;

            //Loading other Quote Details:
            txtJobNumber.Text = mPassed.QuoteToChange.QuoteJobNumber;
            txtReferenceNumber.Text = mPassed.QuoteToChange.QuoteReference;
            txtPRNumber.Text = mPassed.QuoteToChange.QuotePrNumber;
            txtLineNumber.Text = mPassed.QuoteToChange.QuoteLineNumber;
            dtpPaymentTerm.Value = mPassed.QuoteToChange.QuotePaymentTerm;

            txtQuoteNumber.Text = mPassed.QuoteToChange.QuoteNumber;

            dtpQuoteCreationDate.Value = mPassed.QuoteToChange.QuoteCreationDate;
            dtpQuoteExpiryDate.Value = mPassed.QuoteToChange.QuoteExpireyDate;

            lblNewPumpUnitPrice.Text = "New Pump Price: R " + mPassed.QuoteToChange.QuoteCost.PumpPrice.ToString();
            lblRepairPercentage.Text = mPassed.QuoteToChange.QuoteRepairPercentage + "%";
            lblRebateValue.Text = "R" + mPassed.QuoteToChange.QuoteCost.Rebate.ToString();
            lblSubTotalValue.Text = "R" + mPassed.QuoteToChange.QuoteCost.SubTotal.ToString();
            lblVATValue.Text = "R" + mPassed.QuoteToChange.QuoteCost.Vat.ToString();
            lblTotalDueValue.Text = "R" + mPassed.QuoteToChange.QuoteCost.TotalDue.ToString();

            mtxtRebate.Text = mPassed.QuoteToChange.QuoteCost.Rebate.ToString();
        }

        private void ConvertToReadOnly()
        {
            QuoteSwiftMainCode.ReadOnlyComponents(Controls);

            dgvMandatoryPartReplacement.ReadOnly = true;
            DgvNonMandatoryPartReplacement.ReadOnly = true;

            dgvMandatoryPartReplacement.Enabled = true;
            DgvNonMandatoryPartReplacement.Enabled = true;

            pnlPumpDetails.Enabled = true;
            cbxPumpSelection.Enabled = false;

            btnComplete.Text = "Export";
            btnComplete.Enabled = true;
            btnCancel.Enabled = true;

            Text = Text.Replace("<< Business Name >>", mPassed.QuoteToChange.QuoteCompany.BusinessName);
            Text = Text.Replace("Creating New", "Viewing");
        }

        private void ConvertToReadWrite()
        {
            QuoteSwiftMainCode.ReadWriteComponents(Controls);

            Text = Text.Replace(mPassed.QuoteToChange.QuoteCompany.BusinessName, mPassed.QuoteToChange.QuoteCompany.BusinessName);
            Text = Text.Replace("Viewing", "Creating New");

        }

        private void CreateNewQuoteUsingThisQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPassed.QuoteToChange == null) mPassed.QuoteToChange = NewQuote;
            mPassed.ChangeSpecificObject = true;
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
            QuoteSwiftMainCode.CloseApplication(true);
        }
    }

}
