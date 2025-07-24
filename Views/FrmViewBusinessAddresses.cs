using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewBusinessAddresses : BaseForm<ViewBusinessAddressesViewModel>
    {

        readonly INavigationService navigation;
        Business business;
        Customer customer;

        void SetupBindings()
        {
            DgvViewAllBusinessAddresses.DataSource = ViewModel.Addresses;
            SelectionBindings.BindSelectedItem(DgvViewAllBusinessAddresses, ViewModel,
                nameof(ViewBusinessAddressesViewModel.SelectedAddress));

            BindingHelpers.BindReadOnly(DgvViewAllBusinessAddresses, ViewModel, nameof(ViewBusinessAddressesViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(BtnRemoveSelected, ViewModel, nameof(ViewBusinessAddressesViewModel.CanEdit));
            BindingHelpers.BindEnabled(BtnChangeAddressInfo, ViewModel, nameof(ViewBusinessAddressesViewModel.CanEdit));

            CommandBindings.Bind(BtnRemoveSelected, ViewModel.RemoveSelectedAddressCommand);
            CommandBindings.Bind(BtnChangeAddressInfo, ViewModel.EditAddressCommand);
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        public FrmViewBusinessAddresses(ViewBusinessAddressesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
        }

        public void Initialize(Business business = null, Customer customer = null)
        {
            this.business = business;
            this.customer = customer;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ViewModel.ExitCommand.CanExecute(null))
                ViewModel.ExitCommand.Execute(null);
        }

        private void FrmViewBusinessAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessAddressList != null) // View Business Address
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (ViewModel.IsReadOnly)
                {
                    BtnCancel.Enabled = true;
                }

            }
            else if (customer != null && customer.CustomerDeliveryAddressList != null) //View Customer Address
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (ViewModel.IsReadOnly)
                {
                    BtnCancel.Enabled = true;
                }

            }

            ViewModel.UpdateData(business, customer);

            DgvViewAllBusinessAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvViewAllBusinessAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            ViewModel.EditAddressCommand.Execute(null);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ViewModel.CancelCommand.CanExecute(null))
                ViewModel.CancelCommand.Execute(null);
        }


        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }



        /**********************************************************************************/
    }
}
