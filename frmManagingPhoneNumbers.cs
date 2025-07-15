using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
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
                string oldNumber = GetNumberSelection(viewModel.Business.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
                var vm = new EditPhoneNumberViewModel(viewModel.Business, null, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerCellphoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(viewModel.Customer.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
                var vm = new EditPhoneNumberViewModel(null, viewModel.Customer, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }

            LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (viewModel.Business != null && viewModel.Business.BusinessTelephoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(viewModel.Business.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
                var vm = new EditPhoneNumberViewModel(viewModel.Business, null, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }
            else if (viewModel.Customer != null && viewModel.Customer.CustomerTelephoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(viewModel.Customer.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);
                var vm = new EditPhoneNumberViewModel(null, viewModel.Customer, oldNumber, messageService);
                using (var form = new FrmEditPhoneNumber(vm, messageService))
                {
                    form.ShowDialog();
                }
            }

            LoadInformation();
        }

        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (viewModel.Business != null && (viewModel.Business.BusinessTelephoneNumberList != null || viewModel.Business.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", viewModel.Business.BusinessName);

                // components remain editable

                LoadInformation();
            }
            else if (viewModel.Customer != null && (viewModel.Customer.CustomerCellphoneNumberList != null || viewModel.Customer.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", viewModel.Customer.CustomerName);

                // components remain editable

                LoadInformation();
            }

            dgvCellphoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvCellphoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgvTelephoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvTelephoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveTelNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = "";

            if (viewModel.Business != null && viewModel.Business.BusinessTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(viewModel.Business.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);

            if (viewModel.Customer != null && viewModel.Customer.CustomerTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(viewModel.Customer.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);

            if (SelectedNumber != "")
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemoveTelephoneCommand.Execute(SelectedNumber);
                    messageService.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                    LoadInformation();
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnRemoveCellNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = string.Empty;
            if (viewModel.Business != null && viewModel.Business.BusinessCellphoneNumberList != null)
                SelectedNumber = GetNumberSelection(viewModel.Business.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            else if (viewModel.Customer != null && viewModel.Customer.CustomerCellphoneNumberList != null)
                SelectedNumber = GetNumberSelection(viewModel.Customer.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
            if (SelectedNumber != "")
            {
                viewModel.RemoveCellphoneCommand.Execute(SelectedNumber);
                messageService.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                LoadInformation();
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        string GetNumberSelection(IReadOnlyList<string> b, ref DataGridView d)
        {
            if (d == null || d.CurrentCell == null || d.CurrentRow == null)
                return string.Empty;

            int iGridSelection = d.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= d.Rows.Count)
                return string.Empty;

            string SearchName = d.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return string.Empty;

            if (b != null)
            {
                return b.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }

            return SearchName;
        }

        private void LoadInformation()
        {
            dgvTelephoneNumbers.Rows.Clear();
            dgvCellphoneNumbers.Rows.Clear();

            dgvTelephoneNumbers.DataSource = new BindingSource { DataSource = viewModel.TelephoneNumbers };
            dgvCellphoneNumbers.DataSource = new BindingSource { DataSource = viewModel.CellphoneNumbers };
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
