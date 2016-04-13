using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Client PUT entity.</summary>
	public class ClientPutDTO : EntityPutBase
    {
		/// <summary>Your branding colour to use for theme pages.</summary>
		public String PrimaryThemeColour;

		/// <summary>Your branding colour to use for call to action buttons.</summary>
		public String PrimaryButtonColour;
    }
}
