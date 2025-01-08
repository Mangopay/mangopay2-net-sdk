namespace MangoPay.SDK.Entities
{
    public class VirtualAccountAddress
    {
        public VirtualAccountAddress(
            string streetName, 
            string postCode, 
            string townName, 
            string countrySubDivision,
            string country)
        {
            StreetName = streetName;
            PostCode = postCode;
            TownName = townName;
            CountrySubDivision = countrySubDivision;
            Country = country;
        }
        
        private string StreetName { get; set; }

        private string PostCode { get; set; }

        private string TownName { get; set; }

        private string CountrySubDivision { get; set; }
        
        private string Country { get; set; }
    }
}