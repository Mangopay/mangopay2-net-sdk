using System;
using System.Collections.Generic;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    public class CheckDTO
    {
        /// <summary>The unique identifier of the verification check.</summary>
        public string CheckId { get; set; }

        /// <summary>
        /// Type of verification check performed:
        /// <para>BUSINESS_VERIFICATION - Verification of the business entity of a Legal User.</para>
        /// <para>IDENTITY_DOCUMENT_VERIFICATION - Verification of the identity document of a Natural User or the legal representative of a Legal User.</para>
        /// <para>PERSONS_SIGNIFICANT_CONTROL - Verification of a person of significant control of a Legal User.</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>Returned values: VALIDATED, REFUSED, REVIEW</summary>
        public string CheckStatus { get; set; }

        /// <summary>The date and time at which the check was created.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>The date and time at which the check was last updated.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// The data points collected and verified during the check.
        /// </summary>
        public List<CheckDataDTO> Data { get; set; }
        
        public List<CheckDataDTO> Reasons { get; set; }
    }
}