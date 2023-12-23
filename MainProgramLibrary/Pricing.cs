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
        private float mVat;
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
            Vat = 0;
            TotalDue = 0;
            PumpPrice = 0;
        }

        public Pricing(float machining, float labour, float consumables, float rebate, float subTotal, float vat, float totalDue, float pumpPrice)
        {
            Machining = machining;
            Labour = labour;
            Consumables = consumables;
            Rebate = rebate;
            SubTotal = subTotal;
            Vat = vat;
            TotalDue = totalDue;
            PumpPrice = pumpPrice;
        }

        public float Machining { get => mMachining; set => mMachining = value; }
        public float Labour { get => mLabour; set => mLabour = value; }
        public float Consumables { get => mConsumables; set => mConsumables = value; }
        public float Rebate { get => mRebate; set => mRebate = value; }
        public float SubTotal { get => mSubTotal; set => mSubTotal = value; }
        public float Vat { get => mVat; set => mVat = value; }
        public float TotalDue { get => mTotalDue; set => mTotalDue = value; }
        public float PumpPrice { get => mPumpPrice; set => mPumpPrice = value; }
    }
}
