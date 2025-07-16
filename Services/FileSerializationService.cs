using System.Collections.Generic;
using System.ComponentModel;

namespace QuoteSwift
{
    public class FileSerializationService : ISerializationService
    {
        public void SerializePartList(Dictionary<string, Part> partList)
        {
            MainProgramCode.SerializePartList(partList);
        }

        public void SerializePumpList(BindingList<Pump> pumpList)
        {
            MainProgramCode.SerializePumpList(pumpList);
        }

        public void SerializeBusinessList(BindingList<Business> businessList)
        {
            MainProgramCode.SerializeBusinessList(businessList);
        }

        public void SerializeQuoteList(SortedDictionary<string, Quote> quoteList)
        {
            MainProgramCode.SerializeQuoteList(quoteList);
        }

        public void ExportInventory(BindingList<Pump> pumpList, string filePath)
        {
            MainProgramCode.ExportInventory(pumpList, filePath);
        }

        public void CloseApplication(bool exitApp,
            BindingList<Business> businessList,
            BindingList<Pump> pumpList,
            Dictionary<string, Part> partList,
            SortedDictionary<string, Quote> quoteList)
        {
            MainProgramCode.CloseApplication(exitApp, businessList, pumpList, partList, quoteList);
        }
    }
}
