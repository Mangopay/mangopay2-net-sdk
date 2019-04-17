using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.PUT
{
    public class UboDeclarationPutDTO : EntityPutBase
    {
        public UboDeclarationPutDTO(UboDTO[] ubos, UboDeclarationType status)
        {
            Ubos = ubos;
            Status = status;
        }

        public UboDeclarationType Status { get; set; }

        public UboDTO[] Ubos { get; set; }
    }
}