using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Part
    {
        [ProtoMember(1)]
        private string mPartName;
        [ProtoMember(2)]
        private string mPartDescription;
        [ProtoMember(3)]
        private string mOriginalItemPartNumber;
        [ProtoMember(4)]
        private string mNewPartNumber;
        [ProtoMember(5)]
        private bool mMandatoryPart;
        [ProtoMember(6)]
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
