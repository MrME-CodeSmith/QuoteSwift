using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManagingPhoneNumbers : Form
    {

        readonly ManagePhoneNumbersViewModel viewModel;
        readonly IMessageService messageService;

        public FrmManagingPhoneNumbers(ManagePhoneNumbersViewModel viewModel, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            SetupBindings();
        }

        void SetupBindings()
        {
            dgvTelephoneNumbers.DataSource = viewModel.TelephoneNumbers;
            dgvTelephoneNumbers.SelectionChanged += (s, e) =>
            {
                if (dgvTelephoneNumbers.CurrentRow?.DataBoundItem is ManagePhoneNumbersViewModel.NumberEntry entry)
                    viewModel.SelectedTelephoneNumber = entry;
                else
                    viewModel.SelectedTelephoneNumber = null;
            };

            dgvCellphoneNumbers.DataSource = viewModel.CellphoneNumbers;
            dgvCellphoneNumbers.SelectionChanged += (s, e) =>
            {
                if (dgvCellphoneNumbers.CurrentRow?.DataBoundItem is ManagePhoneNumbersViewModel.NumberEntry entry)
                    viewModel.SelectedCellphoneNumber = entry;
                else
                    viewModel.SelectedCellphoneNumber = null;
            };

            txtNewTelephone.DataBindings.Add("Text", viewModel, nameof(ManagePhoneNumbersViewModel.NewTelephoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtNewCellphone.DataBindings.Add("Text", viewModel, nameof(ManagePhoneNumbersViewModel.NewCellphoneNumber), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddTelephone, viewModel.AddTelephoneCommand);
            CommandBindings.Bind(btnAddCellphone, viewModel.AddCellphoneCommand);

            CommandBindings.Bind(btnRemoveTelNumber, viewModel.RemoveSelectedTelephoneCommand);
            CommandBindings.Bind(btnRemoveCellNumber, viewModel.RemoveSelectedCellphoneCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                Application.Exit();
            }
        }

        private void BtnChangePhoneNumberInfo_Click(object sender, EventArgs e)
        {
            if (viewModel.Business != null && viewModel.Business.BusinessCellphoneNumberList != null)
            {
                string oldNumber = viewModel.SelectedCellphoneNumber?.Number ?? string.Empty;
                var vm = new EditPhoneNumberViewModel(viewModel.Business, null, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerCellphoneNumberList != null)
            {
                string oldNumber = viewModel.SelectedCellphoneNumber?.Number ?? string.Empty;
                var vm = new EditPhoneNumberViewModel(null, viewModel.Customer, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (viewModel.Business != null && viewModel.Business.BusinessTelephoneNumberList != null)
            {
                string oldNumber = viewModel.SelectedTelephoneNumber?.Number ?? string.Empty;
                var vm = new EditPhoneNumberViewModel(viewModel.Business, null, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerTelephoneNumberList != null)
            {
                string oldNumber = viewModel.SelectedTelephoneNumber?.Number ?? string.Empty;
                var vm = new EditPhoneNumberViewModel(null, viewModel.Customer, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }



        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManagingPhoneNumbers_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
