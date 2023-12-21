using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewQuotes : Form
    {

        public FrmViewQuotes()
        {
            InitializeComponent();
        }

        private void BtnCreateNewQuote_Click(object sender, EventArgs e)
        {
            if (Global.Context.BusinessMap != null && Global.Context.ProductMap != null && Global.Context.BusinessMap.Values.ToArray()[0].CustomerList != null)
            {
                Hide();
                QuoteSwiftMainCode.CreateNewQuote();
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
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void ManagePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            QuoteSwiftMainCode.ViewAllPumps();
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
            QuoteSwiftMainCode.CreateNewPump();
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
            QuoteSwiftMainCode.AddCustomer();
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
            QuoteSwiftMainCode.ViewCustomers();
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
            QuoteSwiftMainCode.AddBusiness();
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
            QuoteSwiftMainCode.ViewBusinesses();
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
            if (Global.Context != null && Global.Context.QuoteMap != null && dgvPreviousQuotes.SelectedItem as Quote != null)
            {
                Hide();
                Global.Context.QuoteToChange = dgvPreviousQuotes.SelectedItem as Quote;
                Global.Context. ChangeSpecificObject = false;
                QuoteSwiftMainCode.CreateNewQuote();
                Global.Context.QuoteToChange = null;
                Global.Context.ChangeSpecificObject = false;
                Show();
            }
        }

        private void BtnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (Global.Context != null && Global.Context.QuoteMap != null && dgvPreviousQuotes.SelectedItem as Quote != null)
            {
                this.Hide();
                Global.Context.QuoteToChange = dgvPreviousQuotes.SelectedItem as Quote;
                Global.Context.ChangeSpecificObject = true;
                QuoteSwiftMainCode.CreateNewQuote();
                Global.Context.QuoteToChange = null;
                Global.Context.ChangeSpecificObject = false;
                this.Show();
            }
        }

        private void ViewAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            QuoteSwiftMainCode.ViewAllParts();
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
            QuoteSwiftMainCode.AddNewPart();
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

            if (Global.Context != null)
            {
                try
                {

                    byte[] RetreivedMandatoryPartList = MainProgramCode.RetreiveData("MandatoryParts.pbf");

                    if (RetreivedMandatoryPartList != null && RetreivedMandatoryPartList.Length > 0) Global.Context.MandatoryPartMap = new Dictionary<string, Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList).ToDictionary(part => part.OriginalItemPartNumber)); //FIX THESE

                    RetreivedMandatoryPartList = MainProgramCode.RetreiveData("NonMandatoryParts.pbf");

                    if (RetreivedMandatoryPartList != null && RetreivedMandatoryPartList.Length > 0) Global.Context.NonMandatoryPartMap = new Dictionary<string, Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList).ToDictionary(part => part.OriginalItemPartNumber));

                    byte[] RetreivePumpList = MainProgramCode.RetreiveData("PumpList.pbf");

                    if (RetreivePumpList != null && RetreivePumpList.Length > 0) Global.Context.ProductMap = new Dictionary<string,Product>(MainProgramCode.DeserializePumpList(RetreivePumpList).ToDictionary(product => product.ProductName));

                    byte[] RetreiveBusinessList = MainProgramCode.RetreiveData("BusinessList.pbf");

                    if (RetreiveBusinessList != null && RetreiveBusinessList.Length > 0) Global.Context.BusinessMap = new Dictionary<string,Business>(MainProgramCode.DeserializeBusinessList(RetreiveBusinessList).ToDictionary(business => business.BusinessLegalDetails.RegistrationNumber));

                    byte[] RetreiveQuoteList = MainProgramCode.RetreiveData("QuoteList.pbf");

                    if (RetreiveQuoteList != null && RetreiveQuoteList.Length > 0) Global.Context.QuoteMap = new Dictionary<string, Quote>(MainProgramCode.DeserializeQuoteList(RetreiveQuoteList).ToDictionary(quote => quote.QuoteNumber));
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
            QuoteSwiftMainCode.CloseApplication(true);
        }

        void LoadDataGrid()
        {


            BindingSource PreviousQuotesDatagridBindingSource = null;
            if (Global.Context != null && Global.Context.QuoteMap != null && Global.Context.QuoteMap.Count > 0)
                PreviousQuotesDatagridBindingSource = new BindingSource { DataSource = Global.Context.QuoteMap };

            if (PreviousQuotesDatagridBindingSource != null)
            {
                dgvPreviousQuotes.DataSource = PreviousQuotesDatagridBindingSource;


                dgvPreviousQuotes.Columns["QuoteNumber"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["QuoteNumber"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteNumber"].AllowEditing = false;

                dgvPreviousQuotes.Columns["QuoteCreationDate"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["QuoteCreationDate"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteCreationDate"].AllowEditing = false;

                dgvPreviousQuotes.Columns["QuoteExpireyDate"].HeaderText = "Quote Expiry Date";
                dgvPreviousQuotes.Columns["QuoteExpireyDate"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteExpireyDate"].AllowEditing = false;

                dgvPreviousQuotes.Columns["QuoteReference"].HeaderText = "Quote Reference";
                dgvPreviousQuotes.Columns["QuoteReference"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteReference"].Visible = false;

                dgvPreviousQuotes.Columns["QuoteJobNumber"].HeaderText = "Quote Job-Number";
                dgvPreviousQuotes.Columns["QuoteJobNumber"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteJobNumber"].AllowEditing = false;


                dgvPreviousQuotes.Columns["QuotePRNumber"].HeaderText = "Quote PR-Number";
                dgvPreviousQuotes.Columns["QuotePRNumber"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuotePRNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePRNumber"].AllowEditing = false;

                dgvPreviousQuotes.Columns["QuotePaymentTerm"].HeaderText = "Quote Payment Term";
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].AllowEditing = false;


                dgvPreviousQuotes.Columns["QuoteLineNumber"].HeaderText = "Quote Line Number";
                dgvPreviousQuotes.Columns["QuoteLineNumber"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteLineNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteLineNumber"].AllowEditing = false;


                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].HeaderText = "New Pump Unit Price";
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].AllowEditing = false;


                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].HeaderText = "Repair Percentage";
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].AllowEditing = false;

                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].HeaderText = "Delivery Address";
                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].Visible = false;

                dgvPreviousQuotes.Columns["Telefone"].HeaderText = "Telephone";
                dgvPreviousQuotes.Columns["Telefone"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["Telefone"].Visible = false;
                dgvPreviousQuotes.Columns["Telefone"].AllowEditing = false;

                dgvPreviousQuotes.Columns["Cellphone"].HeaderText = "Cellphone";
                dgvPreviousQuotes.Columns["Cellphone"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["Cellphone"].Visible = false;
                dgvPreviousQuotes.Columns["Cellphone"].AllowEditing = false;

                dgvPreviousQuotes.Columns["Email"].HeaderText = "Email";
                dgvPreviousQuotes.Columns["Email"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["Email"].AllowEditing = false;
                dgvPreviousQuotes.Columns["Email"].Visible = false;

                dgvPreviousQuotes.Columns["NetDays"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["NetDays"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["NetDays"].Visible = false;
                dgvPreviousQuotes.Columns["NetDays"].AllowEditing = false;

                dgvPreviousQuotes.Columns["PumpName"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["PumpName"].HeaderStyle.Font.Size = 11;
                dgvPreviousQuotes.Columns["PumpName"].Visible = false;
                dgvPreviousQuotes.Columns["PumpName"].AllowEditing = false;

            }

        }

        private void FrmViewQuotes_Activated(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
    }
}
