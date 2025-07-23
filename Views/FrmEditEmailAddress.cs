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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewModel.CancelCommand.CanExecute(null))
                viewModel.CancelCommand.Execute(null);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
