namespace QuoteSwift
{
    public interface ISerializationService
    {
        void SerializePartList(System.Collections.Generic.Dictionary<string, Part> partList);
        void SerializePumpList(System.ComponentModel.BindingList<Pump> pumpList);
        void SerializeBusinessList(System.ComponentModel.BindingList<Business> businessList);
        void SerializeQuoteList(System.Collections.Generic.SortedDictionary<string, Quote> quoteList);
        void ExportInventory(System.ComponentModel.BindingList<Pump> pumpList, string filePath);
        void CloseApplication(bool exitApp,
            System.ComponentModel.BindingList<Business> businessList,
            System.ComponentModel.BindingList<Pump> pumpList,
            System.Collections.Generic.Dictionary<string, Part> partList,
            System.Collections.Generic.SortedDictionary<string, Quote> quoteList);
    }
}
