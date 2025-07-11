using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Pricing
    {
        [ProtoMember(1)]
        private decimal mMachining;
        [ProtoMember(2)]
        private decimal mLabour;
        [ProtoMember(3)]
        private decimal mConsumables;
        [ProtoMember(4)]
        private decimal mRebate;
        [ProtoMember(5)]
        private decimal mSubTotal;
        [ProtoMember(6)]
        private decimal mVAT;
        [ProtoMember(7)]
        private decimal mTotalDue;
        [ProtoMember(8)]
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
