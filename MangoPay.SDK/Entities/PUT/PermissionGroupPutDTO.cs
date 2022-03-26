using System;

namespace MangoPay.SDK.Entities.PUT
{
	public class PermissionGroupPutDTO : EntityPutBase
	{
		/// <summary>Custom data.</summary>
		public string Tag { get; set; }

		/// <summary>The name of permission group.</summary>
		public string Name { get; set; }

		/// <summary>The name of permission group.</summary>
		public Scopes Scopes { get; set; }
	}
}
