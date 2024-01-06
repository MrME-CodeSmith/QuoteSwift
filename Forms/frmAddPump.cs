using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmAddPump : Form
    {
        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmAddPump()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work correctly.

            if (ValidInput())
            {
                BindingList<ProductPart> NewPumpParts = RetreivePumpPartList();

                if (NewPumpParts == null)
                {
                    MainProgramCode.ShowError("There wasn't any parts chosen from any of the lists below\nPlease ensure that parts are selected and/or that there is parts available to select from.", "ERROR - No Pump Part Selection");
                    return;
                }

                if (mPassed.ChangeSpecificObject) // Update Part List if true
                {
                    RecordNewInformation();
                    MainProgramCode.ShowInformation(mPassed.PumpToChange.ProductName + " has been updated in the list of pumps", "INFORMATION - Pump Update Successfully");

                    //Set ChangeSpecificObject to false and convert to View

                    mPassed.ChangeSpecificObject = false;
                    ConvertToViewForm();

                    //Enable menu strip item that converts form to Update a pump 
                    updatePumpToolStripMenuItem.Enabled = true;
                }
                else //Create New Pump And Add To Pump List
                {
                    Product newPump = new Product(mtxtPumpName.Text, mtxtPumpDescription.Text, (float)Convert.ToDouble(mtxtNewPumpPrice.Text), ref NewPumpParts); // Cast used since Convert.To does not support float
                    if (mPassed.ProductMap == null) mPassed.ProductMap = new Dictionary<string, Product>(){ {newPump.ProductName, newPump} }; else mPassed.ProductMap.Add(newPump.ProductName, newPump);
                    MainProgramCode.ShowInformation(newPump.ProductName + " has been added to the list of pumps", "INFORMATION - Pump Added Successfully");
                }
            }

        }

        private void MtxtPumpName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtPumpDescription_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void MtxtNewPumpPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void DgvNonMandatoryPartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
        }

        private void FrmAddPump_Load(object sender, EventArgs e)
        {
            LoadMandatoryParts();
            LoadNonMandatoryParts();

            if (mPassed != null && mPassed.PumpToChange != null && mPassed.ChangeSpecificObject == true) //Determine if Edit
            {
                ConvertToEditForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (mPassed != null && mPassed.PumpToChange != null && mPassed.ChangeSpecificObject == false) //Determine if View
            {
                ConvertToViewForm();
                Read_OnlyMainComponents();
                PopulateFormWithPassedPump();
            }
            else if (mPassed != null && mPassed.PumpToChange == null && mPassed.ChangeSpecificObject == false) // Determine if Add New
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
            Text = "Updating " + mPassed.PumpToChange.ProductName + " Pump";
            btnAddPump.Text = "Update Pump";
            btnAddPump.Visible = true;
            updatePumpToolStripMenuItem.Enabled = true;
        }

        //Convert Form To View:

        void ConvertToViewForm()
        {
            Text = "Viewing " + mPassed.PumpToChange.ProductName + " Pump";
            btnAddPump.Visible = false;
            Read_OnlyMainComponents();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        //Populates the form with the passed Pump object and checks the check boxes in the data grid view where parts are being used.

        void PopulateFormWithPassedPump()
        {
            mtxtNewPumpPrice.Text = mPassed.PumpToChange.NewProductPrice.ToString();
            mtxtPumpDescription.Text = mPassed.PumpToChange.PumpDescription;
            mtxtPumpName.Text = mPassed.PumpToChange.ProductName;

            for (int i = 0; i < mPassed.MandatoryPartMap.Count; i++)
                for (int k = 0; k < mPassed.PumpToChange.PartList.Count; k++)
                {
                    if (mPassed.MandatoryPartMap.Values.ToArray()[i].OriginalItemPartNumber == mPassed.PumpToChange.PartList[k].Part.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvMandatoryPartView.Rows[i].Cells["clmAddToPumpSelection"];
                        cbx.Value = true;
                        dgvMandatoryPartView.Rows[i].Cells["clmMPartQuantity"].Value = mPassed.PumpToChange.PartList[k].PumpPartQuantity.ToString();
                    }
                }

            for (int s = 0; s < mPassed.NonMandatoryPartMap.Count; s++)
                for (int d = 0; d < mPassed.PumpToChange.PartList.Count; d++)
                {
                    if (mPassed.NonMandatoryPartMap.Values.ToArray()[s].OriginalItemPartNumber == mPassed.PumpToChange.PartList[d].Part.OriginalItemPartNumber)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgvNonMandatoryPartView.Rows[s].Cells["ClmNonMandatoryPartSelection"];
                        cbx.Value = true;
                        dgvNonMandatoryPartView.Rows[s].Cells["clmNMPartQuantity"].Value = mPassed.PumpToChange.PartList[d].PumpPartQuantity.ToString();
                    }
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

        BindingList<ProductPart> RetreivePumpPartList()
        {
            //When done Editing / Adding a pump, all mandatory parts need to be added first to the part list
            //This is for the for loop when the form gets activated to work correctly.

            BindingList<ProductPart> ReturnList = null;
            ProductPart newPart;
            //Mandatory added first
            for (int i = 0; i < dgvMandatoryPartView.Rows.Count; i++)
                try
                {
                    if ((bool)(dgvMandatoryPartView.Rows[i].Cells["clmAddToPumpSelection"].Value) == true)
                    {
                        try
                        {
                            newPart = new ProductPart(mPassed.MandatoryPartMap.Values.ToArray()[i], QuoteSwiftMainCode.ParseInt(dgvMandatoryPartView.Rows[i].Cells["clmMPartQuantity"].Value.ToString())); // Cast used rather than convert; not much but to a degree faster
                        }
                        catch
                        {
                            newPart = null;
                        }

                        if (newPart != null)
                            if (ReturnList == null)
                                ReturnList = new BindingList<ProductPart> { newPart };
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
                    if ((bool)(dgvNonMandatoryPartView.Rows[k].Cells["ClmNonMandatoryPartSelection"].Value) == true)
                    {
                        try
                        {
                            newPart = new ProductPart(mPassed.NonMandatoryPartMap.Values.ToArray()[k], QuoteSwiftMainCode.ParseInt(dgvNonMandatoryPartView.Rows[k].Cells["clmNMPartQuantity"].Value.ToString())); // Cast used rather than convert; not much but to a degree faster
                        }
                        catch
                        {
                            newPart = null;
                        }

                        if (newPart != null)
                            if (ReturnList == null)
                                ReturnList = new BindingList<ProductPart> { newPart };
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
            if (mPassed != null && mPassed.PumpToChange != null && mPassed.ChangeSpecificObject == false)
                if (MainProgramCode.RequestConfirmation("You are currently viewing " + mPassed.PumpToChange.ProductName + " pump, would you like to edit it instead?", "REQUEST - View To Edit REQUEST"))
                {
                    ConvertToEditForm();
                    mPassed.ChangeSpecificObject = true;
                }
        }

        void RecordNewInformation()
        {
            if (mtxtPumpName.Text != mPassed.PumpToChange.ProductName) mPassed.PumpToChange.ProductName = mtxtPumpName.Text;

            if (mtxtPumpDescription.Text != mPassed.PumpToChange.PumpDescription) mPassed.PumpToChange.PumpDescription = mtxtPumpDescription.Text;

            if (NewPumpValueInput() != mPassed.PumpToChange.NewProductPrice) mPassed.PumpToChange.NewProductPrice = NewPumpValueInput();

            mPassed.PumpToChange.PartList = RetreivePumpPartList();
        }

        float NewPumpValueInput()
        {
            float.TryParse(mtxtNewPumpPrice.Text, out float TempNewPumpPrice);
            return TempNewPumpPrice;
        }



        void LoadMandatoryParts()
        {
            if (mPassed.MandatoryPartMap != null)
            {
                dgvMandatoryPartView.Rows.Clear();

                for (int i = 0; i < mPassed.MandatoryPartMap.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvMandatoryPartView.Rows.Add(mPassed.MandatoryPartMap.Values.ToArray()[i].PartName, mPassed.MandatoryPartMap.Values.ToArray()[i].PartDescription, mPassed.MandatoryPartMap.Values.ToArray()[i].OriginalItemPartNumber, mPassed.MandatoryPartMap.Values.ToArray()[i].NewPartNumber, mPassed.MandatoryPartMap.Values.ToArray()[i].PartPrice, false, 0);
                }
            }
        }

        void LoadNonMandatoryParts()
        {
            if (mPassed.NonMandatoryPartMap != null)
            {
                dgvNonMandatoryPartView.Rows.Clear();

                for (int k = 0; k < mPassed.NonMandatoryPartMap.Count; k++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvNonMandatoryPartView.Rows.Add(mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartName, mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartDescription, mPassed.NonMandatoryPartMap.Values.ToArray()[k].OriginalItemPartNumber, mPassed.NonMandatoryPartMap.Values.ToArray()[k].NewPartNumber, mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartPrice, false, 0);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void UpdatePumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mPassed.ChangeSpecificObject)
                ChangeViewToEdit();
            updatePumpToolStripMenuItem.Enabled = false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmAddPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /*********************************************************************************/


    }
}
