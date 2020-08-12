using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiKycTest : BaseTest
    {
        [Test]
        public async Task Test_GetKycDocument()
        {
            try
            {
				KycDocumentDTO kycDocument = await this.GetJohnsKycDocument();
				KycDocumentDTO result = await this.Api.Kyc.Get(kycDocument.Id);

				Assert.IsNotNull(result);
				Assert.IsTrue(result.Id.Equals(kycDocument.Id));
				Assert.IsTrue(result.Status == kycDocument.Status);
				Assert.IsTrue(result.Type == kycDocument.Type);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_Users_CreateKycPageFromBytes()
		{
			try
			{
				UserNaturalDTO john = await this.GetJohn();
				KycDocumentDTO kycDocument = await this.GetNewKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);
                byte[] bytes = File.ReadAllBytes(fi.FullName);
				await Api.Users.CreateKycPage(john.Id, kycDocument.Id, bytes);
				await Api.Users.CreateKycPage(john.Id, kycDocument.Id, bytes);

				var result = await Api.Kyc.GetDocumentConsultations(kycDocument.Id);

				Assert.AreEqual(2, result.Count);
				Assert.IsInstanceOf<DateTime>(result.First().ExpirationDate);
				Assert.IsInstanceOf<String>(result.First().Url);
				Assert.IsNotEmpty(result.First().Url);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
