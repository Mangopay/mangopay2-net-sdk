using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
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
        public async Task<RefundDTO> GetAsync(string refundId)
        {
            return await this.GetObjectAsync<RefundDTO>(MethodKey.RefundsGet, entitiesId: refundId);
        }

        /// <summary>Lists refunds for a payout</summary>
        /// <param name="payOutId">Id of the payout to get refunds for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of refunds for a payout</returns>
        public async Task<ListPaginated<RefundDTO>> GetRefundsForPayOutAsync(string payOutId, Pagination pagination, FilterRefunds filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterRefunds();

            return await GetListAsync<RefundDTO>(MethodKey.PayoutsGetRefunds, pagination, sort, filters.GetValues(), entitiesId: payOutId);
        }

        /// <summary>Lists refunds for a pay in</summary>
        /// <param name="payInId">Id of the pay in to get refunds for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of refunds for a pay in</returns>
        public async Task<ListPaginated<RefundDTO>> GetRefundsForPayInAsync(string payInId, Pagination pagination, FilterRefunds filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterRefunds();

            return await GetListAsync<RefundDTO>(MethodKey.PayinsGetRefunds, pagination, sort, filters.GetValues(), entitiesId: payInId);
        }

        /// <summary>Lists refunds for a transfer</summary>
        /// <param name="transferId">Id of the transfer to get refunds for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of refunds for a transfer</returns>
        public async Task<ListPaginated<RefundDTO>> GetRefundsForTransferAsync(string transferId, Pagination pagination, FilterRefunds filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterRefunds();

            return await GetListAsync<RefundDTO>(MethodKey.TransfersGetRefunds, pagination, sort, filters.GetValues(), entitiesId: transferId);
        }

        /// <summary>Lists refunds for a repudiation</summary>
        /// <param name="repudiationId">Id of the repudiation to get refunds for</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filters">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of refunds for a repudiation</returns>
        public async Task<ListPaginated<RefundDTO>> GetRefundsForRepudiationAsync(string repudiationId, Pagination pagination, FilterRefunds filters, Sort sort = null)
        {
            if (filters == null) filters = new FilterRefunds();

            return await GetListAsync<RefundDTO>(MethodKey.DisputesRepudiationGetRefunds, pagination, sort, filters.GetValues(), entitiesId: repudiationId);
        }
    }
}
