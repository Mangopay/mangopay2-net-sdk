using System;

namespace MangoPay.SDK.Core.Enumerations
{
	public enum UboRefusedReasonType
	{
        MISSING_UBO,
        WRONG_UBO_INFORMATION,
        UBO_IDENTITY_NEEDED,
        SHAREHOLDERS_DECLARATION_NEEDED,
        ORGANIZATION_CHART_NEEDED,
        DOCUMENTS_NEEDED,
        DECLARATION_DO_NOT_MATCH_UBO_INFORMATION,
        SPECIFIC_CASE
    }
}
