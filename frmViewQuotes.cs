using System;
using System.Windows.Forms;

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
            SetupBindings();
        }

        void SetupBindings()
        {
            SelectionBindings.BindSelectedItem(dgvPreviousQuotes, viewModel, nameof(QuotesViewModel.SelectedQuote));

            CommandBindings.Bind(btnCreateNewQuote, viewModel.CreateQuoteCommand);
            CommandBindings.Bind(btnViewSelectedQuote, viewModel.ViewQuoteCommand);
            CommandBindings.Bind(btnCreateNewQuoteOnSelection, viewModel.CreateQuoteFromSelectionCommand);

            CommandBindings.Bind(manageBusinessesToolStripMenuItem, viewModel.ViewBusinessesCommand);
            CommandBindings.Bind(addNewBusinessToolStripMenuItem, viewModel.AddBusinessCommand);
            CommandBindings.Bind(ViewAllBusinessesToolStripMenuItem, viewModel.ViewBusinessesCommand);

            CommandBindings.Bind(manageCustomersToolStripMenuItem, viewModel.ViewCustomersCommand);
            CommandBindings.Bind(addNewCustomerToolStripMenuItem, viewModel.AddCustomerCommand);
            CommandBindings.Bind(viewAllCustomersToolStripMenuItem, viewModel.ViewCustomersCommand);

            CommandBindings.Bind(managePumpsToolStripMenuItem, viewModel.ViewPumpsCommand);
            CommandBindings.Bind(createNewPumpToolStripMenuItem, viewModel.CreatePumpCommand);
            CommandBindings.Bind(viewAllPumpsToolStripMenuItem, viewModel.ViewPumpsCommand);

            CommandBindings.Bind(managePumpPartsToolStripMenuItem, viewModel.ViewPartsCommand);
            CommandBindings.Bind(addNewPartToolStripMenuItem, viewModel.AddPartCommand);
            CommandBindings.Bind(viewAllPartsToolStripMenuItem, viewModel.ViewPartsCommand);
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
        }

        bool columnsConfigured = false;
        private async void FrmViewQuotes_Load(object sender, EventArgs e)
        {
            await viewModel.LoadDataAsync();
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
