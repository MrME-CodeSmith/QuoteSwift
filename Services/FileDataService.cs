using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace QuoteSwift
{
    public class FileDataService : IDataService
    {
        readonly IMessageService messageService;

        public FileDataService(IMessageService messenger = null)
        {
            messageService = messenger;
        }

        public Dictionary<string, Part> LoadPartList()
        {
            byte[] bytes = RetrieveData("Parts.json");
            return bytes != null && bytes.Length > 0 ? MainProgramCode.DeserializePartList(bytes) : new Dictionary<string, Part>();
        }

        public BindingList<Pump> LoadPumpList()
        {
            byte[] bytes = RetrieveData("PumpList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Pump>(MainProgramCode.DeserializePumpList(bytes)) : new BindingList<Pump>();
        }

        public BindingList<Business> LoadBusinessList()
        {
            byte[] bytes = RetrieveData("BusinessList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Business>(MainProgramCode.DeserializeBusinessList(bytes)) : new BindingList<Business>();
        }

        public SortedDictionary<string, Quote> LoadQuoteMap()
        {
            byte[] bytes = RetrieveData("QuoteList.json");
            return bytes != null && bytes.Length > 0 ? MainProgramCode.DeserializeQuoteList(bytes) : new SortedDictionary<string, Quote>();
        }

        public void SaveParts(Dictionary<string, Part> parts)
        {
            MainProgramCode.SerializePartList(parts);
        }

        public void SavePumps(BindingList<Pump> pumps)
        {
            MainProgramCode.SerializePumpList(pumps);
        }

        public void SaveBusinesses(BindingList<Business> businesses)
        {
            MainProgramCode.SerializeBusinessList(businesses);
        }

        public void SaveQuotes(SortedDictionary<string, Quote> quotes)
        {
            MainProgramCode.SerializeQuoteList(quotes);
        }

        byte[] RetrieveData(string fileName)
        {
            string storePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;
            byte[] data = null;
            try
            {
                data = File.ReadAllBytes(storePath);
                return data;
            }
            catch (FileNotFoundException)
            {
                if (fileName != "ExportQuote.json")
                    if (messageService != null && messageService.RequestConfirmation(fileName + " could not be found.\nWould you like to continue the execution? (Recommended for first launch)", "REQUEST - Execution Continuation"))
                        return data;

                messageService?.ShowError(fileName + " Could not be found, please contact the developer to fix this issue.", "ERROR - " + fileName + " Not Found");
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
