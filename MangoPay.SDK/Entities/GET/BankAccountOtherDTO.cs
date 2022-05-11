using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Class represents OTHER type of bank account.</summary>
    public class BankAccountOtherDTO : BankAccountDTO
    {
        /// <summary>The Country associated to the BankAccount.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Country { get; set; }

        /// <summary>Valid BIC format.</summary>
        public string BIC { get; set; }

        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }
    }
}
