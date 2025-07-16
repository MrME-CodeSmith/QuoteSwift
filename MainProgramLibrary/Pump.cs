using System.ComponentModel;


namespace QuoteSwift
{
    public class Pump : ObservableObject
    {
        private string mPumpName;
        private string mPumpDescription;
        private BindingList<Pump_Part> mPartList;
        private decimal mNewPumpPrice;

        public Pump()
        {
            PumpName = "";
            PumpDescription = "";
            PartList = new BindingList<Pump_Part>();
            NewPumpPrice = 0m;
        }

        public Pump(string mPumpName, string mPumpDescription, decimal mNewPumpPrice, ref BindingList<Pump_Part> mPartList)
        {
            PumpName = mPumpName;
            PumpDescription = mPumpDescription;
            PartList = mPartList ?? new BindingList<Pump_Part>();
            NewPumpPrice = mNewPumpPrice;
        }

        public string PumpName
        {
            get => mPumpName;
            set => SetProperty(ref mPumpName, value);
        }

        public string PumpDescription
        {
            get => mPumpDescription;
            set => SetProperty(ref mPumpDescription, value);
        }

        public BindingList<Pump_Part> PartList
        {
            get => mPartList;
            set => SetProperty(ref mPartList, value);
        }

        public decimal NewPumpPrice
        {
            get => mNewPumpPrice;
            set => SetProperty(ref mNewPumpPrice, value);
        }
    }
}
