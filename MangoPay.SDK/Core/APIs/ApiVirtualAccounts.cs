using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for VirtualAccounts</summary>
    public class ApiVirtualAccounts : ApiBase
    {
        /// <summary>Instantiates new ApiVirtualAccounts object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiVirtualAccounts(MangoPayApi root) : base(root) { }
        
        public async Task<VirtualAccountDTO> CreateAsync(string walletId, VirtualAccountPostDTO virtualAccount, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<VirtualAccountDTO, VirtualAccountPostDTO>(MethodKey.VirtualAccountCreate, virtualAccount, idempotentKey, entitiesId: walletId);
        }
        
        /// <summary>Gets given VirtualAccount associated with wallet</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="virtualAccountId">Virtual Account identifier.</param>
        /// <returns>VirtualAccount Object</returns>
        public async Task<VirtualAccountDTO> GetAsync(string walletId, string virtualAccountId)
        {
            return await this.GetObjectAsync<VirtualAccountDTO>(MethodKey.VirtualAccountGet, entitiesId: new[] { walletId, virtualAccountId });
        }
        
        /// <summary>Gets all VirtualAccounts associated with wallet</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>All related Virtual Account Object</returns>
        public async Task<ListPaginated<VirtualAccountDTO>> GetAllAsync(string walletId, Pagination pagination = null, FilterTransactions filter = null, Sort sort = null)
        {
            return await this.GetListAsync<VirtualAccountDTO>(MethodKey.VirtualAccountGetAll, pagination, sort, filter?.GetValues(), entitiesId: walletId);
        }

        /// <summary>Deactivates given VirtualAccount</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="virtualAccountId">Virtual Account identifier.</param>
        /// <returns>Deactivated VirtualAccount Object</returns>
        public async Task<VirtualAccountDTO> DeactivateAsync(string walletId, string virtualAccountId)
        {
            return await this.UpdateObjectAsync<VirtualAccountDTO, VirtualAccountPutDTO>(MethodKey.VirtualAccountDeactivate, new VirtualAccountPutDTO(), entitiesId: new[] { walletId, virtualAccountId });
        }

        /// <summary>Gets all virtual account availabilities.</summary>
        /// <returns>VirtualAccountAvailabilities Object</returns>
        public async Task<VirtualAccountAvailabilities> GetAvailabilitiesAsync()
        {
            return await this.GetObjectAsync<VirtualAccountAvailabilities>(MethodKey.VirtualAccountGetAvailabilities);
        }
    }
}