using System;

namespace MangoPay.Entities
{
    /// <summary>Class represents GB type of bank account.</summary>
    public class BankAccountGbDTO : BankAccountDTO
    {
        /// <summary>Account number.</summary>
        public String AccountNumber { get; set; }

        /// <summary>Sort code.</summary>
        public String SortCode { get; set; }
    }
}
