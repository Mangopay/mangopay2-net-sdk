using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Class represents OTHER type of bank account.</summary>
    public class BankAccountOtherDTO : BankAccountDTO
    {
        /// <summary>The Country associated to the BankAccount.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Country { get; set; }

        /// <summary>Valid BIC format.</summary>
        public String BIC { get; set; }

        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }
    }
}
