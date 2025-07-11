using QuoteSwift;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ExportToExcel
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Quote NewQuote = null;
            try
            {
                
                string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                if (StorePath.Contains("\\ExportToExcel")) StorePath += "\\ExportQuote.json"; else StorePath += "\\ExportToExcel\\ExportQuote.json";

                if (File.Exists(StorePath))
                {
                    string json = File.ReadAllText(StorePath);
                    NewQuote = JsonConvert.DeserializeObject<Quote>(json);
                }
                else return;
            } 
            catch (Exception ex)
            {
                while (ex != null)
                {
                    MainProgramCode.ShowError(ex.Message, "ERROR Exists");
                    ex = ex.InnerException;
                }
                throw;
            }

            if (NewQuote != null)
            {
                Microsoft.Office.Interop.Excel.Application ExcellContainer = null;
                Microsoft.Office.Interop.Excel.Workbook MyWorkBook = null;
                Microsoft.Office.Interop.Excel.Worksheet MyWorkSheet = null;
                try
                {

                    try
                    {
                        ExcellContainer = new Microsoft.Office.Interop.Excel.Application();
                    }
                    catch
                    {
                        //do nothing
                    }

                    if (ExcellContainer == null)
                    {
                        MainProgramCode.ShowError("Excel is not installed on this machine.", "ERROR - Excel Export Failed");
                        return;
                    }

                    MyWorkBook = ExcellContainer.Workbooks.Open(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\QuoteTemplate.xlsx");
                    MyWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)MyWorkBook.Worksheets["Sheet1"];

                    //Business Details:

                    MyWorkSheet.Cells.Replace("<<Business Name>>", NewQuote.QuoteCompany.BusinessName);
                    MyWorkSheet.Cells.Replace("<<POBox Number>>", "P.O.BOX " + NewQuote.QuoteBusinessPOBox.AddressStreetNumber);
                    MyWorkSheet.Cells.Replace("<<POBox Suburb>>", NewQuote.QuoteBusinessPOBox.AddressSuburb);
                    MyWorkSheet.Cells.Replace("<<POBox City>>", NewQuote.QuoteBusinessPOBox.AddressCity);
                    MyWorkSheet.Cells.Replace("<<Registration Number>>", NewQuote.QuoteCompany.BusinessLegalDetails.RegistrationNumber);
                    MyWorkSheet.Cells.Replace("<<VAT Number>>", NewQuote.QuoteCompany.BusinessLegalDetails.VatNumber);
                    MyWorkSheet.Cells.Replace("<<Telephone>>", NewQuote.Telefone);
                    MyWorkSheet.Cells.Replace("<<CellPhone>>", NewQuote.Cellphone);
                    MyWorkSheet.Cells.Replace("<<Email>>", NewQuote.Email);

                    //Quote Details:

                    MyWorkSheet.Cells.Replace("<<Quote Number>>", NewQuote.QuoteNumber);
                    MyWorkSheet.Cells.Replace("<<Creation Date>>", NewQuote.QuoteCreationDate.Date.ToString());
                    MyWorkSheet.Cells.Replace("<<Expire Date>>", NewQuote.QuoteExpireyDate.Date.ToString());

                    //Client POBox:

                    MyWorkSheet.Cells.Replace("<<Customer POBox Desc>>", NewQuote.QuoteCustomer.CustomerCompanyName);
                    MyWorkSheet.Cells.Replace("<<Customer POBox Number>>", "PRIVATE BAG X" + NewQuote.QuoteCustomerPOBox.AddressStreetNumber);
                    MyWorkSheet.Cells.Replace("<<Customer POBox Suburb>>", NewQuote.QuoteCustomerPOBox.AddressSuburb);
                    MyWorkSheet.Cells.Replace("<<Customer POBox AreaCode>>", NewQuote.QuoteCustomerPOBox.AddressAreaCode.ToString());
                    MyWorkSheet.Cells.Replace("<<Vendor Number>>", NewQuote.QuoteCustomer.VendorNumber);
                    MyWorkSheet.Cells.Replace("<<Delivery Details>>", NewQuote.QuoteDeliveryAddress);
                    MyWorkSheet.Cells.Replace("<<CVAT>>", NewQuote.QuoteCustomer.CustomerLegalDetails.VatNumber);

                    //Other:

                    MyWorkSheet.Cells.Replace("<<Ref>>", NewQuote.QuoteReference);
                    MyWorkSheet.Cells.Replace("<<JN>>", NewQuote.QuoteJobNumber);
                    MyWorkSheet.Cells.Replace("<<PRN>>", NewQuote.QuotePRNumber);
                    MyWorkSheet.Cells.Replace("<<LNo>>", NewQuote.QuoteLineNumber);
                    MyWorkSheet.Cells.Replace("<<NETTDAYS>>", NewQuote.NetDays.ToString());
                    MyWorkSheet.Cells.Replace("<<Pump Name>>", NewQuote.PumpName.ToString());

                    //Pricing:

                    MyWorkSheet.Cells.Replace("<<Machine>>", NewQuote.QuoteCost.Machining.ToString());
                    MyWorkSheet.Cells.Replace("<<Labour>>", NewQuote.QuoteCost.Labour.ToString());
                    MyWorkSheet.Cells.Replace("<<Consum>>", NewQuote.QuoteCost.Consumables.ToString());
                    MyWorkSheet.Cells.Replace("<<Rebate>>", NewQuote.QuoteCost.Rebate.ToString());
                    MyWorkSheet.Cells.Replace("<<Sub Total>>", NewQuote.QuoteCost.SubTotal.ToString());
                    MyWorkSheet.Cells.Replace("<<VAT>>", NewQuote.QuoteCost.VAT.ToString());
                    MyWorkSheet.Cells.Replace("<<Total>>", NewQuote.QuoteCost.TotalDue.ToString());
                    MyWorkSheet.Cells.Replace("<<NPP>>", "R" + NewQuote.QuoteNewUnitPrice.ToString());
                    MyWorkSheet.Cells.Replace("<<RP>>", NewQuote.QuoteRepairPercentage.ToString() + "%");

                    /** Mandatory Parts */

                    int CurrentRow = MyWorkSheet.Cells.Find("<<Mandatory Begin>>").Row + 1;

                    // Adding Rows:
                    for (int i = 0; i < NewQuote.QuoteMandatoryPartList.Count - 3; i++)
                    {
                        Microsoft.Office.Interop.Excel.Range range = MyWorkSheet.get_Range("A" + CurrentRow.ToString(), "L" + CurrentRow.ToString()).EntireRow;
                        range.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                        MyWorkSheet.get_Range("B" + CurrentRow.ToString() + ":D" + CurrentRow.ToString()).Merge();
                        MyWorkSheet.get_Range("J" + CurrentRow.ToString() + ":K" + CurrentRow.ToString()).Merge();
                        CurrentRow++;
                    }


                    // Populating Mandatory Rows:
                    CurrentRow = MyWorkSheet.Cells.Find("<<Mandatory Begin>>").Row;
                    for (int i = 0; i < NewQuote.QuoteMandatoryPartList.Count; i++)
                    {
                        MyWorkSheet.Cells[CurrentRow, 1].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                        MyWorkSheet.Cells[CurrentRow, 2].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                        MyWorkSheet.Cells[CurrentRow, 5].Value2 = NewQuote.QuoteMandatoryPartList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 6].Value2 = NewQuote.QuoteMandatoryPartList[i].MissingorScrap.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 7].Value2 = NewQuote.QuoteMandatoryPartList[i].Repaired.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 8].Value2 = NewQuote.QuoteMandatoryPartList[i].New.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 9].Value2 = NewQuote.QuoteMandatoryPartList[i].Price.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 10].Value2 = NewQuote.QuoteMandatoryPartList[i].UnitPrice.ToString() ?? "0";
                        CurrentRow++;
                    }

                    /** Non-Mandatory Parts */

                    CurrentRow = MyWorkSheet.Cells.Find("<<Non Mandatory Begin>>").Row + 1;

                    // Adding Rows:
                    for (int i = 0; i < NewQuote.QuoteNewList.Count - 3; i++)
                    {
                        Microsoft.Office.Interop.Excel.Range range = MyWorkSheet.get_Range("A" + CurrentRow.ToString(), "L" + CurrentRow.ToString()).EntireRow;
                        range.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                        MyWorkSheet.get_Range("B" + CurrentRow.ToString() + ":D" + CurrentRow.ToString()).Merge();
                        MyWorkSheet.get_Range("J" + CurrentRow.ToString() + ":K" + CurrentRow.ToString()).Merge();
                        CurrentRow++;
                    }


                    // Populating Non-Mandatory Rows:
                    CurrentRow = MyWorkSheet.Cells.Find("<<Non Mandatory Begin>>").Row;
                    for (int i = 0; i < NewQuote.QuoteNewList.Count; i++)
                    {
                        MyWorkSheet.Cells[CurrentRow, 1].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                        MyWorkSheet.Cells[CurrentRow, 2].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                        MyWorkSheet.Cells[CurrentRow, 5].Value2 = NewQuote.QuoteNewList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 6].Value2 = NewQuote.QuoteNewList[i].MissingorScrap.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 7].Value2 = NewQuote.QuoteNewList[i].Repaired.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 8].Value2 = NewQuote.QuoteNewList[i].New.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 9].Value2 = NewQuote.QuoteNewList[i].Price.ToString() ?? "0";
                        MyWorkSheet.Cells[CurrentRow, 10].Value2 = NewQuote.QuoteNewList[i].UnitPrice.ToString() ?? "0";
                        CurrentRow++;
                    }

                    //Saving Template File with Quote Number as File Name
                    SaveFileDialog sfdSaveExport;
                    using (sfdSaveExport = new SaveFileDialog())
                    {
                        sfdSaveExport.FileName = NewQuote.QuoteNumber;
                        if (sfdSaveExport.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                MyWorkBook.SaveAs(sfdSaveExport.FileName);
                            }
                            catch
                            {
                                DialogResult dr = MessageBox.Show("The exported quote needs to be saved but the file it needs to save to seems to be already opened.\n" +
                                                                  "Please close the file then click the 'OK' button or alternatively click the 'Cancel' button to stop the quote from being exported.",
                                                                  "Quote Excel Workbook Already Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                                if (dr != DialogResult.OK)
                                {
                                    MainProgramCode.ShowError("Quote could not export correctly.\nQuote Export Canceled", "ERROR - Quote Not Exported");
                                    return;
                                }
                            }
                            MainProgramCode.ShowInformation("Excel file created and stored at selected location.", "INFORMATION - Quote Stored Successfully");
                        }
                        else return;

                    }


                }
                catch
                {
                    string FilePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\QuoteTemplate.xlsx";
                    string NewFilePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\QuoteTemplateBUP.xlsx";
                    if (FilePath.Length > 20 && NewFilePath.Length > 23)
                    {
                        MyWorkBook.Close();
                        ExcellContainer.Quit();
                        Marshal.ReleaseComObject(MyWorkSheet);
                        Marshal.ReleaseComObject(MyWorkBook);
                        Marshal.ReleaseComObject(ExcellContainer);

                        System.IO.File.Delete(FilePath);
                        System.IO.File.Copy(NewFilePath, FilePath);

                        //return;
                    }
                    else
                    {
                        MainProgramCode.ShowError("The template file needed to export the quote cannot be found.\nQuote was created successfully but the exportation of the quote was unsuccessful.", "ERROR - Template File Missing");
                    }

                }
                finally
                {
                    MyWorkBook.Close();
                    ExcellContainer.Quit();
                    Marshal.ReleaseComObject(MyWorkSheet);
                    Marshal.ReleaseComObject(MyWorkBook);
                    Marshal.ReleaseComObject(ExcellContainer);
                }

                string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ExportQuote.json";
                if (File.Exists(StorePath)) File.Delete(StorePath);
            }

        }
    }
}
