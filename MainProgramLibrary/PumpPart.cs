
namespace QuoteSwift
{
    public class Pump_Part : ObservableObject
    {
        private Part mPumpPart;
        private int mPumpPartQuantity;

        public Pump_Part(Part mPumpPart, int mPumpPartQuantity)
        {
            PumpPart = mPumpPart;
            PumpPartQuantity = mPumpPartQuantity;
        }

        public Part PumpPart
        {
            get => mPumpPart;
            set => SetProperty(ref mPumpPart, value);
        }

        public int PumpPartQuantity
        {
            get => mPumpPartQuantity;
            set => SetProperty(ref mPumpPartQuantity, value);
        }
    }
}
