using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManageAllEmails : BaseForm
    {

        readonly ManageEmailsViewModel viewModel;
        public ManageEmailsViewModel ViewModel => viewModel;
        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmManageAllEmails(ManageEmailsViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            SetupBindings();
        }

        void SetupBindings()
        {
            DgvEmails.DataSource = viewModel.Emails;
            SelectionBindings.BindSelectedItem(DgvEmails, viewModel, nameof(ManageEmailsViewModel.SelectedEmail));

            txtNewEmail.DataBindings.Add("Text", viewModel, nameof(ManageEmailsViewModel.NewEmail), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddEmail, viewModel.AddEmailCommand);
            CommandBindings.Bind(btnRemoveAddress, viewModel.RemoveSelectedEmailCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(BtnChangeAddressInfo, viewModel.EditSelectedEmailCommand);
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





        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }

}
