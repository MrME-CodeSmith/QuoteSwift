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

            txtNewEmail.DataBindings.Add("Text", viewModel, nameof(ManageEmailsViewModel.NewEmail), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddEmail, viewModel.AddEmailCommand);

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


        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = viewModel.SelectedEmail?.Address ?? string.Empty;
            var vm = new EditEmailAddressViewModel(viewModel.Business, viewModel.Customer, email);
            using (var form = new FrmEditEmailAddress(vm, messageService))
            {
                form.ShowDialog();
            }
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
