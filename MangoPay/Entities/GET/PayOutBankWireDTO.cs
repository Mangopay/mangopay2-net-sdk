using System;

namespace MangoPay.Entities
{
    public class PayOutBankWireDTO : PayOutDTO
    {
        /// <summary>Bank account identifier.</summary>
        public String BankAccountId { get; set; }

        /// <summary>Communication.</summary>
        public String Communication { get; set; }
    }
}
