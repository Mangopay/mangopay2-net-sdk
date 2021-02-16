namespace MangoPay.SDK.Entities
{
    public class Shipping
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>The address.</summary>
        public Address Address { get; set; }
    }
}
