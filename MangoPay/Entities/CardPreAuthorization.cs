using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>CardPreAuthorization entity.</summary>
    public class CardPreAuthorization : EntityBase
    {
        /// <summary>The user Id of the author of the pre-authorization.</summary>
        public string AuthorId;

        /// <summary>Represents the amount debited on the bank account 
        /// of the Author. DebitedFunds = Fees + CreditedFunds 
        /// (amount received on wallet).</summary>
        public Money DebitedFunds;

        /// <summary>Status of the PreAuthorization: { CREATED, SUCCEEDED, FAILED }.</summary>
        public string Status;

        /// <summary>The status of the payment after the PreAuthorization { WAITING, CANCELED, EXPIRED, VALIDATED }.</summary>
        public string PaymentStatus;

        /// <summary>The PreAuthorization result code.</summary>
        public string ResultCode;

        /// <summary>The PreAuthorization result Message explaining the result code.</summary>
        public string ResultMessage;

        /// <summary>How the PreAuthorization has been executed. Only single value for now: { CARD }.</summary>
        public string ExecutionType;

        /// <summary>The SecureMode correspond to '3D secure' for CB Visa and MasterCard 
        /// or 'Amex Safe Key' for American Express. 
        /// This field lets you activate it manually.</summary>
        public string SecureMode;

        /// <summary>Identifier of the registered card (got through CardRegistration object).</summary>
        public string CardId;

        /// <summary>The value is { true } if the SecureMode was used.</summary>
        public bool SecureModeNeeded;

        /// <summary>This is the URL where to redirect users to proceed to 3D secure validation.</summary>
        public string SecureModeRedirectURL;

        /// <summary>This is the URL where users are automatically redirected after 3D secure validation (if activated).</summary>
        public string SecureModeReturnURL;

        /// <summary>The date when the payment has been processed (UNIX timestamp).</summary>
        public long ExpirationDate;

        /// <summary>Identifier of the associated PayIn.</summary>
        public string PayInId;

        /// <summary>Gets map which property is an object and what type of object.</summary>
        /// <returns>Collection of field name-field type pairs.</returns>
        public override Dictionary<string, Type> GetSubObjects()
        {
            return new Dictionary<string, Type>
            {
                { "DebitedFunds", typeof(Money) }
            };
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<string> GetReadOnlyProperties()
        {
            List<string> result = base.GetReadOnlyProperties();

            result.Add("Status");
            result.Add("ResultCode");
            result.Add("ResultMessage");

            return result;
        }
    }
}
