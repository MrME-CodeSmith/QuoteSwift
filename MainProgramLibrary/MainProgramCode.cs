using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public static byte[] SerializePartList(Dictionary<string, Part> PartList)
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

        // Serialize Mandatory Part List Method

        public static void SerializeMandatoryPartList(ref Pass passed)
        {
            //Determine if Mandatory Parts exist:

            if (passed != null && passed.PassMandatoryPartList != null && passed.PassMandatoryPartList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePartList(passed.PassMandatoryPartList);
                MainProgramCode.SaveData("MandatoryParts.json", ToStore);
            }
        }

        // Serialize Non-Mandatory Part List Method

        public static void SerializeNonMandatoryPartList(ref Pass passed)
        {
            //Determine if Non-Mandatory Parts exist:

            if (passed != null && passed.PassNonMandatoryPartList != null && passed.PassNonMandatoryPartList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePartList(passed.PassNonMandatoryPartList);
                MainProgramCode.SaveData("NonMandatoryParts.json", ToStore);
            }
        }

        // Serialize Pump List Method

        public static byte[] SerializePumpList(BindingList<Pump> PumpPartList)
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

        // Serialize and Store Pump List Method

        public static void SerializePumpList(ref Pass passed)
        {
            //Determine if Pump List exist:

            if (passed != null && passed.PassPumpList != null && passed.PassPumpList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePumpList(passed.PassPumpList);
                MainProgramCode.SaveData("PumpList.json", ToStore);
            }
        }


        // Serialize Business List Method

        public static byte[] SerializeBusinessList(BindingList<Business> BusinessList)
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

        // Serialize and Store Business List Method

        public static void SerializeBusinessList(ref Pass passed)
        {
            //Determine if Pump List exist:

            if (passed != null && passed.PassBusinessList != null && passed.PassBusinessList.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeBusinessList(passed.PassBusinessList);
                MainProgramCode.SaveData("BusinessList.json", ToStore);
            }
        }

        // Serialize Quote List Method

        public static byte[] SerializeQuoteList(SortedDictionary<string, Quote> QuoteList)
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

        // Serialize and Store Quote List Method

        public static void SerializeQuoteList(ref Pass passed)
        {
            //Determine if Pump List exist:

            if (passed != null && passed.PassQuoteMap != null && passed.PassQuoteMap.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeQuoteList(passed.PassQuoteMap);
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

        



        //Procedure Handling The Closing Of The Application
        public static void CloseApplication(bool exitApp, ref Pass passed)
        {
            if (exitApp)
            {
                try
                {
                    SerializeMandatoryPartList(ref passed);
                    SerializeNonMandatoryPartList(ref passed);
                    SerializePumpList(ref passed);
                    SerializeBusinessList(ref passed);
                    SerializeQuoteList(ref passed);
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
