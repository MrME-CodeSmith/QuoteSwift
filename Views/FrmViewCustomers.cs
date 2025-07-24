using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewCustomers : BaseForm<ViewCustomersViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly BindingSource customersBindingSource = new BindingSource();
        public FrmViewCustomers(ViewCustomersViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            SetupBindings();
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            BindIsBusy(ViewModel);
        }

        void SetupBindings()
        {
            customersBindingSource.DataSource = ViewModel;
            customersBindingSource.DataMember = nameof(ViewCustomersViewModel.Customers);
            DgvCustomerList.DataSource = customersBindingSource;
            SelectionBindings.BindSelectedItem(DgvCustomerList, ViewModel, nameof(ViewCustomersViewModel.SelectedCustomer));
            CommandBindings.Bind(btnUpdateSelectedCustomer, ViewModel.UpdateCustomerCommand);
            CommandBindings.Bind(btnAddCustomer, ViewModel.AddCustomerCommand);
            BindingHelpers.BindComboBox(cbBusinessSelection, ViewModel,
                nameof(ViewCustomersViewModel.Businesses), nameof(ViewCustomersViewModel.SelectedBusiness),
                "BusinessName", "BusinessName");
        }

        // CommandBindings handle Exit action

        private async void FrmViewCustomers_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            clmCustomerCompanyName.DataPropertyName = nameof(Customer.CustomerCompanyName);
            clmPreviousQuoteDate.DataPropertyName = nameof(Customer.PreviousQuoteDate);
            DgvCustomerList.AutoGenerateColumns = false;
            DgvCustomerList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvCustomerList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelectedCustomer_Click(object sender, EventArgs e)
        {
            if (ViewModel.RemoveCustomerCommand.CanExecute(null))
                ViewModel.RemoveCustomerCommand.Execute(null);
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        // Binding handled automatically via customersBindingSource

        // CommandBindings handle Cancel action

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        // rely on base.OnClose for data persistence

        /**********************************************************************************/
    }
}
