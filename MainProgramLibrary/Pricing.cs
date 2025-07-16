
namespace QuoteSwift
{
    public class Pricing : ObservableObject
    {
        private decimal mMachining;
        private decimal mLabour;
        private decimal mConsumables;
        private decimal mRebate;
        private decimal mSubTotal;
        private decimal mVAT;
        private decimal mTotalDue;
        private decimal mPumpPrice;

        public Pricing()
        {
            Machining = 0m;
            Labour = 0m;
            Consumables = 0m;
            Rebate = 0m;
            SubTotal = 0m;
            VAT = 0m;
            TotalDue = 0m;
            PumpPrice = 0m;
        }

        public Pricing(decimal mMachining, decimal mLabour, decimal mConsumables, decimal mRebate, decimal mSubTotal, decimal mVAT, decimal mTotalDue, decimal mPumpPrice)
        {
            Machining = mMachining;
            Labour = mLabour;
            Consumables = mConsumables;
            Rebate = mRebate;
            SubTotal = mSubTotal;
            VAT = mVAT;
            TotalDue = mTotalDue;
            PumpPrice = mPumpPrice;
        }

        public decimal Machining
        {
            get => mMachining;
            set => SetProperty(ref mMachining, value);
        }

        public decimal Labour
        {
            get => mLabour;
            set => SetProperty(ref mLabour, value);
        }

        public decimal Consumables
        {
            get => mConsumables;
            set => SetProperty(ref mConsumables, value);
        }

        public decimal Rebate
        {
            get => mRebate;
            set => SetProperty(ref mRebate, value);
        }

        public decimal SubTotal
        {
            get => mSubTotal;
            set => SetProperty(ref mSubTotal, value);
        }

        public decimal VAT
        {
            get => mVAT;
            set => SetProperty(ref mVAT, value);
        }

        public decimal TotalDue
        {
            get => mTotalDue;
            set => SetProperty(ref mTotalDue, value);
        }

        public decimal PumpPrice
        {
            get => mPumpPrice;
            set => SetProperty(ref mPumpPrice, value);
        }
    }
}
