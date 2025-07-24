using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewQuotes : BaseForm<QuotesViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        readonly BindingSource quotesBindingSource = new BindingSource();

        public FrmViewQuotes(QuotesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
        : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            quotesBindingSource.DataSource = ViewModel.Quotes;
            dgvPreviousQuotes.DataSource = quotesBindingSource;
            SetupBindings();
            BindIsBusy(ViewModel);
        }

        void SetupBindings()
        {
            SelectionBindings.BindSelectedItem(dgvPreviousQuotes, ViewModel, nameof(QuotesViewModel.SelectedQuote));

            CommandBindings.Bind(btnCreateNewQuote, ViewModel.CreateQuoteCommand);
            CommandBindings.Bind(btnViewSelectedQuote, ViewModel.ViewQuoteCommand);
            CommandBindings.Bind(btnCreateNewQuoteOnSelection, ViewModel.CreateQuoteFromSelectionCommand);

            CommandBindings.Bind(manageBusinessesToolStripMenuItem, ViewModel.ViewBusinessesCommand);
            CommandBindings.Bind(addNewBusinessToolStripMenuItem, ViewModel.AddBusinessCommand);
            CommandBindings.Bind(ViewAllBusinessesToolStripMenuItem, ViewModel.ViewBusinessesCommand);

            CommandBindings.Bind(manageCustomersToolStripMenuItem, ViewModel.ViewCustomersCommand);
            CommandBindings.Bind(addNewCustomerToolStripMenuItem, ViewModel.AddCustomerCommand);
            CommandBindings.Bind(viewAllCustomersToolStripMenuItem, ViewModel.ViewCustomersCommand);

            CommandBindings.Bind(managePumpsToolStripMenuItem, ViewModel.ViewPumpsCommand);
            CommandBindings.Bind(createNewPumpToolStripMenuItem, ViewModel.CreatePumpCommand);
            CommandBindings.Bind(viewAllPumpsToolStripMenuItem, ViewModel.ViewPumpsCommand);

            CommandBindings.Bind(managePumpPartsToolStripMenuItem, ViewModel.ViewPartsCommand);
            CommandBindings.Bind(addNewPartToolStripMenuItem, ViewModel.AddPartCommand);
            CommandBindings.Bind(viewAllPartsToolStripMenuItem, ViewModel.ViewPartsCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }


        bool columnsConfigured = false;
        private async void FrmViewQuotes_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            quotesBindingSource.DataSource = ViewModel.Quotes;
            ConfigureColumns();
        }

        readonly int count = 0;
        protected override void OnClose()
        {
            ViewModel.SaveChanges();
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
            quotesBindingSource.DataSource = ViewModel.Quotes;
        }
    }
}
