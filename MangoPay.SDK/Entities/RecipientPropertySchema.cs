using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class RecipientPropertySchema
    {
        public bool Required { get; set; }

        public int MaxLength { get; set; }

        public int MinLength { get; set; }

        public string Pattern { get; set; }

        public List<string> AllowedValues { get; set; }
    }
}