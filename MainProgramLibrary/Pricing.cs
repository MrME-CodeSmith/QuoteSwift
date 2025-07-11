
namespace QuoteSwift
{
    public class Pricing
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

        public decimal Machining { get => mMachining; set => mMachining = value; }
        public decimal Labour { get => mLabour; set => mLabour = value; }
        public decimal Consumables { get => mConsumables; set => mConsumables = value; }
        public decimal Rebate { get => mRebate; set => mRebate = value; }
        public decimal SubTotal { get => mSubTotal; set => mSubTotal = value; }
        public decimal VAT { get => mVAT; set => mVAT = value; }
        public decimal TotalDue { get => mTotalDue; set => mTotalDue = value; }
        public decimal PumpPrice { get => mPumpPrice; set => mPumpPrice = value; }
    }
}
