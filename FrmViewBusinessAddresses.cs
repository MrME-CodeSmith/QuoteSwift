using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewBusinessAddresses : BaseForm
    {

        readonly ViewBusinessAddressesViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly Business business;
        readonly Customer customer;

        void SetupBindings()
        {
            DgvViewAllBusinessAddresses.DataSource = viewModel.Addresses;
            DgvViewAllBusinessAddresses.SelectionChanged += (s, e) =>
            {
                if (DgvViewAllBusinessAddresses.CurrentRow?.DataBoundItem is Address a)
                    viewModel.SelectedAddress = a;
                else
                    viewModel.SelectedAddress = null;
            };

            CommandBindings.Bind(BtnRemoveSelected, viewModel.RemoveSelectedAddressCommand);
            CommandBindings.Bind(BtnChangeAddressInfo, viewModel.EditAddressCommand);
        }

        public FrmViewBusinessAddresses(ViewBusinessAddressesViewModel viewModel, INavigationService navigation = null, Business business = null, Customer customer = null, IMessageService messageService = null)
            : base(messageService, navigation)
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
            viewModel.EditAddressCommand.Execute(null);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
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



        /**********************************************************************************/
    }
}
