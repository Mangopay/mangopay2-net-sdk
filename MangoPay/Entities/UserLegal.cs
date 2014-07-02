using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>UserLegal entity.</summary>
    public sealed class UserLegal : User
    {
        /// <summary>Name of this user.</summary>
        public String Name;

        /// <summary>Allowed types for legal user.</summary>
        public static class LegalPersonTypes
        {
            public static readonly String Business = "BUSINESS";
            public static readonly String Organization = "ASSOCIATION";
        }

        /// <summary>Type for legal user. One of UserLegal.LegalPersonTypes constants.</summary>
        public String LegalPersonType;

        /// <summary>Headquarters address.</summary>
        public String HeadquartersAddress;

        /// <summary>Legal representative first name.</summary>
        public String LegalRepresentativeFirstName;

        /// <summary>Legal representative last name.</summary>
        public String LegalRepresentativeLastName;

        /// <summary>Legal representative address.</summary>
        public String LegalRepresentativeAddress;

        /// <summary>Legal representative email.</summary>
        public String LegalRepresentativeEmail;

        /// <summary>Legal representative birthday.</summary>
        public long LegalRepresentativeBirthday;

        /// <summary>Legal representative nationality.</summary>
        public String LegalRepresentativeNationality;

        /// <summary>Legal representative country of residence.</summary>
        public String LegalRepresentativeCountryOfResidence;

        /// <summary>Statute.</summary>
        public String Statute;

        /// <summary>Proof of registration.</summary>
        public String ProofOfRegistration;

        /// <summary>Shareholder declaration.</summary>
        public String ShareholderDeclaration;

        /// <summary>Instantiates new UserLegal object.</summary>
        public UserLegal()
        {
            PersonType = Types.Legal;
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public List<String> getReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("Statute");
            result.Add("ProofOfRegistration");
            result.Add("ShareholderDeclaration");

            return result;
        }
    }
}
