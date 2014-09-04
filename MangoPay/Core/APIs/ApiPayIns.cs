using MangoPay.Entities;
using System;

namespace MangoPay.Core
{
    /// <summary>API for pay-ins.</summary>
    public class ApiPayIns : ApiBase
    {
        /// <summary>Instantiates new ApiPayIns object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPayIns(MangoPayApi root) : base(root) { }

        /// <summary>Creates new payin bankwire direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInBankWireDirectDTO CreateBankWireDirect(PayInBankWireDirectPostDTO payIn)
        {
            return this.CreateObject<PayInBankWireDirectDTO, PayInBankWireDirectPostDTO>(MethodKey.PayinsBankwireDirectCreate, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardDirectDTO CreateCardDirect(PayInCardDirectPostDTO payIn)
        {
            return this.CreateObject<PayInCardDirectDTO, PayInCardDirectPostDTO>(MethodKey.PayinsCardDirectCreate, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardWebDTO CreateCardWeb(PayInCardWebPostDTO payIn)
        {
            return this.CreateObject<PayInCardWebDTO, PayInCardWebPostDTO>(MethodKey.PayinsCardWebCreate, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInPreauthorizedDirectDTO CreatePreauthorizedDirect(PayInPreauthorizedDirectPostDTO payIn)
        {
            return this.CreateObject<PayInPreauthorizedDirectDTO, PayInPreauthorizedDirectPostDTO>(MethodKey.PayinsPreauthorizedDirectCreate, payIn);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInDTO Get(String payInId)
        {
            return this.GetObject<PayInDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn bankwire direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInBankWireDirectDTO GetBankWireDirect(String payInId)
        {
            return this.GetObject<PayInBankWireDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn card direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInCardDirectDTO GetCardDirect(String payInId)
        {
            return this.GetObject<PayInCardDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn car web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInCardWebDTO GetCardWeb(String payInId)
        {
            return this.GetObject<PayInCardWebDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn preauthorized direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInPreauthorizedDirectDTO GetPreauthorizedDirect(String payInId)
        {
            return this.GetObject<PayInPreauthorizedDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO CreateRefund(String payInId, RefundPostDTO refund)
        {
            return this.CreateObject<RefundDTO, RefundPostDTO>(MethodKey.PayinsCreateRefunds, refund, payInId);
        }

        /// <summary>Gets refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO GetRefund(String payInId)
        {
            return this.GetObject<RefundDTO>(MethodKey.PayinsGetRefunds, payInId);
        }
    }
}
