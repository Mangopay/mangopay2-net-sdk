namespace MangoPay.SDK.Entities.GET
{
    public class PayInMbwayDirectDTO : PayInDTO
    {
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary>The mobile phone number of the user initiating the pay-in Country code
        /// followed by hash symbol (#) followed by the rest of the number. Only digits and hash allowed</summary>
        public string Phone { get; set; }
    }
}
