using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    public class UboDeclarationDTO : EntityBase
    {
        public UboDeclarationDTO()
        {
        }

        /// <summary>Date of creation.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ProcessedDate { get; set; }

        public UboDeclarationType Status { get; set; }

        public UboRefusedReasonType[] Reason { get; set; }

        public string Message { get; set; }

        public UboDTO[] Ubos { get; set; }
    }
}