using ProtoBuf;
using System.ComponentModel;


namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Product
    {
        [ProtoMember(1)]
        private string mPumpName;
        [ProtoMember(2)]
        private string mPumpDescription;
        [ProtoMember(3)]
        private BindingList<ProductPart> mPartList;
        [ProtoMember(4)]
        private float mNewProductPrice;

        public Product(string pumpName, string pumpDescription, float newProductPrice, ref BindingList<ProductPart> partList)
        {
            ProductName = pumpName;
            PumpDescription = pumpDescription;
            PartList = partList;
            NewProductPrice = newProductPrice;
        }

        public string ProductName { get => mPumpName; set => mPumpName = value; }
        public string PumpDescription { get => mPumpDescription; set => mPumpDescription = value; }
        public BindingList<ProductPart> PartList { get => mPartList; set => mPartList = value; }
        public float NewProductPrice { get => mNewProductPrice; set => mNewProductPrice = value; }
    }
}
