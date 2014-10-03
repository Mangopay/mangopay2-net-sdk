
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Secure mode enumeration.</summary>
    public enum SecureMode
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>Secured Mode is activated from €100.</summary>
        DEFAULT,

        /// <summary>Secured Mode is activated for any transaction's amount.</summary>
        FORCE
    }
}
