using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class Quote_Part
    {
        private Pump_Part mPumpPart;
        private int mMissingorScrap;
        private int mRepaired;
        private int mNew;
        private float mPrice;
        private float mUnitPrice;
        private float mRepairDevider;

        public Quote_Part(Pump_Part mPumpPart, int mMissingorScrap, int mRepaired, int mNew, float mPrice, float mUnitPrice, float mRepairDevider)
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
        public float Price { get => mPrice; set => mPrice = value; }
        public float UnitPrice { get => mUnitPrice; set => mUnitPrice = value; }
        public float RepairDevider { get => mRepairDevider; set => mRepairDevider = value; }
    }
}
