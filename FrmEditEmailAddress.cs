using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditEmailAddress : Form
    {

        readonly ManageEmailsViewModel viewModel;


        public FrmEditEmailAddress(ManageEmailsViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void BtnUpdateBusinessEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                string oldEmail = viewModel.Pass.EmailToChange;
                viewModel.Pass.EmailToChange = mtxtEmail.Text;
                if (viewModel.Pass != null && viewModel.Pass.BusinessToChange != null)
                {
                    var vm = new AddBusinessViewModel(viewModel.DataService);
                    vm.UpdatePass(viewModel.Pass);
                    vm.LoadData();
                    FrmAddBusiness frmAddBusiness = new FrmAddBusiness(vm);
                    if (!frmAddBusiness.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else viewModel.Pass.EmailToChange = oldEmail;
                }
                else if (viewModel.Pass != null && viewModel.Pass.CustomerToChange != null)
                {
                    var vm = new AddCustomerViewModel(viewModel.DataService);
                    vm.UpdatePass(viewModel.Pass);
                    vm.LoadData();
                    FrmAddCustomer frmAddCustomer = new FrmAddCustomer(vm);
                    if (!frmAddCustomer.EmailAddressExisting(mtxtEmail.Text))
                    {
                        MainProgramCode.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                        Close();
                    }
                    else viewModel.Pass.EmailToChange = oldEmail;
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmEditEmailAddress_Load(object sender, EventArgs e)
        {
            mtxtEmail.Text = viewModel.Pass.EmailToChange;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p = viewModel.Pass;
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref p);
            viewModel.UpdatePass(p);
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p2 = viewModel.Pass;
                MainProgramCode.CloseApplication(true, ref p2);
                viewModel.UpdatePass(p2);
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditEmailAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            var p3 = viewModel.Pass;
            MainProgramCode.CloseApplication(true, ref p3);
            viewModel.UpdatePass(p3);
        }
    }
}
