using ProtoBuf;


namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class QuotePart
    {
        [ProtoMember(1)]
        private ProductPart mPumpPart;
        [ProtoMember(2)]
        private int mMissingorScrap;
        [ProtoMember(3)]
        private int mRepaired;
        [ProtoMember(4)]
        private int mNew;
        [ProtoMember(5)]
        private float mPrice;
        [ProtoMember(6)]
        private float mUnitPrice;
        [ProtoMember(7)]
        private float mRepairDevider;

        public QuotePart(ProductPart pumpPart, int missingorScrap, int repaired, int @new, float price, float unitPrice, float repairDevider)
        {
            PumpPart = pumpPart;
            MissingorScrap = missingorScrap;
            Repaired = repaired;
            New = @new;
            Price = price;
            UnitPrice = unitPrice;
            RepairDevider = repairDevider;
        }

        public ProductPart PumpPart { get => mPumpPart; set => mPumpPart = value; }
        public int MissingorScrap { get => mMissingorScrap; set => mMissingorScrap = value; }
        public int Repaired { get => mRepaired; set => mRepaired = value; }
        public int New { get => mNew; set => mNew = value; }
        public float Price { get => mPrice; set => mPrice = value; }
        public float UnitPrice { get => mUnitPrice; set => mUnitPrice = value; }
        public float RepairDevider { get => mRepairDevider; set => mRepairDevider = value; }
    }
}
