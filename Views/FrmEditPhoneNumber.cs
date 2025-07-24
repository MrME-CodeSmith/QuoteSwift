using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditPhoneNumber : BaseForm<EditPhoneNumberViewModel>
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmEditPhoneNumber(EditPhoneNumberViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.messageService = messageService;
            this.navigation = navigation;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        void SetupBindings()
        {
            txtPhoneNumber.DataBindings.Add("Text", ViewModel, nameof(EditPhoneNumberViewModel.CurrentNumber), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            if (ViewModel.UpdateNumberAndCloseCommand.CanExecute(null))
                ViewModel.UpdateNumberAndCloseCommand.Execute(null);
        }

        // CommandBindings handle Cancel and Exit actions

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
