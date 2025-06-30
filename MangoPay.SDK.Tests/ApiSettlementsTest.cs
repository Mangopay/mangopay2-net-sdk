using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiSettlementsTest : BaseTest
    {
        private static IntentSettlementDTO _settlement;
        
        [Test]
        public async Task Test_Upload_Settlement_File()
        {
            var settlement = await CreateNewSettlement();
            Assert.AreEqual("UPLOADED", settlement.Status);
        }
        
        [Test]
        public async Task Test_Get_Settlement()
        {
            var settlement = await CreateNewSettlement();
            // wait for the file to be processed by the API
            Thread.Sleep(10000);
            var fetched = await Api.ApiSettlements.Get(settlement.SettlementId);
            
            Assert.AreEqual("UPLOADED", settlement.Status);
            Assert.AreEqual("PARTIALLY_SETTLED", fetched.Status);
        }
        
        [Test]
        public async Task Test_Update_Settlement()
        {
            var settlement = await CreateNewSettlement();
            var file = GetSettlementFile();
            var updated = await Api.ApiSettlements.Update(settlement.SettlementId, file);
            Assert.AreEqual("UPLOADED", updated.Status);
            Thread.Sleep(10000);
            
            var fetched = await Api.ApiSettlements.Get(settlement.SettlementId);
            Assert.AreEqual("UPLOADED", settlement.Status);
            Assert.AreEqual("PARTIALLY_SETTLED", fetched.Status);
        }

        private async Task<IntentSettlementDTO> CreateNewSettlement()
        {
            if (_settlement != null)
            {
                return _settlement;
            }
            
            var file = GetSettlementFile();
            return await Api.ApiSettlements.Upload(file);
        }

        private byte[] GetSettlementFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fi = this.GetFileInfoOfFile(assembly.Location, "settlement_sample.csv");
            return File.ReadAllBytes(fi.FullName);
        }
    }
}
