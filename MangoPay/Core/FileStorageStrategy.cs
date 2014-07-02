using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();

            //try
            //{
            //   FileInputStream fileIn = new FileInputStream(getFilePath());
            //   ObjectInputStream in = new ObjectInputStream(fileIn);
            //   OAuthToken token = (OAuthToken) in.readObject();
            //   in.close();
            //   fileIn.close();
            //   return token;
            //} catch (Exception ex)
            //{
            //    return null; // it's not an error: e.g. file not found cause not stored yet
            //}
        }

        /// <summary>Stores authorization token passed as an argument.</summary>
        /// <param name="token">Token instance to be stored.</param>
        public void Store(OAuthToken token)
        {
            throw new NotImplementedException();

            //FileOutputStream fileOut;
            //try {
            //    fileOut = new FileOutputStream(getFilePath());
            //    ObjectOutputStream out = new ObjectOutputStream(fileOut);
            //    out.writeObject(token);
            //    out.close();
            //    fileOut.close();
            //} catch (Exception ex) {
            //    throw;
            //}
        }

        private String GetFilePath() { return _tempDir + GetType().Name + ".tmp"; }
    }
}
