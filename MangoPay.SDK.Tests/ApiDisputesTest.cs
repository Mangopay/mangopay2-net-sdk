using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MangoPay.SDK.Tests
{
    [TestClass]
	public class ApiDisputesTest : BaseTest
	{

		/* IMPORTANT NOTE!
		 * 
		 * Due to the fact the disputes CANNOT be created on user's side,
		 * a special approach in testing is needed. 
		 * In order to get the tests below pass, a bunch of disputes have
		 * to be prepared on the API's side - if they're not, you can
		 * just skip these tests, as they won't pass.
		 * 
		 */


		private ListPaginated<DisputeDTO> _clientDisputes = null;

		[TestInitialize]
		public void Initialize()
		{
			Sort sort = new Sort();
			sort.AddField("CreationDate", SortDirection.desc);

			_clientDisputes = Api.Disputes.GetAll(new Pagination(1, 100), null, sort);

			if (_clientDisputes == null || _clientDisputes.Count == 0)
				Assert.Fail("INITIALIZATION FAILURE - cannot test disputes");
		}

		[TestMethod]
		public void Test_GetDispute()
		{
			DisputeDTO dispute = null;

			try
			{
				dispute = Api.Disputes.Get(_clientDisputes[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(dispute);
			Assert.AreEqual(dispute.Id, _clientDisputes[0].Id);
		}

		[TestMethod]
		public void Test_GetTransactions()
		{
			ListPaginated<TransactionDTO> result = null;

			try
			{
				result = Api.Disputes.GetTransactions(_clientDisputes[0].Id, new Pagination(1, 10), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void Test_GetDisputesForWallet()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null);

			if (dispute == null)
				Assert.Fail("Cannot test getting disputes for wallet because there's no disputes with transaction ID in the disputes list.");

			ListPaginated<DisputeDTO> result = null;

			try
			{
				string walletId = Api.PayIns.Get(dispute.InitialTransactionId).CreditedWalletId;

				result = Api.Disputes.GetDisputesForWallet(walletId, new Pagination(1, 10), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_GetDisputesForUser()
		{
			ListPaginated<DisputeDTO> result = null;

			try
			{
				string userId = Api.Disputes.GetTransactions(_clientDisputes[0].Id, new Pagination(1, 1), null)[0].AuthorId;

				result = Api.Disputes.GetDisputesForUser(userId, new Pagination(1, 20), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void Test_CreateDisputeDocument()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);

				result = Api.Disputes.CreateDisputeDocument(documentPost, dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Type, DisputeDocumentType.DELIVERY_PROOF);
		}

		[TestMethod]
		public void Test_CreateDisputePage()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document page because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);
				result = Api.Disputes.CreateDisputeDocument(documentPost, dispute.Id);

				Api.Disputes.CreateDisputePage(dispute.Id, result.Id, "TestKycPageFile.png");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Type, DisputeDocumentType.DELIVERY_PROOF);
		}

		[TestMethod]
		public void Test_ContestDispute()
		{
			DisputeDTO notContestedDispute = _clientDisputes.FirstOrDefault(x => (x.DisputeType == DisputeType.CONTESTABLE || x.DisputeType == DisputeType.RETRIEVAL) 
				&& (x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION));

			if (notContestedDispute == null)
				Assert.Fail("Cannot test contesting dispute because there's no disputes that can be contested in the disputes list.");

			DisputeDTO result = null;

			try
			{
				Money contestedFunds = notContestedDispute.Status == DisputeStatus.PENDING_CLIENT_ACTION ? new Money { Amount = 100, Currency = CurrencyIso.EUR } : null;

				result = Api.Disputes.ContestDispute(contestedFunds, notContestedDispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Id, notContestedDispute.Id);
		}

		[TestMethod]
		public void Test_SaveTag()
		{
			DisputeDTO result = null;

			string newTag = "New tag: " + DateTime.UtcNow.Ticks.ToString();

			try
			{
				result = Api.Disputes.UpdateTag(newTag, _clientDisputes[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.AreEqual(result.Tag, newTag);
		}

		[TestMethod]
		public void Test_CloseDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test closing dispute because there's no available disputes with expected status in the disputes list.");

			DisputeDTO result = null;

			try
			{
				result = Api.Disputes.CloseDispute(dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_GetDocument()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test getting dispute's document because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO document = null;
			DisputeDocumentDTO result = null;

			try
			{
				DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.OTHER);
				document = Api.Disputes.CreateDisputeDocument(documentPost, dispute.Id);

				result = Api.Disputes.GetDocument(document.Id);
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

		[TestMethod]
		public void Test_GetDocumentsForDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.SUBMITTED);

			if (dispute == null)
				Assert.Fail("Cannot test getting dispute's documents because there's no available disputes with SUBMITTED status in the disputes list.");

			ListPaginated<DisputeDocumentDTO> result = null;

			try
			{
				result = Api.Disputes.GetDocumentsForDispute(dispute.Id, new Pagination(1, 1), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_GetDocumentsForClient()
		{
			ListPaginated<DisputeDocumentDTO> result = null;

			try
			{
				result = Api.Disputes.GetDocumentsForClient(new Pagination(1, 1), null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_SubmitDisputeDocument()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			if (dispute == null)
				Assert.Fail("Cannot test submitting dispute's documents because there's no dispute with expected status in the disputes list.");

			DisputeDocumentDTO disputeDocument = null;

			DisputeDocumentDTO result = null;

			try
			{
				disputeDocument = Api.Disputes.GetDocumentsForDispute(dispute.Id, new Pagination(1, 1), null).First();

				DisputeDocumentPutDTO disputeDocumentPut = new DisputeDocumentPutDTO
				{
					Status = DisputeDocumentStatus.VALIDATION_ASKED
				};

				result = Api.Disputes.SubmitDisputeDocument(disputeDocumentPut, dispute.Id, disputeDocument.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(disputeDocument.Type == result.Type);
			Assert.IsTrue(result.Status == DisputeDocumentStatus.VALIDATION_ASKED);
		}

		[TestMethod]
		public void Test_GetRepudiation()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null);

			RepudiationDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test getting repudiation because there's no disputes with transaction ID in the disputes list.");

			try
			{
				string repudiationId = Api.Disputes.GetTransactions(dispute.Id, new Pagination(1, 1), null)[0].Id;

				result = Api.Disputes.GetRepudiation(repudiationId);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_CreateSettlementTransfer()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.CLOSED);

			RepudiationDTO repudiation = null;
			TransferDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test creating settlement transfer because there's no closed disputes in the disputes list.");

			try
			{
				string repudiationId = Api.Disputes.GetTransactions(dispute.Id, new Pagination(1, 1), null)[0].Id;

				repudiation = Api.Disputes.GetRepudiation(repudiationId);

				SettlementTransferPostDTO post = new SettlementTransferPostDTO(repudiation.AuthorId, new Money { Currency = CurrencyIso.EUR, Amount = 1 }, new Money { Currency = CurrencyIso.EUR, Amount = 0 });

				result = Api.Disputes.CreateSettlementTransfer(post, repudiationId);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test_GetFilteredDisputes()
		{
			ListPaginated<DisputeDTO> result1 = null;
			ListPaginated<DisputeDTO> result2 = null;

			try
			{
				result1 = Api.Disputes.GetAll(new Pagination(1, 100), new FilterDisputes { AfterDate = DateTime.Now });
				result2 = Api.Disputes.GetAll(new Pagination(1, 100), new FilterDisputes { BeforeDate = DateTime.Now });
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result1);
			Assert.IsNotNull(result2);
			Assert.IsTrue(result1.Count == 0);
			Assert.IsTrue(result2.Count > 0);
		}

		[TestMethod]
		public void Test_GetFilteredDisputeDocuments()
		{
			ListPaginated<DisputeDocumentDTO> result1 = null;
			ListPaginated<DisputeDocumentDTO> result2 = null;
			ListPaginated<DisputeDocumentDTO> result3 = null;

			try
			{
				result1 = Api.Disputes.GetDocumentsForClient(new Pagination(1, 100), new FilterDisputeDocuments { AfterDate = DateTime.Now });
				result2 = Api.Disputes.GetDocumentsForClient(new Pagination(1, 100), new FilterDisputeDocuments { BeforeDate = DateTime.Now });
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
				result3 = Api.Disputes.GetDocumentsForClient(new Pagination(1, 100), new FilterDisputeDocuments { Type = result2[0].Type });
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

		[TestMethod]
		public void Test_ResubmitDispute()
		{
			DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);

			DisputeDTO result = null;

			if (dispute == null)
				Assert.Fail("Cannot test resubmitting dispute because there's no re-opened disputes in the disputes list.");

			try
			{
				result = Api.Disputes.ResubmitDispute(dispute.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Status == DisputeStatus.SUBMITTED);
		}
    }
}
