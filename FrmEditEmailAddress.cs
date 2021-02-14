using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmEditEmailAddress(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                string oldEmail = passed.EmailToChange;
                passed.EmailToChange = mtxtEmail.Text;

                FrmAddBusiness frmAddBusiness = new FrmAddBusiness(ref this.passed);
                if (!frmAddBusiness.EmailAddressExisting(mtxtEmail.Text))
                {
                    MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                    this.Close();
                }
                else passed.EmailToChange = oldEmail;
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
            mtxtEmail.Text = passed.EmailToChange;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

    }
}
