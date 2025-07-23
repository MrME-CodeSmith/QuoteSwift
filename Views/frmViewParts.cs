using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewParts : BaseForm
    {

        readonly ViewPartsViewModel viewModel;
        public ViewPartsViewModel ViewModel => viewModel;

        readonly BindingSource partsBindingSource = new BindingSource();

        readonly ApplicationData appData;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.serializationService = serializationService;
            appData = data;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            if (appData != null)
                viewModel.UpdateData(appData.PartList);
            SetupBindings();
        }

        void SetupBindings()
        {
            partsBindingSource.DataSource = viewModel;
            partsBindingSource.DataMember = nameof(ViewPartsViewModel.AllParts);
            dgvAllParts.DataSource = partsBindingSource;

            SelectionBindings.BindSelectedItem(dgvAllParts, viewModel, nameof(ViewPartsViewModel.SelectedPart));

            CommandBindings.Bind(btnAddPart, viewModel.AddPartCommand);
            CommandBindings.Bind(btnViewSelectedPart, viewModel.UpdatePartCommand);
            CommandBindings.Bind(btnRemovePart, viewModel.RemovePartCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (appData != null)
            {
                viewModel.UpdateData(appData.PartList);
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        // Binding handled automatically via BindingSource

        Part GetSelectedPart()
        {
            return dgvAllParts.CurrentRow?.DataBoundItem as Part;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewModel.CancelCommand.CanExecute(null))
                viewModel.CancelCommand.Execute(null);
        }

        private void FrmViewParts_Load(object sender, EventArgs e)
        {
            dgvAllParts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvAllParts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            if (viewModel.SaveChangesCommand.CanExecute(null))
                viewModel.SaveChangesCommand.Execute(null);
        }
    }
}