using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class InstantConversionDTO: EntityBase
    {
        /// <summary>The unique identifier of the user at the source of the transaction.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>The unique identifier of the debited wallet.</summary>
        public string DebitedWalletId { get; set; }
        
        /// <summary>The unique identifier of the credited wallet</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary>The sell funds</summary>
        public Money DebitedFunds { get; set; }
        
        /// <summary>The buy funds</summary>
        public Money CreditedFunds { get; set; }
        
        /// <summary>Real time indicative market rate of a specific currency pair</summary>
        public ConversionRateDTO ConversionRate { get; set; }
        
        /// <summary>The status of the transaction.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        
        /// <summary>The type of transaction</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        
        /// <summary>The nature of the transaction, providing more
        ///  information about the context in which the transaction occurred</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionNature Nature { get; set; }
        
        /// <summary>The code indicates the result of the operation.
        /// This information is mostly used to handle errors or for filtering purposes.</summary>
        public string ResultCode { get; set; }
        
        /// <summary>The explanation of the result code.</summary>
        public string ResultMessage { get; set; }
        
        /// <summary>The date and time at which the status changed to SUCCEEDED,
        /// indicating that the transaction occurred.
        /// The statuses CREATED and FAILED return an ExecutionDate of null</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime ExecutionDate { get; set; }
    }
}