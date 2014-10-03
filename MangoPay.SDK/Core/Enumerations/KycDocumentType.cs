
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>KYC document type enumeration.</summary>
    public enum KycDocumentType
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>Only for natural users. ID of the individual duly empowered to act on behalf of the legal entity.</summary>
        IDENTITY_PROOF,

        /// <summary>Only for legal users. Extract from the relevant register of commerce issued within the last three months.</summary>
        REGISTRATION_PROOF,

        /// <summary>Only for legal users. It’s the Statute. Formal memorandum stated by the entrepreuneurs, in which the following information is mentioned:business name, activity, registered address, shareholding.</summary>
        ARTICLES_OF_ASSOCIATION,

        /// <summary>Only for legal users (business company).</summary>
        SHAREHOLDER_DECLARATION,

        /// <summary>Only for natural users.</summary>
        ADDRESS_PROOF
    }
}
