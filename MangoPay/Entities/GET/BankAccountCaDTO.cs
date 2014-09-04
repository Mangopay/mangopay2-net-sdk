using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>Bank Account CA entity.</summary>
    public class BankAccountCaDTO : BankAccountDTO
    {
        /// <summary>Bank name.</summary>
        public String BankName { get; set; }

        /// <summary>Institution number.</summary>
        public String InstitutionNumber { get; set; }

        /// <summary>Branch code.</summary>
        public String BranchCode { get; set; }

        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }
    }
}
