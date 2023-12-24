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

        public Part(Part p)
        {
            PartName = p.PartName;
            PartDescription = p.PartDescription;
            OriginalItemPartNumber = p.OriginalItemPartNumber;
            NewPartNumber = p.NewPartNumber;
            MandatoryPart = p.MandatoryPart;
            PartPrice = p.PartPrice;
        }

        public Part(string partName, string partDescription, string originalItempartNumber, string newPartNumber, bool mandatoryPart, float partPrice)
        {
            PartName = partName;
            PartDescription = partDescription;
            OriginalItemPartNumber = originalItempartNumber;
            NewPartNumber = newPartNumber;
            MandatoryPart = mandatoryPart;
            PartPrice = partPrice;
        }

        public string PartName { get => mPartName; set => mPartName = value; }
        public string PartDescription { get => mPartDescription; set => mPartDescription = value; }
        public string OriginalItemPartNumber { get => mOriginalItemPartNumber; set => mOriginalItemPartNumber = value; }
        public string NewPartNumber { get => mNewPartNumber; set => mNewPartNumber = value; }
        public bool MandatoryPart { get => mMandatoryPart; set => mMandatoryPart = value; }
        public float PartPrice { get => mPartPrice; set => mPartPrice = value; }
    }
}
