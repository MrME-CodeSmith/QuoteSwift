using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewCustomers : BaseForm
    {
        readonly ViewCustomersViewModel viewModel;
        public ViewCustomersViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        readonly BindingSource customersBindingSource = new BindingSource();
        public FrmViewCustomers(ViewCustomersViewModel viewModel, INavigationService navigation = null, ApplicationData appData = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.appData = appData;
            this.messageService = messageService;
            SetupBindings();
            BindIsBusy(viewModel);
        }

        void SetupBindings()
        {
            customersBindingSource.DataSource = viewModel;
            customersBindingSource.DataMember = nameof(ViewCustomersViewModel.Customers);
            DgvCustomerList.DataSource = customersBindingSource;
            SelectionBindings.BindSelectedItem(DgvCustomerList, viewModel, nameof(ViewCustomersViewModel.SelectedCustomer));
            CommandBindings.Bind(btnUpdateSelectedCustomer, viewModel.UpdateCustomerCommand);
            CommandBindings.Bind(btnAddCustomer, viewModel.AddCustomerCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);

        }


        // Legacy button handlers kept for reference; functionality now provided via commands
        private void BtnUpdateSelectedCustomer_Click(object sender, EventArgs e) { }
        private void BtnAddCustomer_Click(object sender, EventArgs e) { }

        private async void FrmViewCustomers_Load(object sender, EventArgs e)
        {
            await viewModel.LoadDataAsync();
            LinkBusinessToSource(ref cbBusinessSelection);
            clmCustomerCompanyName.DataPropertyName = nameof(Customer.CustomerCompanyName);
            clmPreviousQuoteDate.DataPropertyName = nameof(Customer.PreviousQuoteDate);
            DgvCustomerList.AutoGenerateColumns = false;
            DgvCustomerList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvCustomerList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelectedCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = GetCustomerSelection();
            if (customer != null)
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + customer.CustomerName + "' from the customer list?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemoveCustomer(customer);
                    messageService.ShowInformation("Successfully deleted '" + customer.CustomerName + "' from the business list", "CONFIRMATION - Deletion Success");
                }
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        // Binding handled automatically via customersBindingSource


        private bool ReplaceCustomer(Customer Original, Customer New, Business Container)
        {
            if (New != null && Original != null && Container != null && Container.BusinessCustomerList != null)
            {
                if (Container.CustomerMap.TryGetValue(New.CustomerCompanyName, out Customer existing) && existing != Original)
                {
                    messageService.ShowError("This customer name is already in use.", "ERROR - Duplicate Customer Name");
                    return false;
                }

                Container.UpdateCustomer(Original, New);
                return true;
            }

            return false;
        }

        private Customer GetCustomerSelection()
        {
            return DgvCustomerList.CurrentRow?.DataBoundItem as Customer;
        }

        private Business GetSelectedBusiness()
        {
            return cbBusinessSelection.SelectedItem as Business;
        }

        public void LinkBusinessToSource(ref ComboBox cb)
        {
            if (viewModel.Businesses != null)
            {
                BindingSource source = new BindingSource { DataSource = viewModel.Businesses };

                cb.DataSource = source.DataSource;

                cb.DisplayMember = "BusinessName";
                cb.ValueMember = "BusinessName";
            }
        }

        private void CbBusinessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectBusiness(GetSelectedBusiness());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }

        /**********************************************************************************/
    }
}
