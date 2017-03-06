using System;

namespace MangoPay.SDK.Entities.PUT
{
	public class PermissionGroupPutDTO : EntityPutBase
	{
		/// <summary>Custom data.</summary>
		public String Tag { get; set; }

		/// <summary>The name of permission group.</summary>
		public String Name { get; set; }

		/// <summary>The name of permission group.</summary>
		public Scopes Scopes { get; set; }
	}
}
