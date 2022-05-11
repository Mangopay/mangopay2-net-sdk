using System;

namespace MangoPay.SDK.Entities.PUT
{
	/// <summary>Client logo container.</summary>
	public class ClientLogoPutDTO : EntityPutBase
	{
		public ClientLogoPutDTO(string fileContentBase64)
		{
			File = fileContentBase64;
		}

		public string File { get; set; }
	}
}
