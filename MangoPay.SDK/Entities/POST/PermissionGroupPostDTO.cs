using System;

namespace MangoPay.SDK.Entities.POST
{
	public class PermissionGroupPostDTO : EntityPostBase
	{
		public PermissionGroupPostDTO(string name)
		{
			Name = name;
			Scopes = new Scopes();
		}

		/// <summary>The name of permission group.</summary>
		public String Name { get; set; }

		/// <summary>The name of permission group.</summary>
		public Scopes Scopes { get; set; }
	}
}
