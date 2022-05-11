using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Refund for Transfer POST entity.</summary>
    public class RefundTransferPostDTO : EntityPostBase
    {
        public RefundTransferPostDTO(string authorId)
        {
            AuthorId = authorId;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
    }
}
