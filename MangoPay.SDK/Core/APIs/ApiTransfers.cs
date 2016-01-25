using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for transfers.</summary>
    public class ApiTransfers : ApiBase
    {
        /// <summary>Instantiates new ApiTransfers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiTransfers(MangoPayApi root) : base(root) { }

        /// <summary>Creates new transfer.</summary>
        /// <param name="transfer">Transfer entity instance to be created.</param>
        /// <returns>Transfer object returned from API.</returns>
        public TransferDTO Create(TransferPostDTO transfer)
        {
            return Create(null, transfer);
        }

		/// <summary>Creates new transfer.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="transfer">Transfer entity instance to be created.</param>
		/// <returns>Transfer object returned from API.</returns>
		public TransferDTO Create(String idempotencyKey, TransferPostDTO transfer)
		{
			return this.CreateObject<TransferDTO, TransferPostDTO>(idempotencyKey, MethodKey.TransfersCreate, transfer);
		}

        /// <summary>Gets the transfer.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <returns>Transfer instance returned from API.</returns>
        public TransferDTO Get(String transferId)
        {
            return this.GetObject<TransferDTO>(MethodKey.TransfersGet, transferId);
        }

        /// <summary>Creates refund for transfer object.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <param name="refund">Refund object to create.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO CreateRefund(String transferId, RefundTransferPostDTO refund)
        {
            return CreateRefund(null, transferId, refund);
        }

		/// <summary>Creates refund for transfer object.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="transferId">Transfer identifier.</param>
		/// <param name="refund">Refund object to create.</param>
		/// <returns>Refund entity instance returned from API.</returns>
		public RefundDTO CreateRefund(String idempotencyKey, String transferId, RefundTransferPostDTO refund)
		{
			return this.CreateObject<RefundDTO, RefundTransferPostDTO>(idempotencyKey, MethodKey.TransfersCreateRefunds, refund, transferId);
		}

        /// <summary>Gets refund for transfer object.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO GetRefund(String transferId)
        {
            return this.GetObject<RefundDTO>(MethodKey.TransfersGetRefunds, transferId);
        }
    }
}
