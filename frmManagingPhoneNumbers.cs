using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManagingPhoneNumbers : BaseForm
    {

        readonly ManagePhoneNumbersViewModel viewModel;
        public ManagePhoneNumbersViewModel ViewModel => viewModel;
        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmManagingPhoneNumbers(ManagePhoneNumbersViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
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
            dgvTelephoneNumbers.DataSource = viewModel.TelephoneNumbers;
            SelectionBindings.BindSelectedItem(dgvTelephoneNumbers, viewModel, nameof(ManagePhoneNumbersViewModel.SelectedTelephoneNumber));

            dgvCellphoneNumbers.DataSource = viewModel.CellphoneNumbers;
            SelectionBindings.BindSelectedItem(dgvCellphoneNumbers, viewModel, nameof(ManagePhoneNumbersViewModel.SelectedCellphoneNumber));

            txtNewTelephone.DataBindings.Add("Text", viewModel, nameof(ManagePhoneNumbersViewModel.NewTelephoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtNewCellphone.DataBindings.Add("Text", viewModel, nameof(ManagePhoneNumbersViewModel.NewCellphoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddTelephone, viewModel.AddTelephoneCommand);
            CommandBindings.Bind(btnAddCellphone, viewModel.AddCellphoneCommand);

            CommandBindings.Bind(btnRemoveTelNumber, viewModel.RemoveSelectedTelephoneCommand);
            CommandBindings.Bind(btnRemoveCellNumber, viewModel.RemoveSelectedCellphoneCommand);
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(BtnUpdateTelephoneNumber, viewModel.EditTelephoneCommand);
            CommandBindings.Bind(BtnUpdateCellphoneNumber, viewModel.EditCellphoneCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }



        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (viewModel.Business != null && (viewModel.Business.BusinessTelephoneNumberList != null || viewModel.Business.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", viewModel.Business.BusinessName);

                // components remain editable
            }
            else if (viewModel.Customer != null && (viewModel.Customer.CustomerCellphoneNumberList != null || viewModel.Customer.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", viewModel.Customer.CustomerName);

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
