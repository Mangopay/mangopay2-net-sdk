using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Dispute page POST entity.</summary>
    public class DisputePagePostDTO : EntityPostBase
    {
		public DisputePagePostDTO(string fileContent)
        {
            File = fileContent;
        }

        /// <summary>File content.</summary>
        public String File { get; set; }
    }
}
