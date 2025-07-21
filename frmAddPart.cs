using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {

        readonly AddPartViewModel viewModel;
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

            cbAddToPumpSelection.DataSource = viewModel.Pumps;
            cbAddToPumpSelection.DisplayMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.ValueMember = nameof(Pump.PumpName);
            cbAddToPumpSelection.DataBindings.Add("SelectedItem", viewModel, nameof(AddPartViewModel.SelectedPump), false, DataSourceUpdateMode.OnPropertyChanged);
            NudQuantity.DataBindings.Add("Value", viewModel, nameof(AddPartViewModel.Quantity), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(btnAddPart, viewModel.SavePartCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }


        private void FrmAddPart_Activated(object sender, EventArgs e)
        {

        }

        private void LoadPartBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please ensure that the selected CSV file has the following items in this exact order:\n\n" +
                             "First Column: Original Part Number\n" +
                             "Second Column: Part Name\n" +
                             "Third Column: Part Description\n" +
                             "Fourth Column: New Part Number\n" +
                             "Fifth Column: Part Price\n" +
                             "Sixth Column: Part Quantity (To add this amount of parts to the pump specified) \n" +
                             "Seventh Column: TRUE / FALSE value (Mandatory part)\n" +
                             "Eighth Column: Pump Name(To add a part to a specific pump)\n" +
                             "Ninth Column: Pump Price (Price when pump is bought new)\n" +
                             "Click the OK button to select the file or alternative choose cancel to abort this action.";

            DialogResult result = MessageBox.Show(message, "INFORMATION - CSV Batch Part Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                OfdOpenCSVFile.ShowDialog();
                bool updateDup = messageService.RequestConfirmation("In the case that a duplicate part is being added would you like to update the parts that has already been added before?", "REQUEST - Update Duplicate Part");
                try
                {
                    viewModel.ImportPartsFromCsv(OfdOpenCSVFile.FileName, updateDup);
                    messageService.ShowInformation("The selected CSV file has been successfully imported.", "CONFIRMATION - Batch Part Import Successful");
                }
                catch
                {
                    messageService.ShowError("The provided CSV File's format is incorrect, please try again once the format has been corrected.", "ERROR - CSV File Format Incorrect");
                }
            }
            else return;
            Close();
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
                ApplyControlState();
                btnAddPart.Text = "Update";
                updatePartToolStripMenuItem.Enabled = false;
            }
            else if (!viewModel.ChangeSpecificObject && viewModel.PartToChange != null)
            {
                viewModel.ChangeSpecificObject = false;
                btnAddPart.Visible = false;
                ApplyControlState();
                updatePartToolStripMenuItem.Enabled = true;
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */



        void ApplyControlState()
        {
            bool ro = viewModel.IsReadOnly;
            mtxtNewPartNumber.ReadOnly = ro;
            mtxtOriginalPartNumber.ReadOnly = ro;
            mtxtPartDescription.ReadOnly = ro;
            mtxtPartName.ReadOnly = ro;
            mtxtPartPrice.ReadOnly = ro;
            cbAddToPumpSelection.Enabled = false;
            NudQuantity.Enabled = false;
            cbxMandatoryPart.Enabled = !ro;
            btnAddPart.Visible = !ro;
            if (!ro)
                btnAddPart.Text = "Update Part";
        }

        private void UpdatePartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                if (messageService.RequestConfirmation("You are currently only viewing " + viewModel.PartToChange.PartName + " part, would you like to update it's details instead?", "REQUEST - Update Specific Part Details"))
                {
                    viewModel.ChangeSpecificObject = true;
                    ApplyControlState();
                    updatePartToolStripMenuItem.Enabled = false;
                }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
                appData?.QuoteMap);
        }


        /*********************************************************************************/
    }
}
