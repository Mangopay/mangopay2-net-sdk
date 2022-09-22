using System;
using System.Linq;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiRegulatoryTest : BaseTest
    {
        [Test]
        public async Task Test_Get_Country_Authorizations()
        {
	        var countryAuthorizations = await this.Api.Regulatory.GetCountryAuthorizations(CountryIso.FR);
	        
	        Assert.IsNotNull(countryAuthorizations);
	        Assert.IsNotNull(countryAuthorizations.CountryCode);
	        Assert.IsNotNull(countryAuthorizations.CountryName);
	        Assert.IsNotNull(countryAuthorizations.Authorization);
	        Assert.IsNotNull(countryAuthorizations.LastUpdate);
	        
	        Assert.IsNotNull(countryAuthorizations.Authorization.BlockPayout);
	        Assert.IsNotNull(countryAuthorizations.Authorization.BlockUserCreation);
	        Assert.IsNotNull(countryAuthorizations.Authorization.BlockBankAccountCreation);
        }

        [Test]
        public async Task Test_Get_All_Countries_Authorizations()
        {
	        var countryAuthorizations = await this.Api.Regulatory.GetAllCountriesAuthorizations();
	        
	        Assert.IsNotNull(countryAuthorizations);
	        Assert.IsTrue(countryAuthorizations.Count > 0);
	        Assert.IsNotNull(countryAuthorizations[0].CountryCode);
	        Assert.IsNotNull(countryAuthorizations[0].CountryName);
	        Assert.IsNotNull(countryAuthorizations[0].Authorization);
	        Assert.IsNotNull(countryAuthorizations[0].LastUpdate);
	        
	        Assert.IsNotNull(countryAuthorizations[0].Authorization.BlockPayout);
	        Assert.IsNotNull(countryAuthorizations[0].Authorization.BlockUserCreation);
	        Assert.IsNotNull(countryAuthorizations[0].Authorization.BlockBankAccountCreation);
        }
    }
}
