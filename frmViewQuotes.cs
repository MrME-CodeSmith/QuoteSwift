using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuoteSwift
{
    public partial class FrmViewQuotes : Form
    {

        readonly QuotesViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        readonly BindingSource quotesBindingSource = new BindingSource();

        public FrmViewQuotes(QuotesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            quotesBindingSource.DataSource = viewModel.Quotes;
            dgvPreviousQuotes.DataSource = quotesBindingSource;
        }

        private void BtnCreateNewQuote_Click(object sender, EventArgs e)
        {
            if (viewModel.BusinessList != null && viewModel.BusinessList.Count > 0 && viewModel.PumpList != null && viewModel.BusinessList[0].BusinessCustomerList != null)
            {
                Hide();
                navigation.CreateNewQuote();
                viewModel.LoadData();
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
                messageService.ShowError("Please ensure that the following information is provided before creating a quote:\n" +
                                          ">  Business Information.\n" +
                                          ">  Business' Customer's Information.\n" +
                                          ">  Pump Information.", "ERROR - Prerequisites Not Met");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                serializationService.CloseApplication(true,
                    viewModel.BusinessList,
                    viewModel.PumpList,
                    viewModel.PartMap,
                    viewModel.QuoteMap);
        }

        private void ManagePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.ViewAllPumps();
            viewModel.LoadData();
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
            navigation.CreateNewPump();
            viewModel.LoadData();
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
            navigation.AddCustomer();
            viewModel.LoadData();
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
            navigation.ViewCustomers();
            viewModel.LoadData();
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
            navigation.AddBusiness();
            viewModel.LoadData();
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
            navigation.ViewBusinesses();
            viewModel.LoadData();
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

        Quote GetSelectedQuote()
        {
            if (dgvPreviousQuotes.CurrentCell == null || dgvPreviousQuotes.CurrentRow == null)
                return null;

            int idx = dgvPreviousQuotes.CurrentCell.RowIndex;
            if (idx < 0 || idx >= dgvPreviousQuotes.Rows.Count)
                return null;

            return dgvPreviousQuotes.Rows[idx].DataBoundItem as Quote;
        }

        private void BtnViewSelectedQuote_Click(object sender, EventArgs e)
        {
            if (viewModel.QuoteMap != null)
            {
                Quote selected = GetSelectedQuote();
                if (selected != null)
                {
                    Hide();
                    navigation.CreateNewQuote(selected, false);
                    viewModel.LoadData();
                    Show();
                }
            }
        }

        private void BtnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (viewModel.QuoteMap != null)
            {
                Quote selected = GetSelectedQuote();
                if (selected != null)
                {
                    this.Hide();
                    navigation.CreateNewQuote(selected, true);
                    viewModel.LoadData();
                    this.Show();
                }
            }
        }

        private void ViewAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.ViewAllParts();
            viewModel.LoadData();
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
            navigation.AddNewPart();
            viewModel.LoadData();
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        bool columnsConfigured = false;
        private void FrmViewQuotes_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            quotesBindingSource.DataSource = viewModel.Quotes;
            ConfigureColumns();
        }

        readonly int count = 0;
        private void FrmViewQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewModel.SaveChanges();
        }

        void ConfigureColumns()
        {
            if (columnsConfigured || dgvPreviousQuotes.Columns.Count == 0)
                return;

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

            columnsConfigured = true;
        }

        private void FrmViewQuotes_Activated(object sender, EventArgs e)
        {
            quotesBindingSource.DataSource = viewModel.Quotes;
        }
    }
}
