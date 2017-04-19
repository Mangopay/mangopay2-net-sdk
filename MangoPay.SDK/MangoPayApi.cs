using MangoPay.SDK.Core;
using MangoPay.SDK.Core.APIs;
using System;

namespace MangoPay.SDK
{
    /// <summary>
    /// MangoPay API main entry point. 
    /// Provides managers to connect, send and read data from MangoPay API as well as it holds configuration/authorization data.
    /// </summary>
    public class MangoPayApi
    {
        /// <summary>Instantiates new MangoPayApi object.</summary>
        public MangoPayApi()
        {
            // default config setup
            Config = new Configuration();
            OAuthTokenManager = new AuthorizationTokenManager(this);

            // API managers initialization
            AuthenticationManager = new ApiOAuth(this);
            Clients = new ApiClients(this);
            Users = new ApiUsers(this);
            Wallets = new ApiWallets(this);
            PayIns = new ApiPayIns(this);
            PayOuts = new ApiPayOuts(this);
            Refunds = new ApiRefunds(this);
            Transfers = new ApiTransfers(this);
            CardRegistrations = new ApiCardRegistrations(this);
            Cards = new ApiCards(this);
            Events = new ApiEvents(this);
            CardPreAuthorizations = new ApiCardPreAuthorizations(this);
            Hooks = new ApiHooks(this);
            Kyc = new ApiKyc(this);
			Disputes = new ApiDisputes(this);
			Idempotency = new ApiIdempotency(this);
			Mandates = new ApiMandates(this);
			Reports = new ApiReports(this);
			SingleSignOns = new ApiSingleSignOns(this);
			PermissionGroups = new ApiPermissionGroups(this);
			BankingAlias = new ApiBankingAliases(this);
		}

        /// <summary>Provides authorization token methods.</summary>
        public AuthorizationTokenManager OAuthTokenManager;

        /// <summary>Configuration instance with default settings (to be reset if required).</summary>
        public Configuration Config;

        /// <summary>Stores the raw request and response of the last call from this Api instance, including information about rate-limiting.</summary>
        public LastRequestInfo LastRequestInfo;

        #region API managers

        /// <summary>Provides OAuth methods.</summary>
        public ApiOAuth AuthenticationManager;

        /// <summary>Provides Clients methods.</summary>
        public ApiClients Clients;

        /// <summary>Provides Users methods.</summary>
        public ApiUsers Users;

        /// <summary>Provides Wallets methods.</summary>
        public ApiWallets Wallets;

        /// <summary>Provides PayIns methods.</summary>
        public ApiPayIns PayIns;

        /// <summary>Provides PayOuts methods.</summary>
        public ApiPayOuts PayOuts;

        /// <summary>Provides Transfer methods.</summary>
        public ApiTransfers Transfers;

        /// <summary>Provides CardRegistrations methods.</summary>
        public ApiCardRegistrations CardRegistrations;

        /// <summary>Provides CardPreAuthorizations methods.</summary>
        public ApiCardPreAuthorizations CardPreAuthorizations;

        /// <summary>Provides Cards methods.</summary>
        public ApiCards Cards;

        /// <summary>Provides Refunds methods.</summary>
        public ApiRefunds Refunds;

        /// <summary>Provides Events methods.</summary>
        public ApiEvents Events;

        /// <summary>Provides Hooks methods.</summary>
        public ApiHooks Hooks;

		/// <summary>Provides KYC methods.</summary>
		public ApiKyc Kyc;

		/// <summary>Provides Disputes methods.</summary>
		public ApiDisputes Disputes;

		/// <summary>Provides Idempotency methods.</summary>
		public ApiIdempotency Idempotency;

		/// <summary>Provides Mandates methods.</summary>
		public ApiMandates Mandates;

		/// <summary>Provides Reports methods.</summary>
		public ApiReports Reports;

		/// <summary>Provides Users methods.</summary>
		public ApiBankingAliases BankingAlias;

		/// <summary>Provides SingleSignOns methods.</summary>
		public ApiSingleSignOns SingleSignOns;

		/// <summary>Provides ApiPermissionGroups methods.</summary>
		public ApiPermissionGroups PermissionGroups;

		#endregion

		#region Internal and private

		private Version _version { get; set; }

		/// <summary>
		/// Gets the current SDK <see cref="Version"/>
		/// </summary>
		/// <returns>The current SDK <see cref="Version"/></returns>
		internal Version GetVersion()
		{
			// Get the cached version to avoid using reflection
			if (_version != null)
			{
				return _version;
			}

			_version = typeof(MangoPayApi).Assembly?.GetName()?.Version ?? new Version(0, 0, 0);

			return _version;
		}
		
		#endregion
	}
}
