using System.ComponentModel;


namespace QuoteSwift
{
    public class Pump
    {
        private string mPumpName;
        private string mPumpDescription;
        private BindingList<Pump_Part> mPartList;
        private decimal mNewPumpPrice;

        public Pump(string mPumpName, string mPumpDescription, decimal mNewPumpPrice, ref BindingList<Pump_Part> mPartList)
        {
            PumpName = mPumpName;
            PumpDescription = mPumpDescription;
            mPartList = mPartList;
            NewPumpPrice = mNewPumpPrice;
        }

        public string PumpName { get => mPumpName; set => mPumpName = value; }
        public string PumpDescription { get => mPumpDescription; set => mPumpDescription = value; }
        public IReadOnlyList<Pump_Part> PartList => mPartList;
        public void SetPartList(BindingList<Pump_Part> list)
        {
            mPartList = list;
        }
        public decimal NewPumpPrice { get => mNewPumpPrice; set => mNewPumpPrice = value; }
    }
}
