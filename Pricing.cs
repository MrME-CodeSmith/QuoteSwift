using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class Pricing
    {
        private double mMachining;
        private double mLabour;
        private double mConsumables;
        private double mRebate;
        private double mSubTotal;
        private double mVAT;
        private double mTotalDue;

        public Pricing()
        {
            Machining = 0;
            Labour = 0;
            Consumables = 0;
            Rebate = 0;
            SubTotal = 0;
            VAT = 0;
            TotalDue = 0;
        }

        public Pricing(double mMachining, double mLabour, double mConsumables, double mRebate, double mSubTotal, double mVAT, double mTotalDue)
        {
            Machining = mMachining;
            Labour = mLabour;
            Consumables = mConsumables;
            Rebate = mRebate;
            SubTotal = mSubTotal;
            VAT = mVAT;
            TotalDue = mTotalDue;
        }

        public double Machining { get => mMachining; set => mMachining = value; }
        public double Labour { get => mLabour; set => mLabour = value; }
        public double Consumables { get => mConsumables; set => mConsumables = value; }
        public double Rebate { get => mRebate; set => mRebate = value; }
        public double SubTotal { get => mSubTotal; set => mSubTotal = value; }
        public double VAT { get => mVAT; set => mVAT = value; }
        public double TotalDue { get => mTotalDue; set => mTotalDue = value; }
    }
}
