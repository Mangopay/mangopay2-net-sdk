using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Dispute tag PUT entity.</summary>
	public class DisputeTagPutDTO : EntityPutBase
    {
        /// <summary>Custom data.</summary>
        public string Tag { get; set; }
    }
}
