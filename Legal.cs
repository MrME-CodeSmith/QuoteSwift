using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Legal
    {
        /** Declaring variables needed to store a business' 
        //  Registration and VAT number */

        [ProtoMember(1)]
        private string mRegistrationNumber;
        [ProtoMember(2)]
        private string mVatNumber;

        /** Constructor implemented */
        public Legal(string registrationNumber, string vatNumber)
        {
            RegistrationNumber = registrationNumber;
            VatNumber = vatNumber;
        }

        public string RegistrationNumber { get => mRegistrationNumber; set => mRegistrationNumber = value; }
        public string VatNumber { get => mVatNumber; set => mVatNumber = value; }
    }
}
