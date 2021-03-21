using ProtoBuf;


namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Quote_Part
    {
        [ProtoMember(1)]
        private Pump_Part mPumpPart;
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

        public Quote_Part(Pump_Part mPumpPart, int mMissingorScrap, int mRepaired, int mNew, float mPrice, float mUnitPrice, float mRepairDevider)
        {
            PumpPart = mPumpPart;
            MissingorScrap = mMissingorScrap;
            Repaired = mRepaired;
            New = mNew;
            Price = mPrice;
            UnitPrice = mUnitPrice;
            RepairDevider = mRepairDevider;
        }

        public Pump_Part PumpPart { get => mPumpPart; set => mPumpPart = value; }
        public int MissingorScrap { get => mMissingorScrap; set => mMissingorScrap = value; }
        public int Repaired { get => mRepaired; set => mRepaired = value; }
        public int New { get => mNew; set => mNew = value; }
        public float Price { get => mPrice; set => mPrice = value; }
        public float UnitPrice { get => mUnitPrice; set => mUnitPrice = value; }
        public float RepairDevider { get => mRepairDevider; set => mRepairDevider = value; }
    }
}
