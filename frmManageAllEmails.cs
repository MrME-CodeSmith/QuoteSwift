using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManageAllEmails : Form
    {

        readonly ManageEmailsViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;

        public FrmManageAllEmails(ManageEmailsViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, Business business = null, Customer customer = null)
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

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessEmailAddressList != null)
            {
                Text = Text.Replace("< Business Name >", business.BusinessName);

                // components remain editable

                LoadInformation();
            }
            else if (customer != null && customer.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", customer.CustomerName);

                // components remain editable

                LoadInformation();
            }

            DgvEmails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvEmails.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            string SelectedEmail = GetEmailSelection();
            if (SelectedEmail != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedEmail + "' email address from the list?", "REQUEST - Deletion Request"))
                {
                    if (business != null && business.BusinessEmailAddressList != null)
                    {
                        business.RemoveEmailAddress(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (customer != null && customer.CustomerEmailList != null)
                    {
                        customer.RemoveEmailAddress(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                    }


                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid email address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = GetEmailSelection();
            var vm = new EditEmailAddressViewModel(business, customer, email);
            using (var form = new FrmEditEmailAddress(vm, appData))
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

            if (business != null && business.BusinessEmailAddressList != null)
            {
                return business.BusinessEmailAddressList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }
            else if (customer != null && customer.CustomerEmailList != null)
            {
                return customer.CustomerEmailList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }

            return string.Empty;
        }

        private void LoadInformation()
        {
            DgvEmails.Rows.Clear();
            if (business != null && business.BusinessEmailAddressList != null)
            {
                foreach (var email in business.BusinessEmailAddressList)
                {
                    DgvEmails.Rows.Add(email);
                }
            }
            else if (customer != null && customer.CustomerEmailList != null)
            {
                foreach (var email in customer.CustomerEmailList)
                {
                    DgvEmails.Rows.Add(email);
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManageAllEmails_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }

}
