using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account CA entity.</summary>
	public class BankAccountCaObsoleteDTO : BankAccountObsoleteDTO
    {
        /// <summary>Bank name.</summary>
        public string BankName { get; set; }

        /// <summary>Institution number.</summary>
        public string InstitutionNumber { get; set; }

        /// <summary>Branch code.</summary>
        public string BranchCode { get; set; }

        /// <summary>Account number.</summary>
        public string AccountNumber { get; set; }
    }
}
