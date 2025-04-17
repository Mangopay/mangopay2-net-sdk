using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class RecipientSchemaDTO : EntityBase
    {
        public RecipientPropertySchema DisplayName { get; set; }

        public RecipientPropertySchema Currency { get; set; }

        public RecipientPropertySchema RecipientType { get; set; }

        public RecipientPropertySchema PayoutMethodType { get; set; }

        public RecipientPropertySchema RecipientScope { get; set; }

        public Dictionary<string, Dictionary<string, RecipientPropertySchema>> LocalBankTransfer { get; set; }

        public Dictionary<string, RecipientPropertySchema> InternationalBankTransfer { get; set; }

        public IndividualRecipientPropertySchema IndividualRecipient { get; set; }

        public BusinessRecipientPropertySchema BusinessRecipient { get; set; }

        public new RecipientPropertySchema Tag { get; set; }
    }
}