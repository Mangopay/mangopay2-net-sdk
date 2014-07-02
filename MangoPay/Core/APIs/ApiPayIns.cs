using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for pay-ins.</summary>
    public class ApiPayIns : ApiBase
    {
        /// <summary>Instantiates new ApiPayIns object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPayIns(MangoPayApi root) : base(root) { }

        /// <summary>Creates new PayIn object.</summary>
        /// <param name="payIn">The PayIn object to be created.</param>
        /// <returns>Created PayIn object returned from API.</returns>
        public PayIn Create(PayIn payIn)
        {
            String paymentKey = this.GetPaymentKey(payIn);
            String executionKey = this.GetExecutionKey(payIn);
            return this.CreateObject<PayIn>(String.Format("payins_{0}-{1}_create", paymentKey, executionKey), payIn);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayIn Get(String payInId)
        {
            return this.GetObject<PayIn>("payins_get", payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public Refund CreateRefund(String payInId, Refund refund)
        {
            return this.CreateObject<Refund>("payins_createrefunds", refund, payInId);
        }

        /// <summary>Gets refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public Refund GetRefund(String payInId)
        {
            return this.GetObject<Refund>("payins_getrefunds", payInId);
        }

        private String GetPaymentKey(PayIn payIn)
        {
            if (payIn.PaymentDetails == null)
                throw new Exception("Payment is not defined or it is not object type");

            String className = payIn.PaymentDetails.GetType().Name.Replace("PayInPaymentDetails", "");
            return className.ToLower();
        }

        private String GetExecutionKey(PayIn payIn)
        {
            if (payIn.ExecutionDetails == null)
                throw new Exception("Execution is not defined or it is not object type");

            String className = payIn.ExecutionDetails.GetType().Name.Replace("PayInExecutionDetails", "");
            return className.ToLower();
        }
    }
}
