using System;

namespace MangoPay.Entities
{
    /// <summary>Class represents US type of bank account.</summary>
    public class BankAccountUsDTO : BankAccountDTO
    {
        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }

        /// <summary>ABA.</summary>
        public String ABA { get; set; }
    }
}
