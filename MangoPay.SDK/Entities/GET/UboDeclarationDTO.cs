using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnixDateTimeConverter = MangoPay.SDK.Core.UnixDateTimeConverter;

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

        [JsonConverter(typeof(StringEnumConverter))]
        public UboDeclarationType Status { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UboRefusedReasonType? Reason { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public UboDTO[] Ubos { get; set; }
    }
}