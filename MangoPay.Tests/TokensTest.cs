using MangoPay.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    [TestClass]
    public class TokensTest : BaseTest
    {
        [TestMethod]
        public void Test_ForceToken()
        {
            OAuthToken oldToken = this.Api.OAuthTokenManager.GetToken();
            OAuthToken newToken = this.Api.AuthenticationManager.CreateToken();

            Assert.IsFalse(oldToken.access_token == newToken.access_token);

            this.Api.OAuthTokenManager.StoreToken(newToken);
            OAuthToken storedToken = this.Api.OAuthTokenManager.GetToken();

            Assert.AreEqual(newToken.access_token, storedToken.access_token);
        }

        [TestMethod]
        public void Test_StandardUseToken()
        {
            this.Api.Users.GetAll();
            OAuthToken token = this.Api.OAuthTokenManager.GetToken();
            this.Api.Users.GetAll();

            Assert.AreEqual(token.access_token, this.Api.OAuthTokenManager.GetToken().access_token);
        }

        [TestMethod]
        public void Test_ShareTokenBetweenInstances()
        {
            MangoPayApi api = this.BuildNewMangoPayApi();

            OAuthToken token1 = this.Api.OAuthTokenManager.GetToken();
            OAuthToken token2 = api.OAuthTokenManager.GetToken();

            Assert.AreEqual(token1.access_token, token2.access_token);
        }
    }
}
