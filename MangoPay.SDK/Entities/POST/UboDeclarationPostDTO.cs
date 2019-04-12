using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class UboDeclarationPostDTO : EntityPostBase
    {
        public UboDeclarationPostDTO()
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

        public UboPostDTO[] Ubos { get; set; }
    }
}