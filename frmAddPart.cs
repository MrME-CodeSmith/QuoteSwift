using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                    var BeforeUpdatePart = new Part(ctx.PartToChange);

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

                try
                {
                    ctx.AddPart(ref newPart);
                }
                catch (FeedbackException Ex)
                {
                    MainProgramCode.ShowWarning(
                        Ex.Message, 
                        Messages.TaskWarningInformationCaption
                    );
                }
                catch (Exception)
                {
                    MainProgramCode.ShowError(
                        Messages.TaskErrorInformationText, 
                        Messages.TaskErrorInformationCaption
                    );
                    return;
                }
                
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

            var MessageBoxResult = MessageBox.Show(
                Messages.CSVBatchImportInformationText, 
                Messages.CSVBatchImportInformationCaption, 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Information
            );

            var ctx = Global.Context;

            if (MessageBoxResult == DialogResult.OK)
            {
                OfdOpenCSVFile.ShowDialog();
                using (var fieldParser = new TextFieldParser(OfdOpenCSVFile.FileName))
                {
                    fieldParser.TextFieldType = FieldType.Delimited;
                    fieldParser.SetDelimiters(",");

                    bool UpdateDuplicated = MainProgramCode.RequestConfirmation(
                        Messages.UpdatePartsWithSamePartNumbersRequestText, 
                        Messages.UpdatePartsWithSamePartNumbersRequestCaption
                    );
                    
                    while (!fieldParser.EndOfData)
                    {
                        //Process each row:
                        string[] readFields = fieldParser.ReadFields();
                        Part newPart = null;
                        try
                        {
                            newPart = new Part(
                                readFields[1], 
                                readFields[2], 
                                readFields[0], 
                                readFields[3], 
                                QuoteSwiftMainCode.ParseBoolean(readFields[6]), 
                                QuoteSwiftMainCode.ParseFloat(readFields[4])
                            );

                            try
                            {
                                ctx.AddPart(ref newPart);
                            }
                            catch (FeedbackException)
                            {
                                if (UpdateDuplicated)
                                {
                                    if (!ctx.MandatoryPartMap.TryGetValue(newPart.OriginalItemPartNumber, out var p))
                                        if (!ctx.NonMandatoryPartMap.TryGetValue(newPart.OriginalItemPartNumber, out p))
                                            if (!ctx.MandatoryPartMap.TryGetValue(newPart.NewPartNumber, out p))
                                                ctx.NonMandatoryPartMap.TryGetValue(newPart.NewPartNumber, out p);

                                    var tempPart = new Part[4];

                                    ctx.MandatoryPartMap.TryGetValue(newPart.OriginalItemPartNumber, out tempPart[0]);
                                    ctx.MandatoryPartMap.TryGetValue(newPart.NewPartNumber, out tempPart[1]);

                                    ctx.NonMandatoryPartMap.TryGetValue(newPart.NewPartNumber, out tempPart[2]);
                                    ctx.NonMandatoryPartMap.TryGetValue(newPart.OriginalItemPartNumber, out tempPart[3]);

                                    if (
                                        tempPart.All(
                                            part => part == null ||
                                                    part.Equals(p) ||
                                                    (
                                                        part.OriginalItemPartNumber != newPart.OriginalItemPartNumber &&
                                                        part.NewPartNumber != newPart.NewPartNumber &&
                                                        part.OriginalItemPartNumber != newPart.NewPartNumber &&
                                                        part.NewPartNumber != newPart.OriginalItemPartNumber
                                                    )
                                        )
                                    )
                                    {
                                        p.PartName = newPart.PartName;
                                        p.PartDescription = newPart.PartDescription;
                                        p.PartPrice = newPart.PartPrice;

                                        if (p.MandatoryPart)
                                        {
                                            ctx.MandatoryPartMap.Remove(p.OriginalItemPartNumber);
                                            ctx.MandatoryPartMap.Remove(p.NewPartNumber);
                                            ctx.MandatoryPartList.Remove(p);
                                        }
                                        else
                                        {
                                            ctx.NonMandatoryPartMap.Remove(p.OriginalItemPartNumber);
                                            ctx.NonMandatoryPartMap.Remove(p.NewPartNumber);
                                            ctx.NonMandatoryPartList.Remove(p);
                                        }

                                        p.OriginalItemPartNumber = newPart.OriginalItemPartNumber;
                                        p.NewPartNumber = newPart.NewPartNumber;
                                        p.MandatoryPart = newPart.MandatoryPart;

                                        if (p.MandatoryPart)
                                        {
                                            ctx.MandatoryPartMap[p.OriginalItemPartNumber] = p;
                                            ctx.MandatoryPartMap[p.NewPartNumber] = p;
                                            ctx.MandatoryPartList.Add(p);
                                        }
                                        else
                                        {
                                            ctx.NonMandatoryPartMap[p.OriginalItemPartNumber] = p;
                                            ctx.NonMandatoryPartMap[p.NewPartNumber] = p;
                                            ctx.NonMandatoryPartList.Add(p);
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            MainProgramCode.ShowError(Messages.CsvBatchImportErrorText, Messages.CsvBatchImportErrorCaption);
                            return;
                        }

                        var newProductPartList = new BindingList<Product_Part>();

                        var product = new Product(
                            readFields[7].Trim(), 
                            "", 
                            QuoteSwiftMainCode.ParseFloat(readFields[8].Trim()), 
                            ref newProductPartList
                        );

                        if (ctx.ProductMap.TryGetValue(product.ProductName, out var prod))
                        {
                            if (prod.PartList.All(
                                    part => part.ProductPart.OriginalItemPartNumber != newPart.OriginalItemPartNumber &&
                                            part.ProductPart.NewPartNumber != newPart.NewPartNumber &&
                                            part.ProductPart.OriginalItemPartNumber != newPart.NewPartNumber &&
                                            part.ProductPart.NewPartNumber != newPart.OriginalItemPartNumber
                                    )
                            )
                            {
                                prod.PartList.Add(
                                    new Product_Part(
                                        newPart,
                                        int.Parse(readFields[5].Trim())
                                    )
                                );
                                prod.NewProductPrice = QuoteSwiftMainCode.ParseFloat(readFields[8].Trim());
                            }
                        }
                        else
                        {
                            product.PartList.Add(
                                new Product_Part(
                                    newPart,
                                    int.Parse(readFields[5].Trim())
                                )
                            );
                            ctx.ProductMap[product.ProductName] = product;
                        }
                    }
                    MainProgramCode.ShowInformation(Messages.CsvBatchImportSuccessText, Messages.CsvBatchImportSuccessCaption);
                }
            }
            else return;

            if (ctx.ChangeSpecificObject)
            {
                ctx.PartToChange = null;
                ctx.ChangeSpecificObject = false;
            }
            
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
