namespace MangoPay.SDK.Entities
{
    public class LocalAccountDetails
    {
        public VirtualAccountAddress Address { get; set; }

        public LocalAccount Account { get; set; }
        
        public string BankName { get; set; }
    }
}