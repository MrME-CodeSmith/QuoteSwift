using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmManagingPhoneNumbers : BaseForm<ManagePhoneNumbersViewModel>
    {

        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmManagingPhoneNumbers(ManagePhoneNumbersViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
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
            dgvTelephoneNumbers.DataSource = ViewModel.TelephoneNumbers;
            SelectionBindings.BindSelectedItem(dgvTelephoneNumbers, ViewModel, nameof(ManagePhoneNumbersViewModel.SelectedTelephoneNumber));

            dgvCellphoneNumbers.DataSource = ViewModel.CellphoneNumbers;
            SelectionBindings.BindSelectedItem(dgvCellphoneNumbers, ViewModel, nameof(ManagePhoneNumbersViewModel.SelectedCellphoneNumber));

            txtNewTelephone.DataBindings.Add("Text", ViewModel, nameof(ManagePhoneNumbersViewModel.NewTelephoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtNewCellphone.DataBindings.Add("Text", ViewModel, nameof(ManagePhoneNumbersViewModel.NewCellphoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddTelephone, ViewModel.AddTelephoneCommand);
            CommandBindings.Bind(btnAddCellphone, ViewModel.AddCellphoneCommand);

            CommandBindings.Bind(btnRemoveTelNumber, ViewModel.RemoveSelectedTelephoneCommand);
            CommandBindings.Bind(btnRemoveCellNumber, ViewModel.RemoveSelectedCellphoneCommand);
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(BtnUpdateTelephoneNumber, ViewModel.EditTelephoneCommand);
            CommandBindings.Bind(BtnUpdateCellphoneNumber, ViewModel.EditCellphoneCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }



        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (ViewModel.Business != null && (ViewModel.Business.BusinessTelephoneNumberList != null || ViewModel.Business.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", ViewModel.Business.BusinessName);

                // components remain editable
            }
            else if (ViewModel.Customer != null && (ViewModel.Customer.CustomerCellphoneNumberList != null || ViewModel.Customer.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", ViewModel.Customer.CustomerName);

                // components remain editable
            }

            dgvCellphoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvCellphoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgvTelephoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvTelephoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }






        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

    }
}
