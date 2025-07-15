using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace QuoteSwift
{
    public partial class FrmAddPump : Form
    {
        readonly AddPumpViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;

        public FrmAddPump(AddPumpViewModel viewModel, INavigationService navigation = null, ApplicationData data = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            if (data != null)
                viewModel.UpdateData(data.PumpList, data.PartList, viewModel.PumpToChange, viewModel.ChangeSpecificObject,
                                     data.PumpList != null ? new HashSet<string>(data.PumpList.Select(p => StringUtil.NormalizeKey(p.PumpName))) : null);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            if (!viewModel.ValidateInput())
                return;

            BindingList<Pump_Part> newPumpParts = RetreivePumpPartList();

            if (newPumpParts == null)
            {
                MainProgramCode.ShowError("There wasn't any parts chosen from any of the lists below\nPlease ensure that parts are selected and/or that there is parts available to select from.", "ERROR - No Pump Part Selection");
                return;
            }

            viewModel.CurrentPump = new Pump(mtxtPumpName.Text, mtxtPumpDescription.Text, QuoteSwiftMainCode.ParseDecimal(mtxtNewPumpPrice.Text), ref newPumpParts);

            bool result;
            if (viewModel.ChangeSpecificObject)
            {
                result = viewModel.UpdatePump();
                if (result)
                {
                    MainProgramCode.ShowInformation(viewModel.PumpToChange.PumpName + " has been updated in the list of pumps", "INFORMATION - Pump Update Successfully");
                    viewModel.ChangeSpecificObject = false;
                    ConvertToViewForm();
                    updatePumpToolStripMenuItem.Enabled = true;
                }
                else
                {
                    MainProgramCode.ShowError("This item name is already in use.", "ERROR - Duplicate Item Name");
                }
            }
            else
            {
                result = viewModel.AddPump();
                if (result)
                {
                    MainProgramCode.ShowInformation(viewModel.CurrentPump.PumpName + " has been added to the list of pumps", "INFORMATION - Pump Added Successfully");
                }
                else
                {
                    MainProgramCode.ShowError("This item name is already in use.", "ERROR - Duplicate Item Name");
                }
            }
        }


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
            LoadMandatoryParts();
            LoadNonMandatoryParts();

            if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == true) //Determine if Edit
            {
                ConvertToEditForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == false) //Determine if View
            {
                ConvertToViewForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (viewModel.PumpToChange == null && viewModel.ChangeSpecificObject == false) // Determine if Add New
            {
                mtxtPumpName.Focus();
            }
            else //This should never happen. Error message displayed and application will not allow input
            {
                MainProgramCode.ShowError("An error occurred that was not suppose to ever happen.\nAll input will now be disabled for this current screen", "ERROR - Undefined Action Called");

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

        //Populates the form with the passed Pump object and checks the check boxes in the data grid view where parts are being used.

        void PopulateFormWithPassedPump()
        {
            mtxtNewPumpPrice.Text = viewModel.PumpToChange.NewPumpPrice.ToString();
            mtxtPumpDescription.Text = viewModel.PumpToChange.PumpDescription;
            mtxtPumpName.Text = viewModel.PumpToChange.PumpName;

            int mIndex = 0;
            foreach (var part in viewModel.PartMap?.Values?.Where(p => p.MandatoryPart) ?? Enumerable.Empty<Part>())
            {
                foreach (var pumpPart in viewModel.PumpToChange.PartList)
                {
                    if (part.OriginalItemPartNumber == pumpPart.PumpPart.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvMandatoryPartView.Rows[mIndex].Cells["clmAddToPumpSelection"];
                        cbx.Value = true;
                        dgvMandatoryPartView.Rows[mIndex].Cells["clmMPartQuantity"].Value = pumpPart.PumpPartQuantity.ToString();
                    }
                }
                mIndex++;
            }

            int nmIndex = 0;
            foreach (var part in viewModel.PartMap?.Values?.Where(p => !p.MandatoryPart) ?? Enumerable.Empty<Part>())
            {
                foreach (var pumpPart in viewModel.PumpToChange.PartList)
                {
                    if (part.OriginalItemPartNumber == pumpPart.PumpPart.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvNonMandatoryPartView.Rows[nmIndex].Cells["ClmNonMandatoryPartSelection"];
                        cbx.Value = true;
                        dgvNonMandatoryPartView.Rows[nmIndex].Cells["clmNMPartQuantity"].Value = pumpPart.PumpPartQuantity.ToString();
                    }
                }
                nmIndex++;
            }
        }


        //Links the binding-lists with the corresponding datagridview components

        BindingList<Pump_Part> RetreivePumpPartList()
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work correctly.

            BindingList<Pump_Part> ReturnList = null;
            Pump_Part newPart;
            //Mandatory added first
            int mPartIndex = 0;
            foreach (DataGridViewRow row in dgvMandatoryPartView.Rows)
                try
                {
                    if ((bool)(row.Cells["clmAddToPumpSelection"].Value) == true)
                    {
                        try
                        {
                            string oKey = row.Cells["clmOriginalPartNumber"].Value?.ToString();
                            if (viewModel.PartMap != null && viewModel.PartMap.TryGetValue(StringUtil.NormalizeKey(oKey), out var part))
                                newPart = new Pump_Part(part,
                                    QuoteSwiftMainCode.ParseInt(row.Cells["clmMPartQuantity"].Value.ToString()));
                            else
                                newPart = null;
                        }
                        catch
                        {
                            newPart = null;
                        }

                        if (newPart != null)
                            if (ReturnList == null)
                                ReturnList = new BindingList<Pump_Part> { newPart };
                            else ReturnList.Add(newPart);
                    }
                    mPartIndex++;
                }
                catch
                {
                    //Do Nothing
                }


            //Non-Mandatory added second
            int nmPartIndex = 0;
            foreach (DataGridViewRow row in dgvNonMandatoryPartView.Rows)
                try
                {
                    if ((bool)(row.Cells["ClmNonMandatoryPartSelection"].Value) == true)
                    {
                        try
                        {
                            string oKey = row.Cells["clmOriginalPartNumber"].Value?.ToString();
                            if (viewModel.PartMap != null && viewModel.PartMap.TryGetValue(StringUtil.NormalizeKey(oKey), out var part))
                                newPart = new Pump_Part(part,
                                    QuoteSwiftMainCode.ParseInt(row.Cells["clmNMPartQuantity"].Value.ToString()));
                            else
                                newPart = null;
                        }
                        catch
                        {
                            newPart = null;
                        }

                        if (newPart != null)
                            if (ReturnList == null)
                                ReturnList = new BindingList<Pump_Part> { newPart };
                            else ReturnList.Add(newPart);
                    }
                    nmPartIndex++;
                }
                catch
                {
                    //Do Nothing
                }

            return ReturnList;
        }

        void ChangeViewToEdit()
        {
            if (viewModel.PumpToChange != null && viewModel.ChangeSpecificObject == false)
                if (MainProgramCode.RequestConfirmation("You are currently viewing " + viewModel.PumpToChange.PumpName + " pump, would you like to edit it instead?", "REQUEST - View To Edit REQUEST"))
                {
                    ConvertToEditForm();
                    viewModel.ChangeSpecificObject = true;
                }
        }

        void RecordNewInformation()
        {
            if (mtxtPumpName.Text != viewModel.PumpToChange.PumpName) viewModel.PumpToChange.PumpName = mtxtPumpName.Text;

            if (mtxtPumpDescription.Text != viewModel.PumpToChange.PumpDescription) viewModel.PumpToChange.PumpDescription = mtxtPumpDescription.Text;

            if (NewPumpValueInput() != viewModel.PumpToChange.NewPumpPrice) viewModel.PumpToChange.NewPumpPrice = NewPumpValueInput();

            viewModel.PumpToChange.PartList = RetreivePumpPartList();
        }

        decimal NewPumpValueInput()
        {
            decimal.TryParse(mtxtNewPumpPrice.Text, out decimal TempNewPumpPrice);
            return TempNewPumpPrice;
        }



        void LoadMandatoryParts()
        {
            if (viewModel.PartMap != null)
            {
                dgvMandatoryPartView.Rows.Clear();

                foreach (var part in viewModel.PartMap.Values.Where(p => p.MandatoryPart))
                {
                    //Manually setting the data grid's rows' values:
                    dgvMandatoryPartView.Rows.Add(part.PartName,
                                                   part.PartDescription,
                                                   part.OriginalItemPartNumber,
                                                   part.NewPartNumber,
                                                   part.PartPrice,
                                                   false,
                                                   0);
                }
            }
        }

        void LoadNonMandatoryParts()
        {
            if (viewModel.PartMap != null)
            {
                dgvNonMandatoryPartView.Rows.Clear();

                foreach (var part in viewModel.PartMap.Values.Where(p => !p.MandatoryPart))
                {
                    //Manually setting the data grid's rows' values:
                    dgvNonMandatoryPartView.Rows.Add(part.PartName,
                                                       part.PartDescription,
                                                       part.OriginalItemPartNumber,
                                                       part.NewPartNumber,
                                                       part.PartPrice,
                                                       false,
                                                       0);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
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

        private void FrmAddPump_FormClosing(object sender, FormClosingEventArgs e)
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
