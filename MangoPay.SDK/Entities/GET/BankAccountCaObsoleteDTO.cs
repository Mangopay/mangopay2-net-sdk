using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account CA entity.</summary>
	public class BankAccountCaObsoleteDTO : BankAccountObsoleteDTO
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
