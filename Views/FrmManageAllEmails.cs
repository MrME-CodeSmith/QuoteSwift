using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmManageAllEmails : BaseForm<ManageEmailsViewModel>
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmManageAllEmails(ManageEmailsViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
        }

        void SetupBindings()
        {
            DgvEmails.DataSource = ViewModel.Emails;
            SelectionBindings.BindSelectedItem(DgvEmails, ViewModel, nameof(ManageEmailsViewModel.SelectedEmail));

            txtNewEmail.DataBindings.Add("Text", ViewModel, nameof(ManageEmailsViewModel.NewEmail), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddEmail, ViewModel.AddEmailCommand);
            CommandBindings.Bind(btnRemoveAddress, ViewModel.RemoveSelectedEmailCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(BtnChangeAddressInfo, ViewModel.EditSelectedEmailCommand);
        }

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (ViewModel.Business != null && ViewModel.Business.BusinessEmailAddressList != null)
            {
                Text = Text.Replace("< Business Name >", ViewModel.Business.BusinessName);

                // components remain editable
            }
            else if (ViewModel.Customer != null && ViewModel.Customer.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", ViewModel.Customer.CustomerName);

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
