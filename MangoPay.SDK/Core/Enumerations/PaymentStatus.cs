
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Payment status enumeration.</summary>
    public enum PaymentStatus
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>WAITING payment status.</summary>
        WAITING, 

        /// <summary>CANCELED payment status.</summary>
        CANCELED, 

        /// <summary>EXPIRED payment status.</summary>
        EXPIRED, 

        /// <summary>VALIDATED payment status.</summary>
        VALIDATED,
        
        CANCEL_REQUESTED,
        
        TO_BE_COMPLETED,
        
        NO_SHOW_REQUESTED,
        
        NO_SHOW,
        
        FAILED
    }
}
