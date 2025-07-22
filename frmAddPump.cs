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
            if (data != null)
                viewModel.UpdateData(data.PumpList, data.PartList, viewModel.PumpToChange, viewModel.ChangeSpecificObject,
                                     data.PumpList != null ? new HashSet<string>(data.PumpList.Select(p => StringUtil.NormalizeKey(p.PumpName))) : null);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);



        private void MtxtPumpName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtPumpDescription_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtNewPumpPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvNonMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void FrmAddPump_Load(object sender, EventArgs e)
        {
            SetupBindings();

            if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == true) //Determine if Edit
            {
                ConvertToEditForm();
                Read_OnlyMainComponents();
            }
            else if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == false) //Determine if View
            {
                ConvertToViewForm();
                Read_OnlyMainComponents();
            }
            else if (viewModel.PumpToChange == null && viewModel.ChangeSpecificObject == false) // Determine if Add New
            {
                mtxtPumpName.Focus();
            }
            else //This should never happen. Error message displayed and application will not allow input
            {
                messageService.ShowError("An error occurred that was not suppose to ever happen.\nAll input will now be disabled for this current screen", "ERROR - Undefined Action Called");

                Read_OnlyMainComponents();
            }

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

        //Disable Main Components On This Form:

        void Read_OnlyMainComponents()
        {
            dgvMandatoryPartView.ReadOnly = true;
            dgvNonMandatoryPartView.ReadOnly = true;
            mtxtNewPumpPrice.ReadOnly = true;
            mtxtPumpDescription.ReadOnly = true;
            mtxtPumpName.ReadOnly = true;
            btnAddPump.Enabled = false;
        }

        //Enable Main Components On This Form:

        void ReadWriteMainComponents()
        {
            dgvMandatoryPartView.ReadOnly = false;
            dgvNonMandatoryPartView.ReadOnly = false;
            mtxtNewPumpPrice.ReadOnly = false;
            mtxtPumpDescription.ReadOnly = false;
            mtxtPumpName.ReadOnly = false;
            btnAddPump.Enabled = true;
        }

        //Convert Form To Edit:

        void ConvertToEditForm()
        {
            ReadWriteMainComponents();
            Text = "Updating " + viewModel.PumpToChange.PumpName + " Pump";
            btnAddPump.Text = "Update Pump";
            btnAddPump.Visible = true;
            updatePumpToolStripMenuItem.Enabled = true;
        }

        //Convert Form To View:

        void ConvertToViewForm()
        {
            Text = "Viewing " + viewModel.PumpToChange.PumpName + " Pump";
            btnAddPump.Visible = false;
            Read_OnlyMainComponents();
            updatePumpToolStripMenuItem.Enabled = false;
        }

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
        }


        void ChangeViewToEdit()
        {
            if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == false)
                if (messageService.RequestConfirmation("You are currently viewing " + viewModel.PumpToChange.PumpName + " pump, would you like to edit it instead?", "REQUEST - View To Edit REQUEST"))
                {
                    ConvertToEditForm();
                    viewModel.ChangeSpecificObject = true;
                }
        }

        decimal NewPumpValueInput()
        {
            decimal.TryParse(mtxtNewPumpPrice.Text, out decimal TempNewPumpPrice);
            return TempNewPumpPrice;
        }




        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void UpdatePumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
                ChangeViewToEdit();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        protected override void OnClose()
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }
    }
}
