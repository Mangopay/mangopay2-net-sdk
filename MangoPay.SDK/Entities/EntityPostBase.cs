using System;

namespace MangoPay.SDK.Entities
{
    /// <summary>Base abstract class for POST entities. Provides common properties.</summary>
    public abstract class EntityPostBase
    {
        /// <summary>Custom data.</summary>
        public string Tag { get; set; }
    }
}
