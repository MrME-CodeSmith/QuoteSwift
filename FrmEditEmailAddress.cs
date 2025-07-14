using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        readonly ManageEmailsViewModel viewModel;

        Pass passed
        {
            get => viewModel.Pass;
            set => viewModel.UpdatePass(value);
        }

        public ref Pass Passed { get => ref passed; }

        public FrmEditEmailAddress(ManageEmailsViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                string oldEmail = passed.EmailToChange;
                passed.EmailToChange = mtxtEmail.Text;
                if (passed != null && passed.BusinessToChange != null)
                {
                    var vm = new AddBusinessViewModel(new FileDataService());
                    vm.UpdatePass(passed);
                    FrmAddBusiness frmAddBusiness = new FrmAddBusiness(vm);
                    if (!frmAddBusiness.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else passed.EmailToChange = oldEmail;
                }
                else if (passed != null && passed.CustomerToChange != null)
                {
                    var vm = new AddCustomerViewModel(new FileDataService());
                    vm.UpdatePass(passed);
                    FrmAddCustomer frmAddCustomer = new FrmAddCustomer(vm);
                    if (!frmAddCustomer.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else passed.EmailToChange = oldEmail;
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
            mtxtEmail.Text = passed.EmailToChange;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref passed);
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditEmailAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }
    }
}
