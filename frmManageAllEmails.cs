using System;
using System.Drawing;
using System.Linq;
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

                LoadInformation();
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", viewModel.Customer.CustomerName);

                // components remain editable

                LoadInformation();
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
            string SelectedEmail = GetEmailSelection();
            if (SelectedEmail != "")
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedEmail + "' email address from the list?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemoveEmail(SelectedEmail);
                    messageService.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");


                    LoadInformation();
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid email address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = GetEmailSelection();
            var vm = new EditEmailAddressViewModel(viewModel.Business, viewModel.Customer, email);
            using (var form = new FrmEditEmailAddress(vm, messageService))
            {
                form.ShowDialog();
            }
            LoadInformation();
        }

        string GetEmailSelection()
        {
            if (DgvEmails.CurrentCell == null || DgvEmails.CurrentRow == null)
                return string.Empty;

            int iGridSelection = DgvEmails.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvEmails.Rows.Count)
                return string.Empty;

            string SearchName = DgvEmails.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return string.Empty;

            if (viewModel.Business != null && viewModel.Business.BusinessEmailAddressList != null)
            {
                return viewModel.Business.BusinessEmailAddressList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerEmailList != null)
            {
                return viewModel.Customer.CustomerEmailList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }

            return string.Empty;
        }

        private void LoadInformation()
        {
            DgvEmails.DataSource = new BindingSource { DataSource = viewModel.Emails };
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
