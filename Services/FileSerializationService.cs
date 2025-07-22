using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QuoteSwift
{
    public class FileSerializationService : ISerializationService
    {
        public void SerializePartList(Dictionary<string, Part> partList)
        {
            if (partList != null && partList.Count > 0)
            {
                byte[] data = SerializePartListData(partList);
                SaveData("Parts.json", data);
            }
        }

        public void SerializePumpList(BindingList<Pump> pumpList)
        {
            if (pumpList != null && pumpList.Count > 0)
            {
                byte[] data = SerializePumpListData(pumpList);
                SaveData("PumpList.json", data);
            }
        }

        public void SerializeBusinessList(BindingList<Business> businessList)
        {
            if (businessList != null && businessList.Count > 0)
            {
                byte[] data = SerializeBusinessListData(businessList);
                SaveData("BusinessList.json", data);
            }
        }

        public void SerializeQuoteList(SortedDictionary<string, Quote> quoteList)
        {
            if (quoteList != null && quoteList.Count > 0)
            {
                byte[] data = SerializeQuoteListData(quoteList);
                SaveData("QuoteList.json", data);
            }
        }

        public void ExportInventory(BindingList<Pump> pumpList, string filePath)
        {
            ExportInventoryCsv(pumpList, filePath);
        }

        public void CloseApplication(bool exitApp,
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
                        ex = ex.InnerException;
                    }
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Static helpers
        public static byte[] SerializePartListData(Dictionary<string, Part> list)
        {
            return JsonSerialize(list);
        }

        public static Dictionary<string, Part> DeserializePartList(byte[] data)
        {
            return JsonDeserialize<Dictionary<string, Part>>(data);
        }

        public static byte[] SerializePumpListData(BindingList<Pump> list)
        {
            return JsonSerialize(list);
        }

        public static BindingList<Pump> DeserializePumpList(byte[] data)
        {
            return JsonDeserialize<BindingList<Pump>>(data);
        }

        public static byte[] SerializeBusinessListData(BindingList<Business> list)
        {
            return JsonSerialize(list);
        }

        public static BindingList<Business> DeserializeBusinessList(byte[] data)
        {
            return JsonDeserialize<BindingList<Business>>(data);
        }

        public static byte[] SerializeQuoteListData(SortedDictionary<string, Quote> list)
        {
            return JsonSerialize(list);
        }

        public static SortedDictionary<string, Quote> DeserializeQuoteList(byte[] data)
        {
            return JsonDeserialize<SortedDictionary<string, Quote>>(data);
        }

        public static void ExportInventoryCsv(BindingList<Pump> pumpList, string filePath)
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

        static string CsvEscape(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Contains("\"")) value = value.Replace("\"", "\"\"");
            if (value.Contains(",") || value.Contains("\n") || value.Contains("\r"))
                return $"\"{value}\"";
            return value;
        }

        public static bool SaveData(string fileName, byte[] data)
        {
            string storePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;

            try
            {
                if (File.Exists(storePath)) File.Delete(storePath);
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(storePath)))
                {
                    writer.Write(data);
                    writer.Flush();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static byte[] RetrieveData(string fileName)
        {
            string storePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;
            try
            {
                return File.ReadAllBytes(storePath);
            }
            catch (FileNotFoundException)
            {
            }
            catch
            {
                throw;
            }
            return null;
        }

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
    }
}
