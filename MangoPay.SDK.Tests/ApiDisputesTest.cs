using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{

	/* IMPORTANT NOTE!
	 * 
	 * Due to the fact the disputes CANNOT be created on user's side,
	 * a special approach in testing is needed. 
	 * In order to get the tests below pass, a bunch of disputes has
	 * to be prepared on the API's side - if it's not, the tests won't pass.
	 * 
	 */


	[TestFixture]
    [Explicit]
	public class ApiDisputesTest : BaseTest
	{
		private ListPaginated<DisputeDTO> _clientDisputes = null;

		[SetUp]
		public async Task Initialize()
		{
			Sort sort = new Sort();
			sort.AddField("CreationDate", SortDirection.desc);

			_clientDisputes = await Api.Disputes.GetAllAsync(new Pagination(1, 100), null, sort);

			if (_clientDisputes == null || _clientDisputes.Count == 0)
				Assert.Fail("INITIALIZATION FAILURE - cannot test disputes");
		}

		[Test]
		public async Task Test_GetDispute()
		{
			DisputeDTO dispute = null;

			try
			{
				dispute = await Api.Disputes.GetAsync(_clientDisputes[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(dispute);
			Assert.AreEqual(dispute.Id, _clientDisputes[0].Id);
		}

		[Test]
		public async Task Test_GetTransactions()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.DisputeType.HasValue && x.DisputeType.Value == DisputeType.NOT_CONTESTABLE);

			if (dispute == null)
				Assert.Fail("Cannot test getting transactions for dispute there's no not contestable disputes in the disputes list.");
			
			ListPaginated<TransactionDTO> result = null;

			try
			{
				result = await Api.Disputes.GetTransactionsAsync(dispute.Id, new Pagination(1, 10), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}

		[Test]
		public async Task Test_GetDisputesForWallet()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null);

			if (dispute == null)
				Assert.Fail("Cannot test getting disputes for wallet because there's no disputes with transaction ID in the disputes list.");

			ListPaginated<DisputeDTO> result = null;

			try
			{
                var wallet = await Api.PayIns.GetAsync(dispute.InitialTransactionId);
				string walletId = wallet.CreditedWalletId;

				result = await Api.Disputes.GetDisputesForWalletAsync(walletId, new Pagination(1, 10), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task Test_GetDisputesForUser()
		{
			ListPaginated<DisputeDTO> result = null;

			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.DisputeType.HasValue && x.DisputeType.Value == DisputeType.NOT_CONTESTABLE);
			
			if (dispute == null)
				Assert.Fail("Cannot test getting disputes for user because there's no not contestable disputes in the disputes list.");

			try
			{
                var user = await Api.Disputes.GetTransactionsAsync(dispute.Id, new Pagination(1, 1), null);

                string userId = user[0].AuthorId;

				result = await Api.Disputes.GetDisputesForUserAsync(userId, new Pagination(1, 20), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}
		
		[Test]
		public async Task Test_GetDisputesForPayIn()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null);

			if (dispute == null)
				Assert.Fail("Cannot test getting disputes for wallet because there's no disputes with transaction ID in the disputes list.");

			ListPaginated<DisputeDTO> result = null;

			try
			{
				var payIn = await Api.PayIns.GetAsync(dispute.InitialTransactionId);
				result = await Api.Disputes.GetDisputesForPayInAsync(payIn.Id, new Pagination(1, 10), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}

	    [Test]
	    public async Task Test_GetDisputesPendingSettlement()
	    {
	        ListPaginated<DisputeDTO> result = null;

	        try
	        {
	            result = await Api.Disputes.GetDisputesPendingSettlementAsync(new Pagination(1, 10), null);
	        }
	        catch (Exception ex)
	        {
	            Assert.Fail(ex.Message);
	        }

            Assert.IsNotNull(result);
	    }

		[Test]
		public async Task Test_CreateDisputeDocument()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);

				result = await Api.Disputes.CreateDisputeDocumentAsync(documentPost, dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Type, DisputeDocumentType.DELIVERY_PROOF);
		}

		[Test]
		public async Task Test_CreateDisputePage()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document page because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);
				result = await Api.Disputes.CreateDisputeDocumentAsync(documentPost, dispute.Id);

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");
				await Api.Disputes.CreateDisputePageAsync(dispute.Id, result.Id, fi.FullName);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Type, DisputeDocumentType.DELIVERY_PROOF);
		}

		[Test]
        [Ignore("API isn't ready")]
		public async Task Test_ContestDispute()
		{
			DisputeDTO notContestedDispute = _clientDisputes.FirstOrDefault(x => (x.DisputeType == DisputeType.CONTESTABLE || x.DisputeType == DisputeType.RETRIEVAL) 
				&& (x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION));

			if (notContestedDispute == null)
				Assert.Fail("Cannot test contesting dispute because there's no disputes that can be contested in the disputes list.");

			DisputeDTO result = null;

			try
			{
				Money contestedFunds = notContestedDispute.Status == DisputeStatus.PENDING_CLIENT_ACTION ? new Money { Amount = 100, Currency = CurrencyIso.EUR } : null;

				result = await Api.Disputes.ContestDisputeAsync(contestedFunds, notContestedDispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Id, notContestedDispute.Id);
		}

		[Test]
		public async Task Test_SaveTag()
		{
			DisputeDTO result = null;

			string newTag = "New tag: " + DateTime.UtcNow.Ticks.ToString();

			try
			{
				result = await Api.Disputes.UpdateTagAsync(newTag, _clientDisputes[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Tag, newTag);
		}

		[Test]
		[Ignore("API isn't ready")]
		public async Task Test_CloseDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test closing dispute because there's no available disputes with expected status in the disputes list.");

			DisputeDTO result = null;

			try
			{
				result = await Api.Disputes.CloseDisputeAsync(dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task Test_GetDocument()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test getting dispute's document because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO document = null;
			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.OTHER);
				document = await Api.Disputes.CreateDisputeDocumentAsync(documentPost, dispute.Id);

				result = await Api.Disputes.GetDocumentAsync(document.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.CreationDate, document.CreationDate);
			Assert.AreEqual(result.Id, document.Id);
			Assert.AreEqual(result.RefusedReasonMessage, document.RefusedReasonMessage);
			Assert.AreEqual(result.RefusedReasonType, document.RefusedReasonType);
			Assert.AreEqual(result.Status, document.Status);
			Assert.AreEqual(result.Tag, document.Tag);
			Assert.AreEqual(result.Type, document.Type);
			Assert.AreEqual(result.DisputeId, document.DisputeId);
		}

		[Test]
		public async Task Test_GetDocumentsForDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.SUBMITTED);

			if (dispute == null)
			{
				await Test_ContestDispute();
				await Initialize();

				dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.SUBMITTED);
				
				if (dispute == null)
					Assert.Fail("Cannot test getting dispute's documents because there's no available disputes with SUBMITTED status in the disputes list.");
			}

			ListPaginated<DisputeDocumentDTO> result = null;

			try
			{
				result = await Api.Disputes.GetDocumentsForDisputeAsync(dispute.Id, new Pagination(1, 1), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task Test_GetDocumentsForClient()
		{
			ListPaginated<DisputeDocumentDTO> result = null;

			try
			{
				result = await Api.Disputes.GetDocumentsForClientAsync(new Pagination(1, 1), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
        [Ignore("API isn't ready")]
		public async Task Test_SubmitDisputeDocument()
		{
			DisputeDTO dispute = null;
			DisputeDocumentDTO disputeDocument = null;

			FilterDisputeDocuments filter = new FilterDisputeDocuments();
			filter.Status = DisputeDocumentStatus.CREATED;

			// search for dispute having any documents created
			foreach (DisputeDTO d in _clientDisputes.Where(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION))
			{
                var docs = await Api.Disputes.GetDocumentsForDisputeAsync(d.Id, new Pagination(1, 1), filter);
				DisputeDocumentDTO dd = docs.FirstOrDefault();

				if (dd != null)
				{// found
					dispute = d;
					disputeDocument = dd;
					break;
				}
			}

			if (dispute == null)
			{
				dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

				if (dispute == null)
					Assert.Fail("Cannot test submitting dispute's documents because there's no dispute with expected status in the disputes list.");

				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);
				disputeDocument = await Api.Disputes.CreateDisputeDocumentAsync(documentPost, dispute.Id);
			}

			DisputeDocumentDTO result = null;

			try
			{
				if (disputeDocument == null)
					Assert.Fail("Cannot test submitting dispute's documents because there's no dispute document that can be updated.");

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");
				await Api.Disputes.CreateDisputePageAsync(dispute.Id, disputeDocument.Id, fi.FullName);

				DisputeDocumentPutDTO disputeDocumentPut = new DisputeDocumentPutDTO
				{
					Status = DisputeDocumentStatus.VALIDATION_ASKED
				};

				result = await Api.Disputes.SubmitDisputeDocumentAsync(disputeDocumentPut, dispute.Id, disputeDocument.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(disputeDocument.Type == result.Type);
			Assert.IsTrue(result.Status == DisputeDocumentStatus.VALIDATION_ASKED);
		}

		[Test]
		public async Task Test_GetRepudiation()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null && x.DisputeType.HasValue && x.DisputeType.Value == DisputeType.NOT_CONTESTABLE);

			RepudiationDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test getting repudiation because there's no not contestable disputes with transaction ID in the disputes list.");

			try
			{
                var transactionsDTO = await Api.Disputes.GetTransactionsAsync(dispute.Id, new Pagination(1, 1), null);
				string repudiationId = transactionsDTO[0].Id;

				result = await Api.Disputes.GetRepudiationAsync(repudiationId);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task Test_CreateSettlementTransfer()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.CLOSED && x.DisputeType == DisputeType.NOT_CONTESTABLE);

			RepudiationDTO repudiation = null;
			SettlementDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test creating settlement transfer because there's no closed disputes in the disputes list.");

			try
			{
                var transactionDTOs = await Api.Disputes.GetTransactionsAsync(dispute.Id, new Pagination(1, 1), null);
				string repudiationId = transactionDTOs[0].Id;

				repudiation = await Api.Disputes.GetRepudiationAsync(repudiationId);

				SettlementTransferPostDTO post = new SettlementTransferPostDTO(repudiation.AuthorId, new Money { Currency = CurrencyIso.EUR, Amount = 1 }, new Money { Currency = CurrencyIso.EUR, Amount = 0 });

				result = await Api.Disputes.CreateSettlementTransferAsync(post, repudiationId);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public async Task Test_GetFilteredDisputes()
		{
			ListPaginated<DisputeDTO> result1 = null;
			ListPaginated<DisputeDTO> result2 = null;
			ListPaginated<DisputeDTO> result3 = null;
			ListPaginated<DisputeDTO> result4 = null;

			try
			{
				result1 = await Api.Disputes.GetAllAsync(new Pagination(1, 100), new FilterDisputes { AfterDate = DateTime.Now });
				result2 = await Api.Disputes.GetAllAsync(new Pagination(1, 100), new FilterDisputes { BeforeDate = DateTime.Now });
				result3 = await Api.Disputes.GetAllAsync(new Pagination(1, 100), new FilterDisputes { Type = DisputeType.CONTESTABLE });
				result4 = await Api.Disputes.GetAllAsync(new Pagination(1, 100), new FilterDisputes { Status = DisputeStatus.SUBMITTED });
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result1);
			Assert.IsNotNull(result2);
			Assert.IsNotNull(result3);
			Assert.IsNotNull(result4);
			Assert.IsTrue(result1.Count == 0);
			Assert.IsTrue(result2.Count > 0);
			Assert.IsTrue(result3.Count > 0);
			Assert.IsTrue(result4.Count > 0);

			foreach (DisputeDTO dispute in result3)
			{
				Assert.AreEqual(dispute.DisputeType, DisputeType.CONTESTABLE);
			}

			foreach (DisputeDTO dispute in result4)
			{
				Assert.AreEqual(dispute.Status, DisputeStatus.SUBMITTED);
			}
		}

		[Test]
		public async Task Test_GetFilteredDisputeDocuments()
		{
			ListPaginated<DisputeDocumentDTO> result1 = null;
			ListPaginated<DisputeDocumentDTO> result2 = null;
			ListPaginated<DisputeDocumentDTO> result3 = null;

			try
			{
				result1 = await Api.Disputes.GetDocumentsForClientAsync(new Pagination(1, 100), new FilterDisputeDocuments { AfterDate = DateTime.Now });
				result2 = await Api.Disputes.GetDocumentsForClientAsync(new Pagination(1, 100), new FilterDisputeDocuments { BeforeDate = DateTime.Now });
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result1);
			Assert.IsNotNull(result2);
			Assert.IsTrue(result1.Count == 0);
			Assert.IsTrue(result2.Count > 0);

			try
			{
				result3 = await Api.Disputes.GetDocumentsForClientAsync(new Pagination(1, 100), new FilterDisputeDocuments { Type = result2[0].Type });
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result3);
			Assert.IsTrue(result3.Count > 0);
			foreach (DisputeDocumentDTO dd in result3)
			{
				Assert.IsTrue(dd.Type == result2[0].Type);
			}
		}

		[Test]
        [Ignore("API isn't ready")]
		public async Task Test_ResubmitDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			DisputeDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test resubmitting dispute because there's no re-opened disputes in the disputes list.");

			try
			{
				result = await Api.Disputes.ResubmitDisputeAsync(dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Status == DisputeStatus.SUBMITTED);
		}

		[Test]
		public async Task Test_GetSettlementTransfer()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.CLOSED && x.DisputeType.HasValue && x.DisputeType.Value == DisputeType.NOT_CONTESTABLE);

			RepudiationDTO repudiation = null;
			SettlementDTO transfer = null;

			if (dispute == null)
				Assert.Fail("Cannot test getting settlement transfer because there's no closed and not contestable disputes in the disputes list.");

			try
			{
                var transactions = await Api.Disputes.GetTransactionsAsync(dispute.Id, new Pagination(1, 1), null);
				string repudiationId = transactions[0].Id;

				repudiation = await Api.Disputes.GetRepudiationAsync(repudiationId);

				SettlementTransferPostDTO post = new SettlementTransferPostDTO(repudiation.AuthorId, new Money { Currency = CurrencyIso.EUR, Amount = 1 }, new Money { Currency = CurrencyIso.EUR, Amount = 0 });

				transfer = await Api.Disputes.CreateSettlementTransferAsync(post, repudiationId);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(transfer);


			SettlementDTO result = null;

			try
			{
				result = await Api.Disputes.GetSettlementTransferAsync(transfer.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
            Assert.IsInstanceOf<SettlementDTO>(result);
			Assert.IsNotNull(result.RepudiationId);
			Assert.AreEqual(result.RepudiationId, repudiation.Id);
		}

		[Test]
		public async Task Test_GetDocumentConsultations()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document page because there's no dispute with expected status in the disputes list.");
			
			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);
				var disputeDocument = await Api.Disputes.CreateDisputeDocumentAsync(documentPost, dispute.Id);
                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");
				byte[] bytes = File.ReadAllBytes(fi.FullName);
				await Api.Disputes.CreateDisputePageAsync(dispute.Id, disputeDocument.Id, bytes);

				var result = await Api.Disputes.GetDocumentConsultationsAsync(disputeDocument.Id);

				Assert.AreEqual(1, result.Count);
				Assert.IsInstanceOf<DateTime>(result.First().ExpirationDate);
				Assert.IsInstanceOf<string>(result.First().Url);
				Assert.IsNotEmpty(result.First().Url);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}		
	}
}
