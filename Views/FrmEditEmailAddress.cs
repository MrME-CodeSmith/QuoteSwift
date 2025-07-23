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
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"))
                Application.Exit();
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                Application.Exit();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
