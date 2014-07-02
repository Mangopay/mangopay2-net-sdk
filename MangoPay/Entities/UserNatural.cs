using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>UserNatural entity.</summary>
    public sealed class UserNatural : User
    {
        /// <summary>First name.</summary>
        public String FirstName;

        /// <summary>Last name.</summary>
        public String LastName;

        /// <summary>Address.</summary>
        public String Address;

        /// <summary>Date of birth (UNIX timestamp).</summary>
        public long Birthday;

        /// <summary>Place of birth.</summary>
        public String Birthplace;

        /// <summary>User's country. ISO 3166-1 alpha-2.</summary>
        public String Nationality;

        /// <summary>Country of residence. ISO 3166-1 alpha-2.</summary>
        public String CountryOfResidence;

        /// <summary>User's occupation.</summary>
        public String Occupation;

        /// <summary>Income ranges:
        /// 1 (-18K€),
        /// 2 (18-30K€),
        /// 3 (30-50K€),
        /// 4 (50-80K€),
        /// 5 (80-120K€),
        /// 6 (+120K€).</summary>
        public static class IncomeRanges
        {
            public static readonly int Below18 = 1;
            public static readonly int From18To30 = 2;
            public static readonly int From30To50 = 3;
            public static readonly int From50To80 = 4;
            public static readonly int From80To120 = 5;
            public static readonly int Above120 = 6;
        }

        /// <summary>Income range. One of UserNatural.IncomeRanges constants.</summary>
        public int IncomeRange;

        /// <summary>Proof of identity.</summary>
        public String ProofOfIdentity;

        /// <summary>Proof of address.</summary>
        public String ProofOfAddress;

        /// <summary>Instantiates new UserNatural object.</summary>
        public UserNatural()
        {
            PersonType = Types.Natural;
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("ProofOfIdentity");
            result.Add("ProofOfAddress");

            return result;
        }
    }
}
