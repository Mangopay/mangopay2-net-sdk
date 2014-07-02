using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>CardRegistration entity.</summary>
    public class CardRegistration : EntityBase
    {
        /// <summary>User identifier.</summary>
        public String UserId;

        /// <summary>Access key.</summary>
        public String AccessKey;

        /// <summary>Pre-registration data.</summary>
        public String PreregistrationData;

        /// <summary>Card registration URL.</summary>
        public String CardRegistrationURL;

        /// <summary>Card identifier.</summary>
        public String CardId;

        /// <summary>Card registration data.</summary>
        public String RegistrationData;

        /// <summary>Result code.</summary>
        public String ResultCode;

        /// <summary>Currency.</summary>
        public String Currency;

        /// <summary>Status.</summary>
        public String Status;

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("AccessKey");
            result.Add("PreregistrationData");
            result.Add("CardRegistrationURL");
            result.Add("CardId");
            result.Add("ResultCode");
            result.Add("Status");

            return result;
        }
    }
}
