using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmViewParts : BaseForm<ViewPartsViewModel>
    {



        readonly BindingSource partsBindingSource = new BindingSource();
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.serializationService = serializationService;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            ViewModel.LoadDataCommand.Execute(null);
            SetupBindings();
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        void SetupBindings()
        {
            partsBindingSource.DataSource = ViewModel;
            partsBindingSource.DataMember = nameof(ViewPartsViewModel.AllParts);
            dgvAllParts.DataSource = partsBindingSource;

            SelectionBindings.BindSelectedItem(dgvAllParts, ViewModel, nameof(ViewPartsViewModel.SelectedPart));

            CommandBindings.Bind(btnAddPart, ViewModel.AddPartCommand);
            CommandBindings.Bind(btnViewSelectedPart, ViewModel.UpdatePartCommand);
            CommandBindings.Bind(btnRemovePart, ViewModel.RemovePartCommand);
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            ViewModel.LoadDataCommand.Execute(null);
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

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
            if (ViewModel.SaveChangesCommand.CanExecute(null))
                ViewModel.SaveChangesCommand.Execute(null);
        }
    }
}