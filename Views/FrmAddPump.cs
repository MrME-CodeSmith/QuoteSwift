using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace QuoteSwift.Views
{
    public partial class FrmAddPump : BaseForm<AddPumpViewModel>
    {
        
        readonly INavigationService navigation;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        readonly BindingSource mandatorySource = new BindingSource();
        readonly BindingSource nonMandatorySource = new BindingSource();

        public FrmAddPump(AddPumpViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            ViewModel.CurrentPump = ViewModel.PumpToChange ?? new Pump();
            BindingHelpers.BindText(mtxtPumpName, ViewModel, nameof(AddPumpViewModel.PumpName));
            BindingHelpers.BindText(mtxtPumpDescription, ViewModel, nameof(AddPumpViewModel.PumpDescription));
            BindingHelpers.BindText(mtxtNewPumpPrice, ViewModel, nameof(AddPumpViewModel.NewPumpPrice));
            mandatorySource.DataSource = ViewModel.SelectedMandatoryParts;
            nonMandatorySource.DataSource = ViewModel.SelectedNonMandatoryParts;
            CommandBindings.Bind(btnAddPump, ViewModel.SavePumpCommand);
            CommandBindings.Bind(btnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            ViewModel.LoadDataCommand.Execute(null);
            BindIsBusy(ViewModel);
        }

        // Input changes are tracked by the view model

        private async void FrmAddPump_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            SetupBindings();

            if (ViewModel.PumpToChange == null)
                mtxtPumpName.Focus();

            dgvMandatoryPartView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvMandatoryPartView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgvNonMandatoryPartView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvNonMandatoryPartView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */


        void SetupBindings()
        {
            dgvMandatoryPartView.AutoGenerateColumns = false;
            ClmPartName.DataPropertyName = "PumpPart.PartName";
            clmDescription.DataPropertyName = "PumpPart.PartDescription";
            clmOriginalPartNumber.DataPropertyName = "PumpPart.OriginalItemPartNumber";
            clmNewPartNumber.DataPropertyName = "PumpPart.NewPartNumber";
            clmPartPrice.DataPropertyName = "PumpPart.PartPrice";
            clmMPartQuantity.DataPropertyName = nameof(Pump_Part.PumpPartQuantity);
            dgvMandatoryPartView.DataSource = mandatorySource;

            dgvNonMandatoryPartView.AutoGenerateColumns = false;
            ClmNMPartName.DataPropertyName = "PumpPart.PartName";
            dataGridViewTextBoxColumn1.DataPropertyName = "PumpPart.PartDescription";
            dataGridViewTextBoxColumn2.DataPropertyName = "PumpPart.OriginalItemPartNumber";
            dataGridViewTextBoxColumn3.DataPropertyName = "PumpPart.NewPartNumber";
            dataGridViewTextBoxColumn4.DataPropertyName = "PumpPart.PartPrice";
            clmNMPartQuantity.DataPropertyName = nameof(Pump_Part.PumpPartQuantity);
            dgvNonMandatoryPartView.DataSource = nonMandatorySource;

            BindingHelpers.BindReadOnly(mtxtPumpName, ViewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPumpDescription, ViewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtNewPumpPrice, ViewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(dgvMandatoryPartView, ViewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(dgvNonMandatoryPartView, ViewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(btnAddPump, ViewModel, nameof(AddPumpViewModel.CanEdit));
            BindingHelpers.BindVisible(btnAddPump, ViewModel, nameof(AddPumpViewModel.ShowSaveButton));
            btnAddPump.DataBindings.Add("Text", ViewModel, nameof(AddPumpViewModel.SaveButtonText));
        }


        // No additional logic required - bindings handle state changes




        private void UpdatePumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ViewModel.ChangeSpecificObject)
                ViewModel.ChangeSpecificObject = true;
            updatePumpToolStripMenuItem.Enabled = false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            if (ViewModel.ExitCommand.CanExecute(null))
                ViewModel.ExitCommand.Execute(null);
        }
    }
}
