using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmAddPart(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
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
                    passed.PartToChange.PartPrice = MainProgramCode.ParseFloat(mtxtPartPrice.Text);
                    passed.PartToChange.MandatoryPart = cbxMandatoryPart.Checked;

                    if(BeforeUpdatePart.MandatoryPart && !passed.PartToChange.MandatoryPart)//Determine if it was a mandatory part that changed into a non-mandatory part
                    {
                        if(!ChangeToNonMandatory(passed.PartToChange))
                        {
                            MainProgramCode.ShowError("An error occured while transfering the part to the non-mandatory part list","ERROR - Transfer Failed");
                            return;
                        }
                    }
                    else if(!BeforeUpdatePart.MandatoryPart && passed.PartToChange.MandatoryPart)//Determine if it was a non-mandatory part that changed into a mandatory part
                    {
                        if (!ChangeToMandatory(passed.PartToChange))
                        {
                            MainProgramCode.ShowError("An error occured while transfering the part to the mandatory part list", "ERROR - Transfer Failed");
                            return;
                        }
                    }

                    MainProgramCode.ShowInformation("Successfully updated the part" , "CONFIRMATION - Update Successful");
                    passed.ChangeSpecificObject = false;
                    this.Close();
                }
                else return;

            }
            else // Add New Part
            {
                Part newPart;
                if (ValidInput())
                {
                    newPart = new Part(mtxtPartName.Text, mtxtPartDescription.Text, mtxtOriginalPartNumber.Text, mtxtNewPartNumber.Text, cbxMandatoryPart.Checked, MainProgramCode.ParseFloat(mtxtPartPrice.Text));
                }
                else return;

                

                if (newPart.MandatoryPart)
                {
                    if(passed.PassMandatoryPartList != null) if (!DistinctInput(ref newPart)) return;
                    

                    if (passed.PassMandatoryPartList == null)
                    {
                        passed.PassMandatoryPartList = new BindingList<Part>() { newPart };
                        MainProgramCode.ShowInformation(newPart.PartName + " successfully added to the mandatory part list.", "INFORMATION - Mandatory Part Added Success");
                    }
                    else
                    {
                        passed.PassMandatoryPartList.Add(newPart);
                        MainProgramCode.ShowInformation(newPart.PartName + " successfully added to the mandatory part list.", "INFORMATION - Mandatory Part Added Success");
                    }

                }
                else //newPart is Non-Mandatory
                {
                    if (passed.PassNonMandatoryPartList == null)
                    {
                        passed.PassNonMandatoryPartList = new BindingList<Part>() { newPart };
                        passed.PassNonMandatoryPartList.Add(newPart);
                        MainProgramCode.ShowInformation(newPart.PartName + " successfully added to the non-mandatory part list.", "INFORMATION - Non-Mandatory Part Added Success");
                    }
                    else
                    {
                        passed.PassNonMandatoryPartList.Add(newPart);
                        MainProgramCode.ShowInformation(newPart.PartName + " successfully added to the non-mandatory part list.", "INFORMATION - Non-Mandatory Part Added Success");
                    }
                }


                if (cbAddToPumpSelection.SelectedIndex > -1)
                {
                    Pump PumpSelection = (Pump)cbAddToPumpSelection.SelectedItem;

                    PumpSelection.PartList.Add(new Pump_Part(newPart, (int)NudQuantity.Value));

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
            //Load a csv file and add the items to the appropriate list

            string message = "Please ensure that the selected csv file has the following items in this exact order:\n\n" +
                             "First Column: Original Part Number\n" +
                             "Second Column: Part Name\n" +
                             "Third Column: Part Description\n" +
                             "Fourth Column: New Part Number\n" +
                             "Fith Column: Part Price\n" +
                             "Sixth Column: Part Quantity ( To add this amount of parts to the pump specified ) \n" +
                             "Seventh Column: TRUE / FALSE value ( Mandatory part )\n" +
                             "Eighth Column: Pump Name( To add a part to a specific pump )\n" +
                             "Nineth Column: Pump Price (Price when pump is bought new)\n" +
                             "Click the OK button to select the file or alternitivley chooce cancel to abort this action.";

            DialogResult MessageBoxResult = MessageBox.Show(message, "INFORMATION - CSV Batch Part Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (MessageBoxResult == DialogResult.OK)
            {
                OfdOpenCSVFile.ShowDialog();
                using (TextFieldParser fieldParser = new TextFieldParser(OfdOpenCSVFile.FileName))
                {
                    fieldParser.TextFieldType = FieldType.Delimited;
                    fieldParser.SetDelimiters(",");
                    while (!fieldParser.EndOfData)
                    {
                        //Process each row:
                        string[] readFields = fieldParser.ReadFields();
                        Part newPart = null;
                        try
                        {
                            newPart = new Part(readFields[1], readFields[2], readFields[0], readFields[3], MainProgramCode.ParseBoolean(readFields[6]), MainProgramCode.ParseFloat(readFields[4]));
                            if(!DistinctInput(ref newPart))
                            {
                                MainProgramCode.ShowError("Provided CSV File contains Part Items which do not have distinct Original Part Numbers or New part Number.\n Part items up until the first occurence of an ununique part has been added to the Part list. ", "ERROR - CSV Part Items Not Unique");
                                return;
                            }
                        }
                        catch
                        {
                            MainProgramCode.ShowError("The provided CSV File's format is inccorrect, please try again once the format has been corrected.", "ERROR - CSV File Format Incorrect");
                            return;
                        }

                        if (passed.PassMandatoryPartList == null) passed.PassMandatoryPartList = new BindingList<Part>();
                        if (passed.PassNonMandatoryPartList == null) passed.PassNonMandatoryPartList = new BindingList<Part>();


                        if (newPart != null && newPart.MandatoryPart)
                        {
                            passed.PassMandatoryPartList.Add(newPart);
                        }
                        else if (newPart != null) passed.PassNonMandatoryPartList.Add(newPart);

                        bool FoundPump = false;

                        //TODO: Check pump exists and/or Part exists, 
                        //      in case pump not found but part found - create new pump with part
                        //      in case pump found but not part       - create new part and add to pump

                        BindingList<Pump_Part> NewPumpPartList = new BindingList<Pump_Part>();

                        if (passed.PassPumpList != null)
                        {
                            Pump pump = new Pump(readFields[7], "", MainProgramCode.ParseFloat(readFields[8]), ref NewPumpPartList);
                            
                            for (int i = 0; i < passed.PassPumpList.Count; i++)
                            {
                                if (passed.PassPumpList[i].PumpName == pump.PumpName)
                                {
                                    FoundPump = true;
                                    pump = passed.PassPumpList[i];
                                    break;
                                }
                            }

                            if(!FoundPump) //Pump non existing
                            {
                                NewPumpPartList = new BindingList<Pump_Part> { new Pump_Part(newPart, int.Parse(readFields[5])) };
                                pump.PartList = NewPumpPartList;
                                passed.PassPumpList.Add(pump);
                            }
                            else // Pump Existing
                            {
                                pump.PartList.Add(new Pump_Part(newPart, int.Parse(readFields[5])));
                            }
                        }
                        else // passed.PassPumpList is empty
                        {
                            NewPumpPartList = new BindingList<Pump_Part> { new Pump_Part(newPart, int.Parse(readFields[5])) };
                            passed.PassPumpList = new BindingList<Pump> { new Pump(readFields[7], "", MainProgramCode.ParseFloat(readFields[8]), ref NewPumpPartList) };
                        }
                        
                    }

                 MainProgramCode.ShowInformation("The selected CSV file has been successfully imported.", "CONFIRMATION - Batch Part Import Successful");

                }
            } else return;
            this.Close();
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
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancelation")) this.Close();
        }

        private void FrmAddPart_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.PassPumpList != null)
            {
                //Created a Binding Source for the pumplist to link the pumps
                //directly to the combobox's datasource:

                var ComboBoxPumpSource = new BindingSource { DataSource = passed.PassPumpList };

                cbAddToPumpSelection.DataSource = ComboBoxPumpSource.DataSource;

                //Linking the specific item from the Pump class to display in the combobox:

                cbAddToPumpSelection.DisplayMember = "PumpName";
                cbAddToPumpSelection.ValueMember = "PumpName";
            }

            // Determine is an item is to be edited / added.

            if (this.passed.ChangeSpecificObject && this.passed.PartToChange != null)
            {
                //Updating 
                LoadInformation();
                ReadWriteComponents();
                btnAddPart.Text = "Update";
            }
            else if (!this.passed.ChangeSpecificObject && this.passed.PartToChange != null)
            {
                //Viewing
                btnAddPart.Visible = false;
                Read_OnlyComponents();
                LoadInformation();
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

            if (MainProgramCode.ParseFloat(mtxtPartPrice.Text) == 0)
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
                passed.PassMandatoryPartList.Add(SwitchPart);
                passed.PassNonMandatoryPartList.Remove(SwitchPart);
                return true;
            }
            return false;
        }

        private bool ChangeToNonMandatory(Part SwitchPart)
        {
            if (SwitchPart != null)
            {
                passed.PassNonMandatoryPartList.Add(SwitchPart);
                passed.PassMandatoryPartList.Remove(SwitchPart);
                return true;
            }
            return false;
        }

        // Check if input is distinct:

        private bool DistinctInput(ref Part part)
        {
            if (part != null && part.MandatoryPart)
            {
                if (passed.PassMandatoryPartList != null)
                {
                    for (int i = 0; i < passed.PassMandatoryPartList.Count - 1; i++)
                    {
                        if (passed.PassMandatoryPartList[i].NewPartNumber == part.NewPartNumber || passed.PassMandatoryPartList[i].OriginalItemPartNumber == part.OriginalItemPartNumber)
                        {
                            MainProgramCode.ShowInformation("The provided new part information already has a part which has the same New Part Number or Original Part Number.\nPlease ensure that the provided Part Numbers' are distinct.", "INFORMATION - Part Already Listed");
                            return false;
                        }
                    }
                }
            }
            else if (part != null) // Part is NON-Mandatory
            {
                if (passed.PassNonMandatoryPartList != null)
                {
                    for (int i = 0; i < passed.PassNonMandatoryPartList.Count - 1; i++)
                    {
                        if (passed.PassNonMandatoryPartList[i].NewPartNumber == part.NewPartNumber || passed.PassNonMandatoryPartList[i].OriginalItemPartNumber == part.OriginalItemPartNumber)
                        {
                            MainProgramCode.ShowInformation("The provided new part information already has a part which has the same New Part Number or Original Part Number.\nPlease ensure that the provided Part Numbers' are distinct.", "INFORMATION - Part Already Listed");
                            return false;
                        }
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
            if(!passed.ChangeSpecificObject)
                if(MainProgramCode.RequestConfirmation("You are curently only viewing " + passed.PartToChange.PartName +" part, would you like to update it's details instead?","REQUEST - Update Specific Part Details"))
                {
                    ReadWriteComponents();
                    updatePartToolStripMenuItem.Enabled = false;
                    passed.ChangeSpecificObject = true;
                }    
        }

        /*********************************************************************************/
    }
}
