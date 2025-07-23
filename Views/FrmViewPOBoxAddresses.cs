using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewPOBoxAddresses : BaseForm
    {

        readonly ViewPOBoxAddressesViewModel viewModel;
        readonly INavigationService navigation;
        Business business;
        Customer customer;
        public ViewPOBoxAddressesViewModel ViewModel => viewModel;

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

            BindingHelpers.BindReadOnly(dgvPOBoxAddresses, viewModel, nameof(ViewPOBoxAddressesViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(btnRemoveAddress, viewModel, nameof(ViewPOBoxAddressesViewModel.CanEdit));

            CommandBindings.Bind(btnRemoveAddress, viewModel.RemoveSelectedAddressCommand);
            CommandBindings.Bind(btnChangeAddressInfo, viewModel.EditAddressCommand);
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        public FrmViewPOBoxAddresses(ViewPOBoxAddressesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            viewModel.CloseAction = Close;
            SetupBindings();
        }

        public void Initialize(Business business = null, Customer customer = null)
        {
            this.business = business;
            this.customer = customer;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewModel.CancelCommand.CanExecute(null))
                viewModel.CancelCommand.Execute(null);
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            if (viewModel.EditAddressCommand.CanExecute(null))
                viewModel.EditAddressCommand.Execute(null);
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (business != null && business.BusinessPOBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", business.BusinessName);

                if (viewModel.IsReadOnly)
                {
                    BtnCancel.Enabled = true;
                }

            }
            else if (customer != null && customer.CustomerPOBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", customer.CustomerName);

                if (viewModel.IsReadOnly)
                {
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

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }


        /**********************************************************************************/
    }
}
