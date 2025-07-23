using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditPhoneNumber : BaseForm
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;
        readonly EditPhoneNumberViewModel viewModel;
        public EditPhoneNumberViewModel ViewModel => viewModel;

        public FrmEditPhoneNumber(EditPhoneNumberViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            this.navigation = navigation;
            viewModel.CloseAction = Close;
            SetupBindings();
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        void SetupBindings()
        {
            txtPhoneNumber.DataBindings.Add("Text", viewModel, nameof(EditPhoneNumberViewModel.CurrentNumber), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            viewModel.UpdateNumberCommand.Execute(null);
            var result = viewModel.LastResult;
            if (result.Success)
            {
                messageService.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                Close();
            }
            else if (result.Message != null)
                messageService.ShowError(result.Message, result.Caption);
        }

        // CommandBindings handle Cancel and Exit actions

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
