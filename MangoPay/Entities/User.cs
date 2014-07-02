using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>User entity base class. Parent for <code>UserNatural</code> or <code>UserLegal</code> child types.</summary>
    public class User : EntityBase
    {
        /// <summary>Allowed types of user.</summary>
        public static class Types
        {
            public const String Natural = "NATURAL";
            public const String Legal = "LEGAL";
        }

        /// <summary>Type of user. One of User.Types constants.</summary>
        public String PersonType;

        /// <summary>Email address.</summary>
        public String Email;

        public User(String personType)
        {
            PersonType = personType;
        }

        /// <summary>Descendant classes override it.</summary>
        public User() { }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("PersonType");

            return result;
        }
    }
}
