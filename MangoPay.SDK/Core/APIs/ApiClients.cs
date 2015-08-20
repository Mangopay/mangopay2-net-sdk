using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for clients.</summary>
    public class ApiClients : ApiBase
    {
        /// <summary>Instantiates new ApiClients object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiClients(MangoPayApi root) : base(root) { }

        /// <summary>Gets client data for Basic Access Authentication.</summary>
        /// <param name="clientId">Client's identifier.</param>
        /// <param name="clientName">Client's name for presentation.</param>
        /// <param name="clientEmail">Client's email.</param>
        /// <returns>Client instance returned from API.</returns>
        public ClientDTO Create(String clientId, String clientName, String clientEmail)
        {
            String urlMethod = this.GetRequestUrl(MethodKey.AuthenticationBase);
            String requestType = this.GetRequestType(MethodKey.AuthenticationBase);

            Dictionary<String, String> requestData = new Dictionary<String, String>
            {
                { Constants.CLIENT_ID, clientId },
                { Constants.NAME, clientName },
                { Constants.EMAIL, clientEmail }
            };

            RestTool restTool = new RestTool(this._root, false);
            restTool.AddRequestHttpHeader(Constants.CONTENT_TYPE, Constants.APPLICATION_X_WWW_FORM_URLENCODED);
            return restTool.Request<ClientDTO, ClientDTO>(urlMethod, requestType, requestData);
        }

        /// <summary>Gets the list of all the uploaded documents for all users.</summary>
        /// <param name="pagination">Pagination.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of all users' uploaded documents.</returns>
        public ListPaginated<KycDocumentDTO> GetKycDocuments(Pagination pagination, FilterKycDocuments filter, Sort sort = null)
        {
            if (filter == null) filter = new FilterKycDocuments();

            return this.GetList<KycDocumentDTO>(MethodKey.ClientGetKycDocuments, pagination, null, sort, filter.GetValues());
        }

		public ListPaginated<WalletDTO> GetWallets(FundsType fundsType, Pagination pagination, CurrencyIso currency = CurrencyIso.NotSpecified)
		{
			string currencyParam = currency == CurrencyIso.NotSpecified ? "" : currency.ToString();

			MethodKey? methodKey = null;

			if (fundsType == FundsType.FEES)
			{
				if (currencyParam != "") methodKey = MethodKey.ClientGetWalletsFeesWithCurrency;
				else methodKey = MethodKey.ClientGetWalletsFees;
			}
			else if (fundsType == FundsType.CREDIT)
			{
				if (currencyParam != "") methodKey = MethodKey.ClientGetWalletsCreditWithCurrency;
				else methodKey = MethodKey.ClientGetWalletsCredit;
			}
			else if (fundsType == FundsType.DEFAULT)
			{
				if (currencyParam != "") methodKey = MethodKey.ClientGetWalletsDefaultWithCurrency;
				else methodKey = MethodKey.ClientGetWalletsDefault;
			}

			if (methodKey.HasValue) return this.GetList<WalletDTO>(methodKey.Value, pagination, currencyParam);
			else return null;
		}
    }
}
