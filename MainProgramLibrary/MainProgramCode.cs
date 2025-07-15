using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;

using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;


namespace QuoteSwift
{
    public static class MainProgramCode
    {
        //Get Last Quote

        public static Quote GetLastQuote(ref Pass passed)
        {
            if (passed != null && passed.PassQuoteMap != null && passed.PassQuoteMap.Count > 0)
            {
                Quote latest = passed.PassQuoteMap.First().Value;
                DateTime dt = latest.QuoteCreationDate;

                foreach (var quote in passed.PassQuoteMap.Values.Skip(1))
                {
                    if (quote.QuoteCreationDate.Date > dt)
                    {
                        dt = quote.QuoteCreationDate.Date;
                        latest = quote;
                    }
                }

                return latest;
            }

            return null;
        }

        /** Message Box Custom Functions */



        //Confirmation Request:

        public static bool RequestConfirmation(string text, string caption)
        {
            DialogResult MessageBoxResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return MessageBoxResult == DialogResult.Yes;
        }

        public static void ShowError(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /*********************************/


        /** Serialization Methods: */

        //Read file into byte Array

        public static byte[] RetreiveData(string FileName)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + FileName;
            byte[] Data = null;
            try
            {
                Data = File.ReadAllBytes(StorePath);
                return Data;
            }
            catch (FileNotFoundException)
            {
                if (FileName != "ExportQuote.json")
                    if (MainProgramCode.RequestConfirmation(FileName + " could not be found.\nWould you like to continue the execution? (Recommended for first launch)", "REQUEST - Execution Continuation")) return Data;
                MainProgramCode.ShowError(FileName + " Could not be found, please contact the developer to fix this issue.", "ERROR - " + FileName + " Not Found");
                
            }
            catch
            {
                throw;
            }

            return null;
        }


        //Store Byte Array to Directory

        public static bool SaveData(string FileName, byte[] StoreData)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + FileName;

            try
            {
                if (File.Exists(StorePath)) File.Delete(StorePath);
                BinaryWriter FileWriter = new BinaryWriter(File.OpenWrite(StorePath));
                FileWriter.Write(StoreData);
                FileWriter.Flush();
                FileWriter.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Serialize to JSON

        public static byte[] JsonSerialize<T>(T record) where T : class
        {
            if (record == null) return null;

            try
            {
                string json = JsonConvert.SerializeObject(record);
                return Encoding.UTF8.GetBytes(json);
            }
            catch
            {
                throw;
            }
        }

        // De-serialize from JSON

        public static T JsonDeserialize<T>(byte[] data) where T : class
        {
            if (data == null) return null;

            try
            {
                string json = Encoding.UTF8.GetString(data);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                throw;
            }
        }

        //Serialize Part list:

        public static byte[] SerializePartListData(Dictionary<string, Part> PartList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.JsonSerialize<Dictionary<string, Part>>(PartList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        //De-serialize Part list:

        public static Dictionary<string, Part> DeserializePartList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.JsonDeserialize<Dictionary<string, Part>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and store Part List

        public static void SerializePartList(Dictionary<string, Part> partList)
        {
            if (partList != null && partList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePartListData(partList);
                MainProgramCode.SaveData("Parts.json", ToStore);
            }
        }

        // Serialize Pump List Method

        public static byte[] SerializePumpListData(BindingList<Pump> PumpPartList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.JsonSerialize<BindingList<Pump>>(PumpPartList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // De-serialize Pump List Method

        public static BindingList<Pump> DeserializePumpList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.JsonDeserialize<BindingList<Pump>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and store Pump List

        public static void SerializePumpList(BindingList<Pump> pumpList)
        {
            if (pumpList != null && pumpList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePumpListData(pumpList);
                MainProgramCode.SaveData("PumpList.json", ToStore);
            }
        }


        // Serialize Business List Method

        public static byte[] SerializeBusinessListData(BindingList<Business> BusinessList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.JsonSerialize<BindingList<Business>>(BusinessList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // De-serialize Business List Method

        public static BindingList<Business> DeserializeBusinessList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.JsonDeserialize<BindingList<Business>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and store Business List

        public static void SerializeBusinessList(BindingList<Business> businessList)
        {
            if (businessList != null && businessList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeBusinessListData(businessList);
                MainProgramCode.SaveData("BusinessList.json", ToStore);
            }
        }

        // Serialize Quote List Method

        public static byte[] SerializeQuoteListData(SortedDictionary<string, Quote> QuoteList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.JsonSerialize<SortedDictionary<string, Quote>>(QuoteList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // De-serialize Quote List Method

        public static SortedDictionary<string, Quote> DeserializeQuoteList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.JsonDeserialize<SortedDictionary<string, Quote>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and store Quote List

        public static void SerializeQuoteList(SortedDictionary<string, Quote> quoteList)
        {
            if (quoteList != null && quoteList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeQuoteListData(quoteList);
                MainProgramCode.SaveData("QuoteList.json", ToStore);
            }
        }

        // Serialize Quote To Export

        public static void ExportQuote(ref Quote q)
        {
            if (q != null)
            {
                byte[] tempByte;
                try
                {
                    tempByte = MainProgramCode.JsonSerialize<Quote>(q);
                }
                catch
                {
                    throw;
                }
                MainProgramCode.SaveData("ExportToExcel\\ExportQuote.json", tempByte);
            }
        }

        // De-serialize Quote To Export To Excel

        /****************************************************/

        public static Quote DeserializeQuote(byte[] tempByte)
        {
            try
            {
                return JsonDeserialize<Quote>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Export pump and part inventory to CSV
        public static void ExportInventory(BindingList<Pump> pumpList, string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("PumpName,PumpDescription,PumpPrice,PartOriginalNumber,PartName,PartDescription,PartNewNumber,PartPrice,Mandatory,Quantity");

                if (pumpList != null)
                {
                    foreach (var pump in pumpList)
                    {
                        if (pump.PartList == null) continue;
                        foreach (var pp in pump.PartList)
                        {
                            var part = pp.PumpPart;
                            writer.WriteLine(string.Join(",",
                                CsvEscape(pump.PumpName),
                                CsvEscape(pump.PumpDescription),
                                pump.NewPumpPrice.ToString(CultureInfo.InvariantCulture),
                                CsvEscape(part?.OriginalItemPartNumber),
                                CsvEscape(part?.PartName),
                                CsvEscape(part?.PartDescription),
                                CsvEscape(part?.NewPartNumber),
                                part?.PartPrice.ToString(CultureInfo.InvariantCulture) ?? string.Empty,
                                part?.MandatoryPart.ToString() ?? string.Empty,
                                pp.PumpPartQuantity.ToString(CultureInfo.InvariantCulture)));
                        }
                    }
                }
            }
        }

        private static string CsvEscape(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Contains("\"")) value = value.Replace("\"", "\"\"");
            if (value.Contains(",") || value.Contains("\n") || value.Contains("\r"))
                return $"\"{value}\"";
            return value;
        }

        



        //Procedure Handling The Closing Of The Application
        public static void CloseApplication(bool exitApp,
            BindingList<Business> businessList,
            BindingList<Pump> pumpList,
            Dictionary<string, Part> partList,
            SortedDictionary<string, Quote> quoteList)
        {
            if (exitApp)
            {
                try
                {
                    SerializePartList(partList);
                    SerializePumpList(pumpList);
                    SerializeBusinessList(businessList);
                    SerializeQuoteList(quoteList);
                }
                catch (Exception ex)
                {
                    while (ex != null)
                    {
                        ShowError(ex.Message, "ERROR Occurred");
                        ex = ex.InnerException;
                    }
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /** Parse String Inputs: */

        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }

        // Parse Decimal:

        public static decimal ParseDecimal(string t)
        {
            decimal.TryParse(t, out decimal temp);
            return temp;
        }

        // Parse Boole:

        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }

        // Parse Int:

        public static int ParseInt(string t)
        {
            int.TryParse(t, out int temp);
            return temp;
        }


        /*************************/

    }
}
