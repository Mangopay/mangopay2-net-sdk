namespace MangoPay.SDK.Entities
{
    public class IndividualRecipientPropertySchema
    {
        public RecipientPropertySchema FirstName { get; set; }

        public RecipientPropertySchema LastName { get; set; }

        public RecipientAddressPropertySchema Address { get; set; }
    }
}