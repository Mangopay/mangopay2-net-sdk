
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

        /// <summary> GooglePay payment type </summary>
        GOOGLEPAY,

        /// <summary>
        /// Payconiq payment type 
        /// </summary>
        PAYCONIQ,
        
        /// <summary> Mbway payment type </summary>
        MBWAY,
        /// <summary> Multibanco payment type </summary>
        MULTIBANCO,
        /// <summary> Satispay payment type </summary>
        SATISPAY,
        /// <summary> Blik payment type </summary>
        BLIK,
        /// <summary> Klarna payment type </summary>
        KLARNA,
    }
}
