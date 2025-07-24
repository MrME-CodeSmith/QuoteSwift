using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewPOBoxAddresses : BaseForm<ViewPOBoxAddressesViewModel>
    {

        readonly INavigationService navigation;
        Business business;
        Customer customer;

        void SetupBindings()
        {
            dgvPOBoxAddresses.DataSource = ViewModel.Addresses;
            SelectionBindings.BindSelectedItem(dgvPOBoxAddresses, ViewModel,
                nameof(ViewPOBoxAddressesViewModel.SelectedAddress));

            BindingHelpers.BindReadOnly(dgvPOBoxAddresses, ViewModel, nameof(ViewPOBoxAddressesViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(btnRemoveAddress, ViewModel, nameof(ViewPOBoxAddressesViewModel.CanEdit));

            CommandBindings.Bind(btnRemoveAddress, ViewModel.RemoveSelectedAddressCommand);
            CommandBindings.Bind(BtnChangeAddressInfo, ViewModel.EditAddressCommand);
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        public FrmViewPOBoxAddresses(ViewPOBoxAddressesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ViewModel.CancelCommand.CanExecute(null))
                ViewModel.CancelCommand.Execute(null);
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            if (ViewModel.EditAddressCommand.CanExecute(null))
                ViewModel.EditAddressCommand.Execute(null);
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessPOBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (ViewModel.IsReadOnly)
                {
                    BtnCancel.Enabled = true;
                }

            }
            else if (customer != null && customer.CustomerPOBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (ViewModel.IsReadOnly)
                {
                    BtnCancel.Enabled = true;
                }

            }

            ViewModel.UpdateData(business, customer);

            dgvPOBoxAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPOBoxAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
