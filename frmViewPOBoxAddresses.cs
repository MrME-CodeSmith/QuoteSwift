using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewPOBoxAddresses : Form
    {

        readonly ViewPOBoxAddressesViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;

        public FrmViewPOBoxAddresses(ViewPOBoxAddressesViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, Business business = null, Customer customer = null)
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

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    if (business != null && business.BusinessPOBoxAddressList != null)
                    {
                        business.RemovePOBoxAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (customer != null && customer.CustomerPOBoxAddress != null)
                    {
                        customer.RemovePOBoxAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid P.O.Box address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid P.O.Box Address, the current selection is invalid", "ERROR - Invalid P.O.Box Address Selection");
                return;
            }

            using (var form = new FrmEditBusinessAddress(appData, business, customer, address))
            {
                form.ShowDialog();
            }

            LoadInformation();
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessPOBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (!viewModel.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (customer != null && customer.CustomerPOBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (!viewModel.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            dgvPOBoxAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPOBoxAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        Address GetAddressSelection()
        {
            if (dgvPOBoxAddresses.CurrentCell == null || dgvPOBoxAddresses.CurrentRow == null)
                return null;

            int iGridSelection = dgvPOBoxAddresses.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= dgvPOBoxAddresses.Rows.Count)
                return null;

            string SearchName = dgvPOBoxAddresses.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return null;

            if (business != null && business.BusinessPOBoxAddressList != null)
            {
                return business.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
            }
            else if (customer != null && customer.CustomerPOBoxAddress != null)
            {
                return customer.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
            }

            return null;
        }

        void LoadInformation()
        {
            dgvPOBoxAddresses.Rows.Clear();
            if (business != null && business.BusinessPOBoxAddressList != null)
                for (int i = 0; i < business.BusinessPOBoxAddressList.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(business.BusinessPOBoxAddressList[i].AddressDescription, business.BusinessPOBoxAddressList[i].AddressStreetNumber,
                                                         business.BusinessPOBoxAddressList[i].AddressSuburb, business.BusinessPOBoxAddressList[i].AddressCity,
                                                         business.BusinessPOBoxAddressList[i].AddressAreaCode);

            if (customer != null && customer.CustomerPOBoxAddress != null)
                for (int i = 0; i < customer.CustomerPOBoxAddress.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(customer.CustomerPOBoxAddress[i].AddressDescription, customer.CustomerPOBoxAddress[i].AddressStreetNumber,
                                                         customer.CustomerPOBoxAddress[i].AddressSuburb, customer.CustomerPOBoxAddress[i].AddressCity,
                                                         customer.CustomerPOBoxAddress[i].AddressAreaCode);
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewPOBoxAddresses_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }

        /**********************************************************************************/
    }
}
