using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.PUT
{
    public class UboDeclarationPutDTO : EntityPutBase
    {
        public UboDeclarationPutDTO()
        {
        }

        public string Id { get; set; }

        /// <summary>Date of creation.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
		
        /// <summary>Date of creation.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ProcessedDate { get; set; }
		
        public UboDeclarationType Status { get; set; }

        public UboRefusedReasonType[] Reason { get; set; }

        public string Message { get; set; }

        public UboDTO[] Ubos { get; set; }
    }
}