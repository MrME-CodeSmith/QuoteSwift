using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class ProductPart
    {
        [ProtoMember(1)]
        private Part mPart;
        [ProtoMember(2)]
        private int mPumpPartQuantity;

        public ProductPart(Part part, int pumpPartQuantity)
        {
            Part = part;
            PumpPartQuantity = pumpPartQuantity;
        }

        public Part Part { get => mPart; set => mPart = value; }
        public int PumpPartQuantity { get => mPumpPartQuantity; set => mPumpPartQuantity = value; }
    }
}
