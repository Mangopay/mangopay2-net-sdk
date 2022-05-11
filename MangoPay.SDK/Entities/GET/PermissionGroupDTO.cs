using MangoPay.SDK.Core.Enumerations;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
	public class PermissionGroupDTO : EntityBase
	{
		/// <summary>The name of permission group.</summary>
		public string Name { get; set; }

		/// <summary>The type of permission group.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public PermissionGroupType Type { get; set; }
		
		/// <summary>The scopes of the permission.</summary>
		public Scopes Scopes { get; set; }
	}
}
