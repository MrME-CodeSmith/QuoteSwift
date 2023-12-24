using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmEditEmailAddress()
        {
            InitializeComponent();
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                string oldEmail = mPassed.EmailToChange;
                mPassed.EmailToChange = mtxtEmail.Text;
                if (mPassed != null && mPassed.BusinessToChange != null)
                {
                    FrmAddBusiness frmAddBusiness = new FrmAddBusiness();
                    if (!frmAddBusiness.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else mPassed.EmailToChange = oldEmail;
                }
                else if (mPassed != null && mPassed.CustomerToChange != null)
                {
                    FrmAddCustomer frmAddCustomer = new FrmAddCustomer();
                    if (!frmAddCustomer.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else mPassed.EmailToChange = oldEmail;
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
            mtxtEmail.Text = mPassed.EmailToChange;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"));
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditEmailAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }
    }
}
