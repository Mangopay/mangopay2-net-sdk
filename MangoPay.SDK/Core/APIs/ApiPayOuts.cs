using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
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
        public async Task<PayOutBankWireDTO> CreateBankWireAsync(PayOutBankWirePostDTO payOut)
        {
            return await CreateBankWireAsync(null, payOut);
        }

		/// <summary>Creates new PayOut object.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="payOut">The PayOut object to be created.</param>
		/// <returns>Created PayOut object returned from API.</returns>
		public async Task<PayOutBankWireDTO> CreateBankWireAsync(String idempotencyKey, PayOutBankWirePostDTO payOut)
		{
			return await this.CreateObjectAsync<PayOutBankWireDTO, PayOutBankWirePostDTO>(idempotencyKey, MethodKey.PayoutsBankwireCreate, payOut);
		}

        public async Task<PayOutEligibilityDTO> CheckInstantPayoutEligibility(PayOutEligibilityPostDTO payOut, string idempotencyKey = null)
        {
            return await this.CreateObjectAsync<PayOutEligibilityDTO, PayOutEligibilityPostDTO>(idempotencyKey,
                MethodKey.PayoutsEligibility, payOut);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOut identifier.</param>
        /// <returns>PayOut instance returned from API.</returns>
        public async Task<PayOutDTO> GetAsync(String payOutId)
        {
            return await this.GetObjectAsync<PayOutDTO>(MethodKey.PayoutsGet, payOutId);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOutBankWire identifier.</param>
        /// <returns>PayOutBankWire instance returned from API.</returns>
        public async Task<PayOutBankWireDTO> GetBankWireAsync(String payOutId)
        {
            return await this.GetObjectAsync<PayOutBankWireDTO>(MethodKey.PayoutsGet, payOutId);
        }

        /// <summary>
        /// Gets async PayOut Bankwire Entity by its identifier
        /// </summary>
        /// <param name="payoutId">PayOutBankWire identifier.</param>
        /// <returns></returns>
        public async Task<PayOutBankWireGetDTO> GetBankwirePayoutAsync(String payoutId)
        {
            return await this.GetObjectAsync<PayOutBankWireGetDTO>(MethodKey.PayoutsBankwireGet, payoutId);
        }

        /// <summary>Creates new PayOut object.</summary>
        /// <param name="payOut">The PayOut object to be created.</param>
        /// <returns>Created PayOut object returned from API.</returns>
        public PayOutBankWireDTO CreateBankWire(PayOutBankWirePostDTO payOut)
        {
            return CreateBankWire(null, payOut);
        }

        /// <summary>Creates new PayOut object.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payOut">The PayOut object to be created.</param>
        /// <returns>Created PayOut object returned from API.</returns>
        public PayOutBankWireDTO CreateBankWire(String idempotencyKey, PayOutBankWirePostDTO payOut)
        {
            return this.CreateObject<PayOutBankWireDTO, PayOutBankWirePostDTO>(idempotencyKey, MethodKey.PayoutsBankwireCreate, payOut);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOut identifier.</param>
        /// <returns>PayOut instance returned from API.</returns>
        public PayOutDTO Get(String payOutId)
        {
            return this.GetObject<PayOutDTO>(MethodKey.PayoutsGet, payOutId);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOutBankWire identifier.</param>
        /// <returns>PayOutBankWire instance returned from API.</returns>
        public PayOutBankWireDTO GetBankWire(String payOutId)
        {
            return this.GetObject<PayOutBankWireDTO>(MethodKey.PayoutsGet, payOutId);
        }

        /// <summary>
        /// Gets PayOut Bankwire Entity by its identifier
        /// </summary>
        /// <param name="payoutId">PayOutBankWire identifier.</param>
        /// <returns></returns>
        public PayOutBankWireGetDTO GetBankwirePayout(String payoutId)
        {
            return this.GetObject<PayOutBankWireGetDTO>(MethodKey.PayoutsBankwireGet, payoutId);
        }
    }
}
