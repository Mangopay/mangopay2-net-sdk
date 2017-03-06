namespace MangoPay.SDK.Entities.PUT
{
	/// <summary>Banking alias PUT DTO class for disactivating banking alias.</summary>
	public class BankingAliasPutDTO : EntityPutBase
	{
		/// <summary>Whether the banking alias is active or not.</summary>
		public bool Active { get; set; }
	}
}
