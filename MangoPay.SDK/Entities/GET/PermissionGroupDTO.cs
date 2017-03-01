using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.GET
{
	public class PermissionGroupDTO : EntityBase
	{
		/// <summary>The name of permission group.</summary>
		public String Name { get; set; }

		/// <summary>The type of permission group.</summary>
		public PermissionGroupType GroupType { get; set; }
		
		/// <summary>The scopes of the permission.</summary>
		public Scopes Scopes { get; set; }
	}
}
