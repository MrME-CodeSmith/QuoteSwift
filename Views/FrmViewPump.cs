using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuoteSwift.Views // Repair Quote Swift
{
    public partial class FrmViewPump : BaseForm<ViewPumpViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly Button btnCancelOperation;
        readonly BindingSource pumpBindingSource = new BindingSource();

        void SetupBindings()
        {
            pumpBindingSource.DataSource = ViewModel;
            pumpBindingSource.DataMember = nameof(ViewPumpViewModel.Pumps);
            dgvPumpList.DataSource = pumpBindingSource;

            SelectionBindings.BindSelectedItem(dgvPumpList, ViewModel, nameof(ViewPumpViewModel.SelectedPump));

            CommandBindings.Bind(btnViewSelectedPump, ViewModel.UpdatePumpCommand);
            CommandBindings.Bind(btnAddPump, ViewModel.AddPumpCommand);
            CommandBindings.Bind(btnRemovePumpSelection, ViewModel.RemovePumpCommand);

            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);

            exportInventoryToolStripMenuItem.Click += async (s, e) =>
            {
                if (ViewModel.ExportInventoryCommand.CanExecute(null))
                    await ((AsyncRelayCommand)ViewModel.ExportInventoryCommand).ExecuteAsync(null);
            };
        }

        public FrmViewPump(ViewPumpViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();

            btnCancelOperation = new Button
            {
                Text = "Cancel Operation",
                Size = new Size(130, 32),
                Location = new Point(btnAddPump.Right + 10, btnAddPump.Top)
            };
            btnCancelOperation.Click += BtnCancelOperation_Click;
            Controls.Add(btnCancelOperation);
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

        private void BtnCancelOperation_Click(object sender, EventArgs e)
        {
            ((AsyncRelayCommand)ViewModel.ExportInventoryCommand).Cancel();
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
            ViewModel.SaveChanges();
        }

        /*********************************************************************************/
    }
}
