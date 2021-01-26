using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSwift
{
    [Serializable]
    public class Part
    {
        private string mPartName;
        private string mPartDescription;
        private string mOriginalItemPartNumber;
        private string mNewPartNumber;
        private bool mMandatoryPart;
        private float mPartPrice;
        
        // Default Constructor:
        public Part()
        {
            PartName = "";
            PartDescription = "";
            OriginalItemPartNumber = "";
            NewPartNumber = "";
            MandatoryPart = false;
            PartPrice = 0;
        }

        public Part(string mPartName, string mPartDescription, string mOriginalItempartNumber, string mNewPartNumber, bool mMandatoryPart, float mPartPrice)
        {
            PartName = mPartName;
            PartDescription = mPartDescription;
            OriginalItemPartNumber = mOriginalItempartNumber;
            NewPartNumber = mNewPartNumber;
            MandatoryPart = mMandatoryPart;
            PartPrice = mPartPrice;
        }

        public string PartName { get => mPartName; set => mPartName = value; }
        public string PartDescription { get => mPartDescription; set => mPartDescription = value; }
        public string OriginalItemPartNumber { get => mOriginalItemPartNumber; set => mOriginalItemPartNumber = value; }
        public string NewPartNumber { get => mNewPartNumber; set => mNewPartNumber = value; }
        public bool MandatoryPart { get => mMandatoryPart; set => mMandatoryPart = value; }
        public float PartPrice { get => mPartPrice; set => mPartPrice = value; }
    }
}
