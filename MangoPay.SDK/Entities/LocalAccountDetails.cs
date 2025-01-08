namespace MangoPay.SDK.Entities
{
    public class LocalAccountDetails : EntityBase
    {
        public VirtualAccountAddress Address { get; set; }

        public LocalAccount Account { get; set; }
    }
}