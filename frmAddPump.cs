using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuoteSwift
{
    public partial class FrmAddPump : Form
    {
        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmAddPump(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work correctly.

            if (ValidInput())
            {
                BindingList<Pump_Part> NewPumpParts = RetreivePumpPartList();

                if (NewPumpParts == null)
                {
                    MainProgramCode.ShowError("There wasn't any parts chosen from any of the lists below\nPlease ensure that parts are selected and/or that there is parts available to select from.", "ERROR - No Pump Part Selection");
                    return;
                }

                if (passed.ChangeSpecificObject) // Update Part List if true
                {
                    RecordNewInformation();
                    MainProgramCode.ShowInformation(passed.PumpToChange.PumpName + " has been updated in the list of pumps", "INFORMATION - Pump Update Successfully");

                    //Set ChangeSpecificObject to false and convert to View

                    passed.ChangeSpecificObject = false;
                    ConvertToViewForm();

                    //Enable menu strip item that converts form to Update a pump 
                    updatePumpToolStripMenuItem.Enabled = true;
                }
                else //Create New Pump And Add To Pump List
                {
                    Pump newPump = new Pump(mtxtPumpName.Text, mtxtPumpDescription.Text, QuoteSwiftMainCode.ParseDecimal(mtxtNewPumpPrice.Text), ref NewPumpParts);
                    if (passed.PassPumpList == null) passed.PassPumpList = new BindingList<Pump> { newPump }; else passed.PassPumpList.Add(newPump);
                    MainProgramCode.ShowInformation(newPump.PumpName + " has been added to the list of pumps", "INFORMATION - Pump Added Successfully");
                }
            }

        }

        private void MtxtPumpName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtPumpDescription_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtNewPumpPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvNonMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void FrmAddPump_Load(object sender, EventArgs e)
        {
            LoadMandatoryParts();
            LoadNonMandatoryParts();

            if (passed != null && passed.PumpToChange != null && passed.ChangeSpecificObject == true) //Determine if Edit
            {
                ConvertToEditForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (passed != null && passed.PumpToChange != null && passed.ChangeSpecificObject == false) //Determine if View
            {
                ConvertToViewForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (passed != null && passed.PumpToChange == null && passed.ChangeSpecificObject == false) // Determine if Add New
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
            Text = "Updating " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Text = "Update Pump";
            btnAddPump.Visible = true;
            updatePumpToolStripMenuItem.Enabled = true;
        }

        //Convert Form To View:

        void ConvertToViewForm()
        {
            Text = "Viewing " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Visible = false;
            Read_OnlyMainComponents();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        //Populates the form with the passed Pump object and checks the check boxes in the data grid view where parts are being used.

        void PopulateFormWithPassedPump()
        {
            mtxtNewPumpPrice.Text = passed.PumpToChange.NewPumpPrice.ToString();
            mtxtPumpDescription.Text = passed.PumpToChange.PumpDescription;
            mtxtPumpName.Text = passed.PumpToChange.PumpName;

            int mIndex = 0;
            foreach (var part in passed.PassMandatoryPartList.Values)
            {
                foreach (var pumpPart in passed.PumpToChange.PartList)
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
            foreach (var part in passed.PassNonMandatoryPartList.Values)
            {
                foreach (var pumpPart in passed.PumpToChange.PartList)
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

        bool ValidInput()
        {
            if (mtxtPumpName.TextLength < 3)
            {
                MainProgramCode.ShowInformation("Please ensure the input for the Pump Name is correct and longer than 3 characters.", "INFORMATION -Pump Name Input Incorrect");
                mtxtPumpName.Focus();
                return false;
            }

            if (mtxtPumpDescription.TextLength < 3)
            {
                MainProgramCode.ShowInformation("Please ensure the input for the description of the pump is correct and longer than 3 characters.", "INFORMATION - Pump Description Input Incorrect");
                mtxtPumpDescription.Focus();
                return false;
            }

            if (NewPumpValueInput() == 0)
            {
                MainProgramCode.ShowInformation("Please ensure the input for the price of the pump is correct and longer than 2 characters.", "INFORMATION - Pump Price Input Incorrect");
                mtxtNewPumpPrice.Focus();
                return false;
            }
            return true;
        }

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
                            if (passed.PassMandatoryPartList.TryGetValue(StringUtil.NormalizeKey(oKey), out var part))
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
                            if (passed.PassNonMandatoryPartList.TryGetValue(StringUtil.NormalizeKey(oKey), out var part))
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
            if (passed != null && passed.PumpToChange != null && passed.ChangeSpecificObject == false)
                if (MainProgramCode.RequestConfirmation("You are currently viewing " + passed.PumpToChange.PumpName + " pump, would you like to edit it instead?", "REQUEST - View To Edit REQUEST"))
                {
                    ConvertToEditForm();
                    passed.ChangeSpecificObject = true;
                }
        }

        void RecordNewInformation()
        {
            if (mtxtPumpName.Text != passed.PumpToChange.PumpName) passed.PumpToChange.PumpName = mtxtPumpName.Text;

            if (mtxtPumpDescription.Text != passed.PumpToChange.PumpDescription) passed.PumpToChange.PumpDescription = mtxtPumpDescription.Text;

            if (NewPumpValueInput() != passed.PumpToChange.NewPumpPrice) passed.PumpToChange.NewPumpPrice = NewPumpValueInput();

            passed.PumpToChange.PartList = RetreivePumpPartList();
        }

        decimal NewPumpValueInput()
        {
            decimal.TryParse(mtxtNewPumpPrice.Text, out decimal TempNewPumpPrice);
            return TempNewPumpPrice;
        }



        void LoadMandatoryParts()
        {
            if (passed.PassMandatoryPartList != null)
            {
                dgvMandatoryPartView.Rows.Clear();

                foreach (var part in passed.PassMandatoryPartList.Values)
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
            if (passed.PassNonMandatoryPartList != null)
            {
                dgvNonMandatoryPartView.Rows.Clear();

                foreach (var part in passed.PassNonMandatoryPartList.Values)
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
            if (!passed.ChangeSpecificObject)
                ChangeViewToEdit();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmAddPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        /*********************************************************************************/


    }
}
