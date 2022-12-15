using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
	public class PayinsLinkedDTO : EntityBase
    {
	    /// <summary>ID of the payin made after the deposit creation if it is successful.</summary>
	    public string PayinCaptureId { get; set; }

	    /// <summary>ID of the payin made after the PayinCaptureID if it is successful (Not available yet).</summary>
	    public string PayinComplementId { get; set; }
    }
}
