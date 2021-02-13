using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"),ref this.passed) ;
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work corectly.

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
                    Pump newPump = new Pump(mtxtPumpName.Text, mtxtPumpDescription.Text, (float)Convert.ToDouble(mtxtNewPumpPrice.Text), ref NewPumpParts); // Cast used since Convert.To does not support float
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
            if(!passed.ChangeSpecificObject)
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
                MainProgramCode.ShowError("An error occured that was not suppose to ever happen.\nAll input will now be disabled for this current screen", "ERROR - Undefined Action Called");

                Read_OnlyMainComponents();
            }
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
            this.Text = "Updating " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Text = "Update Pump";
            btnAddPump.Visible = true;
        }

        //Convert Form To View:

        void ConvertToViewForm()
        {
            this.Text = "Viewing " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Visible = false;
            Read_OnlyMainComponents();
        }

        //Populates the form with the passed Pump object and checkes the check boxes in the data grid view where parts are being used.

        void PopulateFormWithPassedPump()
        {
            mtxtNewPumpPrice.Text = passed.PumpToChange.NewPumpPrice.ToString();
            mtxtPumpDescription.Text = passed.PumpToChange.PumpDescription;
            mtxtPumpName.Text = passed.PumpToChange.PumpName;

            for (int i = 0; i < passed.PassMandatoryPartList.Count; i++)
                for (int k = 0; k < passed.PumpToChange.PartList.Count; k++)
                {
                    if (passed.PassMandatoryPartList[i].OriginalItemPartNumber == passed.PumpToChange.PartList[k].PumpPart.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvMandatoryPartView.Rows[i].Cells["clmAddToPumpSelection"];
                        cbx.Value = true;
                        dgvMandatoryPartView.Rows[i].Cells["clmMPartQuantity"].Value = passed.PumpToChange.PartList[k].PumpPartQuantity.ToString();
                    }
                }

            for (int s = 0; s < passed.PassNonMandatoryPartList.Count; s++)
                for (int d = 0; d < passed.PumpToChange.PartList.Count; d++)
                {
                    if (passed.PassNonMandatoryPartList[s].OriginalItemPartNumber == passed.PumpToChange.PartList[d].PumpPart.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvNonMandatoryPartView.Rows[s].Cells["ClmNonMandatoryPartSelection"];
                        cbx.Value = true;
                        dgvNonMandatoryPartView.Rows[s].Cells["clmNMPartQuantity"].Value = passed.PumpToChange.PartList[d].PumpPartQuantity.ToString();
                    }
                }
        }

        //Links the bindinglists with the corresponding datagridview components

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
            //This is for the for loop when the form gets activated to work corectly.

            BindingList<Pump_Part> ReturnList = null;
            Pump_Part newPart;
            //Mandatory added first
            for (int i = 0; i < dgvMandatoryPartView.Rows.Count; i++)
                try
                {
                    if ((Boolean)(dgvMandatoryPartView.Rows[i].Cells["clmAddToPumpSelection"].Value) == true)
                    {
                        try
                        {
                            newPart = new Pump_Part(passed.PassMandatoryPartList[i], MainProgramCode.ParseInt(dgvMandatoryPartView.Rows[i].Cells["clmMPartQuantity"].Value.ToString())); // Cast used rather than convert; not much but to a degree faster
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
                }
                catch
                {
                    //Do Nothing
                }


            //Non-Mandatory added second
            for (int k = 0; k < dgvNonMandatoryPartView.Rows.Count; k++)
                try
                {
                    if ((Boolean)(dgvNonMandatoryPartView.Rows[k].Cells["ClmNonMandatoryPartSelection"].Value) == true)
                    {
                        try
                        {
                            newPart = new Pump_Part(passed.PassNonMandatoryPartList[k], MainProgramCode.ParseInt(dgvNonMandatoryPartView.Rows[k].Cells["clmNMPartQuantity"].Value.ToString())); // Cast used rather than convert; not much but to a degree faster
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
                if (MainProgramCode.RequestConfirmation("You are curently viewing " + passed.PumpToChange.PumpName + " pump, would you like to edit it instead?", "REQUEST - View To Edit REQUEST"))
                {
                    ConvertToEditForm();
                    passed.ChangeSpecificObject = true;
                }
        }

        void RecordNewInformation()
        {
            if(mtxtPumpName.Text != passed.PumpToChange.PumpName) passed.PumpToChange.PumpName = mtxtPumpName.Text;

            if (mtxtPumpDescription.Text != passed.PumpToChange.PumpDescription) passed.PumpToChange.PumpDescription = mtxtPumpDescription.Text;

            if (NewPumpValueInput() != passed.PumpToChange.NewPumpPrice) passed.PumpToChange.NewPumpPrice = NewPumpValueInput();

            passed.PumpToChange.PartList = RetreivePumpPartList();
        }

        float NewPumpValueInput()
        {
            float.TryParse(mtxtNewPumpPrice.Text, out float TempNewPumpPrice);
            return TempNewPumpPrice;
        }

        

        void LoadMandatoryParts()
        {
            if (passed.PassMandatoryPartList != null)
            {
                dgvMandatoryPartView.Rows.Clear();

                for (int i = 0; i < passed.PassMandatoryPartList.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvMandatoryPartView.Rows.Add(passed.PassMandatoryPartList[i].PartName, passed.PassMandatoryPartList[i].PartDescription, passed.PassMandatoryPartList[i].OriginalItemPartNumber, passed.PassMandatoryPartList[i].NewPartNumber, passed.PassMandatoryPartList[i].PartPrice, false,0);
                }
            }
        }

        void LoadNonMandatoryParts()
        {
            if (passed.PassNonMandatoryPartList != null)
            {
                dgvNonMandatoryPartView.Rows.Clear();

                for (int k = 0; k < passed.PassNonMandatoryPartList.Count; k++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvNonMandatoryPartView.Rows.Add(passed.PassNonMandatoryPartList[k].PartName, passed.PassNonMandatoryPartList[k].PartDescription, passed.PassNonMandatoryPartList[k].OriginalItemPartNumber, passed.PassNonMandatoryPartList[k].NewPartNumber, passed.PassNonMandatoryPartList[k].PartPrice, false,0);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
           if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancelation")) this.Close();
        }

        private void UpdatePumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!passed.ChangeSpecificObject)
            ChangeViewToEdit();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        /*********************************************************************************/


    }
}
