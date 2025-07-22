using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewPOBoxAddresses : Form
    {

        readonly ViewPOBoxAddressesViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly Business business;
        readonly Customer customer;

        void SetupBindings()
        {
            dgvPOBoxAddresses.DataSource = viewModel.Addresses;
            dgvPOBoxAddresses.SelectionChanged += (s, e) =>
            {
                if (dgvPOBoxAddresses.CurrentRow?.DataBoundItem is Address a)
                    viewModel.SelectedAddress = a;
                else
                    viewModel.SelectedAddress = null;
            };

            CommandBindings.Bind(btnRemoveAddress, viewModel.RemoveSelectedAddressCommand);
        }

        public FrmViewPOBoxAddresses(ViewPOBoxAddressesViewModel viewModel, INavigationService navigation = null, Business business = null, Customer customer = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.messageService = messageService;
            this.business = business;
            this.customer = customer;
            SetupBindings();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                navigation?.SaveAllData();
                Application.Exit();
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                messageService.ShowError("Please select a valid P.O.Box Address, the current selection is invalid", "ERROR - Invalid P.O.Box Address Selection");
                return;
            }

            navigation?.EditBusinessAddress(business, customer, address);

            viewModel.UpdateData(business, customer);
        }

        void ApplyControlState()
        {
            ControlStateHelper.ApplyReadOnly(Controls, true);
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessPOBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (viewModel.IsReadOnly)
                {
                    ApplyControlState();
                    BtnCancel.Enabled = true;
                }

            }
            else if (customer != null && customer.CustomerPOBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (viewModel.IsReadOnly)
                {
                    ApplyControlState();
                    BtnCancel.Enabled = true;
                }

            }

            viewModel.UpdateData(business, customer);

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
            return dgvPOBoxAddresses.CurrentRow?.DataBoundItem as Address;
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewPOBoxAddresses_FormClosing(object sender, FormClosingEventArgs e)
        {
            navigation?.SaveAllData();
        }

        /**********************************************************************************/
    }
}
