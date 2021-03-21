using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Pricing
    {
        [ProtoMember(1)]
        private float mMachining;
        [ProtoMember(2)]
        private float mLabour;
        [ProtoMember(3)]
        private float mConsumables;
        [ProtoMember(4)]
        private float mRebate;
        [ProtoMember(5)]
        private float mSubTotal;
        [ProtoMember(6)]
        private float mVAT;
        [ProtoMember(7)]
        private float mTotalDue;
        [ProtoMember(8)]
        private float mPumpPrice;

        public Pricing()
        {
            Machining = 0;
            Labour = 0;
            Consumables = 0;
            Rebate = 0;
            SubTotal = 0;
            VAT = 0;
            TotalDue = 0;
            PumpPrice = 0;
        }

        public Pricing(float mMachining, float mLabour, float mConsumables, float mRebate, float mSubTotal, float mVAT, float mTotalDue, float mPumpPrice)
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

        public float Machining { get => mMachining; set => mMachining = value; }
        public float Labour { get => mLabour; set => mLabour = value; }
        public float Consumables { get => mConsumables; set => mConsumables = value; }
        public float Rebate { get => mRebate; set => mRebate = value; }
        public float SubTotal { get => mSubTotal; set => mSubTotal = value; }
        public float VAT { get => mVAT; set => mVAT = value; }
        public float TotalDue { get => mTotalDue; set => mTotalDue = value; }
        public float PumpPrice { get => mPumpPrice; set => mPumpPrice = value; }
    }
}
