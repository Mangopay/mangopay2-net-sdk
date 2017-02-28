namespace MangoPay.SDK.Entities
{
	public class Scopes
	{
		/// <summary>API endpoints linked to client details.</summary>
		public Permissions ClientDetails { get; set; }

		/// <summary>API endpoints linked to client logo.</summary>
		public Permissions ClientLogo { get; set; }

		/// <summary>API endpoints linked to client wallets.</summary>
		public Permissions ClientWallets { get; set; }

		/// <summary>API endpoints linked to client bank accounts.</summary>
		public Permissions ClientBankAccounts { get; set; }

		/// <summary>API endpoints linked to client payins.</summary>
		public Permissions ClientPayins { get; set; }

		/// <summary>API endpoints linked to client payouts.</summary>
		public Permissions ClientPayouts { get; set; }

		/// <summary>API endpoints linked to client transactions.</summary>
		public Permissions ClientTransactions { get; set; }

		/// <summary>API endpoints linked to singe sing ons.</summary>
		public Permissions SSOs { get; set; }

		/// <summary>API endpoints linked to permission groups.</summary>
		public Permissions PermissionGroups { get; set; }

		/// <summary>API endpoints linked to users.</summary>
		public Permissions Users { get; set; }

		/// <summary>API endpoints linked to wallets.</summary>
		public Permissions Wallets { get; set; }

		/// <summary>API endpoints linked to banking aliases.</summary>
		public Permissions BankingAliases { get; set; }

		/// <summary>API endpoints linked to cards.</summary>
		public Permissions Cards { get; set; }

		/// <summary>API endpoints linked to bank accounts.</summary>
		public Permissions BankAccounts { get; set; }

		/// <summary>API endpoints linked to pre authorizations.</summary>
		public Permissions PreAuthorizations { get; set; }

		/// <summary>API endpoints linked to payins.</summary>
		public Permissions Payins { get; set; }

		/// <summary>API endpoints linked to transfers.</summary>
		public Permissions Transfers { get; set; }

		/// <summary>API endpoints linked to payouts.</summary>
		public Permissions Payouts { get; set; }

		/// <summary>API endpoints linked to refunds.</summary>
		public Permissions Refunds { get; set; }

		/// <summary>API endpoints linked to transactions.</summary>
		public Permissions Transactions { get; set; }

		/// <summary>API endpoints linked to KYC documents.</summary>
		public Permissions KYCDocuments { get; set; }

		/// <summary>API endpoints linked to disputes.</summary>
		public Permissions Disputes { get; set; }

		/// <summary>API endpoints linked to repudiations.</summary>
		public Permissions Repudiations { get; set; }

		/// <summary>API endpoints linked to mandates.</summary>
		public Permissions Mandates { get; set; }

		/// <summary>API endpoints linked to reporting.</summary>
		public Permissions Reporting { get; set; }

		/// <summary>API endpoints linked to responses.</summary>
		public Permissions Responses { get; set; }

		/// <summary>API endpoints linked to events.</summary>
		public Permissions Events { get; set; }

		/// <summary>API endpoints linked to hooks.</summary>
		public Permissions Hooks { get; set; }

	}
}
