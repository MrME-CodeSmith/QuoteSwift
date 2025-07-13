using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditPhoneNumber : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmEditPhoneNumber(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
            if (passed.PhoneNumberToChange != "") txtPhoneNumber.Text = passed.PhoneNumberToChange;
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null)
            {
                FrmAddBusiness frmAddBusiness = new FrmAddBusiness(ref passed);
                if (!frmAddBusiness.PhoneNumberExisting(txtPhoneNumber.Text))
                {
                    passed.PhoneNumberToChange = txtPhoneNumber.Text;
                    MainProgramCode.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                    Close();
                }
            }
            else if (passed != null && passed.CustomerToChange != null)
            {
                FrmAddCustomer frmAddCustomer = new FrmAddCustomer(ref passed);
                if (!frmAddCustomer.PhoneNumberExisting(txtPhoneNumber.Text))
                {
                    passed.PhoneNumberToChange = txtPhoneNumber.Text;
                    MainProgramCode.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                    Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditPhoneNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }
    }
}
