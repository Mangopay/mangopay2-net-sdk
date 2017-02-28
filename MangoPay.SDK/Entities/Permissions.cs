using System;

namespace MangoPay.SDK.Entities
{
	public class Permissions
	{
		public Permissions()
		{
		}

		public Permissions(bool read, bool edit, bool create)
		{
			Read = read;
			Edit = edit;
			Create = create;
		}

		/// <summary>Allow GET requests on the related endpoints.</summary>
		public bool Read { get; set; }

		/// <summary>Allow PUT requests on the related endpoints.</summary>
		public bool Edit { get; set; }

		/// <summary>Allow POST requests on the related endpoints.</summary>
		public bool Create { get; set; }
	}
}
