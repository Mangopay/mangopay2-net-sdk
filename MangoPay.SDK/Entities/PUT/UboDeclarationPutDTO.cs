using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    public class UboDeclarationPutDTO : EntityPutBase
    {
        public UboDeclarationPutDTO(UboDTO[] ubos, UboDeclarationType status)
        {
            Ubos = ubos;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public UboDeclarationType Status { get; set; }

        public UboDTO[] Ubos { get; set; }
    }
}