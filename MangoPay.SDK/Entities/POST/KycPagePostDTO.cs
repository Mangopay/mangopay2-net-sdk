using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>KYC page POST entity.</summary>
    public class KycPagePostDTO : EntityPostBase
    {
        public KycPagePostDTO(string fileContent)
        {
            File = fileContent;
        }

        /// <summary>File content.</summary>
        public string File { get; set; }
    }
}
