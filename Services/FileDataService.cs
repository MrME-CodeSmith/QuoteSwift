using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class FileDataService : IDataService
    {
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public FileDataService(ISerializationService serializer, IMessageService messenger = null)
        {
            serializationService = serializer;
            messageService = messenger;
        }

        public Dictionary<string, Part> LoadPartList()
        {
            byte[] bytes = RetrieveData("Parts.json");
            return bytes != null && bytes.Length > 0 ? FileSerializationService.DeserializePartList(bytes) : new Dictionary<string, Part>();
        }

        public async Task<Dictionary<string, Part>> LoadPartListAsync()
        {
            byte[] bytes = await RetrieveDataAsync("Parts.json").ConfigureAwait(false);
            return bytes != null && bytes.Length > 0 ? FileSerializationService.DeserializePartList(bytes) : new Dictionary<string, Part>();
        }

        public BindingList<Pump> LoadPumpList()
        {
            byte[] bytes = RetrieveData("PumpList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Pump>(FileSerializationService.DeserializePumpList(bytes)) : new BindingList<Pump>();
        }

        public async Task<BindingList<Pump>> LoadPumpListAsync()
        {
            byte[] bytes = await RetrieveDataAsync("PumpList.json").ConfigureAwait(false);
            return bytes != null && bytes.Length > 0 ? new BindingList<Pump>(FileSerializationService.DeserializePumpList(bytes)) : new BindingList<Pump>();
        }

        public BindingList<Business> LoadBusinessList()
        {
            byte[] bytes = RetrieveData("BusinessList.json");
            return bytes != null && bytes.Length > 0 ? new BindingList<Business>(FileSerializationService.DeserializeBusinessList(bytes)) : new BindingList<Business>();
        }

        public async Task<BindingList<Business>> LoadBusinessListAsync()
        {
            byte[] bytes = await RetrieveDataAsync("BusinessList.json").ConfigureAwait(false);
            return bytes != null && bytes.Length > 0 ? new BindingList<Business>(FileSerializationService.DeserializeBusinessList(bytes)) : new BindingList<Business>();
        }

        public SortedDictionary<string, Quote> LoadQuoteMap()
        {
            byte[] bytes = RetrieveData("QuoteList.json");
            return bytes != null && bytes.Length > 0 ? FileSerializationService.DeserializeQuoteList(bytes) : new SortedDictionary<string, Quote>();
        }

        public async Task<SortedDictionary<string, Quote>> LoadQuoteMapAsync()
        {
            byte[] bytes = await RetrieveDataAsync("QuoteList.json").ConfigureAwait(false);
            return bytes != null && bytes.Length > 0 ? FileSerializationService.DeserializeQuoteList(bytes) : new SortedDictionary<string, Quote>();
        }

        public void SaveParts(Dictionary<string, Part> parts)
        {
            serializationService.SerializePartList(parts);
        }

        public void SavePumps(BindingList<Pump> pumps)
        {
            serializationService.SerializePumpList(pumps);
        }

        public void SaveBusinesses(BindingList<Business> businesses)
        {
            serializationService.SerializeBusinessList(businesses);
        }

        public void SaveQuotes(SortedDictionary<string, Quote> quotes)
        {
            serializationService.SerializeQuoteList(quotes);
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

        async Task<byte[]> RetrieveDataAsync(string fileName)
        {
            string storePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + fileName;
            byte[] data = null;
            try
            {
                data = await File.ReadAllBytesAsync(storePath).ConfigureAwait(false);
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
