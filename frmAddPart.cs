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
        readonly IMessageService messageService;

        public FrmAddPart(AddPartViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
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
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {

            if (!viewModel.ValidateInput())
                return;

            bool updating = viewModel.ChangeSpecificObject;

            viewModel.SavePartCommand.Execute(null);
            if (!viewModel.LastOperationSuccessful)
            {
                messageService.ShowInformation("The provided new part information already has a part which has the same New Part Number or Original Part Number.\nPlease ensure that the provided Part Numbers' are distinct.", "INFORMATION - Part Already Listed");
                return;
            }

            if (updating)
            {
                messageService.ShowInformation("Successfully updated the part", "CONFIRMATION - Update Successful");
                viewModel.ChangeSpecificObject = false;
                Close();
            }
            else
            {
                string info = viewModel.CurrentPart.MandatoryPart ?
                    " successfully added to the mandatory part list." :
                    " successfully added to the non-mandatory part list.";
                messageService.ShowInformation(viewModel.CurrentPart.PartName + info, "INFORMATION - Part Added Success");
                if (viewModel.SelectedPump != null)
                {
                    messageService.ShowInformation(viewModel.CurrentPart.PartName + " successfully added to " + viewModel.SelectedPump.PumpName + " pump the part list.", "INFORMATION - Part Added  To Pump Success");
                }
                ClearInput();
            }
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
                ClearInput();
                NudQuantity.Enabled = false;
                cbxMandatoryPart.Checked = false;
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


        private void ClearInput()
        {
            mtxtNewPartNumber.ResetText();
            mtxtOriginalPartNumber.ResetText();
            mtxtPartDescription.ResetText();
            mtxtPartName.ResetText();
            mtxtPartPrice.ResetText();
            cbxMandatoryPart.Checked = false;
            NudQuantity.ResetText();
        }

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

        private void FrmAddPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }


        /*********************************************************************************/
    }
}
