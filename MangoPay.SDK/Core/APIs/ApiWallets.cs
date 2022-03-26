using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for wallets.</summary>
    public class ApiWallets : ApiBase
    {
        /// <summary>Instantiates new ApiWallets object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiWallets(MangoPayApi root) : base(root) { }

        /// <summary>Creates new wallet.</summary>
        /// <param name="wallet">Wallet instance to be created.</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> CreateAsync(WalletPostDTO wallet, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<WalletDTO, WalletPostDTO>(MethodKey.WalletsCreate, wallet, idempotentKey);
        }

        /// <summary>Gets wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> GetAsync(string walletId)
        {
            return await this.GetObjectAsync<WalletDTO>(MethodKey.WalletsGet, walletId);
        }

        /// <summary>Updates wallet.</summary>
        /// <param name="wallet">Wallet object to save.</param>
        /// <param name="walletId">Wallet identifier.</param>
        /// <returns>Wallet instance returned from API.</returns>
        public async Task<WalletDTO> UpdateAsync(WalletPutDTO wallet, string walletId)
        {
            return await this.UpdateObjectAsync<WalletDTO, WalletPutDTO>(MethodKey.WalletsSave, wallet, entitiesId: walletId);
        }

        /// <summary>Gets transactions for the wallet.</summary>
        /// <param name="walletId">Wallet identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Transactions for wallet returned from API.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(string walletId, Pagination pagination = null, FilterTransactions filter = null, Sort sort = null)
        {
            return await this.GetListAsync<TransactionDTO>(MethodKey.WalletsAllTransactions, pagination, sort, filter?.GetValues(), entitiesId: walletId);
        }
    }
}
