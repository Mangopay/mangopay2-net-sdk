using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    [Explicit]
    public class ApiRecipientsTest : BaseTest
    {
        private static RecipientDTO _recipient;

        [Test]
        public async Task Test_CreateRecipient_VerificationOfPayeeNull()
        {
            await GetNewRecipient();

            Assert.IsNotNull(_recipient);
            Assert.IsNotNull(_recipient.Status);
            Assert.IsNotNull(_recipient.DisplayName);
            Assert.IsNotNull(_recipient.PayoutMethodType);
            Assert.IsNotNull(_recipient.RecipientType);
            Assert.IsNotNull(_recipient.RecipientScope);
            Assert.IsNotNull(_recipient.UserId);
            Assert.IsNotNull(_recipient.IndividualRecipient);
            Assert.IsNotNull(_recipient.LocalBankTransfer);
            Assert.IsNotNull(_recipient.LocalBankTransfer["GBP"].SortCode);
            Assert.IsNotNull(_recipient.LocalBankTransfer["GBP"].AccountNumber);
            Assert.IsNotNull(_recipient.PendingUserAction);
            Assert.IsNotNull(_recipient.Country);
            Assert.IsNull(_recipient.RecipientVerificationOfPayee);
        }
        
        [Test]
        public async Task Test_CreateRecipient_VerificationOfPayeeNotNull()
        {
            RecipientPostDTO postDto = new RecipientPostDTO();

            Dictionary<string, object> localBankTransfer = new Dictionary<string, object>();
            Dictionary<string, object> details = new Dictionary<string, object>();
            details.Add("IBAN", "DE75512108001245126199");
            localBankTransfer.Add(CurrencyIso.EUR.ToString(), details);

            postDto.DisplayName = "My EUR account";
            postDto.PayoutMethodType = "LocalBankTransfer";
            postDto.RecipientType = "Individual";
            postDto.Currency = CurrencyIso.EUR;
            postDto.IndividualRecipient = new IndividualRecipient()
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new Address
                {
                    AddressLine1 = "Address line 1",
                    AddressLine2 = "Address line 2",
                    City = "Paris",
                    Country = CountryIso.DE,
                    PostalCode = "11222",
                    Region = "Paris"
                }
            };
            postDto.LocalBankTransfer = localBankTransfer;
            postDto.Country = CountryIso.DE;
            
            UserNaturalScaDTO john = await GetJohnScaOwner();
            RecipientDTO recipient = await Api.Recipients.CreateAsync(postDto, john.Id);
            
            Assert.IsNotNull(recipient);
            Assert.IsNotNull(recipient.RecipientVerificationOfPayee);
        }

        [Test]
        public async Task Test_GetRecipient()
        {
            await GetNewRecipient();
            RecipientDTO fetched = await Api.Recipients.GetAsync(_recipient.Id);
            Assert.IsNotNull(fetched);
            Assert.AreEqual(_recipient.Id, fetched.Id);
            Assert.AreEqual(_recipient.Status, fetched.Status);
        }

        [Test]
        public async Task Test_GetUserRecipients()
        {
            await GetNewRecipient();
            UserNaturalScaDTO john = await GetJohnScaOwner();
            ListPaginated<RecipientDTO> recipients = await Api.Recipients.GetUserRecipientsAsync(john.Id);
            Assert.IsNotEmpty(recipients);
        }
        
        [Test]
        public async Task Test_GetUserRecipients_Payout()
        {
            await GetNewRecipient();
            UserNaturalScaDTO john = await GetJohnScaOwner();
            var filter = new FilterRecipients { RecipientScope = "PAYOUT" };
            ListPaginated<RecipientDTO> recipients = await Api.Recipients.GetUserRecipientsAsync(john.Id, filter: filter);
            Assert.IsNotEmpty(recipients);
        }
        
        [Test]
        public async Task Test_GetUserRecipients_PayIn()
        {
            await GetNewRecipient();
            UserNaturalScaDTO john = await GetJohnScaOwner();
            var filter = new FilterRecipients { RecipientScope = "PAYIN" };
            ListPaginated<RecipientDTO> recipients = await Api.Recipients.GetUserRecipientsAsync(john.Id, filter: filter);
            Assert.IsEmpty(recipients);
        }

        [Test]
        public async Task Test_GetPayoutMethods()
        {
            PayoutMethods payoutMethods = await Api.Recipients.GetPayoutMethodsAsync(CountryIso.DE, CurrencyIso.EUR);
            Assert.IsNotNull(payoutMethods);
            Assert.IsNotEmpty(payoutMethods.AvailablePayoutMethods);
        }

        [Test]
        public async Task Test_GetSchema_LocalBankTransfer_Individual()
        {
            RecipientSchemaDTO schema =
                await Api.Recipients.GetSchemaAsync("LocalBankTransfer", "Individual",
                    CurrencyIso.GBP, CountryIso.GB);
            Assert.IsNotNull(schema);
            Assert.IsNotNull(schema.DisplayName);
            Assert.IsNotNull(schema.Currency);
            Assert.IsNotNull(schema.RecipientType);
            Assert.IsNotNull(schema.PayoutMethodType);
            Assert.IsNotNull(schema.RecipientScope);
            Assert.IsNotNull(schema.Tag);
            Assert.IsNotNull(schema.LocalBankTransfer);
            Assert.IsNotNull(schema.IndividualRecipient);
            Assert.IsNull(schema.InternationalBankTransfer);
            Assert.IsNull(schema.BusinessRecipient);
            Assert.IsNotNull(schema.Country);
        }

        [Test]
        public async Task Test_GetSchema_InternationalBankTransfer_Business()
        {
            RecipientSchemaDTO schema =
                await Api.Recipients.GetSchemaAsync("InternationalBankTransfer", "Business",
                    CurrencyIso.GBP, CountryIso.GB);
            Assert.IsNotNull(schema);
            Assert.IsNotNull(schema.DisplayName);
            Assert.IsNotNull(schema.Currency);
            Assert.IsNotNull(schema.RecipientType);
            Assert.IsNotNull(schema.PayoutMethodType);
            Assert.IsNotNull(schema.RecipientScope);
            Assert.IsNotNull(schema.Tag);
            Assert.IsNotNull(schema.InternationalBankTransfer);
            Assert.IsNotNull(schema.BusinessRecipient);
            Assert.IsNull(schema.LocalBankTransfer);
            Assert.IsNull(schema.IndividualRecipient);
            Assert.IsNotNull(schema.Country);
        }

        [Test]
        public async Task Test_ValidateRecipient()
        {
            RecipientPostDTO postDto = GetPostDto();
            UserNaturalScaDTO john = await GetJohnScaOwner();
            // should pass
            await Api.Recipients.ValidateAsync(postDto, john.Id);

            // should fail
            postDto.DisplayName = null;
            try
            {
                await Api.Recipients.ValidateAsync(postDto, john.Id);
            }
            catch (Exception e)
            {
                Assert.True(e.Message.Contains("One or several required parameters are missing or incorrect"));
            }
        }

        [Test]
        [Ignore("The recipient needs to be manually activated before running the test")]
        public async Task Test_DeactivateRecipient()
        {
            await GetNewRecipient();
            Assert.AreEqual("PENDING", _recipient.Status);
            RecipientPutDTO putDto = new RecipientPutDTO() { Status = "DEACTIVATED" };

            RecipientDTO deactivated = await Api.Recipients.DeactivateAsync(putDto, _recipient.Id);
            RecipientDTO fetched = await Api.Recipients.GetAsync(_recipient.Id);
            Assert.AreEqual("DEACTIVATED", deactivated.Status);
            Assert.AreEqual("DEACTIVATED", fetched.Status);
        }

        private async Task GetNewRecipient()
        {
            if (_recipient == null)
            {
                UserNaturalScaDTO john = await GetJohnScaOwner();
                RecipientPostDTO postDto = GetPostDto();
                _recipient = await Api.Recipients.CreateAsync(postDto, john.Id);
            }
        }

        private RecipientPostDTO GetPostDto()
        {
            RecipientPostDTO postDto = new RecipientPostDTO();

            Dictionary<string, object> localBankTransfer = new Dictionary<string, object>();
            Dictionary<string, object> gbpDetails = new Dictionary<string, object>();
            gbpDetails.Add("SortCode", "010039");
            gbpDetails.Add("AccountNumber", "11696419");
            localBankTransfer.Add(CurrencyIso.GBP.ToString(), gbpDetails);

            postDto.DisplayName = "My DB account";
            postDto.PayoutMethodType = "LocalBankTransfer";
            postDto.RecipientType = "Individual";
            postDto.Currency = CurrencyIso.GBP;
            postDto.IndividualRecipient = new IndividualRecipient()
            {
                FirstName = "Payout",
                LastName = "Team",
                Address = new Address
                {
                    AddressLine1 = "Address line 1",
                    AddressLine2 = "Address line 2",
                    City = "Paris",
                    Country = CountryIso.FR,
                    PostalCode = "11222",
                    Region = "Paris"
                }
            };
            postDto.LocalBankTransfer = localBankTransfer;
            postDto.Country = CountryIso.GB;

            return postDto;
        }
    }
}