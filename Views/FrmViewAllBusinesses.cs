using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewAllBusinesses : BaseForm
    {

        readonly ViewBusinessesViewModel viewModel;
        public ViewBusinessesViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly BindingSource businessBindingSource = new BindingSource();

        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            BindIsBusy(viewModel);
            SetupBindings();
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
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

        // CommandBindings handle Exit action

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (viewModel.RemoveBusinessCommand.CanExecute(null))
                viewModel.RemoveBusinessCommand.Execute(null);
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        // CommandBindings handle Cancel action

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        /**********************************************************************************/
    }
}
