using System;

namespace MangoPay.SDK.Entities.POST
{
	/// <summary>User natural POST entity.</summary>
	public class SingleSignOnPostDTO : EntityPostBase
    {
        public SingleSignOnPostDTO(string firstName, string lastName, string email)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

		/// <summary>The name of the user.</summary>
		public String FirstName { get; set; }

		/// <summary>The last name of the user.</summary>
		public String LastName { get; set; }

		/// <summary>Email address.</summary>
		public String Email { get; set; }
	}
}
