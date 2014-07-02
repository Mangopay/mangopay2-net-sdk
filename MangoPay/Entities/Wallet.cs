using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Wallet entity.</summary>
    public class Wallet : EntityBase
    {
        /// <summary>Collection of owners identifiers.</summary>
        public List<String> Owners;

        /// <summary>Wallet description.</summary>
        public String Description;

        /// <summary>Money in wallet.</summary>
        public Money Balance;

        /// <summary>Currency code in ISO.</summary>
        public String Currency;

        /// <summary>Gets map which property is an object and what type of object.</summary>
        /// <returns>Collection of field name-field type pairs.</returns>
        public override Dictionary<String, Type> GetSubObjects()
        {
            return new Dictionary<String, Type>() 
            {
                { "Balance", typeof(Money) }
            };
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("Balance");

            return result;
        }
    }
}
