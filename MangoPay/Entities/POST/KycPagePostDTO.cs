using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>KYC page POST entity.</summary>
    public class KycPagePostDTO : EntityPostBase
    {
        public KycPagePostDTO(string fileContent)
        {
            File = fileContent;
        }

        /// <summary>File content.</summary>
        public String File { get; set; }
    }
}
