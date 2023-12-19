using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Product_Part
    {
        [ProtoMember(1)]
        private Part mPumpPart;
        [ProtoMember(2)]
        private int mPumpPartQuantity;

        public Product_Part(Part mPumpPart, int mPumpPartQuantity)
        {
            PumpPart = mPumpPart;
            PumpPartQuantity = mPumpPartQuantity;
        }

        public Part PumpPart { get => mPumpPart; set => mPumpPart = value; }
        public int PumpPartQuantity { get => mPumpPartQuantity; set => mPumpPartQuantity = value; }
    }
}
