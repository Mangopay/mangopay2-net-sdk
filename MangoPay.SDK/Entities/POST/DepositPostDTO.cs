using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Create Deposit DTO.</summary>
    public class DepositPostDTO : EntityPostBase
    {
        public DepositPostDTO(string authorId, Money debitedFunds, string cardId, string secureModeReturnUrl, string ipAddress, BrowserInfo browserInfo)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            CardId = cardId;
            SecureModeReturnURL = secureModeReturnUrl;
            IpAddress = ipAddress;
            BrowserInfo = browserInfo;
        }

        public DepositPostDTO()
        {
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>CardId.</summary>
        public string CardId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }

        /// <summary>StatementDescriptor.</summary>
        public string StatementDescriptor { get; set; }

        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }

        /// <summary>IpAddress.</summary>
        public string IpAddress { get; set; }

        /// <summary>BrowserInfo.</summary>
        public BrowserInfo BrowserInfo { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }
    }
}