using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for transfers.</summary>
    public class ApiTransfers : ApiBase
    {
        /// <summary>Instantiates new ApiTransfers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiTransfers(MangoPayApi root) : base(root) { }

        /// <summary>Creates new transfer.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="transfer">Transfer entity instance to be created.</param>
        /// <returns>Transfer object returned from API.</returns>
        public async Task<TransferDTO> CreateAsync(TransferPostDTO transfer, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<TransferDTO, TransferPostDTO>(MethodKey.TransfersCreate, transfer, idempotentKey);
        }

        /// <summary>Gets the transfer.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <returns>Transfer instance returned from API.</returns>
        public async Task<TransferDTO> GetAsync(string transferId)
        {
            return await this.GetObjectAsync<TransferDTO>(MethodKey.TransfersGet, entitiesId: transferId);
        }

        /// <summary>Creates refund for transfer object.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="transferId">Transfer identifier.</param>
        /// <param name="refund">Refund object to create.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefundAsync(string transferId, RefundTransferPostDTO refund, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RefundDTO, RefundTransferPostDTO>(MethodKey.TransfersCreateRefunds, refund, idempotentKey, transferId);
        }
    }
}
