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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"));
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Part newPart;
            if (ValidInput())
            {
                newPart = new Part(mtxtPartName.Text, mtxtPartDescription.Text, mtxtOriginalPartNumber.Text, mtxtNewPartNumber.Text, cbxMandatoryPart.Checked, MainProgramCode.ParseFloat(mtxtPartPrice.Text));
            }
            else return;


            if (newPart.MandatoryPart)
            {
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
            else
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

        private void FrmAddPart_Activated(object sender, EventArgs e)
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
        }

        private void LoadPartBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load a csv file and add the items to the appropriate list

            string message = "Please ensure that the selected csv file has the following items in this exact order:\n\n" +
                             "First Column: Part Name\n" +
                             "Second Column: Part Description\n" +
                             "Third Column: Original Part Number\n" +
                             "Fourth Column: New Part Number\n" +
                             "Fith Column: Part Price\n" +
                             "Sixth Column: Pump Name ( To add a row's specific part to that part )\n" +
                             "Seventh Column: Part Quantity ( To add this amount of parts to the pump specified )\n" +
                             "Eighth Column: TRUE / FALSE value ( Mandatory part )\n\n" +
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
                            newPart = new Part(readFields[0], readFields[1], readFields[2], readFields[3], MainProgramCode.ParseBoolean(readFields[7]), MainProgramCode.ParseFloat(readFields[4]));
                        }
                        catch (Exception)
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

                        // TODO: Process Quantity and Pump information in readFields[5] and readFields[6]

                        
                    }

                 MainProgramCode.ShowInformation("The selected CSV file has been successfully imported.", "CONFIRMATION - Batch Part Import Successful");

                }
            }
            else return;
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

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        bool ValidInput()
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

        void ClearInput()
        {
            mtxtNewPartNumber.ResetText();
            mtxtOriginalPartNumber.ResetText();
            mtxtPartDescription.ResetText();
            mtxtPartName.ResetText();
            mtxtPartPrice.ResetText();
            cbxMandatoryPart.Checked = false;
            NudQuantity.ResetText();
        }


        /*********************************************************************************/
    }
}
