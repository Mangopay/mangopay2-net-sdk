using MangoPay.SDK.Entities;
using NUnit.Framework;
using System.Threading.Tasks;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class TokensTest : BaseTest
    {
        [Test]
        public async Task Test_ForceToken()
        {
            var oldToken = await this.Api.OAuthTokenManager.GetTokenAsync();
            var newToken = await this.Api.AuthenticationManager.CreateTokenAsync(new CreateOAuthTokenPostDTO());

            Assert.IsFalse(oldToken.access_token == newToken.access_token);

            this.Api.OAuthTokenManager.StoreToken(newToken);
            var storedToken = await this.Api.OAuthTokenManager.GetTokenAsync();

            Assert.AreEqual(newToken.access_token, storedToken.access_token);
        }

        [Test]
        public async Task Test_StandardUseToken()
        {
            await this.Api.Users.GetAllAsync();
            var token = await this.Api.OAuthTokenManager.GetTokenAsync();
            await this.Api.Users.GetAllAsync();

            var tok = await this.Api.OAuthTokenManager.GetTokenAsync();

            Assert.AreEqual(token.access_token, tok.access_token);
        }

        [Test]
        public async Task Test_ShareTokenBetweenInstances()
        {
            var api = this.BuildNewMangoPayApi();

            var token1 = await this.Api.OAuthTokenManager.GetTokenAsync();
            var token2 = await api.OAuthTokenManager.GetTokenAsync();

            Assert.AreEqual(token1.access_token, token2.access_token);
        }

		[Test]
		public async Task Test_IsolateTokensBetweenEnvironments()
		{
            var api = new MangoPayApi
            {
                Config =
                {
                    ClientId = "sdk-unit-tests",
                    ClientPassword = "cqFfFrWfCcb7UadHNxx2C9Lo6Djw8ZduLi7J9USTmu8bhxxpju",
                    BaseUrl = "https://api.sandbox.mangopay.com"
                }
            };

            var token1 = await api.OAuthTokenManager.GetTokenAsync();

			api.Config.ClientId = "sdk_example";
			api.Config.ClientPassword = "Vfp9eMKSzGkxivCwt15wE082pTTKsx90vBenc9hjLsf5K46ciF";
			api.Config.BaseUrl = "https://api.sandbox.mangopay.com";

            var token2 = await api.OAuthTokenManager.GetTokenAsync();

			Assert.AreNotEqual(token1.access_token, token2.access_token);

			api.Config.ClientId = "sdk-unit-tests";
			api.Config.ClientPassword = "cqFfFrWfCcb7UadHNxx2C9Lo6Djw8ZduLi7J9USTmu8bhxxpju";
			api.Config.BaseUrl = "https://api.sandbox.mangopay.com";

            var token3 = await api.OAuthTokenManager.GetTokenAsync();

			Assert.AreEqual(token1.access_token, token3.access_token);
		}
    }
}
