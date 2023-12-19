using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MainProgramLibrary;
using ToastNotifications;
using ToastNotifications.Position;
using System.Net.Http;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {
        public FrmAddPart()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation(Messages.TerminationRequestText, Messages.TerminationRequestCaption))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            var ctx = Global.Context;

            if (ctx.ChangeSpecificObject)
            {

                if (ValidInput())
                {
                    Part BeforeUpdatePart = new Part(ctx.PartToChange);

                    ctx.PartToChange.PartName = mtxtPartName.Text.Trim();
                    ctx.PartToChange.PartDescription = mtxtPartDescription.Text.Trim();
                    ctx.PartToChange.OriginalItemPartNumber = mtxtOriginalPartNumber.Text.Trim();
                    ctx.PartToChange.NewPartNumber = mtxtNewPartNumber.Text.Trim();
                    ctx.PartToChange.PartPrice = QuoteSwiftMainCode.ParseFloat(mtxtPartPrice.Text.Trim());
                    ctx.PartToChange.MandatoryPart = cbxMandatoryPart.Checked;

                    switch (BeforeUpdatePart.MandatoryPart)
                    {
                        case true when !ctx.PartToChange.MandatoryPart:
                            ChangeToNonMandatory(ctx.PartToChange);
                            break;
                        case false when ctx.PartToChange.MandatoryPart:
                            ChangeToMandatory(ctx.PartToChange);
                            break;
                    }


                    MainProgramCode.ShowInformation($"{Messages.UpdateConfirmationInfoText} the part", Messages.UpdateConfirmationInfoCaption);
                    ctx.PartToChange = null;
                    ctx.ChangeSpecificObject = false;
                    Close();
                }
                else return;

            }
            else // Add New Part
            {
                Part newPart;
                if (ValidInput())
                {
                    newPart = new Part(
                        mPartName: mtxtPartName.Text.Trim(), 
                        mPartDescription: mtxtPartDescription.Text.Trim(), 
                        mOriginalItempartNumber: mtxtOriginalPartNumber.Text.Trim(), 
                        mNewPartNumber: mtxtNewPartNumber.Text.Trim(), 
                        mMandatoryPart: cbxMandatoryPart.Checked, 
                        mPartPrice: QuoteSwiftMainCode.ParseFloat(mtxtPartPrice.Text.Trim())
                    );
                }
                else return;

                ctx.AddPart(ref newPart);

                if (cbAddToProductSelection.SelectedIndex > -1)
                {
                    var ProductSelection = (Product)cbAddToProductSelection.SelectedItem;

                    ProductSelection.PartList.Add(
                        new Product_Part(
                            newPart,
                            (int)NudQuantity.Value
                        )
                    );

                    MainProgramCode.ShowInformation(
                        $"{Messages.AddConfirmationInformationText} {newPart.PartName} to {ProductSelection.ProductName}'s part list.",
                        Messages.AddConfirmationInformationCaption);
                }
                else
                {
                    MainProgramCode.ShowInformation(
                        $"{Messages.AddConfirmationInformationText} {newPart.PartName}",
                        Messages.AddConfirmationInformationCaption);
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
                            newPart = new Part(readFields[1], readFields[2], readFields[0], readFields[3], QuoteSwiftMainCode.ParseBoolean(readFields[6]), QuoteSwiftMainCode.ParseFloat(readFields[4]));
                            Part OldPartToChange = passed.PartToChange;
                            passed.PartToChange = newPart;
                            if (!DistinctInput(ref newPart))
                            {
                                passed.PartToChange = OldPartToChange;

                                if (UpdateDuplicated)
                                {
                                    if (newPart.MandatoryPart)
                                        for (int i = 0; i < passed.PassMandatoryPartList.Count - 1; i++)
                                        {
                                            if (passed.PassMandatoryPartList[i].NewPartNumber == newPart.NewPartNumber || passed.PassMandatoryPartList[i].OriginalItemPartNumber == newPart.OriginalItemPartNumber)
                                            {

                                                Part data = passed.PassMandatoryPartList[i];
                                                data.MandatoryPart = newPart.MandatoryPart;
                                                data.PartDescription = newPart.PartDescription;
                                                data.PartName = newPart.PartName;
                                                data.PartPrice = newPart.PartPrice;

                                                break;
                                            }
                                        }

                                    if (!newPart.MandatoryPart)
                                        for (int i = 0; i < passed.PassNonMandatoryPartList.Count - 1; i++)
                                        {
                                            if (passed.PassNonMandatoryPartList[i].NewPartNumber == newPart.NewPartNumber || passed.PassNonMandatoryPartList[i].OriginalItemPartNumber == newPart.OriginalItemPartNumber)
                                            {


                                                Part data = passed.PassNonMandatoryPartList[i];
                                                data.MandatoryPart = newPart.MandatoryPart;
                                                data.PartDescription = newPart.PartDescription;
                                                data.PartName = newPart.PartName;
                                                data.PartPrice = newPart.PartPrice;

                                                break;
                                            }
                                        }

                                }
                            }
                        }
                        catch
                        {
                            MainProgramCode.ShowError("The provided CSV File's format is incorrect, please try again once the format has been corrected.", "ERROR - CSV File Format Incorrect");
                            return;
                        }

                        if (passed.PassMandatoryPartList == null) passed.PassMandatoryPartList = new BindingList<Part>();
                        if (passed.PassNonMandatoryPartList == null) passed.PassNonMandatoryPartList = new BindingList<Part>();


                        if (newPart != null && newPart.MandatoryPart && DistinctInput(ref newPart))
                        {
                            passed.PassMandatoryPartList.Add(newPart);
                        }
                        else if (newPart != null && DistinctInput(ref newPart)) passed.PassNonMandatoryPartList.Add(newPart);

                        bool FoundPump = false;

                        BindingList<Product_Part> NewPumpPartList = new BindingList<Product_Part>();

                        if (passed.ProductList != null)
                        {
                            Product NewPump = new Product(readFields[7], "", QuoteSwiftMainCode.ParseFloat(readFields[8]), ref NewPumpPartList);
                            Product OldPump = null;
                            for (int i = 0; i < passed.ProductList.Count; i++)
                            {
                                if (passed.ProductList[i].PumpName == NewPump.ProductName)
                                {
                                    FoundPump = true;
                                    OldPump = passed.ProductList[i];
                                    break;
                                }
                            }

                            if (FoundPump == false) //Pump non existing
                            {
                                NewPumpPartList = new BindingList<Product_Part> { new Product_Part(newPart, int.Parse(readFields[5])) };
                                NewPump.PartList = NewPumpPartList;
                                passed.ProductList.Add(NewPump);
                            }
                            else // Pump Existing
                            {
                                OldPump.PartList.Add(new Product_Part(newPart, int.Parse(readFields[5])));
                                if (OldPump.NewPumpPrice != NewPump.NewPumpPrice) OldPump.NewPumpPrice = NewPump.NewPumpPrice;
                            }
                        }
                        else // passed.PassPumpList is empty
                        {
                            NewPumpPartList = new BindingList<Product_Part> { new Product_Part(newPart, int.Parse(readFields[5])) };
                            passed.ProductList = new BindingList<Product> { new Product(readFields[7], "", QuoteSwiftMainCode.ParseFloat(readFields[8]), ref NewPumpPartList) };
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
            if (passed != null && passed.ProductList != null)
            {
                //Created a Binding Source for the pump list to link the pumps
                //directly to the combo-box's data-source:

                BindingSource ComboBoxPumpSource = new BindingSource { DataSource = passed.ProductList };

                cbAddToProductSelection.DataSource = ComboBoxPumpSource.DataSource;

                //Linking the specific item from the Pump class to display in the combo-box:

                cbAddToProductSelection.DisplayMember = "PumpName";
                cbAddToProductSelection.ValueMember = "PumpName";
            }

            // Determine is an item is to be edited / added.

            if (passed.ChangeSpecificObject && passed.PartToChange != null)
            {
                //Updating 
                LoadPartData();
                ReadWriteComponents();
                btnAddPart.Text = "Update";
                updatePartToolStripMenuItem.Enabled = false;
            }
            else if (!passed.ChangeSpecificObject && passed.PartToChange != null)
            {
                //Viewing
                btnAddPart.Visible = false;
                Read_OnlyComponents();
                LoadPartData();
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

            if (QuoteSwiftMainCode.ParseFloat(mtxtPartPrice.Text) == 0)
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
                var ctx = Global.Context;
                ctx.NonMandatoryPartMap.Remove(SwitchPart.OriginalItemPartNumber);
                ctx.NonMandatoryPartMap.Remove(SwitchPart.NewPartNumber);

                ctx.MandatoryPartMap[SwitchPart.OriginalItemPartNumber] = SwitchPart;
                ctx.MandatoryPartMap[SwitchPart.NewPartNumber] = SwitchPart;
                return true;
            }
            return false;
        }

        private bool ChangeToNonMandatory(Part SwitchPart)
        {
            if (SwitchPart != null)
            {
                var ctx = Global.Context;
                ctx.MandatoryPartMap.Remove(SwitchPart.OriginalItemPartNumber);
                ctx.MandatoryPartMap.Remove(SwitchPart.NewPartNumber);

                ctx.NonMandatoryPartMap[SwitchPart.OriginalItemPartNumber] = SwitchPart;
                ctx.NonMandatoryPartMap[SwitchPart.NewPartNumber] = SwitchPart;

                return true;
            }
            return false;
        }

        // Check if input is distinct:

        private bool DistinctInput(ref Part part)
        {
            var ctx = Global.Context;
            return
                part != null &&
                !ctx.MandatoryPartMap.TryGetValue(part.OriginalItemPartNumber, out _) &&
                !ctx.MandatoryPartMap.TryGetValue(part.NewPartNumber, out _) &&
                !ctx.NonMandatoryPartMap.TryGetValue(part.OriginalItemPartNumber, out _) &&
                !ctx.NonMandatoryPartMap.TryGetValue(part.NewPartNumber, out _);
        }

        private void LoadPartData()
        {
            var ctx = Global.Context;
            mtxtPartName.Text = ctx.PartToChange.PartName;
            mtxtPartDescription.Text = ctx.PartToChange.PartDescription;
            mtxtOriginalPartNumber.Text = ctx.PartToChange.OriginalItemPartNumber;
            mtxtNewPartNumber.Text = ctx.PartToChange.NewPartNumber;
            mtxtPartPrice.Text = ctx.PartToChange.PartPrice.ToString();
            cbxMandatoryPart.Checked = ctx.PartToChange.MandatoryPart;
        }

        private void Read_OnlyComponents()
        {
            mtxtNewPartNumber.ReadOnly = true;
            mtxtOriginalPartNumber.ReadOnly = true;
            mtxtPartDescription.ReadOnly = true;
            mtxtPartName.ReadOnly = true;
            mtxtPartPrice.ReadOnly = true;
            cbAddToProductSelection.Enabled = false;
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
            cbAddToProductSelection.Enabled = false;
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
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /*********************************************************************************/
    }
}
