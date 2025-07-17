using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuoteSwift
{
    public class FileExcelExportService : IExcelExportService
    {
        readonly IMessageService messageService;

        public FileExcelExportService(IMessageService messenger = null)
        {
            messageService = messenger;
        }

        [STAThread]
        public void ExportQuoteToExcel(Quote quote)
        {
            if (quote == null) return;

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                try
                {
                    excelApp = new Excel.Application();
                }
                catch
                {
                    // ignored
                }

                if (excelApp == null)
                {
                    messageService?.ShowError("Excel is not installed on this machine.", "ERROR - Excel Export Failed");
                    return;
                }

                workbook = excelApp.Workbooks.Open(Path.GetDirectoryName(Application.ExecutablePath) + "\\QuoteTemplate.xlsx");
                worksheet = (Excel.Worksheet)workbook.Worksheets["Sheet1"];

                // Business Details
                worksheet.Cells.Replace("<<Business Name>>", quote.QuoteCompany.BusinessName);
                worksheet.Cells.Replace("<<POBox Number>>", "P.O.BOX " + quote.QuoteBusinessPOBox.AddressStreetNumber);
                worksheet.Cells.Replace("<<POBox Suburb>>", quote.QuoteBusinessPOBox.AddressSuburb);
                worksheet.Cells.Replace("<<POBox City>>", quote.QuoteBusinessPOBox.AddressCity);
                if (quote.QuoteCompany.BusinessLegalDetails != null)
                {
                    worksheet.Cells.Replace("<<Registration Number>>", quote.QuoteCompany.BusinessLegalDetails.RegistrationNumber ?? string.Empty);
                    worksheet.Cells.Replace("<<VAT Number>>", quote.QuoteCompany.BusinessLegalDetails.VatNumber ?? string.Empty);
                }
                else
                {
                    worksheet.Cells.Replace("<<Registration Number>>", string.Empty);
                    worksheet.Cells.Replace("<<VAT Number>>", string.Empty);
                }
                worksheet.Cells.Replace("<<Telephone>>", quote.Telefone);
                worksheet.Cells.Replace("<<CellPhone>>", quote.Cellphone);
                worksheet.Cells.Replace("<<Email>>", quote.Email);

                // Quote Details
                worksheet.Cells.Replace("<<Quote Number>>", quote.QuoteNumber);
                worksheet.Cells.Replace("<<Creation Date>>", quote.QuoteCreationDate.Date.ToString());
                worksheet.Cells.Replace("<<Expire Date>>", quote.QuoteExpireyDate.Date.ToString());

                // Client POBox
                worksheet.Cells.Replace("<<Customer POBox Desc>>", quote.QuoteCustomer.CustomerCompanyName);
                worksheet.Cells.Replace("<<Customer POBox Number>>", "PRIVATE BAG X" + quote.QuoteCustomerPOBox.AddressStreetNumber);
                worksheet.Cells.Replace("<<Customer POBox Suburb>>", quote.QuoteCustomerPOBox.AddressSuburb);
                worksheet.Cells.Replace("<<Customer POBox AreaCode>>", quote.QuoteCustomerPOBox.AddressAreaCode.ToString());
                worksheet.Cells.Replace("<<Vendor Number>>", quote.QuoteCustomer.VendorNumber);
                worksheet.Cells.Replace("<<Delivery Details>>", quote.QuoteDeliveryAddress);
                worksheet.Cells.Replace("<<CVAT>>", quote.QuoteCustomer.CustomerLegalDetails.VatNumber);

                // Other
                worksheet.Cells.Replace("<<Ref>>", quote.QuoteReference);
                worksheet.Cells.Replace("<<JN>>", quote.QuoteJobNumber);
                worksheet.Cells.Replace("<<PRN>>", quote.QuotePRNumber);
                worksheet.Cells.Replace("<<LNo>>", quote.QuoteLineNumber);
                worksheet.Cells.Replace("<<NETTDAYS>>", quote.NetDays.ToString());
                worksheet.Cells.Replace("<<Pump Name>>", quote.PumpName.ToString());

                // Pricing
                worksheet.Cells.Replace("<<Machine>>", quote.QuoteCost.Machining.ToString());
                worksheet.Cells.Replace("<<Labour>>", quote.QuoteCost.Labour.ToString());
                worksheet.Cells.Replace("<<Consum>>", quote.QuoteCost.Consumables.ToString());
                worksheet.Cells.Replace("<<Rebate>>", quote.QuoteCost.Rebate.ToString());
                worksheet.Cells.Replace("<<Sub Total>>", quote.QuoteCost.SubTotal.ToString());
                worksheet.Cells.Replace("<<VAT>>", quote.QuoteCost.VAT.ToString());
                worksheet.Cells.Replace("<<Total>>", quote.QuoteCost.TotalDue.ToString());
                worksheet.Cells.Replace("<<NPP>>", "R" + quote.QuoteNewUnitPrice.ToString());
                worksheet.Cells.Replace("<<RP>>", quote.QuoteRepairPercentage.ToString() + "%");

                // Mandatory Parts
                int currentRow = worksheet.Cells.Find("<<Mandatory Begin>>").Row + 1;
                for (int i = 0; i < quote.QuoteMandatoryPartList.Count; i++)
                {
                    worksheet.Cells[currentRow, 1].Value2 = quote.QuoteMandatoryPartList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                    worksheet.Cells[currentRow, 2].Value2 = quote.QuoteMandatoryPartList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                    worksheet.Cells[currentRow, 5].Value2 = quote.QuoteMandatoryPartList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                    worksheet.Cells[currentRow, 6].Value2 = quote.QuoteMandatoryPartList[i].MissingorScrap.ToString() ?? "0";
                    worksheet.Cells[currentRow, 7].Value2 = quote.QuoteMandatoryPartList[i].Repaired.ToString() ?? "0";
                    worksheet.Cells[currentRow, 8].Value2 = quote.QuoteMandatoryPartList[i].New.ToString() ?? "0";
                    worksheet.Cells[currentRow, 9].Value2 = quote.QuoteMandatoryPartList[i].Price.ToString() ?? "0";
                    worksheet.Cells[currentRow, 10].Value2 = quote.QuoteMandatoryPartList[i].UnitPrice.ToString() ?? "0";
                    currentRow++;
                }

                // Non-Mandatory Parts
                currentRow = worksheet.Cells.Find("<<Non Mandatory Begin>>").Row + 1;
                for (int i = 0; i < quote.QuoteNewList.Count - 3; i++)
                {
                    Excel.Range range = worksheet.get_Range("A" + currentRow.ToString(), "L" + currentRow.ToString()).EntireRow;
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    worksheet.get_Range("B" + currentRow.ToString() + ":D" + currentRow.ToString()).Merge();
                    worksheet.get_Range("J" + currentRow.ToString() + ":K" + currentRow.ToString()).Merge();
                    currentRow++;
                }

                currentRow = worksheet.Cells.Find("<<Non Mandatory Begin>>").Row;
                for (int i = 0; i < quote.QuoteNewList.Count; i++)
                {
                    worksheet.Cells[currentRow, 1].Value2 = quote.QuoteNewList[i].PumpPart.PumpPart.NewPartNumber ?? "NPN";
                    worksheet.Cells[currentRow, 2].Value2 = quote.QuoteNewList[i].PumpPart.PumpPart.PartDescription ?? "NO DESCRIPTION";
                    worksheet.Cells[currentRow, 5].Value2 = quote.QuoteNewList[i].PumpPart.PumpPartQuantity.ToString() ?? "0";
                    worksheet.Cells[currentRow, 6].Value2 = quote.QuoteNewList[i].MissingorScrap.ToString() ?? "0";
                    worksheet.Cells[currentRow, 7].Value2 = quote.QuoteNewList[i].Repaired.ToString() ?? "0";
                    worksheet.Cells[currentRow, 8].Value2 = quote.QuoteNewList[i].New.ToString() ?? "0";
                    worksheet.Cells[currentRow, 9].Value2 = quote.QuoteNewList[i].Price.ToString() ?? "0";
                    worksheet.Cells[currentRow, 10].Value2 = quote.QuoteNewList[i].UnitPrice.ToString() ?? "0";
                    currentRow++;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = quote.QuoteNumber;
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            workbook.SaveAs(saveDialog.FileName);
                        }
                        catch
                        {
                            DialogResult dr = MessageBox.Show(
                                "The exported quote needs to be saved but the file it needs to save to seems to be already opened.\n" +
                                "Please close the file then click the 'OK' button or alternatively click the 'Cancel' button to stop the quote from being exported.",
                                "Quote Excel Workbook Already Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                            if (dr != DialogResult.OK)
                            {
                                messageService?.ShowError("Quote could not export correctly.\nQuote Export Canceled", "ERROR - Quote Not Exported");
                                return;
                            }
                        }
                        messageService?.ShowInformation("Excel file created and stored at selected location.", "INFORMATION - Quote Stored Successfully");
                    }
                    else return;
                }
            }
            catch
            {
                string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\QuoteTemplate.xlsx";
                string backupPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\QuoteTemplateBUP.xlsx";
                if (filePath.Length > 20 && backupPath.Length > 23)
                {
                    if (workbook != null) workbook.Close();
                    if (excelApp != null) excelApp.Quit();
                    if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                    if (workbook != null) Marshal.ReleaseComObject(workbook);
                    if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                    File.Delete(filePath);
                    File.Copy(backupPath, filePath);
                }
                else
                {
                    messageService?.ShowError("The template file needed to export the quote cannot be found.\nQuote was created successfully but the exportation of the quote was unsuccessful.", "ERROR - Template File Missing");
                }
            }
            finally
            {
                if (workbook != null) workbook.Close();
                if (excelApp != null) excelApp.Quit();
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
