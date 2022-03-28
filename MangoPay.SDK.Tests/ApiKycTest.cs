using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;

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
				KycDocumentDTO result = await this.Api.Kyc.GetAsync(kycDocument.Id);

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
        public async Task Test_Client_GetKycDocuments()
        {
            ListPaginated<KycDocumentDTO> result = null;
            ListPaginated<KycDocumentDTO> result2 = null;

            try
            {
                result = await this.Api.Kyc.GetKycDocumentsAsync(null, null);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                var pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Kyc.GetKycDocumentsAsync(pagination, null, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Kyc.GetKycDocumentsAsync(pagination, null, sort);
                Assert.IsNotNull(result2);
                Assert.IsTrue(result2.Count > 0);

                Assert.IsTrue(result[0].Id != result2[0].Id);
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
				await Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, bytes);
				await Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, bytes);

				var result = await Api.Kyc.GetDocumentConsultationsAsync(kycDocument.Id);

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
