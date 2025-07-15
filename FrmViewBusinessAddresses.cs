using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewBusinessAddresses : Form
    {

        readonly ViewBusinessAddressesViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;

        public FrmViewBusinessAddresses(ViewBusinessAddressesViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, Business business = null, Customer customer = null)
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

        private void FrmViewBusinessAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessAddressList != null) // View Business Address
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (!viewModel.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (customer != null && customer.CustomerDeliveryAddressList != null) //View Customer Address
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (!viewModel.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            DgvViewAllBusinessAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvViewAllBusinessAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid Business Address, the current selection is invalid", "ERROR - Invalid Address Selection");
                return;
            }

            var vm = new EditBusinessAddressViewModel(business, customer, address);
            using (var form = new FrmEditBusinessAddress(vm, appData))
            {
                form.ShowDialog();
            }

            LoadInformation();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    if (business != null && customer == null)
                    {
                        business.RemoveAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (business == null && customer != null)
                    {
                        customer.RemoveDeliveryAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid address from the list.", "ERROR - Invalid Selection");
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        Address GetAddressSelection()
        {
            if (DgvViewAllBusinessAddresses.CurrentCell == null || DgvViewAllBusinessAddresses.CurrentRow == null)
                return null;

            int iGridSelection = DgvViewAllBusinessAddresses.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvViewAllBusinessAddresses.Rows.Count)
                return null;

            string SearchName = DgvViewAllBusinessAddresses.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return null;

            if (business != null && business.BusinessAddressList != null)
            {
                return business.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
            }
            else if (customer != null && customer.CustomerDeliveryAddressList != null)
            {
                return customer.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvViewAllBusinessAddresses.Rows.Clear();
            if (business != null && business.BusinessAddressList != null)
                for (int i = 0; i < business.BusinessAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(business.BusinessAddressList[i].AddressDescription, business.BusinessAddressList[i].AddressStreetNumber,
                                                         business.BusinessAddressList[i].AddressStreetName, business.BusinessAddressList[i].AddressSuburb,
                                                         business.BusinessAddressList[i].AddressCity, business.BusinessAddressList[i].AddressAreaCode);

            if (customer != null && customer.CustomerDeliveryAddressList != null)
                for (int i = 0; i < customer.CustomerDeliveryAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(customer.CustomerDeliveryAddressList[i].AddressDescription, customer.CustomerDeliveryAddressList[i].AddressStreetNumber,
                                                         customer.CustomerDeliveryAddressList[i].AddressStreetName, customer.CustomerDeliveryAddressList[i].AddressSuburb,
                                                         customer.CustomerDeliveryAddressList[i].AddressCity, customer.CustomerDeliveryAddressList[i].AddressAreaCode);
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewBusinessAddresses_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }


        /**********************************************************************************/
    }
}
