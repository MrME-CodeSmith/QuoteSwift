

namespace QuoteSwift
{
    public class Quote_Part
    {
        private Pump_Part mPumpPart;
        private int mMissingorScrap;
        private int mRepaired;
        private int mNew;
        private decimal mPrice;
        private decimal mUnitPrice;
        private decimal mRepairDevider;

        public Quote_Part(Pump_Part mPumpPart, int mMissingorScrap, int mRepaired, int mNew, decimal mPrice, decimal mUnitPrice, decimal mRepairDevider)
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
        public decimal Price { get => mPrice; set => mPrice = value; }
        public decimal UnitPrice { get => mUnitPrice; set => mUnitPrice = value; }
        public decimal RepairDevider { get => mRepairDevider; set => mRepairDevider = value; }
    }
}
