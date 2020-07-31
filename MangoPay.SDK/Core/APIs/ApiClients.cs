using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.IO;
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
		public async Task<ListPaginated<KycDocumentDTO>> GetKycDocuments(Pagination pagination, FilterKycDocuments filter, Sort sort = null)
		{
			if (filter == null) filter = new FilterKycDocuments();

			return await this.GetList<KycDocumentDTO>(MethodKey.ClientGetKycDocuments, pagination, sort, filter.GetValues());
		}


		/// <summary>Gets client wallets.</summary>
		/// <param name="fundsType">Type of funds.</param>
		/// <param name="pagination">Pagination.</param>
		/// <returns>Collection of client's wallets.</returns>
		public async Task<ListPaginated<WalletDTO>> GetWallets(FundsType fundsType, Pagination pagination)
		{
			switch (fundsType)
			{
				case FundsType.DEFAULT:
					return await this.GetList<WalletDTO>(MethodKey.ClientGetWalletsDefault, pagination);
				case FundsType.FEES:
					return await this.GetList<WalletDTO>(MethodKey.ClientGetWalletsFees, pagination);
				case FundsType.CREDIT:
					return await this.GetList<WalletDTO>(MethodKey.ClientGetWalletsCredit, pagination);
			}

			return null;
		}

		/// <summary>Gets client wallet.</summary>
		/// <param name="fundsType">Type of funds.</param>
		/// <param name="currency">Currency.</param>
		/// <returns>Wallet with given funds type and currency.</returns>
		public async Task<WalletDTO> GetWallet(FundsType fundsType, CurrencyIso currency)
		{
			if (currency == CurrencyIso.NotSpecified) return null;

			switch (fundsType)
			{
				case FundsType.DEFAULT:
					return await this.GetObject<WalletDTO>(MethodKey.ClientGetWalletsDefaultWithCurrency, currency.ToString());
				case FundsType.FEES:
					return await this.GetObject<WalletDTO>(MethodKey.ClientGetWalletsFeesWithCurrency, currency.ToString());
				case FundsType.CREDIT:
					return await this.GetObject<WalletDTO>(MethodKey.ClientGetWalletsCreditWithCurrency, currency.ToString());
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
		public async Task<ListPaginated<TransactionDTO>> GetWalletTransactions(FundsType fundsType, CurrencyIso currency, Pagination pagination, FilterTransactions filter, Sort sort = null)
		{
			if (filter == null) filter = new FilterTransactions();

			return await this.GetList<TransactionDTO>(MethodKey.ClientGetWalletTransactions, pagination, sort, filter.GetValues(),fundsType.ToString(), currency.ToString());
		}


		/// <summary>Gets client transactions.</summary>
		/// <param name="pagination">Pagination.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="sort">Sort.</param>
		/// <returns>Collection of client's transactions.</returns>
		public async Task<ListPaginated<TransactionDTO>> GetTransactions(Pagination pagination, FilterTransactions filter, Sort sort = null)
		{
			if (filter == null) filter = new FilterTransactions();

			return await this.GetList<TransactionDTO>(MethodKey.ClientGetTransactions, pagination, sort, filter.GetValues());
		}

		/// <summary>Creates new bankwire direct for client.</summary>
		/// <param name="bankWireDirect">Object instance to be created.</param>
		/// <returns>Object instance returned from API.</returns>
		public async Task<PayInBankWireDirectDTO> CreateBankWireDirect(ClientBankWireDirectPostDTO bankWireDirect)
		{
			return await CreateBankWireDirect(null, bankWireDirect);
		}

		/// <summary>Creates new bankwire direct for client.</summary>
		/// <param name="idempotencyKey">Idempotency key for this request.</param>
		/// <param name="bankWireDirect">Object instance to be created.</param>
		/// <returns>Object instance returned from API.</returns>
		public async Task<PayInBankWireDirectDTO> CreateBankWireDirect(String idempotencyKey, ClientBankWireDirectPostDTO bankWireDirect)
		{
			return await this.CreateObject<PayInBankWireDirectDTO, ClientBankWireDirectPostDTO>(idempotencyKey, MethodKey.ClientCreateBankwireDirect, bankWireDirect);
		}

		/// <summary>Gets client entity.</summary>
		/// <returns>Object instance returned from API.</returns>
		public async Task<ClientDTO> Get()
		{
			return await this.GetObject<ClientDTO>(MethodKey.ClientGet, null);
		}

		/// <summary>Updates client information.</summary>
		/// <param name="client">Client entity instance to be updated.</param>
		/// <returns>Updated Client entity.</returns>
		public async Task<ClientDTO> Save(ClientPutDTO client)
		{
			return await this.UpdateObject<ClientDTO, ClientPutDTO>(MethodKey.ClientSave, client);
		}

		/// <summary>Uploads logo for client.</summary>
		/// <param name="binaryData">Binary file content (only GIF, PNG, JPG, JPEG, BMP, PDF and DOC formats are accepted).</param>
		public async Task<bool> UploadLogo(byte[] binaryData)
		{
			String fileContent = Convert.ToBase64String(binaryData);

			ClientLogoPutDTO logo = new ClientLogoPutDTO(fileContent);

			var result = await this.UpdateObject<ClientDTO, ClientLogoPutDTO>(MethodKey.ClientUploadLogo, logo);

            return result != null;
		}

		/// <summary>Uploads logo for client.</summary>
		/// <param name="filePath">Path to logo file (only GIF, PNG, JPG, JPEG, BMP, PDF and DOC formats are accepted).</param>
		public async Task<bool> UploadLogo(string filePath)
		{
			byte[] fileArray = File.ReadAllBytes(filePath);
			return await UploadLogo(fileArray);
		}
	}
}
