
namespace QuoteSwift
{
    public class Part
    {
        private string mPartName;
        private string mPartDescription;
        private string mOriginalItemPartNumber;
        private string mNewPartNumber;
        private bool mMandatoryPart;
        private decimal mPartPrice;

        // Default Constructor:
        public Part()
        {
            PartName = "";
            PartDescription = "";
            OriginalItemPartNumber = "";
            NewPartNumber = "";
            MandatoryPart = false;
            PartPrice = 0m;
        }

        //Copy Constructor:

        public Part(Part P)
        {
            PartName = P.PartName;
            PartDescription = P.PartDescription;
            OriginalItemPartNumber = P.OriginalItemPartNumber;
            NewPartNumber = P.NewPartNumber;
            MandatoryPart = P.MandatoryPart;
            PartPrice = P.PartPrice;
        }

        public Part(string mPartName, string mPartDescription, string mOriginalItempartNumber, string mNewPartNumber, bool mMandatoryPart, decimal mPartPrice)
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
        public decimal PartPrice { get => mPartPrice; set => mPartPrice = value; }
    }
}
