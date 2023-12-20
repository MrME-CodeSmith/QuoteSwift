using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Product_Part
    {
        [ProtoMember(1)]
        private Part mProductPart;
        [ProtoMember(2)]
        private int mPumpPartQuantity;

        public Product_Part(Part productPart, int mPumpPartQuantity)
        {
            ProductPart = productPart;
            PumpPartQuantity = mPumpPartQuantity;
        }

        public Part ProductPart { get => mProductPart; set => mProductPart = value; }
        public int PumpPartQuantity { get => mPumpPartQuantity; set => mPumpPartQuantity = value; }
    }
}
