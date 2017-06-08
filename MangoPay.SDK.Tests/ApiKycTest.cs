using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiKycTest : BaseTest
    {
        [Test]
        public void Test_GetKycDocument()
        {
            try
            {
				KycDocumentDTO kycDocument = this.GetJohnsKycDocument();
				KycDocumentDTO result = this.Api.Kyc.Get(kycDocument.Id);

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
		public void Test_Users_CreateKycPageFromBytes()
		{
			try
			{
				UserNaturalDTO john = this.GetJohn();
				KycDocumentDTO kycDocument = this.GetNewKycDocument();

				Assembly assembly = Assembly.GetExecutingAssembly();
				FileInfo assemblyFileInfo = new FileInfo(assembly.Location);
				FileInfo fi = assemblyFileInfo.Directory.GetFiles("TestKycPageFile.png").Single();
				byte[] bytes = File.ReadAllBytes(fi.FullName);
				Api.Users.CreateKycPage(john.Id, kycDocument.Id, bytes);
				Api.Users.CreateKycPage(john.Id, kycDocument.Id, bytes);

				var result = Api.Kyc.GetDocumentConsultations(kycDocument.Id);

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
