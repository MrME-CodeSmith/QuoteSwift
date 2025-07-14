using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewCustomers : Form
    {
        readonly ViewCustomersViewModel viewModel;
        readonly INavigationService navigation;


        public FrmViewCustomers(ViewCustomersViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p = viewModel.Pass;
                MainProgramCode.CloseApplication(true, ref p);
                viewModel.UpdatePass(p);
            }
        }

        private void BtnUpdateSelectedCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = GetCustomerSelection();
            Business container = GetSelectedBusiness();

            if (customer == null)
            {
                MainProgramCode.ShowError("Please select a valid customer, the current selection is invalid", "ERROR - Invalid Customer Selection");
                return;
            }

            viewModel.Pass.CustomerToChange = customer;
            viewModel.Pass.ChangeSpecificObject = false;
            viewModel.Pass.BusinessToChange = container;

            navigation.AddCustomer();
            viewModel.UpdatePass(navigation.Pass);

            if (!ReplaceCustomer(customer, viewModel.Pass.CustomerToChange, container) && viewModel.Pass.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Customer will not be stored.", "ERROR - Customer Not Updated");

            viewModel.Pass.CustomerToChange = null;
            viewModel.Pass.BusinessToChange = null;
            viewModel.Pass.ChangeSpecificObject = false;

            LoadInformation();


        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddCustomer();
            viewModel.UpdatePass(navigation.Pass);
            Show();

            LoadInformation();
        }

        private void FrmViewCustomers_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            LinkBusinessToSource(ref cbBusinessSelection);

            LoadInformation();

            DgvCustomerList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvCustomerList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelectedCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = GetCustomerSelection();
            Business container = GetSelectedBusiness();

            if (customer != null && container != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + customer.CustomerName + "' from the customer list?", "REQUEST - Deletion Request"))
                {
                    container.RemoveCustomer(customer);
                    MainProgramCode.ShowInformation("Successfully deleted '" + customer.CustomerName + "' from the business list", "CONFIRMATION - Deletion Success");

                    LoadInformation();
                }
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private void LoadInformation()
        {
            DgvCustomerList.Rows.Clear();

            if (viewModel.Pass != null && viewModel.Pass.PassBusinessList != null && cbBusinessSelection.Text.Length > 0)
                foreach (var business in viewModel.Pass.PassBusinessList)
                    if (cbBusinessSelection.Text == business.BusinessName)
                        if (business.BusinessCustomerList != null)
                            foreach (var customer in business.BusinessCustomerList)
                                DgvCustomerList.Rows.Add(customer.CustomerCompanyName,
                                                         GetPreviousQuoteDate(customer));

        }

        private string GetPreviousQuoteDate(Customer c)
        {
            if (viewModel.Pass.PassQuoteMap != null)
            {
                DateTime latest = DateTime.MinValue;
                bool found = false;

                foreach (var q in viewModel.Pass.PassQuoteMap.Values)
                {
                    if (q.QuoteCustomer != null && c != null &&
                        q.QuoteCustomer.CustomerCompanyName == c.CustomerCompanyName)
                    {
                        if (!found || q.QuoteCreationDate.Date > latest.Date)
                        {
                            latest = q.QuoteCreationDate;
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    return latest.ToShortDateString();
                }
            }

            return "No Previous Quote Date Available";
        }

        private bool ReplaceCustomer(Customer Original, Customer New, Business Container)
        {
            if (New != null && Original != null && Container != null && Container.BusinessCustomerList != null)
            {
                if (Container.CustomerMap.TryGetValue(New.CustomerCompanyName, out Customer existing) && existing != Original)
                {
                    MainProgramCode.ShowError("This customer name is already in use.", "ERROR - Duplicate Customer Name");
                    return false;
                }

                Container.UpdateCustomer(Original, New);
                return true;
            }

            return false;
        }

        private Customer GetCustomerSelection()
        {
            if (DgvCustomerList.CurrentCell == null || DgvCustomerList.CurrentRow == null)
                return null;

            int iGridSelection = DgvCustomerList.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvCustomerList.Rows.Count)
                return null;

            string SearchName = DgvCustomerList.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return null;

            Business selected = GetSelectedBusiness();
            if (selected != null && selected.CustomerMap != null && selected.CustomerMap.TryGetValue(SearchName, out Customer customer))
                return customer;

            return null;
        }

        private Business GetSelectedBusiness()
        {
            string searchName = cbBusinessSelection.Text;

            if (searchName.Length > 1 && viewModel.Pass.BusinessLookup.TryGetValue(searchName, out Business business))
            {
                return business;
            }

            return null;
        }

        public void LinkBusinessToSource(ref ComboBox cb)
        {
            if (viewModel.Pass != null && viewModel.Pass.PassBusinessList != null)
            {
                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = viewModel.Pass.PassBusinessList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                cb.DisplayMember = "BusinessName";
                cb.ValueMember = "BusinessName";
            }
        }

        private void CbBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInformation();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {
            var p = viewModel.Pass;
            MainProgramCode.CloseApplication(true, ref p);
            viewModel.UpdatePass(p);
        }

        /**********************************************************************************/
    }
}
