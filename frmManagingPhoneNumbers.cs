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
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;

        public FrmManagingPhoneNumbers(ManagePhoneNumbersViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, Business business = null, Customer customer = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.business = business;
            this.customer = customer;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                appData.SaveAll();
                Application.Exit();
            }
        }

        private void BtnChangePhoneNumberInfo_Click(object sender, EventArgs e)
        {
            if (business != null && business.BusinessCellphoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(business.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
                using (var form = new FrmEditPhoneNumber(appData, business, null, oldNumber))
                {
                    form.ShowDialog();
                }
            }
            else if (customer != null && customer.CustomerCellphoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(customer.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
                using (var form = new FrmEditPhoneNumber(appData, null, customer, oldNumber))
                {
                    form.ShowDialog();
                }
            }

            LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (business != null && business.BusinessTelephoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(business.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
                using (var form = new FrmEditPhoneNumber(appData, business, null, oldNumber))
                {
                    form.ShowDialog();
                }
            }
            else if (customer != null && customer.CustomerTelephoneNumberList != null)
            {
                string oldNumber = GetNumberSelection(customer.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);
                using (var form = new FrmEditPhoneNumber(appData, null, customer, oldNumber))
                {
                    form.ShowDialog();
                }
            }

            LoadInformation();
        }

        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (business != null && (business.BusinessTelephoneNumberList != null || business.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", business.BusinessName);

                // components remain editable

                LoadInformation();
            }
            else if (customer != null && (customer.CustomerCellphoneNumberList != null || customer.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", customer.CustomerName);

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

            if (business != null && business.BusinessTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(business.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);

            if (customer != null && customer.CustomerTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(customer.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);

            if (SelectedNumber != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    if (business != null && business.BusinessTelephoneNumberList != null)
                    {
                        business.RemoveTelephoneNumber(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                    }
                    else if (customer != null && customer.CustomerTelephoneNumberList != null)
                    {
                        customer.RemoveTelephoneNumber(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnRemoveCellNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = string.Empty;
            if (business != null && business.BusinessCellphoneNumberList != null)
                SelectedNumber = GetNumberSelection(business.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            else if (customer != null && customer.CustomerCellphoneNumberList != null)
                SelectedNumber = GetNumberSelection(customer.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
            if (SelectedNumber != "")
            {
                if (business != null && business.BusinessCellphoneNumberList != null)
                {
                    business.RemoveCellphoneNumber(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                }
                else if (customer != null && customer.CustomerCellphoneNumberList != null)
                {
                    customer.RemoveCellphoneNumber(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                }

                LoadInformation();
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
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

            if (business != null && business.BusinessTelephoneNumberList != null)
            {
                foreach (var number in business.BusinessTelephoneNumberList)
                {
                    dgvTelephoneNumbers.Rows.Add(number);
                }
            }

            if (business != null && business.BusinessCellphoneNumberList != null)
            {
                foreach (var number in business.BusinessCellphoneNumberList)
                {
                    dgvCellphoneNumbers.Rows.Add(number);
                }
            }

            if (customer != null && customer.CustomerCellphoneNumberList != null)
            {
                foreach (var number in customer.CustomerCellphoneNumberList)
                {
                    dgvCellphoneNumbers.Rows.Add(number);
                }
            }

            if (customer != null && customer.CustomerTelephoneNumberList != null)
            {
                foreach (var number in customer.CustomerTelephoneNumberList)
                {
                    dgvTelephoneNumbers.Rows.Add(number);
                }
            }
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManagingPhoneNumbers_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }
}
