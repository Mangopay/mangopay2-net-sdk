using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Base abstract class for entities.</summary>
    public abstract class Dto
    {
        /// <summary>Gets map which property is an object and what type of object. To be overridden in child class if has any sub objects.</summary>
        /// <returns>Collection of field name-field type pairs.</returns>
        public virtual Dictionary<string, Type> GetSubObjects() { return new Dictionary<string, Type>(); }

        /// <summary>Gets the structure that maps which property depends on other property. To be overridden in child class if has any dependent objects.</summary>
        /// <returns></returns>
        public virtual Dictionary<string, Dictionary<string, Dictionary<string, Type>>> GetDependentObjects() { return new Dictionary<string, Dictionary<string, Dictionary<string, Type>>>(); }

        /// <summary>Gets the collection of read-only fields names. To be overridden in child class.</summary>
        /// <returns>List of field names.</returns>
        public virtual List<string> GetReadOnlyProperties() { return new List<string>(); }
    }
}
