using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewCustomers : Form
    {
        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewCustomers(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
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

            passed.CustomerToChange = customer;
            passed.ChangeSpecificObject = false;
            passed.BusinessToChange = container;

            passed = QuoteSwiftMainCode.AddCustomer(ref passed);

            if (!ReplaceCustomer(customer, passed.CustomerToChange, container) && passed.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Customer will not be stored.", "ERROR - Customer Not Updated");

            passed.CustomerToChange = null;
            passed.BusinessToChange = null;
            passed.ChangeSpecificObject = false;

            LoadInformation();


        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddCustomer(ref passed);
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
                    container.BusinessCustomerList.Remove(customer);
                    MainProgramCode.ShowInformation("Successfully deleted '" + customer.CustomerName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (container.BusinessCustomerList.Count == 0) container.BusinessCustomerList = null;

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

            if (passed != null && passed.PassBusinessList != null && cbBusinessSelection.Text.Length > 0)
                foreach (var business in passed.PassBusinessList)
                    if (cbBusinessSelection.Text == business.BusinessName)
                        if (business.BusinessCustomerList != null)
                            foreach (var customer in business.BusinessCustomerList)
                                DgvCustomerList.Rows.Add(customer.CustomerCompanyName,
                                                         GetPreviousQuoteDate(customer));

        }

        private string GetPreviousQuoteDate(Customer c)
        {
            if (passed.PassQuoteList != null)
            {
                DateTime latest = DateTime.MinValue;
                bool found = false;

                foreach (var q in passed.PassQuoteList)
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
                for (int i = 0; i < Container.BusinessCustomerList.Count; i++)
                    if (Container.BusinessCustomerList[i] == Original)
                    {
                        Container.BusinessCustomerList[i] = New;
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
                customer = GetSelectedBusiness().BusinessCustomerList.SingleOrDefault(p => p.CustomerCompanyName == SearchName);
                return customer;
            }

            return null;
        }

        private Business GetSelectedBusiness()
        {
            Business business;
            string SearchName = cbBusinessSelection.Text;

            if (passed.PassBusinessList != null && SearchName.Length > 1)
            {
                business = passed.PassBusinessList.SingleOrDefault(p => p.BusinessName == SearchName);
                return business;
            }

            return null;
        }

        public void LinkBusinessToSource(ref ComboBox cb)
        {
            if (passed != null && passed.PassBusinessList != null)
            {
                BindingSource ComboBoxBusinessSource = new BindingSource { DataSource = passed.PassBusinessList };

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
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        /**********************************************************************************/
    }
}
