using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewAllBusinesses : BaseForm<ViewBusinessesViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly BindingSource businessBindingSource = new BindingSource();

        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        void SetupBindings()
        {
            businessBindingSource.DataSource = ViewModel;
            businessBindingSource.DataMember = nameof(ViewBusinessesViewModel.Businesses);
            DgvBusinessList.DataSource = businessBindingSource;
            SelectionBindings.BindSelectedItem(DgvBusinessList, ViewModel, nameof(ViewBusinessesViewModel.SelectedBusiness));
            CommandBindings.Bind(btnUpdateBusiness, ViewModel.UpdateBusinessCommand);
            CommandBindings.Bind(btnAddBusiness, ViewModel.AddBusinessCommand);
        }

        // CommandBindings handle Exit action

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (ViewModel.RemoveBusinessCommand.CanExecute(null))
                ViewModel.RemoveBusinessCommand.Execute(null);
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
