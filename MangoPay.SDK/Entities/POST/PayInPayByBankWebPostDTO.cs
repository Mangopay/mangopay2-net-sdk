using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class PayInPayByBankWebPostDTO : EntityPostBase
    {
        public PayInPayByBankWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId,
            string returnUrl, CountryIso country)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Country = country;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }

        /// <summary> Country </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Country { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        /// <summary>The BIC of the user’s bank account, which is only returned if it was sent.</summary>
        public string BIC { get; set; }

        /// <summary>The IBAN of the user’s bank account, which is only returned if it was sent.</summary>
        public string IBAN { get; set; }

        /// <summary>
        /// <p>Allowed values: WEB, APP</p>
        /// <p>Default value: WEB</p>
        /// <p>The platform environment of the post-payment flow. The PaymentFlow value combines with the ReturnURL to manage the redirection behavior after payment:</p>
        /// <p>Set the value to APP to send the user to your platform’s mobile app</p>
        /// <p>Set the value to WEB to send the user to a web browser</p>
        /// <p>In both cases you need to provide the relevant ReturnURL, whether to your app or website.</p>
        /// </summary>
        public string PaymentFlow { get; set; }

        /// <summary>
        /// Name of the end-user’s bank
        /// </summary>
        public string BankName { get; set; }

        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode Culture { get; set; }

        /// <summary>
        /// The scheme to use to process the payment. Note that some banks may charge additional fees
        /// to the user for instant payment schemes.
        ///
        /// Mandatory for Country: DK
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Parameter that is only returned once the bank wire has been successfully authenticated and initiated
        /// by the user but has not yet been received by Mangopay. When the funds are received, the Status changes
        /// from CREATED to SUCCEEDED and the ProcessingStatus is no longer returned.
        ///
        /// Possible value: PENDING_SUCCEEDED
        /// </summary>
        public string ProcessingStatus { get; set; }
    }
}