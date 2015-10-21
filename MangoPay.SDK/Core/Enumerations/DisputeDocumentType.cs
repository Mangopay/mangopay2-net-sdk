using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.Enumerations
{
	public enum DisputeDocumentType
	{
		/// <summary>Not specified.</summary>
		NotSpecified,

		DELIVERY_PROOF, 
		INVOICE, 
		REFUND_PROOF, 
		USER_CORRESPONDANCE, 
		USER_ACCEPTANCE_PROOF, 
		PRODUCT_REPLACEMENT_PROOF, 
		OTHER
	}
}
