using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for clients.</summary>
    public class ApiClients : ApiBase
    {
        /// <summary>Instantiates new ApiClients object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiClients(MangoPayApi root) : base(root) { }

        /// <summary>***Now depreciated and soon to be removed from this class (already moved to ApiKyc.cs)*** Gets the list of all the uploaded documents for all users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of all users' uploaded documents.</returns>
        public async Task<ListPaginated<KycDocumentDTO>> GetKycDocumentsAsync(Pagination pagination, FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return await this.GetListAsync<KycDocumentDTO>(MethodKey.ClientGetKycDocuments, pagination, sort, filter.GetValues());
        }


        /// <summary>Gets client wallets.</summary>
        /// <param name="fundsType">Type of funds.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Collection of client's wallets.</returns>
        public async Task<ListPaginated<WalletDTO>> GetWalletsAsync(FundsType fundsType, Pagination pagination)
        {
            switch (fundsType)
            {
                case FundsType.DEFAULT:
                    return await this.GetListAsync<WalletDTO>(MethodKey.ClientGetWalletsDefault, pagination);
                case FundsType.FEES:
                    return await this.GetListAsync<WalletDTO>(MethodKey.ClientGetWalletsFees, pagination);
                case FundsType.CREDIT:
                    return await this.GetListAsync<WalletDTO>(MethodKey.ClientGetWalletsCredit, pagination);
            }

            return null;
        }

        /// <summary>Gets client wallet.</summary>
        /// <param name="fundsType">Type of funds.</param>
        /// <param name="currency">Currency.</param>
        /// <returns>Wallet with given funds type and currency.</returns>
        public async Task<WalletDTO> GetWalletAsync(FundsType fundsType, CurrencyIso currency, Pagination pagination = null)
        {
            if (currency == CurrencyIso.NotSpecified) return null;

            switch (fundsType)
            {
                case FundsType.DEFAULT:
                    return await this.GetObjectAsync<WalletDTO>(MethodKey.ClientGetWalletsDefaultWithCurrency, entitiesId: currency.ToString());
                case FundsType.FEES:
                    return await this.GetObjectAsync<WalletDTO>(MethodKey.ClientGetWalletsFeesWithCurrency, entitiesId: currency.ToString());
                case FundsType.CREDIT:
                    return await this.GetObjectAsync<WalletDTO>(MethodKey.ClientGetWalletsCreditWithCurrency, entitiesId: currency.ToString());
                case FundsType.NotSpecified:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fundsType), fundsType, null);
            }

            return null;
        }

        /// <summary>Gets client wallet transactions.</summary>
        /// <param name="fundsType">Type of funds.</param>
        /// <param name="currency">Currency.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns></returns>
        public async Task<ListPaginated<TransactionDTO>> GetWalletTransactionsAsync(FundsType fundsType, CurrencyIso currency, Pagination pagination, FilterTransactions filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterTransactions();

            return await this.GetListAsync<TransactionDTO>(MethodKey.ClientGetWalletTransactions, pagination, sort, filter.GetValues(), null, fundsType.ToString(), currency.ToString());
        }


        /// <summary>Gets client transactions.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of client's transactions.</returns>
        public async Task<ListPaginated<TransactionDTO>> GetTransactionsAsync(Pagination pagination, FilterTransactions filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterTransactions();

            return await this.GetListAsync<TransactionDTO>(MethodKey.ClientGetTransactions, pagination, sort, filter.GetValues());
        }

        /// <summary>Creates new bank wire direct for client.</summary>
        /// <param name="bankWireDirect">Object instance to be created.</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirectAsync(ClientBankWireDirectPostDTO bankWireDirect, string idempotentKey = null)
        {
            return await 
                this.CreateObjectAsync<PayInBankWireDirectDTO, ClientBankWireDirectPostDTO>(MethodKey.ClientCreateBankwireDirect, bankWireDirect, idempotentKey);
        }

        /// <summary>Gets client entity.</summary>
        /// <returns>Object instance returned from API.</returns>
        public async Task<ClientDTO> GetAsync()
        {
            return await this.GetObjectAsync<ClientDTO>(MethodKey.ClientGet, null);
        }

        /// <summary>Updates client information.</summary>
        /// <param name="client">Client entity instance to be updated.</param>
        /// <returns>Updated Client entity.</returns>
        public async Task<ClientDTO> SaveAsync(ClientPutDTO client)
        {
            return await this.UpdateObjectAsync<ClientDTO, ClientPutDTO>(MethodKey.ClientSave, client);
        }

        /// <summary>Uploads logo for client.</summary>
        /// <param name="binaryData">Binary file content (only GIF, PNG, JPG, JPEG, BMP, PDF and DOC formats are accepted).</param>
        public async Task<bool> UploadLogoAsync(byte[] binaryData)
        {
            var fileContent = Convert.ToBase64String(binaryData);

            var logo = new ClientLogoPutDTO(fileContent);

            var result = await this.UpdateObjectAsync<ClientDTO, ClientLogoPutDTO>(MethodKey.ClientUploadLogo, logo);

            return result != null;
        }

        /// <summary>Uploads logo for client.</summary>
        /// <param name="filePath">Path to logo file (only GIF, PNG, JPG, JPEG, BMP, PDF and DOC formats are accepted).</param>
        public async Task<bool> UploadLogoAsync(string filePath)
        {
            var fileArray = File.ReadAllBytes(filePath);
            return await UploadLogoAsync(fileArray);
        }

        /// <summary>
        /// Creates BankAccountIban Async
        /// </summary>
        /// <param name="bankAccount">BankAccountIbanPostDTO object</param>
        /// <param name="idempotentKey"></param>
        /// <returns></returns>
        public async Task<BankAccountIbanDTO> CreateBankAccountIbanAsync(BankAccountIbanPostDTO bankAccount, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<BankAccountIbanDTO, BankAccountIbanPostDTO>(MethodKey.ClientBankAccount, bankAccount, idempotentKey);
        }

        /// <summary>
        /// Creates a payout async
        /// </summary>
        /// <param name="payOut">PayOut object</param>
        /// <param name="idempotentKey">Idempotent Key</param>
        /// <returns></returns>
        public async Task<PayOutBankWireDTO> CreatePayoutAsync(WalletPayoutDTO payOut, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayOutBankWireDTO, WalletPayoutDTO>(MethodKey.ClientPayout, payOut, idempotentKey);
        }
    }
}
