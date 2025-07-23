using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmAddPart : BaseForm
    {

        readonly AddPartViewModel viewModel;
        public AddPartViewModel ViewModel => viewModel;
        readonly INavigationService navigation;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;

        public FrmAddPart(AddPartViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            viewModel.Initialize();
            SetupBindings();
            BindIsBusy(viewModel);
        }

        void SetupBindings()
        {
            mtxtPartName.DataBindings.Add("Text", viewModel.CurrentPart, nameof(Part.PartName), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPartDescription.DataBindings.Add("Text", viewModel.CurrentPart, nameof(Part.PartDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtOriginalPartNumber.DataBindings.Add("Text", viewModel.CurrentPart, nameof(Part.OriginalItemPartNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtNewPartNumber.DataBindings.Add("Text", viewModel.CurrentPart, nameof(Part.NewPartNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPartPrice.DataBindings.Add("Value", viewModel.CurrentPart, nameof(Part.PartPrice), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxMandatoryPart.DataBindings.Add("Checked", viewModel.CurrentPart, nameof(Part.MandatoryPart), false, DataSourceUpdateMode.OnPropertyChanged);

            BindingHelpers.BindReadOnly(mtxtPartName, viewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPartDescription, viewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtOriginalPartNumber, viewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtNewPartNumber, viewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPartPrice, viewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(cbxMandatoryPart, viewModel, nameof(AddPartViewModel.CanEdit));
            BindingHelpers.BindVisible(btnAddPart, viewModel, nameof(AddPartViewModel.ShowSaveButton));
            btnAddPart.DataBindings.Add("Text", viewModel, nameof(AddPartViewModel.SaveButtonText));

            cbAddToPumpSelection.DataSource = viewModel.Pumps;
            cbAddToPumpSelection.DisplayMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.ValueMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.DataBindings.Add("SelectedItem", viewModel, nameof(AddPartViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);
            NudQuantity.DataBindings.Add("Value", viewModel, nameof(AddPartViewModel.Quantity), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddPart, viewModel.SavePartCommand);
            CommandBindings.Bind(loadPartBatchToolStripMenuItem, viewModel.ImportPartsCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
            CommandBindings.Bind(btnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(resetInputToolStripMenuItem, viewModel.ResetInputCommand);
            CommandBindings.Bind(updatePartToolStripMenuItem, viewModel.StartEditCommand);
        }

        private void CbAddToPumpSelection_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (!cbxMandatoryPart.Enabled) cbxMandatoryPart.Enabled = true;
        }

        private async void FrmAddPart_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)viewModel.LoadDataCommand).ExecuteAsync(null);
            if (viewModel.PartToChange == null)
            {
                viewModel.ChangeSpecificObject = true;
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */





        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }



        /*********************************************************************************/
    }
}
