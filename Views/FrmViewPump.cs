using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views // Repair Quote Swift
{
    public partial class FrmViewPump : BaseForm
    {

        readonly ViewPumpViewModel viewModel;
        public ViewPumpViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly BindingSource pumpBindingSource = new BindingSource();

        void SetupBindings()
        {
            pumpBindingSource.DataSource = viewModel;
            pumpBindingSource.DataMember = nameof(ViewPumpViewModel.Pumps);
            dgvPumpList.DataSource = pumpBindingSource;

            SelectionBindings.BindSelectedItem(dgvPumpList, viewModel, nameof(ViewPumpViewModel.SelectedPump));

            CommandBindings.Bind(btnViewSelectedPump, viewModel.UpdatePumpCommand);
            CommandBindings.Bind(btnAddPump, viewModel.AddPumpCommand);
            CommandBindings.Bind(btnRemovePumpSelection, viewModel.RemovePumpCommand);

            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);

            exportInventoryToolStripMenuItem.Click += async (s, e) =>
            {
                if (viewModel.ExportInventoryCommand.CanExecute(null))
                    await ((AsyncRelayCommand)viewModel.ExportInventoryCommand).ExecuteAsync(null);
            };
        }

        public FrmViewPump(ViewPumpViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            BindIsBusy(viewModel);
            SetupBindings();
        }

        // CommandBindings handle Exit action


        private void MainScreenViewQuotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Hide();
        }

        private void FrmViewPump_Load(object sender, EventArgs e)
        {
            dgvPumpList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPumpList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        // Binding handled automatically via pumpBindingSource

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            viewModel.SaveChanges();
        }

        /*********************************************************************************/
    }
}
