namespace MangoPay.SDK.Entities
{
    public class RecipientAddressPropertySchema
    {
        public RecipientPropertySchema AddressLine1 { get; set; }

        public RecipientPropertySchema AddressLine2 { get; set; }

        public RecipientPropertySchema City { get; set; }

        public RecipientPropertySchema Region { get; set; }

        public RecipientPropertySchema PostalCode { get; set; }

        public RecipientPropertySchema Country { get; set; }
    }
}