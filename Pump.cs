using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace QuoteSwift
{
    [Serializable]
    public class Pump
    {
        string mPumpName;
        string mPumpDescription;
        BindingList<Pump_Part> mPartList;
        float mNewPumpPrice;

        public Pump(string mPumpName, string mPumpDescription, float mNewPumpPrice,ref BindingList<Pump_Part> mPartList)
        {
            PumpName = mPumpName;
            PumpDescription = mPumpDescription;
            PartList = mPartList;
            NewPumpPrice = mNewPumpPrice;
        }

        public string PumpName { get => mPumpName; set => mPumpName = value; }
        public string PumpDescription { get => mPumpDescription; set => mPumpDescription = value; }
        public BindingList<Pump_Part> PartList { get => mPartList; set => mPartList = value; }
        public float NewPumpPrice { get => mNewPumpPrice; set => mNewPumpPrice = value; }
    }
}
