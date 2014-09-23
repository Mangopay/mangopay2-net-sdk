using MangoPay.SDK.Core.Interfaces;
using MangoPay.SDK.Entities;
using System;
using System.IO;

namespace MangoPay.SDK.Core
{
    /// <summary>File token storage strategy implementation.</summary>
    public class FileStorageStrategy : IStorageStrategy
    {
        private String _tempDir = null;

        /// <summary>Instantiates FileStorageStrategy object.</summary>
        /// <param name="tempDir">Temporary directory path.</param>
        public FileStorageStrategy(String tempDir)
        {
            _tempDir = tempDir;
        }

        /// <summary>Gets the currently stored token.</summary>
        /// <returns>Currently stored token instance or null.</returns>
        public OAuthTokenDTO Get()
        {
            try
            {
                OAuthTokenDTO token = OAuthTokenDTO.Deserialize(File.ReadAllText(GetFilePath()));
                return token;
            }
            catch
            {
                return null; // it's not an error: e.g. file not found because not stored yet
            }
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
        /// <param name="token">Token instance to be stored.</param>
        public void Store(OAuthTokenDTO token)
        {
            string serializedToken = token.Serialize();

            File.WriteAllText(GetFilePath(), serializedToken);
        }

        private String GetFilePath() { return _tempDir + GetType().Name + Constants.TMP_FILE_EXTENSION; }
    }
}
