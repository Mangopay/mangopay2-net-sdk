using MangoPay.SDK.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class TokensTest : BaseTest
    {
        [TestMethod]
        public void Test_ForceToken()
        {
            OAuthTokenDTO oldToken = this.Api.OAuthTokenManager.GetToken();
            OAuthTokenDTO newToken = this.Api.AuthenticationManager.CreateToken();

            Assert.IsFalse(oldToken.access_token == newToken.access_token);

            this.Api.OAuthTokenManager.StoreToken(newToken);
            OAuthTokenDTO storedToken = this.Api.OAuthTokenManager.GetToken();

            Assert.AreEqual(newToken.access_token, storedToken.access_token);
        }

        [TestMethod]
        public void Test_StandardUseToken()
        {
            this.Api.Users.GetAll();
            OAuthTokenDTO token = this.Api.OAuthTokenManager.GetToken();
            this.Api.Users.GetAll();

            Assert.AreEqual(token.access_token, this.Api.OAuthTokenManager.GetToken().access_token);
        }

        [TestMethod]
        public void Test_ShareTokenBetweenInstances()
        {
            MangoPayApi api = this.BuildNewMangoPayApi();

            OAuthTokenDTO token1 = this.Api.OAuthTokenManager.GetToken();
            OAuthTokenDTO token2 = api.OAuthTokenManager.GetToken();

            Assert.AreEqual(token1.access_token, token2.access_token);
        }
    }
}
