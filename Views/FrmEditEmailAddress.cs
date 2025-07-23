using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditEmailAddress : BaseForm
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;
        readonly EditEmailAddressViewModel viewModel;
        public EditEmailAddressViewModel ViewModel => viewModel;

        public FrmEditEmailAddress(EditEmailAddressViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            this.navigation = navigation;
            viewModel.CloseAction = Close;
            SetupBindings();
            CommandBindings.Bind(btnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        void SetupBindings()
        {
            mtxtEmail.DataBindings.Add("Text", viewModel, nameof(EditEmailAddressViewModel.CurrentEmail), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            viewModel.SaveCommand.Execute(null);
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
        }

        // CommandBindings handle Cancel and Exit actions

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
