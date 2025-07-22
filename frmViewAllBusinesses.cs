using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewAllBusinesses : Form
    {

        readonly ViewBusinessesViewModel viewModel;
        public ViewBusinessesViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly BindingSource businessBindingSource = new BindingSource();

        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.messageService = messageService;
            SetupBindings();
        }

        void SetupBindings()
        {
            businessBindingSource.DataSource = viewModel;
            businessBindingSource.DataMember = nameof(ViewBusinessesViewModel.Businesses);
            DgvBusinessList.DataSource = businessBindingSource;
            SelectionBindings.BindSelectedItem(DgvBusinessList, viewModel, nameof(ViewBusinessesViewModel.SelectedBusiness));
            CommandBindings.Bind(btnUpdateBusiness, viewModel.UpdateBusinessCommand);
            CommandBindings.Bind(btnAddBusiness, viewModel.AddBusinessCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                Application.Exit();
        }

        // Legacy button handlers kept for reference; functionality now provided via commands
        private void BtnUpdateBusiness_Click(object sender, EventArgs e) { }
        private void BtnAddBusiness_Click(object sender, EventArgs e) { }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && viewModel.Businesses != null)
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemoveBusiness(business);
                    messageService.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");
                }
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private Business GetBusinessSelection()
        {
            return DgvBusinessList.CurrentRow?.DataBoundItem as Business;
        }

        private void LoadInformation()
        {
            // Binding handled automatically via businessBindingSource
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewAllBusinesses_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        /**********************************************************************************/
    }
}
