using MangoPay.SDK.Core.Interfaces;
using MangoPay.SDK.Entities;
using System;
using System.IO;

namespace MangoPay.SDK.Core
{
    /// <summary>File token storage strategy implementation.</summary>
    public class FileStorageStrategy : IStorageStrategy
    {
        private readonly string _tempDir = null;

        /// <summary>Instantiates FileStorageStrategy object.</summary>
        /// <param name="tempDir">Temporary directory path.</param>
        public FileStorageStrategy(string tempDir)
        {
            _tempDir = tempDir;
        }

		/// <summary>Gets the currently stored token.</summary>
		/// <param name="envKey">Environment key for token.</param>
        /// <returns>Currently stored token instance or null.</returns>
		public OAuthTokenDTO Get(string envKey)
        {
            try
            {
				var token = OAuthTokenDTO.Deserialize(File.ReadAllText(GetFilePath(envKey)));
                return token;
            }
            catch
            {
                return null; // it's not an error: e.g. file not found because not stored yet
            }
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
		/// <param name="token">Token instance to be stored.</param>
		/// <param name="envKey">Environment key for token.</param>
        public void Store(OAuthTokenDTO token, string envKey)
        {
            var serializedToken = token.Serialize();

			File.WriteAllText(GetFilePath(envKey), serializedToken);
        }

		private string GetFilePath(string envKey) 
		{ 
			return _tempDir + GetType().Name + "." + envKey + Constants.TMP_FILE_EXTENSION; 
		}
    }
}
