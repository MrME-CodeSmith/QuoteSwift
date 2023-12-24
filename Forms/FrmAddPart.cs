using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using ToastNotifications;
using ToastNotifications.Position;
using System.Net.Http;
using QuoteSwift.Controllers;

namespace QuoteSwift
{
    public partial class FrmAddPart : Form
    {
        private readonly FrmAddPartController mFrmAddPartController;

        public FrmAddPart()
        {
            InitializeComponent();
            mFrmAddPartController = new FrmAddPartController();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation(Messages.TerminationRequestText, Messages.TerminationRequestCaption))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Product selectedProduct = null;
            if (cbAddToProductSelection.SelectedIndex != -1)
            {
                var ProductSelection = (Product)cbAddToProductSelection.SelectedItem;

            }

            if(
                mFrmAddPartController.AddPartHandler(
                    partName: mtxtPartName.Text,
                    partDescription: mtxtPartDescription.Text,
                    originalPartNumber: mtxtOriginalPartNumber.Text,
                    newPartNumber: mtxtNewPartNumber.Text,
                    partPrice: mtxtPartPrice.Text,
                    isMandatory: cbxMandatoryPart.Checked,
                    selectedProd: selectedProduct
                )
            ) Close();
        }

        private void FrmAddPart_Activated(object sender, EventArgs e)
        {

        }

        private void LoadPartBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load a CSV file and add the items to the appropriate list

            var MessageBoxResult = MessageBox.Show(
                Messages.CsvBatchImportInformationText, 
                Messages.CsvBatchImportInformationCaption, 
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

                        var newProductPartList = new BindingList<ProductPart>();

                        var product = new Product(
                            readFields[7].Trim(), 
                            "", 
                            QuoteSwiftMainCode.ParseFloat(readFields[8].Trim()), 
                            ref newProductPartList
                        );

                        if (ctx.ProductMap.TryGetValue(product.ProductName, out var prod))
                        {
                            if (prod.PartList.All(
                                    part => part.Part.OriginalItemPartNumber != newPart.OriginalItemPartNumber &&
                                            part.Part.NewPartNumber != newPart.NewPartNumber &&
                                            part.Part.OriginalItemPartNumber != newPart.NewPartNumber &&
                                            part.Part.NewPartNumber != newPart.OriginalItemPartNumber
                                    )
                            )
                            {
                                prod.PartList.Add(
                                    new ProductPart(
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
                                new ProductPart(
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
            if (MainProgramCode.RequestConfirmation(Messages.ScreenDefaultValueRequestText, Messages.ScreenDefaultValueRequestCaption))
            {
                ClearInput();
                NudQuantity.Enabled = false;
                cbxMandatoryPart.Checked = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation(Messages.ActionCancelRequestText, Messages.ActionCancelRequestCaption)) 
                Close();
        }

        private void FrmAddPart_Load(object sender, EventArgs e)
        {
            var ctx = Global.Context;

            if (ctx.ProductMap.Values.Count > 0)
            {
                cbAddToProductSelection.DataSource = new BindingSource { DataSource = ctx.ProductMap.Values };

                cbAddToProductSelection.DisplayMember = "ProductName";
                cbAddToProductSelection.ValueMember = "ProductName";
            }

            // Determine is an item is to be edited / added.

            if (ctx.ChangeSpecificObject && ctx.PartToChange != null)
            {
                //Updating 
                LoadPartData();
                ReadWriteComponents();
                btnAddPart.Text = "Update";
                updatePartToolStripMenuItem.Enabled = false;
            }
            else if (!ctx.ChangeSpecificObject && ctx.PartToChange != null)
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

        

        private void LoadPartData()
        {
            var ctx = Global.Context;
            mtxtPartName.Text = ctx.PartToChange.PartName;
            mtxtPartDescription.Text = ctx.PartToChange.PartDescription;
            mtxtOriginalPartNumber.Text = ctx.PartToChange.OriginalItemPartNumber;
            mtxtNewPartNumber.Text = ctx.PartToChange.NewPartNumber;
            mtxtPartPrice.Text = ctx.PartToChange.PartPrice.ToString(CultureInfo.CurrentCulture);
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
            var ctx = Global.Context;
            if (!ctx.ChangeSpecificObject && MainProgramCode.RequestConfirmation(Messages.UpdatePartRequestText, Messages.UpdatePartRequestCaption))
            {
                ReadWriteComponents();
                updatePartToolStripMenuItem.Enabled = false;
                ctx.ChangeSpecificObject = true;
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
