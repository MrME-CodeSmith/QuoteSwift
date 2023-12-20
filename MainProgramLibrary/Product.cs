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
        private BindingList<Product_Part> mPartList;
        [ProtoMember(4)]
        private float mNewProductPrice;

        public Product(string mPumpName, string mPumpDescription, float newProductPrice, ref BindingList<Product_Part> mPartList)
        {
            ProductName = mPumpName;
            PumpDescription = mPumpDescription;
            PartList = mPartList;
            NewProductPrice = newProductPrice;
        }

        public string ProductName { get => mPumpName; set => mPumpName = value; }
        public string PumpDescription { get => mPumpDescription; set => mPumpDescription = value; }
        public BindingList<Product_Part> PartList { get => mPartList; set => mPartList = value; }
        public float NewProductPrice { get => mNewProductPrice; set => mNewProductPrice = value; }
    }
}
