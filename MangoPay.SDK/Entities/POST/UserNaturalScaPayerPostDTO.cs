﻿using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>User natural SCA Payer POST entity.</summary>
    public class UserNaturalScaPayerPostDTO : EntityPostBase
    {
        /// <summary>First name.</summary>
        public string FirstName { get; set; }

        /// <summary>Last name.</summary>
        public string LastName { get; set; }

        /// <summary>Email address.</summary>
        public string Email { get; set; }

        /// <summary>Address.</summary>
        public Address Address { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }

        public bool TermsAndConditionsAccepted { get; set; }
        
        /// <summary>
        /// Format: International telephone numbering plan E.164 (+ then country code then the number) or local format.
        /// <para>
        /// Required if UserCategory is OWNER.
        /// </para>
        /// <para>
        /// The individual’s phone number.
        /// </para>
        /// <para>
        /// If the international format is sent, the PhoneNumberCountry value is not taken into account.
        /// </para>
        /// <para>
        /// We recommend that you use the PhoneNumberCountry parameter to ensure the correct rendering in line with the E.164 standard.
        /// </para>
        /// <para>
        /// Caution: If UserCategory is OWNER, modifying this value means the user will be required to re-enroll the new value in SCA via the PendingUserAction.RedirectUrl.
        /// For more details see the <a href="https://docs.mangopay.com/guides/users/sca/enrollment">SCA</a> guides.
        /// </para>
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Allowed values: Two-letter country code (ISO 3166-1 alpha-2 format).
        /// <para>
        /// Required if the PhoneNumber is provided in local format.
        /// </para>
        /// <para>
        /// The country code of the PhoneNumber, used to render the value in the E.164 standard.
        /// </para>
        /// <para>
        /// Caution: If UserCategory is OWNER, modifying this value means the user will be required to re-enroll the new value in SCA via the PendingUserAction.RedirectUrl.
        /// For more details see the <a href="https://docs.mangopay.com/guides/users/sca/enrollment">SCA</a> guides.
        /// </para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? PhoneNumberCountry { get; set; }
    }
}
