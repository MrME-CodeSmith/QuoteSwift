using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {

        readonly AddPartViewModel viewModel;
        public AddPartViewModel ViewModel => viewModel;
        readonly INavigationService navigation;

        readonly ApplicationData appData;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;

        public FrmAddPart(AddPartViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.serializationService = serializationService;
            this.messageService = messageService;
            viewModel.Initialize();
            SetupBindings();
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
            BindingHelpers.BindVisible(btnAddPart, viewModel, nameof(AddPartViewModel.CanEdit));

            cbAddToPumpSelection.DataSource = viewModel.Pumps;
            cbAddToPumpSelection.DisplayMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.ValueMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.DataBindings.Add("SelectedItem", viewModel, nameof(AddPartViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);
            NudQuantity.DataBindings.Add("Value", viewModel, nameof(AddPartViewModel.Quantity), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddPart, viewModel.SavePartCommand);
            CommandBindings.Bind(loadPartBatchToolStripMenuItem, viewModel.ImportPartsCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
        }

        private void FrmAddPart_Activated(object sender, EventArgs e)
        {

        }


        private void CbAddToPumpSelection_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (!cbxMandatoryPart.Enabled) cbxMandatoryPart.Enabled = true;
        }

        private void ResetInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to reset the current screen to it's default values?", "REQUEST - Screen Defaults Reset"))
            {
                viewModel.ResetInput();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void FrmAddPart_Load(object sender, EventArgs e)
        {
            if (viewModel.ChangeSpecificObject && viewModel.PartToChange != null)
            {
                viewModel.ChangeSpecificObject = true;
                btnAddPart.Text = "Update";
                updatePartToolStripMenuItem.Enabled = false;
            }
            else if (!viewModel.ChangeSpecificObject && viewModel.PartToChange != null)
            {
                viewModel.ChangeSpecificObject = false;
                btnAddPart.Visible = false;
                updatePartToolStripMenuItem.Enabled = true;
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */




        private void UpdatePartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                if (messageService.RequestConfirmation("You are currently only viewing " + viewModel.PartToChange.PartName + " part, would you like to update it's details instead?", "REQUEST - Update Specific Part Details"))
                {
                    viewModel.ChangeSpecificObject = true;
                    updatePartToolStripMenuItem.Enabled = false;
                }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }



        /*********************************************************************************/
    }
}
