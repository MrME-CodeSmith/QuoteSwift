

namespace QuoteSwift
{
    public class Quote_Part : ObservableObject
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

        public Pump_Part PumpPart
        {
            get => mPumpPart;
            set => SetProperty(ref mPumpPart, value);
        }

        public int MissingorScrap
        {
            get => mMissingorScrap;
            set => SetProperty(ref mMissingorScrap, value);
        }

        public int Repaired
        {
            get => mRepaired;
            set => SetProperty(ref mRepaired, value);
        }

        public int New
        {
            get => mNew;
            set => SetProperty(ref mNew, value);
        }

        public decimal Price
        {
            get => mPrice;
            set => SetProperty(ref mPrice, value);
        }

        public decimal UnitPrice
        {
            get => mUnitPrice;
            set => SetProperty(ref mUnitPrice, value);
        }

        public decimal RepairDevider
        {
            get => mRepairDevider;
            set => SetProperty(ref mRepairDevider, value);
        }
    }
}
