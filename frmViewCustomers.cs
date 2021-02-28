using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnUpdateSelectedCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = GetCustomerSelection();
            Business container = GetSelectedBusiness();

            if(customer == null)
            {
                MainProgramCode.ShowError("Please select a valid customer, the current selection is invalid", "ERROR - Invalid Customer Selection");
                return;
            }

            this.passed.CustomerToChange = customer;
            this.passed.ChangeSpecificObject = false;
            this.passed.BusinessToChange = container;

            this.passed = MainProgramCode.AddCustomer(ref this.passed);

            if (!ReplaceCustomer(customer, this.passed.CustomerToChange, container) && passed.ChangeSpecificObject) MainProgramCode.ShowError("An error occured during the updating procedure.\nUpdated Customer will not be stored.", "ERROR - Customer Not Updated");

            this.passed.CustomerToChange = null;
            this.passed.BusinessToChange = null;
            passed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.AddCustomer(ref this.passed);
            this.Show();

            LoadInformation();
        }

        private void FrmViewCustomers_Load(object sender, EventArgs e)
        {
            LinkBusinessToSource(ref cbBusinessSelection);

            LoadInformation();

            this.DgvCustomerList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.DgvCustomerList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
                for (int i = 0; i < passed.PassBusinessList.Count; i++)
                    if (cbBusinessSelection.Text == passed.PassBusinessList[i].BusinessName)
                        if (passed.PassBusinessList[i].BusinessCustomerList != null)
                            for (int j = 0; j < passed.PassBusinessList[i].BusinessCustomerList.Count; j++)
                                DgvCustomerList.Rows.Add(passed.PassBusinessList[i].BusinessCustomerList[j].CustomerName,
                                                         passed.PassBusinessList[i].BusinessCustomerList[j].CustomerCompanyName,
                                                         GetPreviousQuoteDate(passed.PassBusinessList[i].BusinessCustomerList[j]));
        }

        private string GetPreviousQuoteDate(Customer c)
        {
            if(this.passed.PassQuoteList != null)
            {
                //TODO: Implement
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
                customer = GetSelectedBusiness().BusinessCustomerList.SingleOrDefault(p => p.CustomerName == SearchName);
                return customer;
            }

            return null;
        }

        private Business GetSelectedBusiness()
        {
            if(passed.PassBusinessList != null && cbBusinessSelection.Text.Length > 0)
            {
                for(int i = 0; i < passed.PassBusinessList.Count; i++)
                {
                    if (passed.PassBusinessList[i].BusinessName == cbBusinessSelection.Text) return passed.PassBusinessList[i];
                }
            }

            return null;
        }

        public void LinkBusinessToSource(ref ComboBox cb)
        {
            if (passed != null && passed.PassBusinessList != null)
            {
                //Created a Binding Source for the Business list to link the source
                //directly to the combobox's datasource:

                var ComboBoxBusinessSource = new BindingSource { DataSource = passed.PassBusinessList };

                cb.DataSource = ComboBoxBusinessSource.DataSource;

                //Linking the specific item from the Business class to display in the combobox:

                cb.DisplayMember = "BusinessName";
                cb.ValueMember = "BusinessName";
            }
        }

        /**********************************************************************************/
    }
}
