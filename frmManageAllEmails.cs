using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManageAllEmails : Form
    {

        readonly ManageEmailsViewModel viewModel;
        readonly IMessageService messageService;

        public FrmManageAllEmails(ManageEmailsViewModel viewModel, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            SetupBindings();
        }

        void SetupBindings()
        {
            DgvEmails.DataSource = viewModel.Emails;
            DgvEmails.SelectionChanged += (s, e) =>
            {
                if (DgvEmails.CurrentRow?.DataBoundItem is ManageEmailsViewModel.EmailEntry entry)
                    viewModel.SelectedEmail = entry;
                else
                    viewModel.SelectedEmail = null;
            };

            CommandBindings.Bind(btnRemoveAddress, viewModel.RemoveSelectedEmailCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                Application.Exit();
            }
        }

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (viewModel.Business != null && viewModel.Business.BusinessEmailAddressList != null)
            {
                Text = Text.Replace("< Business Name >", viewModel.Business.BusinessName);

                // components remain editable
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", viewModel.Customer.CustomerName);

                // components remain editable
            }

            DgvEmails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvEmails.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            string SelectedEmail = viewModel.SelectedEmail?.Address ?? string.Empty;
            if (SelectedEmail != "")
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedEmail + "' email address from the list?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemoveEmailCommand.Execute(SelectedEmail);
                    messageService.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid email address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = viewModel.SelectedEmail?.Address ?? string.Empty;
            var vm = new EditEmailAddressViewModel(viewModel.Business, viewModel.Customer, email);
            using (var form = new FrmEditEmailAddress(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewEmail.Text))
            {
                messageService.ShowError("The provided email address is invalid.", "ERROR - Invalid Email Address");
                return;
            }
            viewModel.AddEmailCommand.Execute(txtNewEmail.Text);
            messageService.ShowInformation($"Successfully added '{txtNewEmail.Text}' to the email address list", "CONFIRMATION - Addition Success");
            txtNewEmail.Clear();
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManageAllEmails_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }

}
