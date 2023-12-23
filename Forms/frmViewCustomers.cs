using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewCustomers : Form
    {
        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmViewCustomers()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
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

            mPassed.CustomerToChange = customer;
            mPassed.ChangeSpecificObject = false;
            mPassed.BusinessToChange = container;

            QuoteSwiftMainCode.AddCustomer();

            if (!ReplaceCustomer(customer, mPassed.CustomerToChange, container) && mPassed.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Customer will not be stored.", "ERROR - Customer Not Updated");

            mPassed.CustomerToChange = null;
            mPassed.BusinessToChange = null;
            mPassed.ChangeSpecificObject = false;

            LoadInformation();


        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            Hide();
            QuoteSwiftMainCode.AddCustomer();
            Show();

            LoadInformation();
        }

        private void FrmViewCustomers_Load(object sender, EventArgs e)
        {
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
                    container.CustomerList.Remove(customer);
                    MainProgramCode.ShowInformation("Successfully deleted '" + customer.CustomerName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (container.CustomerList.Count == 0) container.CustomerList = null;

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

            if (mPassed != null && mPassed.BusinessMap != null && cbBusinessSelection.Text.Length > 0)
                for (int i = 0; i < mPassed.BusinessMap.Count; i++)
                    if (cbBusinessSelection.Text == mPassed.BusinessMap.Values.ToArray()[i].BusinessName)
                        if (mPassed.BusinessMap.Values.ToArray()[i].CustomerList != null)
                            for (int j = 0; j < mPassed.BusinessMap.Values.ToArray()[i].CustomerList.Count; j++)
                                DgvCustomerList.Rows.Add(mPassed.BusinessMap.Values.ToArray()[i].CustomerList[j].CustomerCompanyName,
                                                         GetPreviousQuoteDate(mPassed.BusinessMap.Values.ToArray()[i].CustomerList[j]));

        }

        private string GetPreviousQuoteDate(Customer c)
        {
            if (mPassed.QuoteMap != null)
            {
                //TODO: Implement
            }

            return "No Previous Quote Date Available";
        }

        private bool ReplaceCustomer(Customer original, Customer @new, Business container)
        {
            if (@new != null && original != null && container != null && container.CustomerList != null)
                for (int i = 0; i < container.CustomerList.Count; i++)
                    if (container.CustomerList[i] == original)
                    {
                        container.CustomerList[i] = @new;
                        return true;
                    }

            return false;
        }

        private Customer GetCustomerSelection()
        {
            Customer customer;
            string SearchName;
            int iGridSelection;
            try
            {
                iGridSelection = DgvCustomerList.CurrentCell.RowIndex;
                SearchName = DgvCustomerList.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }

            if (GetSelectedBusiness() != null)
            {
                customer = GetSelectedBusiness().CustomerList.SingleOrDefault(p => p.CustomerCompanyName == SearchName);
                return customer;
            }

            return null;
        }

        private Business GetSelectedBusiness()
        {
            Business business;
            string SearchName = cbBusinessSelection.Text;

            if (mPassed.BusinessMap != null && SearchName.Length > 1)
            {
                business = mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessName == SearchName).Value;
                return business;
            }

            return null;
        }

        public void LinkBusinessToSource(ref ComboBox cb)
        {
            if (mPassed != null && mPassed.BusinessMap != null)
            {
                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = mPassed.BusinessMap };

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
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /**********************************************************************************/
    }
}
