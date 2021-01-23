using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSwift
{
    [Serializable]
    public class Pump_Part
    {
        private Part mPumpPart;
        private int mPumpPartQuantity;

        public Pump_Part(Part mPumpPart, int mPumpPartQuantity)
        {
            PumpPart = mPumpPart;
            PumpPartQuantity = mPumpPartQuantity;
        }

        public Part PumpPart { get => mPumpPart; set => mPumpPart = value; }
        public int PumpPartQuantity { get => mPumpPartQuantity; set => mPumpPartQuantity = value; }
    }
}
