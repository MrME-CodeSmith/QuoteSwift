using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewBusinessAddresses : Form
    {

        readonly ViewBusinessAddressesViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly IMessageService messageService;
        readonly Business business;
        readonly Customer customer;

        void SetupBindings()
        {
            DgvViewAllBusinessAddresses.DataSource = viewModel.Addresses;
        }

        public FrmViewBusinessAddresses(ViewBusinessAddressesViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, Business business = null, Customer customer = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.messageService = messageService;
            this.business = business;
            this.customer = customer;
            SetupBindings();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
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

                if (viewModel.IsReadOnly)
                {
                    ApplyControlState();
                    BtnCancel.Enabled = true;
                }

            }
            else if (customer != null && customer.CustomerDeliveryAddressList != null) //View Customer Address
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (viewModel.IsReadOnly)
                {
                    ApplyControlState();
                    BtnCancel.Enabled = true;
                }

            }

            viewModel.UpdateData(business, customer);

            DgvViewAllBusinessAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvViewAllBusinessAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                messageService.ShowError("Please select a valid Business Address, the current selection is invalid", "ERROR - Invalid Address Selection");
                return;
            }

            var vm = new EditBusinessAddressViewModel(business, customer, address);
            using (var form = new FrmEditBusinessAddress(vm, appData))
            {
                form.ShowDialog();
            }

            viewModel.UpdateData(business, customer);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    if (business != null && customer == null)
                    {
                        business.RemoveAddress(SelectedAddress);
                        messageService.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (business == null && customer != null)
                    {
                        customer.RemoveDeliveryAddress(SelectedAddress);
                        messageService.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }

                    viewModel.UpdateData(business, customer);
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid address from the list.", "ERROR - Invalid Selection");
            }
        }

        void ApplyControlState()
        {
            ControlStateHelper.ApplyReadOnly(Controls, true);
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        Address GetAddressSelection()
        {
            return DgvViewAllBusinessAddresses.CurrentRow?.DataBoundItem as Address;
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
