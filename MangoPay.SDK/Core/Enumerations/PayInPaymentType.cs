
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Payment type enumeration.</summary>
    public enum PayInPaymentType
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>CARD payment type.</summary>
        CARD, 

        /// <summary>BANK WIRE payment type.</summary>
        BANK_WIRE, 

        /// <summary>AUTOMATIC DEBIT payment type.</summary>
        AUTOMATIC_DEBIT, 

        /// <summary>DIRECT DEBIT payment type.</summary>
        DIRECT_DEBIT,

        /// <summary>PREAUTHORIZED payment type.</summary>
        PREAUTHORIZED
    }
}
