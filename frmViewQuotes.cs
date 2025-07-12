using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuoteSwift
{
    public partial class FrmViewQuotes : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewQuotes(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
            if (this.passed == null) passed = new Pass(new SortedDictionary<string, Quote>(), new BindingList<Business>(), new BindingList<Pump>(), new BindingList<Part>(), new BindingList<Part>());

        }

        private void BtnCreateNewQuote_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.PassBusinessList != null && passed.PassPumpList != null && passed.PassBusinessList[0].BusinessCustomerList != null)
            {
                Hide();
                passed = QuoteSwiftMainCode.CreateNewQuote(ref passed);
                try
                {
                    Show();
                }
                catch (Exception)
                {
                    // Do Nothing - Since this only happens when Application.Exit() is called.
                }
            }
            else
            {
                MainProgramCode.ShowError("Please ensure that the following information is provided before creating a quote:\n" +
                                          ">  Business Information.\n" +
                                          ">  Business' Customer's Information.\n" +
                                          ">  Pump Information.", "ERROR - Prerequisites Not Met");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void ManagePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.ViewAllPumps(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void CreateNewPumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.CreateNewPump(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllPumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managePumpsToolStripMenuItem.PerformClick();
        }

        private void AddNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddCustomer(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.ViewCustomers(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAllCustomersToolStripMenuItem.PerformClick();
        }

        private void AddNewBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddBusiness(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.ViewBusinesses(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllBusinessesToolStripMenuItem.PerformClick();
        }

        private void BtnViewSelectedQuote_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.PassQuoteMap != null && dgvPreviousQuotes.SelectedRows.Count > 0)
            {
                Hide();
                passed.QuoteTOChange = dgvPreviousQuotes.SelectedRows[0].DataBoundItem as Quote;
                passed.ChangeSpecificObject = false;
                QuoteSwiftMainCode.CreateNewQuote(ref passed);
                passed.QuoteTOChange = null;
                passed.ChangeSpecificObject = false;
                Show();
            }
        }

        private void BtnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.PassQuoteMap != null && dgvPreviousQuotes.SelectedRows.Count > 0)
            {
                this.Hide();
                passed.QuoteTOChange = dgvPreviousQuotes.SelectedRows[0].DataBoundItem as Quote;
                passed.ChangeSpecificObject = true;
                QuoteSwiftMainCode.CreateNewQuote(ref passed);
                passed.QuoteTOChange = null;
                passed.ChangeSpecificObject = false;
                this.Show();
            }
        }

        private void ViewAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.ViewAllParts(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManagePumpPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAllPartsToolStripMenuItem.PerformClick();
        }

        private void AddNewPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddNewPart(ref passed);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void FrmViewQuotes_Load(object sender, EventArgs e)
        {

            if (passed != null)
            {
                try
                {

                    byte[] RetreivedMandatoryPartList = MainProgramCode.RetreiveData("MandatoryParts.json");

                    if (RetreivedMandatoryPartList != null && RetreivedMandatoryPartList.Length > 0) passed.PassMandatoryPartList = new BindingList<Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList));

                    RetreivedMandatoryPartList = MainProgramCode.RetreiveData("NonMandatoryParts.json");

                    if (RetreivedMandatoryPartList != null && RetreivedMandatoryPartList.Length > 0) passed.PassNonMandatoryPartList = new BindingList<Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList));

                    byte[] RetreivePumpList = MainProgramCode.RetreiveData("PumpList.json");

                    if (RetreivePumpList != null && RetreivePumpList.Length > 0) passed.PassPumpList = new BindingList<Pump>(MainProgramCode.DeserializePumpList(RetreivePumpList));

                    byte[] RetreiveBusinessList = MainProgramCode.RetreiveData("BusinessList.json");

                    if (RetreiveBusinessList != null && RetreiveBusinessList.Length > 0) passed.PassBusinessList = new BindingList<Business>(MainProgramCode.DeserializeBusinessList(RetreiveBusinessList));

                    byte[] RetreiveQuoteList = MainProgramCode.RetreiveData("QuoteList.json");

                    if (RetreiveQuoteList != null && RetreiveQuoteList.Length > 0)
                        passed.PassQuoteMap = MainProgramCode.DeserializeQuoteList(RetreiveQuoteList);
                }
                catch (Exception Ex)
                {
                    while(Ex != null)
                    {
                        MainProgramCode.ShowError(Ex.Message, "ERROR On Load");
                        Ex = Ex.InnerException;
                    }
                }

            }

            LoadDataGrid();
        }

        readonly int count = 0;
        private void FrmViewQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        void LoadDataGrid()
        {


            BindingSource PreviousQuotesDatagridBindingSource = null;
            if (passed != null && passed.PassQuoteMap != null)
                PreviousQuotesDatagridBindingSource = new BindingSource { DataSource = new BindingList<Quote>(passed.PassQuoteMap.Values.ToList()) };

            if (PreviousQuotesDatagridBindingSource != null)
            {
                dgvPreviousQuotes.DataSource = PreviousQuotesDatagridBindingSource;


                dgvPreviousQuotes.Columns["QuoteNumber"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["QuoteNumber"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteCreationDate"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["QuoteCreationDate"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteExpireyDate"].HeaderText = "Quote Expiry Date";
                dgvPreviousQuotes.Columns["QuoteExpireyDate"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteReference"].HeaderText = "Quote Reference";
                dgvPreviousQuotes.Columns["QuoteReference"].Visible = false;

                dgvPreviousQuotes.Columns["QuoteJobNumber"].HeaderText = "Quote Job-Number";
                dgvPreviousQuotes.Columns["QuoteJobNumber"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuotePRNumber"].HeaderText = "Quote PR-Number";
                dgvPreviousQuotes.Columns["QuotePRNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePRNumber"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuotePaymentTerm"].HeaderText = "Quote Payment Term";
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteLineNumber"].HeaderText = "Quote Line Number";
                dgvPreviousQuotes.Columns["QuoteLineNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteLineNumber"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].HeaderText = "New Pump Unit Price";
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].HeaderText = "Repair Percentage";
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].HeaderText = "Delivery Address";
                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].Visible = false;

                dgvPreviousQuotes.Columns["Telefone"].HeaderText = "Telephone";
                dgvPreviousQuotes.Columns["Telefone"].Visible = false;
                dgvPreviousQuotes.Columns["Telefone"].ReadOnly = true;

                dgvPreviousQuotes.Columns["Cellphone"].HeaderText = "Cellphone";
                dgvPreviousQuotes.Columns["Cellphone"].Visible = false;
                dgvPreviousQuotes.Columns["Cellphone"].ReadOnly = true;

                dgvPreviousQuotes.Columns["Email"].HeaderText = "Email";
                dgvPreviousQuotes.Columns["Email"].ReadOnly = true;
                dgvPreviousQuotes.Columns["Email"].Visible = false;

                dgvPreviousQuotes.Columns["NetDays"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["NetDays"].Visible = false;
                dgvPreviousQuotes.Columns["NetDays"].ReadOnly = true;

                dgvPreviousQuotes.Columns["PumpName"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["PumpName"].Visible = false;
                dgvPreviousQuotes.Columns["PumpName"].ReadOnly = true;

            }

        }

        private void FrmViewQuotes_Activated(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
    }
}
