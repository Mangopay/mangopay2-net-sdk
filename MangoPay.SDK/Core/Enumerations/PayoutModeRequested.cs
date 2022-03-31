using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Core.Enumerations
{
    public enum PayoutModeRequested
    {
        /// <summary>
        /// (value by default if no parameter is sent): a standard bank wire is requested and the processing time of the funds is about 48 hours;
        /// </summary>
        STANDARD,

        /// <summary>
        /// an instant payment bank wire is requested and the processing time is within 25 seconds (subject to prerequisites);
        /// </summary>
        INSTANT_PAYMENT,

        /// <summary>
        /// an instant payment bank wire is requested and the processing time is within 25 seconds, but if any prerequisite is not met or another problem occurs, there is no fallback: the wallet is automatically refunded and the payout is not completed.
        /// </summary>
        INSTANT_PAYMENT_ONLY
    }
}
