﻿using System;
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
    public partial class frmAddPump : Form
    {

        readonly MainProgramCode MPC = new MainProgramCode(); //Creating an instance of the class MainProgramCode containing specialised methods

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public frmAddPump(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }
  
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPC.CloseApplication(MPC.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "CONFIRMATION - Application Termination"));
        }

        private void btnAddPump_Click(object sender, EventArgs e)
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work corectly.
            
            if (ValidInput())
            {
                BindingList<Pump_Part> NewPumpParts = RetreivePumpPartList();

                if (passed.ChangeSpecificObject)
                {

                }
                else //Create New Pump And Add To Pump List
                {

                    Pump newPump = new Pump(mtxtNewPumpPrice.Text, mtxtPumpDescription.Text, (float)Convert.ToDouble(mtxtNewPumpPrice.Text), ref NewPumpParts); // Cast used since Convert.To does not support float
                    passed.PassPumpList.Add(newPump);
                    MPC.ShowInformation(newPump.PumpName + " has been added to the list of pumps", "INFORMATION - Pump Added Successfully");
                
                }
            }
        }

        private void frmAddPump_Activated(object sender, EventArgs e)
        {
            if(passed != null && passed.PumpToChange != null && passed.ChangeSpecificObject == true) //Determine if Edit
            {
                ConvertToEditForm();
                DisableMainComponents();
                PopulateFormWithPassedPump();
            }
            else if(passed != null && passed.PumpToChange != null && passed.ChangeSpecificObject == false) //Determine if View
            {
                ConvertToViewForm();
                DisableMainComponents();
                PopulateFormWithPassedPump();
            }
            else if(passed != null && passed.PumpToChange == null && passed.ChangeSpecificObject == false) // Determine if Add New
            {
                LinkDataSources();
                mtxtPumpName.Focus();
            }
            else //This should never happen. Error message displayed and application will not allow input
            {
                MPC.ShowError("An error occured that was not suppose to ever happen.\nAll input will now be disabled for this current screen","ERROR - Undefined Action Called");

                DisableMainComponents();
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */
        
        //Disable Main Components On This Form:

        void DisableMainComponents()
        {
            dgvMandatoryPartView.Enabled = false;
            dgvNonMandatoryPartView.Enabled = false;
            mtxtNewPumpPrice.Enabled = false;
            mtxtPumpDescription.Enabled = false;
            mtxtPumpName.Enabled = false;
            btnAddPump.Enabled = false;
        }                                                                                                               

        //Enable Main Components On This Form:

        void EnableMainComponents()
        {
            dgvMandatoryPartView.Enabled = true;
            dgvNonMandatoryPartView.Enabled = true;
            mtxtNewPumpPrice.Enabled = true;
            mtxtPumpDescription.Enabled = true;
            mtxtPumpName.Enabled = true;
            btnAddPump.Enabled = true;
        }                                                                                                                                           

        //Convert Form To Edit:

        void ConvertToEditForm()
        {
            this.Text = "Editing " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Text = "Edit Pump";
            btnAddPump.Visible = true;
        }

        //Convert Form To View:

        void ConvertToViewForm()
        {
            this.Text = "Viewing " + passed.PumpToChange.PumpName + " Pump";
            btnAddPump.Visible = false;
        }

        //Populates the form with the passed Pump object and checkes the check boxes in the data grid view where parts are being used.

        void PopulateFormWithPassedPump()
        {
            mtxtNewPumpPrice.Text = passed.PumpToChange.NewPumpPrice.ToString();
            mtxtPumpDescription.Text = passed.PumpToChange.PumpDescription;
            mtxtPumpName.Text = passed.PumpToChange.PumpName;

            LinkDataSources();

            for (int i = 0; i < passed.PassMandatoryPartList.Count; i++)
                for (int k = 0; k < passed.PassMandatoryPartList.Count; k++)
                {
                    if (passed.PassMandatoryPartList[i].OriginalItemPartNumber == passed.PumpToChange.PartList[k].PumpPart.OriginalItemPartNumber)
                    {
                        dgvMandatoryPartView.Rows[i].Cells[4].Value = true;
                    }
                }

            for (int s = 0; s < passed.PumpToChange.PartList.Count; s++)
                for (int d = 0; d < passed.PumpToChange.PartList.Count; d++)
                {
                    if (passed.PassNonMandatoryPartList[s].OriginalItemPartNumber == passed.PumpToChange.PartList[d].PumpPart.OriginalItemPartNumber)
                    {
                        dgvNonMandatoryPartView.Rows[s].Cells[4].Value = true;
                    }
                }
        }

        //Links the bindinglists with the corresponding datagridview components

        void LinkDataSources()
        {
            dgvMandatoryPartView.DataSource = passed.PassMandatoryPartList;
            dgvNonMandatoryPartView.DataSource = passed.PassNonMandatoryPartList;
        }

        bool ValidInput()
        {
            if (mtxtPumpName.TextLength < 3)
            {
                MPC.ShowInformation("Please ensure the input for the Pump Name is correct and longer than 3 characters.", "INFORMATION -Pump Name Input Incorrect");
                mtxtPumpName.Focus();
                return false;
            }

            if (mtxtPumpDescription.TextLength < 3)
            {
                MPC.ShowInformation("Please ensure the input for the description of the pump is correct and longer than 3 characters.", "INFORMATION - Pump Description Input Incorrect");
                mtxtPumpDescription.Focus();
                return false;
            }

            float TempNewPumpPrice;
            float.TryParse(mtxtNewPumpPrice.Text, out TempNewPumpPrice);
            if (TempNewPumpPrice == 0)
            {
                MPC.ShowInformation("Please ensure the input for the price of the pump is correct and longer than 2 characters.", "INFORMATION - Pump Price Input Incorrect");
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

            //Mandatory added first
            for (int i = 0; i < dgvMandatoryPartView.Rows.Count; i++)
                if ( ( Boolean ) (dgvMandatoryPartView.Rows[i].Cells["clmAddToPumpSelection"].Value) == true)
                {
                    Pump_Part newPart = new Pump_Part(passed.PassMandatoryPartList[i], ( int ) (dgvMandatoryPartView.Rows[i].Cells["clmMPartQuantity"].Value)); // Cast used rather than convert; not much but to a degree faster
                    ReturnList.Add(newPart);
                }

            //Non-Mandatory added second
            for(int k = 0; k < dgvNonMandatoryPartView.Rows.Count; k++)
                if ((Boolean)(dgvNonMandatoryPartView.Rows[k].Cells["clmAddToPumpSelection"].Value) == true)
                {
                    Pump_Part newPart = new Pump_Part(passed.PassNonMandatoryPartList[k], (int)(dgvNonMandatoryPartView.Rows[k].Cells["clmNMPartQuantity"].Value)); // Cast used rather than convert; not much but to a degree faster
                    ReturnList.Add(newPart);
                }

            return ReturnList;
        }

        /*******************************************/
    }
}