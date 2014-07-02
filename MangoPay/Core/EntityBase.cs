using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Base abstract class for entities. Provides common properties.</summary>
    public abstract class EntityBase : Dto
    {
        /// <summary>Unique identifier.</summary>
        public string Id;

        /// <summary>Custom data.</summary>
        public string Tag;

        /// <summary>Date of creation (UNIX timestamp).</summary>
        public long CreationDate;

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<string> GetReadOnlyProperties()
        {
            List<string> result = new List<string>();

            result.Add("Id");
            result.Add("CreationDate");

            return result;
        }
    }
}
