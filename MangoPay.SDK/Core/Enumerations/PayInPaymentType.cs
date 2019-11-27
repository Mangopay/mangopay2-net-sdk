
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

        /// <summary>DIRECT DEBIT payment type.</summary>
        DIRECT_DEBIT,

        /// <summary>PREAUTHORIZED payment type.</summary>
        PREAUTHORIZED,

		/// <summary>PAYPAL payment type.</summary>
		PAYPAL,

        /// <summary> APPLEPAY payment type </summary>
        APPLEPAY,
    }
}
