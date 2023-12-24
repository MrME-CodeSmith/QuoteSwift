using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;



namespace QuoteSwift
{
    public static class MainProgramCode
    {
        //Get Last Quote

        public static Quote GetLastQuote()
        {
            if (Global.Context.QuoteMap != null)
            {
                int Index = 0;
                DateTime dt = Global.Context.QuoteMap.Values.ToArray()[0].QuoteCreationDate;
                for (int i = 1; i < Global.Context.QuoteMap.Count; i++)
                    if (Global.Context.QuoteMap.Values.ToArray()[i].QuoteCreationDate.Date > dt)
                    {
                        dt = Global.Context.QuoteMap.Values.ToArray()[i].QuoteCreationDate.Date;
                        Index = i;
                    }
                return Global.Context.QuoteMap.Values.ToArray()[Index];
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

        public static void ShowWarning(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInformation(string text, string caption)
        {
            var toastXml = Windows.UI.Notifications.ToastNotificationManager.GetTemplateContent(Windows.UI.Notifications.ToastTemplateType.ToastImageAndText04);

            // Fill in the text elements
            var stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode(caption));
            stringElements[1].AppendChild(toastXml.CreateTextNode(text));

            // Create the toast and attach event listeners
            var toast = new Windows.UI.Notifications.ToastNotification(toastXml);

            // Show the toast. 
            Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier().Show(toast);
        }


        /*********************************/


        /** Serialization Methods: */

        //Read file into byte Array

        public static byte[] RetreiveData(string fileName)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;
            byte[] Data = null;
            try
            {
                Data = File.ReadAllBytes(StorePath);
                return Data;
            }
            catch (FileNotFoundException)
            {
                if (fileName != "ExportQuote.pbf")
                    if (MainProgramCode.RequestConfirmation(fileName + " could not be found.\nWould you like to continue the execution? (Recommended for first launch)", "REQUEST - Execution Continuation")) return Data;
                MainProgramCode.ShowError(fileName + " Could not be found, please contact the developer to fix this issue.", "ERROR - " + fileName + " Not Found");

            }
            catch
            {
                throw;
            }

            return null;
        }


        //Store Byte Array to Directory

        public static bool SaveData(string fileName, byte[] storeData)
        {
            string StorePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;

            try
            {
                if (File.Exists(StorePath)) File.Delete(StorePath);
                BinaryWriter FileWriter = new BinaryWriter(File.OpenWrite(StorePath));
                FileWriter.Write(storeData);
                FileWriter.Flush();
                FileWriter.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Serialize - Protobuf

        public static byte[] ProtoSerialize<T>(T record) where T : class
        {
            if (null == record) return null;

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, record);
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }

        //De-serialize - Protobuf

        public static T ProtoDeserialize<T>(byte[] data) where T : class
        {
            if (null == data) return null;

            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<T>(stream);
                }
            }
            catch
            {
                throw;
            }
        }

        //Serialize Part list:

        public static byte[] SerializePartList(List<Part> partList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<List<Part>>(partList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        //De-serialize Part list:

        public static BindingList<Part> DeserializePartList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Part>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize Mandatory Part List Method

        public static void SerializeMandatoryPartList()
        {
            //Determine if Mandatory Parts exist:

            if (Global.Context != null && Global.Context.MandatoryPartMap != null && Global.Context.MandatoryPartMap.Count > 0)
            {
                byte[] ToStore = SerializePartList(Global.Context.MandatoryPartMap.Values.ToList());
                SaveData("MandatoryParts.pbf", ToStore);
            }
        }

        // Serialize Non-Mandatory Part List Method

        public static void SerializeNonMandatoryPartList()
        {
            //Determine if Non-Mandatory Parts exist:

            if (Global.Context != null && Global.Context.NonMandatoryPartMap != null && Global.Context.NonMandatoryPartMap.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePartList(Global.Context.NonMandatoryPartMap.Values.ToList());
                MainProgramCode.SaveData("NonMandatoryParts.pbf", ToStore);
            }
        }

        // Serialize Pump List Method

        public static byte[] SerializePumpList(List<Product> pumpPartList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<List<Product>>(pumpPartList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // De-serialize Pump List Method

        public static BindingList<Product> DeserializePumpList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Product>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and Store Pump List Method

        public static void SerializePumpList()
        {
            //Determine if Pump List exist:

            if (Global.Context != null && Global.Context.ProductMap != null && Global.Context.ProductMap.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializePumpList(Global.Context.ProductMap.Values.ToList());
                MainProgramCode.SaveData("PumpList.pbf", ToStore);
            }
        }


        // Serialize Business List Method

        public static byte[] SerializeBusinessList(List<Business> businessList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<List<Business>>(businessList);
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
                return MainProgramCode.ProtoDeserialize<BindingList<Business>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and Store Business List Method

        public static void SerializeBusinessList()
        {
            //Determine if Pump List exist:

            if (Global.Context != null && Global.Context.BusinessMap != null && Global.Context.BusinessMap.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeBusinessList(Global.Context.BusinessMap.Values.ToList());
                MainProgramCode.SaveData("BusinessList.pbf", ToStore);
            }
        }

        // Serialize Quote List Method

        public static byte[] SerializeQuoteList(List<Quote> quoteList)
        {
            byte[] tempByte;
            try
            {
                tempByte = MainProgramCode.ProtoSerialize<List<Quote>>(quoteList);
            }
            catch
            {
                throw;
            }

            return tempByte;
        }

        // De-serialize Quote List Method

        public static BindingList<Quote> DeserializeQuoteList(byte[] tempByte)
        {
            try
            {
                return MainProgramCode.ProtoDeserialize<BindingList<Quote>>(tempByte);
            }
            catch
            {
                return null;
            }
        }

        // Serialize and Store Quote List Method

        public static void SerializeQuoteList()
        {
            //Determine if Pump List exist:

            if (Global.Context != null && Global.Context.QuoteMap != null && Global.Context.QuoteMap.Count > 0)
            {
                byte[] ToStore = MainProgramCode.SerializeQuoteList(Global.Context.QuoteMap.Values.ToList());
                MainProgramCode.SaveData("QuoteList.pbf", ToStore);
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
                    tempByte = MainProgramCode.ProtoSerialize<Quote>(q);
                }
                catch
                {
                    throw;
                }
                MainProgramCode.SaveData("ExportToExcel\\ExportQuote.pbf", tempByte);
            }
        }

        // De-serialize Quote To Export To Excel

        /****************************************************/

        public static Quote DeserializeQuote(byte[] tempByte)
        {
            try
            {
                return ProtoDeserialize<Quote>(tempByte);
            }
            catch
            {
                return null;
            }
        }





        //Procedure Handling The Closing Of The Application
        public static void CloseApplication(bool b)
        {

            MainProgramCode.SerializeMandatoryPartList();

            MainProgramCode.SerializeNonMandatoryPartList();

            MainProgramCode.SerializePumpList();

            MainProgramCode.SerializeBusinessList();

            MainProgramCode.SerializeQuoteList();

            if (b)
            {
                Application.Exit();
            }
        }

        /** Parse String Inputs: */

        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
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
