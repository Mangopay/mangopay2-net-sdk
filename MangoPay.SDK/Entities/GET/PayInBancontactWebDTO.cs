using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInBancontactWebDTO : PayInDTO
    {
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not </summary>
        public string ReturnURL { get; set; }

        /// <summary> The URL to which the user is redirected to complete the payment </summary>
        public string RedirectURL { get; set; }
        
        /// <summary> </summary>
        public string DeepLinkURL { get; set; }
        
        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }
        
        /// <summary>Whether the Bancontact pay-ins are being made to be re-used in a recurring payment flow</summary>
        public bool? Recurring { get; set; }
    }
}
