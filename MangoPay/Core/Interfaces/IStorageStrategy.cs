using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core.Interfaces
{
    /// <summary>Storage strategy interface.</summary>
    public interface IStorageStrategy
    {
        OAuthToken Get();

        void Store(OAuthToken token);
    }
}
