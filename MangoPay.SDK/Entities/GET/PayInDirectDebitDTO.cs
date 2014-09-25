using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInDirectDebitDTO : PayInDTO
    {
        /// <summary>Direct debit type.</summary>
        public DirectDebitType DirectDebitType { get; set; }

        /// <summary>URL format expected.</summary>
        public String TemplateURLOptions { get; set; }

        /// <summary>Culture.</summary>
        public String Culture { get; set; }

        /// <summary>Redirect URL.</summary>
        public String RedirectURL { get; set; }

        /// <summary>Return URL.</summary>
        public String ReturnURL { get; set; }
    }
}
