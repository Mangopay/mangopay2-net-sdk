using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayOutBankWireDTO : PayOutDTO
    {
        /// <summary>Bank account identifier.</summary>
        public String BankAccountId { get; set; }

        /// <summary>A custom reference you wish to appear on the user’s bank statement (your ClientId is already shown).</summary>
        public String BankWireRef { get; set; }
    }

    public class PayOutBankWireGetDTO : PayOutBankWireDTO
    {
        public new String Status { get; set; }

        public String ModeRequested { get; set; }

        public String ModeApplied { get; set; }

        public String FallbackReason { get; set; }
    }
}
