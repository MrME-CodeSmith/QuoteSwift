using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditPhoneNumber : Form
    {

        readonly ApplicationData appData;
        readonly IMessageService messageService;
        readonly EditPhoneNumberViewModel viewModel;

        public FrmEditPhoneNumber(EditPhoneNumberViewModel viewModel, ApplicationData data = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            appData = data;
            this.messageService = messageService;
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.CurrentNumber))
                txtPhoneNumber.Text = viewModel.CurrentNumber;
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            viewModel.CurrentNumber = txtPhoneNumber.Text;
            if (viewModel.UpdateNumber())
            {
                messageService.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                appData.SaveAll();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditPhoneNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }
}
