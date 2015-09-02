using MangoPay.SDK.Entities.GET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiKycTest : BaseTest
    {
        [TestMethod]
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
    }
}
