using System;

namespace MangoPay.SDK.Entities.GET
{
	public class PermissionGroupDTO : EntityBase
	{
		/// <summary>The name of permission group.</summary>
		public String Name { get; set; }

		/// <summary>The name of permission group.</summary>
		public Scopes Scopes { get; set; }
	}
}
