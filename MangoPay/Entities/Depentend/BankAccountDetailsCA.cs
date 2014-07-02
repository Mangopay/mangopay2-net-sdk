using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class represents CA type of bank account.</summary>
    public class BankAccountDetailsCA : Dto, IBankAccountDetails
    {
        /// <summary>Bank name.</summary>
        public String BankName;

        /// <summary>Institution number.</summary>
        public String InstitutionNumber;

        /// <summary>Branch code.</summary>
        public String BranchCode;

        /// <summary>Account number.</summary>
        public String AccountNumber;
    }
}
