using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Syncfusion.XlsIO;
using Microsoft.Office.Interop.Excel;
using System.Security.Principal;
using System.Security.Permissions;

namespace QuoteSwift
{
    public partial class FrmCreateQuote : Form
    { 
        Pass passed;

        Quote NewQuote;

        Pricing P = new Pricing();
        public FrmCreateQuote(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public ref Pass Passed { get => ref passed; }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            NewQuote = CreateQuote();
            if (NewQuote != null)
            {
                if (this.passed.PassQuoteList != null)
                {
                    this.passed.PassQuoteList.Add(NewQuote);
                }
                else this.passed.PassQuoteList = new BindingList<Quote> { NewQuote };

                if (MainProgramCode.RequestConfirmation("The quote was successfully created. Would you like to export the quote an Excell/PDF document?", "REQUEST - Export Quote to Excell/PDF"))
                {
                    ExportQuoteToTemplate();

                }
            }
            else MainProgramCode.ShowError("The Quote could not be created successfully.", "ERROR - Quote Creation Unsuccessfull");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancelation")) this.Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void CbxPumpSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPartlists();
        }

        private void FrmCreateQuote_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadPartlists();
            LoadBusinessPOBoxAddress();
            LoadBusinessLegalDatails();
            LoadCustomerDeliveryAddress();
            LoadCustomerPOBoxAddress();

            dtpQuoteCreationDate.Value = DateTime.Today;
            dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
            dtpPaymentTerm.Value = DateTime.Today;

            this.Text = this.Text.Replace("<< Business Name >>", GetBusinessSelection().BusinessName);

            this.dgvMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            this.DgvNonMandatoryPartReplacement.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.DgvNonMandatoryPartReplacement.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void CbxCustomerSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkCustomerDeliveryAddress(GetCustomerSelection(), ref cbxCustomerDeliveryAddress);
            LoadCustomerDetails();
            LinkCustomerPOBox(GetCustomerSelection(), ref CbxCustomerPOBoxSelection);
            LoadCustomerPOBoxAddress();
        }

        private void CbxBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkBusinessTelephone(GetBusinessSelection(), ref cbxBusinessTelephoneNumberSelection);
            LinkBusinessCellphone(GetBusinessSelection(), ref cbxBusinessCellphoneNumberSelection);
            LinkBusinessEmail(GetBusinessSelection(), ref cbxBusinessEmailAddressSelection);
            LinkCustomers(GetBusinessSelection(), ref cbxCustomerSelection);

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

            if (passed.PassBusinessList != null)
            {
                business = passed.PassBusinessList.SingleOrDefault(p => p.BusinessName == SearchName);
                return business;
            }

            return null;
        }
        
        private Customer GetCustomerSelection()
        {
            string SearchName = cbxCustomerSelection.Text;

            if (passed.PassBusinessList != null) return GetBusinessSelection().BusinessCustomerList.SingleOrDefault(p => p.CustomerCompanyName == SearchName);

            return null;
        }

        private Pump GetPumpSelection()
        {
            string SearchName = cbxPumpSelection.Text;

            if (passed.PassPumpList != null) return passed.PassPumpList.SingleOrDefault(p => p.PumpName == SearchName);

            return null;
        }

        private Address GetBusinesssPOBoxAddressSelection(Business b)
        {
            string SearchName = CbxPOBoxSelection.Text;

            if (b.BusinessPOBoxAddressList != null) return b.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);

            return null;
        }

        private Address GetCustomerPOBoxAddressSelection(Customer c)
        {
            string SearchName = CbxCustomerPOBoxSelection.Text;

            if (c.CustomerPOBoxAddress!= null) return c.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);

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
            if (passed != null && passed.PassBusinessList != null && b != null)
            {
                //Created a Binding Source for the Business list to link the source
                //directly to the combobox's datasource:

                var ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessTelephoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessCellphone(Business b, ref ComboBox cb)
        {
            if (passed != null && passed.PassBusinessList != null && b != null)
            {
                //Created a Binding Source for the Business list to link the source
                //directly to the combobox's datasource:

                var ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessCellphoneNumberList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinessEmail(Business b,ref ComboBox cb)
        {
            if (passed != null && passed.PassBusinessList != null && b != null)
            {
                //Created a Binding Source for the Business list to link the source
                //directly to the combobox's datasource:

                var ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessEmailAddressList};

                cb.DataSource = ComboBoxBusinessSource.DataSource;
            }
        }

        private void LinkBusinesssPOBox(Business b, ref ComboBox cb)
        {
            if (b != null && b.BusinessPOBoxAddressList != null)
            { 
                var ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessPOBoxAddressList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "BusinessName";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkCustomers(Business b , ref ComboBox cb)
        {
            if (b != null && b.BusinessCustomerList != null)
            {
                //Created a Binding Source for the Business list to link the source
                //directly to the combobox's datasource:

                var ComboBoxBusinessSource = new BindingSource { DataSource = b.BusinessCustomerList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                //Linking the specific item from the Business class to display in the combobox:

                cb.DisplayMember = "CustomerCompanyName";
                cb.ValueMember = "CustomerCompanyName";
            }
        }

        private void LinkCustomerDeliveryAddress(Customer c, ref ComboBox cb)
        {
            if (c != null && c.CustomerDeliveryAddressList != null)
            { 

                var ComboBoxSource = new BindingSource { DataSource = c.CustomerDeliveryAddressList };

                cb.DataSource = ComboBoxSource.DataSource;

                cb.DisplayMember = "CustomerName";
                cb.ValueMember = "AddressDescription";
            }
        }

        private void LinkPumpList(ref ComboBox cb)
        {
            if(passed != null && passed.PassPumpList != null)
            {
                var ComboBoxSource = new BindingSource { DataSource = passed.PassPumpList };

                cb.DataSource = ComboBoxSource.DataSource;

                cb.DisplayMember = "PumpName";
                cb.ValueMember = "PumpName";
            }
        }

        private void LinkCustomerPOBox(Customer c, ref ComboBox cb)
        {
            if (c != null && c.CustomerPOBoxAddress != null)
            {
                var ComboBoxBusinessSource = new BindingSource { DataSource = c.CustomerPOBoxAddress };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "CustomerName";
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
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(ref this.passed);
            frmViewCustomers.LinkBusinessToSource(ref cbxBusinessSelection);

            LinkBusinessTelephone(GetBusinessSelection(), ref cbxBusinessTelephoneNumberSelection);
            LinkBusinessCellphone(GetBusinessSelection(), ref cbxBusinessCellphoneNumberSelection);
            LinkBusinessEmail(GetBusinessSelection(),ref cbxBusinessEmailAddressSelection);
            LinkCustomers(GetBusinessSelection(), ref cbxCustomerSelection);
            LinkCustomerDeliveryAddress(GetCustomerSelection(), ref cbxCustomerDeliveryAddress);
            LinkPumpList(ref cbxPumpSelection);
            LinkBusinesssPOBox(GetBusinessSelection(), ref CbxPOBoxSelection);
            LinkCustomerPOBox(GetCustomerSelection(), ref CbxCustomerPOBoxSelection);
        }

        private void LoadPartlists()
        {
            dgvMandatoryPartReplacement.Rows.Clear();
            DgvNonMandatoryPartReplacement.Rows.Clear();

            if(passed != null && passed.PassPumpList != null && cbxPumpSelection.SelectedIndex > -1)
            {
                Pump display = GetPumpSelection();

                if (display != null) LoadParts(display);
            }
            Calculate();
        }

        void LoadParts(Pump p)
        {
            if (p.PartList != null)
            {
                dgvMandatoryPartReplacement.Rows.Clear();
                DgvNonMandatoryPartReplacement.Rows.Clear();

                for (int i = 0; i < p.PartList.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    if (p.PartList[i].PumpPart.MandatoryPart)
                        dgvMandatoryPartReplacement.Rows.Add(p.PartList[i].PumpPart.NewPartNumber,
                                                             p.PartList[i].PumpPart.PartDescription,
                                                             p.PartList[i].PumpPartQuantity,
                                                             p.PartList[i].PumpPartQuantity, 
                                                             0,
                                                             p.PartList[i].PumpPartQuantity,
                                                             (p.PartList[i].PumpPartQuantity * p.PartList[i].PumpPart.PartPrice),
                                                             p.PartList[i].PumpPart.PartPrice,
                                                             0,1);
                    else DgvNonMandatoryPartReplacement.Rows.Add(p.PartList[i].PumpPart.NewPartNumber,
                                                                 p.PartList[i].PumpPart.PartDescription,
                                                                 p.PartList[i].PumpPartQuantity,
                                                                 p.PartList[i].PumpPartQuantity, 
                                                                 0,
                                                                 p.PartList[i].PumpPartQuantity,
                                                                 0,
                                                                 p.PartList[i].PumpPart.PartPrice,
                                                                 0,1);
                    
                }
                DgvNonMandatoryPartReplacement.Rows.Add("TS6MACH", "MACHINING", 1, 0, 0, 1, 0, 1000, 0 ,1);
                DgvNonMandatoryPartReplacement.Rows.Add("TS6LAB", "LABOUR", 1, 0, 0, 1, 0, 1000, 0 ,1);
                DgvNonMandatoryPartReplacement.Rows.Add("CON TS6", "CONSUMABLES incl COLLECTION & DELIVERY", 1, 0, 0, 1, 0, 1000, 0 ,1);

                lblNewPumpUnitPrice.Text = "New Pump Price: R " + p.NewPumpPrice.ToString();
            }
        }

        private void LoadBusinessPOBoxAddress()
        {
            Address Selection = GetBusinesssPOBoxAddressSelection(GetBusinessSelection());
            if (Selection != null)
            {
                lblBusinessPOBoxStreetName.Text = "Street Name: " + Selection.AddressStreetName;
                lblBusinessPOBoxNumber.Text = "P.O.Box Number " + Selection.AddressStreetNumber.ToString();
                lblBusinessPOBoxSuburb.Text = "Suburb: " + Selection.AddressSuburb;
                lblBusinessPOBoxCity.Text = "City: " + Selection.AddressCity;
                lblBusinessPOBoxAreaCode.Text = "Area Code: " + Selection.AddressAreaCode.ToString();
            }
        }
        private void LoadCustomerPOBoxAddress()
        {
            Address Selection = GetCustomerPOBoxAddressSelection(GetCustomerSelection());
            if (Selection != null)
            {
                lblCustomerPOBoxNumber.Text = "Street Name: " + Selection.AddressStreetName;
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
                rtxCustomerDeliveryDescripton.Text = "ATT: " + Selection.CustomerName +
                                                     "\nStreet Number: " + Selection.AddressStreetNumber.ToString() +
                                                     "\nStreet Name: " + Selection.AddressStreetName.ToString() +
                                                     "\nSuburb: " + Selection.AddressSuburb +
                                                     "\nCity: " + Selection.AddressCity +
                                                     "\nArea Code: " + Selection.AddressAreaCode.ToString();
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
            LoadCustomerPOBoxAddress();
        }

        void Calculate(bool b=false)
        {
            // Calculate datagridviews' Price and Total columns

            if (b)
            {
                dgvMandatoryPartReplacement.Rows.RemoveAt(dgvMandatoryPartReplacement.Rows.Count - 1);
                DgvNonMandatoryPartReplacement.Rows.RemoveAt(DgvNonMandatoryPartReplacement.Rows.Count - 1);
            }

            double Sum = 0;
            int size = dgvMandatoryPartReplacement.Rows.Count;

            for (int i = 0; i < size; i++)
            {
                if (b)
                {
                    dgvMandatoryPartReplacement.Rows[i].Cells["clmMMissing_Scrap"].Value = MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmQuantity"].Value.ToString()) -
                                                                                               MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmMRepaired"].Value.ToString());

                    dgvMandatoryPartReplacement.Rows[i].Cells["clmNew"].Value = dgvMandatoryPartReplacement.Rows[i].Cells["clmMMissing_Scrap"].Value;
                }
                    dgvMandatoryPartReplacement.Rows[i].Cells["clmPrice"].Value = (MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmUnitPrice"].Value.ToString()) *
                                                                                   MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmNew"].Value.ToString())) +
                                                                                  (MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells["clmMRepaired"].Value.ToString()) *
                                                                                  (MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmUnitPrice"].Value.ToString()) /
                                                                                   MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["ClmRepairDevider"].Value.ToString())));
                
                Sum += MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells["clmPrice"].Value.ToString());

                if (i == dgvMandatoryPartReplacement.Rows.Count - 1) dgvMandatoryPartReplacement.Rows.Add("-", "-", "-", "-", "-", "-", "-", "-", Sum, "-");
            }

            size = DgvNonMandatoryPartReplacement.Rows.Count;
            for (int i = 0; i < size; i++)
            {
                if (b)
                {
                    DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMMissing_Scrap"].Value = MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[2].Value.ToString()) -
                                                                                               MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepaired"].Value.ToString());

                    DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMNewPartQuantity"].Value = DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMMissing_Scrap"].Value;
                }
                DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMPrice"].Value = (MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMUnitPrice"].Value.ToString()) *
                                                                                  MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMNewPartQuantity"].Value.ToString())) +
                                                                                 (MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepaired"].Value.ToString()) *
                                                                                 (MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMUnitPrice"].Value.ToString()) /
                                                                                  MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMRepairDevider"].Value.ToString())));

                Sum += MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells["ClmNMPrice"].Value.ToString());

                if (i == DgvNonMandatoryPartReplacement.Rows.Count - 1) 
                    DgvNonMandatoryPartReplacement.Rows.Add("-", "-", "-", "-", "-", "-", "-", "-", Sum - MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[DgvNonMandatoryPartReplacement.Rows.Count-1].Cells[8].Value.ToString()), "-");
            }

            // Display Sum of all totals:

            P.Rebate = MainProgramCode.ParseFloat(mtxtRebate.Text);
            P.SubTotal = (Sum -= MainProgramCode.ParseFloat(mtxtRebate.Text));
            P.VAT = (Sum * 0.15);
            P.TotalDue = (Sum *= 1.15);

            P.Machining = GetPriceForNMItem("MACHINING");
            P.Labour = GetPriceForNMItem("LABOUR");
            P.Consumables = GetPriceForNMItem("CONSUMABLES incl COLLECTION & DELIVERY");

            lblRebateValue.Text = "R" + P.Rebate.ToString();
            lblSubTotalValue.Text = "R" + P.SubTotal.ToString();
            lblVATValue.Text = "R" + P.VAT.ToString();
            lblTotalDueValue.Text = "R" + P.TotalDue.ToString();

            lblRebateValue.Left = 107;
            lblSubTotalValue.Left = 107;
            lblVATValue.Left = 107;
            lblTotalDueValue.Left = 107;

            

            lblRepairPercentage.Text = "Repair Percentage: " + Convert.ToString((Sum / GetPumpSelection().NewPumpPrice) * 100) + "%";
        }

        private void BtnCalculateRebate_Click(object sender, EventArgs e)
        {
            Calculate(true);
        }

        private void DtpQuoteCreationDate_ValueChanged(object sender, EventArgs e)
        {
            dtpQuoteExpiryDate.Value = dtpQuoteCreationDate.Value.AddMonths(2);
        }

        private void DtpQuoteExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            dtpQuoteCreationDate.Value = dtpQuoteExpiryDate.Value.AddMonths(-2);
        }

        private bool ValidInput()
        {
            if(txtCustomerVATNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please provide a valid Customer VAT Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if(txtJobNumber.Text.Length < 3)
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

            if(txtLineNumber.Text.Length == 0)
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
            if(cbxUseAutomaticNumberingScheme.Checked)
            {
                txtQuoteNumber.ReadOnly = true;
                txtQuoteNumber.Text = (MainProgramCode.ParseInt(MainProgramCode.GetLastQuote(ref this.passed).QuoteNumber.Substring(0, 3)) + 1).ToString();
            }
            else
            {
                txtQuoteNumber.ReadOnly = false;
            }
        }

        Pump_Part GetPart(string s, BindingList<Pump_Part> bl)
        {

            if (bl != null && s != "")
            {
                for(int i = 0; i < bl.Count; i++)
                {
                    if (bl[i].PumpPart.NewPartNumber == s)
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

            BindingList<Quote_Part> MandatoryPartList = new BindingList<Quote_Part>();
            for(int i = 0; i < dgvMandatoryPartReplacement.Rows.Count; i++)
            {
                if(dgvMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString() != "-")
                {
                    Quote_Part quote_Part = new Quote_Part(GetPart(dgvMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString(),
                                                                   GetPumpSelection().PartList),
                                                           MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[3].Value.ToString()),
                                                           MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[4].Value.ToString()),
                                                           MainProgramCode.ParseInt(dgvMandatoryPartReplacement.Rows[i].Cells[5].Value.ToString()),
                                                           MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[6].Value.ToString()),
                                                           MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString()),
                                                           MainProgramCode.ParseFloat(dgvMandatoryPartReplacement.Rows[i].Cells[9].Value.ToString()));

                    MandatoryPartList.Add(quote_Part);
                }
            }


            BindingList<Quote_Part> NonMandatoryPartList = new BindingList<Quote_Part>();
            for (int i = 0; i < DgvNonMandatoryPartReplacement.Rows.Count-4; i++)
            {
                if (DgvNonMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString() != "-")
                {
                    Quote_Part quote_Part = new Quote_Part(GetPart(DgvNonMandatoryPartReplacement.Rows[i].Cells[0].Value.ToString(), GetPumpSelection().PartList),
                                                           MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[3].Value.ToString()),
                                                           MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[4].Value.ToString()),
                                                           MainProgramCode.ParseInt(DgvNonMandatoryPartReplacement.Rows[i].Cells[5].Value.ToString()),
                                                           MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[6].Value.ToString()),
                                                           MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString()),
                                                           MainProgramCode.ParseFloat(DgvNonMandatoryPartReplacement.Rows[i].Cells[9].Value.ToString()));

                    NonMandatoryPartList.Add(quote_Part);
                }
            }

            Quote CreateQuote = new Quote(txtQuoteNumber.Text,
                                         dtpQuoteCreationDate.Value,
                                         dtpQuoteExpiryDate.Value,
                                         txtReferenceNumber.Text,
                                         txtJobNumber.Text,
                                         txtPRNumber.Text,
                                         dtpPaymentTerm.Value,
                                         new Address(GetBusinesssPOBoxAddressSelection(GetBusinessSelection())),
                                         new Address(GetCustomerPOBoxAddressSelection(GetCustomerSelection())),
                                         MainProgramCode.ParseInt(txtLineNumber.Text),
                                         GetPumpSelection().NewPumpPrice,
                                         ((MainProgramCode.ParseFloat(lblTotalDue.Text) / GetPumpSelection().NewPumpPrice) * 100),
                                         rtxCustomerDeliveryDescripton.Text,
                                         new Customer(GetCustomerSelection()),
                                         new Business(GetBusinessSelection()),
                                         MandatoryPartList,
                                         NonMandatoryPartList,
                                         cbxBusinessTelephoneNumberSelection.Text,
                                         cbxBusinessCellphoneNumberSelection.Text,
                                         cbxBusinessEmailAddressSelection.Text,
                                         (int)(dtpPaymentTerm.Value.Subtract(dtpQuoteCreationDate.Value)).TotalDays,
                                         P,
                                         cbxPumpSelection.Text);

            CreateQuote.QuoteRepairPercentage = ((float)(P.TotalDue / GetPumpSelection().NewPumpPrice * 100));
            return CreateQuote;
        }
         
        public void ExportQuoteToTemplate()
        {
            
            Microsoft.Office.Interop.Excel.Application ExcellContainer = null;
            Microsoft.Office.Interop.Excel.Workbook MyWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet MyWorkSheet = null;
            string SavePath;
            try
            {
                
                try
                {
                    ExcellContainer = new Microsoft.Office.Interop.Excel.Application();
                }
                catch
                {
                    //do nothing
                }

                if (ExcellContainer == null)
                {
                    MainProgramCode.ShowError("Excel is not installed on this machine.", "ERROR - Excel Export Failed");
                    return;
                }

                FolderBrowserDialog browserDialog = new FolderBrowserDialog();

                
                if (browserDialog.ShowDialog() != DialogResult.Cancel)
                {
                    SavePath = browserDialog.SelectedPath;
                    SavePath += "\\" + NewQuote.QuoteNumber + ".xlsx";
                }
                else return;

                MyWorkBook = ExcellContainer.Workbooks.Open(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\QuoteTemplate.xlsx");
                MyWorkSheet = (Excel.Worksheet)MyWorkBook.Worksheets["Sheet1"];

                //Business Details:

                MyWorkSheet.Cells.Replace("<<Business Name>>", NewQuote.QuoteCompany.BusinessName);
                MyWorkSheet.Cells.Replace("<<POBox Number>>", "P.O.BOX " + NewQuote.QuoteBusinessPOBox.AddressStreetNumber);
                MyWorkSheet.Cells.Replace("<<POBox Suburb>>", NewQuote.QuoteBusinessPOBox.AddressSuburb);
                MyWorkSheet.Cells.Replace("<<POBox City>>", NewQuote.QuoteBusinessPOBox.AddressCity);
                MyWorkSheet.Cells.Replace("<<Registration Number>>", NewQuote.QuoteCompany.BusinessLegalDetails.RegistrationNumber);
                MyWorkSheet.Cells.Replace("<<VAT Number>>", NewQuote.QuoteCompany.BusinessLegalDetails.VatNumber);
                MyWorkSheet.Cells.Replace("<<Telephone>>", NewQuote.Telefone);
                MyWorkSheet.Cells.Replace("<<CellPhone>>", NewQuote.Cellphone);
                MyWorkSheet.Cells.Replace("<<Email>>", NewQuote.Email);

                //Quote Details:

                MyWorkSheet.Cells.Replace("<<Quote Number>>", NewQuote.QuoteNumber);
                MyWorkSheet.Cells.Replace("<<Creation Date>>", NewQuote.QuoteCreationDate.Date.ToString());
                MyWorkSheet.Cells.Replace("<<Expire Date>>", NewQuote.QuoteExpireyDate.Date.ToString());

                //Client POBox:

                MyWorkSheet.Cells.Replace("<<Customer POBox Desc>>", NewQuote.QuoteCustomer.CustomerCompanyName);
                MyWorkSheet.Cells.Replace("<<Customer POBox Number>>", "PRIVATE BAG X" + NewQuote.QuoteCustomerPOBox.AddressStreetNumber);
                MyWorkSheet.Cells.Replace("<<Customer POBox Suburb>>", NewQuote.QuoteCustomerPOBox.AddressSuburb);
                MyWorkSheet.Cells.Replace("<<Customer POBox AreaCode>>", NewQuote.QuoteCustomerPOBox.AddressAreaCode.ToString());
                MyWorkSheet.Cells.Replace("<<Vendor Number>>", NewQuote.QuoteCustomer.VendorNumber);
                MyWorkSheet.Cells.Replace("<<Delivery Details>>", NewQuote.QuoteDeliveryAddress);
                MyWorkSheet.Cells.Replace("<<CVAT>>", NewQuote.QuoteCustomer.CustomerLegalDetails.VatNumber);

                //Other:

                MyWorkSheet.Cells.Replace("<<Ref>>", NewQuote.QuoteReference);
                MyWorkSheet.Cells.Replace("<<JN>>", NewQuote.QuoteJobNumber);
                MyWorkSheet.Cells.Replace("<<PRN>>", NewQuote.QuotePRNumber);
                MyWorkSheet.Cells.Replace("<<LNo>>", NewQuote.QuoteLineNumber);
                MyWorkSheet.Cells.Replace("<<NETTDAYS>>", NewQuote.NetDays.ToString());
                MyWorkSheet.Cells.Replace("<<Pump Name>>", NewQuote.PumpName.ToString());

                //Pricing:

                MyWorkSheet.Cells.Replace("<<Machine>>", NewQuote.QuoteCost.Machining.ToString());
                MyWorkSheet.Cells.Replace("<<Labour>>", NewQuote.QuoteCost.Labour.ToString());
                MyWorkSheet.Cells.Replace("<<Consum>>", NewQuote.QuoteCost.Consumables.ToString());
                MyWorkSheet.Cells.Replace("<<Rebate>>", NewQuote.QuoteCost.Rebate.ToString());
                MyWorkSheet.Cells.Replace("<<Sub Total>>", NewQuote.QuoteCost.SubTotal.ToString());
                MyWorkSheet.Cells.Replace("<<VAT>>", NewQuote.QuoteCost.VAT.ToString());
                MyWorkSheet.Cells.Replace("<<Total>>", NewQuote.QuoteCost.TotalDue.ToString());
                MyWorkSheet.Cells.Replace("<<NPP>>", "R" + NewQuote.QuoteNewUnitPrice.ToString());
                MyWorkSheet.Cells.Replace("<<RP>>", NewQuote.QuoteRepairPercentage.ToString() + "%");

                /** Mandatory Parts */

                int CurrentRow = MyWorkSheet.Cells.Find("<<Mandatory Begin>>").Row+1;

                // Adding Rows:
                for (int i = 0; i < NewQuote.QuoteMandatoryPartList.Count-3; i++)
                {   
                    Excel.Range range = MyWorkSheet.get_Range("A" + CurrentRow.ToString(), "L" + CurrentRow.ToString()).EntireRow;
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    MyWorkSheet.get_Range("B" + CurrentRow.ToString() + ":D" + CurrentRow.ToString()).Merge();
                    MyWorkSheet.get_Range("J" + CurrentRow.ToString() + ":K" + CurrentRow.ToString()).Merge();
                    CurrentRow++;
                }


                // Populating Mandatory Rows:
                CurrentRow = MyWorkSheet.Cells.Find("<<Mandatory Begin>>").Row;
                for (int i = 0; i < NewQuote.QuoteMandatoryPartList.Count; i++)
                {
                    MyWorkSheet.Cells[CurrentRow, 1].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                    MyWorkSheet.Cells[CurrentRow, 2].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                    MyWorkSheet.Cells[CurrentRow, 5].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 6].Value2 = NewQuote.QuoteMandatoryPartList[i].MissingorScrap.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 7].Value2 = NewQuote.QuoteMandatoryPartList[i].Repaired.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 8].Value2 = NewQuote.QuoteMandatoryPartList[i].New.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 9].Value2 = NewQuote.QuoteMandatoryPartList[i].Price.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 10].Value2 = NewQuote.QuoteMandatoryPartList[i].UnitPrice.ToString() ?? "0";
                    CurrentRow++;
                }

                /** Non-Mandatory Parts */

                CurrentRow = MyWorkSheet.Cells.Find("<<Non Mandatory Begin>>").Row + 1;

                // Adding Rows:
                for (int i = 0; i < NewQuote.QuoteNewList.Count - 3; i++)
                {
                    Excel.Range range = MyWorkSheet.get_Range("A" + CurrentRow.ToString(), "L" + CurrentRow.ToString()).EntireRow;
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    MyWorkSheet.get_Range("B" + CurrentRow.ToString() + ":D" + CurrentRow.ToString()).Merge();
                    MyWorkSheet.get_Range("J" + CurrentRow.ToString() + ":K" + CurrentRow.ToString()).Merge();
                    CurrentRow++;
                }


                // Populating Non-Mandatory Rows:
                CurrentRow = MyWorkSheet.Cells.Find("<<Non Mandatory Begin>>").Row;
                for (int i = 0; i < NewQuote.QuoteNewList.Count; i++)
                {
                    MyWorkSheet.Cells[CurrentRow, 1].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                    MyWorkSheet.Cells[CurrentRow, 2].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                    MyWorkSheet.Cells[CurrentRow, 5].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 6].Value2 = NewQuote.QuoteNewList[i].MissingorScrap.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 7].Value2 = NewQuote.QuoteNewList[i].Repaired.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 8].Value2 = NewQuote.QuoteNewList[i].New.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 9].Value2 = NewQuote.QuoteNewList[i].Price.ToString() ?? "0";
                    MyWorkSheet.Cells[CurrentRow, 10].Value2 = NewQuote.QuoteNewList[i].UnitPrice.ToString() ?? "0";
                    CurrentRow++;
                }



                MyWorkBook.SaveAs(SavePath);
                MainProgramCode.ShowInformation("Excel file created and stored at:\n" + SavePath, "INFORMATION - Quote Stored Successfully");
            }
            finally
            {
                MyWorkBook.Close();
                ExcellContainer.Quit();
                Marshal.ReleaseComObject(MyWorkSheet);
                Marshal.ReleaseComObject(MyWorkBook);
                Marshal.ReleaseComObject(ExcellContainer);
            }
        }

        private float GetPriceForNMItem(string s)
        {
            if(s != "")
            {
                for(int i = 0; i < DgvNonMandatoryPartReplacement.Rows.Count; i++)
                {
                    if(DgvNonMandatoryPartReplacement.Rows[i].Cells[1].Value.ToString() == s)
                    {
                        return (float) double.Parse(DgvNonMandatoryPartReplacement.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                    }    
                }
            }
            return 0;
        }

        private void lblRepairPercentage_Click(object sender, EventArgs e)
        {

        }
    }
}
