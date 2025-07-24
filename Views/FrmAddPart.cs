using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmAddPart : BaseForm<AddPartViewModel>
    {

        readonly INavigationService navigation;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        readonly Button btnCancelOperation;

        public FrmAddPart(AddPartViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            ViewModel.Initialize();
            SetupBindings();
            BindIsBusy(ViewModel);

            btnCancelOperation = new Button
            {
                Text = "Cancel Operation",
                Size = new Size(130, 32),
                Location = new Point(btnAddPart.Right + 10, btnAddPart.Top)
            };
            btnCancelOperation.Click += BtnCancelOperation_Click;
            Controls.Add(btnCancelOperation);
        }

        void SetupBindings()
        {
            mtxtPartName.DataBindings.Add("Text", ViewModel.CurrentPart, nameof(Part.PartName), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPartDescription.DataBindings.Add("Text", ViewModel.CurrentPart, nameof(Part.PartDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtOriginalPartNumber.DataBindings.Add("Text", ViewModel.CurrentPart, nameof(Part.OriginalItemPartNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtNewPartNumber.DataBindings.Add("Text", ViewModel.CurrentPart, nameof(Part.NewPartNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPartPrice.DataBindings.Add("Value", ViewModel.CurrentPart, nameof(Part.PartPrice), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxMandatoryPart.DataBindings.Add("Checked", ViewModel.CurrentPart, nameof(Part.MandatoryPart), false, DataSourceUpdateMode.OnPropertyChanged);

            BindingHelpers.BindReadOnly(mtxtPartName, ViewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPartDescription, ViewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtOriginalPartNumber, ViewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtNewPartNumber, ViewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindReadOnly(mtxtPartPrice, ViewModel, nameof(AddPartViewModel.IsReadOnly));
            BindingHelpers.BindEnabled(cbxMandatoryPart, ViewModel, nameof(AddPartViewModel.CanEdit));
            BindingHelpers.BindVisible(btnAddPart, ViewModel, nameof(AddPartViewModel.ShowSaveButton));
            btnAddPart.DataBindings.Add("Text", ViewModel, nameof(AddPartViewModel.SaveButtonText));

            cbAddToPumpSelection.DataSource = ViewModel.Pumps;
            cbAddToPumpSelection.DisplayMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.ValueMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.DataBindings.Add("SelectedItem", ViewModel, nameof(AddPartViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);
            NudQuantity.DataBindings.Add("Value", ViewModel, nameof(AddPartViewModel.Quantity), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddPart, ViewModel.SavePartCommand);
            CommandBindings.Bind(loadPartBatchToolStripMenuItem, ViewModel.ImportPartsCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            CommandBindings.Bind(btnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(resetInputToolStripMenuItem, ViewModel.ResetInputCommand);
            CommandBindings.Bind(updatePartToolStripMenuItem, ViewModel.StartEditCommand);
        }

        private void BtnCancelOperation_Click(object sender, EventArgs e)
        {
            ((AsyncRelayCommand)ViewModel.ImportPartsCommand).Cancel();
        }

        private void CbAddToPumpSelection_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (!cbxMandatoryPart.Enabled) cbxMandatoryPart.Enabled = true;
        }

        private async void FrmAddPart_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            if (ViewModel.PartToChange == null)
            {
                ViewModel.ChangeSpecificObject = true;
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
