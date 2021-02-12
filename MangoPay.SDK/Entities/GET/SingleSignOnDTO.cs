using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using UnixDateTimeConverter = MangoPay.SDK.Core.UnixDateTimeConverter;

namespace MangoPay.SDK.Entities.GET
{
	public class SingleSignOnDTO : EntityBase
	{
		/// <summary>The name of the user.</summary>
		public String FirstName { get; set; }

		/// <summary>The last name of the user.</summary>
		public String LastName { get; set; }

		/// <summary>Email address.</summary>
		public String Email { get; set; }

		/// <summary>Wheter the SSO is active or not.</summary>
		public bool Active { get; set; }

		/// <summary>Wheter the SSO is active or not.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public InvitationStatus InvitationStatus { get; set; }

		/// <summary>Date of the latest authentification.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? LastLoginDate { get; set; }

		/// <summary>Permission group ID assigned to this SSO.</summary>
		public String PermissionGroupId { get; set; }

		/// <summary>An ID for the client.</summary>
		public String ClientId { get; set; }
	}
}
