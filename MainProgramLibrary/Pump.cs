using ProtoBuf;
using System.ComponentModel;


namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Pump
    {
        [ProtoMember(1)]
        private string mPumpName;
        [ProtoMember(2)]
        private string mPumpDescription;
        [ProtoMember(3)]
        private BindingList<Pump_Part> mPartList;
        [ProtoMember(4)]
        private decimal mNewPumpPrice;

        public Pump(string mPumpName, string mPumpDescription, decimal mNewPumpPrice, ref BindingList<Pump_Part> mPartList)
        {
            PumpName = mPumpName;
            PumpDescription = mPumpDescription;
            PartList = mPartList;
            NewPumpPrice = mNewPumpPrice;
        }

        public string PumpName { get => mPumpName; set => mPumpName = value; }
        public string PumpDescription { get => mPumpDescription; set => mPumpDescription = value; }
        public BindingList<Pump_Part> PartList { get => mPartList; set => mPartList = value; }
        public decimal NewPumpPrice { get => mNewPumpPrice; set => mNewPumpPrice = value; }
    }
}
