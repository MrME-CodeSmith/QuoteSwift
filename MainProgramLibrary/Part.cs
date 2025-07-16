
namespace QuoteSwift
{
    public class Part : ObservableObject
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

        public string PartName
        {
            get => mPartName;
            set => SetProperty(ref mPartName, value);
        }

        public string PartDescription
        {
            get => mPartDescription;
            set => SetProperty(ref mPartDescription, value);
        }

        public string OriginalItemPartNumber
        {
            get => mOriginalItemPartNumber;
            set => SetProperty(ref mOriginalItemPartNumber, value);
        }

        public string NewPartNumber
        {
            get => mNewPartNumber;
            set => SetProperty(ref mNewPartNumber, value);
        }

        public bool MandatoryPart
        {
            get => mMandatoryPart;
            set => SetProperty(ref mMandatoryPart, value);
        }

        public decimal PartPrice
        {
            get => mPartPrice;
            set => SetProperty(ref mPartPrice, value);
        }
    }
}
