using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for refunds.</summary>
    public class ApiRefunds : ApiBase
    {
        /// <summary>Instantiates new ApiRefunds object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiRefunds(MangoPayApi root) : base(root) { }

        /// <summary>Gets refund.</summary>
        /// <param name="refundId">Refund identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO Get(string refundId)
        {
            return this.GetObject<RefundDTO>(MethodKey.RefundsGet, refundId);
        }
    }
}
