using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayOutBankWireDTO : PayOutDTO
    {
        /// <summary>Bank account identifier.</summary>
        public string BankAccountId { get; set; }

        /// <summary>A custom reference you wish to appear on the user’s bank statement (your ClientId is already shown).</summary>
        public string BankWireRef { get; set; }
    }

    public class PayOutBankWireGetDTO : PayOutBankWireDTO
    {
        public new string Status { get; set; }

        public string ModeRequested { get; set; }

        public string ModeApplied { get; set; }

        public FallbackReason FallbackReason { get; set; }
    }

    public class FallbackReason
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
