using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for pay-outs.</summary>
    public class ApiPayOuts : ApiBase
    {
        /// <summary>Instantiates new ApiPayOuts object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPayOuts(MangoPayApi root) : base(root) { }

        /// <summary>Creates new PayOut object.</summary>
        /// <param name="payOut">The PayOut object to be created.</param>
        /// <returns>Created PayOut object returned from API.</returns>
        public PayOut Create(PayOut payOut)
        {
            String paymentKey = this.GetPaymentKey(payOut);
            return this.CreateObject<PayOut>(String.Format("payouts_{0}_create", paymentKey), payOut);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOut identifier.</param>
        /// <returns>PayOut instance returned from API.</returns>
        public PayOut Get(String payOutId)
        {
            return this.GetObject<PayOut>("payouts_get", payOutId);
        }

        private String GetPaymentKey(PayOut payOut)
        {
            if (payOut.MeanOfPaymentDetails == null)
                throw new Exception("Mean of payment is not defined or it is not object type");

            String className = payOut.MeanOfPaymentDetails.GetType().Name.Replace("PayOutPaymentDetails", "");
            return className.ToLower();

        }
    }
}
