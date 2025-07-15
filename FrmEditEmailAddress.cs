using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        readonly ApplicationData appData;
        readonly EditEmailAddressViewModel viewModel;

        public FrmEditEmailAddress(EditEmailAddressViewModel viewModel, ApplicationData data = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            appData = data;
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            viewModel.CurrentEmail = mtxtEmail.Text;
            if (viewModel.UpdateEmail())
            {
                MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                Close();
            }
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
            mtxtEmail.Text = viewModel.CurrentEmail;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"))
                appData.SaveAll();
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                appData.SaveAll();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditEmailAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }
}
