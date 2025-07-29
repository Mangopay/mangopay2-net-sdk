using System;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.PUT
{
    public class PayInIntentSplitPutDTO : EntityPutBase
    {
        public string LineItemId { get; set; }
        
        public int? SplitAmount { get; set; }
        
        public int? FeesAmount { get; set; }
        
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? TransferDate { get; set; }
        
        public string Description { get; set; }
    }
}