using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities.GET
{
    public class CountryAuthorizationDTO : EntityBase
    {
        public CountryIso CountryCode { get; set; }

        public string CountryName { get; set; }

        public CountryAuthorizationDataDTO Authorization { get; set; }

        public long LastUpdate { get; set; }
    }
}