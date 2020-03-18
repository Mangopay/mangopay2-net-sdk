using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>Base class for all Api classes.</summary>
    public abstract class ApiBase
    {
        /// <summary>Root/parent instance that holds the OAuthToken and Configuration instance.</summary>
        protected MangoPayApi _root;

        /// <summary>Array with REST URL and request type.</summary>
        private Dictionary<MethodKey, ApiEndPoint> _methods = new Dictionary<MethodKey, ApiEndPoint>
        {
            { MethodKey.AuthenticationBase, new ApiEndPoint("/clients/", RequestType.POST)},
            { MethodKey.AuthenticationOAuth, new ApiEndPoint("/oauth/token", RequestType.POST)},

            { MethodKey.EventsAll, new ApiEndPoint("/events", RequestType.GET)},

            { MethodKey.HooksCreate, new ApiEndPoint("/hooks", RequestType.POST)},
            { MethodKey.HooksAll, new ApiEndPoint("/hooks", RequestType.GET)},
            { MethodKey.HooksGet, new ApiEndPoint("/hooks/{0}", RequestType.GET)},
            { MethodKey.HooksSave, new ApiEndPoint("/hooks/{0}", RequestType.PUT)},

            { MethodKey.CardRegistrationCreate, new ApiEndPoint("/cardregistrations", RequestType.POST)},
            { MethodKey.CardRegistrationGet, new ApiEndPoint("/cardregistrations/{0}", RequestType.GET)},
            { MethodKey.CardRegistrationSave, new ApiEndPoint("/cardregistrations/{0}", RequestType.PUT)},
            { MethodKey.CardByFingerprintGet, new ApiEndPoint("/cards/fingerprints/{0}", RequestType.GET)},

            { MethodKey.PreauthorizationCreate, new ApiEndPoint("/preauthorizations/card/direct", RequestType.POST)},
            { MethodKey.PreauthorizationGet, new ApiEndPoint("/preauthorizations/{0}", RequestType.GET)},
            { MethodKey.PreauthorizationSave, new ApiEndPoint("/preauthorizations/{0}", RequestType.PUT)},

            { MethodKey.CardGet, new ApiEndPoint("/cards/{0}", RequestType.GET)},
            { MethodKey.CardSave, new ApiEndPoint("/cards/{0}", RequestType.PUT)},
            { MethodKey.CardPreauthorizations, new ApiEndPoint("/cards/{0}/preauthorizations", RequestType.GET)},
            { MethodKey.CardTransactions, new ApiEndPoint("/cards/{0}/transactions", RequestType.GET)},

            { MethodKey.PayinsCardWebCreate, new ApiEndPoint("/payins/card/web", RequestType.POST)},
            { MethodKey.PayinsCardWebGetCardData, new ApiEndPoint("/payins/card/web/{0}/extended/", RequestType.GET)},
            { MethodKey.PayinsCardDirectCreate, new ApiEndPoint("/payins/card/direct", RequestType.POST)},
            { MethodKey.PayinsGet, new ApiEndPoint("/payins/{0}", RequestType.GET)},
            { MethodKey.PayinsCreateRefunds, new ApiEndPoint("/payins/{0}/refunds", RequestType.POST)},
            { MethodKey.PayinsGetRefunds, new ApiEndPoint("/payins/{0}/refunds", RequestType.GET)},

            { MethodKey.PayinsPayPalCreate, new ApiEndPoint("/payins/paypal/web", RequestType.POST)},

            { MethodKey.PayinsPreauthorizedDirectCreate, new ApiEndPoint("/payins/preauthorized/direct", RequestType.POST)},

            { MethodKey.PayinsBankwireDirectCreate, new ApiEndPoint("/payins/bankwire/direct", RequestType.POST)},

            { MethodKey.PayinsDirectDebitCreate, new ApiEndPoint("/payins/directdebit/web", RequestType.POST)},
            { MethodKey.PayinsMandateDirectDebitCreate, new ApiEndPoint("/payins/directdebit/direct", RequestType.POST)},
            
            { MethodKey.ApplePayinsDirectCreate, new ApiEndPoint("/payins/applepay/direct", RequestType.POST)},
            { MethodKey.GooglePayinsDirectCreate, new ApiEndPoint("/payins/googlepay/direct", RequestType.POST)},

            { MethodKey.PayoutsBankwireCreate, new ApiEndPoint("/payouts/bankwire", RequestType.POST)},
            { MethodKey.PayoutsGet, new ApiEndPoint("/payouts/{0}", RequestType.GET)},
            { MethodKey.PayoutsGetRefunds, new ApiEndPoint("/payouts/{0}/refunds", RequestType.GET)},

            { MethodKey.RefundsGet, new ApiEndPoint("/refunds/{0}", RequestType.GET)},

            { MethodKey.TransfersCreate, new ApiEndPoint("/transfers", RequestType.POST)},
            { MethodKey.TransfersGet, new ApiEndPoint("/transfers/{0}", RequestType.GET)},
            { MethodKey.TransfersGetRefunds, new ApiEndPoint("/transfers/{0}/refunds", RequestType.GET)},
            { MethodKey.TransfersCreateRefunds, new ApiEndPoint("/transfers/{0}/refunds", RequestType.POST)},

            { MethodKey.UsersAll, new ApiEndPoint("/users", RequestType.GET)},
            { MethodKey.UsersAllWallets, new ApiEndPoint("/users/{0}/wallets", RequestType.GET)},
            { MethodKey.UsersAllBankAccount, new ApiEndPoint("/users/{0}/bankaccounts", RequestType.GET)},
            { MethodKey.UsersAllCards, new ApiEndPoint("/users/{0}/cards", RequestType.GET)},
            { MethodKey.UsersAllTransactions, new ApiEndPoint("/users/{0}/transactions", RequestType.GET)},
            { MethodKey.UsersCreateNaturals, new ApiEndPoint("/users/natural", RequestType.POST)},
            { MethodKey.UsersCreateLegals, new ApiEndPoint("/users/legal", RequestType.POST)},
            { MethodKey.UsersCreateKycDocument, new ApiEndPoint("/users/{0}/KYC/documents", RequestType.POST)},
            { MethodKey.UsersCreateKycPage, new ApiEndPoint("/users/{0}/KYC/documents/{1}/pages", RequestType.POST)},
            { MethodKey.UsersCreateBankAccountsIban, new ApiEndPoint("/users/{0}/bankaccounts/iban", RequestType.POST)},
            { MethodKey.UsersCreateBankAccountsGb, new ApiEndPoint("/users/{0}/bankaccounts/gb", RequestType.POST)},
            { MethodKey.UsersCreateBankAccountsUs, new ApiEndPoint("/users/{0}/bankaccounts/us", RequestType.POST)},
            { MethodKey.UsersCreateBankAccountsCa, new ApiEndPoint("/users/{0}/bankaccounts/ca", RequestType.POST)},
            { MethodKey.UsersCreateBankAccountsOther, new ApiEndPoint("/users/{0}/bankaccounts/other", RequestType.POST)},
            { MethodKey.UsersGet, new ApiEndPoint("/users/{0}", RequestType.GET)},
            { MethodKey.UsersGetNaturals, new ApiEndPoint("/users/natural/{0}", RequestType.GET)},
            { MethodKey.UsersGetLegals, new ApiEndPoint("/users/legal/{0}", RequestType.GET)},
            { MethodKey.UsersPreauthorizations, new ApiEndPoint("/users/{0}/preauthorizations", RequestType.GET)},

            { MethodKey.UsersGetKycDocument, new ApiEndPoint("/users/{0}/KYC/documents/{1}", RequestType.GET)},
            { MethodKey.UsersGetKycDocuments, new ApiEndPoint("/users/{0}/KYC/documents", RequestType.GET)},
            { MethodKey.UsersGetBankAccount, new ApiEndPoint("/users/{0}/bankaccounts/{1}", RequestType.GET)},
            { MethodKey.UsersSaveBankAccount, new ApiEndPoint("/users/{0}/bankaccounts/{1}", RequestType.PUT)},
            { MethodKey.UsersSaveNaturals, new ApiEndPoint("/users/natural/{0}", RequestType.PUT)},
            { MethodKey.UsersSaveLegals, new ApiEndPoint("/users/legal/{0}", RequestType.PUT)},
            { MethodKey.UsersSaveKycDocument, new ApiEndPoint("/users/{0}/KYC/documents/{1}", RequestType.PUT)},
            { MethodKey.UsersEmoneyGet, new ApiEndPoint("/users/{0}/emoney", RequestType.GET)},
            { MethodKey.UsersEmoneyYearGet, new ApiEndPoint("/users/{0}/emoney/{1}", RequestType.GET)},
            { MethodKey.UsersEmoneyMonthGet, new ApiEndPoint("/users/{0}/emoney/{1}/{2}", RequestType.GET)},

            { MethodKey.WalletsCreate, new ApiEndPoint("/wallets", RequestType.POST)},
            { MethodKey.WalletsAllTransactions, new ApiEndPoint("/wallets/{0}/transactions", RequestType.GET)},
            { MethodKey.WalletsGet, new ApiEndPoint("/wallets/{0}", RequestType.GET)},
            { MethodKey.WalletsSave, new ApiEndPoint("/wallets/{0}", RequestType.PUT)},
            { MethodKey.BankingAliasCreateIban, new ApiEndPoint("/wallets/{0}/bankingaliases/iban", RequestType.POST)},
            { MethodKey.BankingAliasAll, new ApiEndPoint("/wallets/{0}/bankingaliases", RequestType.GET)},
            { MethodKey.BankingAliasGet, new ApiEndPoint("/bankingaliases/{0}", RequestType.GET)},
            { MethodKey.BankingAliasSave, new ApiEndPoint("/bankingaliases/{0}", RequestType.PUT)},

            { MethodKey.ClientGetKycDocuments, new ApiEndPoint("/KYC/documents", RequestType.GET)},
            { MethodKey.GetKycDocument, new ApiEndPoint("/KYC/documents/{0}", RequestType.GET)},
            { MethodKey.KycDocumentConsult, new ApiEndPoint("/KYC/documents/{0}/consult", RequestType.POST)},

            { MethodKey.ClientGetWalletsDefault, new ApiEndPoint("/clients/wallets", RequestType.GET)},
            { MethodKey.ClientGetWalletsFees, new ApiEndPoint("/clients/wallets/fees", RequestType.GET)},
            { MethodKey.ClientGetWalletsCredit, new ApiEndPoint("/clients/wallets/credit", RequestType.GET)},
            { MethodKey.ClientGetWalletsDefaultWithCurrency, new ApiEndPoint("/clients/wallets/{0}", RequestType.GET)},
            { MethodKey.ClientGetWalletsFeesWithCurrency, new ApiEndPoint("/clients/wallets/fees/{0}", RequestType.GET)},
            { MethodKey.ClientGetWalletsCreditWithCurrency, new ApiEndPoint("/clients/wallets/credit/{0}", RequestType.GET)},

            { MethodKey.ClientGetTransactions, new ApiEndPoint("/clients/transactions", RequestType.GET)},
            { MethodKey.ClientGetWalletTransactions, new ApiEndPoint("/clients/wallets/{0}/{1}/transactions", RequestType.GET)},
            { MethodKey.ClientCreateBankwireDirect, new ApiEndPoint("/clients/payins/bankwire/direct", RequestType.POST)},
            { MethodKey.ClientGet, new ApiEndPoint("/clients", RequestType.GET)},
            { MethodKey.ClientSave, new ApiEndPoint("/clients", RequestType.PUT)},
            { MethodKey.ClientUploadLogo, new ApiEndPoint("/clients/logo", RequestType.PUT)},

            { MethodKey.DisputesGet, new ApiEndPoint("/disputes/{0}", RequestType.GET)},
            { MethodKey.DisputesSaveTag, new ApiEndPoint("/disputes/{0}", RequestType.PUT)},
            { MethodKey.DisputesSaveContestFunds, new ApiEndPoint("/disputes/{0}/submit", RequestType.PUT)},
            { MethodKey.DisputeSaveClose, new ApiEndPoint("/disputes/{0}/close", RequestType.PUT)},
            { MethodKey.DisputesGetPendingSettlement, new ApiEndPoint("/disputes/pendingsettlement", RequestType.GET)},

            { MethodKey.DisputesGetTransactions, new ApiEndPoint("/disputes/{0}/transactions", RequestType.GET)},

            { MethodKey.DisputesGetAll, new ApiEndPoint("/disputes", RequestType.GET)},
            { MethodKey.DisputesGetForWallet, new ApiEndPoint("/wallets/{0}/disputes", RequestType.GET)},
            { MethodKey.DisputesGetForUser, new ApiEndPoint("/users/{0}/disputes", RequestType.GET)},

            { MethodKey.DisputesDocumentCreate, new ApiEndPoint("/disputes/{0}/documents", RequestType.POST)},
            { MethodKey.DisputesDocumentPageCreate, new ApiEndPoint("/disputes/{0}/documents/{1}/pages", RequestType.POST)},
            { MethodKey.DisputesDocumentSubmit, new ApiEndPoint("/disputes/{0}/documents/{1}", RequestType.PUT)},
            { MethodKey.DisputesDocumentGet, new ApiEndPoint("/dispute-documents/{0}", RequestType.GET)},
            { MethodKey.DisputesDocumentGetForDispute, new ApiEndPoint("/disputes/{0}/documents", RequestType.GET)},
            { MethodKey.DisputesDocumentGetForClient, new ApiEndPoint("/dispute-documents", RequestType.GET)},
            { MethodKey.DisputesDocumentConsult, new ApiEndPoint("/dispute-documents/{0}/consult", RequestType.POST)},

            { MethodKey.DisputesRepudiationGet, new ApiEndPoint("/repudiations/{0}", RequestType.GET)},
            { MethodKey.DisputesRepudiationGetRefunds, new ApiEndPoint("/repudiations/{0}/refunds", RequestType.GET)},

            { MethodKey.DisputesRepudiationCreateSettlement, new ApiEndPoint("/repudiations/{0}/settlementtransfer", RequestType.POST)},
            { MethodKey.SettlementsGet, new ApiEndPoint("/settlements/{0}/", RequestType.GET)},

            { MethodKey.IdempotencyResponseGet, new ApiEndPoint("/responses/{0}/", RequestType.GET)},

            { MethodKey.MandateCreate, new ApiEndPoint("/mandates/directdebit/web", RequestType.POST)},
            { MethodKey.MandateCancel, new ApiEndPoint("/mandates/{0}/cancel/", RequestType.PUT)},
            { MethodKey.MandateGet, new ApiEndPoint("/mandates/{0}/", RequestType.GET)},
            { MethodKey.MandatesGetAll, new ApiEndPoint("/mandates/", RequestType.GET)},
            { MethodKey.MandatesGetTransactions, new ApiEndPoint("/mandates/{0}/transactions", RequestType.GET)},
            { MethodKey.MandatesGetForUser, new ApiEndPoint("/users/{0}/mandates/", RequestType.GET)},
            { MethodKey.MandatesGetForBankAccount, new ApiEndPoint("/users/{0}/bankaccounts/{1}/mandates/", RequestType.GET)},

            { MethodKey.ReportRequest, new ApiEndPoint("/reports/{0}", RequestType.POST)},
            { MethodKey.ReportGetAll, new ApiEndPoint("/reports", RequestType.GET)},
            { MethodKey.ReportGet, new ApiEndPoint("/reports/{0}", RequestType.GET)},

            { MethodKey.SingleSignOnAll, new ApiEndPoint("/clients/ssos", RequestType.GET)},
            { MethodKey.SingleSignOnCreate, new ApiEndPoint("/clients/ssos", RequestType.POST)},
            { MethodKey.SingleSignOnGet, new ApiEndPoint("/clients/ssos/{0}", RequestType.GET)},
            { MethodKey.SingleSignOnSave, new ApiEndPoint("/clients/ssos/{0}", RequestType.PUT)},
            { MethodKey.SingleSignOnExtendInvitation, new ApiEndPoint("/clients/ssos/{0}/extendinvitation", RequestType.PUT)},

            { MethodKey.PermissionGroupAll, new ApiEndPoint("/clients/permissiongroups", RequestType.GET)},
            { MethodKey.PermissionGroupAllSsos, new ApiEndPoint("/clients/permissiongroups/{0}/SSOs", RequestType.GET)},
            { MethodKey.PermissionGroupCreate, new ApiEndPoint("/clients/permissiongroups", RequestType.POST)},
            { MethodKey.PermissionGroupGet, new ApiEndPoint("/clients/permissiongroups/{0}", RequestType.GET)},
            { MethodKey.PermissionGroupSave, new ApiEndPoint("/clients/permissiongroups/{0}", RequestType.PUT)},

            { MethodKey.SingleSignOnsMe, new ApiEndPoint("/ssos/me", RequestType.GET, false)},
            { MethodKey.SingleSignOnsMePermissionGroup , new ApiEndPoint("/ssos/me/permissiongroup", RequestType.GET, false)},
            
            { MethodKey.UboDeclarationCreate, new ApiEndPoint("/users/{0}/kyc/ubodeclarations", RequestType.POST)},
            { MethodKey.UboDeclarationUpdate, new ApiEndPoint("/users/{0}/kyc/ubodeclarations/{1}", RequestType.PUT)},
            { MethodKey.UboDeclarationsGet, new ApiEndPoint("/users/{0}/kyc/ubodeclarations",RequestType.GET)},
            { MethodKey.UboDeclarationGet, new ApiEndPoint("/users/{0}/kyc/ubodeclarations/{1}",RequestType.GET)},
            { MethodKey.UboGet,new ApiEndPoint("/users/{0}/kyc/ubodeclarations/{1}/ubos/{2}",RequestType.GET)},
            { MethodKey.UboCreate,new ApiEndPoint("/users/{0}/kyc/ubodeclarations/{1}/ubos",RequestType.POST)},
            { MethodKey.UboUpdate,new ApiEndPoint("/users/{0}/kyc/ubodeclarations/{1}/ubos/{2}",RequestType.PUT) },
            
            { MethodKey.BankAccountsGetTransactions, new ApiEndPoint("/bankaccounts/{0}/transactions", RequestType.GET)},
        };

        /// <summary>Creates new API instance.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiBase(MangoPayApi root)
        {
            _root = root;
        }

        /// <summary>Gets an instance of <see cref="ApiEndPoint"/> for given method key</summary>
        /// <param name="key">The method key to get the end point details for</param>
        /// <returns></returns>
        protected ApiEndPoint GetApiEndPoint(MethodKey key)
        {
            if (!_methods.ContainsKey(key))
            {
                throw new Exception("Unknown method key: " + key);
            }

            return (ApiEndPoint)_methods[key].Clone();
        }

        /// <summary>Creates the DTO instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">DTO instance that is going to be sent.</param>
        /// <param name="entitiesId">Entity identifier.</param>
        /// <returns>The DTO instance returned from API.</returns>
        protected U CreateObject<U, T>(String idempotencyKey, MethodKey methodKey, T entity, params string[] entitiesId)
            where U : EntityBase, new()
            where T : EntityPostBase
        {
            var endPoint = GetApiEndPoint(methodKey);
            endPoint.SetParameters(entitiesId);

            RestTool restTool = new RestTool(this._root, true);
            U result = restTool.Request<U, T>(idempotencyKey, endPoint, null, null, entity);

            return result;
        }

        /// <summary>Gets the DTO instance from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entitiesId">Entities identifier.</param>
        /// <returns>The DTO instance returned from API.</returns>
        protected T GetObject<T>(MethodKey methodKey, params string[] entitiesId) where T:EntityBase, new()
        {
            var endPoint = GetApiEndPoint(methodKey);
            endPoint.SetParameters(entitiesId);

            RestTool rest = new RestTool(this._root, true);
            T response = rest.Request<T, T>(endPoint);

            return response;
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entitiesId">Entities identifier.</param>
        /// <param name="sort">Sort.</param>
        /// <param name="additionalUrlParams">Collection of key-value pairs of request parameters.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, Sort sort, Dictionary<String, String> additionalUrlParams, params string[] entitiesId)
            where T : EntityBase, new()
        {
            var endPoint = GetApiEndPoint(methodKey);
            endPoint.SetParameters(entitiesId);

            if (pagination == null)
            {
                pagination = new Pagination();
            }

            if (sort != null && sort.IsSet)
            {
                if (additionalUrlParams == null)
                    additionalUrlParams = new Dictionary<string, string>();

                additionalUrlParams.Add(Constants.SORT_URL_PARAMETER_NAME, sort.GetFields());
            }

            RestTool restTool = new RestTool(this._root, true);

            return restTool.RequestList<T>(endPoint, additionalUrlParams, pagination);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="entitiesId">Entities identifier.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination,  Sort sort = null, params string[] entitiesId)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination, sort,null,entitiesId);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination, Sort sort = null)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination,sort, additionalUrlParams:null);
        }

        /// <summary>Gets the collection of Dto instances from API.</summary>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Collection of Dto instances returned from API.</returns>
        protected ListPaginated<T> GetList<T>(MethodKey methodKey, Pagination pagination)
            where T : EntityBase, new()
        {
            return GetList<T>(methodKey, pagination, sort: null, additionalUrlParams:null);
        }

        /// <summary>Saves the Dto instance.</summary>
        /// <typeparam name="U">Return type.</typeparam>
        /// <typeparam name="T">Type on behalf of which the request is being called.</typeparam>
        /// <param name="methodKey">Relevant method key.</param>
        /// <param name="entity">Dto instance that is going to be sent.</param>
        /// <param name="entitiesId">Entities identifier.</param>
        /// <returns>The Dto instance returned from API.</returns>
        protected U UpdateObject<U, T>(MethodKey methodKey, T entity, params string[] entitiesId)
            where U : EntityBase, new()
            where T : EntityPutBase
        {
            var endPoint = GetApiEndPoint(methodKey);
            endPoint.SetParameters(entitiesId);

            RestTool restTool = new RestTool(this._root, true);
            return restTool.Request<U, T>(null, endPoint, null, null, entity);
        }

        protected Type GetObjectForIdempotencyUrl()
        {
            return typeof(UserNaturalDTO);
        }
    }
}
