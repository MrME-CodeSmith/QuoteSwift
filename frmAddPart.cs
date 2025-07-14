using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {

        readonly AddPartViewModel viewModel;
        readonly INavigationService navigation;

        Pass passed
        {
            get => viewModel.Pass;
            set => viewModel.UpdatePass(value);
        }

        public ref Pass Passed { get => ref passed; }

        public FrmAddPart(AddPartViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {

            if (passed.ChangeSpecificObject)
            {

                if (ValidInput())
                {
                    Part BeforeUpdatePart = new Part(passed.PartToChange);

                    passed.PartToChange.PartName = mtxtPartName.Text;
                    passed.PartToChange.PartDescription = mtxtPartDescription.Text;
                    passed.PartToChange.OriginalItemPartNumber = mtxtOriginalPartNumber.Text;
                    passed.PartToChange.NewPartNumber = mtxtNewPartNumber.Text;
                    passed.PartToChange.PartPrice = QuoteSwiftMainCode.ParseDecimal(mtxtPartPrice.Text);
                    passed.PartToChange.MandatoryPart = cbxMandatoryPart.Checked;

                    if (BeforeUpdatePart.MandatoryPart && !passed.PartToChange.MandatoryPart)//Determine if it was a mandatory part that changed into a non-mandatory part
                    {
                        if (!ChangeToNonMandatory(passed.PartToChange))
                        {
                            MainProgramCode.ShowError("An error occurred while transferring the part to the non-mandatory part list", "ERROR - Transfer Failed");
                            return;
                        }
                    }
                    else if (!BeforeUpdatePart.MandatoryPart && passed.PartToChange.MandatoryPart)//Determine if it was a non-mandatory part that changed into a mandatory part
                    {
                        if (!ChangeToMandatory(passed.PartToChange))
                        {
                            MainProgramCode.ShowError("An error occurred while transferring the part to the mandatory part list", "ERROR - Transfer Failed");
                            return;
                        }
                    }

                    MainProgramCode.ShowInformation("Successfully updated the part", "CONFIRMATION - Update Successful");
                    passed.ChangeSpecificObject = false;
                    Close();
                }
                else return;

            }
            else // Add New Part
            {
                Part newPart;
                if (ValidInput())
                {
                    newPart = new Part(mtxtPartName.Text, mtxtPartDescription.Text, mtxtOriginalPartNumber.Text, mtxtNewPartNumber.Text, cbxMandatoryPart.Checked, QuoteSwiftMainCode.ParseDecimal(mtxtPartPrice.Text));
                }
                else return;



                if (passed.PassPartList != null)
                    if (!DistinctInput(ref newPart))
                        return;

                if (passed.PassPartList == null)
                    passed.PassPartList = new Dictionary<string, Part>();

                passed.AddPart(newPart);
                string info = newPart.MandatoryPart ?
                    " successfully added to the mandatory part list." :
                    " successfully added to the non-mandatory part list.";
                MainProgramCode.ShowInformation(newPart.PartName + info, "INFORMATION - Part Added Success");


                if (cbAddToPumpSelection.SelectedIndex > -1)
                {
                    Pump PumpSelection = (Pump)cbAddToPumpSelection.SelectedItem;

                    AddOrOverridePumpPart(PumpSelection, newPart, (int)NudQuantity.Value);

                    MainProgramCode.ShowInformation(newPart.PartName + " successfully added to " + PumpSelection.PumpName + " pump the part list.", "INFORMATION - Part Added  To Pump Success");
                }


                ClearInput();

            }
        }

        private void FrmAddPart_Activated(object sender, EventArgs e)
        {

        }

        private void LoadPartBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load a CSV file and add the items to the appropriate list

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

            DialogResult MessageBoxResult = MessageBox.Show(message, "INFORMATION - CSV Batch Part Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (MessageBoxResult == DialogResult.OK)
            {
                OfdOpenCSVFile.ShowDialog();
                using (TextFieldParser fieldParser = new TextFieldParser(OfdOpenCSVFile.FileName))
                {
                    fieldParser.TextFieldType = FieldType.Delimited;
                    fieldParser.SetDelimiters(",");

                    bool UpdateDuplicated = false;
                    if (MainProgramCode.RequestConfirmation("In the case that a duplicate part is being added would you like to update the parts that has already been added before?", "REQUEST - Update Duplicate Part")) UpdateDuplicated = true;

                    while (!fieldParser.EndOfData)
                    {
                        //Process each row:
                        string[] readFields = fieldParser.ReadFields();
                        Part newPart = null;
                        try
                        {
                            newPart = new Part(readFields[1], readFields[2], readFields[0], readFields[3], QuoteSwiftMainCode.ParseBoolean(readFields[6]), QuoteSwiftMainCode.ParseDecimal(readFields[4]));
                            Part OldPartToChange = passed.PartToChange;
                            passed.PartToChange = newPart;
                            if (!DistinctInput(ref newPart))
                            {
                                passed.PartToChange = OldPartToChange;

                                if (UpdateDuplicated)
                                {
                                    string oKey = StringUtil.NormalizeKey(newPart.OriginalItemPartNumber);
                                    string nKey = StringUtil.NormalizeKey(newPart.NewPartNumber);

                                    if (passed.PassPartList.TryGetValue(oKey, out var data) ||
                                        passed.TryGetPartByNew(nKey, out data))
                                    {
                                        data.MandatoryPart = newPart.MandatoryPart;
                                        data.PartDescription = newPart.PartDescription;
                                        data.PartName = newPart.PartName;
                                        data.PartPrice = newPart.PartPrice;
                                    }

                                }
                            }
                        }
                        catch
                        {
                            MainProgramCode.ShowError("The provided CSV File's format is incorrect, please try again once the format has been corrected.", "ERROR - CSV File Format Incorrect");
                            return;
                        }

                        if (passed.PassPartList == null) passed.PassPartList = new Dictionary<string, Part>();


                        Part partForPump = newPart;
                        bool partIsDistinct = newPart != null && DistinctInput(ref newPart);

                        if (newPart != null)
                        {
                            if (partIsDistinct)
                                passed.AddPart(newPart);
                            else
                                partForPump = GetPartByOriginal(newPart.OriginalItemPartNumber) ?? newPart;
                        }

                        bool FoundPump = false;

                        BindingList<Pump_Part> NewPumpPartList = new BindingList<Pump_Part>();

                        if (passed.PassPumpList != null)
                        {
                            Pump NewPump = new Pump(readFields[7], "", QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref NewPumpPartList);
                            Pump OldPump = null;
                            foreach (var pump in passed.PassPumpList)
                            {
                                if (StringUtil.NormalizeKey(pump.PumpName) == StringUtil.NormalizeKey(NewPump.PumpName))
                                {
                                    FoundPump = true;
                                    OldPump = pump;
                                    break;
                                }
                            }

                            if (FoundPump == false) //Pump non existing
                            {
                                NewPumpPartList = new BindingList<Pump_Part> { new Pump_Part(partForPump, int.Parse(readFields[5])) };
                                NewPump.PartList = NewPumpPartList;
                                passed.PassPumpList.Add(NewPump);
                            }
                            else // Pump Existing
                            {
                                AddOrOverridePumpPart(OldPump, partForPump, int.Parse(readFields[5]));
                                if (OldPump.NewPumpPrice != NewPump.NewPumpPrice) OldPump.NewPumpPrice = NewPump.NewPumpPrice;
                            }
                        }
                        else // passed.PassPumpList is empty
                        {
                            NewPumpPartList = new BindingList<Pump_Part> { new Pump_Part(partForPump, int.Parse(readFields[5])) };
                            passed.PassPumpList = new BindingList<Pump> { new Pump(readFields[7], "", QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref NewPumpPartList) };
                        }

                    }

                    MainProgramCode.ShowInformation("The selected CSV file has been successfully imported.", "CONFIRMATION - Batch Part Import Successful");

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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to reset the current screen to it's default values?", "REQUEST - Screen Defaults Reset"))
            {
                ClearInput();
                NudQuantity.Enabled = false;
                cbxMandatoryPart.Checked = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void FrmAddPart_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.PassPumpList != null)
            {
                //Created a Binding Source for the pump list to link the pumps
                //directly to the combo-box's data-source:

                BindingSource ComboBoxPumpSource = new BindingSource { DataSource = passed.PassPumpList };

                cbAddToPumpSelection.DataSource = ComboBoxPumpSource.DataSource;

                //Linking the specific item from the Pump class to display in the combo-box:

                cbAddToPumpSelection.DisplayMember = "PumpName";
                cbAddToPumpSelection.ValueMember = "PumpName";
            }

            // Determine is an item is to be edited / added.

            if (passed.ChangeSpecificObject && passed.PartToChange != null)
            {
                //Updating 
                LoadInformation();
                ReadWriteComponents();
                btnAddPart.Text = "Update";
                updatePartToolStripMenuItem.Enabled = false;
            }
            else if (!passed.ChangeSpecificObject && passed.PartToChange != null)
            {
                //Viewing
                btnAddPart.Visible = false;
                Read_OnlyComponents();
                LoadInformation();
                updatePartToolStripMenuItem.Enabled = true;
            }   //Otherwise its Add

        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        private bool ValidInput()
        {
            if (mtxtPartName.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please ensure that the name of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                mtxtPartName.Focus();
                return false;
            }

            if (mtxtPartDescription.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please ensure that the description of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                mtxtPartDescription.Focus();
                return false;
            }

            if (mtxtOriginalPartNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please ensure that the original part number of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                mtxtOriginalPartNumber.Focus();
                return false;
            }

            if (mtxtNewPartNumber.Text.Length < 3)
            {
                MainProgramCode.ShowError("Please ensure that the new part number of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                mtxtNewPartNumber.Focus();
                return false;
            }

            if (QuoteSwiftMainCode.ParseDecimal(mtxtPartPrice.Text) == 0)
            {
                MainProgramCode.ShowError("Please ensure that the price of the Item is valid and it has a value greater than R99.", "ERROR - Invalid Input");
                mtxtPartPrice.Focus();
                return false;
            }

            return true;
        }

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

        private bool ChangeToMandatory(Part SwitchPart)
        {
            if (SwitchPart != null)
            {
                SwitchPart.MandatoryPart = true;
                return true;
            }
            return false;
        }

        private bool ChangeToNonMandatory(Part SwitchPart)
        {
            if (SwitchPart != null)
            {
                SwitchPart.MandatoryPart = false;
                return true;
            }
            return false;
        }

        // Check if input is distinct:

        private bool DistinctInput(ref Part part)
        {
            if (part != null)
            {
                if (passed.PassPartList != null)
                {
                    string oKey = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
                    string nKey = StringUtil.NormalizeKey(part.NewPartNumber);
                    if (passed.PassPartList.ContainsKey(oKey) || passed.TryGetPartByNew(nKey, out _))
                    {
                        if (passed.PartToChange == null)
                            MainProgramCode.ShowInformation("The provided new part information already has a part which has the same New Part Number or Original Part Number.\nPlease ensure that the provided Part Numbers' are distinct.", "INFORMATION - Part Already Listed");
                        return false;
                    }
                }
            }
            else return false; //part is null and therefore not valid


            return true;
        }

        private void LoadInformation()
        {
            mtxtPartName.Text = passed.PartToChange.PartName;
            mtxtPartDescription.Text = passed.PartToChange.PartDescription;
            mtxtOriginalPartNumber.Text = passed.PartToChange.OriginalItemPartNumber;
            mtxtNewPartNumber.Text = passed.PartToChange.NewPartNumber;
            mtxtPartPrice.Text = passed.PartToChange.PartPrice.ToString();
            cbxMandatoryPart.Checked = passed.PartToChange.MandatoryPart;
        }

        private void Read_OnlyComponents()
        {
            mtxtNewPartNumber.ReadOnly = true;
            mtxtOriginalPartNumber.ReadOnly = true;
            mtxtPartDescription.ReadOnly = true;
            mtxtPartName.ReadOnly = true;
            mtxtPartPrice.ReadOnly = true;
            cbAddToPumpSelection.Enabled = false;
            NudQuantity.Enabled = false;
            cbxMandatoryPart.Enabled = false;
        }

        private void ReadWriteComponents()
        {
            mtxtNewPartNumber.ReadOnly = false;
            mtxtOriginalPartNumber.ReadOnly = false;
            mtxtPartDescription.ReadOnly = false;
            mtxtPartName.ReadOnly = false;
            mtxtPartPrice.ReadOnly = false;
            cbAddToPumpSelection.Enabled = false;
            NudQuantity.Enabled = false;
            cbxMandatoryPart.Enabled = true;
            btnAddPart.Visible = true;
            btnAddPart.Text = "Update Part";
        }

        private void UpdatePartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!passed.ChangeSpecificObject)
                if (MainProgramCode.RequestConfirmation("You are currently only viewing " + passed.PartToChange.PartName + " part, would you like to update it's details instead?", "REQUEST - Update Specific Part Details"))
                {
                    ReadWriteComponents();
                    updatePartToolStripMenuItem.Enabled = false;
                    passed.ChangeSpecificObject = true;
                }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmAddPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }

        private Part GetPartByOriginal(string originalNumber)
        {
            string key = StringUtil.NormalizeKey(originalNumber);
            if (passed.PassPartList != null &&
                passed.PassPartList.TryGetValue(key, out var part))
                return part;
            return null;
        }

        private void AddOrOverridePumpPart(Pump pump, Part part, int quantity)
        {
            if (pump == null || part == null)
                return;

            if (pump.PartList == null)
                pump.PartList = new BindingList<Pump_Part>();

            string key = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
            foreach (var pp in pump.PartList)
            {
                if (StringUtil.NormalizeKey(pp.PumpPart.OriginalItemPartNumber) == key)
                {
                    pp.PumpPartQuantity = quantity;
                    return;
                }
            }

            pump.PartList.Add(new Pump_Part(part, quantity));
        }

        /*********************************************************************************/
    }
}
