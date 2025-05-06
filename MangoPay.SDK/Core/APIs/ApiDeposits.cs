using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for deposits.</summary>
    public class ApiDeposits : ApiBase
    {
        /// <summary>Instantiates new ApiDeposits object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiDeposits(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Creates new deposit.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="deposit">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<DepositDTO> CreateAsync(DepositPostDTO deposit, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<DepositDTO, DepositPostDTO>(MethodKey.DepositsCreate, deposit,
                idempotentKey);
        }

        /// <summary>Gets deposit.</summary>
        /// <param name="depositId">Deposit identifier.</param>
        /// <returns>Deposit instance returned from API.</returns>
        public async Task<DepositDTO> GetAsync(string depositId)
        {
            return await this.GetObjectAsync<DepositDTO>(MethodKey.DepositsGet, entitiesId: depositId);
        }

        /// <summary>Cancel deposit.</summary>
        /// <param name="depositId">Deposit identifier.</param>
        /// <returns>Deposit object returned from API.</returns>
        public async Task<DepositDTO> CancelAsync(string depositId)
        {
            DepositPutDTO dto = new DepositPutDTO {PaymentStatus = PaymentStatus.CANCELED};

            return await this.UpdateObjectAsync<DepositDTO, DepositPutDTO>(
                MethodKey.DepositsCancel, dto, entitiesId: depositId);
        }
        
        /// <summary>List Deposit Preauthorizations for a Card</summary>
        /// <param name="cardId">Card identifier.</param>
        /// <param name="pagination">Pagination.</param>
        ///         /// <param name="filter">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of DepositDTO</returns>
        public async Task<ListPaginated<DepositDTO>> GetAllForCardAsync(string cardId, FilterPreAuthorizations filter,
            Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<DepositDTO>(MethodKey.DepositsGetAllForCard, pagination, sort,
                filter.GetValues(), entitiesId: cardId);
        }
        
        /// <summary>List Deposit Preauthorizations for a User</summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="pagination">Pagination.</param>
        ///         /// <param name="filter">Filters.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>List of DepositDTO</returns>
        public async Task<ListPaginated<DepositDTO>> GetAllForUserAsync(string userId, FilterPreAuthorizations filter,
            Pagination pagination = null, Sort sort = null)
        {
            return await this.GetListAsync<DepositDTO>(MethodKey.DepositsGetAllForUser, pagination, sort,
                filter.GetValues(), entitiesId: userId);
        }
    }
}