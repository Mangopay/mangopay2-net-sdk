using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
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
        public OAuthToken Get()
        {
            try
            {
                OAuthToken token = OAuthToken.Deserialize(File.ReadAllText(GetFilePath()));
                return token;
            }
            catch
            {
                return null; // it's not an error: e.g. file not found because not stored yet
            }
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
        /// <param name="token">Token instance to be stored.</param>
        public void Store(OAuthToken token)
        {
            string serializedToken = token.Serialize();

            File.WriteAllText(GetFilePath(), serializedToken);
        }

        private String GetFilePath() { return _tempDir + GetType().Name + ".tmp"; }
    }
}
