using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        readonly IMessageService messageService;
        readonly EditEmailAddressViewModel viewModel;

        public FrmEditEmailAddress(EditEmailAddressViewModel viewModel, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            SetupBindings();
        }

        void SetupBindings()
        {
            mtxtEmail.DataBindings.Add("Text", viewModel, nameof(EditEmailAddressViewModel.CurrentEmail), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            viewModel.UpdateEmailCommand.Execute(null);
            var result = viewModel.LastResult;
            if (result.Success)
            {
                messageService.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                Close();
            }
            else if (result.Message != null)
                messageService.ShowError(result.Message, result.Caption);
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

        private void FrmEditEmailAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
