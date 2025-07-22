using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace QuoteSwift
{
    public partial class FrmAddPump : BaseForm
    {
        readonly AddPumpViewModel viewModel;
        public AddPumpViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        readonly BindingSource mandatorySource = new BindingSource();
        readonly BindingSource nonMandatorySource = new BindingSource();

        public FrmAddPump(AddPumpViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.serializationService = serializationService;
            this.messageService = messageService;
            viewModel.CurrentPump = viewModel.PumpToChange ?? new Pump();
            mtxtPumpName.DataBindings.Add("Text", viewModel.CurrentPump, nameof(Pump.PumpName), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPumpDescription.DataBindings.Add("Text", viewModel.CurrentPump, nameof(Pump.PumpDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtNewPumpPrice.DataBindings.Add("Text", viewModel.CurrentPump, nameof(Pump.NewPumpPrice), true, DataSourceUpdateMode.OnPropertyChanged);
            mandatorySource.DataSource = viewModel.SelectedMandatoryParts;
            nonMandatorySource.DataSource = viewModel.SelectedNonMandatoryParts;
            CommandBindings.Bind(btnAddPump, viewModel.SavePumpCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
            if (data != null)
                viewModel.UpdateData(data.PumpList, data.PartList, viewModel.PumpToChange, viewModel.ChangeSpecificObject,
                                     data.PumpList != null ? new HashSet<string>(data.PumpList.Select(p => StringUtil.NormalizeKey(p.PumpName))) : null);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }


        private void MtxtPumpName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
        }

        private void MtxtPumpDescription_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
        }

        private void MtxtNewPumpPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
        }

        private void DgvMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
        }

        private void DgvNonMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
        }

        private void FrmAddPump_Load(object sender, EventArgs e)
        {
            SetupBindings();

            if (viewModel.PumpToChange == null)
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

            BindingHelpers.BindReadOnly(mtxtPumpName, viewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPumpDescription, viewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtNewPumpPrice, viewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(dgvMandatoryPartView, viewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(dgvNonMandatoryPartView, viewModel, nameof(AddPumpViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(btnAddPump, viewModel, nameof(AddPumpViewModel.CanEdit));
            BindingHelpers.BindVisible(btnAddPump, viewModel, nameof(AddPumpViewModel.ShowSaveButton));
            btnAddPump.DataBindings.Add("Text", viewModel, nameof(AddPumpViewModel.SaveButtonText));
        }


        // No additional logic required - bindings handle state changes




        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void UpdatePumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                viewModel.ChangeSpecificObject = true;
            updatePumpToolStripMenuItem.Enabled = false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }
    }
}
