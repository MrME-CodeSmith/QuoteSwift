using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditEmailAddress : BaseForm<EditEmailAddressViewModel>
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmEditEmailAddress(EditEmailAddressViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.messageService = messageService;
            this.navigation = navigation;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
            CommandBindings.Bind(btnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        void SetupBindings()
        {
            mtxtEmail.DataBindings.Add("Text", ViewModel, nameof(EditEmailAddressViewModel.CurrentEmail), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute(null);
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
